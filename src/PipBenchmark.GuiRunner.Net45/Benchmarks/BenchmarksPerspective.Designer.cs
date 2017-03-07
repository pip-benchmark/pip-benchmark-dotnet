namespace PipBenchmark.Gui.Benchmarks
{
    partial class BenchmarksPerspective
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
            this.suitSelectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.suiteNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suiteDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suiteAssemblyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suitesLabel = new System.Windows.Forms.Label();
            this.unselectAllBenchmarksButton = new System.Windows.Forms.Button();
            this.unselectBenchmarkButton = new System.Windows.Forms.Button();
            this.selectAllBenchmarksButton = new System.Windows.Forms.Button();
            this.selectBenchmarkButton = new System.Windows.Forms.Button();
            this.benchmarksDataGridView = new System.Windows.Forms.DataGridView();
            this.benchmarksLabel = new System.Windows.Forms.Label();
            this.benchmarkSelectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.benchmarkNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.benchmarkDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.benchmarkProportionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.contentContainer.Margin = new System.Windows.Forms.Padding(6);
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
            this.contentContainer.Panel1.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            // 
            // contentContainer.Panel2
            // 
            this.contentContainer.Panel2.Controls.Add(this.unselectAllBenchmarksButton);
            this.contentContainer.Panel2.Controls.Add(this.unselectBenchmarkButton);
            this.contentContainer.Panel2.Controls.Add(this.selectAllBenchmarksButton);
            this.contentContainer.Panel2.Controls.Add(this.selectBenchmarkButton);
            this.contentContainer.Panel2.Controls.Add(this.benchmarksDataGridView);
            this.contentContainer.Panel2.Controls.Add(this.benchmarksLabel);
            this.contentContainer.Panel2.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.contentContainer.Size = new System.Drawing.Size(1000, 769);
            this.contentContainer.SplitterDistance = 315;
            this.contentContainer.SplitterWidth = 8;
            this.contentContainer.TabIndex = 11;
            // 
            // unloadAllSuitesButton
            // 
            this.unloadAllSuitesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unloadAllSuitesButton.Location = new System.Drawing.Point(824, 260);
            this.unloadAllSuitesButton.Margin = new System.Windows.Forms.Padding(6);
            this.unloadAllSuitesButton.Name = "unloadAllSuitesButton";
            this.unloadAllSuitesButton.Size = new System.Drawing.Size(150, 44);
            this.unloadAllSuitesButton.TabIndex = 9;
            this.unloadAllSuitesButton.Text = "UnloadAll";
            this.unloadAllSuitesButton.UseVisualStyleBackColor = true;
            // 
            // unloadSuiteButton
            // 
            this.unloadSuiteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unloadSuiteButton.Location = new System.Drawing.Point(662, 260);
            this.unloadSuiteButton.Margin = new System.Windows.Forms.Padding(6);
            this.unloadSuiteButton.Name = "unloadSuiteButton";
            this.unloadSuiteButton.Size = new System.Drawing.Size(150, 44);
            this.unloadSuiteButton.TabIndex = 8;
            this.unloadSuiteButton.Text = "Unload";
            this.unloadSuiteButton.UseVisualStyleBackColor = true;
            // 
            // loadSuiteButton
            // 
            this.loadSuiteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadSuiteButton.Location = new System.Drawing.Point(500, 260);
            this.loadSuiteButton.Margin = new System.Windows.Forms.Padding(6);
            this.loadSuiteButton.Name = "loadSuiteButton";
            this.loadSuiteButton.Size = new System.Drawing.Size(150, 44);
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
            this.suitSelectedColumn,
            this.suiteNameColumn,
            this.suiteDescriptionColumn,
            this.suiteAssemblyColumn});
            this.suitesDataGridView.DataSource = this.suitesBindingSource;
            this.suitesDataGridView.Location = new System.Drawing.Point(26, 50);
            this.suitesDataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.suitesDataGridView.Name = "suitesDataGridView";
            this.suitesDataGridView.RowHeadersVisible = false;
            this.suitesDataGridView.Size = new System.Drawing.Size(948, 198);
            this.suitesDataGridView.TabIndex = 6;
            this.suitesDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellValueChanged);
            // 
            // suitSelectedColumn
            // 
            this.suitSelectedColumn.DataPropertyName = "IsSelected";
            this.suitSelectedColumn.HeaderText = "";
            this.suitSelectedColumn.MinimumWidth = 20;
            this.suitSelectedColumn.Name = "suitSelectedColumn";
            this.suitSelectedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.suitSelectedColumn.Width = 20;
            // 
            // suiteNameColumn
            // 
            this.suiteNameColumn.DataPropertyName = "Name";
            this.suiteNameColumn.HeaderText = "Name";
            this.suiteNameColumn.MinimumWidth = 100;
            this.suiteNameColumn.Name = "suiteNameColumn";
            this.suiteNameColumn.ReadOnly = true;
            this.suiteNameColumn.Width = 150;
            // 
            // suiteDescriptionColumn
            // 
            this.suiteDescriptionColumn.DataPropertyName = "Description";
            this.suiteDescriptionColumn.HeaderText = "Description";
            this.suiteDescriptionColumn.MinimumWidth = 150;
            this.suiteDescriptionColumn.Name = "suiteDescriptionColumn";
            this.suiteDescriptionColumn.ReadOnly = true;
            this.suiteDescriptionColumn.Width = 200;
            // 
            // suiteAssemblyColumn
            // 
            this.suiteAssemblyColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.suiteAssemblyColumn.DataPropertyName = "Assembly";
            this.suiteAssemblyColumn.HeaderText = "Assembly";
            this.suiteAssemblyColumn.Name = "suiteAssemblyColumn";
            this.suiteAssemblyColumn.ReadOnly = true;
            // 
            // suitesLabel
            // 
            this.suitesLabel.AutoSize = true;
            this.suitesLabel.Location = new System.Drawing.Point(26, 19);
            this.suitesLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.suitesLabel.Name = "suitesLabel";
            this.suitesLabel.Size = new System.Drawing.Size(192, 25);
            this.suitesLabel.TabIndex = 5;
            this.suitesLabel.Text = "Benchmark Suites:";
            // 
            // unselectAllBenchmarksButton
            // 
            this.unselectAllBenchmarksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unselectAllBenchmarksButton.Location = new System.Drawing.Point(824, 353);
            this.unselectAllBenchmarksButton.Margin = new System.Windows.Forms.Padding(6);
            this.unselectAllBenchmarksButton.Name = "unselectAllBenchmarksButton";
            this.unselectAllBenchmarksButton.Size = new System.Drawing.Size(150, 44);
            this.unselectAllBenchmarksButton.TabIndex = 16;
            this.unselectAllBenchmarksButton.Text = "Unselect All";
            this.unselectAllBenchmarksButton.UseVisualStyleBackColor = true;
            // 
            // unselectBenchmarkButton
            // 
            this.unselectBenchmarkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unselectBenchmarkButton.Location = new System.Drawing.Point(662, 353);
            this.unselectBenchmarkButton.Margin = new System.Windows.Forms.Padding(6);
            this.unselectBenchmarkButton.Name = "unselectBenchmarkButton";
            this.unselectBenchmarkButton.Size = new System.Drawing.Size(150, 44);
            this.unselectBenchmarkButton.TabIndex = 15;
            this.unselectBenchmarkButton.Text = "Unselect";
            this.unselectBenchmarkButton.UseVisualStyleBackColor = true;
            // 
            // selectAllBenchmarksButton
            // 
            this.selectAllBenchmarksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllBenchmarksButton.Location = new System.Drawing.Point(500, 353);
            this.selectAllBenchmarksButton.Margin = new System.Windows.Forms.Padding(6);
            this.selectAllBenchmarksButton.Name = "selectAllBenchmarksButton";
            this.selectAllBenchmarksButton.Size = new System.Drawing.Size(150, 44);
            this.selectAllBenchmarksButton.TabIndex = 14;
            this.selectAllBenchmarksButton.Text = "Select All";
            this.selectAllBenchmarksButton.UseVisualStyleBackColor = true;
            // 
            // selectBenchmarkButton
            // 
            this.selectBenchmarkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectBenchmarkButton.Location = new System.Drawing.Point(338, 353);
            this.selectBenchmarkButton.Margin = new System.Windows.Forms.Padding(6);
            this.selectBenchmarkButton.Name = "selectBenchmarkButton";
            this.selectBenchmarkButton.Size = new System.Drawing.Size(150, 44);
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
            this.benchmarkSelectedColumn,
            this.benchmarkNameColumn,
            this.benchmarkDescriptionColumn,
            this.benchmarkProportionColumn});
            this.benchmarksDataGridView.DataSource = this.benchmarksBindingSource;
            this.benchmarksDataGridView.Location = new System.Drawing.Point(26, 38);
            this.benchmarksDataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.benchmarksDataGridView.Name = "benchmarksDataGridView";
            this.benchmarksDataGridView.RowHeadersVisible = false;
            this.benchmarksDataGridView.Size = new System.Drawing.Size(948, 303);
            this.benchmarksDataGridView.TabIndex = 12;
            // 
            // benchmarksLabel
            // 
            this.benchmarksLabel.AutoSize = true;
            this.benchmarksLabel.Location = new System.Drawing.Point(26, 8);
            this.benchmarksLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.benchmarksLabel.Name = "benchmarksLabel";
            this.benchmarksLabel.Size = new System.Drawing.Size(137, 25);
            this.benchmarksLabel.TabIndex = 11;
            this.benchmarksLabel.Text = "Benchmarks:";
            // 
            // benchmarkSelectedColumn
            // 
            this.benchmarkSelectedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.benchmarkSelectedColumn.DataPropertyName = "IsSelected";
            this.benchmarkSelectedColumn.HeaderText = "";
            this.benchmarkSelectedColumn.MinimumWidth = 20;
            this.benchmarkSelectedColumn.Name = "benchmarkSelectedColumn";
            this.benchmarkSelectedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.benchmarkSelectedColumn.Width = 20;
            // 
            // benchmarkNameColumn
            // 
            this.benchmarkNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.benchmarkNameColumn.DataPropertyName = "FullName";
            this.benchmarkNameColumn.HeaderText = "Name";
            this.benchmarkNameColumn.MinimumWidth = 100;
            this.benchmarkNameColumn.Name = "benchmarkNameColumn";
            this.benchmarkNameColumn.ReadOnly = true;
            this.benchmarkNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // benchmarkDescriptionColumn
            // 
            this.benchmarkDescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.benchmarkDescriptionColumn.DataPropertyName = "Description";
            this.benchmarkDescriptionColumn.HeaderText = "Description";
            this.benchmarkDescriptionColumn.MinimumWidth = 150;
            this.benchmarkDescriptionColumn.Name = "benchmarkDescriptionColumn";
            this.benchmarkDescriptionColumn.ReadOnly = true;
            this.benchmarkDescriptionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.benchmarkDescriptionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // benchmarkProportionColumn
            // 
            this.benchmarkProportionColumn.DataPropertyName = "Proportion";
            this.benchmarkProportionColumn.HeaderText = "Proportion %";
            this.benchmarkProportionColumn.MinimumWidth = 150;
            this.benchmarkProportionColumn.Name = "benchmarkProportionColumn";
            this.benchmarkProportionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.benchmarkProportionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.benchmarkProportionColumn.Width = 150;
            // 
            // BenchmarksPerspective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentContainer);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BenchmarksPerspective";
            this.Size = new System.Drawing.Size(1000, 769);
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn suitSelectedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suiteNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suiteDescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suiteAssemblyColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn benchmarkSelectedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn benchmarkNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn benchmarkDescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn benchmarkProportionColumn;
    }
}
