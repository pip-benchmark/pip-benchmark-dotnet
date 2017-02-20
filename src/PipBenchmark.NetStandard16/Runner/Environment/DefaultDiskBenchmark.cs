using System;
using System.IO;

namespace PipBenchmark.Runner.Environment
{
    public class DefaultDiskBenchmark : Benchmark
    {
        private const int BufferSize = 512;

        private object _syncRoot = new object();
        private Random _randomGenerator = new Random();
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
            _fileSize = Math.Max(Context.Parameters["FileSize"].AsInteger, 1024);
            _chunkSize = Math.Max(Context.Parameters["ChunkSize"].AsInteger, 128);
            _chunkSize = Math.Min(_chunkSize, _fileSize);

            _testReads = !Context.Parameters["OperationTypes"].Value.Equals("Write", StringComparison.InvariantCultureIgnoreCase);
            _testWrites = !Context.Parameters["OperationTypes"].Value.Equals("Read", StringComparison.InvariantCultureIgnoreCase);

            _fileName = GetFileName();
            _fileStream = new FileStream(_fileName, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None, 1);

            // If we test only reads then file shall be prepared in advance
            if (!_testWrites)
            {
                _fileStream.Seek(0, SeekOrigin.Begin);
                int sizeToWrite = _fileSize;
                while (sizeToWrite > 0)
                {
                    _fileStream.Write(_buffer, 0, Math.Min(BufferSize, sizeToWrite));
                    sizeToWrite -= BufferSize;
                }
                _fileStream.Flush();
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

            return directoryPath + string.Format("\\DiskBenchmark-{0}.dat", Guid.NewGuid().ToString("N"));
        }

        public override void Execute()
        {
            if (_fileStream == null)
            {
                return;
            }

            lock (_syncRoot)
            {
                if (_fileStream.Length == 0 || (_testWrites && (!_testReads || _randomGenerator.Next(2) == 0)))
                {
                    int position;

                    if (_fileStream.Length < _fileSize)
                        position = Math.Min(_fileSize - _chunkSize, (int)_fileStream.Length);
                    else
                        position = _randomGenerator.Next(_fileSize - _chunkSize);

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
                    int position = _randomGenerator.Next((int)_fileStream.Length - _chunkSize);
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
