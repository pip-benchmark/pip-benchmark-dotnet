using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace PipBenchmark.Runner.Environment
{
    public class SystemInformation : Dictionary<string, string>
    {
        public SystemInformation()
        {
            FillSystemInformation();
        }

        private void FillSystemInformation()
        {
#if !CompactFramework
            AddSystemInfo("Machine Name", System.Environment.MachineName);
#else
            AddSystemInfo("Machine Name",
                (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\Ident", "Name", "NAME"));
#endif
#if !CompactFramework
            AddSystemInfo("User Name", System.Environment.UserName);
#endif
            AddSystemInfo("Operating System", System.Environment.OSVersion.ToString());
            AddSystemInfo(".NET Framework", System.Environment.Version.ToString());
        }

        private void AddSystemInfo(string parameter, string value)
        {
            Add(parameter, value);
        }
    }
}
