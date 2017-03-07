using PipBenchmark.Runner;
using PipBenchmark.Runner.Results;
using System;

namespace PipBenchmark.Runner.Execution
{
    public abstract class BenchmarkMeter
    {
        private DateTime _lastMeasuredTime;
        private double _currentValue;
        private double _minValue;
        private double _maxValue;
        private double _averageValue;
        private double _sumOfValues;
        private double _numberOfMeasurements;

        public BenchmarkMeter()
        {
            Reset();
        }

        public Measurement Measurement
        {
            get { return new Measurement(CurrentValue, MinValue, AverageValue, MaxValue); }
        }

        public DateTime LastMeasuredTime
        {
            get { return _lastMeasuredTime; }
            protected set { _lastMeasuredTime = value; }
        }

        public double CurrentValue
        {
            get { return _currentValue; }
            protected set { _currentValue = value; }
        }

        public double MinValue
        {
            get { return _minValue < Double.MaxValue ? _minValue : 0; }
            protected set { _minValue = value; }
        }

        public double MaxValue
        {
            get { return _maxValue > Double.MinValue ? _maxValue : 0; }
            protected set { _minValue = value; }
        }

        public double AverageValue
        {
            get { return _averageValue; }
            protected set { _averageValue = value; }
        }

        public virtual void Reset()
        {
            _lastMeasuredTime = DateTime.Now;
            _currentValue = PerformMeasurement();
            _minValue = Double.MaxValue;
            _maxValue = Double.MinValue;
            _averageValue = 0;
            _sumOfValues = 0;
            _numberOfMeasurements = 0;
        }

        protected void CalculateAggregates()
        {
            _sumOfValues += _currentValue;
            _numberOfMeasurements++;
            _averageValue = _sumOfValues / _numberOfMeasurements;
            _maxValue = Math.Max(_maxValue, _currentValue);
            _minValue = Math.Min(_minValue, _currentValue);
        }

        public virtual double Measure()
        {
            _currentValue = PerformMeasurement();
            _lastMeasuredTime = DateTime.Now;
            CalculateAggregates();
            return _currentValue;
        }

        protected abstract double PerformMeasurement();
    }
}
