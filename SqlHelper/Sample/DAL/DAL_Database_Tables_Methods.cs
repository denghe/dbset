using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using SqlLib;

namespace DAL.Database.Tables.dbo
{

    partial class Formula_890
    {
        public static List<Formula_890> Select(Queries.Tables.dbo.Formula_890 q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<Formula_890>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                while(reader.Read())
                {
                    rows.Add(new Formula_890
                    {
                        Name = reader.GetString(0),
                        Expression = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Value = reader.IsDBNull(2) ? null : reader.GetString(2),
                        IsGenerator = reader.IsDBNull(3) ? null : new bool?(reader.GetBoolean(3))
                    });
                }
            }
            return rows;
        }

        public static List<Formula_890> Select(
            Expressions.Tables.dbo.Formula_890.Handler where = null
            , Orientations.Tables.dbo.Formula_890.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.Formula_890.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.Formula_890.New(where, orderby, pageSize, pageIndex, columns));
        }

    }
    partial class FS
    {
        public static List<FS> Select(Queries.Tables.dbo.FS q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<FS>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                while(reader.Read())
                {
                    rows.Add(new FS
                    {
                        ID = reader.GetGuid(0),
                        Category = reader.GetValue(1),
                        Stream = reader.IsDBNull(2) ? null : reader.GetSqlBinary(2).Value
                    });
                }
            }
            return rows;
        }

        public static List<FS> Select(
            Expressions.Tables.dbo.FS.Handler where = null
            , Orientations.Tables.dbo.FS.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.FS.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.FS.New(where, orderby, pageSize, pageIndex, columns));
        }

    }
    partial class ParentChildOrg
    {
        public static List<ParentChildOrg> Select(Queries.Tables.dbo.ParentChildOrg q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<ParentChildOrg>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                while(reader.Read())
                {
                    rows.Add(new ParentChildOrg
                    {
                        EmployeeID = reader.GetInt32(0),
                        ManagerId = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1)),
                        EmployeeName = reader.IsDBNull(2) ? null : reader.GetString(2)
                    });
                }
            }
            return rows;
        }

        public static List<ParentChildOrg> Select(
            Expressions.Tables.dbo.ParentChildOrg.Handler where = null
            , Orientations.Tables.dbo.ParentChildOrg.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.ParentChildOrg.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.ParentChildOrg.New(where, orderby, pageSize, pageIndex, columns));
        }

    }
    partial class t
    {
        public static List<t> Select(Queries.Tables.dbo.t q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<t>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                while(reader.Read())
                {
                    rows.Add(new t
                    {
                        a = reader.GetInt32(0),
                        b = reader.GetInt32(1),
                        c = reader.GetSqlBinary(2).Value
                    });
                }
            }
            return rows;
        }

        public static List<t> Select(
            Expressions.Tables.dbo.t.Handler where = null
            , Orientations.Tables.dbo.t.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.t.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.t.New(where, orderby, pageSize, pageIndex, columns));
        }

    }
    partial class t1
    {
        public static List<t1> Select(Queries.Tables.dbo.t1 q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<t1>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                while(reader.Read())
                {
                    rows.Add(new t1
                    {
                        ID = reader.GetInt32(0),
                        PID = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1))
                    });
                }
            }
            return rows;
        }

        public static List<t1> Select(
            Expressions.Tables.dbo.t1.Handler where = null
            , Orientations.Tables.dbo.t1.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.t1.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.t1.New(where, orderby, pageSize, pageIndex, columns));
        }

    }
    partial class t2
    {
        public static List<t2> Select(Queries.Tables.dbo.t2 q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<t2>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                while(reader.Read())
                {
                    rows.Add(new t2
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        CreateTime = reader.GetDateTime(2)
                    });
                }
            }
            return rows;
        }

        public static List<t2> Select(
            Expressions.Tables.dbo.t2.Handler where = null
            , Orientations.Tables.dbo.t2.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.t2.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.t2.New(where, orderby, pageSize, pageIndex, columns));
        }

    }
    partial class tree
    {
        public static List<tree> Select(Queries.Tables.dbo.tree q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<tree>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                while(reader.Read())
                {
                    rows.Add(new tree
                    {
                        Parent = reader.GetString(0),
                        Children = reader.IsDBNull(1) ? null : reader.GetString(1)
                    });
                }
            }
            return rows;
        }

        public static List<tree> Select(
            Expressions.Tables.dbo.tree.Handler where = null
            , Orientations.Tables.dbo.tree.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.tree.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.tree.New(where, orderby, pageSize, pageIndex, columns));
        }

    }
}
namespace DAL.Database.Tables.MySchema
{

    partial class FS
    {
        public static List<FS> Select(Queries.Tables.MySchema.FS q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<FS>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                while(reader.Read())
                {
                    rows.Add(new FS
                    {
                        dbo_FSID = reader.GetGuid(0),
                        asdf = reader.IsDBNull(1) ? null : reader.GetString(1),
                        ID = reader.GetInt32(2)
                    });
                }
            }
            return rows;
        }

        public static List<FS> Select(
            Expressions.Tables.MySchema.FS.Handler where = null
            , Orientations.Tables.MySchema.FS.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.MySchema.FS.Handler columns = null
            )
        {
            return Select(Queries.Tables.MySchema.FS.New(where, orderby, pageSize, pageIndex, columns));
        }

    }
}
namespace DAL.Database.Tables.Schema1
{

    partial class T1
    {
        public static List<T1> Select(Queries.Tables.Schema1.T1 q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<T1>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                while(reader.Read())
                {
                    rows.Add(new T1
                    {
                        ID = reader.GetInt32(0),
                        PID = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1))
                    });
                }
            }
            return rows;
        }

        public static List<T1> Select(
            Expressions.Tables.Schema1.T1.Handler where = null
            , Orientations.Tables.Schema1.T1.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.Schema1.T1.Handler columns = null
            )
        {
            return Select(Queries.Tables.Schema1.T1.New(where, orderby, pageSize, pageIndex, columns));
        }

    }
}