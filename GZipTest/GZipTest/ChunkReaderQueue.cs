using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GZipTest
{
	internal class ChunkReaderQueue : IChunkReader, IWorkProvider
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
		private int[] _ChunkInProgressIndices;
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

						if (chunk.Exception != null)
							throw chunk.Exception;

						buffer = chunk.Buffer;
						chunkIndex = chunk.Index;
						length = chunk.Length;

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
			int threadIndex = Interlocked.Increment(ref _ThreadIndex);

			_ChunkInProgressIndices[threadIndex] = int.MaxValue;

			Chunk chunk;
			while (!_IsStopped && !_IsException)
			{
				Interlocked.Increment(ref _ChunkCountInProgress);

				try
				{
					lock (ChunkReader)
					{
						if (!_IsException)
						{
							chunk = ReadChunkFromReader();

							if (chunk.Exception != null)
								_IsException = true;
							else
								_ChunkInProgressIndices[threadIndex] = (chunk.Index < 0) ? int.MaxValue : chunk.Index;
						}
						else
							break;
					}

					if (chunk.Length > 0)
					{
						AddChunkToQueue(chunk);
					}

					if ((chunk.Length == 0) || (chunk.Exception != null))
						break;
				}
				finally
				{
					Interlocked.Decrement(ref _ChunkCountInProgress);
				}
			}
		}

		private Chunk ReadChunkFromReader()
		{
			int read = 1;//if exception occur add chunk to queue to rethrow it
			byte[] buffer = null;
			int chunkIndex = -1;
			Exception exception = null;

			try
			{
				read = ChunkReader.ReadChunk(out buffer, out chunkIndex);
			}
			catch (Exception ex)
			{
				exception = ex;
			}
			return new Chunk()
			{
				Buffer = buffer,
				Exception = exception,
				Index = chunkIndex,
				Length = read
			};
		}

		private void AddChunkToQueue(Chunk chunk)
		{
			while (true)
			{
				_WaitForRemoveEvent.Wait(500);

				lock (_ChunkQueue)
				{
					int minIndex = _ChunkInProgressIndices.Min();

					if ((minIndex == _ChunkCountEnqueued + 1 - _WorkDoer.ThreadCount && chunk.Index == minIndex)
						|| (minIndex > _ChunkCountEnqueued + 1 - _WorkDoer.ThreadCount && _ChunkCountEnqueued < chunk.Index + _WorkDoer.ThreadCount && _ChunkCountEnqueued > chunk.Index - _WorkDoer.ThreadCount))
					{
						_ChunkQueue.Enqueue(chunk);
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

		public ChunkReaderQueue(IChunkReader chunkReader, IWorkDoer workDoer, int queueLength)
		{
			_WorkDoer = workDoer;
			_QueueLength = queueLength;
			ChunkReader = chunkReader;
			_WaitForAddEvent = new ManualResetEventSlim(false);
			_WaitForRemoveEvent = new ManualResetEventSlim(true);
			_ChunkInProgressIndices = new int[workDoer.ThreadCount];
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

		class Chunk
		{
			public byte[] Buffer;
			public int Index;
			public int Length;
			public Exception Exception;
		}
	}
}
