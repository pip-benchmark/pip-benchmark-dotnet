using PipBenchmark.Gui.Properties;

namespace PipBenchmark.Gui.Errors
{
    partial class ErrorDialog
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
            this.messageLabel = new System.Windows.Forms.Label();
            this.additionalInformationLabel = new System.Windows.Forms.Label();
            this.errorIconPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.detailsButton = new System.Windows.Forms.Button();
            this.splitterPanel = new System.Windows.Forms.Panel();
            this.stackTraceTextBox = new System.Windows.Forms.TextBox();
            this.abortButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.Location = new System.Drawing.Point(122, 27);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(920, 35);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.Text = "Error Message...";
            // 
            // additionalInformationLabel
            // 
            this.additionalInformationLabel.AutoSize = true;
            this.additionalInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.additionalInformationLabel.Location = new System.Drawing.Point(122, 69);
            this.additionalInformationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.additionalInformationLabel.Name = "additionalInformationLabel";
            this.additionalInformationLabel.Size = new System.Drawing.Size(252, 26);
            this.additionalInformationLabel.TabIndex = 2;
            this.additionalInformationLabel.Text = "Additional Information:";
            // 
            // errorIconPictureBox
            // 
            this.errorIconPictureBox.Image = global::PipBenchmark.Gui.Properties.Resources.ErrorLarge;
            this.errorIconPictureBox.Location = new System.Drawing.Point(26, 27);
            this.errorIconPictureBox.Margin = new System.Windows.Forms.Padding(6);
            this.errorIconPictureBox.Name = "errorIconPictureBox";
            this.errorIconPictureBox.Size = new System.Drawing.Size(70, 67);
            this.errorIconPictureBox.TabIndex = 0;
            this.errorIconPictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PipBenchmark.Gui.Properties.Resources.DetailsGlyph;
            this.pictureBox1.Location = new System.Drawing.Point(128, 100);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 31);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // detailsLabel
            // 
            this.detailsLabel.Location = new System.Drawing.Point(170, 104);
            this.detailsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(872, 119);
            this.detailsLabel.TabIndex = 4;
            this.detailsLabel.Text = "Error Details...";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(772, 767);
            this.okButton.Margin = new System.Windows.Forms.Padding(6);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(150, 44);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OnOkClick);
            // 
            // detailsButton
            // 
            this.detailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.detailsButton.Location = new System.Drawing.Point(26, 767);
            this.detailsButton.Margin = new System.Windows.Forms.Padding(6);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(150, 44);
            this.detailsButton.TabIndex = 6;
            this.detailsButton.Text = "Details <<";
            this.detailsButton.UseVisualStyleBackColor = true;
            this.detailsButton.Click += new System.EventHandler(this.OnDetailsClick);
            // 
            // splitterPanel
            // 
            this.splitterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitterPanel.Location = new System.Drawing.Point(-4, 237);
            this.splitterPanel.Margin = new System.Windows.Forms.Padding(6);
            this.splitterPanel.Name = "splitterPanel";
            this.splitterPanel.Size = new System.Drawing.Size(954, 4);
            this.splitterPanel.TabIndex = 7;
            // 
            // stackTraceTextBox
            // 
            this.stackTraceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stackTraceTextBox.Location = new System.Drawing.Point(26, 256);
            this.stackTraceTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.stackTraceTextBox.Multiline = true;
            this.stackTraceTextBox.Name = "stackTraceTextBox";
            this.stackTraceTextBox.ReadOnly = true;
            this.stackTraceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.stackTraceTextBox.Size = new System.Drawing.Size(892, 496);
            this.stackTraceTextBox.TabIndex = 8;
            this.stackTraceTextBox.WordWrap = false;
            // 
            // abortButton
            // 
            this.abortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.abortButton.Location = new System.Drawing.Point(772, 767);
            this.abortButton.Margin = new System.Windows.Forms.Padding(6);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(150, 44);
            this.abortButton.TabIndex = 9;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.OnAbortClick);
            // 
            // continueButton
            // 
            this.continueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.continueButton.Location = new System.Drawing.Point(610, 767);
            this.continueButton.Margin = new System.Windows.Forms.Padding(6);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(150, 44);
            this.continueButton.TabIndex = 10;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.OnOkClick);
            // 
            // ErrorDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 836);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.stackTraceTextBox);
            this.Controls.Add(this.splitterPanel);
            this.Controls.Add(this.detailsButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.detailsLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.additionalInformationLabel);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.errorIconPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ErrorDialog";
            this.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error";
            ((System.ComponentModel.ISupportInitialize)(this.errorIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox errorIconPictureBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label additionalInformationLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label detailsLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button detailsButton;
        private System.Windows.Forms.Panel splitterPanel;
        private System.Windows.Forms.TextBox stackTraceTextBox;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.Button continueButton;
    }
}