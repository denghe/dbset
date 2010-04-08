using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SqlLib;

namespace DAL.Database.Tables.dbo
{

    partial class Child
    {

        #region Select

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

        public static List<Child> Select(Tree parent, Queries.Tables.dbo.Child.Handler query = null) {
            if(query == null) return Child.Select(where: o => o.TreeID == parent.TreeID);
            var q = query(new Queries.Tables.dbo.Child());
            if(q.Where == null) q.SetWhere(o => o.TreeID == parent.TreeID);
            else q.Where.And(o => o.TreeID == parent.TreeID);
            return Child.Select(q);
        }

        #endregion

        #region Insert

		public static int Insert(Child o, ColumnEnums.Tables.dbo.Child ics = null, ColumnEnums.Tables.dbo.Child fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[Child] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("TreeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TreeID", DataRowVersion.Current, o.TreeID));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[TreeID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@TreeID");
				isFirst = false;
			}
			if (ics == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("ChildID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "ChildID", DataRowVersion.Current, o.ChildID));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[ChildID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@ChildID");
				isFirst = false;
			}
			if (ics == null || ics.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, o.Name));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Name]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Name");
				isFirst = false;
			}
			if (ics == null || ics.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("CreateTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "CreateTime", DataRowVersion.Current, o.CreateTime));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[CreateTime]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@CreateTime");
				isFirst = false;
			}
			if (ics == null || ics.Contains(4))
			{
                cmd.Parameters.Add(new SqlParameter("Memo", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Memo", DataRowVersion.Current, o.Memo));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Memo]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Memo");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fcs == null) {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                    sb.Append(@" VALUES (");
                }
            }
            else sb.Append(@"
) 
VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
            if(!isFillAfterInsert)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.TreeID = reader.GetInt32(0);
                        o.ChildID = reader.GetGuid(1);
                        o.Name = reader.GetString(2);
                        o.CreateTime = reader.GetDateTime(3);
                        o.Memo = reader.GetString(4);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.TreeID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.ChildID = reader.GetGuid(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.Name = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.CreateTime = reader.GetDateTime(i); i++; }
                            else if(i < fccount && fcs.Contains(4)) {o.Memo = reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(Child o, ColumnEnums.Tables.dbo.Child.Handler insertCols = null, ColumnEnums.Tables.dbo.Child.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.dbo.Child()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.Child()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(Child o, Expressions.Tables.dbo.Child eh = null, ColumnEnums.Tables.dbo.Child ucs = null, ColumnEnums.Tables.dbo.Child fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[Child]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("TreeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TreeID", DataRowVersion.Current, o.TreeID));
				sb.Append((isFirst ? @"" : @"
     , ") + "[TreeID] = @TreeID");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("ChildID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "ChildID", DataRowVersion.Current, o.ChildID));
				sb.Append((isFirst ? @"" : @"
     , ") + "[ChildID] = @ChildID");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, o.Name));
				sb.Append((isFirst ? @"" : @"
     , ") + "[Name] = @Name");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("CreateTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "CreateTime", DataRowVersion.Current, o.CreateTime));
				sb.Append((isFirst ? @"" : @"
     , ") + "[CreateTime] = @CreateTime");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(4))
			{
                cmd.Parameters.Add(new SqlParameter("Memo", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Memo", DataRowVersion.Current, o.Memo));
				sb.Append((isFirst ? @"" : @"
     , ") + "[Memo] = @Memo");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fcs == null) {
                    sb.Append(@"
OUTPUT INSERTED.*");
                }
                else {
                    sb.Append(@"
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                }
            }

            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    sb.Append(@"
 WHERE " + ws);
            }
			cmd.CommandText = sb.ToString();
			if (!isFillAfterUpdate)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.TreeID = reader.GetInt32(0);
                        o.ChildID = reader.GetGuid(1);
                        o.Name = reader.GetString(2);
                        o.CreateTime = reader.GetDateTime(3);
                        o.Memo = reader.GetString(4);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.TreeID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.ChildID = reader.GetGuid(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.Name = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.CreateTime = reader.GetDateTime(i); i++; }
                            else if(i < fccount && fcs.Contains(4)) {o.Memo = reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(Child o, Expressions.Tables.dbo.Child.Handler eh = null, ColumnEnums.Tables.dbo.Child.Handler updateCols = null, ColumnEnums.Tables.dbo.Child.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.dbo.Child()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.dbo.Child()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.Child()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.Child eh)
		{
			var s = @"
DELETE FROM [dbo].[Child]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.dbo.Child.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.dbo.Child()));
        }
        #endregion

    }
    partial class ChildLog
    {

        #region Select

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

        public static List<ChildLog> Select(Child parent, Queries.Tables.dbo.ChildLog.Handler query = null) {
            if(query == null) return ChildLog.Select(where: o => o.ChildID == parent.ChildID);
            var q = query(new Queries.Tables.dbo.ChildLog());
            if(q.Where == null) q.SetWhere(o => o.ChildID == parent.ChildID);
            else q.Where.And(o => o.ChildID == parent.ChildID);
            return ChildLog.Select(q);
        }

        #endregion

        #region Insert

		public static int Insert(ChildLog o, ColumnEnums.Tables.dbo.ChildLog ics = null, ColumnEnums.Tables.dbo.ChildLog fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[ChildLog] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("ChildID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "ChildID", DataRowVersion.Current, o.ChildID));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[ChildID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@ChildID");
				isFirst = false;
			}
			if (ics == null || ics.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("CreateTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "CreateTime", DataRowVersion.Current, o.CreateTime));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[CreateTime]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@CreateTime");
				isFirst = false;
			}
			if (ics == null || ics.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("LogContent", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "LogContent", DataRowVersion.Current, o.LogContent));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[LogContent]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@LogContent");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fcs == null) {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                    sb.Append(@" VALUES (");
                }
            }
            else sb.Append(@"
) 
VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
            if(!isFillAfterInsert)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.ChildID = reader.GetGuid(0);
                        o.ChildLogID = reader.GetInt32(1);
                        o.CreateTime = reader.GetDateTime(2);
                        o.LogContent = reader.GetString(3);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ChildID = reader.GetGuid(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.ChildLogID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.CreateTime = reader.GetDateTime(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.LogContent = reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(ChildLog o, ColumnEnums.Tables.dbo.ChildLog.Handler insertCols = null, ColumnEnums.Tables.dbo.ChildLog.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.dbo.ChildLog()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.ChildLog()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(ChildLog o, Expressions.Tables.dbo.ChildLog eh = null, ColumnEnums.Tables.dbo.ChildLog ucs = null, ColumnEnums.Tables.dbo.ChildLog fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[ChildLog]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("ChildID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "ChildID", DataRowVersion.Current, o.ChildID));
				sb.Append((isFirst ? @"" : @"
     , ") + "[ChildID] = @ChildID");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("CreateTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "CreateTime", DataRowVersion.Current, o.CreateTime));
				sb.Append((isFirst ? @"" : @"
     , ") + "[CreateTime] = @CreateTime");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("LogContent", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "LogContent", DataRowVersion.Current, o.LogContent));
				sb.Append((isFirst ? @"" : @"
     , ") + "[LogContent] = @LogContent");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fcs == null) {
                    sb.Append(@"
OUTPUT INSERTED.*");
                }
                else {
                    sb.Append(@"
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                }
            }

            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    sb.Append(@"
 WHERE " + ws);
            }
			cmd.CommandText = sb.ToString();
			if (!isFillAfterUpdate)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.ChildID = reader.GetGuid(0);
                        o.ChildLogID = reader.GetInt32(1);
                        o.CreateTime = reader.GetDateTime(2);
                        o.LogContent = reader.GetString(3);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ChildID = reader.GetGuid(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.ChildLogID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.CreateTime = reader.GetDateTime(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.LogContent = reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(ChildLog o, Expressions.Tables.dbo.ChildLog.Handler eh = null, ColumnEnums.Tables.dbo.ChildLog.Handler updateCols = null, ColumnEnums.Tables.dbo.ChildLog.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.dbo.ChildLog()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.dbo.ChildLog()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.ChildLog()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.ChildLog eh)
		{
			var s = @"
DELETE FROM [dbo].[ChildLog]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.dbo.ChildLog.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.dbo.ChildLog()));
        }
        #endregion

    }
    partial class DoublePK
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(DoublePK o, ColumnEnums.Tables.dbo.DoublePK ics = null, ColumnEnums.Tables.dbo.DoublePK fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[DoublePK] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("ID1", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ID1", DataRowVersion.Current, o.ID1));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[ID1]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@ID1");
				isFirst = false;
			}
			if (ics == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("ID2", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ID2", DataRowVersion.Current, o.ID2));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[ID2]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@ID2");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fcs == null) {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                    sb.Append(@" VALUES (");
                }
            }
            else sb.Append(@"
) 
VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
            if(!isFillAfterInsert)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.ID1 = reader.GetInt32(0);
                        o.ID2 = reader.GetInt32(1);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ID1 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.ID2 = reader.GetInt32(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(DoublePK o, ColumnEnums.Tables.dbo.DoublePK.Handler insertCols = null, ColumnEnums.Tables.dbo.DoublePK.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.dbo.DoublePK()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.DoublePK()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(DoublePK o, Expressions.Tables.dbo.DoublePK eh = null, ColumnEnums.Tables.dbo.DoublePK ucs = null, ColumnEnums.Tables.dbo.DoublePK fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[DoublePK]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("ID1", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ID1", DataRowVersion.Current, o.ID1));
				sb.Append((isFirst ? @"" : @"
     , ") + "[ID1] = @ID1");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("ID2", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ID2", DataRowVersion.Current, o.ID2));
				sb.Append((isFirst ? @"" : @"
     , ") + "[ID2] = @ID2");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fcs == null) {
                    sb.Append(@"
OUTPUT INSERTED.*");
                }
                else {
                    sb.Append(@"
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                }
            }

            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    sb.Append(@"
 WHERE " + ws);
            }
			cmd.CommandText = sb.ToString();
			if (!isFillAfterUpdate)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.ID1 = reader.GetInt32(0);
                        o.ID2 = reader.GetInt32(1);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ID1 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.ID2 = reader.GetInt32(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(DoublePK o, Expressions.Tables.dbo.DoublePK.Handler eh = null, ColumnEnums.Tables.dbo.DoublePK.Handler updateCols = null, ColumnEnums.Tables.dbo.DoublePK.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.dbo.DoublePK()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.dbo.DoublePK()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.DoublePK()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.DoublePK eh)
		{
			var s = @"
DELETE FROM [dbo].[DoublePK]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.dbo.DoublePK.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.dbo.DoublePK()));
        }
        #endregion

    }
    partial class Orders
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(Orders o, ColumnEnums.Tables.dbo.Orders ics = null, ColumnEnums.Tables.dbo.Orders fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[Orders] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("memberID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "memberID", DataRowVersion.Current, o.memberID));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[memberID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@memberID");
				isFirst = false;
			}
			if (ics == null || ics.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("orderDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "orderDate", DataRowVersion.Current, o.orderDate));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[orderDate]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@orderDate");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fcs == null) {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                    sb.Append(@" VALUES (");
                }
            }
            else sb.Append(@"
) 
VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
            if(!isFillAfterInsert)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.OrderID = reader.GetInt32(0);
                        o.memberID = reader.GetInt32(1);
                        o.orderDate = reader.GetDateTime(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.OrderID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.memberID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.orderDate = reader.GetDateTime(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(Orders o, ColumnEnums.Tables.dbo.Orders.Handler insertCols = null, ColumnEnums.Tables.dbo.Orders.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.dbo.Orders()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.Orders()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(Orders o, Expressions.Tables.dbo.Orders eh = null, ColumnEnums.Tables.dbo.Orders ucs = null, ColumnEnums.Tables.dbo.Orders fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[Orders]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("memberID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "memberID", DataRowVersion.Current, o.memberID));
				sb.Append((isFirst ? @"" : @"
     , ") + "[memberID] = @memberID");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("orderDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "orderDate", DataRowVersion.Current, o.orderDate));
				sb.Append((isFirst ? @"" : @"
     , ") + "[orderDate] = @orderDate");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fcs == null) {
                    sb.Append(@"
OUTPUT INSERTED.*");
                }
                else {
                    sb.Append(@"
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                }
            }

            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    sb.Append(@"
 WHERE " + ws);
            }
			cmd.CommandText = sb.ToString();
			if (!isFillAfterUpdate)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.OrderID = reader.GetInt32(0);
                        o.memberID = reader.GetInt32(1);
                        o.orderDate = reader.GetDateTime(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.OrderID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.memberID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.orderDate = reader.GetDateTime(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(Orders o, Expressions.Tables.dbo.Orders.Handler eh = null, ColumnEnums.Tables.dbo.Orders.Handler updateCols = null, ColumnEnums.Tables.dbo.Orders.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.dbo.Orders()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.dbo.Orders()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.Orders()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.Orders eh)
		{
			var s = @"
DELETE FROM [dbo].[Orders]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.dbo.Orders.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.dbo.Orders()));
        }
        #endregion

    }
    partial class t1
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(t1 o, ColumnEnums.Tables.dbo.t1 ics = null, ColumnEnums.Tables.dbo.t1 fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[t1] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, o.Name));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Name]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Name");
				isFirst = false;
			}
			if (ics == null || ics.Contains(2))
			{
                var p = new SqlParameter("XML", SqlDbType.Xml, -1, ParameterDirection.Input, false, 0, 0, "XML", DataRowVersion.Current, null);
                if (o.XML == null) p.Value = DBNull.Value; else p.Value = o.XML;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[XML]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@XML");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fcs == null) {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                    sb.Append(@" VALUES (");
                }
            }
            else sb.Append(@"
) 
VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
            if(!isFillAfterInsert)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.ID = reader.GetInt32(0);
                        o.Name = reader.GetString(1);
                        o.XML = reader.IsDBNull(2) ? null : reader.GetString(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.Name = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.XML = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(t1 o, ColumnEnums.Tables.dbo.t1.Handler insertCols = null, ColumnEnums.Tables.dbo.t1.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.dbo.t1()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.t1()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(t1 o, Expressions.Tables.dbo.t1 eh = null, ColumnEnums.Tables.dbo.t1 ucs = null, ColumnEnums.Tables.dbo.t1 fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[t1]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, o.Name));
				sb.Append((isFirst ? @"" : @"
     , ") + "[Name] = @Name");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(2))
			{
                var p = new SqlParameter("XML", SqlDbType.Xml, -1, ParameterDirection.Input, false, 0, 0, "XML", DataRowVersion.Current, null);
                if (o.XML == null) p.Value = DBNull.Value; else p.Value = o.XML;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[XML] = @XML");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fcs == null) {
                    sb.Append(@"
OUTPUT INSERTED.*");
                }
                else {
                    sb.Append(@"
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                }
            }

            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    sb.Append(@"
 WHERE " + ws);
            }
			cmd.CommandText = sb.ToString();
			if (!isFillAfterUpdate)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.ID = reader.GetInt32(0);
                        o.Name = reader.GetString(1);
                        o.XML = reader.IsDBNull(2) ? null : reader.GetString(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.Name = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.XML = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(t1 o, Expressions.Tables.dbo.t1.Handler eh = null, ColumnEnums.Tables.dbo.t1.Handler updateCols = null, ColumnEnums.Tables.dbo.t1.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.dbo.t1()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.dbo.t1()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.t1()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.t1 eh)
		{
			var s = @"
DELETE FROM [dbo].[t1]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.dbo.t1.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.dbo.t1()));
        }
        #endregion

    }
    partial class TA
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(TA o, ColumnEnums.Tables.dbo.TA ics = null, ColumnEnums.Tables.dbo.TA fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[TA] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(0))
			{
                var p = new SqlParameter("AID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AID", DataRowVersion.Current, null);
                if (o.AID == null) p.Value = DBNull.Value; else p.Value = o.AID;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[AID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@AID");
				isFirst = false;
			}
			if (ics == null || ics.Contains(1))
			{
                var p = new SqlParameter("AData", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "AData", DataRowVersion.Current, null);
                if (o.AData == null) p.Value = DBNull.Value; else p.Value = o.AData;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[AData]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@AData");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fcs == null) {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                    sb.Append(@" VALUES (");
                }
            }
            else sb.Append(@"
) 
VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
            if(!isFillAfterInsert)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.AID = reader.IsDBNull(0) ? null : new int?(reader.GetInt32(0));
                        o.AData = reader.IsDBNull(1) ? null : reader.GetString(1);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.AID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.AData = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(TA o, ColumnEnums.Tables.dbo.TA.Handler insertCols = null, ColumnEnums.Tables.dbo.TA.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.dbo.TA()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.TA()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(TA o, Expressions.Tables.dbo.TA eh = null, ColumnEnums.Tables.dbo.TA ucs = null, ColumnEnums.Tables.dbo.TA fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[TA]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(0))
			{
                var p = new SqlParameter("AID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "AID", DataRowVersion.Current, null);
                if (o.AID == null) p.Value = DBNull.Value; else p.Value = o.AID;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[AID] = @AID");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(1))
			{
                var p = new SqlParameter("AData", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "AData", DataRowVersion.Current, null);
                if (o.AData == null) p.Value = DBNull.Value; else p.Value = o.AData;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[AData] = @AData");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fcs == null) {
                    sb.Append(@"
OUTPUT INSERTED.*");
                }
                else {
                    sb.Append(@"
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                }
            }

            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    sb.Append(@"
 WHERE " + ws);
            }
			cmd.CommandText = sb.ToString();
			if (!isFillAfterUpdate)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.AID = reader.IsDBNull(0) ? null : new int?(reader.GetInt32(0));
                        o.AData = reader.IsDBNull(1) ? null : reader.GetString(1);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.AID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.AData = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(TA o, Expressions.Tables.dbo.TA.Handler eh = null, ColumnEnums.Tables.dbo.TA.Handler updateCols = null, ColumnEnums.Tables.dbo.TA.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.dbo.TA()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.dbo.TA()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.TA()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.TA eh)
		{
			var s = @"
DELETE FROM [dbo].[TA]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.dbo.TA.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.dbo.TA()));
        }
        #endregion

    }
    partial class TB
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(TB o, ColumnEnums.Tables.dbo.TB ics = null, ColumnEnums.Tables.dbo.TB fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[TB] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(0))
			{
                var p = new SqlParameter("BID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "BID", DataRowVersion.Current, null);
                if (o.BID == null) p.Value = DBNull.Value; else p.Value = o.BID;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[BID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@BID");
				isFirst = false;
			}
			if (ics == null || ics.Contains(1))
			{
                var p = new SqlParameter("BData", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "BData", DataRowVersion.Current, null);
                if (o.BData == null) p.Value = DBNull.Value; else p.Value = o.BData;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[BData]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@BData");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fcs == null) {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                    sb.Append(@" VALUES (");
                }
            }
            else sb.Append(@"
) 
VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
            if(!isFillAfterInsert)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.BID = reader.IsDBNull(0) ? null : new int?(reader.GetInt32(0));
                        o.BData = reader.IsDBNull(1) ? null : reader.GetString(1);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.BID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.BData = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(TB o, ColumnEnums.Tables.dbo.TB.Handler insertCols = null, ColumnEnums.Tables.dbo.TB.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.dbo.TB()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.TB()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(TB o, Expressions.Tables.dbo.TB eh = null, ColumnEnums.Tables.dbo.TB ucs = null, ColumnEnums.Tables.dbo.TB fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[TB]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(0))
			{
                var p = new SqlParameter("BID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "BID", DataRowVersion.Current, null);
                if (o.BID == null) p.Value = DBNull.Value; else p.Value = o.BID;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[BID] = @BID");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(1))
			{
                var p = new SqlParameter("BData", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "BData", DataRowVersion.Current, null);
                if (o.BData == null) p.Value = DBNull.Value; else p.Value = o.BData;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[BData] = @BData");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fcs == null) {
                    sb.Append(@"
OUTPUT INSERTED.*");
                }
                else {
                    sb.Append(@"
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                }
            }

            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    sb.Append(@"
 WHERE " + ws);
            }
			cmd.CommandText = sb.ToString();
			if (!isFillAfterUpdate)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.BID = reader.IsDBNull(0) ? null : new int?(reader.GetInt32(0));
                        o.BData = reader.IsDBNull(1) ? null : reader.GetString(1);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.BID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.BData = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(TB o, Expressions.Tables.dbo.TB.Handler eh = null, ColumnEnums.Tables.dbo.TB.Handler updateCols = null, ColumnEnums.Tables.dbo.TB.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.dbo.TB()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.dbo.TB()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.TB()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.TB eh)
		{
			var s = @"
DELETE FROM [dbo].[TB]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.dbo.TB.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.dbo.TB()));
        }
        #endregion

    }
    partial class Tree
    {

        #region Select

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

        public static List<Tree> Select(Tree parent, Queries.Tables.dbo.Tree.Handler query = null) {
            if(query == null) return Tree.Select(where: o => o.TreePID == parent.TreeID);
            var q = query(new Queries.Tables.dbo.Tree());
            if(q.Where == null) q.SetWhere(o => o.TreePID == parent.TreeID);
            else q.Where.And(o => o.TreePID == parent.TreeID);
            return Tree.Select(q);
        }

        #endregion

        #region Insert

		public static int Insert(Tree o, ColumnEnums.Tables.dbo.Tree ics = null, ColumnEnums.Tables.dbo.Tree fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[Tree] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("TreeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TreeID", DataRowVersion.Current, o.TreeID));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[TreeID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@TreeID");
				isFirst = false;
			}
			if (ics == null || ics.Contains(1))
			{
                var p = new SqlParameter("TreePID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TreePID", DataRowVersion.Current, null);
                if (o.TreePID == null) p.Value = DBNull.Value; else p.Value = o.TreePID;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[TreePID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@TreePID");
				isFirst = false;
			}
			if (ics == null || ics.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, o.Name));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Name]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Name");
				isFirst = false;
			}
			if (ics == null || ics.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("Memo", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Memo", DataRowVersion.Current, o.Memo));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Memo]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Memo");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fcs == null) {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                    sb.Append(@" VALUES (");
                }
            }
            else sb.Append(@"
) 
VALUES (");
			sb.Append(sb2);
			sb.Append(@"
);");
			cmd.CommandText = sb.ToString();
            if(!isFillAfterInsert)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.TreeID = reader.GetInt32(0);
                        o.TreePID = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1));
                        o.Name = reader.GetString(2);
                        o.Memo = reader.GetString(3);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.TreeID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.TreePID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.Name = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.Memo = reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(Tree o, ColumnEnums.Tables.dbo.Tree.Handler insertCols = null, ColumnEnums.Tables.dbo.Tree.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.dbo.Tree()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.Tree()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(Tree o, Expressions.Tables.dbo.Tree eh = null, ColumnEnums.Tables.dbo.Tree ucs = null, ColumnEnums.Tables.dbo.Tree fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[Tree]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("TreeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TreeID", DataRowVersion.Current, o.TreeID));
				sb.Append((isFirst ? @"" : @"
     , ") + "[TreeID] = @TreeID");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(1))
			{
                var p = new SqlParameter("TreePID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "TreePID", DataRowVersion.Current, null);
                if (o.TreePID == null) p.Value = DBNull.Value; else p.Value = o.TreePID;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[TreePID] = @TreePID");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, o.Name));
				sb.Append((isFirst ? @"" : @"
     , ") + "[Name] = @Name");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("Memo", SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Memo", DataRowVersion.Current, o.Memo));
				sb.Append((isFirst ? @"" : @"
     , ") + "[Memo] = @Memo");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fcs == null) {
                    sb.Append(@"
OUTPUT INSERTED.*");
                }
                else {
                    sb.Append(@"
OUTPUT ");
                    for(int i = 0; i < fccount; i++) {
                        if(i > 0) sb.Append(@", ");
                        sb.Append(@"INSERTED.[" + fcs.GetColumnName(i).Replace("]", "]]") + "]");
                    }
                }
            }

            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    sb.Append(@"
 WHERE " + ws);
            }
			cmd.CommandText = sb.ToString();
			if (!isFillAfterUpdate)
                return SqlHelper.ExecuteNonQuery(cmd);

            using(var reader = SqlHelper.ExecuteDataReader(cmd))
            {
                if(fccount == 0)
                {
                    while(reader.Read())
                    {
                        o.TreeID = reader.GetInt32(0);
                        o.TreePID = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1));
                        o.Name = reader.GetString(2);
                        o.Memo = reader.GetString(3);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.TreeID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.TreePID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.Name = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.Memo = reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(Tree o, Expressions.Tables.dbo.Tree.Handler eh = null, ColumnEnums.Tables.dbo.Tree.Handler updateCols = null, ColumnEnums.Tables.dbo.Tree.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.dbo.Tree()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.dbo.Tree()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.dbo.Tree()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.Tree eh)
		{
			var s = @"
DELETE FROM [dbo].[Tree]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.dbo.Tree.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.dbo.Tree()));
        }
        #endregion

    }
}