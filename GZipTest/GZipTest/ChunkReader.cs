using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{
	internal abstract class ChunkReaderBase : ChunkStreamBase, IDisposable
	{
		public int ReadChunk(byte[] buffer, int offset, int count, out int chunkIndex)
		{
			lock (InnerStream)
			{
				chunkIndex = _ChunkIndex++;

				return Read(buffer, offset, count);
			}
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			lock (InnerStream)
			{
				int read = 0;

				int readLength;

				while (read < count && (readLength = InnerStream.Read(buffer, offset + read, count - read)) > 0)
				{
					read += readLength;
				}

				return read;
			}
		}

		public ChunkReaderBase(Stream stream):base(stream)
		{
		}
	}
}
