using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong
{
	/// <summary>
	/// zpracuje odpověď ve formě:
	/// STX        ADDR       CMD        STATUS      ETX        SUM
	/// (1 byte)   (1 byte)   (1 byte)   (4 bytes)   (1 byte)   (1 byte)
	/// </summary>
	class BoardResponse
	{
		public ADDR ADDR { get; private set; }
		public STATUS STATUS { get; private set; }
		public CMD CMD { get; private set; }

		private BoardResponse(ADDR addr, STATUS status, CMD cmd)
		{
			ADDR = addr;
			STATUS = status;
			CMD = cmd;
		}

		public static BoardResponse Parse(byte[] command)
		{
			BoardResponse parseResponse = null;

			if (command?.Length == 9)
			{
				CheckCorrectness(command);

				byte[] data = new byte[command.Length - 3];
				Array.Copy(command, 1, data, 0, data.Length);

				if (data.Length == 6)
				{
					byte addr_command = data[0];
					ADDR addr = ADDR.Parse(addr_command);

					byte cmd_command = data[1];
					CMD cmd = CMD.Parse(cmd_command);

					byte[] status_command = new byte[4];
					Array.Copy(data, 2, status_command, 0, 4);
					STATUS status = STATUS.Parse(status_command);

					parseResponse = new BoardResponse(addr, status, cmd);
				}
				else
				{
					throw new Exception($"BoardResponse: délka dat zprávy nesouhlasí [{data?.Length}] != 6!");
				}
			}
			else
			{
				throw new Exception($"BoardResponse: délka zprávy nesouhlasí [{command?.Length}] != 9!");
			}

			return parseResponse;
		}

		private static void CheckCorrectness(byte[] command)
		{
			byte stx = command[0];
			byte etx = command[command.Length - 2];
			byte sum = command[command.Length - 1];

			if (stx != BoardCommon.STX)
			{
				throw new Exception($"BoardResponse: obsahuje neplatný příznak [{stx:X2}] na pozici STX!");
			}

			if (etx != BoardCommon.ETX)
			{
				throw new Exception($"BoardResponse: obsahuje neplatný příznak [{etx:X2}] na pozici ETX!");
			}

			byte byteSum = BoardCommon.ComputeSum(command, 0, command.Length - 2);
			if (sum != byteSum)
			{
				throw new Exception($"BoardResponse: neshoduje se suma dat [{byteSum:X2}] s deklarovanou SUM=[{sum:X2}]!");
			}
		}

		public override string ToString()
		{
			return $"ADDR=[{ADDR}],CMD=[{CMD}],STATUS=[{STATUS}]";
		}
	}
}
