using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

using PipBenchmark;
using System.Threading;
using System.Threading.Tasks;

namespace PipBenchmark.Database
{
    public abstract class DatabaseBenchmarkSuite : BenchmarkSuite
    {
        private const int MAX_RETRIES = 3;
        private const int RECONNECT_TIMEOUT = 10000;

        private string _machineNameValue;
        private Guid _processIdValue;
        private List<string> _memoValues;

        private Parameter _connectionString;
        private Parameter _numberOfRecordsInTable;
        private Parameter _numberOfRecordsToSelect;
        private Parameter _blobFieldSize;

        protected RandomDataGenerator RandomGenerator = new RandomDataGenerator();

        protected DatabaseBenchmarkSuite(string name, string description)
            : base(name, description)
        {
            InitializeConfigurationParameters();
            InitializeBenchmarkTests();
            InitializeFieldValues();
        }

        private void InitializeConfigurationParameters()
        {
            _connectionString = AddParameter("ConnectionString", "Connection string to connect to the test db", "");
            _numberOfRecordsInTable = AddParameter("NumberOfRecordsInTable", "Number of records in the test table", "10000");
            _numberOfRecordsToSelect = AddParameter("NumberOfRecordsToSelect", "Number of records to retrieve in select query", "100");
            _blobFieldSize = AddParameter("BlobFieldSize", "Size of blob field", "1024");
        }

        private void InitializeBenchmarkTests()
        {
            AddBenchmark("Insert", "Measures inserts", ExecuteInsert);
            AddBenchmark("Update", "Measures updates", ExecuteUpdate);
            AddBenchmark("Delete", "Measures deletes", ExecuteDelete);
            AddBenchmark("Select", "Measures selects", ExecuteSelect);
            AddBenchmark("SelectWhere", "Measures selects with where clause", ExecuteSelectWhere);

            AddBenchmark("ReadBlob", "Measures reading blobs", ExecuteReadBlob);
            AddBenchmark("WriteBlob", "Measures writing blobs", ExecuteWriteBlob);

            AddBenchmark("Commit", "Measures commits", ExecuteCommit);
            AddBenchmark("Rollback", "Measures rollbacks", ExecuteRollback);
        }

        private void InitializeFieldValues()
        {
#if !CompactFramework
            _machineNameValue = System.Environment.MachineName;
#else
            _machineNameValue = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\Ident", "Name", "NAME");
#endif
            _processIdValue = Guid.NewGuid();
            _memoValues = RandomGenerator.RandomStringList(0, 100, 128);
        }

        public string ConnectionString
        {
            get { return _connectionString.AsString; }
            set { _connectionString.AsString = value; }
        }

        public int NumberOfRecordsInTable
        {
            get { return Math.Max(100, _numberOfRecordsInTable.AsInteger); }
        }

        public int NumberOfRecordsToSelect
        {
            get { return Math.Max(100, Math.Min(NumberOfRecordsInTable, _numberOfRecordsToSelect.AsInteger)); }
        }

        public int BlobFieldSize
        {
            get { return Math.Max(128, Math.Min(10 * 1024 * 1024, _blobFieldSize.AsInteger)); }
        }

        protected string GetMachineNameValue()
        {
            return _machineNameValue;
        }

        protected Guid GetProcessIdValue()
        {
            return _processIdValue;
        }

        protected DateTime GetLastUpdateTimeValue()
        {
            return DateTime.Now;
        }

        protected double GetRandomValue()
        {
            return RandomGenerator.RandomDouble(0, 100);
        }

        protected string GetMemoValue()
        {
            StringBuilder builder = new StringBuilder();
            while (builder.Length < BlobFieldSize)
            {
                builder.Append(_memoValues[RandomGenerator.RandomInteger(0, _memoValues.Count)]);
            }
            builder.Length = BlobFieldSize;
            return builder.ToString();
        }

        internal abstract bool IsConnected();
        internal abstract void ConnectToDatabase();
        internal abstract void CreateTable();
        internal abstract int GetTableRecordCount();
        internal abstract void DisconnectFromDatabase();

        internal abstract void ExecuteInsert();
        internal abstract void ExecuteUpdate();
        internal abstract void ExecuteDelete();
        internal abstract void ExecuteSelect();
        internal abstract void ExecuteSelectWhere();

        internal abstract void ExecuteReadBlob();
        internal abstract void ExecuteWriteBlob();

        internal abstract void ExecuteCommit();
        internal abstract void ExecuteRollback();

        public override void SetUp()
        {
            ConnectToDatabase();
            CreateTable();

            int recordCount = GetTableRecordCount();
            if (recordCount < NumberOfRecordsInTable)
            {
                for (int index = recordCount; index < NumberOfRecordsInTable; index++)
                {
                    ExecuteInsert();
                }
            }
            else if (recordCount > NumberOfRecordsInTable)
            {
                for (int index = recordCount; index > NumberOfRecordsInTable; index--)
                {
                    ExecuteDelete();
                }
            }

            ExecuteCommit();
        }

        public override void TearDown()
        {
            DisconnectFromDatabase();
        }

        public void ExecuteWithRetries(Action action)
        {
            while (!IsConnected())
            {
                Context.SendMessage("Reconnecting...");

                ConnectToDatabase();
                CreateTable();
            }

            for (int retry = 1; retry <= MAX_RETRIES; retry++)
            {
                try
                {
                    action();
                    break;
                }
                catch (Exception ex)
                {
                    if (retry < MAX_RETRIES) continue;

                    // If too many retries - close connection and sleep for a while
                    DisconnectFromDatabase();
                    Thread.Sleep(RECONNECT_TIMEOUT);

                    throw ex;
                }
            }
        }
    }
}
