//using System;
//using System.Collections.Generic;
//using System.Data.SqlServerCe;
//using System.IO;
//using System.Reflection;

//namespace PipBenchmark.Database
//{
//    public class SqlCompactNativeBenchmarkTestSuite : AbstractDatabaseBenchmarkTestSuite
//    {
//        private SqlCeConnection _connection;
//        private SqlCeTransaction _transaction;
//        private SqlCeCommand _command;
//        private SqlCeResultSet _resultSet;

//        public SqlCompactNativeBenchmarkTestSuite()
//            : base("SqlCompactNative", "Benchmark for SQL Compact native API")
//        {
//#if !CompactFramework
//            ConnectionString = "Data Source=PipBenchmark.sdf; Persist Security Info=false";
//#else
//            ConnectionString = string.Format("Data Source={0}\\PipBenchmark.sdf; Persist Security Info=false",
//                Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));
//#endif
//        }

//        internal override void ConnectToDatabase()
//        {
//            _connection = new SqlCeConnection(ConnectionString);
//            _connection.Open();
//        }

//        internal override void CreateTable()
//        {
//            _transaction = _connection.BeginTransaction();

//            _command = _connection.CreateCommand();
//            _command.CommandText = "SELECT * FROM [BenchmarkTable]";
//            _command.Transaction = _transaction;
//            _resultSet = _command.ExecuteResultSet(ResultSetOptions.Scrollable | ResultSetOptions.Updatable);
//        }

//        internal override int GetTableRecordCount()
//        {
//            string getCountSql = "SELECT COUNT(*) FROM [BenchmarkTable]";
//            using (SqlCeCommand getCountCommand = _connection.CreateCommand())
//            {
//                getCountCommand.CommandText = getCountSql;
//                getCountCommand.Transaction = _transaction;
//                return (int)getCountCommand.ExecuteScalar();
//            }
//        }

//        internal override void DisconnectFromDatabase()
//        {
//            lock (SyncRoot)
//            {
//                if (_resultSet != null)
//                {
//                    _resultSet.Close();
//                }
//                if (_command != null)
//                {
//                    _command = null;
//                }
//                if (_transaction != null)
//                {
//                    _transaction.Rollback();
//                    _transaction = null;
//                }
//                if (_connection != null)
//                {
//                    _connection.Close();
//                    _connection = null;
//                }
//            }
//        }

//        internal override void ExecuteInsert()
//        {
//            lock (SyncRoot)
//            {
//                SqlCeUpdatableRecord record = _resultSet.CreateRecord();
//                record.SetValue(0, GetMachineNameValue());
//                record.SetValue(1, GetProcessIdValue());
//                record.SetValue(2, GetLastUpdateTimeValue());
//                record.SetValue(3, GetRandomValue());
//                _resultSet.Insert(record);
//            }
//        }

//        internal override void ExecuteUpdate()
//        {
//            lock (SyncRoot)
//            {
//                if (_resultSet.ReadAbsolute(RandomGenerator.RandomInteger(0, NumberOfRecordsInTable)))
//                {
//                    _resultSet.SetValue(0, GetMachineNameValue());
//                    _resultSet.SetValue(1, GetProcessIdValue());
//                    _resultSet.SetValue(2, GetLastUpdateTimeValue());
//                    _resultSet.SetValue(3, GetRandomValue());
//                    _resultSet.Update();
//                }
//            }
//        }

//        internal override void ExecuteDelete()
//        {
//            lock (SyncRoot)
//            {
//                if (_resultSet.ReadAbsolute(RandomGenerator.RandomInteger(0, NumberOfRecordsInTable)))
//                {
//                    _resultSet.Delete();
//                }
//            }
//        }

//        internal override void ExecuteSelect()
//        {
//            lock (SyncRoot)
//            {
//                _resultSet.ReadFirst();
//                int topFieldCount = NumberOfRecordsToSelect;
//                while (topFieldCount > 0 && _resultSet.Read())
//                {
//                    object field1 = _resultSet.GetValue(0);
//                    object field2 = _resultSet.GetValue(1);
//                    object field3 = _resultSet.GetValue(2);
//                    object field4 = _resultSet.GetValue(3);
//                    topFieldCount--;
//                }
//            }
//        }

//        internal override void ExecuteSelectWhere()
//        {
//            lock (SyncRoot)
//            {
//                _resultSet.ReadFirst();
//                while (_resultSet.Read())
//                {
//                    object field1 = _resultSet.GetValue(0);
//                    object field2 = _resultSet.GetValue(1);
//                    object field3 = _resultSet.GetValue(2);
//                    object field4 = _resultSet.GetValue(3);
//                }
//            }
//        }

//        internal override void ExecuteReadBlob()
//        {
//            lock (SyncRoot)
//            {
//                if (_resultSet.ReadAbsolute(RandomGenerator.RandomInteger(0, NumberOfRecordsInTable)))
//                {
//                    object blobField = _resultSet.GetValue(4);
//                }
//            }
//        }

//        internal override void ExecuteWriteBlob()
//        {
//            lock (SyncRoot)
//            {
//                if (_resultSet.ReadAbsolute(RandomGenerator.RandomInteger(0, NumberOfRecordsInTable)))
//                {
//                    _resultSet.SetValue(4, GetMemoValue());
//                    _resultSet.Update();
//                }
//            }
//        }

//        internal override void ExecuteCommit()
//        {
//            lock (SyncRoot)
//            {
//                _resultSet.Close();
//                _transaction.Commit();
//                _transaction = _connection.BeginTransaction();
//                _command.Transaction = _transaction;
//                _resultSet = _command.ExecuteResultSet(ResultSetOptions.Scrollable | ResultSetOptions.Updatable);
//            }
//        }

//        internal override void ExecuteRollback()
//        {
//            lock (SyncRoot)
//            {
//                _resultSet.Close();
//                _transaction.Rollback();
//                _transaction = _connection.BeginTransaction();
//                _command.Transaction = _transaction;
//                _resultSet = _command.ExecuteResultSet(ResultSetOptions.Scrollable | ResultSetOptions.Updatable);
//            }
//        }

//    }
//}
