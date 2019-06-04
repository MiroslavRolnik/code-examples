using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation
{
	/// <summary>
	/// Klíčem je číslo comportu.
	/// </summary>
	public class DriverCollection : Dictionary<Socket, Driver>
	{
		public Driver GetDriverForSocket(Socket socket)
		{
			Driver driver = null;
			if(ContainsKey(socket))
			{
				driver = this[socket];
			}

			return driver;
		}
	}
}
