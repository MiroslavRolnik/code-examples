using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{
	internal class ComressedChunkWriter : ChunkWriter
	{
		protected override void WriteBody(byte[] buffer, int offset, int count, int chunkIndex)
		{
			InnerStream.Write(BitConverter.GetBytes(count), 0, 4);

			base.WriteBody(buffer, offset, count, chunkIndex);
		}

		public ComressedChunkWriter(Stream stream) : base(stream)
		{
		}
	}
}
