using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong
{
	/// <summary>
	/// zpracuje pole ve formě:
	/// DATA1      DATA2      DATA3      DATA4
	/// (1 byte)   (1 byte)   (1 byte)   (1 byte)
	/// do:
	///		DATA_LOCK             DATA_IR
	///		(2 byte)              (2 byte)
	/// </summary>
	class STATUS
	{
		public int DATA_LOCK { get; private set; }
		public int DATA_IR { get; private set; }

		private STATUS(int dataLock, int dataIR)
		{
			DATA_LOCK = dataLock;
			DATA_IR = dataIR;
		}

		public static STATUS Parse(byte[] command)
		{
			STATUS status = null;

			if (command.Length == 4)
			{
				int dataLock = ((command[1] << 8) | command[0]);
				int dataIR = ((command[3] << 8) | command[2]);

				status = new STATUS(dataLock, dataIR);
			}
			else
			{
				throw new Exception($"STATUS: zpráva nemá patřičnou délku 4, obsahuje [{command?.Length}] znaků!");
			}

			return status;
		}

		public override string ToString()
		{
			return $"DATA_LOCK=[{DATA_LOCK:X2}],DATA_IR=[{DATA_IR:X2}]";
		}
	}
}
