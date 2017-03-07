using PipBenchmark.Gui.About;
using PipBenchmark.Gui.AsyncWait;
using PipBenchmark.Gui.Parameters;
using PipBenchmark.Gui.Environment;
using PipBenchmark.Gui.Errors;
using PipBenchmark.Gui.Execution;
using PipBenchmark.Gui.Benchmarks;
using PipBenchmark.Gui.Results;
using PipBenchmark.Runner;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PipBenchmark.Gui.Shell
{
    public class MainController
    {
        private IMainView _view;
        private BenchmarkRunner _model;
        private BenchmarksController _benchmarksController;
        private ParametersController _parametersController;
        private ExecutionController _executionController;
        private ResultsController _resultsController;
        private EnvironmentController _environmentController;
        private AsyncWaitController _asyncWaitController;
        private ErrorHandlingController _errorHandlingController;

        #region Initialization

        public MainController(IMainView view, BenchmarkRunner model)
        {
            _view = view;
            _model = model;

            InitializeView();
            InitializeControllers();
        }

        private void InitializeView()
        {
            _view.LoadSuiteClicked += OnLoadSuitesClicked;
            _view.SaveReportClicked += OnSaveReportClicked;
            _view.PrintReportClicked += OnPrintReportClicked;
            _view.LoadParametersClicked += OnLoadParametersClicked;
            _view.SaveParametersClicked += OnSaveParametersClicked;
            _view.StartBenchmarkingClicked += OnStartBenchmarkingClicked;
            _view.StopBenchmarkingClicked += OnStopBenchmarkingClicked;
            _view.UpdateSystemBenchmarkClicked += OnUpdateSystemBenchmarkClicked;
            _view.AboutClicked += OnAboutClicked;
            _view.ExitClicked += OnExitClicked;
            _view.FormExited += OnFormExited;

            _view.ParametersViewActivated += OnParametersViewActivated;
        }

        private void OnParametersViewActivated(object sender, EventArgs eventArgs)
        {
            if (_view.SelectedView.Equals("Parameters", StringComparison.InvariantCultureIgnoreCase))
                _parametersController.UpdateView();
        }

        private void InitializeControllers()
        {
            _benchmarksController = new BenchmarksController(this, _view.BenchmarksView);
            _parametersController = new ParametersController(this, _view.ParametersView);
            _executionController = new ExecutionController(this, _view.ExecutionView);
            _resultsController = new ResultsController(this, _view.ResultsView);
            _environmentController = new EnvironmentController(this, _view.EnvironmentView);
            _asyncWaitController = new AsyncWaitController(this);
            _errorHandlingController = new ErrorHandlingController(this);
        }

        #endregion

        public IMainView View
        {
            get { return _view; }
        }

        public BenchmarkRunner Model
        {
            get { return _model; }
        }

        #region Child Controllers

        public BenchmarksController BenchmarksController
        {
            get { return _benchmarksController; }
        }

        public ParametersController ParametersController
        {
            get { return _parametersController; }
        }

        public ExecutionController ExecutionController
        {
            get { return _executionController; }
        }

        public ResultsController ResultsController
        {
            get { return _resultsController; }
        }

        public EnvironmentController EnvironmentController
        {
            get { return _environmentController; }
        }

        public AsyncWaitController AsyncWaitController
        {
            get { return _asyncWaitController; }
        }

        public ErrorHandlingController ErrorHandlingController
        {
            get { return _errorHandlingController; }
        }

        #endregion

        #region Event Handlers

        private void OnLoadSuitesClicked(object sender, EventArgs args)
        {
            _view.SelectedView = "Benchmarks";
            _benchmarksController.LoadSuitesFromAssembly();
        }

        private void OnSaveReportClicked(object sender, EventArgs args)
        {
            _view.SelectedView = "Results";
            _resultsController.SaveReport();
        }

        private void OnPrintReportClicked(object sender, EventArgs args)
        {
            _view.SelectedView = "Results";
            _resultsController.PrintReport();
        }

        private void OnLoadParametersClicked(object sender, EventArgs args)
        {
            _view.SelectedView = "Parameters";
            _parametersController.Load();
        }

        private void OnSaveParametersClicked(object sender, EventArgs args)
        {
            _view.SelectedView = "Parameters";
            _parametersController.Save();
        }

        private void OnStartBenchmarkingClicked(object sender, EventArgs args)
        {
            _view.SelectedView = "Execution";
            _executionController.StartBenchmarking();
        }

        private void OnStopBenchmarkingClicked(object sender, EventArgs args)
        {
            _view.SelectedView = "Execution";
            _executionController.StopBenchmarking();
        }

        private void OnUpdateSystemBenchmarkClicked(object sender, EventArgs args)
        {
            _view.SelectedView = "Environment";
            _environmentController.UpdateSystemBenchmark();
        }

        private void OnExitClicked(object sender, EventArgs args)
        {
            CloseApplication();
        }

        private void OnAboutClicked(object sender, EventArgs args)
        {
#if !CompactFramework
            new AboutDialog().ShowDialog(View.Handler);
#else
            new AboutDialog().ShowDialog();
#endif
        }

        private void OnFormExited(object sender, EventArgs args)
        {
            CloseApplication();
        }

        #endregion

        #region Utility Methods

        public void CloseApplication()
        {
            _executionController.StopBenchmarking();
            Application.Exit();
        }

        public void SetStatusMessage(object message)
        {
            if (_view.Handler.InvokeRequired)
            {
                _view.Handler.BeginInvoke(new WaitCallback(SetStatusMessage), message);
            }
            else
            {
                _view.StatusMessage = message != null ? message.ToString() : null;
            }
        }

        #endregion
    }
}
