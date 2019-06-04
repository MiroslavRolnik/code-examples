using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation.Implementation.Simulator
{
	internal partial class DriverForm : Form, IDriver
	{
		#region Private Variables

		private bool _ClosingEnabled = false;

		private Driver _Driver;

		private Dictionary<Module, ModuleControl> _ModuleControlCol;

		private bool _IsInit = true;

		#endregion

		#region Constructors

		public DriverForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Internal Properties

		internal Microsoft.Win32.RegistryKey RegKey { get; set; }

		#endregion

		#region Private Methods

		internal void ShowSimulatorForm()
		{
			ShowDialog();
		}

		private ModuleControl GetModuleControl(Module module)
		{
			return _ModuleControlCol[module];
		}

		private BoxControl GetBoxControl(BoxHw box)
		{
			return GetModuleControl(box.Module).GetBoxControl(box);
		}

		#endregion

		#region Public Methods

		public void SetValue(string name, object value)
		{
			if (!_IsInit)
			{
				try
				{
					RegKey.SetValue(name, value);
					RegKey.Flush();
				}
				catch { }
			}
		}

		#endregion

		#region IDriver Interface

		public void UnLock(BoxHw box)
		{
			ModuleControl con = GetModuleControl(box.Module);
			con.ThrowErrorCommunicationError();

			bool rc = false;

			if (InvokeRequired)
			{
				con.SimulateDelay();
				Invoke(new System.Windows.Forms.MethodInvoker(delegate()
				{
					rc = GetBoxControl(box).Unlock();
				}));
			}

			if(!rc) throw new Exception("Box open error!");
		}

		public StateResponse GetState(Module module)
		{
			System.Threading.Thread.Sleep(200);

			GetModuleControl(module).ThrowErrorCommunicationError();

			return GetModuleControl(module).GetState();
		}

		public void Init(BoxArrayImplementation.Driver driver)
		{
			_Driver = driver;

			Thread thread = new Thread(ShowSimulatorForm);
			thread.Name = "BoxControllerEmulatorForm";
			thread.Start();
		}

		public void Deinit()
		{
			if (InvokeRequired)
			{
				Invoke(new System.Windows.Forms.MethodInvoker(delegate() { Deinit(); }));
				return;
			}

			_ClosingEnabled = true;
			_ModuleControlCol.Clear();
			Close();
		}

		#endregion

		#region GUI Events

		private void DriverForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = !_ClosingEnabled;
		}

		private void DriverForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				RegKey.Close();
			}
			catch { }
		}

		private void DriverForm_Load(object sender, EventArgs e)
		{
			_ModuleControlCol = new Dictionary<Module, ModuleControl>();

			try
			{
				string file = System.Windows.Forms.Application.ExecutablePath.Replace('\\', '/');
				RegKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Payment4U\Simulators\" + file + @"\BoxArrayBoardKerong\" + _Driver.Socket.ToString());
			}
			catch { }

			// Přidám kontrolky modulů do formuláře.
			foreach (Module i in _Driver.Modules.Values)
			{
				ModuleControl mc = new ModuleControl();
				mc.Init(this, i);
				this.modulePanel.Controls.Add(mc);
				_ModuleControlCol.Add(i, mc);
			}

			// A teď nakonec načtu poslední konfiguraci simulátoru.
			try
			{
				Point point = new Point((int)RegKey.GetValue("X"), (int)RegKey.GetValue("Y"));

				foreach (Screen i in Screen.AllScreens)
				{
					if (i.Bounds.IntersectsWith(new Rectangle(point, this.Size)))
					{
						this.Location = point;
						break;
					}
				}
			}
			catch { }

			this.Text = string.Format("[{0}]: BoxController Emulator", _Driver.Socket);

			_IsInit = false;
		}

		private void DriverForm_Move(object sender, EventArgs e)
		{
			SetValue("X", this.Location.X);
			SetValue("Y", this.Location.Y);
		}

		#endregion
	}
}
