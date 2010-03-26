using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using SqlLib;

namespace DAL.Database.Tables.dbo
{

    partial class Child
    {

        public static List<Child> Select(Queries.Tables.dbo.Child q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<Child>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new Child();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.TreeID = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.ChildID = reader.GetGuid(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.Name = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(3)) {row.CreateTime = reader.GetDateTime(i); i++; }
                            else if(i < count && cols.Contains(4)) {row.Memo = reader.GetString(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new Child
                        {
                            TreeID = reader.GetInt32(0),
                            ChildID = reader.GetGuid(1),
                            Name = reader.GetString(2),
                            CreateTime = reader.GetDateTime(3),
                            Memo = reader.GetString(4)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<Child> Select(
            Expressions.Tables.dbo.Child.Handler where = null
            , Orientations.Tables.dbo.Child.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.Child.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.Child.New(where, orderby, pageSize, pageIndex, columns));
        }

        public static Child Select(Guid c0, ColumnEnums.Tables.dbo.Child.Handler columns = null)
        {
            return Select(o => o.ChildID.Equal(c0), columns: columns).FirstOrDefault();
        }

		public static int Insert(Child o, ColumnEnums.Tables.dbo.Child.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[Child] (");
			var sb2 = new StringBuilder();
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.Child());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("TreeID", o.TreeID);
				sb.Append((isFirst ? "" : @"
     , ") + "[TreeID]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@TreeID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("ChildID", o.ChildID);
				sb.Append((isFirst ? "" : @"
     , ") + "[ChildID]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@ChildID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(2))
			{
				cmd.AddParameter("Name", o.Name);
				sb.Append((isFirst ? "" : @"
     , ") + "[Name]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@Name");
				isFirst = false;
			}
			if (ch == null || cols.Contains(3))
			{
				cmd.AddParameter("CreateTime", o.CreateTime);
				sb.Append((isFirst ? "" : @"
     , ") + "[CreateTime]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@CreateTime");
				isFirst = false;
			}
			if (ch == null || cols.Contains(4))
			{
				cmd.AddParameter("Memo", o.Memo);
				sb.Append((isFirst ? "" : @"
     , ") + "[Memo]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@Memo");
				isFirst = false;
			}
			sb.Append(@"
) OUTPUT INSERTED.* VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Update(Child o, Expressions.Tables.dbo.Child.Handler eh = null, ColumnEnums.Tables.dbo.Child.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[Child]
   SET ");
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.Child());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("TreeID", o.TreeID);
				sb.Append((isFirst ? "" : @"
     , ") + "[TreeID] = @TreeID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("ChildID", o.ChildID);
				sb.Append((isFirst ? "" : @"
     , ") + "[ChildID] = @ChildID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(2))
			{
				cmd.AddParameter("Name", o.Name);
				sb.Append((isFirst ? "" : @"
     , ") + "[Name] = @Name");
				isFirst = false;
			}
			if (ch == null || cols.Contains(3))
			{
				cmd.AddParameter("CreateTime", o.CreateTime);
				sb.Append((isFirst ? "" : @"
     , ") + "[CreateTime] = @CreateTime");
				isFirst = false;
			}
			if (ch == null || cols.Contains(4))
			{
				cmd.AddParameter("Memo", o.Memo);
				sb.Append((isFirst ? "" : @"
     , ") + "[Memo] = @Memo");
				isFirst = false;
			}
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.Child()).ToString();
    			sb.Append(@"
 WHERE " + ws);
            }
			sb.Append(@";");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Delete(Expressions.Tables.dbo.Child.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[Child]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.Child()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
    }
    partial class ChildLog
    {

        public static List<ChildLog> Select(Queries.Tables.dbo.ChildLog q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<ChildLog>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new ChildLog();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.ChildID = reader.GetGuid(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.ChildLogID = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.CreateTime = reader.GetDateTime(i); i++; }
                            else if(i < count && cols.Contains(3)) {row.LogContent = reader.GetString(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new ChildLog
                        {
                            ChildID = reader.GetGuid(0),
                            ChildLogID = reader.GetInt32(1),
                            CreateTime = reader.GetDateTime(2),
                            LogContent = reader.GetString(3)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<ChildLog> Select(
            Expressions.Tables.dbo.ChildLog.Handler where = null
            , Orientations.Tables.dbo.ChildLog.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.ChildLog.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.ChildLog.New(where, orderby, pageSize, pageIndex, columns));
        }

        public static ChildLog Select(int c0, ColumnEnums.Tables.dbo.ChildLog.Handler columns = null)
        {
            return Select(o => o.ChildLogID.Equal(c0), columns: columns).FirstOrDefault();
        }

		public static int Insert(ChildLog o, ColumnEnums.Tables.dbo.ChildLog.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[ChildLog] (");
			var sb2 = new StringBuilder();
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.ChildLog());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("ChildID", o.ChildID);
				sb.Append((isFirst ? "" : @"
     , ") + "[ChildID]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@ChildID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(2))
			{
				cmd.AddParameter("CreateTime", o.CreateTime);
				sb.Append((isFirst ? "" : @"
     , ") + "[CreateTime]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@CreateTime");
				isFirst = false;
			}
			if (ch == null || cols.Contains(3))
			{
				cmd.AddParameter("LogContent", o.LogContent);
				sb.Append((isFirst ? "" : @"
     , ") + "[LogContent]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@LogContent");
				isFirst = false;
			}
			sb.Append(@"
) OUTPUT INSERTED.* VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Update(ChildLog o, Expressions.Tables.dbo.ChildLog.Handler eh = null, ColumnEnums.Tables.dbo.ChildLog.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[ChildLog]
   SET ");
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.ChildLog());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("ChildID", o.ChildID);
				sb.Append((isFirst ? "" : @"
     , ") + "[ChildID] = @ChildID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(2))
			{
				cmd.AddParameter("CreateTime", o.CreateTime);
				sb.Append((isFirst ? "" : @"
     , ") + "[CreateTime] = @CreateTime");
				isFirst = false;
			}
			if (ch == null || cols.Contains(3))
			{
				cmd.AddParameter("LogContent", o.LogContent);
				sb.Append((isFirst ? "" : @"
     , ") + "[LogContent] = @LogContent");
				isFirst = false;
			}
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.ChildLog()).ToString();
    			sb.Append(@"
 WHERE " + ws);
            }
			sb.Append(@";");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Delete(Expressions.Tables.dbo.ChildLog.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[ChildLog]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.ChildLog()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
    }
    partial class DoublePK
    {

        public static List<DoublePK> Select(Queries.Tables.dbo.DoublePK q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<DoublePK>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new DoublePK();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.ID1 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.ID2 = reader.GetInt32(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new DoublePK
                        {
                            ID1 = reader.GetInt32(0),
                            ID2 = reader.GetInt32(1)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<DoublePK> Select(
            Expressions.Tables.dbo.DoublePK.Handler where = null
            , Orientations.Tables.dbo.DoublePK.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.DoublePK.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.DoublePK.New(where, orderby, pageSize, pageIndex, columns));
        }

        public static DoublePK Select(int c0, int c1, ColumnEnums.Tables.dbo.DoublePK.Handler columns = null)
        {
            return Select(o => o.ID1.Equal(c0) & o.ID2.Equal(c1), columns: columns).FirstOrDefault();
        }

		public static int Insert(DoublePK o, ColumnEnums.Tables.dbo.DoublePK.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[DoublePK] (");
			var sb2 = new StringBuilder();
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.DoublePK());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("ID1", o.ID1);
				sb.Append((isFirst ? "" : @"
     , ") + "[ID1]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@ID1");
				isFirst = false;
			}
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("ID2", o.ID2);
				sb.Append((isFirst ? "" : @"
     , ") + "[ID2]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@ID2");
				isFirst = false;
			}
			sb.Append(@"
) OUTPUT INSERTED.* VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Update(DoublePK o, Expressions.Tables.dbo.DoublePK.Handler eh = null, ColumnEnums.Tables.dbo.DoublePK.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[DoublePK]
   SET ");
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.DoublePK());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("ID1", o.ID1);
				sb.Append((isFirst ? "" : @"
     , ") + "[ID1] = @ID1");
				isFirst = false;
			}
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("ID2", o.ID2);
				sb.Append((isFirst ? "" : @"
     , ") + "[ID2] = @ID2");
				isFirst = false;
			}
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.DoublePK()).ToString();
    			sb.Append(@"
 WHERE " + ws);
            }
			sb.Append(@";");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Delete(Expressions.Tables.dbo.DoublePK.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[DoublePK]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.DoublePK()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
    }
    partial class Orders
    {

        public static List<Orders> Select(Queries.Tables.dbo.Orders q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<Orders>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new Orders();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.OrderID = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.memberID = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.orderDate = reader.GetDateTime(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new Orders
                        {
                            OrderID = reader.GetInt32(0),
                            memberID = reader.GetInt32(1),
                            orderDate = reader.GetDateTime(2)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<Orders> Select(
            Expressions.Tables.dbo.Orders.Handler where = null
            , Orientations.Tables.dbo.Orders.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.Orders.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.Orders.New(where, orderby, pageSize, pageIndex, columns));
        }

        public static Orders Select(int c0, ColumnEnums.Tables.dbo.Orders.Handler columns = null)
        {
            return Select(o => o.OrderID.Equal(c0), columns: columns).FirstOrDefault();
        }

		public static int Insert(Orders o, ColumnEnums.Tables.dbo.Orders.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[Orders] (");
			var sb2 = new StringBuilder();
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.Orders());
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("memberID", o.memberID);
				sb.Append((isFirst ? "" : @"
     , ") + "[memberID]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@memberID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(2))
			{
				cmd.AddParameter("orderDate", o.orderDate);
				sb.Append((isFirst ? "" : @"
     , ") + "[orderDate]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@orderDate");
				isFirst = false;
			}
			sb.Append(@"
) OUTPUT INSERTED.* VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Update(Orders o, Expressions.Tables.dbo.Orders.Handler eh = null, ColumnEnums.Tables.dbo.Orders.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[Orders]
   SET ");
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.Orders());
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("memberID", o.memberID);
				sb.Append((isFirst ? "" : @"
     , ") + "[memberID] = @memberID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(2))
			{
				cmd.AddParameter("orderDate", o.orderDate);
				sb.Append((isFirst ? "" : @"
     , ") + "[orderDate] = @orderDate");
				isFirst = false;
			}
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.Orders()).ToString();
    			sb.Append(@"
 WHERE " + ws);
            }
			sb.Append(@";");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Delete(Expressions.Tables.dbo.Orders.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[Orders]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.Orders()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
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
                            else if(i < count && cols.Contains(1)) {row.Name = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.XML = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
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
                            Name = reader.GetString(1),
                            XML = reader.IsDBNull(2) ? null : reader.GetString(2)
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

		public static int Insert(t1 o, ColumnEnums.Tables.dbo.t1.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[t1] (");
			var sb2 = new StringBuilder();
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.t1());
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("Name", o.Name);
				sb.Append((isFirst ? "" : @"
     , ") + "[Name]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@Name");
				isFirst = false;
			}
			if (ch == null || cols.Contains(2))
			{
				cmd.AddParameter("XML", o.XML);
				sb.Append((isFirst ? "" : @"
     , ") + "[XML]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@XML");
				isFirst = false;
			}
			sb.Append(@"
) OUTPUT INSERTED.* VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Update(t1 o, Expressions.Tables.dbo.t1.Handler eh = null, ColumnEnums.Tables.dbo.t1.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[t1]
   SET ");
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.t1());
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("Name", o.Name);
				sb.Append((isFirst ? "" : @"
     , ") + "[Name] = @Name");
				isFirst = false;
			}
			if (ch == null || cols.Contains(2))
			{
				cmd.AddParameter("XML", o.XML);
				sb.Append((isFirst ? "" : @"
     , ") + "[XML] = @XML");
				isFirst = false;
			}
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.t1()).ToString();
    			sb.Append(@"
 WHERE " + ws);
            }
			sb.Append(@";");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Delete(Expressions.Tables.dbo.t1.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[t1]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.t1()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
    }
    partial class TA
    {

        public static List<TA> Select(Queries.Tables.dbo.TA q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<TA>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new TA();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.AID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < count && cols.Contains(1)) {row.AData = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new TA
                        {
                            AID = reader.IsDBNull(0) ? null : new int?(reader.GetInt32(0)),
                            AData = reader.IsDBNull(1) ? null : reader.GetString(1)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<TA> Select(
            Expressions.Tables.dbo.TA.Handler where = null
            , Orientations.Tables.dbo.TA.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.TA.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.TA.New(where, orderby, pageSize, pageIndex, columns));
        }

		public static int Insert(TA o, ColumnEnums.Tables.dbo.TA.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[TA] (");
			var sb2 = new StringBuilder();
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.TA());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("AID", o.AID);
				sb.Append((isFirst ? "" : @"
     , ") + "[AID]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@AID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("AData", o.AData);
				sb.Append((isFirst ? "" : @"
     , ") + "[AData]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@AData");
				isFirst = false;
			}
			sb.Append(@"
) OUTPUT INSERTED.* VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Update(TA o, Expressions.Tables.dbo.TA.Handler eh = null, ColumnEnums.Tables.dbo.TA.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[TA]
   SET ");
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.TA());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("AID", o.AID);
				sb.Append((isFirst ? "" : @"
     , ") + "[AID] = @AID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("AData", o.AData);
				sb.Append((isFirst ? "" : @"
     , ") + "[AData] = @AData");
				isFirst = false;
			}
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.TA()).ToString();
    			sb.Append(@"
 WHERE " + ws);
            }
			sb.Append(@";");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Delete(Expressions.Tables.dbo.TA.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[TA]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.TA()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
    }
    partial class TB
    {

        public static List<TB> Select(Queries.Tables.dbo.TB q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<TB>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new TB();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.BID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < count && cols.Contains(1)) {row.BData = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new TB
                        {
                            BID = reader.IsDBNull(0) ? null : new int?(reader.GetInt32(0)),
                            BData = reader.IsDBNull(1) ? null : reader.GetString(1)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<TB> Select(
            Expressions.Tables.dbo.TB.Handler where = null
            , Orientations.Tables.dbo.TB.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.TB.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.TB.New(where, orderby, pageSize, pageIndex, columns));
        }

		public static int Insert(TB o, ColumnEnums.Tables.dbo.TB.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[TB] (");
			var sb2 = new StringBuilder();
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.TB());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("BID", o.BID);
				sb.Append((isFirst ? "" : @"
     , ") + "[BID]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@BID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("BData", o.BData);
				sb.Append((isFirst ? "" : @"
     , ") + "[BData]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@BData");
				isFirst = false;
			}
			sb.Append(@"
) OUTPUT INSERTED.* VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Update(TB o, Expressions.Tables.dbo.TB.Handler eh = null, ColumnEnums.Tables.dbo.TB.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[TB]
   SET ");
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.TB());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("BID", o.BID);
				sb.Append((isFirst ? "" : @"
     , ") + "[BID] = @BID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("BData", o.BData);
				sb.Append((isFirst ? "" : @"
     , ") + "[BData] = @BData");
				isFirst = false;
			}
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.TB()).ToString();
    			sb.Append(@"
 WHERE " + ws);
            }
			sb.Append(@";");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Delete(Expressions.Tables.dbo.TB.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[TB]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.TB()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
    }
    partial class Tree
    {

        public static List<Tree> Select(Queries.Tables.dbo.Tree q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<Tree>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new Tree();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.TreeID = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.TreePID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < count && cols.Contains(2)) {row.Name = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(3)) {row.Memo = reader.GetString(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new Tree
                        {
                            TreeID = reader.GetInt32(0),
                            TreePID = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1)),
                            Name = reader.GetString(2),
                            Memo = reader.GetString(3)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<Tree> Select(
            Expressions.Tables.dbo.Tree.Handler where = null
            , Orientations.Tables.dbo.Tree.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.dbo.Tree.Handler columns = null
            )
        {
            return Select(Queries.Tables.dbo.Tree.New(where, orderby, pageSize, pageIndex, columns));
        }

        public static Tree Select(int c0, ColumnEnums.Tables.dbo.Tree.Handler columns = null)
        {
            return Select(o => o.TreeID.Equal(c0), columns: columns).FirstOrDefault();
        }

		public static int Insert(Tree o, ColumnEnums.Tables.dbo.Tree.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[Tree] (");
			var sb2 = new StringBuilder();
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.Tree());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("TreeID", o.TreeID);
				sb.Append((isFirst ? "" : @"
     , ") + "[TreeID]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@TreeID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("TreePID", o.TreePID);
				sb.Append((isFirst ? "" : @"
     , ") + "[TreePID]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@TreePID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(2))
			{
				cmd.AddParameter("Name", o.Name);
				sb.Append((isFirst ? "" : @"
     , ") + "[Name]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@Name");
				isFirst = false;
			}
			if (ch == null || cols.Contains(3))
			{
				cmd.AddParameter("Memo", o.Memo);
				sb.Append((isFirst ? "" : @"
     , ") + "[Memo]");
				sb2.Append((isFirst ? "" : @"
     , ") + "@Memo");
				isFirst = false;
			}
			sb.Append(@"
) OUTPUT INSERTED.* VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Update(Tree o, Expressions.Tables.dbo.Tree.Handler eh = null, ColumnEnums.Tables.dbo.Tree.Handler ch = null)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[Tree]
   SET ");
            var cols = ch == null ? null : ch.Invoke(new ColumnEnums.Tables.dbo.Tree());
			if (ch == null || cols.Contains(0))
			{
				cmd.AddParameter("TreeID", o.TreeID);
				sb.Append((isFirst ? "" : @"
     , ") + "[TreeID] = @TreeID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(1))
			{
				cmd.AddParameter("TreePID", o.TreePID);
				sb.Append((isFirst ? "" : @"
     , ") + "[TreePID] = @TreePID");
				isFirst = false;
			}
			if (ch == null || cols.Contains(2))
			{
				cmd.AddParameter("Name", o.Name);
				sb.Append((isFirst ? "" : @"
     , ") + "[Name] = @Name");
				isFirst = false;
			}
			if (ch == null || cols.Contains(3))
			{
				cmd.AddParameter("Memo", o.Memo);
				sb.Append((isFirst ? "" : @"
     , ") + "[Memo] = @Memo");
				isFirst = false;
			}
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.Tree()).ToString();
    			sb.Append(@"
 WHERE " + ws);
            }
			sb.Append(@";");
			cmd.CommandText = sb.ToString();
			return SqlHelper.ExecuteNonQuery(cmd);
		}
		public static int Delete(Expressions.Tables.dbo.Tree.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[Tree]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.Tree()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
    }
}