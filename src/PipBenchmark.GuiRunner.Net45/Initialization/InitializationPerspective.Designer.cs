namespace PipBenchmark.Gui.Initialization
{
    partial class InitializationPerspective
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
            this.suitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.benchmarksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contentContainer = new System.Windows.Forms.SplitContainer();
            this.unloadAllSuitesButton = new System.Windows.Forms.Button();
            this.unloadSuiteButton = new System.Windows.Forms.Button();
            this.loadSuiteButton = new System.Windows.Forms.Button();
            this.suitesDataGridView = new System.Windows.Forms.DataGridView();
            this.enabledColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.testSuiteNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testSuiteDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testSuiteAssemblyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suitesLabel = new System.Windows.Forms.Label();
            this.unselectAllBenchmarksButton = new System.Windows.Forms.Button();
            this.unselectBenchmarkButton = new System.Windows.Forms.Button();
            this.selectAllBenchmarksButton = new System.Windows.Forms.Button();
            this.selectBenchmarkButton = new System.Windows.Forms.Button();
            this.benchmarksDataGridView = new System.Windows.Forms.DataGridView();
            this.benchmarksLabel = new System.Windows.Forms.Label();
            this.testEnabledColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.testNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testProportionColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.suitesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.benchmarksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentContainer)).BeginInit();
            this.contentContainer.Panel1.SuspendLayout();
            this.contentContainer.Panel2.SuspendLayout();
            this.contentContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suitesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.benchmarksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // suitesBindingSource
            // 
            this.suitesBindingSource.AllowNew = false;
            // 
            // benchmarksBindingSource
            // 
            this.benchmarksBindingSource.AllowNew = false;
            // 
            // contentContainer
            // 
            this.contentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentContainer.Location = new System.Drawing.Point(0, 0);
            this.contentContainer.Name = "contentContainer";
            this.contentContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // contentContainer.Panel1
            // 
            this.contentContainer.Panel1.Controls.Add(this.unloadAllSuitesButton);
            this.contentContainer.Panel1.Controls.Add(this.unloadSuiteButton);
            this.contentContainer.Panel1.Controls.Add(this.loadSuiteButton);
            this.contentContainer.Panel1.Controls.Add(this.suitesDataGridView);
            this.contentContainer.Panel1.Controls.Add(this.suitesLabel);
            this.contentContainer.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // contentContainer.Panel2
            // 
            this.contentContainer.Panel2.Controls.Add(this.unselectAllBenchmarksButton);
            this.contentContainer.Panel2.Controls.Add(this.unselectBenchmarkButton);
            this.contentContainer.Panel2.Controls.Add(this.selectAllBenchmarksButton);
            this.contentContainer.Panel2.Controls.Add(this.selectBenchmarkButton);
            this.contentContainer.Panel2.Controls.Add(this.benchmarksDataGridView);
            this.contentContainer.Panel2.Controls.Add(this.benchmarksLabel);
            this.contentContainer.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.contentContainer.Size = new System.Drawing.Size(500, 400);
            this.contentContainer.SplitterDistance = 164;
            this.contentContainer.TabIndex = 11;
            // 
            // unloadAllSuitesButton
            // 
            this.unloadAllSuitesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unloadAllSuitesButton.Location = new System.Drawing.Point(412, 135);
            this.unloadAllSuitesButton.Name = "unloadAllSuitesButton";
            this.unloadAllSuitesButton.Size = new System.Drawing.Size(75, 23);
            this.unloadAllSuitesButton.TabIndex = 9;
            this.unloadAllSuitesButton.Text = "UnloadAll";
            this.unloadAllSuitesButton.UseVisualStyleBackColor = true;
            // 
            // unloadSuiteButton
            // 
            this.unloadSuiteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unloadSuiteButton.Location = new System.Drawing.Point(331, 135);
            this.unloadSuiteButton.Name = "unloadSuiteButton";
            this.unloadSuiteButton.Size = new System.Drawing.Size(75, 23);
            this.unloadSuiteButton.TabIndex = 8;
            this.unloadSuiteButton.Text = "Unload";
            this.unloadSuiteButton.UseVisualStyleBackColor = true;
            // 
            // loadSuiteButton
            // 
            this.loadSuiteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadSuiteButton.Location = new System.Drawing.Point(250, 135);
            this.loadSuiteButton.Name = "loadSuiteButton";
            this.loadSuiteButton.Size = new System.Drawing.Size(75, 23);
            this.loadSuiteButton.TabIndex = 7;
            this.loadSuiteButton.Text = "Load...";
            this.loadSuiteButton.UseVisualStyleBackColor = true;
            // 
            // suitesDataGridView
            // 
            this.suitesDataGridView.AllowUserToAddRows = false;
            this.suitesDataGridView.AllowUserToDeleteRows = false;
            this.suitesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suitesDataGridView.AutoGenerateColumns = false;
            this.suitesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suitesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enabledColumn,
            this.testSuiteNameColumn,
            this.testSuiteDescriptionColumn,
            this.testSuiteAssemblyColumn});
            this.suitesDataGridView.DataSource = this.suitesBindingSource;
            this.suitesDataGridView.Location = new System.Drawing.Point(13, 26);
            this.suitesDataGridView.Name = "suitesDataGridView";
            this.suitesDataGridView.RowHeadersVisible = false;
            this.suitesDataGridView.Size = new System.Drawing.Size(474, 103);
            this.suitesDataGridView.TabIndex = 6;
            this.suitesDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellValueChanged);
            // 
            // enabledColumn
            // 
            this.enabledColumn.DataPropertyName = "Enabled";
            this.enabledColumn.HeaderText = "";
            this.enabledColumn.MinimumWidth = 20;
            this.enabledColumn.Name = "enabledColumn";
            this.enabledColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.enabledColumn.Width = 20;
            // 
            // testSuiteNameColumn
            // 
            this.testSuiteNameColumn.DataPropertyName = "Name";
            this.testSuiteNameColumn.HeaderText = "Name";
            this.testSuiteNameColumn.MinimumWidth = 100;
            this.testSuiteNameColumn.Name = "testSuiteNameColumn";
            this.testSuiteNameColumn.ReadOnly = true;
            this.testSuiteNameColumn.Width = 150;
            // 
            // testSuiteDescriptionColumn
            // 
            this.testSuiteDescriptionColumn.DataPropertyName = "Description";
            this.testSuiteDescriptionColumn.HeaderText = "Description";
            this.testSuiteDescriptionColumn.MinimumWidth = 150;
            this.testSuiteDescriptionColumn.Name = "testSuiteDescriptionColumn";
            this.testSuiteDescriptionColumn.ReadOnly = true;
            this.testSuiteDescriptionColumn.Width = 200;
            // 
            // testSuiteAssemblyColumn
            // 
            this.testSuiteAssemblyColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.testSuiteAssemblyColumn.DataPropertyName = "Assembly";
            this.testSuiteAssemblyColumn.HeaderText = "Assembly";
            this.testSuiteAssemblyColumn.Name = "testSuiteAssemblyColumn";
            this.testSuiteAssemblyColumn.ReadOnly = true;
            // 
            // suitesLabel
            // 
            this.suitesLabel.AutoSize = true;
            this.suitesLabel.Location = new System.Drawing.Point(13, 10);
            this.suitesLabel.Name = "suitesLabel";
            this.suitesLabel.Size = new System.Drawing.Size(96, 13);
            this.suitesLabel.TabIndex = 5;
            this.suitesLabel.Text = "Benchmark Suites:";
            // 
            // unselectAllBenchmarksButton
            // 
            this.unselectAllBenchmarksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unselectAllBenchmarksButton.Location = new System.Drawing.Point(412, 190);
            this.unselectAllBenchmarksButton.Name = "unselectAllBenchmarksButton";
            this.unselectAllBenchmarksButton.Size = new System.Drawing.Size(75, 23);
            this.unselectAllBenchmarksButton.TabIndex = 16;
            this.unselectAllBenchmarksButton.Text = "Unselect All";
            this.unselectAllBenchmarksButton.UseVisualStyleBackColor = true;
            // 
            // unselectBenchmarkButton
            // 
            this.unselectBenchmarkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unselectBenchmarkButton.Location = new System.Drawing.Point(331, 190);
            this.unselectBenchmarkButton.Name = "unselectBenchmarkButton";
            this.unselectBenchmarkButton.Size = new System.Drawing.Size(75, 23);
            this.unselectBenchmarkButton.TabIndex = 15;
            this.unselectBenchmarkButton.Text = "Unselect";
            this.unselectBenchmarkButton.UseVisualStyleBackColor = true;
            // 
            // selectAllBenchmarksButton
            // 
            this.selectAllBenchmarksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllBenchmarksButton.Location = new System.Drawing.Point(250, 190);
            this.selectAllBenchmarksButton.Name = "selectAllBenchmarksButton";
            this.selectAllBenchmarksButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllBenchmarksButton.TabIndex = 14;
            this.selectAllBenchmarksButton.Text = "Select All";
            this.selectAllBenchmarksButton.UseVisualStyleBackColor = true;
            // 
            // selectBenchmarkButton
            // 
            this.selectBenchmarkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectBenchmarkButton.Location = new System.Drawing.Point(169, 190);
            this.selectBenchmarkButton.Name = "selectBenchmarkButton";
            this.selectBenchmarkButton.Size = new System.Drawing.Size(75, 23);
            this.selectBenchmarkButton.TabIndex = 13;
            this.selectBenchmarkButton.Text = "Select";
            this.selectBenchmarkButton.UseVisualStyleBackColor = true;
            // 
            // benchmarksDataGridView
            // 
            this.benchmarksDataGridView.AllowUserToAddRows = false;
            this.benchmarksDataGridView.AllowUserToDeleteRows = false;
            this.benchmarksDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.benchmarksDataGridView.AutoGenerateColumns = false;
            this.benchmarksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.benchmarksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.testEnabledColumn,
            this.testNameColumn,
            this.testDescriptionColumn,
            this.testProportionColumn1});
            this.benchmarksDataGridView.DataSource = this.benchmarksBindingSource;
            this.benchmarksDataGridView.Location = new System.Drawing.Point(13, 20);
            this.benchmarksDataGridView.Name = "benchmarksDataGridView";
            this.benchmarksDataGridView.RowHeadersVisible = false;
            this.benchmarksDataGridView.Size = new System.Drawing.Size(474, 164);
            this.benchmarksDataGridView.TabIndex = 12;
            // 
            // benchmarksLabel
            // 
            this.benchmarksLabel.AutoSize = true;
            this.benchmarksLabel.Location = new System.Drawing.Point(13, 4);
            this.benchmarksLabel.Name = "benchmarksLabel";
            this.benchmarksLabel.Size = new System.Drawing.Size(69, 13);
            this.benchmarksLabel.TabIndex = 11;
            this.benchmarksLabel.Text = "Benchmarks:";
            // 
            // testEnabledColumn
            // 
            this.testEnabledColumn.DataPropertyName = "IsSelected";
            this.testEnabledColumn.HeaderText = "";
            this.testEnabledColumn.MinimumWidth = 20;
            this.testEnabledColumn.Name = "testEnabledColumn";
            this.testEnabledColumn.Width = 20;
            // 
            // testNameColumn
            // 
            this.testNameColumn.DataPropertyName = "FullName";
            this.testNameColumn.HeaderText = "Name";
            this.testNameColumn.MinimumWidth = 100;
            this.testNameColumn.Name = "testNameColumn";
            this.testNameColumn.ReadOnly = true;
            this.testNameColumn.Width = 150;
            // 
            // testDescriptionColumn
            // 
            this.testDescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.testDescriptionColumn.DataPropertyName = "Description";
            this.testDescriptionColumn.HeaderText = "Description";
            this.testDescriptionColumn.MinimumWidth = 150;
            this.testDescriptionColumn.Name = "testDescriptionColumn";
            this.testDescriptionColumn.ReadOnly = true;
            // 
            // testProportionColumn1
            // 
            this.testProportionColumn1.DataPropertyName = "Proportion";
            this.testProportionColumn1.HeaderText = "Proportion (%)";
            this.testProportionColumn1.MinimumWidth = 100;
            this.testProportionColumn1.Name = "testProportionColumn1";
            // 
            // InitializationPerspective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentContainer);
            this.Name = "InitializationPerspective";
            this.Size = new System.Drawing.Size(500, 400);
            ((System.ComponentModel.ISupportInitialize)(this.suitesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.benchmarksBindingSource)).EndInit();
            this.contentContainer.Panel1.ResumeLayout(false);
            this.contentContainer.Panel1.PerformLayout();
            this.contentContainer.Panel2.ResumeLayout(false);
            this.contentContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentContainer)).EndInit();
            this.contentContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.suitesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.benchmarksDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource suitesBindingSource;
        private System.Windows.Forms.BindingSource benchmarksBindingSource;
        private System.Windows.Forms.SplitContainer contentContainer;
        private System.Windows.Forms.Button unloadAllSuitesButton;
        private System.Windows.Forms.Button unloadSuiteButton;
        private System.Windows.Forms.Button loadSuiteButton;
        private System.Windows.Forms.DataGridView suitesDataGridView;
        private System.Windows.Forms.Label suitesLabel;
        private System.Windows.Forms.Button unselectAllBenchmarksButton;
        private System.Windows.Forms.Button unselectBenchmarkButton;
        private System.Windows.Forms.Button selectAllBenchmarksButton;
        private System.Windows.Forms.Button selectBenchmarkButton;
        private System.Windows.Forms.DataGridView benchmarksDataGridView;
        private System.Windows.Forms.Label benchmarksLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn testProportionColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testSuiteNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testSuiteDescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testSuiteAssemblyColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn testEnabledColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testDescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testProportionColumn1;
    }
}
