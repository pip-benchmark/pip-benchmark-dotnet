namespace PipBenchmark.Runner.Gui.Results
{
    partial class ResultsPerspective
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
            this.printReportButton = new System.Windows.Forms.Button();
            this.saveReportButton = new System.Windows.Forms.Button();
            this.reportContentTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // printReportButton
            // 
            this.printReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printReportButton.Location = new System.Drawing.Point(818, 728);
            this.printReportButton.Margin = new System.Windows.Forms.Padding(6);
            this.printReportButton.Name = "printReportButton";
            this.printReportButton.Size = new System.Drawing.Size(72, 23);
            this.printReportButton.TabIndex = 1;
            this.printReportButton.Text = "Print...";
            this.printReportButton.UseVisualStyleBackColor = true;
            // 
            // saveReportButton
            // 
            this.saveReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveReportButton.Location = new System.Drawing.Point(902, 728);
            this.saveReportButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveReportButton.Name = "saveReportButton";
            this.saveReportButton.Size = new System.Drawing.Size(72, 23);
            this.saveReportButton.TabIndex = 2;
            this.saveReportButton.Text = "Save...";
            this.saveReportButton.UseVisualStyleBackColor = true;
            // 
            // reportContentTextBox
            // 
            this.reportContentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportContentTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.reportContentTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportContentTextBox.Location = new System.Drawing.Point(26, 25);
            this.reportContentTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.reportContentTextBox.Multiline = true;
            this.reportContentTextBox.Name = "reportContentTextBox";
            this.reportContentTextBox.ReadOnly = true;
            this.reportContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.reportContentTextBox.Size = new System.Drawing.Size(944, 691);
            this.reportContentTextBox.TabIndex = 3;
            this.reportContentTextBox.WordWrap = false;
            // 
            // ResultsPerspective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportContentTextBox);
            this.Controls.Add(this.saveReportButton);
            this.Controls.Add(this.printReportButton);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ResultsPerspective";
            this.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.Size = new System.Drawing.Size(1000, 769);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printReportButton;
        private System.Windows.Forms.Button saveReportButton;
        private System.Windows.Forms.TextBox reportContentTextBox;
    }
}
