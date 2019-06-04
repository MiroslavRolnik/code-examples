using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation
{
	/// <summary>
	/// Klíčem je logické číslo boxu.
	/// </summary>
	public class BoxHwCollection : Dictionary<int, BoxHw>
	{
		public BoxHw GetBoxForLogicalNumber(int logicalNumber)
		{
			try
			{
				return this[logicalNumber];
			}
			catch { }

			return null;
		}

		/// <summary>
		/// Vrátí první výskyt Boxu podle čísla portu na modulu.
		/// </summary>
		public BoxHw GetBoxForModulePortNumber(byte modulePortNumber)
		{
			foreach(BoxHw i in Values)
			{
				if (i.ModulePortNumber == modulePortNumber) return i;
			}

			return null;
		}

		public BoxHw GetBoxForModulePortNumber(byte moduleAddress, byte modulePortNumber)
		{
			foreach (BoxHw i in Values)
			{
				if (i.Module.Address == moduleAddress && i.ModulePortNumber == modulePortNumber) return i;
			}

			return null;
		}
	}
}
