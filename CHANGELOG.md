# Portable Benchmarking Framework in .NET Changelog

## <a name="2.1.0"></a> 2.1.0 (2018-03-15)

Added support for .NET Core

### Features
* Added support for .NET Core 2.0
* Added -t command line parameter to set number of threads

### Breaking Changes
* Runner API was completely changed

## <a name="2.0.0"></a> 2.0.0 (2017-02-06)

Complete refactoring of benchmark runner

### Breaking Changes
* Runner API was completely changed

## <a name="1.0.1-1.0.10"></a> 1.0.1-1.0.10 (2017-02-02)

Added ability to track errors

### Features
* **errors** Reporting errors during execution
* **example** Added examples
* **runner** Changed format of command line arguments. Added argument to set parameters
* **runner** Extracted ConsoleEventPrinter

### Breaking changes
* Renamed packages
* Changed execution context, moved there parameters
* Removed proportion property from benchmarks
* Renamed measurement type, nominal rate and execution type

### Bu Fixes
* Fixed issues with GuiRunner
* Fixed command line parameters

## <a name="1.0.0"></a> 1.0.0 (2017-01-13)

Initial public release

### Features
* **benchmarks** Code is structured as Benchmark and BenchmarkSuite classes
* **passive** Passive benchmarks that perform and report their own measurements
* **sequencial** Sequencial execution of benchmarks. Each benchmark runs for specified duration
* **proportional** Proportional execution of benchmarks. Each benchmark is called proportionally
* **peak** Peak measurement makes maximum number of calls, one after another without wait
* **nominal** Nominal measurement tries to maintain specified call rate while measuring system load
* **environment** Taking key environment benchmarks (CPU, Video, Disk) to report for objective interpretation of results
* **console** Console and GUI runners to execute benchmarks

### Breaking Changes
No breaking changes since this is the first version

### Bug Fixes
No fixes in this version

