using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GZipTest
{
	internal class ChunkQueue : IChunkReader
	{
		private readonly int _QueueLength;

		public IChunkReader ChunkReader { get; private set; }

		private Thread _WorkThread;

		private readonly ManualResetEventSlim _WaitForAddEvent;
		private readonly ManualResetEventSlim _WaitForRemoveEvent;

		private int _IsRunning = 0;
		private volatile bool _IsEndOfStream;

		private Queue<Chunk> _ChunkQueue = new Queue<Chunk>();

		public int ReadChunk(out byte[] buffer, out int chunkIndex)
		{
			if (Interlocked.CompareExchange(ref _IsRunning, 1, 0) == 0)
				Run();

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
					else if (_IsEndOfStream)
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
			while (!_IsEndOfStream)
			{
				_WaitForRemoveEvent.Wait(500);

				lock (_ChunkQueue)
				{
					if (_ChunkQueue.Count == _QueueLength)
					{
						_WaitForRemoveEvent.Reset();
						continue;
					}
				}

				int chunkIndex;

				Exception exception = null;
				try
				{
					read = ChunkReader.ReadChunk(out buffer, out chunkIndex);
				}
				catch (Exception ex)
				{
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
					}

				_WaitForAddEvent.Set();
			}
		}

		public void Run()
		{
			_WorkThread = new Thread(FillQueue);
			_WorkThread.Name = "ReadThread";
			_WorkThread.IsBackground = true;

			_WorkThread.Start();
		}

		public void FinishFillQueue()
		{
			_IsEndOfStream = true;
			_WaitForRemoveEvent.Set();
			_WorkThread?.Join();
			_WorkThread = null;
		}

		public ChunkQueue(IChunkReader chunkReader, int queueLength)
		{
			_QueueLength = queueLength;
			ChunkReader = chunkReader;
			_WaitForAddEvent = new ManualResetEventSlim(false);
			_WaitForRemoveEvent = new ManualResetEventSlim(true);
		}

		private bool disposedValue = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					FinishFillQueue();

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
