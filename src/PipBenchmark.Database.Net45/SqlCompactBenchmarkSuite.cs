//using System;
//using System.Collections.Generic;
//using System.Data.SqlServerCe;
//using System.Data;
//using System.IO;
//using System.Reflection;

//namespace PipBenchmark.Database
//{
//    public class SqlCompactBenchmarkTestSuite : AbstractDatabaseBenchmarkTestSuite
//    {
//        private SqlCeConnection _connection;
//        private SqlCeTransaction _transaction;
//        private SqlCeCommand _insertCommand;
//        private SqlCeCommand _updateCommand;
//        private SqlCeCommand _deleteCommand;
//        private SqlCeCommand _selectCommand;
//        private SqlCeCommand _selectWhereCommand;
//        private SqlCeCommand _readBlobCommand;
//        private SqlCeCommand _writeBlobCommand;

//        public SqlCompactBenchmarkTestSuite()
//            : base("SqlCompact", "Benchmark for SQL Server Compact edition")
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
//            //string createTableSql =
//            //    "IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BenchmarkTable]') AND type in (N'U'))"
//            //    + "CREATE TABLE [BenchmarkTable]("
//            //    + "[MachineName] [varchar](15) NULL,"
//            //    + "[ProcessID] [uniqueidentifier] NULL,"
//            //    + "[LastUpdateTime] [datetime] NULL,"
//            //    + "[Value] [float] NULL,"
//            //    + "[Memo] [text] NULL"
//            //    + ")";
//            //using (SqlCeCommand createCommand = _connection.CreateCommand())
//            //{
//            //    createCommand.CommandText = createTableSql;
//            //    createCommand.ExecuteNonQuery();
//            //}

//            _insertCommand = _connection.CreateCommand();
//            _insertCommand.CommandText = "INSERT INTO [BenchmarkTable]"
//                + " ([MachineName],[ProcessID],[LastUpdateTime],[Value])"
//                + " VALUES (@MachineName, @ProcessID, @LastUpdateTime, @Value)";
//            _insertCommand.Parameters.Add(new SqlCeParameter("MachineName", SqlDbType.NVarChar));
//            _insertCommand.Parameters[0].Size = 15;
//            _insertCommand.Parameters.Add(new SqlCeParameter("ProcessID", SqlDbType.UniqueIdentifier));
//            _insertCommand.Parameters.Add(new SqlCeParameter("LastUpdateTime", SqlDbType.DateTime));
//            _insertCommand.Parameters.Add(new SqlCeParameter("Value", SqlDbType.Float));
//            _insertCommand.Prepare();

//            _updateCommand = _connection.CreateCommand();
//            _updateCommand.CommandText = "UPDATE [BenchmarkTable]"
//                + " SET [MachineName]=@MachineName, [ProcessID]=@ProcessID,"
//                + " [LastUpdateTime]=@LastUpdateTime, [Value]=@Value"
//                + " WHERE [Value]=@Old_Value";
//            _updateCommand.Parameters.Add(new SqlCeParameter("MachineName", SqlDbType.NVarChar));
//            _updateCommand.Parameters[0].Size = 15;
//            _updateCommand.Parameters.Add(new SqlCeParameter("ProcessID", SqlDbType.UniqueIdentifier));
//            _updateCommand.Parameters.Add(new SqlCeParameter("LastUpdateTime", SqlDbType.DateTime));
//            _updateCommand.Parameters.Add(new SqlCeParameter("Value", SqlDbType.Float));
//            _updateCommand.Parameters.Add(new SqlCeParameter("Old_Value", SqlDbType.Float));
//            _updateCommand.Prepare();

//            _deleteCommand = _connection.CreateCommand();
//            _deleteCommand.CommandText = "DELETE FROM [BenchmarkTable]"
//                + " WHERE [Value]=@Old_Value";
//            _deleteCommand.Parameters.Add(new SqlCeParameter("Old_Value", SqlDbType.Float));
//            _deleteCommand.Prepare();

//            _selectCommand = _connection.CreateCommand();
//            _selectCommand.CommandText = string.Format("SELECT TOP({0})"
//                + " [MachineName],[ProcessID],[LastUpdateTime],[Value]"
//                + " FROM [BenchmarkTable]", NumberOfRecordsToSelect);
//            _selectCommand.Prepare();

//            _selectWhereCommand = _connection.CreateCommand();
//            _selectWhereCommand.CommandText = "SELECT [MachineName],[ProcessID],[LastUpdateTime],[Value]"
//                + " FROM  [BenchmarkTable] WHERE [Value] > @Old_Value - 10 AND [Value] < @Old_Value + 10";
//            _selectWhereCommand.Parameters.Add(new SqlCeParameter("Old_Value", SqlDbType.Float));
//            _selectWhereCommand.Prepare();

//            _readBlobCommand = _connection.CreateCommand();
//            _readBlobCommand.CommandText = "SELECT [Memo]"
//                + " FROM  [BenchmarkTable] WHERE [Value]=@Old_Value";
//            _readBlobCommand.Parameters.Add(new SqlCeParameter("Old_Value", SqlDbType.Float));
//            _readBlobCommand.Prepare();

//            _writeBlobCommand = _connection.CreateCommand();
//            _writeBlobCommand.CommandText = "UPDATE [BenchmarkTable]"
//                + " SET [Memo]=@Memo WHERE [Value]=@Old_Value";
//            _writeBlobCommand.Parameters.Add(new SqlCeParameter("Memo", SqlDbType.NText));
//            _writeBlobCommand.Parameters[0].Size = BlobFieldSize;
//            _writeBlobCommand.Parameters.Add(new SqlCeParameter("Old_Value", SqlDbType.Float));
//            _writeBlobCommand.Prepare();

//            _transaction = _connection.BeginTransaction();
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
//                _insertCommand.Transaction = _transaction;
//                _insertCommand.Parameters[0].Value = GetMachineNameValue();
//                _insertCommand.Parameters[1].Value = GetProcessIdValue();
//                _insertCommand.Parameters[2].Value = GetLastUpdateTimeValue();
//                _insertCommand.Parameters[3].Value = GetRandomValue();
//                _insertCommand.ExecuteNonQuery();
//            }
//        }

//        internal override void ExecuteUpdate()
//        {
//            lock (SyncRoot)
//            {
//                _updateCommand.Transaction = _transaction;
//                _updateCommand.Parameters[0].Value = GetMachineNameValue();
//                _updateCommand.Parameters[1].Value = GetProcessIdValue();
//                _updateCommand.Parameters[2].Value = GetLastUpdateTimeValue();
//                _updateCommand.Parameters[3].Value = GetRandomValue();
//                _updateCommand.Parameters[4].Value = GetRandomValue();
//                _updateCommand.ExecuteNonQuery();
//            }
//        }

//        internal override void ExecuteDelete()
//        {
//            lock (SyncRoot)
//            {
//                _deleteCommand.Transaction = _transaction;
//                _deleteCommand.Parameters[0].Value = GetRandomValue();
//                _deleteCommand.ExecuteNonQuery();
//            }
//        }

//        internal override void ExecuteSelect()
//        {
//            lock (SyncRoot)
//            {
//                _selectCommand.Transaction = _transaction;
//                using (SqlCeDataReader reader = _selectCommand.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        object field1 = reader.GetValue(0);
//                        object field2 = reader.GetValue(1);
//                        object field3 = reader.GetValue(2);
//                        object field4 = reader.GetValue(3);
//                    }
//                }
//            }
//        }

//        internal override void ExecuteSelectWhere()
//        {
//            lock (SyncRoot)
//            {
//                _selectWhereCommand.Transaction = _transaction;
//                _selectWhereCommand.Parameters[0].Value = GetRandomValue();
//                using (SqlCeDataReader reader = _selectWhereCommand.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        object field1 = reader.GetValue(0);
//                        object field2 = reader.GetValue(1);
//                        object field3 = reader.GetValue(2);
//                        object field4 = reader.GetValue(3);
//                    }
//                }
//            }
//        }

//        internal override void ExecuteReadBlob()
//        {
//            lock (SyncRoot)
//            {
//                _readBlobCommand.Transaction = _transaction;
//                _readBlobCommand.Parameters[0].Value = GetRandomValue();
//                using (SqlCeDataReader reader = _readBlobCommand.ExecuteReader())
//                {
//                    if (reader.Read())
//                    {
//                        object memoField = reader.GetValue(0);
//                    }
//                }
//            }
//        }

//        internal override void ExecuteWriteBlob()
//        {
//            lock (SyncRoot)
//            {
//                _writeBlobCommand.Transaction = _transaction;
//                _writeBlobCommand.Parameters[0].Value = GetMemoValue();
//                _writeBlobCommand.Parameters[1].Value = GetRandomValue();
//                _writeBlobCommand.ExecuteNonQuery();
//            }
//        }

//        internal override void ExecuteCommit()
//        {
//            lock (SyncRoot)
//            {
//                _transaction.Commit();
//                _transaction = _connection.BeginTransaction();
//            }
//        }

//        internal override void ExecuteRollback()
//        {
//            lock (SyncRoot)
//            {
//                _transaction.Rollback();
//                _transaction = _connection.BeginTransaction();
//            }
//        }
//    }
//}
