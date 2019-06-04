namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation.Implementation.Simulator
{
	partial class BoxControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbEnableDoorUnlock = new System.Windows.Forms.CheckBox();
			this.lblNumber = new System.Windows.Forms.Label();
			this.btClose = new System.Windows.Forms.Button();
			this.lblNumberModulePort = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbEnableDoorUnlock
			// 
			this.cbEnableDoorUnlock.AutoSize = true;
			this.cbEnableDoorUnlock.Location = new System.Drawing.Point(39, 3);
			this.cbEnableDoorUnlock.Name = "cbEnableDoorUnlock";
			this.cbEnableDoorUnlock.Size = new System.Drawing.Size(70, 17);
			this.cbEnableDoorUnlock.TabIndex = 0;
			this.cbEnableDoorUnlock.Text = "Open OK";
			this.cbEnableDoorUnlock.UseVisualStyleBackColor = true;
			this.cbEnableDoorUnlock.CheckedChanged += new System.EventHandler(this.cbEnableDoorUnlock_CheckedChanged);
			// 
			// lblNumber
			// 
			this.lblNumber.AutoSize = true;
			this.lblNumber.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblNumber.Location = new System.Drawing.Point(0, 2);
			this.lblNumber.Name = "lblNumber";
			this.lblNumber.Size = new System.Drawing.Size(28, 18);
			this.lblNumber.TabIndex = 1;
			this.lblNumber.Text = "00";
			// 
			// btClose
			// 
			this.btClose.Location = new System.Drawing.Point(36, 0);
			this.btClose.Name = "btClose";
			this.btClose.Size = new System.Drawing.Size(52, 21);
			this.btClose.TabIndex = 3;
			this.btClose.Text = "CLOSE";
			this.btClose.UseVisualStyleBackColor = true;
			this.btClose.Click += new System.EventHandler(this.btClose_Click);
			// 
			// lblNumberModulePort
			// 
			this.lblNumberModulePort.AutoSize = true;
			this.lblNumberModulePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblNumberModulePort.Location = new System.Drawing.Point(24, 4);
			this.lblNumberModulePort.Name = "lblNumberModulePort";
			this.lblNumberModulePort.Size = new System.Drawing.Size(11, 12);
			this.lblNumberModulePort.TabIndex = 6;
			this.lblNumberModulePort.Text = "X";
			// 
			// BoxControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblNumberModulePort);
			this.Controls.Add(this.lblNumber);
			this.Controls.Add(this.cbEnableDoorUnlock);
			this.Controls.Add(this.btClose);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "BoxControl";
			this.Size = new System.Drawing.Size(115, 22);
			this.Load += new System.EventHandler(this.BoxControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbEnableDoorUnlock;
		private System.Windows.Forms.Label lblNumber;
		private System.Windows.Forms.Button btClose;
		private System.Windows.Forms.Label lblNumberModulePort;
	}
}
