using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation
{
	/// <summary>
	/// Modul - skupina skříněk, která je řízena jedním modulem.
	/// </summary>
	public class Module
	{
		internal Module(Driver driver, byte address)
		{
			Driver = driver;
			Address = address;
			Boxes = new BoxHwCollection();
			driver.Modules.Add(address, this);
		}

		/// <summary>
		/// Driver, přes který je modul řízen.
		/// </summary>
		internal Driver Driver { get; private set; }

		public BoxHwCollection Boxes { get; private set; }

		/// <summary>
		/// Adresa modulu.
		/// </summary>
		public byte Address { get; private set; }

		/// <summary>
		/// Vrátí stav modulu: - stav dvířek
		///                    - světla, která svítí
		///                    - světla, která blikají
		/// </summary>
		public StateResponse GetState()
		{
			return Driver.DriverImpl.GetState(this);
		}
	}
}
