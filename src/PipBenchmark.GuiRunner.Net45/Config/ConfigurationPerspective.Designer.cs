namespace PipBenchmark.Runner.Gui.Config
{
    partial class ConfigurationPerspective
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.parametersLabel = new System.Windows.Forms.Label();
            this.configParamsDataGridView = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configParamsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loadConfigurationButton = new System.Windows.Forms.Button();
            this.saveConfigurationButton = new System.Windows.Forms.Button();
            this.setToDefaultParamsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.configParamsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configParamsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // parametersLabel
            // 
            this.parametersLabel.AutoSize = true;
            this.parametersLabel.Location = new System.Drawing.Point(26, 19);
            this.parametersLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.parametersLabel.Name = "parametersLabel";
            this.parametersLabel.Size = new System.Drawing.Size(63, 13);
            this.parametersLabel.TabIndex = 0;
            this.parametersLabel.Text = "Parameters:";
            // 
            // configParamsDataGridView
            // 
            this.configParamsDataGridView.AllowUserToAddRows = false;
            this.configParamsDataGridView.AllowUserToDeleteRows = false;
            this.configParamsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configParamsDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.configParamsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.configParamsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.configParamsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.valueColumn,
            this.descriptionColumn});
            this.configParamsDataGridView.DataSource = this.configParamsBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.configParamsDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.configParamsDataGridView.Location = new System.Drawing.Point(26, 50);
            this.configParamsDataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.configParamsDataGridView.Name = "configParamsDataGridView";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.configParamsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.configParamsDataGridView.Size = new System.Drawing.Size(926, 657);
            this.configParamsDataGridView.TabIndex = 1;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "Name";
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.MinimumWidth = 100;
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 220;
            // 
            // valueColumn
            // 
            this.valueColumn.DataPropertyName = "Value";
            this.valueColumn.HeaderText = "Value";
            this.valueColumn.MinimumWidth = 100;
            this.valueColumn.Name = "valueColumn";
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionColumn.DataPropertyName = "Description";
            this.descriptionColumn.HeaderText = "Description";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.ReadOnly = true;
            // 
            // configParamsBindingSource
            // 
            this.configParamsBindingSource.AllowNew = false;
            // 
            // loadConfigurationButton
            // 
            this.loadConfigurationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadConfigurationButton.Location = new System.Drawing.Point(662, 719);
            this.loadConfigurationButton.Margin = new System.Windows.Forms.Padding(6);
            this.loadConfigurationButton.Name = "loadConfigurationButton";
            this.loadConfigurationButton.Size = new System.Drawing.Size(85, 23);
            this.loadConfigurationButton.TabIndex = 2;
            this.loadConfigurationButton.Text = "Load...";
            this.loadConfigurationButton.UseVisualStyleBackColor = true;
            // 
            // saveConfigurationButton
            // 
            this.saveConfigurationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveConfigurationButton.Location = new System.Drawing.Point(759, 719);
            this.saveConfigurationButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveConfigurationButton.Name = "saveConfigurationButton";
            this.saveConfigurationButton.Size = new System.Drawing.Size(84, 23);
            this.saveConfigurationButton.TabIndex = 3;
            this.saveConfigurationButton.Text = "Save...";
            this.saveConfigurationButton.UseVisualStyleBackColor = true;
            // 
            // setToDefaultParamsButton
            // 
            this.setToDefaultParamsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.setToDefaultParamsButton.Location = new System.Drawing.Point(855, 719);
            this.setToDefaultParamsButton.Margin = new System.Windows.Forms.Padding(6);
            this.setToDefaultParamsButton.Name = "setToDefaultParamsButton";
            this.setToDefaultParamsButton.Size = new System.Drawing.Size(97, 23);
            this.setToDefaultParamsButton.TabIndex = 5;
            this.setToDefaultParamsButton.Text = "Set to Default";
            this.setToDefaultParamsButton.UseVisualStyleBackColor = true;
            // 
            // ConfigurationPerspective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.setToDefaultParamsButton);
            this.Controls.Add(this.saveConfigurationButton);
            this.Controls.Add(this.loadConfigurationButton);
            this.Controls.Add(this.configParamsDataGridView);
            this.Controls.Add(this.parametersLabel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ConfigurationPerspective";
            this.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.Size = new System.Drawing.Size(978, 767);
            ((System.ComponentModel.ISupportInitialize)(this.configParamsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configParamsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label parametersLabel;
        private System.Windows.Forms.DataGridView configParamsDataGridView;
        private System.Windows.Forms.Button loadConfigurationButton;
        private System.Windows.Forms.Button saveConfigurationButton;
        private System.Windows.Forms.Button setToDefaultParamsButton;
        private System.Windows.Forms.BindingSource configParamsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
    }
}
