using System;

namespace P4U.Peri.BoxBoardKerong.Implementation.Board
{
	public class BoxBoard: BoxBoardKerongController
	{
		protected override string Type
		{
			get => "BOXCONTROLLER";
		}

		protected override void OpenBoxInternal(byte boxAddress, string ipAddress, int port)
		{
			byte[] request = GetOpenBoxReq(boxAddress);

			Global.CommLogger.WriteToCommunicationLog("W", request);

			TcpIpCommunication.SendRequest(ipAddress, port, request, false);
		}

		protected override bool IsBoxOpenInternal(byte boxAddress, string ipAddress, int port)
		{
			byte[] request = GetIsBoxOpenReq(boxAddress);

			Global.CommLogger.WriteToCommunicationLog("W", request);

			byte[] response = TcpIpCommunication.SendRequest(ipAddress, port, request, true);

			Global.CommLogger.WriteToCommunicationLog("R", response);

			return IsBoxOpen(response, boxAddress);
		}

		private byte[] GetOpenBoxReq(byte address)
		{
			CMD cmd = CMD.Create(BoardCommon.CMD_BoxOpenReq);

			ADDR addr = ADDR.Parse(address);

			return BoardRequest.Create(addr, cmd);
		}

		private byte[] GetIsBoxOpenReq(byte address)
		{
			CMD cmd = CMD.Create(BoardCommon.CMD_BoxStatusReq);

			ADDR addr = ADDR.Parse(address);

			return BoardRequest.Create(addr, cmd);
		}

		private bool IsBoxOpen(byte[] response, byte boxAddress)
		{
			BoardResponse boardResponse = BoardResponse.Parse(response);

			if (boardResponse.CMD.Cmd != BoardCommon.CMD_BoxStatusRes)
			{
				throw new Exception($"IsBoxOpen: neočekávaný typ CMD=[{boardResponse.CMD:X2}] místo [{BoardCommon.CMD_BoxStatusRes:X2}]");
			}

			int boardCU = (boxAddress >> 4);
			if (boardResponse.ADDR.BoardCU != boardCU)
			{
				throw new Exception($"IsBoxOpen: neočekávaný typ BoardCU=[{boardResponse.ADDR.BoardCU:X2}] místo [{boardCU:X2}]");
			}

			int boardBU = (boxAddress & 0xF);
			bool isOpen = (((boardResponse.STATUS.DATA_LOCK >> boardBU) & 1) == BoardCommon.STATUS_BoxOpen);

			return isOpen;
		}
	}
}


