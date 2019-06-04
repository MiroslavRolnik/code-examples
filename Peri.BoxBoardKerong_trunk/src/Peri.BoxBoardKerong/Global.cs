using P4U.Peri.BoxBoardKerong.Logger;
using System.Collections.Generic;

namespace P4U.Peri.BoxBoardKerong
{
	internal class Global
	{
		public static CommunicationLogger CommLogger { get; private set; } = CommunicationLogger.GetInstance(CommunicationLoggerType.NONE, null);

		public static void SetCommLogger(CommunicationLoggerType type, Dictionary<string, object> pars)
		{
			CommLogger = CommunicationLogger.GetInstance(type, pars);
		}
	}
}
