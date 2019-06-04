using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P4U.Peri.BoxBoardKerong;

namespace P4U.Peri.BoxBoardKerong.Test
{
	public partial class BoxBoardTest : Form
	{
		public BoxBoardTest()
		{
			InitializeComponent();

			BoxBoard = new Implementation.Board.BoxBoard();
		}

		private Implementation.Board.BoxBoard BoxBoard { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btTestConnection_Click(object sender, EventArgs e)
		{			
			string msg = string.Empty;
			try
			{
				Ping pingSender = new Ping();
				IPAddress address = IPAddress.Parse(txtIpAddress.Text);
				PingReply reply = pingSender.Send(address);

				msg = $"Test connection status = [{reply.Status.ToString()}].";
			}
			catch(Exception ex)
			{
				msg = $"Ping error [{ex.Message}]";
			}

			MessageBox.Show(msg);
		}

		private async void btOpenBox_Click(object sender, EventArgs e)
		{
			try
			{
				string ipAddress = txtIpAddress.Text;
				int port = int.Parse(txtPort.Text);

				int boxNo = int.Parse(txtBoxNo.Text) & 0xF;
				int boardNo = int.Parse(txtBoardNo.Text) & 0xF;

				byte address = (byte)((boardNo << 4) | boxNo);

				lblBoxAddress.Text = address.ToString("x");
				txtResponse.Text = "Čekám na odpověď...";

				await Task.Run(() => BoxBoard.OpenBox(address, ipAddress, port));
				txtResponse.Text = "Odesláno.";
			}
			catch(Exception ex)
			{
				string msg = $"{ex.Message}[{ex.InnerException.Message}]";

				txtResponse.Text = msg;

				MessageBox.Show(msg);
			}
		}

		private async void btIsBoxOpen_Click(object sender, EventArgs e)
		{
			bool isBoxOpen = false;
			try
			{
				string ipAddress = txtIpAddress.Text;
				int port = int.Parse(txtPort.Text);

				int boxNo = int.Parse(txtBoxNo.Text) & 0xF;
				int boardNo = int.Parse(txtBoardNo.Text) & 0xF;

				byte address = (byte)((boardNo << 4) | boxNo);

				lblBoxAddress.Text = address.ToString("x");
				txtResponse.Text = "Čekám na odpověď...";

				await Task.Run(() =>  isBoxOpen = BoxBoard.IsBoxOpen(address, ipAddress, port));

				txtResponse.Text = $"IsBoxOpen = [{isBoxOpen.ToString()}]";
			}
			catch (Exception ex)
			{
				string msg = $"{ex.Message}[{ex.InnerException.Message}]";

				txtResponse.Text = msg;

				MessageBox.Show(msg);
			}
		}

		private void SetCommLogger()
		{
			bool loggingOn = chkLogComm.Checked;

			if (loggingOn)
			{
				BoxBoard.SetCommLogger(Logger.CommunicationLoggerType.FILE, null);
			}
			else
			{
				BoxBoard.SetCommLogger(Logger.CommunicationLoggerType.NONE, null);
			}
		}

		private void chkLogComm_CheckedChanged(object sender, EventArgs e)
		{
			SetCommLogger();
		}

		private void BoxBoardTest_Load(object sender, EventArgs e)
		{
			SetCommLogger();
		}
	}
}
