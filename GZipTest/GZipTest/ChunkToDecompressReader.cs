using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{	
	internal class ChunkToDecompressReader : ChunkReaderBase, IChunkReader
	{
		public int ReadChunk(out byte[] buffer, out int chunkIndex)
		{
			lock (InnerStream)
			{
				buffer = new byte[4];

				int readLength = InnerStream.Read(buffer, 0, 4);

				if (readLength == 4)
				{
					int chunkLength = BitConverter.ToInt32(buffer, 0);

					if (buffer.Length < chunkLength)
						buffer = new byte[chunkLength];

					return Read(buffer, 0, chunkLength, out chunkIndex);
				}
				else if (readLength == 0)
				{
					chunkIndex = -1;
					return 0;
				}
				else
					throw new InvalidDataException("Unexpected end of file.");
			}
		}

		public ChunkToDecompressReader(Stream stream) : base(stream)
		{
		}
	}
}
