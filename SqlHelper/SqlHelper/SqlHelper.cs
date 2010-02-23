namespace DAL
{
    using System;
    using System.Collections.Concurrent;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading;

    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public static partial class SqlHelper
    {
        #region Common ( ConnectString ... )

        private static volatile string _connectString;
        public static string ConnectString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectString))
                    throw new Exception("the SQLHelper.ConnectString property must be not empty");
                return _connectString;
            }
            set { _connectString = value; }
        }

        public static void InitConnectString(
            string server = ".",
            string dbname = "Test",
            string username = "sa",
            string password = "1")
        {
            ConnectString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                server, dbname, username, password);
        }

        private static ConcurrentDictionary<int, Pair<SqlConnection, SqlTransaction>> _threadSqlElements =
            new ConcurrentDictionary<int, Pair<SqlConnection, SqlTransaction>>();

        private static Pair<SqlConnection, SqlTransaction> CurrentSqlElements
        {
            get
            {
                var se = _threadSqlElements.GetOrAdd(Thread.CurrentThread.ManagedThreadId,
                    (o) => { return new Pair<SqlConnection, SqlTransaction>(); });
                return se;
            }
        }
        private static SqlConnection CurrentConnection { get { return CurrentSqlElements.First; } }
        private static SqlTransaction CurrentTransaction { get { return CurrentSqlElements.Second; } }

        public static SqlConnection NewConnection(string connStr = null, bool isOpen = true)
        {
            var se = CurrentSqlElements;
            if (se.First != null)
                throw new Exception("u a try 2 create more than 1 common connections in 1 thread");
            var conn = new SqlConnection(connStr ?? ConnectString);
            conn.Disposed += (sender, ea) =>
            {
                se.First = null;
                se.Second = null;
            };
            if (isOpen) conn.Open();
            se.First = conn;
            return conn;
        }
        public static SqlTransaction NewTransaction()
        {
            var se = CurrentSqlElements;
            if (se.First == null)
                NewConnection();
            //else if (se.Second != null)
            //    throw new Exception("u a try 2 create more than 1 common transaction in 1 thread");
            se.Second = se.First.BeginTransaction();
            return se.Second;
        }

        #endregion

        #region Command Execute Methods

        /// <summary>
        /// 执行一个 SQL 命令对象，返加受影响行数
        /// </summary>
        public static int ExecuteNonQuery(SqlCommand cmd, SqlInfoMessageEventHandler imHandler = null)
        {
            if (cmd.Connection == null)
            {
                var se = CurrentSqlElements;
                var conn = se.First;
                int ocs = -1;
                if (conn == null) conn = new SqlConnection(ConnectString);
                else ocs = (int)conn.State;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
                if (imHandler != null) conn.InfoMessage += imHandler;
                try
                {
                    cmd.Connection = conn;
                    if (cmd.Transaction == null) cmd.Transaction = se.Second;
                    return cmd.ExecuteNonQuery();
                }
                finally
                {
                    if (imHandler != null) conn.InfoMessage -= imHandler;
                    if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                    if (ocs == -1) conn.Dispose();
                }
            }
            else
            {
                return cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// 执行一个 SQL 命令对象，返回第一行第一列的内容
        /// </summary>
        public static object ExecuteScalar(SqlCommand cmd, SqlInfoMessageEventHandler imHandler = null)
        {
            if (cmd.Connection == null)
            {
                var se = CurrentSqlElements;
                var conn = se.First;
                int ocs = -1;
                if (conn == null) conn = new SqlConnection(ConnectString);
                else ocs = (int)conn.State;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
                if (imHandler != null) conn.InfoMessage += imHandler;
                try
                {
                    cmd.Connection = conn;
                    if (cmd.Transaction == null) cmd.Transaction = se.Second;
                    return cmd.ExecuteScalar();
                }
                finally
                {
                    if (imHandler != null) conn.InfoMessage -= imHandler;
                    if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                    if (ocs == -1) conn.Dispose();
                }
            }
            else
            {
                return cmd.ExecuteScalar();
            }
        }


        /// <summary>
        /// 创建一个新连接（无事务支持），执行一个 SQL 命令对象，返回一个 DataReader（关闭的同时将关闭连接）
        /// </summary>
        public static SqlDataReader ExecuteDataReader(SqlCommand cmd)
        {
            if (cmd.Connection == null)
            {
                var se = CurrentSqlElements;
                var conn = se.First;
                int ocs = -1;
                if (conn == null) conn = new SqlConnection(ConnectString);
                else ocs = (int)conn.State;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();

                cmd.Connection = conn;
                if (cmd.Transaction == null) cmd.Transaction = se.Second;

                if (ocs == -1 || ocs == (int)ConnectionState.Closed) return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                else return cmd.ExecuteReader();
            }
            else
            {
                return cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// 执行一个 SQL 命令对象，返回一个数据集
        /// </summary>
        public static DataSet ExecuteDataSet(SqlCommand cmd, SqlInfoMessageEventHandler imHandler = null)
        {
            if (cmd.Connection == null)
            {
                var se = CurrentSqlElements;
                var conn = se.First;
                int ocs = -1;
                if (conn == null) conn = new SqlConnection(ConnectString);
                else ocs = (int)conn.State;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
                if (imHandler != null) conn.InfoMessage += imHandler;
                try
                {
                    cmd.Connection = conn;
                    if (cmd.Transaction == null) cmd.Transaction = se.Second;
                    using (var da = new SqlDataAdapter())
                    {
                        var ds = new DataSet();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return ds;
                    }
                }
                finally
                {
                    if (imHandler != null) conn.InfoMessage -= imHandler;
                    if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                    if (ocs == -1) conn.Dispose();
                }
            }
            else
            {
                using (var da = new SqlDataAdapter())
                {
                    var ds = new DataSet();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
            }
        }



        /// <summary>
        /// 执行一个 SQL 命令对象，填充一个数据集，返加受影响行数
        /// </summary>
        public static int ExecuteDataSet(DataSet ds, SqlCommand cmd, SqlInfoMessageEventHandler imHandler = null)
        {
            if (cmd.Connection == null)
            {
                var se = CurrentSqlElements;
                var conn = se.First;
                int ocs = -1;
                if (conn == null) conn = new SqlConnection(ConnectString);
                else ocs = (int)conn.State;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
                if (imHandler != null) conn.InfoMessage += imHandler;
                try
                {
                    cmd.Connection = conn;
                    if (cmd.Transaction == null) cmd.Transaction = se.Second;
                    using (var da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        return da.Fill(ds);
                    }
                }
                finally
                {
                    if (imHandler != null) conn.InfoMessage -= imHandler;
                    if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                    if (ocs == -1) conn.Dispose();
                }
            }
            else
            {
                using (var da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    return da.Fill(ds);
                }
            }
        }


        /// <summary>
        /// 执行一个 SQL 命令对象，填充一个数据表，返回受影响行数
        /// </summary>
        public static int ExecuteDataTable(DataTable dt, SqlCommand cmd, SqlInfoMessageEventHandler imHandler = null)
        {
            if (cmd.Connection == null)
            {
                var se = CurrentSqlElements;
                var conn = se.First;
                int ocs = -1;
                if (conn == null) conn = new SqlConnection(ConnectString);
                else ocs = (int)conn.State;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
                if (imHandler != null) conn.InfoMessage += imHandler;
                try
                {
                    cmd.Connection = conn;
                    if (cmd.Transaction == null) cmd.Transaction = se.Second;
                    using (var da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        return da.Fill(dt);
                    }
                }
                finally
                {
                    if (imHandler != null) conn.InfoMessage -= imHandler;
                    if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                    if (ocs == -1) conn.Dispose();
                }
            }
            else
            {
                using (var da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    return da.Fill(dt);
                }
            }
        }

        /// <summary>
        /// 执行一个 SQL 命令对象，返回一个数据表
        /// </summary>
        public static DataTable ExecuteDataTable(SqlCommand cmd, SqlInfoMessageEventHandler imHandler = null)
        {
            var ds = ExecuteDataSet(cmd, imHandler);
            if (ds.Tables.Count > 0) return ds.Tables[0];
            else return null;
        }


        /// <summary>
        /// 执行一个 SQL 命令对象，返回一个 DbSet 数据集
        /// </summary>
        public static DbSet ExecuteDbSet(SqlCommand cmd, bool isGetInfoMessage = true, SqlInfoMessageEventHandler imHandler = null)
        {
            var se = CurrentSqlElements;
            var ds = new DbSet();
            var h = new SqlInfoMessageEventHandler((sender, ea) =>
            {
                ds.Messages.Add(ea.Message);
                foreach (SqlError err in ea.Errors)
                {
                    if (err.Class == 0)
                    {
                        ds.Messages.Add(err.Message);
                        continue;
                    }
                    ds.Errors.Add(new global::SqlError
                    {
                        Class = err.Class,
                        LineNumber = err.LineNumber,
                        Message = err.Message,
                        Number = err.Number,
                        Procedure = err.Procedure,
                        Server = err.Server,
                        Source = err.Source,
                        State = err.State
                    });
                }
            });
            SqlConnection conn = null;
            if (cmd.Connection == null) conn = se.First;
            else conn = cmd.Connection;
            int ocs = -1;
            if (conn == null) conn = new SqlConnection(ConnectString);
            else ocs = (int)conn.State;
            if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
            if (isGetInfoMessage) conn.InfoMessage += h;
            if (imHandler != null) conn.InfoMessage += imHandler;
            SqlParameter returnParameter = null;
            if (!cmd.Parameters.Contains("RETURN_VALUE"))
            {
                returnParameter = new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null);
                cmd.Parameters.Add(returnParameter);
            }
            try
            {
                cmd.Connection = conn;
                if (cmd.Transaction == null) cmd.Transaction = se.Second;
                using (var r = cmd.ExecuteReader())
                {
                    do
                    {
                        using (var st = r.GetSchemaTable())
                        {
                            if (st != null)
                            {
                                var t = new DbTable();
                                for (var i = 0; i < st.Rows.Count; i++)
                                    t.NewColumn((string)st.Rows[i]["ColumnName"]
                                        , (Type)st.Rows[i]["DataType"]
                                        , (bool)st.Rows[i]["AllowDBNull"]);
                                ds.Tables.Add(t);
                                if (r.HasRows)
                                    while (r.Read())
                                    {
                                        var buffer = new object[t.Columns.Count];
                                        r.GetValues(buffer);
                                        t.NewRow(buffer);
                                    }
                            }
                        }
                    } while (r.NextResult());
                }
            }
            finally
            {
                if (returnParameter != null) cmd.Parameters.Remove(returnParameter);
                if (isGetInfoMessage) conn.InfoMessage -= h;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                if (ocs == -1) conn.Dispose();
            }
            return ds;
        }


        /// <summary>
        /// 执行一个 SQL 命令对象，返回一个 DbSet 数据集
        /// </summary>
        public static DbTable ExecuteDbTable(SqlCommand cmd, SqlInfoMessageEventHandler imHandler = null)
        {
            var se = CurrentSqlElements;
            var t = new DbTable();
            SqlConnection conn = null;
            if (cmd.Connection == null) conn = se.First;
            else conn = cmd.Connection;
            int ocs = -1;
            if (conn == null) conn = new SqlConnection(ConnectString);
            else ocs = (int)conn.State;
            if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
            if (imHandler != null) conn.InfoMessage += imHandler;
            try
            {
                cmd.Connection = conn;
                if (cmd.Transaction == null) cmd.Transaction = se.Second;
                using (var r = cmd.ExecuteReader())
                {
                    using (var st = r.GetSchemaTable())
                    {
                        if (st != null)
                        {
                            for (var i = 0; i < st.Rows.Count; i++)
                                t.NewColumn((string)st.Rows[i]["ColumnName"]
                                    , (Type)st.Rows[i]["DataType"]
                                    , (bool)st.Rows[i]["AllowDBNull"]);
                            if (r.HasRows)
                                while (r.Read())
                                {
                                    var buffer = new object[t.Columns.Count];
                                    r.GetValues(buffer);
                                    t.NewRow(buffer);
                                }
                        }
                    }
                }
            }
            finally
            {
                if (imHandler != null) conn.InfoMessage -= imHandler;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                if (ocs == -1) conn.Dispose();
            }
            return t;
        }


        #endregion

        #region TSQL String Execute Methods

        /// <summary>
        /// 执行一个 SQL 语句，返回影响行数
        /// </summary>
        public static int ExecuteNonQuery(string s, SqlInfoMessageEventHandler imHandler = null)
        {
            var se = CurrentSqlElements;
            int effect = 0;
            var conn = se.First;
            int ocs = -1;
            if (conn == null) conn = new SqlConnection(ConnectString);
            else ocs = (int)conn.State;
            if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
            if (imHandler != null) conn.InfoMessage += imHandler;
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = se.Second;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = s;
                    effect = cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (imHandler != null) conn.InfoMessage -= imHandler;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                if (ocs == -1) conn.Dispose();
            }
            return effect;
        }





        /// <summary>
        /// 执行一个 SQL 语句，返回第一行第一列的内容
        /// </summary>
        public static object ExecuteScalar(string s, SqlInfoMessageEventHandler imHandler = null)
        {
            var se = CurrentSqlElements;
            object r = null;
            var conn = se.First;
            int ocs = -1;
            if (conn == null) conn = new SqlConnection(ConnectString);
            else ocs = (int)conn.State;
            if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
            if (imHandler != null) conn.InfoMessage += imHandler;
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = se.Second;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = s;
                    r = cmd.ExecuteScalar();
                }
            }
            finally
            {
                if (imHandler != null) conn.InfoMessage -= imHandler;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                if (ocs == -1) conn.Dispose();
            }
            return r;
        }




        /// <summary>
        /// 创建一个新连接（无事务支持），执行一个 SQL 语句，返回一个 DataReader（关闭的同时将关闭连接）
        /// </summary>
        public static SqlDataReader ExecuteDataReader(string s, SqlInfoMessageEventHandler imHandler = null)
        {
            var se = CurrentSqlElements;
            SqlDataReader r = null;
            var conn = se.First;
            int ocs = -1;
            if (conn == null) conn = new SqlConnection(ConnectString);
            else ocs = (int)conn.State;
            if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
            if (imHandler != null) conn.InfoMessage += imHandler;
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = se.Second;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = s;
                    if (ocs == -1 || ocs == (int)ConnectionState.Closed) r = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    else r = cmd.ExecuteReader();
                }
            }
            finally
            {
                if (imHandler != null) conn.InfoMessage -= imHandler;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                if (ocs == -1) conn.Dispose();
            }
            return r;
        }






        /// <summary>
        /// 执行一个 SQL 语句，返回一个数据集
        /// </summary>
        public static DataSet ExecuteDataSet(string s, SqlInfoMessageEventHandler imHandler = null)
        {
            var se = CurrentSqlElements;
            DataSet ds = null;
            var conn = se.First;
            int ocs = -1;
            if (conn == null) conn = new SqlConnection(ConnectString);
            else ocs = (int)conn.State;
            if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
            if (imHandler != null) conn.InfoMessage += imHandler;
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = se.Second;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = s;
                    using (var sda = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        sda.Fill(ds);
                    }
                }
            }
            finally
            {
                if (imHandler != null) conn.InfoMessage -= imHandler;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                if (ocs == -1) conn.Dispose();
            }
            return ds;
        }




        /// <summary>
        /// 执行一个 SQL 语句，填充一个数据集，返加受影响行数
        /// </summary>
        public static int ExecuteDataSet(DataSet ds, string s, SqlInfoMessageEventHandler imHandler = null)
        {
            var se = CurrentSqlElements;
            var conn = se.First;
            int ocs = -1;
            if (conn == null) conn = new SqlConnection(ConnectString);
            else ocs = (int)conn.State;
            if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
            if (imHandler != null) conn.InfoMessage += imHandler;
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = se.Second;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = s;
                    using (var sda = new SqlDataAdapter(cmd))
                    {
                        return sda.Fill(ds);
                    }
                }
            }
            finally
            {
                if (imHandler != null) conn.InfoMessage -= imHandler;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                if (ocs == -1) conn.Dispose();
            }
        }

        /// <summary>
        /// 执行一个 SQL 语句，返回一个数据表
        /// </summary>
        public static DataTable ExecuteDataTable(string s, SqlInfoMessageEventHandler imHandler = null)
        {
            var ds = ExecuteDataSet(s, imHandler);
            if (ds.Tables.Count > 0) return ds.Tables[0];
            else return null;
        }



        /// <summary>
        /// 执行一个 SQL 语句，填充一个数据表，返加受影响行数
        /// </summary>
        public static int ExecuteDataTable(DataTable dt, string s, SqlInfoMessageEventHandler imHandler = null)
        {
            var se = CurrentSqlElements;
            var conn = se.First;
            int ocs = -1;
            if (conn == null) conn = new SqlConnection(ConnectString);
            else ocs = (int)conn.State;
            if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
            if (imHandler != null) conn.InfoMessage += imHandler;
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = se.Second;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = s;
                    using (var sda = new SqlDataAdapter(cmd))
                    {
                        return sda.Fill(dt);
                    }
                }
            }
            finally
            {
                if (imHandler != null) conn.InfoMessage -= imHandler;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                if (ocs == -1) conn.Dispose();
            }
        }


        /// <summary>
        /// 执行一段 SQL 脚本( for MS SQL200X )
        /// </summary>
        public static void ExecuteSqlScript(string sScript, ScriptExecuteHandler handler, SqlInfoMessageEventHandler imHandler = null)
        {
            string[] statements = System.Text.RegularExpressions.Regex.Split(sScript, "\\sGO\\s", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            using (var conn = new SqlConnection(ConnectString))
            {
                if (imHandler != null) conn.InfoMessage += imHandler;
                conn.Open();
                try
                {
                    using (var trans = conn.BeginTransaction())
                    {
                        foreach (var sql0 in statements)
                        {
                            var sql = sql0.Trim();
                            try
                            {
                                if (sql.ToLower().IndexOf("setuser") >= 0) continue;
                                if (sql.Length > 0)
                                {
                                    using (SqlCommand cmd = new SqlCommand())
                                    {
                                        cmd.Transaction = trans;
                                        cmd.Connection = conn;
                                        cmd.CommandType = CommandType.Text;
                                        cmd.CommandText = sql.Trim();
                                        var o = cmd.ExecuteScalar();
                                        if (handler != null) handler(new EventSQLScriptArgs(cmd.CommandText, o));
                                    }
                                }
                            }
                            catch (Exception x)
                            {
                                trans.Rollback();
                                throw new Exception(String.Format("ERROR:\n{1}\n\nSTATEMENT:\n{0}", sql, x.Message));
                            }
                        }
                        trans.Commit();
                    }
                }
                finally
                {
                    if (imHandler != null) conn.InfoMessage -= imHandler;
                    conn.Close();
                    conn.Dispose();
                }
            }
        }


        /// <summary>
        /// 执行一个 SQL 脚本文件( for MS SQL200X )
        /// </summary>
        public static void ExecuteSqlScriptFile(string fileName, ScriptExecuteHandler handler, SqlInfoMessageEventHandler imHandler = null)
        {
            string sScript = null;
            try
            {
                using (var file = new System.IO.StreamReader(fileName))
                {
                    sScript = file.ReadToEnd() + Environment.NewLine;
                    file.Close();
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                return;
            }
            catch (Exception x)
            {
                throw new Exception("Failed to read " + fileName, x);
            }

            ExecuteSqlScript(sScript, handler, imHandler);
        }

        /// <summary>
        /// 返回正在执行的脚本与返回结果的参数的委托
        /// </summary>
        public delegate void ScriptExecuteHandler(EventSQLScriptArgs ea);

        /// <summary>
        /// 正在执行的脚本与返回结果的参数
        /// </summary>
        public class EventSQLScriptArgs : EventArgs
        {
            public EventSQLScriptArgs(string sql, object returns)
            {
                Sql = sql;
                if (returns != null) Returns = returns.ToString();
            }
            public string Sql { get; set; }
            public string Returns { get; set; }
        }

        /// <summary>
        /// 执行一个 SQL 语句，返回一个 DbSet 数据集
        /// </summary>
        public static DbSet ExecuteDbSet(string s, bool isStoredProcedure = false, bool isGetInfoMessage = true, SqlInfoMessageEventHandler imHandler = null)
        {
            var se = CurrentSqlElements;
            var ds = new DbSet();
            var h = new SqlInfoMessageEventHandler((sender, ea) =>
            {
                foreach (SqlError err in ea.Errors)
                {
                    if (err.Class == 0)
                    {
                        ds.Messages.Add(err.Message);
                        continue;
                    }
                    ds.Errors.Add(new global::SqlError
                    {
                        Class = err.Class,
                        LineNumber = err.LineNumber,
                        Message = err.Message,
                        Number = err.Number,
                        Procedure = err.Procedure,
                        Server = err.Server,
                        Source = err.Source,
                        State = err.State
                    });
                }
            });
            var conn = se.First;
            int ocs = -1;
            if (conn == null) conn = new SqlConnection(ConnectString);
            else ocs = (int)conn.State;
            if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
            if (imHandler != null) conn.InfoMessage += imHandler;
            if (isGetInfoMessage) conn.InfoMessage += h;
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = se.Second;
                    cmd.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    cmd.CommandText = s;
                    cmd.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
                    using (var r = cmd.ExecuteReader())
                    {
                        do
                        {
                            using (var st = r.GetSchemaTable())
                            {
                                if (st != null)
                                {
                                    var t = new DbTable();
                                    for (var i = 0; i < st.Rows.Count; i++)
                                        t.NewColumn((string)st.Rows[i]["ColumnName"]
                                            , (Type)st.Rows[i]["DataType"]
                                            , (bool)st.Rows[i]["AllowDBNull"]);
                                    ds.Tables.Add(t);
                                    if (r.HasRows)
                                        while (r.Read())
                                        {
                                            var buffer = new object[t.Columns.Count];
                                            r.GetValues(buffer);
                                            t.NewRow(buffer);
                                        }
                                }
                            }
                        } while (r.NextResult());
                        ds.RecordsAffected = r.RecordsAffected;
                    }
                    var o = cmd.Parameters["RETURN_VALUE"].Value;
                    if (o == null || o == DBNull.Value) ds.ReturnValue = 0;
                    ds.ReturnValue = (int)o;
                }
            }
            finally
            {
                if (isGetInfoMessage) conn.InfoMessage -= h;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                if (ocs == -1) conn.Dispose();
            }
            return ds;
        }


        /// <summary>
        /// 执行一个 SQL 语句，返回一个 DbTable 数据表
        /// </summary>
        public static DbTable ExecuteDbTable(string s, SqlInfoMessageEventHandler imHandler = null)
        {
            var se = CurrentSqlElements;
            var t = new DbTable();
            var conn = se.First;
            int ocs = -1;
            if (conn == null) conn = new SqlConnection(ConnectString);
            else ocs = (int)conn.State;
            if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Open();
            if (imHandler != null) conn.InfoMessage += imHandler;
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = se.Second;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = s;
                    using (var r = cmd.ExecuteReader())
                    {
                        using (var st = r.GetSchemaTable())
                        {
                            if (st != null)
                            {
                                for (var i = 0; i < st.Rows.Count; i++)
                                    t.NewColumn((string)st.Rows[i]["ColumnName"]
                                        , (Type)st.Rows[i]["DataType"]
                                        , (bool)st.Rows[i]["AllowDBNull"]);
                                if (r.HasRows)
                                    while (r.Read())
                                    {
                                        var buffer = new object[t.Columns.Count];
                                        r.GetValues(buffer);
                                        t.NewRow(buffer);
                                    }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (imHandler != null) conn.InfoMessage -= imHandler;
                if (ocs == -1 || ocs == (int)ConnectionState.Closed) conn.Close();
                if (ocs == -1) conn.Dispose();
            }
            return t;
        }


        #endregion
    }
}