namespace P4U.Peri.BoxBoardKerong.Implementation.Simulator
{
	partial class BoxSimulatorForm
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
			this.chkOnTop = new System.Windows.Forms.CheckBox();
			this.chkThrowError = new System.Windows.Forms.CheckBox();
			this.txBoxMessage = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbIsOpen = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numReqDuration = new System.Windows.Forms.NumericUpDown();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Request = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Response = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.numReqDuration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// chkOnTop
			// 
			this.chkOnTop.AutoSize = true;
			this.chkOnTop.BackColor = System.Drawing.Color.Transparent;
			this.chkOnTop.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.chkOnTop.Checked = true;
			this.chkOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOnTop.Location = new System.Drawing.Point(12, 474);
			this.chkOnTop.Name = "chkOnTop";
			this.chkOnTop.Size = new System.Drawing.Size(96, 17);
			this.chkOnTop.TabIndex = 13;
			this.chkOnTop.Text = "Always on Top";
			this.chkOnTop.UseVisualStyleBackColor = false;
			// 
			// chkThrowError
			// 
			this.chkThrowError.AutoSize = true;
			this.chkThrowError.BackColor = System.Drawing.Color.Transparent;
			this.chkThrowError.Location = new System.Drawing.Point(12, 22);
			this.chkThrowError.Name = "chkThrowError";
			this.chkThrowError.Size = new System.Drawing.Size(107, 17);
			this.chkThrowError.TabIndex = 10;
			this.chkThrowError.Text = "Box Throws Error";
			this.chkThrowError.UseVisualStyleBackColor = false;
			// 
			// txBoxMessage
			// 
			this.txBoxMessage.Location = new System.Drawing.Point(12, 437);
			this.txBoxMessage.Name = "txBoxMessage";
			this.txBoxMessage.Size = new System.Drawing.Size(152, 20);
			this.txBoxMessage.TabIndex = 2;
			this.txBoxMessage.Text = "Chyba boxu.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 421);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "ExceptionText";
			// 
			// cbIsOpen
			// 
			this.cbIsOpen.AutoSize = true;
			this.cbIsOpen.BackColor = System.Drawing.Color.Transparent;
			this.cbIsOpen.Checked = true;
			this.cbIsOpen.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbIsOpen.Location = new System.Drawing.Point(147, 22);
			this.cbIsOpen.Name = "cbIsOpen";
			this.cbIsOpen.Size = new System.Drawing.Size(84, 17);
			this.cbIsOpen.TabIndex = 19;
			this.cbIsOpen.Text = "Box Is Open";
			this.cbIsOpen.UseVisualStyleBackColor = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(259, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "Request duration";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(416, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(20, 13);
			this.label4.TabIndex = 21;
			this.label4.Text = "ms";
			// 
			// numReqDuration
			// 
			this.numReqDuration.Location = new System.Drawing.Point(353, 18);
			this.numReqDuration.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numReqDuration.Name = "numReqDuration";
			this.numReqDuration.Size = new System.Drawing.Size(56, 20);
			this.numReqDuration.TabIndex = 20;
			this.numReqDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numReqDuration.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Address,
            this.IpAddress,
            this.Port,
            this.Request,
            this.Response});
			this.dataGridView1.Location = new System.Drawing.Point(3, 45);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(643, 373);
			this.dataGridView1.TabIndex = 23;
			// 
			// Time
			// 
			this.Time.DataPropertyName = "Time";
			this.Time.HeaderText = "Time";
			this.Time.Name = "Time";
			// 
			// Address
			// 
			this.Address.DataPropertyName = "Address";
			this.Address.HeaderText = "Address";
			this.Address.Name = "Address";
			// 
			// IpAddress
			// 
			this.IpAddress.DataPropertyName = "IpAddress";
			this.IpAddress.HeaderText = "IpAddress";
			this.IpAddress.Name = "IpAddress";
			// 
			// Port
			// 
			this.Port.DataPropertyName = "Port";
			this.Port.HeaderText = "Port";
			this.Port.Name = "Port";
			// 
			// Request
			// 
			this.Request.DataPropertyName = "Request";
			this.Request.HeaderText = "Request";
			this.Request.Name = "Request";
			// 
			// Response
			// 
			this.Response.DataPropertyName = "Response";
			this.Response.HeaderText = "Response";
			this.Response.Name = "Response";
			// 
			// BoxSimulatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(658, 502);
			this.ControlBox = false;
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numReqDuration);
			this.Controls.Add(this.cbIsOpen);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txBoxMessage);
			this.Controls.Add(this.chkOnTop);
			this.Controls.Add(this.chkThrowError);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BoxSimulatorForm";
			this.Text = "Box Controller Simulator";
			((System.ComponentModel.ISupportInitialize)(this.numReqDuration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckBox chkOnTop;
		private System.Windows.Forms.CheckBox chkThrowError;
		private System.Windows.Forms.TextBox txBoxMessage;
		private System.Windows.Forms.Label label3;
		//private Common.Win.FSDGrid.FSDGrid grid;
		private System.Windows.Forms.CheckBox cbIsOpen;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numReqDuration;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Time;
		private System.Windows.Forms.DataGridViewTextBoxColumn Address;
		private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
		private System.Windows.Forms.DataGridViewTextBoxColumn Port;
		private System.Windows.Forms.DataGridViewTextBoxColumn Request;
		private System.Windows.Forms.DataGridViewTextBoxColumn Response;
	}
}