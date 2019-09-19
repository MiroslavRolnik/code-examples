using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{
	internal static class ByteArrayExtension
	{
		public static bool IsEqual(this byte[] array, byte[] other, int otherStartIndex)
		{
			if (other == null || other.Length < (array.Length + otherStartIndex))
				return false;

			int index = array.Length - 1;
			while (index >= 0 && array[index] == other[otherStartIndex + index--]) ;

			return index < 0;
		}

	}
}
