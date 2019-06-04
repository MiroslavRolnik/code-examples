using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation
{
	/// <summary>
	/// Skříňka.
	/// </summary>
	public class BoxHw
	{
		#region Constructors

		internal BoxHw(int id, Module module, int logicalNumber, byte modulePortNumber)
		{
			ID = id;
			Module = module;
			LogicalNumber = logicalNumber;
			ModulePortNumber = modulePortNumber;
			module.Boxes.Add(logicalNumber, this);
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// ID pod kterým je Box uchováván v DB.
		/// </summary>
		public int ID { get; private set; }

		/// <summary>
		/// Modul, do kterého náleží skříňka.
		/// </summary>
		public Module Module { get; private set; }

		/// <summary>
		/// Číslo skříňky.
		/// </summary>
		public int LogicalNumber { get; private set; }

		/// <summary>
		/// Číslo portu na který je box připojen na modulu.
		/// </summary>
		public byte ModulePortNumber { get; private set; }

		/// <summary>
		/// Pošle otevírací impuls do zámku dvířek.
		/// </summary>
		public void UnLock()
		{
			Module.Driver.DriverImpl.UnLock(this);
		}

		#endregion
	}
}
