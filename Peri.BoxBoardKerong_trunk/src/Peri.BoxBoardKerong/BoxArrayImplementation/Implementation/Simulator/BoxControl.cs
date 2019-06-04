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
	internal partial class BoxControl : UserControl
	{
		private string _IsDoorUnlockedValueName;
		private string _IsDisabledUnlockOfDoorValueName;

		private ModuleControl _ModuleControl;

		public BoxHw Box;
		public bool IsDoorUnlocked { get; private set; }

		public BoxControl()
		{
			InitializeComponent();
		}

		public void Init(ModuleControl moduleControl, BoxHw box)
		{
			_ModuleControl = moduleControl;
			Box = box;

			_IsDoorUnlockedValueName = "IsDoorUnlocked_" + Box.LogicalNumber.ToString();
			_IsDisabledUnlockOfDoorValueName = "IsDisabledUnlockOfDoor_" + Box.LogicalNumber.ToString();

			lblNumber.Text = box.LogicalNumber.ToString();
			lblNumberModulePort.Text = box.ModulePortNumber.ToString();
		}

		public void RefreshBlinker()
		{
			_ModuleControl = null;
			Box = null;
		}

		private void RefreshGui()
		{
			cbEnableDoorUnlock.BackColor = cbEnableDoorUnlock.Checked ? SystemColors.Control : Color.Red;
		}

		private void cbEnableDoorUnlock_CheckedChanged(object sender, EventArgs e)
		{
			_ModuleControl.DriverForm.SetValue(_IsDisabledUnlockOfDoorValueName, cbEnableDoorUnlock.CheckState.ToString());
			RefreshGui();
		}

		private void SetDoorUnlocked(bool unlock)
		{
			IsDoorUnlocked = unlock;
			_ModuleControl.DriverForm.SetValue(_IsDoorUnlockedValueName, unlock.ToString());
			btClose.Visible = unlock;
			cbEnableDoorUnlock.Visible = !unlock;
		}

		private void btClose_Click(object sender, EventArgs e)
		{
			SetDoorUnlocked(false);
		}

		private void BoxControl_Load(object sender, EventArgs e)
		{
			try
			{
				IsDoorUnlocked = ((string)_ModuleControl.DriverForm.RegKey.GetValue(_IsDoorUnlockedValueName)).ToUpper() == "TRUE";
			}
			catch { }

			try
			{
				cbEnableDoorUnlock.CheckState = (CheckState)Enum.Parse(typeof(CheckState), (string)_ModuleControl.DriverForm.RegKey.GetValue(_IsDisabledUnlockOfDoorValueName));
			}
			catch { }

			
			SetDoorUnlocked(IsDoorUnlocked);
			RefreshGui();
		}



		/// <summary>
		/// Otevře dveře.
		/// Vrací true, pokud jsou dveře otevřeny.
		/// </summary>
		public bool Unlock()
		{
			if (!cbEnableDoorUnlock.Checked) return false;
			SetDoorUnlocked(true);
			return true;
		}
	}
}
