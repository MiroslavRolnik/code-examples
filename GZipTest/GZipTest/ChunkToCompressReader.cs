using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{
	internal class ChunkToCompressReader : ChunkReaderBase, IChunkReader
	{
		private readonly int _ChunkLength;

		public int ReadChunk(out byte[] buffer, out int chunkIndex)
		{
			lock (InnerStream)
			{
				buffer = new byte[_ChunkLength];

				return Read(buffer, 0, _ChunkLength, out chunkIndex);
			}
		}

		public ChunkToCompressReader(Stream stream, int chunkLength):base(stream)
		{
			if (chunkLength < 1)
				throw new ArgumentOutOfRangeException($"Value of {nameof(chunkLength)} must be greater than or equal to 1.");
			_ChunkLength = chunkLength;
		}
	}
}
