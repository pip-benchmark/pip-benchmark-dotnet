using PipBenchmark.Runner.Gui.Properties;

namespace PipBenchmark.Runner.Gui.AsyncWait
{
    partial class AsyncWaitDialog
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
            this.statusMessageLabel = new System.Windows.Forms.Label();
            this.abortButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // statusMessageLabel
            // 
            this.statusMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusMessageLabel.Location = new System.Drawing.Point(132, 27);
            this.statusMessageLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.statusMessageLabel.Name = "statusMessageLabel";
            this.statusMessageLabel.Size = new System.Drawing.Size(484, 81);
            this.statusMessageLabel.TabIndex = 1;
            this.statusMessageLabel.Text = "Message";
            // 
            // abortButton
            // 
            this.abortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.abortButton.Location = new System.Drawing.Point(246, 131);
            this.abortButton.Margin = new System.Windows.Forms.Padding(6);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(150, 44);
            this.abortButton.TabIndex = 2;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::PipBenchmark.Runner.Gui.Properties.Resources.WaitLarge;
            this.pictureBox.Location = new System.Drawing.Point(26, 25);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(76, 73);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // AsyncWaitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 200);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.statusMessageLabel);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "AsyncWaitDialog";
            this.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Processing...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label statusMessageLabel;
        private System.Windows.Forms.Button abortButton;
    }
}