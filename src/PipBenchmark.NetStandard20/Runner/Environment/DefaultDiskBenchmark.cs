using PipBenchmark.Utilities.Random;
using System;
using System.IO;

namespace PipBenchmark.Runner.Environment
{
    public class DefaultDiskBenchmark : Benchmark
    {
        private const int BufferSize = 512;
        private const int ChunkSize = 1024000;
        private const int FileSize = 102400000;

        private object _syncRoot = new object();
        
        private string _fileName;
        private FileStream _fileStream;
        private int _fileSize;
        private int _chunkSize;
        private bool _testReads = true;
        private bool _testWrites = true;
        private byte[] _buffer = new byte[BufferSize];

        public DefaultDiskBenchmark()
            : base("Disk", "Measures system disk performance")
        { }

        public override void SetUp()
        {
            _fileSize = Math.Max(Context.Parameters["FileSize"].AsInteger, FileSize);
            _chunkSize = Math.Max(Context.Parameters["ChunkSize"].AsInteger, ChunkSize);
            _chunkSize = Math.Min(_chunkSize, _fileSize);

            _testReads = !Context.Parameters["OperationTypes"].Value.Equals("Write", StringComparison.InvariantCultureIgnoreCase);
            _testWrites = !Context.Parameters["OperationTypes"].Value.Equals("Read", StringComparison.InvariantCultureIgnoreCase);

            _fileName = GetFileName();
            lock (_fileStream)
            {
                _fileStream = new FileStream(_fileName, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None, 1);
            }

            // If we test only reads then file shall be prepared in advance
            if (!_testWrites)
            {
                lock (_fileStream)
                {
                    _fileStream.Seek(0, SeekOrigin.Begin);
                }
                int sizeToWrite = _fileSize;
                while (sizeToWrite > 0)
                {
                    lock (_fileStream)
                    {
                        _fileStream.Write(_buffer, 0, Math.Min(BufferSize, sizeToWrite));
                    }

                    sizeToWrite -= BufferSize;
                }
                lock (_fileStream)
                {
                    _fileStream.Flush();
                }
            }
        }

        private string GetFileName()
        {
            string directoryPath = Context.Parameters["FilePath"].Value;

            // Use default if directory path is not set
            if (string.IsNullOrEmpty(directoryPath))
            {
#if !CompactFramework
                directoryPath = Directory.GetCurrentDirectory();
#else
                directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
#endif
            }

            return directoryPath + $"\\DiskBenchmark-{Guid.NewGuid():N}.dat";
        }

        public override void Execute()
        {
            if (_fileStream == null)
            {
                return;
            }

            lock (_syncRoot)
            {
                if (_fileStream.Length == 0 || (_testWrites && (!_testReads || RandomInteger.NextInteger(2) == 0)))
                {
                    var position = _fileStream.Length < _fileSize
                        ? Math.Min(_fileSize - _chunkSize, (int) _fileStream.Length)
                        : RandomInteger.NextInteger(_fileSize - _chunkSize);

                    _fileStream.Seek(position, SeekOrigin.Begin);
                    int sizeToWrite = _chunkSize;
                    while (sizeToWrite > 0)
                    {
                        _fileStream.Write(_buffer, 0, Math.Min(BufferSize, sizeToWrite));
                        sizeToWrite -= BufferSize;
                    }
                    _fileStream.Flush();
                }
                else
                {
                    int position = RandomInteger.NextInteger((int)_fileStream.Length - _chunkSize);
                    _fileStream.Seek(position, SeekOrigin.Begin);

                    int sizeToRead = _chunkSize;
                    while (sizeToRead > 0)
                    {
                        _fileStream.Read(_buffer, 0, Math.Min(BufferSize, sizeToRead));
                        sizeToRead -= BufferSize;
                    }
                }
            }
        }

        public override void TearDown()
        {
            lock (_syncRoot)
            {
                _fileStream.Close();
                _fileStream = null;

                FileInfo fileInfo = new FileInfo(_fileName);
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
    }
}
