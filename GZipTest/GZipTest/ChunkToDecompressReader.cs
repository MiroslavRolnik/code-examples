using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{	
	internal class ChunkToDecompressReader : ChunkReaderBase, IChunkReader
	{
		private HashAlgorithm hashAlgorithm = new MD5Cng();

		public int ReadChunk(out byte[] buffer, out int chunkIndex)
		{
			buffer = new byte[0];

			lock (InnerStream)
			{
				int hashLength = hashAlgorithm.HashSize / 8;
				int headerLength = 4 + hashLength;

				byte[] headerBuffer = new byte[headerLength];
				
				int readLength = InnerStream.Read(headerBuffer, 0, headerLength);

				if (readLength == headerLength)
				{
					int chunkLength = BitConverter.ToInt32(headerBuffer, 0);

					buffer = new byte[chunkLength];

					int read = Read(buffer, 0, chunkLength, out chunkIndex);

					byte[] hash = hashAlgorithm.ComputeHash(buffer);

					if (read != chunkLength || !hash.IsEqual(headerBuffer, 4))
						throw new Exception($"Hash code error in chunk {chunkIndex}!");

					return read;
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
