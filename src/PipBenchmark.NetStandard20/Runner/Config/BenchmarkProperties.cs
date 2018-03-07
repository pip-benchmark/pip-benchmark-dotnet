using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace PipBenchmark.Runner.Config
{
    public class BenchmarkProperties : Properties
    {
        public BenchmarkProperties()
        {
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

        private string GetFilePath()
        {
#if !CompactFramework
            string directoryPath = Directory.GetCurrentDirectory();
#else
            string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
#endif
            return directoryPath + "\\BenchmarkSettings.properties";
        }
    }
}
