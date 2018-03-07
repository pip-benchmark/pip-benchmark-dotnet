using System;
using System.Collections.Generic;
using System.Net;

#if !CompactFramework
using System.Net.NetworkInformation;
#else
using OpenNETCF.Net.NetworkInformation;
#endif

namespace PipBenchmark.Hardware
{
    public class NetworkBenchmarkSuite : BenchmarkSuite
    {
        private Parameter _destinationAddress;
        private Parameter _pingPacketSize;
        private Parameter _pingTimeout;

        private object _syncRoot = new object();
        private Ping _ping;
        private byte[] _pingBuffer;
        private int _pingTimeoutValue;
        private IPAddress _destinationIP;

        public NetworkBenchmarkSuite()
            : base("Network", "Benchmark for network")
        {
            InitializeConfigurationParameters();
            InitializeTests();
        }

        private void InitializeConfigurationParameters()
        {
            _destinationAddress = CreateParameter("DestinationAddress", "Address of the remote host", "localhost");
            _pingPacketSize = CreateParameter("PingPacketSize", "Size of ping packets in bytes", "32");
            _pingTimeout = CreateParameter("PingTimeout", "Ping timeout in msecs", "3000");
        }

        private void InitializeTests()
        {
            CreateBenchmark("Ping", "Measures network pings", ExecutePing);
        }

        public string DestinationAddress
        {
            get { return _destinationAddress.AsString; }
        }

        public int PingPacketSize
        {
            get { return _pingPacketSize.AsInteger; }
        }

        public int PingTimeout
        {
            get { return _pingTimeout.AsInteger; }
        }

        public override void SetUp()
        {
            _ping = new Ping();
            _pingBuffer = new byte[PingPacketSize];
            _destinationIP = Dns.GetHostEntry(DestinationAddress).AddressList[0];
            _pingTimeoutValue = PingTimeout;
        }

        public override void TearDown()
        {
        }

        public void ExecutePing()
        {
            lock (_syncRoot)
            {
                try
                {
#if !CompactFramework
                    _ping.Send(_destinationIP, _pingTimeoutValue, _pingBuffer, new PingOptions());
#else
                    _ping.Send(_destinationIP, _pingBuffer, _pingTimeoutValue, new PingOptions());
#endif
                }
                catch (PingException)
                {
                    // Ignore exception;
                }
            }
        }
    }
}
