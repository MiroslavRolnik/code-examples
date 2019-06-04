namespace Peri.BoxArrayBoardKerong.Test
{
	partial class BoxArrayBoardTestForm
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
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btInit = new System.Windows.Forms.Button();
			this.btDeinit = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.cbImplementation = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btUnlock = new System.Windows.Forms.Button();
			this.txtBoxNumber = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panelBoxCheckboxes = new System.Windows.Forms.Panel();
			this.cbBox15 = new System.Windows.Forms.CheckBox();
			this.cbBox14 = new System.Windows.Forms.CheckBox();
			this.cbBox13 = new System.Windows.Forms.CheckBox();
			this.cbBox12 = new System.Windows.Forms.CheckBox();
			this.cbBox11 = new System.Windows.Forms.CheckBox();
			this.cbBox10 = new System.Windows.Forms.CheckBox();
			this.cbBox9 = new System.Windows.Forms.CheckBox();
			this.cbBox8 = new System.Windows.Forms.CheckBox();
			this.cbBox7 = new System.Windows.Forms.CheckBox();
			this.cbBox6 = new System.Windows.Forms.CheckBox();
			this.cbBox5 = new System.Windows.Forms.CheckBox();
			this.cbBox4 = new System.Windows.Forms.CheckBox();
			this.cbBox3 = new System.Windows.Forms.CheckBox();
			this.cbBox2 = new System.Windows.Forms.CheckBox();
			this.cbBox1 = new System.Windows.Forms.CheckBox();
			this.cbBox0 = new System.Windows.Forms.CheckBox();
			this.lblInternalErrors = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.cbModuleSocket = new System.Windows.Forms.ComboBox();
			this.btGetState = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtModuleAddress = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.chkLogComm = new System.Windows.Forms.CheckBox();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtBoxNumber)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panelBoxCheckboxes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtModuleAddress)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btInit);
			this.groupBox4.Controls.Add(this.btDeinit);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.cbImplementation);
			this.groupBox4.Location = new System.Drawing.Point(12, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(215, 82);
			this.groupBox4.TabIndex = 15;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Funkce kontroleru";
			// 
			// btInit
			// 
			this.btInit.Location = new System.Drawing.Point(9, 19);
			this.btInit.Name = "btInit";
			this.btInit.Size = new System.Drawing.Size(89, 23);
			this.btInit.TabIndex = 1;
			this.btInit.Text = "Init";
			this.btInit.UseVisualStyleBackColor = true;
			this.btInit.Click += new System.EventHandler(this.btInit_Click);
			// 
			// btDeinit
			// 
			this.btDeinit.Location = new System.Drawing.Point(98, 19);
			this.btDeinit.Name = "btDeinit";
			this.btDeinit.Size = new System.Drawing.Size(89, 23);
			this.btDeinit.TabIndex = 2;
			this.btDeinit.Text = "Deinit";
			this.btDeinit.UseVisualStyleBackColor = true;
			this.btDeinit.Click += new System.EventHandler(this.btDeinit_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 51);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Impl.:";
			// 
			// cbImplementation
			// 
			this.cbImplementation.FormattingEnabled = true;
			this.cbImplementation.Location = new System.Drawing.Point(44, 48);
			this.cbImplementation.Name = "cbImplementation";
			this.cbImplementation.Size = new System.Drawing.Size(143, 21);
			this.cbImplementation.TabIndex = 3;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btUnlock);
			this.groupBox2.Controls.Add(this.txtBoxNumber);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(12, 333);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(215, 109);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Funkce boxu";
			// 
			// btUnlock
			// 
			this.btUnlock.Location = new System.Drawing.Point(10, 54);
			this.btUnlock.Name = "btUnlock";
			this.btUnlock.Size = new System.Drawing.Size(166, 36);
			this.btUnlock.TabIndex = 2;
			this.btUnlock.Text = "Odemknout";
			this.btUnlock.UseVisualStyleBackColor = true;
			this.btUnlock.Click += new System.EventHandler(this.btUnlock_Click);
			// 
			// txtBoxNumber
			// 
			this.txtBoxNumber.Location = new System.Drawing.Point(113, 23);
			this.txtBoxNumber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.txtBoxNumber.Name = "txtBoxNumber";
			this.txtBoxNumber.Size = new System.Drawing.Size(63, 20);
			this.txtBoxNumber.TabIndex = 1;
			this.txtBoxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtBoxNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Logické číslo boxu:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panelBoxCheckboxes);
			this.groupBox1.Controls.Add(this.lblInternalErrors);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.cbModuleSocket);
			this.groupBox1.Controls.Add(this.btGetState);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtModuleAddress);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Location = new System.Drawing.Point(12, 100);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(215, 227);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Funkce modulu";
			// 
			// panelBoxCheckboxes
			// 
			this.panelBoxCheckboxes.Controls.Add(this.cbBox15);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox14);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox13);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox12);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox11);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox10);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox9);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox8);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox7);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox6);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox5);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox4);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox3);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox2);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox1);
			this.panelBoxCheckboxes.Controls.Add(this.cbBox0);
			this.panelBoxCheckboxes.Location = new System.Drawing.Point(6, 91);
			this.panelBoxCheckboxes.Name = "panelBoxCheckboxes";
			this.panelBoxCheckboxes.Size = new System.Drawing.Size(106, 119);
			this.panelBoxCheckboxes.TabIndex = 65;
			// 
			// cbBox15
			// 
			this.cbBox15.AutoSize = true;
			this.cbBox15.Location = new System.Drawing.Point(58, 102);
			this.cbBox15.Name = "cbBox15";
			this.cbBox15.Size = new System.Drawing.Size(38, 17);
			this.cbBox15.TabIndex = 50;
			this.cbBox15.Tag = "16";
			this.cbBox15.Text = "16";
			this.cbBox15.UseVisualStyleBackColor = true;
			// 
			// cbBox14
			// 
			this.cbBox14.AutoSize = true;
			this.cbBox14.Location = new System.Drawing.Point(58, 88);
			this.cbBox14.Name = "cbBox14";
			this.cbBox14.Size = new System.Drawing.Size(38, 17);
			this.cbBox14.TabIndex = 49;
			this.cbBox14.Tag = "15";
			this.cbBox14.Text = "15";
			this.cbBox14.UseVisualStyleBackColor = true;
			// 
			// cbBox13
			// 
			this.cbBox13.AutoSize = true;
			this.cbBox13.Location = new System.Drawing.Point(58, 74);
			this.cbBox13.Name = "cbBox13";
			this.cbBox13.Size = new System.Drawing.Size(38, 17);
			this.cbBox13.TabIndex = 48;
			this.cbBox13.Tag = "14";
			this.cbBox13.Text = "14";
			this.cbBox13.UseVisualStyleBackColor = true;
			// 
			// cbBox12
			// 
			this.cbBox12.AutoSize = true;
			this.cbBox12.Location = new System.Drawing.Point(58, 60);
			this.cbBox12.Name = "cbBox12";
			this.cbBox12.Size = new System.Drawing.Size(38, 17);
			this.cbBox12.TabIndex = 47;
			this.cbBox12.Tag = "13";
			this.cbBox12.Text = "13";
			this.cbBox12.UseVisualStyleBackColor = true;
			// 
			// cbBox11
			// 
			this.cbBox11.AutoSize = true;
			this.cbBox11.Location = new System.Drawing.Point(58, 46);
			this.cbBox11.Name = "cbBox11";
			this.cbBox11.Size = new System.Drawing.Size(38, 17);
			this.cbBox11.TabIndex = 46;
			this.cbBox11.Tag = "12";
			this.cbBox11.Text = "12";
			this.cbBox11.UseVisualStyleBackColor = true;
			// 
			// cbBox10
			// 
			this.cbBox10.AutoSize = true;
			this.cbBox10.BackColor = System.Drawing.Color.Red;
			this.cbBox10.Location = new System.Drawing.Point(58, 32);
			this.cbBox10.Name = "cbBox10";
			this.cbBox10.Size = new System.Drawing.Size(38, 17);
			this.cbBox10.TabIndex = 45;
			this.cbBox10.Tag = "11";
			this.cbBox10.Text = "11";
			this.cbBox10.UseVisualStyleBackColor = false;
			// 
			// cbBox9
			// 
			this.cbBox9.AutoSize = true;
			this.cbBox9.BackColor = System.Drawing.Color.PaleGreen;
			this.cbBox9.Location = new System.Drawing.Point(58, 18);
			this.cbBox9.Name = "cbBox9";
			this.cbBox9.Size = new System.Drawing.Size(38, 17);
			this.cbBox9.TabIndex = 44;
			this.cbBox9.Tag = "10";
			this.cbBox9.Text = "10";
			this.cbBox9.UseVisualStyleBackColor = false;
			// 
			// cbBox8
			// 
			this.cbBox8.AutoSize = true;
			this.cbBox8.Location = new System.Drawing.Point(58, 4);
			this.cbBox8.Name = "cbBox8";
			this.cbBox8.Size = new System.Drawing.Size(32, 17);
			this.cbBox8.TabIndex = 43;
			this.cbBox8.Tag = "9";
			this.cbBox8.Text = "9";
			this.cbBox8.UseVisualStyleBackColor = true;
			// 
			// cbBox7
			// 
			this.cbBox7.AutoSize = true;
			this.cbBox7.Location = new System.Drawing.Point(5, 102);
			this.cbBox7.Name = "cbBox7";
			this.cbBox7.Size = new System.Drawing.Size(32, 17);
			this.cbBox7.TabIndex = 42;
			this.cbBox7.Tag = "8";
			this.cbBox7.Text = "8";
			this.cbBox7.UseVisualStyleBackColor = true;
			// 
			// cbBox6
			// 
			this.cbBox6.AutoSize = true;
			this.cbBox6.Location = new System.Drawing.Point(5, 88);
			this.cbBox6.Name = "cbBox6";
			this.cbBox6.Size = new System.Drawing.Size(32, 17);
			this.cbBox6.TabIndex = 41;
			this.cbBox6.Tag = "7";
			this.cbBox6.Text = "7";
			this.cbBox6.UseVisualStyleBackColor = true;
			// 
			// cbBox5
			// 
			this.cbBox5.AutoSize = true;
			this.cbBox5.Location = new System.Drawing.Point(5, 74);
			this.cbBox5.Name = "cbBox5";
			this.cbBox5.Size = new System.Drawing.Size(32, 17);
			this.cbBox5.TabIndex = 40;
			this.cbBox5.Tag = "6";
			this.cbBox5.Text = "6";
			this.cbBox5.UseVisualStyleBackColor = true;
			// 
			// cbBox4
			// 
			this.cbBox4.AutoSize = true;
			this.cbBox4.Location = new System.Drawing.Point(5, 60);
			this.cbBox4.Name = "cbBox4";
			this.cbBox4.Size = new System.Drawing.Size(32, 17);
			this.cbBox4.TabIndex = 39;
			this.cbBox4.Tag = "5";
			this.cbBox4.Text = "5";
			this.cbBox4.UseVisualStyleBackColor = true;
			// 
			// cbBox3
			// 
			this.cbBox3.AutoSize = true;
			this.cbBox3.Location = new System.Drawing.Point(5, 46);
			this.cbBox3.Name = "cbBox3";
			this.cbBox3.Size = new System.Drawing.Size(32, 17);
			this.cbBox3.TabIndex = 38;
			this.cbBox3.Tag = "4";
			this.cbBox3.Text = "4";
			this.cbBox3.UseVisualStyleBackColor = true;
			// 
			// cbBox2
			// 
			this.cbBox2.AutoSize = true;
			this.cbBox2.Location = new System.Drawing.Point(5, 32);
			this.cbBox2.Name = "cbBox2";
			this.cbBox2.Size = new System.Drawing.Size(32, 17);
			this.cbBox2.TabIndex = 37;
			this.cbBox2.Tag = "3";
			this.cbBox2.Text = "3";
			this.cbBox2.UseVisualStyleBackColor = true;
			// 
			// cbBox1
			// 
			this.cbBox1.AutoSize = true;
			this.cbBox1.Location = new System.Drawing.Point(5, 18);
			this.cbBox1.Name = "cbBox1";
			this.cbBox1.Size = new System.Drawing.Size(32, 17);
			this.cbBox1.TabIndex = 36;
			this.cbBox1.Tag = "2";
			this.cbBox1.Text = "2";
			this.cbBox1.UseVisualStyleBackColor = true;
			// 
			// cbBox0
			// 
			this.cbBox0.AutoSize = true;
			this.cbBox0.Location = new System.Drawing.Point(5, 4);
			this.cbBox0.Name = "cbBox0";
			this.cbBox0.Size = new System.Drawing.Size(32, 17);
			this.cbBox0.TabIndex = 35;
			this.cbBox0.Tag = "1";
			this.cbBox0.Text = "1";
			this.cbBox0.UseVisualStyleBackColor = true;
			// 
			// lblInternalErrors
			// 
			this.lblInternalErrors.AutoSize = true;
			this.lblInternalErrors.Location = new System.Drawing.Point(78, 210);
			this.lblInternalErrors.Name = "lblInternalErrors";
			this.lblInternalErrors.Size = new System.Drawing.Size(79, 13);
			this.lblInternalErrors.TabIndex = 64;
			this.lblInternalErrors.Text = "lblInternalErrors";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(8, 210);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(72, 13);
			this.label13.TabIndex = 63;
			this.label13.Text = "Interní chyby:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(8, 54);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(35, 13);
			this.label11.TabIndex = 51;
			this.label11.Text = "Driver";
			// 
			// cbModuleSocket
			// 
			this.cbModuleSocket.FormattingEnabled = true;
			this.cbModuleSocket.Location = new System.Drawing.Point(64, 51);
			this.cbModuleSocket.Name = "cbModuleSocket";
			this.cbModuleSocket.Size = new System.Drawing.Size(145, 21);
			this.cbModuleSocket.TabIndex = 14;
			// 
			// btGetState
			// 
			this.btGetState.Location = new System.Drawing.Point(127, 94);
			this.btGetState.Name = "btGetState";
			this.btGetState.Size = new System.Drawing.Size(82, 44);
			this.btGetState.TabIndex = 4;
			this.btGetState.Text = "Zjistit stav modulu";
			this.btGetState.UseVisualStyleBackColor = true;
			this.btGetState.Click += new System.EventHandler(this.btGetState_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 34;
			this.label2.Text = "Odemknuto:";
			// 
			// txtModuleAddress
			// 
			this.txtModuleAddress.Location = new System.Drawing.Point(131, 23);
			this.txtModuleAddress.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.txtModuleAddress.Name = "txtModuleAddress";
			this.txtModuleAddress.Size = new System.Drawing.Size(78, 20);
			this.txtModuleAddress.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 25);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 13);
			this.label8.TabIndex = 18;
			this.label8.Text = "Adresa modulu:";
			// 
			// chkLogComm
			// 
			this.chkLogComm.AutoSize = true;
			this.chkLogComm.Location = new System.Drawing.Point(21, 448);
			this.chkLogComm.Name = "chkLogComm";
			this.chkLogComm.Size = new System.Drawing.Size(150, 17);
			this.chkLogComm.TabIndex = 18;
			this.chkLogComm.Text = "Log Communication to File";
			this.chkLogComm.UseVisualStyleBackColor = true;
			this.chkLogComm.CheckedChanged += new System.EventHandler(this.chkLogComm_CheckedChanged);
			// 
			// BoxArrayBoardTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(240, 473);
			this.Controls.Add(this.chkLogComm);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox4);
			this.Name = "BoxArrayBoardTestForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.BoxArrayBoardTestForm_Load);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtBoxNumber)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panelBoxCheckboxes.ResumeLayout(false);
			this.panelBoxCheckboxes.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtModuleAddress)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btInit;
		private System.Windows.Forms.Button btDeinit;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbImplementation;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btUnlock;
		private System.Windows.Forms.NumericUpDown txtBoxNumber;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.CheckBox cbBox15;
		private System.Windows.Forms.CheckBox cbBox14;
		private System.Windows.Forms.CheckBox cbBox13;
		private System.Windows.Forms.CheckBox cbBox12;
		private System.Windows.Forms.CheckBox cbBox11;
		private System.Windows.Forms.CheckBox cbBox10;
		private System.Windows.Forms.CheckBox cbBox9;
		private System.Windows.Forms.CheckBox cbBox8;
		private System.Windows.Forms.CheckBox cbBox7;
		private System.Windows.Forms.CheckBox cbBox6;
		private System.Windows.Forms.CheckBox cbBox5;
		private System.Windows.Forms.CheckBox cbBox4;
		private System.Windows.Forms.CheckBox cbBox3;
		private System.Windows.Forms.CheckBox cbBox2;
		private System.Windows.Forms.CheckBox cbBox1;
		private System.Windows.Forms.CheckBox cbBox0;
		private System.Windows.Forms.ComboBox cbModuleSocket;
		private System.Windows.Forms.Button btGetState;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown txtModuleAddress;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblInternalErrors;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Panel panelBoxCheckboxes;
		private System.Windows.Forms.CheckBox chkLogComm;
	}
}

