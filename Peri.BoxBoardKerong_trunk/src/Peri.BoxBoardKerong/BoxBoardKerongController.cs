using P4U.Peri.BoxBoardKerong.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4U.Peri.BoxBoardKerong
{
	public abstract class BoxBoardKerongController
	{
		#region Public Methods

		public static BoxBoardKerongController Create(string type)
		{
			string typeUpper = type.ToUpper();

			if (typeUpper == "NONE")
			{
				return new Implementation.None.BoxNone();
			}
			else if (typeUpper == "SIMULATOR")
			{
				return new Implementation.Simulator.BoxSimulator();
			}
			else if (typeUpper == "BOXCONTROLLER")
			{
				return new Implementation.Board.BoxBoard();
			}
			else
			{
				throw new Exception($"Unknown BoxController Type = [{typeUpper}]");
			}
		}

		public void OpenBox(byte boxAddress, string ipAddress, int port)
		{
			string methodName = "OpenBox";
			try
			{
				OpenBoxInternal(boxAddress, ipAddress, port);
			}
			catch (Exception ex)
			{
				throw new Exception($"Chyba v metodě [{methodName}] na boxu [{boxAddress}/{ipAddress}:{port}].",ex);
			}
		}

		public bool IsBoxOpen(byte boxAddress, string ipAddress, int port)
		{
			string methodName = "IsBoxOpen";
			bool result;
			try
			{
				result = IsBoxOpenInternal(boxAddress, ipAddress, port);
			}
			catch (Exception ex)
			{
				throw new Exception($"Chyba v metodě [{methodName}] na boxu  [{boxAddress:X2}/{ipAddress}:{port}].", ex);
			}

			return result;
		}

		public void SetCommLogger(CommunicationLoggerType type, Dictionary<string, object> pars)
		{
			Global.SetCommLogger(type, pars);
		}


		#endregion

		#region Abstract Methods

		protected abstract void OpenBoxInternal(byte boxAddress, string ipAddress, int port);
		protected abstract bool IsBoxOpenInternal(byte boxAddress, string ipAddress, int port);
		protected abstract string Type { get; }

		#endregion
	}
}
