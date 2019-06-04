using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong
{
	static class BoardCommon
	{
		public static readonly byte STX = 0x02;//start code
		public static readonly byte ETX = 0x03;//end code

		public static readonly byte STATUS_BoxOpen = 0x00;
		public static readonly byte STATUS_BoxClosed = 0x01;
		public static readonly byte STATUS_BoxNotEmpty = 0x01;
		public static readonly byte STATUS_BoxEmpty = 0x00;

		public static readonly byte CMD_BoxOpenReq = 0x31;//request door open
		public static readonly byte CMD_BoxStatusReq = 0x30;//request locker’s door open or close Status
		public static readonly byte CMD_BoxStatusRes = 0x35;//reponse status of door open or close (STATUS (DATA1,DATA2): 0x01 open, 0x00 closed; STATUS (DATA3, DATA4):0x01 not empty, 0x00 empty)

		public static byte ComputeSum(byte[] data)
		{
			return ComputeSum(data, 0, data.Length - 1);
		}

		public static byte ComputeSum(byte[] data, int startIndex, int endIndex)
		{
			if (startIndex < 0
				|| endIndex > data.Length - 1
				|| startIndex > endIndex)
			{
				throw new Exception("Chyba v indexech, nelze sečíst dané byty!");
			}

			int intSum = 0;
			for (int index = startIndex; index <= endIndex; index++)
			{
				intSum += data[index];
			}

			return (byte)(intSum & 0xFF);
		}
	}
}
