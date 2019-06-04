using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation
{
	/// <summary>
	/// Návratová hodnota obsahující stav boxů na modulu
	/// </summary>
	public class StateResponse
	{
		public bool HasInternalHWModuleErrors { get { return InternalHWModuleErrors.Count > 0; } }

		/// <summary>
		/// Kolekce boxů. které jsou odemčené.
		/// </summary>
		public BoxHwCollection UnlockedBoxes { get; private set; }

		/// <summary>
		/// Kolekce boxů. kde je IR senzor = true
		/// </summary>
		public BoxHwCollection IrBoxes { get; private set; }

		/// <summary>
		/// Kolekce interních chyb modulu.
		/// </summary>
		public InternalHWModuleErrorCollection InternalHWModuleErrors { get; private set; }

		internal StateResponse()
		{
			UnlockedBoxes = new BoxHwCollection();
			IrBoxes = new BoxHwCollection();
			InternalHWModuleErrors = new InternalHWModuleErrorCollection();
		}
	}
}
