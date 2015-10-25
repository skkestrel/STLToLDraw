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
			this._fileLabel = new System.Windows.Forms.Label();
			this._infoLabel = new System.Windows.Forms.Label();
			this._convertButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _openButton
			// 
			this._openButton.Location = new System.Drawing.Point(13, 13);
			this._openButton.Name = "_openButton";
			this._openButton.Size = new System.Drawing.Size(75, 23);
			this._openButton.TabIndex = 0;
			this._openButton.Text = "Open";
			this._openButton.UseVisualStyleBackColor = true;
			this._openButton.Click += new System.EventHandler(this.OpenButtonOnClick);
			// 
			// _fileLabel
			// 
			this._fileLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._fileLabel.Location = new System.Drawing.Point(12, 39);
			this._fileLabel.Name = "_fileLabel";
			this._fileLabel.Size = new System.Drawing.Size(437, 20);
			this._fileLabel.TabIndex = 1;
			// 
			// _infoLabel
			// 
			this._infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._infoLabel.Location = new System.Drawing.Point(12, 59);
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
			// STLToLDraw
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 219);
			this.Controls.Add(this._convertButton);
			this.Controls.Add(this._infoLabel);
			this.Controls.Add(this._fileLabel);
			this.Controls.Add(this._openButton);
			this.Name = "STLToLDraw";
			this.Text = "STLToLDraw";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _openButton;
		private System.Windows.Forms.Label _fileLabel;
		private System.Windows.Forms.Label _infoLabel;
		private System.Windows.Forms.Button _convertButton;
	}
}

