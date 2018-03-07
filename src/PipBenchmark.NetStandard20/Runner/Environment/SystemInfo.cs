using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace PipBenchmark.Runner.Environment
{
    public class SystemInfo : Dictionary<string, string>
    {
        public SystemInfo()
        {
#if !CompactFramework
            Add("Machine Name", System.Environment.MachineName);
#else
            Add("Machine Name",
                (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\Ident", "Name", "NAME"));
#endif
#if !CompactFramework
            Add("User Name", System.Environment.UserName);
#endif
            Add("Operating System", System.Environment.OSVersion.ToString());
            Add(".NET Framework", System.Environment.Version.ToString());
        }
    }
}
