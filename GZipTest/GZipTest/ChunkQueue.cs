using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GZipTest
{
	internal class ChunkQueue : IChunkReader, IWorkProvider
	{
		private readonly int _QueueLength;
		private IWorkDoer _WorkDoer;

		public IChunkReader ChunkReader { get; private set; }

		private readonly ManualResetEventSlim _WaitForAddEvent;
		private readonly ManualResetEventSlim _WaitForRemoveEvent;

		private volatile int _IsRunning;
		private volatile bool _IsStopped;
		private volatile bool _IsException;

		private volatile int _ChunkCountInProgress;
		private int[] _ChunkIndexInProgress;
		private volatile int _ThreadIndex = -1;
		private volatile int _ChunkCountEnqueued;

		private Queue<Chunk> _ChunkQueue = new Queue<Chunk>();

		public int ReadChunk(out byte[] buffer, out int chunkIndex)
		{
			if (Interlocked.CompareExchange(ref _IsRunning, 1, 0) == 0)
				_WorkDoer.DoWork(this);

			int length = -1;

			buffer = new byte[0];
			chunkIndex = -1;

			while (length < 0)
			{
				_WaitForAddEvent.Wait(500);

				lock (_ChunkQueue)
				{
					if (_ChunkQueue.Count > 0)
					{
						Chunk chunk = _ChunkQueue.Dequeue();

						length = chunk.Length;

						if (chunk.Exception != null)
							throw chunk.Exception;

						buffer = chunk.Buffer;
						chunkIndex = chunk.Index;

						_WaitForRemoveEvent.Set();
					}
					else if (_ChunkCountInProgress == 0)
						length = 0;
					else
						_WaitForAddEvent.Reset();
				}
			}

			return length;
		}

		private void FillQueue()
		{
			int read;
			byte[] buffer;
			int chunkIndex;
			Exception exception;
			bool isEnd = false;
			int threadIndex = Interlocked.Increment(ref _ThreadIndex);
			_ChunkIndexInProgress[threadIndex] = int.MaxValue;

			while (!isEnd && !_IsStopped && !_IsException)
			{
				Interlocked.Increment(ref _ChunkCountInProgress);

				try
				{
					lock (ChunkReader)
					{
						if (!_IsException)
						{
							try
							{
								read = ChunkReader.ReadChunk(out buffer, out chunkIndex);
								_ChunkIndexInProgress[threadIndex] = (chunkIndex < 0) ? int.MaxValue : chunkIndex;
								exception = null;
							}
							catch (Exception ex)
							{
								_IsException = true;
								exception = ex;
								buffer = null;
								chunkIndex = -1;
								read = 1;
							}
						}
						else
							break;
					}

					isEnd = (read == 0) || (exception != null);

					if (read > 0)
					{
						while (true)
						{
							_WaitForRemoveEvent.Wait(500);

							lock (_ChunkQueue)
							{
								int minIndex = _ChunkIndexInProgress.Min();

								if ((minIndex == _ChunkCountEnqueued + 1 - _WorkDoer.ThreadCount && chunkIndex == minIndex)
									|| (minIndex > _ChunkCountEnqueued + 1 - _WorkDoer.ThreadCount && _ChunkCountEnqueued < chunkIndex + _WorkDoer.ThreadCount && _ChunkCountEnqueued > chunkIndex - _WorkDoer.ThreadCount))
								{
									_ChunkQueue.Enqueue(new Chunk() { Buffer = buffer, Index = chunkIndex, Length = read, Exception = exception });
									_ChunkCountEnqueued++;
									_WaitForAddEvent.Set();
									break;
								}
								else
								{
									_WaitForRemoveEvent.Reset();
									continue;
								}
							}
						}
					}
				}
				finally
				{
					Interlocked.Decrement(ref _ChunkCountInProgress);
				}
			}
		}

		public ChunkQueue(IChunkReader chunkReader, IWorkDoer workDoer, int queueLength)
		{
			_WorkDoer = workDoer;
			_QueueLength = queueLength;
			ChunkReader = chunkReader;
			_WaitForAddEvent = new ManualResetEventSlim(false);
			_WaitForRemoveEvent = new ManualResetEventSlim(true);
			_ChunkIndexInProgress = new int[workDoer.ThreadCount];
		}

		private bool disposedValue = false;

		public Action GetWork() => FillQueue;

		public void StopWork()
		{
			_IsStopped = true;
			_WaitForRemoveEvent.Set();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					StopWork();

					_WorkDoer.Stop();
					_WorkDoer.WaitToEnd();

					ChunkReader?.Dispose();
					ChunkReader = null;
				}

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		struct Chunk
		{
			public byte[] Buffer;
			public int Index;
			public int Length;
			public Exception Exception;
		}
	}
}
