using PipBenchmark.Utilities.Random;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PipBenchmark.Hardware
{
    public class StandardDiskBenchmark : Benchmark
    {
        private const int BufferSize = 512;
        private int ChunkSize = 1024000;
#if !CompactFramework
        private const int FileSize = 102400000;
#else
        private const int FileSize = 2048000;
#endif

        private object _syncRoot = new object();
        private FileStream _fileStream;
        private byte[] _buffer = new byte[BufferSize];

        public StandardDiskBenchmark()
            : base("Disk", "Measures disk read and write operations")
        {
        }

        public override void SetUp()
        {
            _fileStream = new FileStream(GetFileName(), FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None, 1);
        }

        private string GetFileName()
        {
#if !CompactFramework
            string directoryPath = Directory.GetCurrentDirectory();
#else
            string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
#endif
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
                if (_fileStream.Length == 0 || RandomInteger.NextInteger(2) == 0)
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
                else
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

        public override void TearDown()
        {
            lock (_syncRoot)
            {
                _fileStream.Close();
                _fileStream = null;

                FileInfo fileInfo = new FileInfo(GetFileName());
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
