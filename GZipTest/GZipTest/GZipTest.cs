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
	internal static class GZipTest
	{
		public static void Compress(Stream inputStream, Stream outputStream, int chunkLength = 1024, int workThreadCount = 5)
		{
			CheckArguments(inputStream, outputStream, chunkLength, workThreadCount);
			
			using (var chunkReader = new ChunkQueue(new ChunkToCompressReader(inputStream, chunkLength) , workThreadCount))
			using (var chunkWriter = new ComressedChunkWriter(outputStream))
			{
				IWorkProvider workProvider = new GZipTestCompress(chunkReader, chunkWriter);

				DoWork(workProvider, workThreadCount);
			}
		}

		public static void Decompress(Stream inputStream, Stream outputStream, int chunkLength = 1024, int workThreadCount = 5)
		{
			CheckArguments(inputStream, outputStream, chunkLength, workThreadCount);
			
			using (var chunkReader = new ChunkToDecompressReader(inputStream))// new ChunkQueue(new ChunkToDecompressReader(inputStream),workThreadCount)
			using (var chunkWriter = new ChunkWriter(outputStream))
			{
				IWorkProvider workProvider = new GZipTestDecompress(chunkReader, chunkWriter);

				DoWork(workProvider, workThreadCount);
			}
		}

		private static void CheckArguments(Stream inputStream, Stream outputStream, int? chunkLength, int workThreadCount)
		{
			if (inputStream == null)
				throw new ArgumentNullException(nameof(inputStream));
			if (!inputStream.CanRead)
				throw new ArgumentException($"The stream {nameof(inputStream)} must be readable!");
			if (outputStream == null)
				throw new ArgumentNullException(nameof(outputStream));
			if (!outputStream.CanWrite)
				throw new ArgumentException($"The stream {nameof(outputStream)} must be writtable!");
			if (chunkLength < 1)
				throw new ArgumentOutOfRangeException($"Value of {nameof(chunkLength)} must be greater than or equal to 1.");
			if (workThreadCount < 1)
				throw new ArgumentOutOfRangeException($"Value of {nameof(workThreadCount)} must be greater than or equal to 1.");
		}

		private static void DoWork(IWorkProvider workProvider, int workThreadCount)
		{
			IWorkDoer workDoer = new WorkDoer(workThreadCount);

			workDoer.DoWork(workProvider);
		}

	}
}
