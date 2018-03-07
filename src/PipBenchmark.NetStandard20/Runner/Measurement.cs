namespace PipBenchmark.Runner
{
    public struct Measurement
    {
        private double _currentValue;
        private double _minValue;
        private double _averageValue;
        private double _maxValue;

        public Measurement(double currentValue, double minValue,
            double averageValue, double maxValue)
        {
            _currentValue = currentValue;
            _minValue = minValue;
            _averageValue = averageValue;
            _maxValue = maxValue;
        }

        public double CurrentValue
        {
            get { return _currentValue; }
        }

        public double MinValue
        {
            get { return _minValue; }
        }

        public double AverageValue
        {
            get { return _averageValue; }
        }

        public double MaxValue
        {
            get { return _maxValue; }
        }
    }
}
