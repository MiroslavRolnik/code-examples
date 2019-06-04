using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong
{
	/// <summary>
	/// zpracuje pole ve formě:
	/// BoardCU         No. of Box
	/// (high 4 bits)   (low 4 bits)
	/// </summary>
	class ADDR
	{
		public byte BoardCU { get; private set; }
		public byte BoardBU { get; private set; }

		private ADDR(byte boardCU, byte boardBU)
		{
			BoardCU = boardCU;
			BoardBU = boardBU;
		}

		public static ADDR Create(byte boardCU, byte boardBU)
		{
			CheckCorrectness(boardCU, boardBU);

			return new ADDR(boardCU, boardBU);
		}

		public byte[] GetMsg()
		{
			byte[] msg = new byte[] { (byte)((BoardCU << 4) | BoardBU) };

			return msg;
		}

		public static ADDR Parse(byte addr)
		{
			ADDR parsed = null;

			byte boardCU = (byte)(addr >> 4);
			byte boardBU = (byte)(addr & 0xF);

			parsed = new ADDR(boardCU, boardBU);

			return parsed;
		}

		private static void CheckCorrectness(byte boardCU, byte boardBU)
		{
			if (((boardCU >> 4) != 0) || ((boardBU >> 4) != 0))
			{
				throw new Exception($"ADDR: neplatný formát BoardCU=[{boardCU}], BoardBU=[{boardBU}]");
			}
		}

		public override string ToString()
		{
			return $"BoardCU=[{BoardCU}],BoardBU=[{BoardBU}]";
		}
	}
}
