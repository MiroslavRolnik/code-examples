using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GZipTest
{
	internal class ComressedChunkWriter : ChunkWriter
	{
		private HashAlgorithm hashAlgorithm = new MD5Cng();

		protected override void WriteBody(byte[] buffer, int offset, int count, int chunkIndex)
		{
			lock (InnerStream)
			{
				InnerStream.Write(BitConverter.GetBytes(count), 0, 4);

				byte[] hash = hashAlgorithm.ComputeHash(buffer, offset, count);

				InnerStream.Write(hash, 0, hash.Length);

				base.WriteBody(buffer, offset, count, chunkIndex);
			}
		}

		public ComressedChunkWriter(Stream stream) : base(stream)
		{
		}
	}
}
