using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation.Implementation.Simulator
{
	internal partial class ModuleControl : UserControl
	{
		private string _CommunicationErrorValueName;

		private Module _Module;

		private Dictionary<BoxHw, BoxControl> _BoxControlCol;

		public DriverForm DriverForm { get; private set; }

		public bool ErrorCommunication { get { return cbErr.Checked; } }

		public ModuleControl()
		{
			InitializeComponent();
		}

		public void Init(DriverForm driverForm, Module module)
		{
			_BoxControlCol = new Dictionary<BoxHw, BoxControl>();

			DriverForm = driverForm;
			_Module = module;

			_CommunicationErrorValueName = "CommunicationError_" + _Module.Address.ToString();

			lblAddress.Text = module.Address.ToString();

			// Přidám kontrolky boxů do kontrolky modulu.
			foreach (BoxHw i in _Module.Boxes.Values)
			{
				BoxControl bc = new BoxControl();
				bc.Init(this, i);
				panelBoxes.Controls.Add(bc);
				_BoxControlCol.Add(i,bc);
			}
		}

		public void Deinit()
		{
			DriverForm = null;
			_Module = null;
			_BoxControlCol.Clear();
		}

		public BoxControl GetBoxControl(BoxHw box)
		{
			return _BoxControlCol[box];
		}		

		public void ThrowErrorCommunicationError()
		{
			if (ErrorCommunication)
				throw new Exception("response timeout");
		}

		public StateResponse GetState()
		{
			SimulateDelay();

			StateResponse r = new StateResponse();

			foreach(BoxControl i in _BoxControlCol.Values)
			{
				if (i.IsDoorUnlocked)
					r.UnlockedBoxes.Add(i.Box.LogicalNumber, i.Box);
			}

			/*for (byte i = 1; i < 10; i++)
			{
				r.InternalHWModuleErrorCollection.Add(new InternalHWModuleError(i));
			}*/

			return r;
		}

		private void RefreshGui()
		{
			cbErr.BackColor = cbErr.Checked ? Color.Red : SystemColors.Control;
		}

		public void SimulateDelay()
		{
			System.Threading.Thread.Sleep((int)numDuration.Value);
		}

		private void ModuleControl_Load(object sender, EventArgs e)
		{
			try
			{
				cbErr.CheckState = (CheckState)Enum.Parse(typeof(CheckState), (string)DriverForm.RegKey.GetValue(_CommunicationErrorValueName));
			}
			catch { }

			RefreshGui();
		}

		private void cbErr_CheckedChanged(object sender, EventArgs e)
		{
			RefreshGui();
			DriverForm.SetValue(_CommunicationErrorValueName, cbErr.CheckState.ToString());
		}
	}
}
