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

		private readonly SemaphoreSlim _Semaphore;

		private int _IsRunning = 0;

		private volatile bool _IsEndOfStream;
		private volatile bool _IsException;
		private volatile bool _IsStopped;

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

						_Semaphore.Release();
					}
					else if (_IsEndOfStream || _IsException || _IsStopped)
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
			while (!_IsEndOfStream && !_IsException && !_IsStopped)
			{
				if (_Semaphore.Wait(500))
				{
					int chunkIndex;

					Exception exception = null;
					try
					{
						read = ChunkReader.ReadChunk(out buffer, out chunkIndex);
					}
					catch (Exception ex)
					{
						_IsException = true;

						exception = ex;
						buffer = null;
						chunkIndex = -1;
						read = 0;
					}

					_IsEndOfStream = (read == 0);

					if (!_IsEndOfStream)
						lock (_ChunkQueue)
						{
							_ChunkQueue.Enqueue(new Chunk() { Buffer = buffer, Index = chunkIndex, Length = read, Exception = exception });
							_WaitForAddEvent.Set();
						}
				}
			}
		}

		public ChunkQueue(IChunkReader chunkReader, IWorkDoer workDoer, int queueLength)
		{
			ChunkReader = chunkReader;
			_QueueLength = queueLength;
			_WorkDoer = workDoer;
			_WaitForAddEvent = new ManualResetEventSlim(false);
			_Semaphore = new SemaphoreSlim(workDoer.ThreadCount, workDoer.ThreadCount);
		}

		private bool disposedValue = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_WorkDoer.Stop();
					_WorkDoer.WaitToEnd();

					_WaitForAddEvent?.Dispose();

					_Semaphore?.Dispose();

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

		public Action GetWork() => FillQueue;

		public void StopWork()
		{
			_IsStopped = true;
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
