namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation.Implementation.Simulator
{
	partial class ModuleControl
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
			this.panelBoxes = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.lblAddress = new System.Windows.Forms.Label();
			this.cbErr = new System.Windows.Forms.CheckBox();
			this.numDuration = new System.Windows.Forms.NumericUpDown();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelBoxes
			// 
			this.panelBoxes.AutoSize = true;
			this.panelBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBoxes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.panelBoxes.Location = new System.Drawing.Point(0, 60);
			this.panelBoxes.Name = "panelBoxes";
			this.panelBoxes.Size = new System.Drawing.Size(115, 40);
			this.panelBoxes.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Address:";
			// 
			// lblAddress
			// 
			this.lblAddress.AutoSize = true;
			this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblAddress.Location = new System.Drawing.Point(55, 3);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(23, 13);
			this.lblAddress.TabIndex = 3;
			this.lblAddress.Text = "XX";
			// 
			// cbErr
			// 
			this.cbErr.AutoSize = true;
			this.cbErr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbErr.Location = new System.Drawing.Point(1, 19);
			this.cbErr.Name = "cbErr";
			this.cbErr.Size = new System.Drawing.Size(86, 17);
			this.cbErr.TabIndex = 1;
			this.cbErr.Text = "Module Error";
			this.cbErr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbErr.UseVisualStyleBackColor = true;
			this.cbErr.CheckedChanged += new System.EventHandler(this.cbErr_CheckedChanged);
			// 
			// numDuration
			// 
			this.numDuration.AutoSize = true;
			this.numDuration.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numDuration.Location = new System.Drawing.Point(55, 37);
			this.numDuration.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numDuration.Name = "numDuration";
			this.numDuration.Size = new System.Drawing.Size(56, 20);
			this.numDuration.TabIndex = 8;
			this.numDuration.ThousandsSeparator = true;
			this.numDuration.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.cbErr);
			this.panel1.Controls.Add(this.numDuration);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lblAddress);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(115, 60);
			this.panel1.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Duration:";
			// 
			// ModuleControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.panelBoxes);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(1);
			this.Name = "ModuleControl";
			this.Size = new System.Drawing.Size(115, 100);
			this.Load += new System.EventHandler(this.ModuleControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel panelBoxes;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblAddress;
		private System.Windows.Forms.CheckBox cbErr;
		private System.Windows.Forms.NumericUpDown numDuration;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
	}
}
