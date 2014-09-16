namespace ZillowForm {
	partial class ZillowFormView {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.streetComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.resultsBox = new System.Windows.Forms.TextBox();
			this.searchButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// streetComboBox
			// 
			this.streetComboBox.FormattingEnabled = true;
			this.streetComboBox.Location = new System.Drawing.Point(69, 39);
			this.streetComboBox.Name = "streetComboBox";
			this.streetComboBox.Size = new System.Drawing.Size(216, 21);
			this.streetComboBox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Address:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(86, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "EG: 1418 Ashton Rd, 19083";
			// 
			// resultsBox
			// 
			this.resultsBox.Location = new System.Drawing.Point(18, 66);
			this.resultsBox.Multiline = true;
			this.resultsBox.Name = "resultsBox";
			this.resultsBox.Size = new System.Drawing.Size(348, 231);
			this.resultsBox.TabIndex = 4;
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(291, 37);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(75, 23);
			this.searchButton.TabIndex = 5;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 309);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.resultsBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.streetComboBox);
			this.Name = "Form1";
			this.Text = "Zillow Calc";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox streetComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox resultsBox;
		private System.Windows.Forms.Button searchButton;
	}
}

