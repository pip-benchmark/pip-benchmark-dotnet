using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace PipBenchmark.Database
{
    public class SqlServerBenchmarkSuite : DatabaseBenchmarkSuite
    {
        private object _syncRoot = new object();
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        private SqlCommand _insertCommand;
        private SqlCommand _updateCommand;
        private SqlCommand _deleteCommand;
        private SqlCommand _selectCommand;
        private SqlCommand _selectWhereCommand;
        private SqlCommand _readBlobCommand;
        private SqlCommand _writeBlobCommand;

        public SqlServerBenchmarkSuite()
            : base("SqlServer", "Benchmark for SQL Server")
        {
            ConnectionString = "Data Source=localhost; Initial Catalog=test; Integrated Security=true";
        }

        internal override bool IsConnected()
        {
            return _connection != null;
        }

        internal override void ConnectToDatabase()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        internal override void CreateTable()
        {
            string createTableSql =
                "IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BenchmarkTable]') AND type in (N'U'))"
                + "CREATE TABLE [dbo].[BenchmarkTable]("
                + "[MachineName] [varchar](15) NULL,"
                + "[ProcessID] [uniqueidentifier] NULL,"
                + "[LastUpdateTime] [datetime] NULL,"
                + "[Value] [float] NULL,"
                + "[Memo] [text] NULL"
                + ")";
            using (SqlCommand createCommand = _connection.CreateCommand())
            {
                createCommand.CommandText = createTableSql;
                createCommand.ExecuteNonQuery();
            }

            _insertCommand = _connection.CreateCommand();
            _insertCommand.CommandText = "INSERT INTO [dbo].[BenchmarkTable]"
                + " ([MachineName],[ProcessID],[LastUpdateTime],[Value])"
                + " VALUES (@MachineName, @ProcessID, @LastUpdateTime, @Value)";
            _insertCommand.Parameters.Add(new SqlParameter("MachineName", SqlDbType.VarChar));
            _insertCommand.Parameters[0].Size = 15;
            _insertCommand.Parameters.Add(new SqlParameter("ProcessID", SqlDbType.UniqueIdentifier));
            _insertCommand.Parameters.Add(new SqlParameter("LastUpdateTime", SqlDbType.DateTime));
            _insertCommand.Parameters.Add(new SqlParameter("Value", SqlDbType.Float));
            _insertCommand.Prepare();

            _updateCommand = _connection.CreateCommand();
            _updateCommand.CommandText = "UPDATE [dbo].[BenchmarkTable]"
                + " SET [MachineName]=@MachineName, [ProcessID]=@ProcessID,"
                + " [LastUpdateTime]=@LastUpdateTime, [Value]=@Value"
                + " WHERE [Value]=@Old_Value";
            _updateCommand.Parameters.Add(new SqlParameter("MachineName", SqlDbType.VarChar));
            _updateCommand.Parameters[0].Size = 15;
            _updateCommand.Parameters.Add(new SqlParameter("ProcessID", SqlDbType.UniqueIdentifier));
            _updateCommand.Parameters.Add(new SqlParameter("LastUpdateTime", SqlDbType.DateTime));
            _updateCommand.Parameters.Add(new SqlParameter("Value", SqlDbType.Float));
            _updateCommand.Parameters.Add(new SqlParameter("Old_Value", SqlDbType.Float));
            _updateCommand.Prepare();

            _deleteCommand = _connection.CreateCommand();
            _deleteCommand.CommandText = "DELETE FROM [dbo].[BenchmarkTable]"
                + " WHERE [Value]=@Old_Value";
            _deleteCommand.Parameters.Add(new SqlParameter("Old_Value", SqlDbType.Float));
            _deleteCommand.Prepare();

            _selectCommand = _connection.CreateCommand();
            _selectCommand.CommandText = string.Format("SELECT TOP({0})"
                + " [MachineName],[ProcessID],[LastUpdateTime],[Value]"
                + " FROM [dbo].[BenchmarkTable]", NumberOfRecordsToSelect);
            _selectCommand.Prepare();

            _selectWhereCommand = _connection.CreateCommand();
            _selectWhereCommand.CommandText = "SELECT [MachineName],[ProcessID],[LastUpdateTime],[Value]"
                + " FROM  [dbo].[BenchmarkTable] WHERE [Value] > @Old_Value - 10 AND [Value] < @Old_Value + 10";
            _selectWhereCommand.Parameters.Add(new SqlParameter("Old_Value", SqlDbType.Float));
            _selectWhereCommand.Prepare();

            _readBlobCommand = _connection.CreateCommand();
            _readBlobCommand.CommandText = "SELECT [Memo]"
                + " FROM  [dbo].[BenchmarkTable] WHERE [Value]=@Old_Value";
            _readBlobCommand.Parameters.Add(new SqlParameter("Old_Value", SqlDbType.Float));
            _readBlobCommand.Prepare();

            _writeBlobCommand = _connection.CreateCommand();
            _writeBlobCommand.CommandText = "UPDATE [dbo].[BenchmarkTable]"
                + " SET [Memo]=@Memo WHERE [Value]=@Old_Value";
            _writeBlobCommand.Parameters.Add(new SqlParameter("Memo", SqlDbType.Text));
            _writeBlobCommand.Parameters[0].Size = BlobFieldSize;
            _writeBlobCommand.Parameters.Add(new SqlParameter("Old_Value", SqlDbType.Float));
            _writeBlobCommand.Prepare();

            _transaction = _connection.BeginTransaction();
        }

        internal override int GetTableRecordCount()
        {
            string getCountSql = "SELECT COUNT(*) FROM [dbo].[BenchmarkTable]";
            using (SqlCommand getCountCommand = _connection.CreateCommand())
            {
                getCountCommand.CommandText = getCountSql;
                getCountCommand.Transaction = _transaction;
                return (int)getCountCommand.ExecuteScalar();
            }
        }

        internal override void DisconnectFromDatabase()
        {
            lock (_syncRoot)
            {
                if (_transaction != null)
                {
                    try
                    {
                        _transaction.Rollback();
                    }
                    catch
                    {
                        // Ignore..
                    }
                    _transaction = null;
                }
                if (_connection != null)
                {
                    try
                    {
                        _connection.Close();
                    }
                    catch
                    {
                        // Ignore...
                    }
                    _connection = null;
                }
            }
        }

        internal override void ExecuteInsert()
        {
            lock (_syncRoot)
            {
                ExecuteWithRetries(() =>
                {
                    _insertCommand.Transaction = _transaction;
                    _insertCommand.Parameters[0].Value = GetMachineNameValue();
                    _insertCommand.Parameters[1].Value = GetProcessIdValue();
                    _insertCommand.Parameters[2].Value = GetLastUpdateTimeValue();
                    _insertCommand.Parameters[3].Value = GetRandomValue();
                    _insertCommand.ExecuteNonQuery();
                });
            }
        }

        internal override void ExecuteUpdate()
        {
            lock (_syncRoot)
            {
                ExecuteWithRetries(() =>
                {
                    _updateCommand.Transaction = _transaction;
                    _updateCommand.Parameters[0].Value = GetMachineNameValue();
                    _updateCommand.Parameters[1].Value = GetProcessIdValue();
                    _updateCommand.Parameters[2].Value = GetLastUpdateTimeValue();
                    _updateCommand.Parameters[3].Value = GetRandomValue();
                    _updateCommand.Parameters[4].Value = GetRandomValue();
                    _updateCommand.ExecuteNonQuery();
                });
            }
        }

        internal override void ExecuteDelete()
        {
            lock (_syncRoot)
            {
                ExecuteWithRetries(() =>
                {
                    _deleteCommand.Transaction = _transaction;
                    _deleteCommand.Parameters[0].Value = GetRandomValue();
                    _deleteCommand.ExecuteNonQuery();
                });
            }
        }

        internal override void ExecuteSelect()
        {
            lock (_syncRoot)
            {
                ExecuteWithRetries(() =>
                {
                    _selectCommand.Transaction = _transaction;
                    using (SqlDataReader reader = _selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object field1 = reader.GetValue(0);
                            object field2 = reader.GetValue(1);
                            object field3 = reader.GetValue(2);
                            object field4 = reader.GetValue(3);
                        }
                    }
                });
            }
        }

        internal override void ExecuteSelectWhere()
        {
            lock (_syncRoot)
            {
                ExecuteWithRetries(() =>
                {
                    _selectWhereCommand.Transaction = _transaction;
                    _selectWhereCommand.Parameters[0].Value = GetRandomValue();
                    using (SqlDataReader reader = _selectWhereCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object field1 = reader.GetValue(0);
                            object field2 = reader.GetValue(1);
                            object field3 = reader.GetValue(2);
                            object field4 = reader.GetValue(3);
                        }
                    }
                });
            }
        }

        internal override void ExecuteReadBlob()
        {
            lock (_syncRoot)
            {
                ExecuteWithRetries(() =>
                {
                    _readBlobCommand.Transaction = _transaction;
                    _readBlobCommand.Parameters[0].Value = GetRandomValue();
                    using (SqlDataReader reader = _readBlobCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            object memoField = reader.GetValue(0);
                        }
                    }
                });
            }
        }

        internal override void ExecuteWriteBlob()
        {
            lock (_syncRoot)
            {
                ExecuteWithRetries(() =>
                {
                    _writeBlobCommand.Transaction = _transaction;
                    _writeBlobCommand.Parameters[0].Value = GetMemoValue();
                    _writeBlobCommand.Parameters[1].Value = GetRandomValue();
                    _writeBlobCommand.ExecuteNonQuery();
                });
            }
        }

        internal override void ExecuteCommit()
        {
            lock (_syncRoot)
            {
                ExecuteWithRetries(() =>
                {
                    _transaction.Commit();
                    _transaction = _connection.BeginTransaction();
                });
            }
        }

        internal override void ExecuteRollback()
        {
            lock (_syncRoot)
            {
                ExecuteWithRetries(() =>
                {
                    _transaction.Rollback();
                    _transaction = _connection.BeginTransaction();
                });
            }
        }
    }
}
