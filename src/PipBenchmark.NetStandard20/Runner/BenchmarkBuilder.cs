﻿using System.Collections.Generic;
using PipBenchmark.Runner.Config;

namespace PipBenchmark.Runner
{
    public abstract class BenchmarkBuilder
    {
        protected BenchmarkRunner _runner = new BenchmarkRunner();

        public BenchmarkBuilder ForceContinue(bool isForceContinue = false)
        {
            this._runner.Configuration.ForceContinue = isForceContinue;
            return this;
        }

        public BenchmarkBuilder MeasureAs(MeasurementType measurementType)
        {
            this._runner.Configuration.MeasurementType = measurementType;
            return this;
        }

        public BenchmarkBuilder WithNominalRate(double nominalRate)
        {
            this._runner.Configuration.NominalRate = nominalRate;
            return this;
        }

        public BenchmarkBuilder ExecuteAs(ExecutionType executionType)
        {
            this._runner.Configuration.ExecutionType = executionType;
            return this;
        }

        public BenchmarkBuilder ForDuration(int duration)
        {
            this._runner.Configuration.Duration = duration;
            return this;
        }

        public BenchmarkBuilder AddSuite(BenchmarkSuite suite)
        {
            this._runner.Benchmarks.AddSuite(suite);
            return this;
        }

        public BenchmarkBuilder WithParameter(string name, string value)
        {
            var parameters = new Dictionary<string, string> {[name] = value};
            this._runner.Parameters.Set(parameters);
            return this;
        }

        public BenchmarkBuilder WithBenchmark(string name)
        {
            this._runner.Benchmarks.SelectByName(new[] { name });
            return this;
        }


        public BenchmarkBuilder WithAllBenchmarks()
        {
            this._runner.Benchmarks.SelectAll();
            return this;
        }

        public BenchmarkBuilder InThreads(int numberOfThreads)
        {
            _runner.Configuration.NumberOfThreads = numberOfThreads;

            return this;
        }

        public virtual BenchmarkRunner Create()
        {
            var result = this._runner;
            this._runner = new BenchmarkRunner();
            return result;
        }
    }
}