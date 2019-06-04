using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P4U.Peri.BoxBoardKerong;
using P4U.Peri.BoxBoardKerong.BoxArrayImplementation;
using P4U.Peri.BoxBoardKerong.Logger;

namespace Peri.BoxArrayBoardKerong.Test
{
	public partial class BoxArrayBoardTestForm : Form
	{
		#region Private Variables
		
		private BoxArrayBoardKerongController _Controller;

		private static Color COLOR_BOX_LOCKED = Color.Red;
		private static Color COLOR_BOX_UNLOCKED = Color.PaleGreen;

		#endregion

		#region Constructor

		public BoxArrayBoardTestForm()
		{
			InitializeComponent();

			foreach (ImplementationType type in Enum.GetValues(typeof(ImplementationType)))
			{
				cbImplementation.Items.Add(type.ToString());
			}
			cbImplementation.Text = ImplementationType.Kerong.ToString();
		}
		
		#endregion

		#region Private Method

		private void RefreshState(StateResponse state)
		{
			foreach (CheckBox chk in GetCheckBoxControls())
			{
				if (state != null)
				{
					byte boxOrderNumberOnModule = byte.Parse(chk.Tag.ToString());
					byte moduleAdress = (byte)txtModuleAddress.Value;
					byte boxModulePortNumber = (byte)(boxOrderNumberOnModule - 1);
					BoxHw box = _Controller.Boxes.GetBoxForModulePortNumber(moduleAdress, boxModulePortNumber);
					bool isUnlocked = state.UnlockedBoxes.ContainsValue(box);

					chk.BackColor = isUnlocked ? Color.PaleGreen : Color.Red;
				}
				else
				{
					chk.BackColor = SystemColors.Control;
				}
			}

			//cbBox0.Checked = (state != null && state.UnlockedBoxes.GetBoxForModulePortNumber(0) != null);

			lblInternalErrors.Text = "";
			if (state != null)
			{
				foreach (InternalHWModuleError i in state.InternalHWModuleErrors)
				{
					lblInternalErrors.Text += i.GetDesription() + "; ";
				}
			}
		}

		private List<CheckBox> GetCheckBoxControls()
		{
			List<CheckBox> list = new List<CheckBox>();

			foreach (Control con in panelBoxCheckboxes.Controls)
			{
				if (con is CheckBox)
				{
					list.Add((CheckBox)con);
				}
			}

			return list;
		}

		private CheckBox GetCheckBoxControlForBoxNumber(int number)
		{
			foreach (CheckBox chk in GetCheckBoxControls())
			{
				int controlBoxNumber = (int)chk.Tag;
				if (number == controlBoxNumber)
				{
					return chk;
				}
			}

			return null;
		}

		/// <summary>
		/// Vrátí testovací data z konfigu.
		/// </summary>
		private static DataTable ReturnTestDataTable()
		{
			DataTable dt = new DataTable();

			dt.Columns.Add("ID", typeof(int));
			dt.Columns.Add("LogicalNumber", typeof(int));
			dt.Columns.Add("ModulePortNumber", typeof(byte));
			dt.Columns.Add("ModuleAddress", typeof(byte));
			dt.Columns.Add("DriverIpAddress", typeof(string));
			dt.Columns.Add("DriverPort", typeof(int));

			int i = 1;

			foreach (string box in Properties.Settings.Default.BoxList)
			{
				string[] list = box.Split(',');

				DataRow row = dt.NewRow();
				row["ID"] = i++;
				row["LogicalNumber"] = int.Parse(list[0]);
				row["ModulePortNumber"] = byte.Parse(list[1]);
				row["ModuleAddress"] = byte.Parse(list[2]);
				row["DriverIpAddress"] = list[3];
				row["DriverPort"] = int.Parse(list[4]);

				dt.Rows.Add(row);
			}

			return dt;
		}

		private void SetCommLogger()
		{
			bool loggingOn = chkLogComm.Checked;

			if (loggingOn)
			{
				_Controller.SetCommLogger(CommunicationLoggerType.FILE, null);
			}
			else
			{
				_Controller.SetCommLogger(CommunicationLoggerType.NONE, null);
			}
		}

		#endregion

		#region Event Handlers

		private void btInit_Click(object sender, EventArgs e)
		{
			ImplementationType type = (ImplementationType)Enum.Parse(typeof(ImplementationType), cbImplementation.Text);

			if (_Controller != null)
			{
				MessageBox.Show("Kontroler je již vytvořen.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				_Controller = new BoxArrayBoardKerongController();
				_Controller.Init(type, ReturnTestDataTable());

				foreach (Socket socket in _Controller.Drivers.Keys)
				{
					cbModuleSocket.Items.Add(socket.ToString());
				}

				if (cbModuleSocket.Items.Count > 0) cbModuleSocket.SelectedIndex = 0;
				SetCommLogger();
			}
		}

		private void btDeinit_Click(object sender, EventArgs e)
		{
			if (_Controller != null)
			{
				try
				{
					_Controller.Deinit();
				}
				catch { }
				_Controller = null;
				cbModuleSocket.Items.Clear();
			}
		}

		private void btGetState_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			btGetState.Enabled = false;
			try
			{
				RefreshState(null);
				Socket socket = Socket.Parse(cbModuleSocket.Text);
				RefreshState(_Controller.Drivers[socket].Modules[(byte)txtModuleAddress.Value].GetState());
			}
			catch (Exception ex)
			{
				MessageBox.Show("Nepodařilo se zjistit stav: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
				btGetState.Enabled = true;
			}
		}

		private void btUnlock_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			btUnlock.Enabled = false;
			try
			{
				_Controller.Boxes[(int)txtBoxNumber.Value].UnLock();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Nepodařilo se odemknout zámek: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
				btUnlock.Enabled = true;
			}
		}

		private void chkLogComm_CheckedChanged(object sender, EventArgs e)
		{
			SetCommLogger();
		}

		private void BoxArrayBoardTestForm_Load(object sender, EventArgs e)
		{
		}

		#endregion
	}
}