using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation
{
	/// <summary>
	/// Reprezentuje připojení pro skupinu modulů.
	/// </summary>
	public class Driver
	{
		internal Driver(ImplementationType type, Socket socket)
		{
			Type = type;
			Socket = socket;
			Modules = new ModuleCollection();
		}

		/// <summary>
		/// Odkaz na rozhraní implementace.
		/// </summary>
		/// 
		internal IDriver DriverImpl { get; private set; }

		internal ImplementationType Type { get; private set; }

		public Socket Socket { get; private set; }

		public ModuleCollection Modules { get; private set; }

		internal void Init()
		{
			switch (Type)
			{
				case ImplementationType.None:
					DriverImpl = new Implementation.None.Driver();
					break;

				case ImplementationType.Emulator:
					DriverImpl = new Implementation.Simulator.DriverForm();
					break;

				case ImplementationType.Kerong:
					DriverImpl = new Implementation.BoxArrayBoard.Driver();
					break;
			}

			DriverImpl.Init(this);
		}

		internal void Deinit()
		{
			DriverImpl.Deinit();
			DriverImpl = null;
			Modules.Clear();
		}
	}
}
