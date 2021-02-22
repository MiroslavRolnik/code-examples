using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{
	internal class GZipTestCompress : IWorkProvider
	{
		private IChunkReader _ChunkReader;

		private IChunkWriter _ChunkWriter;

		private volatile bool _StopWork;

		public GZipTestCompress(IChunkReader chunkReader, IChunkWriter chunkWriter)
		{
			_ChunkReader = chunkReader ?? throw new ArgumentNullException(nameof(chunkReader));

			_ChunkWriter = chunkWriter ?? throw new ArgumentNullException(nameof(chunkWriter));
		}

		private void CompressWork()
		{
			int chunkIndex = 0;
			byte[] buffer;

			int readLength = 0;
			while (!_StopWork && (readLength = _ChunkReader.ReadChunk(out buffer, out chunkIndex)) > 0)
			{
				byte[] compressed = null;
				using (MemoryStream ms = new MemoryStream())
				{
					using (GZipStream gzip = new GZipStream(ms, CompressionMode.Compress))
					{
						gzip.Write(buffer, 0, readLength);
					}

					compressed = ms.ToArray();
				}

				_ChunkWriter.WriteChunk(compressed, 0, compressed.Length, chunkIndex);
			}
		}

		public Action GetWork() => CompressWork;

		public void StopWork()
		{
			_StopWork = true;
		}
	}
}
