//#define EXTRA_LOG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using P4U.Peri.BoxBoardKerong;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation.Implementation.BoxArrayBoard
{
	internal class Driver : IDriver
	{
		#region Private Variables

		private BoxArrayImplementation.Driver _Driver;

		#endregion

		#region IDriver Members

		public void Init(BoxArrayImplementation.Driver driver)
		{
			_Driver = driver;
		}

		public void Deinit()
		{
		}

		public void UnLock(BoxHw box)
		{
			byte address = (byte)(((box.Module.Address & 0xF) << 4) | (box.ModulePortNumber & 0xF));
			byte[] request = GetOpenBoxReq(address);

			Global.CommLogger.WriteToCommunicationLog("W", request);

			TcpIpCommunication.SendRequest(box.Module.Driver.Socket.IpAddress, box.Module.Driver.Socket.Port, request, false);
		}

		public StateResponse GetState(Module module)
		{
			StateResponse sr = new StateResponse();

			byte[] request = GetIsBoxOpenReq((byte)(module.Address << 4));

			Global.CommLogger.WriteToCommunicationLog("W", request);

			byte[] response = TcpIpCommunication.SendRequest(module.Driver.Socket.IpAddress, module.Driver.Socket.Port, request, true);

			Global.CommLogger.WriteToCommunicationLog("R", response);

			BoardResponse boardResponse = BoardResponse.Parse(response);

			int dataLock = boardResponse.STATUS.DATA_LOCK;

			for (byte boardBU = 0; boardBU < 16; boardBU++)
			{
				BoxHw box = module.Boxes.GetBoxForModulePortNumber(boardBU);
				
				if (box != null)
				{
					if (((dataLock >> boardBU) & 1) == BoardCommon.STATUS_BoxOpen)
						sr.UnlockedBoxes.Add(box.LogicalNumber, box);
				}
			}

			return sr;
		}

		private byte[] GetIsBoxOpenReq(byte address)
		{
			CMD cmd = CMD.Create(BoardCommon.CMD_BoxStatusReq);

			ADDR addr = ADDR.Parse(address);

			return BoardRequest.Create(addr, cmd);
		}

		private byte[] GetOpenBoxReq(byte address)
		{
			CMD cmd = CMD.Create(BoardCommon.CMD_BoxOpenReq);

			ADDR addr = ADDR.Parse(address);

			return BoardRequest.Create(addr, cmd);
		}

		#endregion
	}
}
