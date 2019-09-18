using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{
	internal interface IChunkWriter
	{
		void Write(byte[] buffer, int offset, int count, int chunkIndex);
	}
}
