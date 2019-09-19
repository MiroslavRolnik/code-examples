using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{
	internal class GZipTestDecompress : IWorkProvider
	{
		private IChunkReader _ChunkReader;

		private IChunkWriter _ChunkWriter;

		private volatile bool _StopWork;

		public GZipTestDecompress(IChunkReader chunkReader,IChunkWriter chunkWriter)
		{
			_ChunkReader = chunkReader ?? throw new ArgumentNullException(nameof(chunkReader));

			_ChunkWriter = chunkWriter ?? throw new ArgumentNullException(nameof(chunkWriter));
		}

		private void DecompressWork()
		{
			byte[] buffer;
			int chunkIndex = 0;

			int readLength = 0;
			while (!_StopWork && (readLength = _ChunkReader.ReadChunk(out buffer, out chunkIndex)) > 0)
			{
				byte[] decompressed = null;
				using (MemoryStream ws = new MemoryStream())
				{
					using (MemoryStream ms = new MemoryStream(buffer))
					using (GZipStream gzip = new GZipStream(ms, CompressionMode.Decompress))
						gzip.CopyTo(ws);

					decompressed = ws.ToArray();
				}

				_ChunkWriter.Write(decompressed, 0, decompressed.Length, chunkIndex);
			}
		}

		public Action GetWork() => DecompressWork;

		public void StopWork()
		{
			_StopWork = true;
		}
	}
}
