using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.Logger.Impl.None
{
	internal class NoneCommLogger : CommunicationLogger
	{
		#region Implementing CommunicationLogger

		public override void WriteToCommunicationLog(bool header, bool newLine, string type, string str, bool footer)
		{
		}

		#endregion
	}
}