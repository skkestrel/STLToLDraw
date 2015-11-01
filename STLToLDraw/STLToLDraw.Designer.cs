namespace STLToLDraw
{
	partial class STLToLDraw
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
			this._openButton = new System.Windows.Forms.Button();
			this._infoLabel = new System.Windows.Forms.Label();
			this._convertButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this._scaleBox = new System.Windows.Forms.NumericUpDown();
			this._progressBar = new System.Windows.Forms.ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this._scaleBox)).BeginInit();
			this.SuspendLayout();
			// 
			// _openButton
			// 
			this._openButton.Location = new System.Drawing.Point(12, 12);
			this._openButton.Name = "_openButton";
			this._openButton.Size = new System.Drawing.Size(75, 23);
			this._openButton.TabIndex = 0;
			this._openButton.Text = "Open";
			this._openButton.UseVisualStyleBackColor = true;
			this._openButton.Click += new System.EventHandler(this.OpenButtonOnClick);
			// 
			// _infoLabel
			// 
			this._infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._infoLabel.Location = new System.Drawing.Point(12, 36);
			this._infoLabel.Name = "_infoLabel";
			this._infoLabel.Size = new System.Drawing.Size(437, 20);
			this._infoLabel.TabIndex = 2;
			// 
			// _convertButton
			// 
			this._convertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._convertButton.Location = new System.Drawing.Point(374, 12);
			this._convertButton.Name = "_convertButton";
			this._convertButton.Size = new System.Drawing.Size(75, 23);
			this._convertButton.TabIndex = 3;
			this._convertButton.Text = "Convert";
			this._convertButton.UseVisualStyleBackColor = true;
			this._convertButton.Click += new System.EventHandler(this.ConvertButtonOnClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(95, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(194, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Scale Factor (STL units to LDraw Units)";
			// 
			// _scaleBox
			// 
			this._scaleBox.DecimalPlaces = 3;
			this._scaleBox.Location = new System.Drawing.Point(295, 13);
			this._scaleBox.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this._scaleBox.Name = "_scaleBox";
			this._scaleBox.Size = new System.Drawing.Size(73, 20);
			this._scaleBox.TabIndex = 5;
			this._scaleBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// _progressBar
			// 
			this._progressBar.Location = new System.Drawing.Point(15, 60);
			this._progressBar.Name = "_progressBar";
			this._progressBar.Size = new System.Drawing.Size(434, 23);
			this._progressBar.TabIndex = 6;
			// 
			// STLToLDraw
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 219);
			this.Controls.Add(this._progressBar);
			this.Controls.Add(this._scaleBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._convertButton);
			this.Controls.Add(this._infoLabel);
			this.Controls.Add(this._openButton);
			this.Name = "STLToLDraw";
			this.Text = "STLToLDraw";
			((System.ComponentModel.ISupportInitialize)(this._scaleBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _openButton;
		private System.Windows.Forms.Label _infoLabel;
		private System.Windows.Forms.Button _convertButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown _scaleBox;
		private System.Windows.Forms.ProgressBar _progressBar;
	}
}

