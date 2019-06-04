using System;
using System.Collections.Generic;
using System.Text;

namespace P4U.Peri.BoxBoardKerong.Logger
{
	internal abstract class CommunicationLogger
	{
		#region Public Methods

		internal static CommunicationLogger GetInstance(CommunicationLoggerType type, Dictionary<string, object> pars)
		{
			switch (type)
			{
				case CommunicationLoggerType.FILE:
					string logsPath = ".";
					if (pars != null && pars.ContainsKey("LogsPath"))
					{
						logsPath = pars["LogsPath"].ToString();
					}
					return new Impl.FileLogger.FileCommLogger(logsPath);

				case CommunicationLoggerType.NONE:
					return new Impl.None.NoneCommLogger();

				default:
					throw new ApplicationException($"Unknown CommunicationLoggerType type=[{type}]!");
			}
		}

		public void WriteToCommunicationLog(string type, string str)
		{
			WriteToCommunicationLog(true, true, type, str, false);
		}

		public void WriteToCommunicationLog(string type, byte[] data)
		{
			string str = ((data != null) ? BitConverter.ToString(data) : "NULL");

			WriteToCommunicationLog(true, true, type, str, false);
		}

		public void WriteToCommunicationLog(bool header, bool newLine, string type, string str, byte[] data)
		{
			WriteToCommunicationLog(header, newLine, type, str, data, 0, data.Length, false);
		}

		public void WriteToCommunicationLog(string type, string str, byte[] data)
		{
			WriteToCommunicationLog(true, true, type, str, data, 0, data.Length, false);
		}

		public void WriteToCommunicationLog(bool header, bool newLine, string type, string str, byte[] data, int offset, int length, bool footer)
		{
			if (type == null) type = "";
			if (str == null) str = "";

			try
			{
				if (data != null)
				{
					if (offset + length > data.Length) length = data.Length - offset;

					StringBuilder builder = new StringBuilder(length * 3);

					for (int i = 0; i < length; i++)
					{
						builder.Append(' ');
						builder.Append(data[i + offset].ToString("X2"));
					}

					str += builder.ToString();
				}

				WriteToCommunicationLog(header, newLine, type, str, footer);
			}
			catch (Exception)
			{
			}
		}

		#endregion

		#region Abstract Methods

		public abstract void WriteToCommunicationLog(bool header, bool newLine, string type, string str, bool footer);

		#endregion
	}
}