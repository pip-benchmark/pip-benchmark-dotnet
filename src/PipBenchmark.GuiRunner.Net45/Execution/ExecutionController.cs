using PipBenchmark.Runner.Gui.Shell;
using System;
using System.Collections.Generic;

namespace PipBenchmark.Runner.Gui.Execution
{
    public class ExecutionController : AbstractChildController
    {
        private bool _updatingView = false;
        private IExecutionView _view;
        private BenchmarkRunner _model;
        private IDictionary<string, ExecutionResult> _results = new Dictionary<string, ExecutionResult>();

        public ExecutionController(MainController mainController, IExecutionView view)
            : base(mainController)
        {
            _view = view;
            _view.BenchmarkActionClicked += OnBenchmarkActionClicked;
            _view.DataUpdated += OnDataUpdated;
            _view.BenchmarkActionButton = "Start";
            _view.PerformanceChartName = "Performance Chart (tps)";

            _model = mainController.Model;
            _model.ErrorReported += OnMessageReceived;
            _model.MessageSent += OnMessageReceived;
            _model.ResultUpdated += OnBenchmarkUpdate;

            UpdateView();
        }

        public void UpdateView()
        {
            _updatingView = true;
            try
            {
                _view.NumberOfThreads = _model.NumberOfThreads;
                _view.MeasurementType = _model.MeasurementType;
                _view.NominalRate = _model.NominalRate;
                _view.ExecutionType = _model.ExecutionType;
                _view.Duration = _model.Duration / 1000;
            }
            finally
            {
                _updatingView = false;
            }
        }

        public void StartBenchmarking()
        {
            if (!_model.IsRunning)
            {
                MainController.SetStatusMessage("Benchmarking...");

                _results.Clear();

                _model.NumberOfThreads = _view.NumberOfThreads;
                _model.MeasurementType = _view.MeasurementType;
                _model.NominalRate = _view.NominalRate;
                _model.ExecutionType = _view.ExecutionType;
                _model.Duration = _view.Duration * 1000;

                try
                {
                    _model.Start();

                    _view.BenchmarkActionButton = "Stop";
                    _view.ShowPerformanceChart = _model.ExecutionType == ExecutionType.Proportional;
                    _view.ExecutionResults = new List<ExecutionResult>(_results.Values);
                }
                catch (Exception ex)
                {
                    MainController.ErrorHandlingController.ShowErrorDialog("Start Benchmarking",
                        "Benchmarking process failed", ex);
                }                
            }
        }

        public void StopBenchmarking()
        {
            if (_model.IsRunning)
            {
                //MainController.SetStatusMessage("Benchmarking completed.");

                _model.Stop();
                
                //_view.BenchmarkActionButton = "Start";
                //MainController.ResultsController.GenerateReport();
                //MainController.View.SelectedView = "Results";
            }
        }

        private void OnBenchmarkActionClicked(object sender, EventArgs args)
        {
            if (_model.IsRunning)
            {
                StopBenchmarking();
            }
            else
            {
                StartBenchmarking();
            }
        }

        private void OnDataUpdated(object sender, EventArgs args)
        {
            if (_model.IsRunning)
            {
                MainController.SetStatusMessage("Benchmarking completed.");
                _model.Stop();
                _view.BenchmarkActionButton = "Start";
                MainController.ResultsController.GenerateReport();
            }

            if (!_updatingView)
            {
                _model.NumberOfThreads = _view.NumberOfThreads;
                _model.MeasurementType = _view.MeasurementType;
                _model.NominalRate = _view.NominalRate;
                _model.ExecutionType = _view.ExecutionType;
                _model.Duration = _view.Duration;
            }
        }

        private void OnMessageReceived(object sender, MessageEventArgs e)
        {
            MainController.SetStatusMessage(e.Message);
        }

        private void OnBenchmarkUpdate(object sender, ResultUpdatedEventArgs args)
        {
            if (MainController.View.Handler.InvokeRequired)
            {
                MainController.View.Handler.BeginInvoke(
                    new EventHandler<ResultUpdatedEventArgs>(OnBenchmarkUpdate),
                    sender, args);
            }
            else
            {
                if (args.Result != null)
                {
                    _view.StartTime = args.Result.StartTime.ToLongTimeString();
                    _view.ElapsedTime = args.Result.ElapsedTime.ToString();
                    _view.EndTime = args.Result.StartTime.Add(args.Result.ElapsedTime).ToLongTimeString();
                    _view.MinPerformance = args.Result.PerformanceMeasurement.MinValue.ToString("0.##");
                    _view.AveragePerformance = args.Result.PerformanceMeasurement.AverageValue.ToString("0.##");
                    _view.MaxPerformance = args.Result.PerformanceMeasurement.MaxValue.ToString("0.##");
                    _view.MinCpuLoad = args.Result.CpuLoadMeasurement.MinValue.ToString("0.##");
                    _view.AverageCpuLoad = args.Result.CpuLoadMeasurement.AverageValue.ToString("0.##");
                    _view.MaxCpuLoad = args.Result.CpuLoadMeasurement.MaxValue.ToString("0.##");
                    _view.MinMemoryUsage = args.Result.MemoryUsageMeasurement.MinValue.ToString("0.##");
                    _view.AverageMemoryUsage = args.Result.MemoryUsageMeasurement.AverageValue.ToString("0.##");
                    _view.MaxMemoryUsage = args.Result.MemoryUsageMeasurement.MaxValue.ToString("0.##");

                    string resultName = args.Result.Benchmarks.Count != 1 ? "All" : args.Result.Benchmarks[0].FullName;
                    ExecutionResult result;
                    if (_results.TryGetValue(resultName, out result))
                    {
                        result.Update(args.Result);
                    }
                    else
                    {
                        result = new ExecutionResult(args.Result);
                        _results.Add(resultName, result);
                    }
                    _view.ExecutionResults = new List<ExecutionResult>(_results.Values);
                }

                if (_model.MeasurementType == MeasurementType.Peak)
                {
                    _view.PerformanceChartName = "Performance Chart (tps)";
                }
                else
                {
                    _view.PerformanceChartName = "Cpu Load Chart (%)";
                }

                if (args.State == ExecutionState.Starting)
                {
                    _view.ClearPerformancePoints();
                }
                else if (args.State == ExecutionState.Running)
                {
                    if (args.Result != null)
                    {
                        _view.AddCurrentPerformancePoint(_model.MeasurementType == MeasurementType.Peak
                            ? args.Result.PerformanceMeasurement.CurrentValue
                            : args.Result.CpuLoadMeasurement.CurrentValue);
                    }
                }
                else if (args.State == ExecutionState.Completed)
                {
                    MainController.SetStatusMessage("Benchmarking completed.");
                    _view.BenchmarkActionButton = "Start";
                    MainController.ResultsController.GenerateReport();
                    MainController.View.SelectedView = "Results";
                }
            }
        }
    }
}
