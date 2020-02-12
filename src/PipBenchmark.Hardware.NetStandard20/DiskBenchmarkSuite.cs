using PipBenchmark.Utilities.Random;
using System;
using System.IO;

namespace PipBenchmark.Hardware
{
    public class DiskBenchmarkSuite : BenchmarkSuite
    {
        private const int BufferSize = 512;

        private Parameter _filePath;
        private Parameter _fileSize;
        private Parameter _chunkSize;

        private object _syncRoot = new object();
        private FileStream _fileStream;
        private byte[] _buffer = new byte[BufferSize];

        public DiskBenchmarkSuite()
            : base("Disk", "Benchmark for disk I/O operations")
        {
            InitializeConfigurationParameters();
            InitializeTests();
        }

        private void InitializeConfigurationParameters()
        {
            _filePath = CreateParameter("FilePath", "Path where test file is located on disk", "");
            _fileSize = CreateParameter("FileSize", "Size of the test file",
#if !CompactFramework 
                "102400000"
#else
                "2048000"
#endif
            );
            _chunkSize = CreateParameter("ChunkSize", "Size of a chunk that read or writter from/to test file", "1024000");
        }

        private void InitializeTests()
        {
            CreateBenchmark("ReadsAndWrites", "Measures read and write operations", ExecuteReadsAndWrites);
            CreateBenchmark("Reads", "Measures only read operations", ExecuteReads);
            CreateBenchmark("Writes", "Measures only write operations", ExecuteWrites);
        }

        public int FileSize
        {
            get { return Math.Max(_fileSize.AsInteger, 1024); } 
        }

        public int ChunkSize
        {
            get { return Math.Min(FileSize, Math.Max(_chunkSize.AsInteger, 128)); }
        }

        public string FileName
        {
            get
            {
                string directoryPath = _filePath.Value;

                // Use default if directory path is not set
                if (string.IsNullOrEmpty(directoryPath))
                {
#if !CompactFramework
                    directoryPath = Directory.GetCurrentDirectory();
#else
                directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
#endif
                }

                return directoryPath + string.Format("\\DiskBenchmark-{0}.dat", Guid.NewGuid().ToString("N"));
            }
        }

        public override void SetUp()
        {
            _fileStream = new FileStream(FileName, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None, 1);

            // If we test only reads then file shall be prepared in advance
            _fileStream.Seek(0, SeekOrigin.Begin);
            int sizeToWrite = FileSize;
            while (sizeToWrite > 0)
            {
                _fileStream.Write(_buffer, 0, Math.Min(BufferSize, sizeToWrite));
                sizeToWrite -= BufferSize;
            }
            _fileStream.Flush();
        }

        public override void TearDown()
        {
            lock (_syncRoot)
            {
                _fileStream.Close();
                _fileStream = null;

                FileInfo fileInfo = new FileInfo(FileName);
                if (fileInfo.Exists)
                {
                    try
                    {
                        fileInfo.Delete();
                    }
                    catch
                    {
                        // Ignore...
                    }
                }
            }
        }

        public void ExecuteReadsAndWrites()
        {
            if (_fileStream.Length == 0 || RandomInteger.NextInteger(2) == 0)
            {
                ExecuteWrites();
            }
            else
            {
                ExecuteReads();
            }
        }

        public void ExecuteWrites()
        {
            lock (_syncRoot)
            {
                int position;

                if (_fileStream.Length < FileSize)
                {
                    position = Math.Min(FileSize - ChunkSize, (int)_fileStream.Length);
                }
                else
                {
                    position = RandomInteger.NextInteger(FileSize - ChunkSize);
                }

                _fileStream.Seek(position, SeekOrigin.Begin);
                int sizeToWrite = ChunkSize;
                while (sizeToWrite > 0)
                {
                    _fileStream.Write(_buffer, 0, Math.Min(BufferSize, sizeToWrite));
                    sizeToWrite -= BufferSize;
                }
                _fileStream.Flush();
            }
        }

        public void ExecuteReads()
        {
            lock (_syncRoot)
            {
                if (_fileStream.Length > 0)
                {
                    int position = RandomInteger.NextInteger((int)_fileStream.Length - ChunkSize);
                    _fileStream.Seek(position, SeekOrigin.Begin);

                    int sizeToRead = ChunkSize;
                    while (sizeToRead > 0)
                    {
                        _fileStream.Read(_buffer, 0, Math.Min(BufferSize, sizeToRead));
                        sizeToRead -= BufferSize;
                    }
                }
            }
        }
    }
}
