using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace P4U.Peri.BoxBoardKerong.Implementation.Simulator
{
	public partial class BoxSimulatorForm : Form
	{
		private DataTable _DataTable;

		public BoxSimulatorForm()
		{
			InitializeComponent();
			this.chkOnTop.Checked = this.TopMost;

			InitDataTable();
		}

		private void InitDataTable()
		{
			if (_DataTable == null)
			{
				CreateDataTable();
			}
		}

		private void CreateDataTable()
		{
			_DataTable = new DataTable();

			_DataTable.Columns.Add("Time", typeof(DateTime));			
			_DataTable.Columns.Add("Address", typeof(string));
			_DataTable.Columns.Add("IpAddress", typeof(string));
			_DataTable.Columns.Add("Port", typeof(string));
			_DataTable.Columns.Add("Request", typeof(string));
			_DataTable.Columns.Add("Response", typeof(string));
		}

		private void chkOnTop_CheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = this.chkOnTop.Checked;
		}

		public void OpenBox(byte address, string ipAddress, int port)
		{
			SimulateRequestDuration();

			CheckExceptionThrow();

			AddToDataTable(address, ipAddress, port, "OpenBox", string.Empty);

			RefreshGrid();
		}

		public bool IsBoxOpen(byte address, string ipAddress, int port)
		{
			SimulateRequestDuration();

			CheckExceptionThrow();

			bool isBoxOpen =  cbIsOpen.Checked;

			AddToDataTable(address, ipAddress,port, "IsBoxOpen", isBoxOpen.ToString());

			RefreshGrid();

			return isBoxOpen;
		}

		private void AddToDataTable(byte address, string ipAddress, int port, string request, string response)
		{
			DataRow row = _DataTable.NewRow();

			row["Time"] = DateTime.Now;
			row["Address"] = address.ToString("X2");
			row["IpAddress"] = ipAddress;
			row["Port"] = port.ToString();
			row["Request"] = request;
			row["Response"] = response;

			_DataTable.Rows.Add(row);
		}

		private void RefreshGrid()
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new MethodInvoker(RefreshGrid));
				return;
			}

			dataGridView1.DataSource = _DataTable;
			dataGridView1.Refresh();
		}

		private void CheckExceptionThrow()
		{
			if (chkThrowError.Checked)
			{
				throw new Exception(txBoxMessage.Text);
			}
		}

		private void SimulateRequestDuration()
		{
			Thread.Sleep((int)numReqDuration.Value);
		}
	}
}
