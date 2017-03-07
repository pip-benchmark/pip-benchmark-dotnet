using PipBenchmark.Utilities;
using System.IO;

namespace PipBenchmark.Runner.Environment
{
    public class EnvironmentProperties : Properties
    {
        public EnvironmentProperties()
        {
        }

        private string GetFilePath()
        {
#if !CompactFramework
            string directoryPath = Directory.GetCurrentDirectory();
#else
            string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
#endif
            return directoryPath + "\\BenchmarkEnvironment.properties";
        }

        public double CpuBenchmark
        {
            get { return base.GetAsDouble("CpuBenchmark", 0); }
            set { base.SetAsDouble("CpuBenchmark", value); }
        }

        public double DiskBenchmark
        {
            get { return base.GetAsDouble("DiskBenchmark", 0); }
            set { base.SetAsDouble("DiskBenchmark", value); }
        }

        public double VideoBenchmark
        {
            get { return base.GetAsDouble("VideoBenchmark", 0); }
            set { base.SetAsDouble("VideoBenchmark", value); }
        }

        public void Load()
        {
            FileInfo fileInfo = new FileInfo(GetFilePath());
            if (fileInfo.Exists)
            {
                using (FileStream stream = fileInfo.OpenRead())
                {
                    LoadFromStream(stream);
                }
            }
        }

        public void Save()
        {
            FileInfo fileInfo = new FileInfo(GetFilePath());
            using (FileStream stream = fileInfo.OpenWrite())
            {
                SaveToStream(stream);
            }
        }

    }
}
