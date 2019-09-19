using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{
	internal interface IChunkReader : IDisposable
	{
		int ReadChunk(out byte[] buffer, out int chunkIndex);
	}
}
