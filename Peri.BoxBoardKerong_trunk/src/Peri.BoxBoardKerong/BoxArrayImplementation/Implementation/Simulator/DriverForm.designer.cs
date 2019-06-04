namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation.Implementation.Simulator
{
	partial class DriverForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverForm));
			this.modulePanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// modulePanel
			// 
			this.modulePanel.AutoSize = true;
			this.modulePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.modulePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modulePanel.Location = new System.Drawing.Point(0, 0);
			this.modulePanel.Name = "modulePanel";
			this.modulePanel.Size = new System.Drawing.Size(180, 311);
			this.modulePanel.TabIndex = 1;
			// 
			// DriverForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(180, 311);
			this.ControlBox = false;
			this.Controls.Add(this.modulePanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DriverForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DriverForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DriverForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DriverForm_FormClosed);
			this.Load += new System.EventHandler(this.DriverForm_Load);
			this.Move += new System.EventHandler(this.DriverForm_Move);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel modulePanel;
	}
}