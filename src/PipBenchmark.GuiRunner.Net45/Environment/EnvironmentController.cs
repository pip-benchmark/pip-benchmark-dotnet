using PipBenchmark.Gui.AsyncWait;
using PipBenchmark.Gui.Shell;
using PipBenchmark.Runner;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PipBenchmark.Gui.Environment
{
    public class EnvironmentController : AbstractChildController
    {
        private IEnvironmentView _view;
        private BenchmarkRunner _model;

        public EnvironmentController(MainController mainController, IEnvironmentView view)
            : base(mainController)
        {
            _view = view;
            _view.UpdateSystemBenchmarkClicked += OnUpdateSystemBenchmarkClicked;

            _model = mainController.Model;

            UpdateView();
        }

        private void UpdateView()
        {
            _view.SystemInformation = GetSystemInformation();
            _view.CpuPerformance = _model.Environment.CpuMeasurement.ToString("0.##");
            _view.VideoPerformance = _model.Environment.VideoMeasurement.ToString("0.##");
            _view.DiskPerformance = _model.Environment.DiskMeasurement.ToString("0.##");
        }

        private List<EnvironmentParameter> GetSystemInformation()
        {
            List<EnvironmentParameter> result = new List<EnvironmentParameter>();
            foreach (KeyValuePair<string, string> pair in _model.Environment.SystemInfo)
            {
                result.Add(new EnvironmentParameter(pair.Key, pair.Value));
            }
            return result;
        }

        public void UpdateSystemBenchmark()
        {
            MainController.AsyncWaitController.ExecuteAndWait("Updating System Benchmark",
                "Benchmarking process may take up to 2 mins.\r\n\r\nPlease wait...",
                UpdateSystemBenchmarkCallback, null);
        }

        private void OnUpdateSystemBenchmarkClicked(object sender, EventArgs args)
        {
            UpdateSystemBenchmark();
        }

        private void UpdateSystemBenchmarkCallback(IAsyncWaitContext context)
        {
            _model.Environment.Measure(true, true, true);

            MainController.View.Handler.Invoke(new ThreadStart(UpdateView));
        }
    }
}
