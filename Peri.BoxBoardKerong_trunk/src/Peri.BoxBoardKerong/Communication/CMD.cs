using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong
{
	/// <summary>
	/// zpracuje pole ve formě:
	/// CMD
	/// (1 byte)
	/// </summary>
	class CMD
	{
		public byte Cmd { get; private set; }

		private CMD(byte cmd)
		{
			Cmd = cmd;
		}

		public static CMD Create(byte cmd)
		{
			CheckCorrectness(cmd);

			return new CMD(cmd);
		}

		public static CMD Parse(byte command)
		{
			CMD parsedCMD = null;

			CheckCorrectness(command);

			parsedCMD = new CMD(command);

			return parsedCMD;
		}

		public byte[] GetMsg()
		{
			byte[] msg = new byte[] { Cmd };

			return msg;
		}

		private static void CheckCorrectness(byte cmd)
		{
			if (cmd != BoardCommon.CMD_BoxStatusRes
				&& cmd != BoardCommon.CMD_BoxOpenReq
				&& cmd != BoardCommon.CMD_BoxStatusReq)
			{
				throw new Exception($"CMD: obsahuje neplatný příznak [{cmd:X2}]!");
			}
		}

		public override string ToString()
		{
			return $"Cmd=[{Cmd:X2}]";
		}
	}
}
