using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using PipBenchmark.Runner.Gui.Initialization;
using PipBenchmark.Runner;

namespace PipBenchmark.Runner.Gui.Initialization
{
    public partial class InitializationPerspective : UserControl, IInitializationView
    {
        public InitializationPerspective()
        {
            InitializeComponent();
        }

        private void OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && SuiteSelectedChanged != null)
                SuiteSelectedChanged(this, EventArgs.Empty);
        }

        #region IInitializationView Members

        public List<BenchmarkSuiteInstance> AllSuites
        {
            get { return suitesBindingSource.DataSource as List<BenchmarkSuiteInstance>; }
            set 
            {
                suitesDataGridView.AutoGenerateColumns = false;
                suitesBindingSource.DataSource = value; 
            }
        }

        public List<BenchmarkSuiteInstance> SelectedSuites
        {
            get 
            {
                List<BenchmarkSuiteInstance> suites = new List<BenchmarkSuiteInstance>();
                foreach (DataGridViewRow row in suitesDataGridView.SelectedRows)
                    suites.Add(row.DataBoundItem as BenchmarkSuiteInstance);

                if (suites.Count == 0 && suitesDataGridView.CurrentCell != null)
                    suites.Add(suitesDataGridView.CurrentCell.OwningRow.DataBoundItem as BenchmarkSuiteInstance);

                return suites;
            }
        }

        public List<BenchmarkInstance> AllBenchmarks
        {
            get { return benchmarksBindingSource.DataSource as List<BenchmarkInstance>; }
            set 
            {
                benchmarksDataGridView.AutoGenerateColumns = false;
                benchmarksBindingSource.DataSource = value; 
            }
        }

        public List<BenchmarkInstance> SelectedBenchmarks
        {
            get
            {
                List<BenchmarkInstance> benchmarks = new List<BenchmarkInstance>();
                foreach (DataGridViewRow row in benchmarksDataGridView.SelectedRows)
                    benchmarks.Add(row.DataBoundItem as BenchmarkInstance);

                if (benchmarks.Count == 0 && benchmarksDataGridView.CurrentCell != null)
                    benchmarks.Add(benchmarksDataGridView.CurrentCell.OwningRow.DataBoundItem as BenchmarkInstance);

                return benchmarks;
            }
        }

        public event EventHandler SuiteSelectedChanged;

        public event EventHandler LoadSuiteClicked
        {
            add { loadSuiteButton.Click += value; }
            remove { loadSuiteButton.Click -= value; }
        }

        public event EventHandler UnloadSuiteClicked
        {
            add { unloadSuiteButton.Click += value; }
            remove { unloadSuiteButton.Click -= value; }
        }

        public event EventHandler UnloadSuitesClicked
        {
            add { unloadAllSuitesButton.Click += value; }
            remove { unloadAllSuitesButton.Click -= value; }
        }

        public event EventHandler SelectBenchmarkClicked
        {
            add { selectBenchmarkButton.Click += value; }
            remove { selectBenchmarkButton.Click -= value; }
        }

        public event EventHandler SelectAllBenchmarksClicked
        {
            add { selectAllBenchmarksButton.Click += value; }
            remove { selectAllBenchmarksButton.Click -= value; }
        }

        public event EventHandler UnselectBenchmarkClicked
        {
            add { unselectBenchmarkButton.Click += value; }
            remove { unselectBenchmarkButton.Click -= value; }
        }

        public event EventHandler UnselectAllBenchmarksClicked
        {
            add { unselectAllBenchmarksButton.Click += value; }
            remove { unselectAllBenchmarksButton.Click -= value; }
        }

        public void RefreshData()
        {
            suitesBindingSource.ResetBindings(false);
            benchmarksBindingSource.ResetBindings(false);
        }

        #endregion

    }
}
