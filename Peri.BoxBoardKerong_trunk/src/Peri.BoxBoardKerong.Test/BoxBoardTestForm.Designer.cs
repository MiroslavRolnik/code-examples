namespace P4U.Peri.BoxBoardKerong.Test
{
	partial class BoxBoardTest
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtBoxNo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtResponse = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btOpenBox = new System.Windows.Forms.Button();
			this.btTestConnection = new System.Windows.Forms.Button();
			this.btIsBoxOpen = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblBoxAddress = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tc = new System.Windows.Forms.Label();
			this.txtBoardNo = new System.Windows.Forms.TextBox();
			this.txtIpAddress = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.chkLogComm = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "BoxNo";
			// 
			// txtBoxNo
			// 
			this.txtBoxNo.Location = new System.Drawing.Point(87, 17);
			this.txtBoxNo.Name = "txtBoxNo";
			this.txtBoxNo.Size = new System.Drawing.Size(74, 20);
			this.txtBoxNo.TabIndex = 1;
			this.txtBoxNo.Text = "8";
			this.txtBoxNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 109);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "IpAddress";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 135);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(26, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Port";
			// 
			// txtResponse
			// 
			this.txtResponse.Location = new System.Drawing.Point(9, 211);
			this.txtResponse.Multiline = true;
			this.txtResponse.Name = "txtResponse";
			this.txtResponse.Size = new System.Drawing.Size(424, 82);
			this.txtResponse.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 192);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Response:";
			// 
			// btOpenBox
			// 
			this.btOpenBox.Location = new System.Drawing.Point(210, 7);
			this.btOpenBox.Name = "btOpenBox";
			this.btOpenBox.Size = new System.Drawing.Size(223, 49);
			this.btOpenBox.TabIndex = 10;
			this.btOpenBox.Text = "OpenBox";
			this.btOpenBox.UseVisualStyleBackColor = true;
			this.btOpenBox.Click += new System.EventHandler(this.btOpenBox_Click);
			// 
			// btTestConnection
			// 
			this.btTestConnection.Location = new System.Drawing.Point(12, 158);
			this.btTestConnection.Name = "btTestConnection";
			this.btTestConnection.Size = new System.Drawing.Size(168, 23);
			this.btTestConnection.TabIndex = 11;
			this.btTestConnection.Text = "Test Connection";
			this.btTestConnection.UseVisualStyleBackColor = true;
			this.btTestConnection.Click += new System.EventHandler(this.btTestConnection_Click);
			// 
			// btIsBoxOpen
			// 
			this.btIsBoxOpen.Location = new System.Drawing.Point(210, 62);
			this.btIsBoxOpen.Name = "btIsBoxOpen";
			this.btIsBoxOpen.Size = new System.Drawing.Size(223, 49);
			this.btIsBoxOpen.TabIndex = 12;
			this.btIsBoxOpen.Text = "IsBoxOpen";
			this.btIsBoxOpen.UseVisualStyleBackColor = true;
			this.btIsBoxOpen.Click += new System.EventHandler(this.btIsBoxOpen_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblBoxAddress);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tc);
			this.groupBox1.Controls.Add(this.txtBoardNo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtBoxNo);
			this.groupBox1.Location = new System.Drawing.Point(9, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(179, 91);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "BoxAddress";
			// 
			// lblBoxAddress
			// 
			this.lblBoxAddress.Location = new System.Drawing.Point(89, 69);
			this.lblBoxAddress.Name = "lblBoxAddress";
			this.lblBoxAddress.Size = new System.Drawing.Size(72, 13);
			this.lblBoxAddress.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 70);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "BoxAddress";
			// 
			// tc
			// 
			this.tc.AutoSize = true;
			this.tc.Location = new System.Drawing.Point(6, 42);
			this.tc.Name = "tc";
			this.tc.Size = new System.Drawing.Size(49, 13);
			this.tc.TabIndex = 2;
			this.tc.Text = "BoardNo";
			// 
			// txtBoardNo
			// 
			this.txtBoardNo.Location = new System.Drawing.Point(87, 39);
			this.txtBoardNo.Name = "txtBoardNo";
			this.txtBoardNo.Size = new System.Drawing.Size(74, 20);
			this.txtBoardNo.TabIndex = 3;
			this.txtBoardNo.Text = "0";
			this.txtBoardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtIpAddress
			// 
			this.txtIpAddress.Location = new System.Drawing.Point(80, 106);
			this.txtIpAddress.Name = "txtIpAddress";
			this.txtIpAddress.Size = new System.Drawing.Size(100, 20);
			this.txtIpAddress.TabIndex = 3;
			this.txtIpAddress.Text = global::Test.Properties.Settings.Default.IpAddress;
			this.txtIpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(80, 132);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(100, 20);
			this.txtPort.TabIndex = 5;
			this.txtPort.Text = global::Test.Properties.Settings.Default.Port;
			this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chkLogComm
			// 
			this.chkLogComm.AutoSize = true;
			this.chkLogComm.Location = new System.Drawing.Point(210, 134);
			this.chkLogComm.Name = "chkLogComm";
			this.chkLogComm.Size = new System.Drawing.Size(150, 17);
			this.chkLogComm.TabIndex = 14;
			this.chkLogComm.Text = "Log Communication to File";
			this.chkLogComm.UseVisualStyleBackColor = true;
			this.chkLogComm.CheckedChanged += new System.EventHandler(this.chkLogComm_CheckedChanged);
			// 
			// BoxBoardTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(438, 312);
			this.Controls.Add(this.chkLogComm);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btIsBoxOpen);
			this.Controls.Add(this.btTestConnection);
			this.Controls.Add(this.btOpenBox);
			this.Controls.Add(this.txtResponse);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtIpAddress);
			this.Controls.Add(this.label2);
			this.Name = "BoxBoardTest";
			this.Text = "BoxBoardTest";
			this.Load += new System.EventHandler(this.BoxBoardTest_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBoxNo;
		private System.Windows.Forms.TextBox txtIpAddress;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtResponse;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btOpenBox;
		private System.Windows.Forms.Button btTestConnection;
		private System.Windows.Forms.Button btIsBoxOpen;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblBoxAddress;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label tc;
		private System.Windows.Forms.TextBox txtBoardNo;
		private System.Windows.Forms.CheckBox chkLogComm;
	}
}

