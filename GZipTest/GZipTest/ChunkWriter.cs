using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GZipTest
{
	internal class ChunkWriter : ChunkStreamBase, IChunkWriter
	{
		private ManualResetEventSlim EventSlim = new ManualResetEventSlim();

		public void Write(byte[] buffer, int offset, int count, int chunkIndex)
		{
			while (true)
			{
				bool isExpectedIndex = false;

				lock (InnerStream)
				{
					if (isExpectedIndex = chunkIndex == _ChunkIndex)
					{
						EventSlim.Reset();

						WriteBody(buffer, offset, count, chunkIndex);

						_ChunkIndex++;

						EventSlim.Set();
						break;
					}
				}

				if (!isExpectedIndex)
					EventSlim.Wait();
			}
		}

		protected virtual void WriteBody(byte[] buffer, int offset, int count, int chunkIndex)
		{
			InnerStream.Write(buffer, offset, count);
		}

		public ChunkWriter(Stream stream):base(stream)
		{
		}		
	}
}

