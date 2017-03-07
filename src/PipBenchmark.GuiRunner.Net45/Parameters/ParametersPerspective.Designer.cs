namespace PipBenchmark.Gui.Parameters
{
    partial class ParametersPerspective
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
            this.paramsDataGridView = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paramsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.setToDefaultButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.paramsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramsBindingSource)).BeginInit();
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
            // paramsDataGridView
            // 
            this.paramsDataGridView.AllowUserToAddRows = false;
            this.paramsDataGridView.AllowUserToDeleteRows = false;
            this.paramsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paramsDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.paramsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.paramsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paramsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.valueColumn,
            this.descriptionColumn});
            this.paramsDataGridView.DataSource = this.paramsBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.paramsDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.paramsDataGridView.Location = new System.Drawing.Point(26, 50);
            this.paramsDataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.paramsDataGridView.Name = "paramsDataGridView";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.paramsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.paramsDataGridView.Size = new System.Drawing.Size(926, 657);
            this.paramsDataGridView.TabIndex = 1;
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
            // paramsBindingSource
            // 
            this.paramsBindingSource.AllowNew = false;
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Location = new System.Drawing.Point(662, 719);
            this.loadButton.Margin = new System.Windows.Forms.Padding(6);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(85, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load...";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(759, 719);
            this.saveButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(84, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save...";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // setToDefaultParamsButton
            // 
            this.setToDefaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.setToDefaultButton.Location = new System.Drawing.Point(855, 719);
            this.setToDefaultButton.Margin = new System.Windows.Forms.Padding(6);
            this.setToDefaultButton.Name = "setToDefaultParamsButton";
            this.setToDefaultButton.Size = new System.Drawing.Size(97, 23);
            this.setToDefaultButton.TabIndex = 5;
            this.setToDefaultButton.Text = "Set to Default";
            this.setToDefaultButton.UseVisualStyleBackColor = true;
            // 
            // ParametersPerspective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.setToDefaultButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.paramsDataGridView);
            this.Controls.Add(this.parametersLabel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ParametersPerspective";
            this.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.Size = new System.Drawing.Size(978, 767);
            ((System.ComponentModel.ISupportInitialize)(this.paramsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label parametersLabel;
        private System.Windows.Forms.DataGridView paramsDataGridView;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button setToDefaultButton;
        private System.Windows.Forms.BindingSource paramsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
    }
}
