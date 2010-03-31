using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SqlLib;

namespace DAL.Database.Tables.dbo
{

    partial class Formula_890
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(Formula_890 o, ColumnEnums.Tables.dbo.Formula_890.Handler insertCols = null, ColumnEnums.Tables.dbo.Formula_890.Handler fillCols = null, bool isFillAfterInsert = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[Formula_890] (");
			var sb2 = new StringBuilder();
            var ics = insertCols == null ? null : insertCols.Invoke(new ColumnEnums.Tables.dbo.Formula_890());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.Formula_890());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (insertCols == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("Name", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, o.Name));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Name]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Name");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(1))
			{
                var p = new SqlParameter("Expression", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "Expression", DataRowVersion.Current, null);
                if (o.Expression == null) p.Value = DBNull.Value; else p.Value = o.Expression;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Expression]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Expression");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(2))
			{
                var p = new SqlParameter("Value", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "Value", DataRowVersion.Current, null);
                if (o.Value == null) p.Value = DBNull.Value; else p.Value = o.Value;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Value]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Value");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(3))
			{
                var p = new SqlParameter("IsGenerator", SqlDbType.Bit, 1, ParameterDirection.Input, false, 1, 0, "IsGenerator", DataRowVersion.Current, null);
                if (o.IsGenerator == null) p.Value = DBNull.Value; else p.Value = o.IsGenerator;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[IsGenerator]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@IsGenerator");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fillCols == null) {
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
                        o.Name = reader.GetString(0);
                        o.Expression = reader.IsDBNull(1) ? null : reader.GetString(1);
                        o.Value = reader.IsDBNull(2) ? null : reader.GetString(2);
                        o.IsGenerator = reader.IsDBNull(3) ? null : new bool?(reader.GetBoolean(3));
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.Name = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.Expression = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.Value = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.IsGenerator = reader.IsDBNull(i) ? null : new bool?(reader.GetBoolean(i)); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}
        #endregion

        #region Update

		public static int Update(Formula_890 o, Expressions.Tables.dbo.Formula_890.Handler eh = null, ColumnEnums.Tables.dbo.Formula_890.Handler updateCols = null, ColumnEnums.Tables.dbo.Formula_890.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[Formula_890]
   SET ");
            var ucs = updateCols == null ? null : updateCols.Invoke(new ColumnEnums.Tables.dbo.Formula_890());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.Formula_890());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (updateCols == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("Name", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, o.Name));
				sb.Append((isFirst ? @"" : @"
     , ") + "[Name] = @Name");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(1))
			{
                var p = new SqlParameter("Expression", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "Expression", DataRowVersion.Current, null);
                if (o.Expression == null) p.Value = DBNull.Value; else p.Value = o.Expression;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[Expression] = @Expression");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(2))
			{
                var p = new SqlParameter("Value", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "Value", DataRowVersion.Current, null);
                if (o.Value == null) p.Value = DBNull.Value; else p.Value = o.Value;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[Value] = @Value");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(3))
			{
                var p = new SqlParameter("IsGenerator", SqlDbType.Bit, 1, ParameterDirection.Input, false, 1, 0, "IsGenerator", DataRowVersion.Current, null);
                if (o.IsGenerator == null) p.Value = DBNull.Value; else p.Value = o.IsGenerator;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[IsGenerator] = @IsGenerator");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fillCols == null) {
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
                var ws = eh.Invoke(new Expressions.Tables.dbo.Formula_890()).ToString();
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
                        o.Name = reader.GetString(0);
                        o.Expression = reader.IsDBNull(1) ? null : reader.GetString(1);
                        o.Value = reader.IsDBNull(2) ? null : reader.GetString(2);
                        o.IsGenerator = reader.IsDBNull(3) ? null : new bool?(reader.GetBoolean(3));
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.Name = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.Expression = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.Value = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.IsGenerator = reader.IsDBNull(i) ? null : new bool?(reader.GetBoolean(i)); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.Formula_890.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[Formula_890]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.Formula_890()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        #endregion

    }
    partial class FS
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(FS o, ColumnEnums.Tables.dbo.FS.Handler insertCols = null, ColumnEnums.Tables.dbo.FS.Handler fillCols = null, bool isFillAfterInsert = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[FS] (");
			var sb2 = new StringBuilder();
            var ics = insertCols == null ? null : insertCols.Invoke(new ColumnEnums.Tables.dbo.FS());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.FS());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (insertCols == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("ID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Current, o.ID));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[ID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@ID");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("Category", SqlDbType.Variant, 892, ParameterDirection.Input, false, 0, 0, "Category", DataRowVersion.Current, o.Category));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Category]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Category");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(2))
			{
                var p = new SqlParameter("Stream", SqlDbType.VarBinary, -1, ParameterDirection.Input, false, 0, 0, "Stream", DataRowVersion.Current, null);
                if (o.Stream == null) p.Value = DBNull.Value; else p.Value = o.Stream;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Stream]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Stream");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fillCols == null) {
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
                        o.ID = reader.GetGuid(0);
                        o.Category = reader.GetValue(1);
                        o.Stream = reader.IsDBNull(2) ? null : reader.GetSqlBinary(2).Value;
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ID = reader.GetGuid(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.Category = reader.GetValue(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.Stream = reader.IsDBNull(i) ? null : reader.GetSqlBinary(i).Value; i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}
        #endregion

        #region Update

		public static int Update(FS o, Expressions.Tables.dbo.FS.Handler eh = null, ColumnEnums.Tables.dbo.FS.Handler updateCols = null, ColumnEnums.Tables.dbo.FS.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[FS]
   SET ");
            var ucs = updateCols == null ? null : updateCols.Invoke(new ColumnEnums.Tables.dbo.FS());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.FS());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (updateCols == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("ID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Current, o.ID));
				sb.Append((isFirst ? @"" : @"
     , ") + "[ID] = @ID");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("Category", SqlDbType.Variant, 892, ParameterDirection.Input, false, 0, 0, "Category", DataRowVersion.Current, o.Category));
				sb.Append((isFirst ? @"" : @"
     , ") + "[Category] = @Category");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(2))
			{
                var p = new SqlParameter("Stream", SqlDbType.VarBinary, -1, ParameterDirection.Input, false, 0, 0, "Stream", DataRowVersion.Current, null);
                if (o.Stream == null) p.Value = DBNull.Value; else p.Value = o.Stream;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[Stream] = @Stream");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fillCols == null) {
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
                var ws = eh.Invoke(new Expressions.Tables.dbo.FS()).ToString();
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
                        o.ID = reader.GetGuid(0);
                        o.Category = reader.GetValue(1);
                        o.Stream = reader.IsDBNull(2) ? null : reader.GetSqlBinary(2).Value;
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ID = reader.GetGuid(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.Category = reader.GetValue(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.Stream = reader.IsDBNull(i) ? null : reader.GetSqlBinary(i).Value; i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.FS.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[FS]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.FS()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        #endregion

    }
    partial class ParentChildOrg
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(ParentChildOrg o, ColumnEnums.Tables.dbo.ParentChildOrg.Handler insertCols = null, ColumnEnums.Tables.dbo.ParentChildOrg.Handler fillCols = null, bool isFillAfterInsert = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[ParentChildOrg] (");
			var sb2 = new StringBuilder();
            var ics = insertCols == null ? null : insertCols.Invoke(new ColumnEnums.Tables.dbo.ParentChildOrg());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.ParentChildOrg());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (insertCols == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("EmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "EmployeeID", DataRowVersion.Current, o.EmployeeID));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[EmployeeID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@EmployeeID");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(1))
			{
                var p = new SqlParameter("ManagerId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ManagerId", DataRowVersion.Current, null);
                if (o.ManagerId == null) p.Value = DBNull.Value; else p.Value = o.ManagerId;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[ManagerId]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@ManagerId");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(2))
			{
                var p = new SqlParameter("EmployeeName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "EmployeeName", DataRowVersion.Current, null);
                if (o.EmployeeName == null) p.Value = DBNull.Value; else p.Value = o.EmployeeName;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[EmployeeName]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@EmployeeName");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fillCols == null) {
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
                        o.EmployeeID = reader.GetInt32(0);
                        o.ManagerId = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1));
                        o.EmployeeName = reader.IsDBNull(2) ? null : reader.GetString(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.EmployeeID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.ManagerId = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.EmployeeName = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}
        #endregion

        #region Update

		public static int Update(ParentChildOrg o, Expressions.Tables.dbo.ParentChildOrg.Handler eh = null, ColumnEnums.Tables.dbo.ParentChildOrg.Handler updateCols = null, ColumnEnums.Tables.dbo.ParentChildOrg.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[ParentChildOrg]
   SET ");
            var ucs = updateCols == null ? null : updateCols.Invoke(new ColumnEnums.Tables.dbo.ParentChildOrg());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.ParentChildOrg());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (updateCols == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("EmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "EmployeeID", DataRowVersion.Current, o.EmployeeID));
				sb.Append((isFirst ? @"" : @"
     , ") + "[EmployeeID] = @EmployeeID");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(1))
			{
                var p = new SqlParameter("ManagerId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ManagerId", DataRowVersion.Current, null);
                if (o.ManagerId == null) p.Value = DBNull.Value; else p.Value = o.ManagerId;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[ManagerId] = @ManagerId");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(2))
			{
                var p = new SqlParameter("EmployeeName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "EmployeeName", DataRowVersion.Current, null);
                if (o.EmployeeName == null) p.Value = DBNull.Value; else p.Value = o.EmployeeName;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[EmployeeName] = @EmployeeName");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fillCols == null) {
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
                var ws = eh.Invoke(new Expressions.Tables.dbo.ParentChildOrg()).ToString();
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
                        o.EmployeeID = reader.GetInt32(0);
                        o.ManagerId = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1));
                        o.EmployeeName = reader.IsDBNull(2) ? null : reader.GetString(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.EmployeeID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.ManagerId = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.EmployeeName = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.ParentChildOrg.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[ParentChildOrg]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.ParentChildOrg()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        #endregion

    }
    partial class t
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(t o, ColumnEnums.Tables.dbo.t.Handler insertCols = null, ColumnEnums.Tables.dbo.t.Handler fillCols = null, bool isFillAfterInsert = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[t] (");
			var sb2 = new StringBuilder();
            var ics = insertCols == null ? null : insertCols.Invoke(new ColumnEnums.Tables.dbo.t());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.t());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (insertCols == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("a", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "a", DataRowVersion.Current, o.a));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[a]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@a");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("b", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "b", DataRowVersion.Current, o.b));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[b]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@b");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("c", SqlDbType.Binary, 50, ParameterDirection.Input, false, 0, 0, "c", DataRowVersion.Current, o.c));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[c]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@c");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fillCols == null) {
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
                        o.a = reader.GetInt32(0);
                        o.b = reader.GetInt32(1);
                        o.c = reader.GetSqlBinary(2).Value;
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.a = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.b = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.c = reader.GetSqlBinary(i).Value; i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}
        #endregion

        #region Update

		public static int Update(t o, Expressions.Tables.dbo.t.Handler eh = null, ColumnEnums.Tables.dbo.t.Handler updateCols = null, ColumnEnums.Tables.dbo.t.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[t]
   SET ");
            var ucs = updateCols == null ? null : updateCols.Invoke(new ColumnEnums.Tables.dbo.t());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.t());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (updateCols == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("a", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "a", DataRowVersion.Current, o.a));
				sb.Append((isFirst ? @"" : @"
     , ") + "[a] = @a");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("b", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "b", DataRowVersion.Current, o.b));
				sb.Append((isFirst ? @"" : @"
     , ") + "[b] = @b");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("c", SqlDbType.Binary, 50, ParameterDirection.Input, false, 0, 0, "c", DataRowVersion.Current, o.c));
				sb.Append((isFirst ? @"" : @"
     , ") + "[c] = @c");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fillCols == null) {
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
                var ws = eh.Invoke(new Expressions.Tables.dbo.t()).ToString();
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
                        o.a = reader.GetInt32(0);
                        o.b = reader.GetInt32(1);
                        o.c = reader.GetSqlBinary(2).Value;
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.a = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.b = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.c = reader.GetSqlBinary(i).Value; i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.t.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[t]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.t()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
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

        #endregion

        #region Insert

		public static int Insert(t1 o, ColumnEnums.Tables.dbo.t1.Handler insertCols = null, ColumnEnums.Tables.dbo.t1.Handler fillCols = null, bool isFillAfterInsert = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[t1] (");
			var sb2 = new StringBuilder();
            var ics = insertCols == null ? null : insertCols.Invoke(new ColumnEnums.Tables.dbo.t1());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.t1());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (insertCols == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ID", DataRowVersion.Current, o.ID));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[ID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@ID");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(1))
			{
                var p = new SqlParameter("PID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PID", DataRowVersion.Current, null);
                if (o.PID == null) p.Value = DBNull.Value; else p.Value = o.PID;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[PID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@PID");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fillCols == null) {
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
                        o.PID = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1));
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.PID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}
        #endregion

        #region Update

		public static int Update(t1 o, Expressions.Tables.dbo.t1.Handler eh = null, ColumnEnums.Tables.dbo.t1.Handler updateCols = null, ColumnEnums.Tables.dbo.t1.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[t1]
   SET ");
            var ucs = updateCols == null ? null : updateCols.Invoke(new ColumnEnums.Tables.dbo.t1());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.t1());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (updateCols == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ID", DataRowVersion.Current, o.ID));
				sb.Append((isFirst ? @"" : @"
     , ") + "[ID] = @ID");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(1))
			{
                var p = new SqlParameter("PID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PID", DataRowVersion.Current, null);
                if (o.PID == null) p.Value = DBNull.Value; else p.Value = o.PID;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[PID] = @PID");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fillCols == null) {
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
                var ws = eh.Invoke(new Expressions.Tables.dbo.t1()).ToString();
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
                        o.PID = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1));
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.PID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        #endregion

        #region Delete

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
        #endregion

    }
    partial class t2
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(t2 o, ColumnEnums.Tables.dbo.t2.Handler insertCols = null, ColumnEnums.Tables.dbo.t2.Handler fillCols = null, bool isFillAfterInsert = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[t2] (");
			var sb2 = new StringBuilder();
            var ics = insertCols == null ? null : insertCols.Invoke(new ColumnEnums.Tables.dbo.t2());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.t2());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (insertCols == null || ics.Contains(1))
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
			if (insertCols == null || ics.Contains(2))
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
            if(isFillAfterInsert) {
                if(fillCols == null) {
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
                        o.CreateTime = reader.GetDateTime(2);
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
                            else if(i < fccount && fcs.Contains(2)) {o.CreateTime = reader.GetDateTime(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}
        #endregion

        #region Update

		public static int Update(t2 o, Expressions.Tables.dbo.t2.Handler eh = null, ColumnEnums.Tables.dbo.t2.Handler updateCols = null, ColumnEnums.Tables.dbo.t2.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[t2]
   SET ");
            var ucs = updateCols == null ? null : updateCols.Invoke(new ColumnEnums.Tables.dbo.t2());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.t2());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (updateCols == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, o.Name));
				sb.Append((isFirst ? @"" : @"
     , ") + "[Name] = @Name");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("CreateTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 23, 3, "CreateTime", DataRowVersion.Current, o.CreateTime));
				sb.Append((isFirst ? @"" : @"
     , ") + "[CreateTime] = @CreateTime");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fillCols == null) {
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
                var ws = eh.Invoke(new Expressions.Tables.dbo.t2()).ToString();
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
                        o.CreateTime = reader.GetDateTime(2);
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
                            else if(i < fccount && fcs.Contains(2)) {o.CreateTime = reader.GetDateTime(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.t2.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[t2]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.t2()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        #endregion

    }
    partial class tree
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(tree o, ColumnEnums.Tables.dbo.tree.Handler insertCols = null, ColumnEnums.Tables.dbo.tree.Handler fillCols = null, bool isFillAfterInsert = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [dbo].[tree] (");
			var sb2 = new StringBuilder();
            var ics = insertCols == null ? null : insertCols.Invoke(new ColumnEnums.Tables.dbo.tree());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.tree());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (insertCols == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("Parent", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "Parent", DataRowVersion.Current, o.Parent));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Parent]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Parent");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(1))
			{
                var p = new SqlParameter("Children", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "Children", DataRowVersion.Current, null);
                if (o.Children == null) p.Value = DBNull.Value; else p.Value = o.Children;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[Children]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@Children");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fillCols == null) {
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
                        o.Parent = reader.GetString(0);
                        o.Children = reader.IsDBNull(1) ? null : reader.GetString(1);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.Parent = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.Children = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}
        #endregion

        #region Update

		public static int Update(tree o, Expressions.Tables.dbo.tree.Handler eh = null, ColumnEnums.Tables.dbo.tree.Handler updateCols = null, ColumnEnums.Tables.dbo.tree.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [dbo].[tree]
   SET ");
            var ucs = updateCols == null ? null : updateCols.Invoke(new ColumnEnums.Tables.dbo.tree());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.dbo.tree());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (updateCols == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("Parent", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "Parent", DataRowVersion.Current, o.Parent));
				sb.Append((isFirst ? @"" : @"
     , ") + "[Parent] = @Parent");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(1))
			{
                var p = new SqlParameter("Children", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "Children", DataRowVersion.Current, null);
                if (o.Children == null) p.Value = DBNull.Value; else p.Value = o.Children;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[Children] = @Children");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fillCols == null) {
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
                var ws = eh.Invoke(new Expressions.Tables.dbo.tree()).ToString();
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
                        o.Parent = reader.GetString(0);
                        o.Children = reader.IsDBNull(1) ? null : reader.GetString(1);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.Parent = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.Children = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.dbo.tree.Handler eh = null)
		{
			var s = @"
DELETE FROM [dbo].[tree]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.dbo.tree()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        #endregion

    }
}
namespace DAL.Database.Tables.MySchema
{

    partial class FS
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(FS o, ColumnEnums.Tables.MySchema.FS.Handler insertCols = null, ColumnEnums.Tables.MySchema.FS.Handler fillCols = null, bool isFillAfterInsert = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [MySchema].[FS] (");
			var sb2 = new StringBuilder();
            var ics = insertCols == null ? null : insertCols.Invoke(new ColumnEnums.Tables.MySchema.FS());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.MySchema.FS());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (insertCols == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("dbo_FSID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "dbo_FSID", DataRowVersion.Current, o.dbo_FSID));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[dbo_FSID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@dbo_FSID");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(1))
			{
                var p = new SqlParameter("asdf", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "asdf", DataRowVersion.Current, null);
                if (o.asdf == null) p.Value = DBNull.Value; else p.Value = o.asdf;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[asdf]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@asdf");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fillCols == null) {
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
                        o.dbo_FSID = reader.GetGuid(0);
                        o.asdf = reader.IsDBNull(1) ? null : reader.GetString(1);
                        o.ID = reader.GetInt32(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.dbo_FSID = reader.GetGuid(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.asdf = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.ID = reader.GetInt32(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}
        #endregion

        #region Update

		public static int Update(FS o, Expressions.Tables.MySchema.FS.Handler eh = null, ColumnEnums.Tables.MySchema.FS.Handler updateCols = null, ColumnEnums.Tables.MySchema.FS.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [MySchema].[FS]
   SET ");
            var ucs = updateCols == null ? null : updateCols.Invoke(new ColumnEnums.Tables.MySchema.FS());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.MySchema.FS());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (updateCols == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("dbo_FSID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "dbo_FSID", DataRowVersion.Current, o.dbo_FSID));
				sb.Append((isFirst ? @"" : @"
     , ") + "[dbo_FSID] = @dbo_FSID");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(1))
			{
                var p = new SqlParameter("asdf", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "asdf", DataRowVersion.Current, null);
                if (o.asdf == null) p.Value = DBNull.Value; else p.Value = o.asdf;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[asdf] = @asdf");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fillCols == null) {
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
                var ws = eh.Invoke(new Expressions.Tables.MySchema.FS()).ToString();
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
                        o.dbo_FSID = reader.GetGuid(0);
                        o.asdf = reader.IsDBNull(1) ? null : reader.GetString(1);
                        o.ID = reader.GetInt32(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.dbo_FSID = reader.GetGuid(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.asdf = reader.IsDBNull(i) ? null : reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.ID = reader.GetInt32(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.MySchema.FS.Handler eh = null)
		{
			var s = @"
DELETE FROM [MySchema].[FS]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.MySchema.FS()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        #endregion

    }
}
namespace DAL.Database.Tables.Schema1
{

    partial class T1
    {

        #region Select

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

        #endregion

        #region Insert

		public static int Insert(T1 o, ColumnEnums.Tables.Schema1.T1.Handler insertCols = null, ColumnEnums.Tables.Schema1.T1.Handler fillCols = null, bool isFillAfterInsert = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [Schema1].[T1] (");
			var sb2 = new StringBuilder();
            var ics = insertCols == null ? null : insertCols.Invoke(new ColumnEnums.Tables.Schema1.T1());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.Schema1.T1());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (insertCols == null || ics.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ID", DataRowVersion.Current, o.ID));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[ID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@ID");
				isFirst = false;
			}
			if (insertCols == null || ics.Contains(1))
			{
                var p = new SqlParameter("PID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PID", DataRowVersion.Current, null);
                if (o.PID == null) p.Value = DBNull.Value; else p.Value = o.PID;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[PID]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@PID");
				isFirst = false;
			}
            if(isFillAfterInsert) {
                if(fillCols == null) {
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
                        o.PID = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1));
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.PID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}
        #endregion

        #region Update

		public static int Update(T1 o, Expressions.Tables.Schema1.T1.Handler eh = null, ColumnEnums.Tables.Schema1.T1.Handler updateCols = null, ColumnEnums.Tables.Schema1.T1.Handler fillCols = null, bool isFillAfterUpdate = true)
		{
			var isFirst = true;
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [Schema1].[T1]
   SET ");
            var ucs = updateCols == null ? null : updateCols.Invoke(new ColumnEnums.Tables.Schema1.T1());
            var fcs = fillCols == null ? null : fillCols.Invoke(new ColumnEnums.Tables.Schema1.T1());
            var fccount = fcs == null ? 0 : fcs.Count();
			if (updateCols == null || ucs.Contains(0))
			{
                cmd.Parameters.Add(new SqlParameter("ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ID", DataRowVersion.Current, o.ID));
				sb.Append((isFirst ? @"" : @"
     , ") + "[ID] = @ID");
				isFirst = false;
			}
			if (updateCols == null || ucs.Contains(1))
			{
                var p = new SqlParameter("PID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "PID", DataRowVersion.Current, null);
                if (o.PID == null) p.Value = DBNull.Value; else p.Value = o.PID;
                cmd.Parameters.Add(p);
				sb.Append((isFirst ? @"" : @"
     , ") + "[PID] = @PID");
				isFirst = false;
			}
            if(isFillAfterUpdate) {
                if(fillCols == null) {
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
                var ws = eh.Invoke(new Expressions.Tables.Schema1.T1()).ToString();
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
                        o.PID = reader.IsDBNull(1) ? null : new int?(reader.GetInt32(1));
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.ID = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.PID = reader.IsDBNull(i) ? null : new int?(reader.GetInt32(i)); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.Schema1.T1.Handler eh = null)
		{
			var s = @"
DELETE FROM [Schema1].[T1]";
            if (eh != null)
            {
                var ws = eh.Invoke(new Expressions.Tables.Schema1.T1()).ToString();
    			s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        #endregion

    }
}