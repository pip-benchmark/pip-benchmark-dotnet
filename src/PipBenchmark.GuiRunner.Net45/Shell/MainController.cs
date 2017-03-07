using PipBenchmark.Gui.About;
using PipBenchmark.Gui.AsyncWait;
using PipBenchmark.Gui.Config;
using PipBenchmark.Gui.Environment;
using PipBenchmark.Gui.Errors;
using PipBenchmark.Gui.Execution;
using PipBenchmark.Gui.Initialization;
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
        private InitializationController _initializationController;
        private ConfigurationController _configurationController;
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
            _view.LoadTestSuiteClicked += OnLoadTestSuitesClicked;
            _view.SaveReportClicked += OnSaveReportClicked;
            _view.PrintReportClicked += OnPrintReportClicked;
            _view.LoadConfigurationClicked += OnLoadConfigurationClicked;
            _view.SaveConfigurationClicked += OnSaveConfigurationClicked;
            _view.StartBenchmarkingClicked += OnStartBenchmarkingClicked;
            _view.StopBenchmarkingClicked += OnStopBenchmarkingClicked;
            _view.UpdateSystemBenchmarkClicked += OnUpdateSystemBenchmarkClicked;
            _view.AboutClicked += OnAboutClicked;
            _view.ExitClicked += OnExitClicked;
            _view.FormExited += OnFormExited;

            _view.ConfigurationViewActivated += OnConfigurationViewActivated;
        }

        private void OnConfigurationViewActivated(object sender, EventArgs eventArgs)
        {
            if (_view.SelectedView.Equals("Configuration", StringComparison.InvariantCultureIgnoreCase))
                _configurationController.UpdateView();
        }

        private void InitializeControllers()
        {
            _initializationController = new InitializationController(this, _view.InitializationView);
            _configurationController = new ConfigurationController(this, _view.ConfigurationView);
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

        public InitializationController InitializationController
        {
            get { return _initializationController; }
        }

        public ConfigurationController ConfigurationController
        {
            get { return _configurationController; }
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

        private void OnLoadTestSuitesClicked(object sender, EventArgs args)
        {
            _view.SelectedView = "Initialization";
            _initializationController.LoadSuitesFromAssembly();
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

        private void OnLoadConfigurationClicked(object sender, EventArgs args)
        {
            _view.SelectedView = "Configuration";
            _configurationController.LoadConfiguration();
        }

        private void OnSaveConfigurationClicked(object sender, EventArgs args)
        {
            _view.SelectedView = "Configuration";
            _configurationController.SaveConfiguration();
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
