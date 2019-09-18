using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{
	internal abstract class ChunkStreamBase : IDisposable
	{
		public Stream InnerStream { get; private set; }

		protected int _ChunkIndex;

		public ChunkStreamBase(Stream stream)
		{
			InnerStream = stream ?? throw new ArgumentNullException(nameof(stream));
		}

		#region IDisposable Support
		private bool disposedValue = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					InnerStream?.Dispose();
					InnerStream = null;
				}

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
		#endregion
	}
}
