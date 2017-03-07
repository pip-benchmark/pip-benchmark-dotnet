using System;

namespace PipBenchmark.Runner.Config
{
    public class ConfigurationManager
    {
        private int _numberOfThreads = 1;
        private MeasurementType _measurementType = MeasurementType.Peak;
        private double _nominalRate = 1;
        private ExecutionType _executionType = ExecutionType.Proportional;
        private int _duration = 60;
        private bool _forceContinue = false;

        public ConfigurationManager() { }

        public int NumberOfThreads
        {
            get { return _numberOfThreads; }
            set { _numberOfThreads = value; }
        }

        public MeasurementType MeasurementType
        {
            get { return _measurementType; }
            set { _measurementType = value; }
        }

        public double NominalRate
        {
            get { return _nominalRate; }
            set { _nominalRate = value; }
        }

        public ExecutionType ExecutionType
        {
            get { return _executionType; }
            set { _executionType = value; }
        }

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public bool ForceContinue
        {
            get { return _forceContinue; }
            set { _forceContinue = value; }
        }

        public event EventHandler Changed;

        public void NotifyChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }
    }
}
