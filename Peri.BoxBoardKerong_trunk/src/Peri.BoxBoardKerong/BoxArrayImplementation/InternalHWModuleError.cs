using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation
{
	/// <summary>
	/// Interní chyba modulu.
	/// </summary>
	public class InternalHWModuleError
	{
		public byte ErrorNumber { get; private set; }

		internal InternalHWModuleError(byte error)
		{
			ErrorNumber = error;
		}

		public string GetDesription()
		{
			switch (ErrorNumber)
			{
				case 0x01:
					return "přetížení napájení při otevírání zámku nebo zkrat";
				default:
					return string.Format("chyba modulu {0} bez popisu", ErrorNumber);
			}
		}
	}
}
