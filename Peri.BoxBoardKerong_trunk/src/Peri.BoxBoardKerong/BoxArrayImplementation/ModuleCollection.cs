using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation
{
	/// <summary>
	/// Klíčem je adresa modulu.
	/// </summary>
	public class ModuleCollection : Dictionary<byte, Module>
	{
		public Module GetModuleForAddress(byte address)
		{
			Module module = null;

			if (ContainsKey(address))
			{ 
				module = this[address];
			}

			return module;
		}
	}
}
