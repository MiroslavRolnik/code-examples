using System;
using System.Collections.Generic;
using System.Text;

namespace P4U.Peri.BoxBoardKerong.Implementation.Simulator
{
	public class BoxSimulator : BoxBoardKerongController
	{
		#region Private Variables

		BoxSimulatorForm _Form;

		#endregion

		#region Constructors

		public BoxSimulator()
		{
			_Form = new BoxSimulatorForm();
			_Form.Show();
		}

		#endregion

		#region Override from BoxController

		protected override string Type
		{
			get => "Simulator";
		}

		/// <summary>
		/// Simulace otevření skříňky
		/// </summary>
		protected override void OpenBoxInternal(byte boxAddress, string ipAddress, int port)
		{
			_Form.OpenBox(boxAddress, ipAddress, port);
		}

		/// <summary>
		/// Test, zda je skříňka otevřena.
		/// </summary>
		/// <param name="box"></param>
		/// <returns>příznak, zda je skříňka otevřena</returns>
		protected override bool IsBoxOpenInternal(byte boxAddress, string ipAddress, int port)
		{
			return _Form.IsBoxOpen(boxAddress, ipAddress, port);
		}

		#endregion	
	}
}
