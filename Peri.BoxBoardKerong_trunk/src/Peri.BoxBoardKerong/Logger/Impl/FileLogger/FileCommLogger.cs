using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.Logger.Impl.FileLogger
{
	internal class FileCommLogger : CommunicationLogger
	{
		#region Private Variables

		private string _CommunicationLogPath;

		#endregion

		#region Constructors

		public FileCommLogger(string communicationLogPath)
		{
			_CommunicationLogPath = communicationLogPath;
			if (_CommunicationLogPath == "") _CommunicationLogPath = null;
		}

		#endregion

		#region Implementing CommunicationLogger

		public override void WriteToCommunicationLog(bool header, bool newLine, string type, string str, bool footer)
		{
			if (_CommunicationLogPath == null) return;

			try
			{
				DateTime now = DateTime.Now;
				string fileName = "BoxCommLog_" + now.ToString("yyyy-MM-dd_HH") + ".txt";
				string fileNameFull = Path.Combine(_CommunicationLogPath, fileName);

				lock (this)
				{
					using (StreamWriter sw = new StreamWriter(fileNameFull, true))
					{
						string time = now.ToString("HH:mm:ss.fff ");
						string s = (header ? (time + type + ": ") : "") + str + (footer ? " <<< " + time + ">>>" : "");
						if (newLine)
						{
							sw.WriteLine(s);
						}
						else
						{
							sw.Write(s);
						}
						sw.Close();
					}
				}
			}
			catch (Exception)
			{
			}
		}

		#endregion
	}
}
