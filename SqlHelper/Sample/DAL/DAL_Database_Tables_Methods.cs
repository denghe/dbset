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
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new Formula_890();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.Name = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.Expression = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.Value = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(3)) {row.IsGenerator = reader.IsDBNull(i) ? null : new bool?(reader.GetBoolean(i)); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
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

        public static Formula_890 Select(string c0, ColumnEnums.Tables.dbo.Formula_890.Handler columns = null)
        {
            return Select(o => o.Name.Equal(c0), columns: columns).FirstOrDefault();
        }

			public static int Insert(Formula_890 o, ColumnEnums.Tables.dbo.Formula_890.Handler h = null)
			{
				var isFirst = true;
				var cmd = new SqlCommand();
				var sb = new StringBuilder("INSERT INTO [dbo].[Formula_890] (");
				var sb2 = new StringBuilder();
                var cols = h.Invoke(new ColumnEnums.Tables.dbo.Formula_890());
				if (cols.Contains(0))
				{
					cmd.AddParameter("Name", o.Name);
					sb.Append((isFirst ? "" : ", ") + "[Name]");
					sb2.Append((isFirst ? "" : ", ") + "@Name");
					isFirst = false;
				}
				if (cols.Contains(1))
				{
					cmd.AddParameter("Expression", o.Expression);
					sb.Append((isFirst ? "" : ", ") + "[Expression]");
					sb2.Append((isFirst ? "" : ", ") + "@Expression");
					isFirst = false;
				}
				if (cols.Contains(2))
				{
					cmd.AddParameter("Value", o.Value);
					sb.Append((isFirst ? "" : ", ") + "[Value]");
					sb2.Append((isFirst ? "" : ", ") + "@Value");
					isFirst = false;
				}
				if (cols.Contains(3))
				{
					cmd.AddParameter("IsGenerator", o.IsGenerator);
					sb.Append((isFirst ? "" : ", ") + "[IsGenerator]");
					sb2.Append((isFirst ? "" : ", ") + "@IsGenerator");
					isFirst = false;
				}
				sb.Append(") OUTPUT INSERTED.* VALUES (");
				sb.Append(sb2);
				sb.Append(@");");
				cmd.CommandText = sb.ToString();
				return SqlHelper.ExecuteNonQuery(cmd);
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
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new FS();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.ID = reader.GetGuid(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.Category = reader.GetValue(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.Stream = reader.IsDBNull(i) ? null : reader.GetSqlBinary(i).Value; i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
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

        public static FS Select(Guid c0, ColumnEnums.Tables.dbo.FS.Handler columns = null)
        {
            return Select(o => o.ID.Equal(c0), columns: columns).FirstOrDefault();
        }

			public static int Insert(FS o, ColumnEnums.Tables.dbo.FS.Handler h = null)
			{
				var isFirst = true;
				var cmd = new SqlCommand();
				var sb = new StringBuilder("INSERT INTO [dbo].[FS] (");
				var sb2 = new StringBuilder();
                var cols = h.Invoke(new ColumnEnums.Tables.dbo.FS());
				if (cols.Contains(0))
				{
					cmd.AddParameter("ID", o.ID);
					sb.Append((isFirst ? "" : ", ") + "[ID]");
					sb2.Append((isFirst ? "" : ", ") + "@ID");
					isFirst = false;
				}
				if (cols.Contains(1))
				{
					cmd.AddParameter("Category", o.Category);
					sb.Append((isFirst ? "" : ", ") + "[Category]");
					sb2.Append((isFirst ? "" : ", ") + "@Category");
					isFirst = false;
				}
				if (cols.Contains(2))
				{
					cmd.AddParameter("Stream", o.Stream);
					sb.Append((isFirst ? "" : ", ") + "[Stream]");
					sb2.Append((isFirst ? "" : ", ") + "@Stream");
					isFirst = false;
				}
				sb.Append(") OUTPUT INSERTED.* VALUES (");
				sb.Append(sb2);
				sb.Append(@");");
				cmd.CommandText = sb.ToString();
				return SqlHelper.ExecuteNonQuery(cmd);
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
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new ParentChildOrg();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.EmployeeID = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.ManagerId = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < count && cols.Contains(2)) {row.EmployeeName = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
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

        public static ParentChildOrg Select(int c0, ColumnEnums.Tables.dbo.ParentChildOrg.Handler columns = null)
        {
            return Select(o => o.EmployeeID.Equal(c0), columns: columns).FirstOrDefault();
        }

			public static int Insert(ParentChildOrg o, ColumnEnums.Tables.dbo.ParentChildOrg.Handler h = null)
			{
				var isFirst = true;
				var cmd = new SqlCommand();
				var sb = new StringBuilder("INSERT INTO [dbo].[ParentChildOrg] (");
				var sb2 = new StringBuilder();
                var cols = h.Invoke(new ColumnEnums.Tables.dbo.ParentChildOrg());
				if (cols.Contains(0))
				{
					cmd.AddParameter("EmployeeID", o.EmployeeID);
					sb.Append((isFirst ? "" : ", ") + "[EmployeeID]");
					sb2.Append((isFirst ? "" : ", ") + "@EmployeeID");
					isFirst = false;
				}
				if (cols.Contains(1))
				{
					cmd.AddParameter("ManagerId", o.ManagerId);
					sb.Append((isFirst ? "" : ", ") + "[ManagerId]");
					sb2.Append((isFirst ? "" : ", ") + "@ManagerId");
					isFirst = false;
				}
				if (cols.Contains(2))
				{
					cmd.AddParameter("EmployeeName", o.EmployeeName);
					sb.Append((isFirst ? "" : ", ") + "[EmployeeName]");
					sb2.Append((isFirst ? "" : ", ") + "@EmployeeName");
					isFirst = false;
				}
				sb.Append(") OUTPUT INSERTED.* VALUES (");
				sb.Append(sb2);
				sb.Append(@");");
				cmd.CommandText = sb.ToString();
				return SqlHelper.ExecuteNonQuery(cmd);
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
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new t();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.a = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.b = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.c = reader.GetSqlBinary(i).Value; i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
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

			public static int Insert(t o, ColumnEnums.Tables.dbo.t.Handler h = null)
			{
				var isFirst = true;
				var cmd = new SqlCommand();
				var sb = new StringBuilder("INSERT INTO [dbo].[t] (");
				var sb2 = new StringBuilder();
                var cols = h.Invoke(new ColumnEnums.Tables.dbo.t());
				if (cols.Contains(0))
				{
					cmd.AddParameter("a", o.a);
					sb.Append((isFirst ? "" : ", ") + "[a]");
					sb2.Append((isFirst ? "" : ", ") + "@a");
					isFirst = false;
				}
				if (cols.Contains(1))
				{
					cmd.AddParameter("b", o.b);
					sb.Append((isFirst ? "" : ", ") + "[b]");
					sb2.Append((isFirst ? "" : ", ") + "@b");
					isFirst = false;
				}
				if (cols.Contains(2))
				{
					cmd.AddParameter("c", o.c);
					sb.Append((isFirst ? "" : ", ") + "[c]");
					sb2.Append((isFirst ? "" : ", ") + "@c");
					isFirst = false;
				}
				sb.Append(") OUTPUT INSERTED.* VALUES (");
				sb.Append(sb2);
				sb.Append(@");");
				cmd.CommandText = sb.ToString();
				return SqlHelper.ExecuteNonQuery(cmd);
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
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new t1();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.ID = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.PID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
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

        public static t1 Select(int c0, ColumnEnums.Tables.dbo.t1.Handler columns = null)
        {
            return Select(o => o.ID.Equal(c0), columns: columns).FirstOrDefault();
        }

			public static int Insert(t1 o, ColumnEnums.Tables.dbo.t1.Handler h = null)
			{
				var isFirst = true;
				var cmd = new SqlCommand();
				var sb = new StringBuilder("INSERT INTO [dbo].[t1] (");
				var sb2 = new StringBuilder();
                var cols = h.Invoke(new ColumnEnums.Tables.dbo.t1());
				if (cols.Contains(0))
				{
					cmd.AddParameter("ID", o.ID);
					sb.Append((isFirst ? "" : ", ") + "[ID]");
					sb2.Append((isFirst ? "" : ", ") + "@ID");
					isFirst = false;
				}
				if (cols.Contains(1))
				{
					cmd.AddParameter("PID", o.PID);
					sb.Append((isFirst ? "" : ", ") + "[PID]");
					sb2.Append((isFirst ? "" : ", ") + "@PID");
					isFirst = false;
				}
				sb.Append(") OUTPUT INSERTED.* VALUES (");
				sb.Append(sb2);
				sb.Append(@");");
				cmd.CommandText = sb.ToString();
				return SqlHelper.ExecuteNonQuery(cmd);
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
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new t2();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.ID = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.Name = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.CreateTime = reader.GetDateTime(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
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

        public static t2 Select(int c0, ColumnEnums.Tables.dbo.t2.Handler columns = null)
        {
            return Select(o => o.ID.Equal(c0), columns: columns).FirstOrDefault();
        }

			public static int Insert(t2 o, ColumnEnums.Tables.dbo.t2.Handler h = null)
			{
				var isFirst = true;
				var cmd = new SqlCommand();
				var sb = new StringBuilder("INSERT INTO [dbo].[t2] (");
				var sb2 = new StringBuilder();
                var cols = h.Invoke(new ColumnEnums.Tables.dbo.t2());
				if (cols.Contains(1))
				{
					cmd.AddParameter("Name", o.Name);
					sb.Append((isFirst ? "" : ", ") + "[Name]");
					sb2.Append((isFirst ? "" : ", ") + "@Name");
					isFirst = false;
				}
				if (cols.Contains(2))
				{
					cmd.AddParameter("CreateTime", o.CreateTime);
					sb.Append((isFirst ? "" : ", ") + "[CreateTime]");
					sb2.Append((isFirst ? "" : ", ") + "@CreateTime");
					isFirst = false;
				}
				sb.Append(") OUTPUT INSERTED.* VALUES (");
				sb.Append(sb2);
				sb.Append(@");");
				cmd.CommandText = sb.ToString();
				return SqlHelper.ExecuteNonQuery(cmd);
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
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new tree();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.Parent = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.Children = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
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

        public static tree Select(string c0, ColumnEnums.Tables.dbo.tree.Handler columns = null)
        {
            return Select(o => o.Parent.Equal(c0), columns: columns).FirstOrDefault();
        }

			public static int Insert(tree o, ColumnEnums.Tables.dbo.tree.Handler h = null)
			{
				var isFirst = true;
				var cmd = new SqlCommand();
				var sb = new StringBuilder("INSERT INTO [dbo].[tree] (");
				var sb2 = new StringBuilder();
                var cols = h.Invoke(new ColumnEnums.Tables.dbo.tree());
				if (cols.Contains(0))
				{
					cmd.AddParameter("Parent", o.Parent);
					sb.Append((isFirst ? "" : ", ") + "[Parent]");
					sb2.Append((isFirst ? "" : ", ") + "@Parent");
					isFirst = false;
				}
				if (cols.Contains(1))
				{
					cmd.AddParameter("Children", o.Children);
					sb.Append((isFirst ? "" : ", ") + "[Children]");
					sb2.Append((isFirst ? "" : ", ") + "@Children");
					isFirst = false;
				}
				sb.Append(") OUTPUT INSERTED.* VALUES (");
				sb.Append(sb2);
				sb.Append(@");");
				cmd.CommandText = sb.ToString();
				return SqlHelper.ExecuteNonQuery(cmd);
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
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new FS();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.dbo_FSID = reader.GetGuid(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.asdf = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.ID = reader.GetInt32(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
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

        public static FS Select(int c0, ColumnEnums.Tables.MySchema.FS.Handler columns = null)
        {
            return Select(o => o.ID.Equal(c0), columns: columns).FirstOrDefault();
        }

			public static int Insert(FS o, ColumnEnums.Tables.MySchema.FS.Handler h = null)
			{
				var isFirst = true;
				var cmd = new SqlCommand();
				var sb = new StringBuilder("INSERT INTO [MySchema].[FS] (");
				var sb2 = new StringBuilder();
                var cols = h.Invoke(new ColumnEnums.Tables.MySchema.FS());
				if (cols.Contains(0))
				{
					cmd.AddParameter("dbo_FSID", o.dbo_FSID);
					sb.Append((isFirst ? "" : ", ") + "[dbo_FSID]");
					sb2.Append((isFirst ? "" : ", ") + "@dbo_FSID");
					isFirst = false;
				}
				if (cols.Contains(1))
				{
					cmd.AddParameter("asdf", o.asdf);
					sb.Append((isFirst ? "" : ", ") + "[asdf]");
					sb2.Append((isFirst ? "" : ", ") + "@asdf");
					isFirst = false;
				}
				sb.Append(") OUTPUT INSERTED.* VALUES (");
				sb.Append(sb2);
				sb.Append(@");");
				cmd.CommandText = sb.ToString();
				return SqlHelper.ExecuteNonQuery(cmd);
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
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new T1();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.ID = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.PID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
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

        public static T1 Select(int c0, ColumnEnums.Tables.Schema1.T1.Handler columns = null)
        {
            return Select(o => o.ID.Equal(c0), columns: columns).FirstOrDefault();
        }

			public static int Insert(T1 o, ColumnEnums.Tables.Schema1.T1.Handler h = null)
			{
				var isFirst = true;
				var cmd = new SqlCommand();
				var sb = new StringBuilder("INSERT INTO [Schema1].[T1] (");
				var sb2 = new StringBuilder();
                var cols = h.Invoke(new ColumnEnums.Tables.Schema1.T1());
				if (cols.Contains(0))
				{
					cmd.AddParameter("ID", o.ID);
					sb.Append((isFirst ? "" : ", ") + "[ID]");
					sb2.Append((isFirst ? "" : ", ") + "@ID");
					isFirst = false;
				}
				if (cols.Contains(1))
				{
					cmd.AddParameter("PID", o.PID);
					sb.Append((isFirst ? "" : ", ") + "[PID]");
					sb2.Append((isFirst ? "" : ", ") + "@PID");
					isFirst = false;
				}
				sb.Append(") OUTPUT INSERTED.* VALUES (");
				sb.Append(sb2);
				sb.Append(@");");
				cmd.CommandText = sb.ToString();
				return SqlHelper.ExecuteNonQuery(cmd);
			}
    }
}