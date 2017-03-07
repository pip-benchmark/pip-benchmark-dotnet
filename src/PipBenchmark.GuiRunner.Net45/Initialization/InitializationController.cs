using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using PipBenchmark.Gui.Shell;
using PipBenchmark.Runner;
using PipBenchmark.Runner.Benchmarks;

#if PocketPC
using OpenFileDialog = PipBenchmark.Gui.OpenFileDialog.OpenFileDialog;
#endif

namespace PipBenchmark.Gui.Initialization
{
    public class InitializationController : AbstractChildController
    {
        private IInitializationView _view;
        private BenchmarkRunner _model;
        private OpenFileDialog _loadSuiteDialog;

        public InitializationController(MainController mainController, IInitializationView view)
            : base(mainController)
        {
            _view = view;

            _model = mainController.Model;

            InitializeView();
            UpdateView();
            InitializeDialogs();
        }

        private void InitializeDialogs()
        {
            _loadSuiteDialog = new OpenFileDialog();
#if !CompactFramework
            _loadSuiteDialog.Filter = ".NET Assemblies|*.dll|All Files|*.*";
            _loadSuiteDialog.Title = "Load Suite From Assembly";
            _loadSuiteDialog.DefaultExt = "dll";
#else
#if WindowsCE
            _loadTestSuiteDialog.Filter = ".NET Assemblies|*.dll|All Files|*.*";
#else
            _loadTestSuiteDialog.ShowDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));
#endif
#endif
        }

        private void InitializeView()
        {
            _view.LoadSuiteClicked += OnLoadSuiteClicked;
            _view.UnloadSuiteClicked += OnUnloadSuiteClicked;
            _view.UnloadSuitesClicked += OnUnloadAllSuitesClicked;
            _view.SelectBenchmarkClicked += OnSelectBenchmarkClicked;
            _view.SelectAllBenchmarksClicked += OnSelectAllBenchmarksClicked;
            _view.UnselectBenchmarkClicked += OnUnselectBenchmarkClicked;
            _view.UnselectAllBenchmarksClicked += OnUnselectAllBenchmarksClicked;
            _view.SuiteSelectedChanged += OnSuiteSelectedChanged;
        }

        public void UpdateView()
        {
            _view.AllSuites = _model.Suites;
            _view.AllBenchmarks = GetAllBenchmarks();
            _view.RefreshData();
        }

        private List<BenchmarkInstance> GetAllBenchmarks()
        {
            List<BenchmarkInstance> benchmarks = new List<BenchmarkInstance>();
            foreach (BenchmarkSuiteInstance suite in _model.Suites)
            {
                foreach (BenchmarkInstance benchmark in suite.Benchmarks)
                    benchmarks.Add(benchmark);
            }
            return benchmarks;
        }

        public void LoadSuitesFromAssembly()
        {
            if (_loadSuiteDialog.ShowDialog() == DialogResult.OK)
            {
                int numberOfSuites = _model.Suites.Count;
                _model.Benchmarks.AddSuitesFromAssembly(_loadSuiteDialog.FileName);
                UpdateView();

                if (numberOfSuites < _model.Suites.Count)
                {
                    MainController.SetStatusMessage(string.Format("Loaded suites from {0}",
                        _loadSuiteDialog.FileName));
                }
                else
                {
                    MainController.SetStatusMessage("No suites were founded to load");
                }
            }
        }

        public void UnloadAllAssemblies()
        {
            _model.Benchmarks.Clear();
            UpdateView();

            MainController.SetStatusMessage("Unloaded all suites");
        }

        private void OnLoadSuiteClicked(object sender, EventArgs args)
        {
            LoadSuitesFromAssembly();
        }

        private void OnUnloadSuiteClicked(object sender, EventArgs args)
        {
            int numberOfSuites = _model.Suites.Count;
            foreach (BenchmarkSuiteInstance suite in _view.SelectedSuites)
            {
                _model.Benchmarks.RemoveSuiteByName(suite.Name);
            }
            UpdateView();

            if (numberOfSuites > _model.Suites.Count)
            {
                MainController.SetStatusMessage("Unloaded specified suites");
            }
            else
            {
                MainController.SetStatusMessage("No suites were unloaded");
            }
        }

        private void OnUnloadAllSuitesClicked(object sender, EventArgs args)
        {
            UnloadAllAssemblies();
        }

        private void OnSelectBenchmarkClicked(object sender, EventArgs args)
        {
            foreach (BenchmarkInstance benchmark in _view.SelectedBenchmarks)
            {
                benchmark.Selected = true;
            }
            _view.RefreshData();
        }

        private void OnSelectAllBenchmarksClicked(object sender, EventArgs args)
        {
            foreach (BenchmarkInstance benchmark in _view.AllBenchmarks)
            {
                benchmark.Selected = true;
            }
            _view.RefreshData();
        }

        private void OnUnselectBenchmarkClicked(object sender, EventArgs args)
        {
            foreach (BenchmarkInstance benchmark in _view.SelectedBenchmarks)
            {
                benchmark.Selected = false;
            }
            _view.RefreshData();
        }

        private void OnUnselectAllBenchmarksClicked(object sender, EventArgs args)
        {
            foreach (BenchmarkInstance benchmark in _view.AllBenchmarks)
            {
                benchmark.Selected = false;
            }
            _view.RefreshData();
        }

        private void OnSuiteSelectedChanged(object sender, EventArgs args)
        {
            _view.AllBenchmarks = GetAllBenchmarks();
        }
    }
}
