using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SqlLib;

namespace DAL.Database.Tables.产品
{

    partial class 产品
    {

        #region Select

        public static List<产品> Select(Queries.Tables.产品.产品 q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<产品>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new 产品();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.产品编号 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.名称 = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.说明 = reader.GetString(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new 产品
                        {
                            产品编号 = reader.GetInt32(0),
                            名称 = reader.GetString(1),
                            说明 = reader.GetString(2)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<产品> Select(
            Expressions.Tables.产品.产品.Handler where = null
            , Orientations.Tables.产品.产品.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.产品.产品.Handler columns = null
            )
        {
            return Select(Queries.Tables.产品.产品.New(where, orderby, pageSize, pageIndex, columns));
        }

        public static 产品 Select(int c0, ColumnEnums.Tables.产品.产品.Handler columns = null)
        {
            return Select(o => o.产品编号.Equal(c0), columns: columns).FirstOrDefault();
        }

        #endregion

        #region Insert

		public static int Insert(产品 o, ColumnEnums.Tables.产品.产品 ics, ColumnEnums.Tables.产品.产品 fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [产品].[产品] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("名称", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "名称", DataRowVersion.Current, false, o.名称, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[名称]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@名称");
				isFirst = false;
			}
			if (ics == null || ics.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("说明", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "说明", DataRowVersion.Current, false, o.说明, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[说明]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@说明");
				isFirst = false;
			}
            if(isFillAfterInsert)
            {
                if(fcs == null)
                {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else
                {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++)
                    {
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
                        o.产品编号 = reader.GetInt32(0);
                        o.名称 = reader.GetString(1);
                        o.说明 = reader.GetString(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.产品编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.名称 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.说明 = reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(产品 o, ColumnEnums.Tables.产品.产品.Handler insertCols = null, ColumnEnums.Tables.产品.产品.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.产品.产品()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.产品.产品()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(产品 o, Expressions.Tables.产品.产品 eh = null, ColumnEnums.Tables.产品.产品 ucs = null, ColumnEnums.Tables.产品.产品 fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [产品].[产品]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("名称", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "名称", DataRowVersion.Current, false, o.名称, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[名称] = @名称");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("说明", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "说明", DataRowVersion.Current, false, o.说明, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[说明] = @说明");
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
                        o.产品编号 = reader.GetInt32(0);
                        o.名称 = reader.GetString(1);
                        o.说明 = reader.GetString(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.产品编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.名称 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.说明 = reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(产品 o, Expressions.Tables.产品.产品.Handler eh = null, ColumnEnums.Tables.产品.产品.Handler updateCols = null, ColumnEnums.Tables.产品.产品.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.产品.产品()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.产品.产品()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.产品.产品()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.产品.产品 eh)
		{
			var s = @"
DELETE FROM [产品].[产品]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.产品.产品.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.产品.产品()));
        }
        #endregion

        #region Others

        #region Count

        public static int Count(
            Expressions.Tables.产品.产品 where,
            ColumnEnums.Tables.产品.产品 column,
            bool isDistinct
        )
        {
            string tsql;
            if (where == null)
            {
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [产品].[产品]";
                    else tsql = "SELECT COUNT(*) FROM [产品].[产品]";
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [产品].[产品]";
                    else tsql = "SELECT COUNT(" + c + ") FROM [产品].[产品]";
                }
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [产品].[产品]" + w;
                    else tsql = "SELECT COUNT(*) FROM [产品].[产品]" + w;
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [产品].[产品]" + w;
                    else tsql = "SELECT COUNT(" + c + ") FROM [产品].[产品]" + w;
                }
            }
            return SqlHelper.ExecuteScalar<int>(tsql);
        }

        public static int Count(
            Expressions.Tables.产品.产品.Handler where = null,
            ColumnEnums.Tables.产品.产品.Handler column = null,
            bool isDistinct = false
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.产品.产品());
            var c = column == null ? null : column(new ColumnEnums.Tables.产品.产品());
            return Count(w, c, isDistinct);
        }

        #endregion

        #region Exists

        public static bool Exists(
            Expressions.Tables.产品.产品 where
        )
        {
            string tsql;
            if (where == null)
            {
                tsql = "SELECT TOP(1) 1 FROM [产品].[产品]";
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                tsql = "SELECT TOP(1) 1 FROM [产品].[产品]" + w;
            }
            var o = SqlHelper.ExecuteScalar(tsql);
            return !(o == null || o == DBNull.Value);
        }
        public static bool Exists(
            Expressions.Tables.产品.产品.Handler where = null
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.产品.产品());
            return Exists(w);
        }

        #endregion

        #endregion

    }
}
namespace DAL.Database.Tables.雇员
{

    partial class 雇员
    {

        #region Select

        public static List<雇员> Select(Queries.Tables.雇员.雇员 q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<雇员>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new 雇员();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.雇员编号 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.姓名 = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.性别 = reader.GetBoolean(i); i++; }
                            else if(i < count && cols.Contains(3)) {row.年龄 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(4)) {row.照片 = reader.GetSqlBinary(i).Value; i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new 雇员
                        {
                            雇员编号 = reader.GetInt32(0),
                            姓名 = reader.GetString(1),
                            性别 = reader.GetBoolean(2),
                            年龄 = reader.GetInt32(3),
                            照片 = reader.GetSqlBinary(4).Value
                        });
                    }
                }

            }
            return rows;
        }

        public static List<雇员> Select(
            Expressions.Tables.雇员.雇员.Handler where = null
            , Orientations.Tables.雇员.雇员.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.雇员.雇员.Handler columns = null
            )
        {
            return Select(Queries.Tables.雇员.雇员.New(where, orderby, pageSize, pageIndex, columns));
        }

        public static 雇员 Select(int c0, ColumnEnums.Tables.雇员.雇员.Handler columns = null)
        {
            return Select(o => o.雇员编号.Equal(c0), columns: columns).FirstOrDefault();
        }

        #endregion

        #region Insert

		public static int Insert(雇员 o, ColumnEnums.Tables.雇员.雇员 ics, ColumnEnums.Tables.雇员.雇员 fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [雇员].[雇员] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("姓名", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "姓名", DataRowVersion.Current, false, o.姓名, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[姓名]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@姓名");
				isFirst = false;
			}
			if (ics == null || ics.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("性别", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "性别", DataRowVersion.Current, false, o.性别, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[性别]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@性别");
				isFirst = false;
			}
			if (ics == null || ics.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("年龄", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "年龄", DataRowVersion.Current, false, o.年龄, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[年龄]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@年龄");
				isFirst = false;
			}
			if (ics == null || ics.Contains(4))
			{
                cmd.Parameters.Add(new SqlParameter("照片", SqlDbType.VarBinary, 0, ParameterDirection.Input, 0, 0, "照片", DataRowVersion.Current, false, o.照片, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[照片]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@照片");
				isFirst = false;
			}
            if(isFillAfterInsert)
            {
                if(fcs == null)
                {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else
                {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++)
                    {
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
                        o.雇员编号 = reader.GetInt32(0);
                        o.姓名 = reader.GetString(1);
                        o.性别 = reader.GetBoolean(2);
                        o.年龄 = reader.GetInt32(3);
                        o.照片 = reader.GetSqlBinary(4).Value;
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.雇员编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.姓名 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.性别 = reader.GetBoolean(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.年龄 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(4)) {o.照片 = reader.GetSqlBinary(i).Value; i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(雇员 o, ColumnEnums.Tables.雇员.雇员.Handler insertCols = null, ColumnEnums.Tables.雇员.雇员.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.雇员.雇员()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.雇员.雇员()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(雇员 o, Expressions.Tables.雇员.雇员 eh = null, ColumnEnums.Tables.雇员.雇员 ucs = null, ColumnEnums.Tables.雇员.雇员 fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [雇员].[雇员]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("姓名", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "姓名", DataRowVersion.Current, false, o.姓名, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[姓名] = @姓名");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("性别", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "性别", DataRowVersion.Current, false, o.性别, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[性别] = @性别");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("年龄", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "年龄", DataRowVersion.Current, false, o.年龄, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[年龄] = @年龄");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(4))
			{
                cmd.Parameters.Add(new SqlParameter("照片", SqlDbType.VarBinary, 0, ParameterDirection.Input, 0, 0, "照片", DataRowVersion.Current, false, o.照片, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[照片] = @照片");
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
                        o.雇员编号 = reader.GetInt32(0);
                        o.姓名 = reader.GetString(1);
                        o.性别 = reader.GetBoolean(2);
                        o.年龄 = reader.GetInt32(3);
                        o.照片 = reader.GetSqlBinary(4).Value;
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.雇员编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.姓名 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.性别 = reader.GetBoolean(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.年龄 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(4)) {o.照片 = reader.GetSqlBinary(i).Value; i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(雇员 o, Expressions.Tables.雇员.雇员.Handler eh = null, ColumnEnums.Tables.雇员.雇员.Handler updateCols = null, ColumnEnums.Tables.雇员.雇员.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.雇员.雇员()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.雇员.雇员()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.雇员.雇员()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.雇员.雇员 eh)
		{
			var s = @"
DELETE FROM [雇员].[雇员]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.雇员.雇员.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.雇员.雇员()));
        }
        #endregion

        #region Others

        #region Count

        public static int Count(
            Expressions.Tables.雇员.雇员 where,
            ColumnEnums.Tables.雇员.雇员 column,
            bool isDistinct
        )
        {
            string tsql;
            if (where == null)
            {
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [雇员].[雇员]";
                    else tsql = "SELECT COUNT(*) FROM [雇员].[雇员]";
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [雇员].[雇员]";
                    else tsql = "SELECT COUNT(" + c + ") FROM [雇员].[雇员]";
                }
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [雇员].[雇员]" + w;
                    else tsql = "SELECT COUNT(*) FROM [雇员].[雇员]" + w;
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [雇员].[雇员]" + w;
                    else tsql = "SELECT COUNT(" + c + ") FROM [雇员].[雇员]" + w;
                }
            }
            return SqlHelper.ExecuteScalar<int>(tsql);
        }

        public static int Count(
            Expressions.Tables.雇员.雇员.Handler where = null,
            ColumnEnums.Tables.雇员.雇员.Handler column = null,
            bool isDistinct = false
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.雇员.雇员());
            var c = column == null ? null : column(new ColumnEnums.Tables.雇员.雇员());
            return Count(w, c, isDistinct);
        }

        #endregion

        #region Exists

        public static bool Exists(
            Expressions.Tables.雇员.雇员 where
        )
        {
            string tsql;
            if (where == null)
            {
                tsql = "SELECT TOP(1) 1 FROM [雇员].[雇员]";
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                tsql = "SELECT TOP(1) 1 FROM [雇员].[雇员]" + w;
            }
            var o = SqlHelper.ExecuteScalar(tsql);
            return !(o == null || o == DBNull.Value);
        }
        public static bool Exists(
            Expressions.Tables.雇员.雇员.Handler where = null
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.雇员.雇员());
            return Exists(w);
        }

        #endregion

        #endregion

    }
}
namespace DAL.Database.Tables.客户
{

    partial class 订单
    {

        #region Select

        public static List<订单> Select(Queries.Tables.客户.订单 q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<订单>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new 订单();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.订单编号 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.客户编号 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.经办雇员编号 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(3)) {row.序列号 = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(4)) {row.下单时间 = reader.GetDateTime(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new 订单
                        {
                            订单编号 = reader.GetInt32(0),
                            客户编号 = reader.GetInt32(1),
                            经办雇员编号 = reader.GetInt32(2),
                            序列号 = reader.GetString(3),
                            下单时间 = reader.GetDateTime(4)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<订单> Select(
            Expressions.Tables.客户.订单.Handler where = null
            , Orientations.Tables.客户.订单.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.客户.订单.Handler columns = null
            )
        {
            return Select(Queries.Tables.客户.订单.New(where, orderby, pageSize, pageIndex, columns));
        }

        public static 订单 Select(int c0, ColumnEnums.Tables.客户.订单.Handler columns = null)
        {
            return Select(o => o.订单编号.Equal(c0), columns: columns).FirstOrDefault();
        }

        public static List<订单> Select(Database.Tables.雇员.雇员 parent, Queries.Tables.客户.订单.Handler query = null) {
            if(query == null) return 订单.Select(where: o => o.经办雇员编号 == parent.雇员编号);
            var q = query(new Queries.Tables.客户.订单());
            if(q.Where == null) q.SetWhere(o => o.经办雇员编号 == parent.雇员编号);
            else q.Where.And(o => o.经办雇员编号 == parent.雇员编号);
            return 订单.Select(q);
        }

        public static List<订单> Select(Database.Tables.客户.客户 parent, Queries.Tables.客户.订单.Handler query = null) {
            if(query == null) return 订单.Select(where: o => o.客户编号 == parent.客户编号);
            var q = query(new Queries.Tables.客户.订单());
            if(q.Where == null) q.SetWhere(o => o.客户编号 == parent.客户编号);
            else q.Where.And(o => o.客户编号 == parent.客户编号);
            return 订单.Select(q);
        }

        #endregion

        #region Insert

		public static int Insert(订单 o, ColumnEnums.Tables.客户.订单 ics, ColumnEnums.Tables.客户.订单 fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [客户].[订单] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("客户编号", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "客户编号", DataRowVersion.Current, false, o.客户编号, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[客户编号]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@客户编号");
				isFirst = false;
			}
			if (ics == null || ics.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("经办雇员编号", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "经办雇员编号", DataRowVersion.Current, false, o.经办雇员编号, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[经办雇员编号]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@经办雇员编号");
				isFirst = false;
			}
			if (ics == null || ics.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("序列号", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "序列号", DataRowVersion.Current, false, o.序列号, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[序列号]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@序列号");
				isFirst = false;
			}
			if (ics == null || ics.Contains(4))
			{
                cmd.Parameters.Add(new SqlParameter("下单时间", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "下单时间", DataRowVersion.Current, false, o.下单时间, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[下单时间]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@下单时间");
				isFirst = false;
			}
            if(isFillAfterInsert)
            {
                if(fcs == null)
                {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else
                {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++)
                    {
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
                        o.订单编号 = reader.GetInt32(0);
                        o.客户编号 = reader.GetInt32(1);
                        o.经办雇员编号 = reader.GetInt32(2);
                        o.序列号 = reader.GetString(3);
                        o.下单时间 = reader.GetDateTime(4);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.订单编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.客户编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.经办雇员编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.序列号 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(4)) {o.下单时间 = reader.GetDateTime(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(订单 o, ColumnEnums.Tables.客户.订单.Handler insertCols = null, ColumnEnums.Tables.客户.订单.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.客户.订单()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.客户.订单()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(订单 o, Expressions.Tables.客户.订单 eh = null, ColumnEnums.Tables.客户.订单 ucs = null, ColumnEnums.Tables.客户.订单 fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [客户].[订单]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("客户编号", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "客户编号", DataRowVersion.Current, false, o.客户编号, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[客户编号] = @客户编号");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("经办雇员编号", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "经办雇员编号", DataRowVersion.Current, false, o.经办雇员编号, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[经办雇员编号] = @经办雇员编号");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("序列号", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "序列号", DataRowVersion.Current, false, o.序列号, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[序列号] = @序列号");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(4))
			{
                cmd.Parameters.Add(new SqlParameter("下单时间", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "下单时间", DataRowVersion.Current, false, o.下单时间, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[下单时间] = @下单时间");
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
                        o.订单编号 = reader.GetInt32(0);
                        o.客户编号 = reader.GetInt32(1);
                        o.经办雇员编号 = reader.GetInt32(2);
                        o.序列号 = reader.GetString(3);
                        o.下单时间 = reader.GetDateTime(4);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.订单编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.客户编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.经办雇员编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.序列号 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(4)) {o.下单时间 = reader.GetDateTime(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(订单 o, Expressions.Tables.客户.订单.Handler eh = null, ColumnEnums.Tables.客户.订单.Handler updateCols = null, ColumnEnums.Tables.客户.订单.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.客户.订单()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.客户.订单()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.客户.订单()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.客户.订单 eh)
		{
			var s = @"
DELETE FROM [客户].[订单]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.客户.订单.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.客户.订单()));
        }
        #endregion

        #region Others

        #region Count

        public static int Count(
            Expressions.Tables.客户.订单 where,
            ColumnEnums.Tables.客户.订单 column,
            bool isDistinct
        )
        {
            string tsql;
            if (where == null)
            {
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [客户].[订单]";
                    else tsql = "SELECT COUNT(*) FROM [客户].[订单]";
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [客户].[订单]";
                    else tsql = "SELECT COUNT(" + c + ") FROM [客户].[订单]";
                }
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [客户].[订单]" + w;
                    else tsql = "SELECT COUNT(*) FROM [客户].[订单]" + w;
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [客户].[订单]" + w;
                    else tsql = "SELECT COUNT(" + c + ") FROM [客户].[订单]" + w;
                }
            }
            return SqlHelper.ExecuteScalar<int>(tsql);
        }

        public static int Count(
            Expressions.Tables.客户.订单.Handler where = null,
            ColumnEnums.Tables.客户.订单.Handler column = null,
            bool isDistinct = false
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.客户.订单());
            var c = column == null ? null : column(new ColumnEnums.Tables.客户.订单());
            return Count(w, c, isDistinct);
        }

        #endregion

        #region Exists

        public static bool Exists(
            Expressions.Tables.客户.订单 where
        )
        {
            string tsql;
            if (where == null)
            {
                tsql = "SELECT TOP(1) 1 FROM [客户].[订单]";
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                tsql = "SELECT TOP(1) 1 FROM [客户].[订单]" + w;
            }
            var o = SqlHelper.ExecuteScalar(tsql);
            return !(o == null || o == DBNull.Value);
        }
        public static bool Exists(
            Expressions.Tables.客户.订单.Handler where = null
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.客户.订单());
            return Exists(w);
        }

        #endregion

        #endregion

    }
    partial class 订单明细
    {

        #region Select

        public static List<订单明细> Select(Queries.Tables.客户.订单明细 q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<订单明细>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new 订单明细();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.订单明细编号 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.订单编号 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.产品编号 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(3)) {row.数量 = reader.GetDecimal(i); i++; }
                            else if(i < count && cols.Contains(4)) {row.单价 = reader.GetDecimal(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new 订单明细
                        {
                            订单明细编号 = reader.GetInt32(0),
                            订单编号 = reader.GetInt32(1),
                            产品编号 = reader.GetInt32(2),
                            数量 = reader.GetDecimal(3),
                            单价 = reader.GetDecimal(4)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<订单明细> Select(
            Expressions.Tables.客户.订单明细.Handler where = null
            , Orientations.Tables.客户.订单明细.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.客户.订单明细.Handler columns = null
            )
        {
            return Select(Queries.Tables.客户.订单明细.New(where, orderby, pageSize, pageIndex, columns));
        }

        public static 订单明细 Select(int c0, ColumnEnums.Tables.客户.订单明细.Handler columns = null)
        {
            return Select(o => o.订单明细编号.Equal(c0), columns: columns).FirstOrDefault();
        }

        public static List<订单明细> Select(Database.Tables.产品.产品 parent, Queries.Tables.客户.订单明细.Handler query = null) {
            if(query == null) return 订单明细.Select(where: o => o.产品编号 == parent.产品编号);
            var q = query(new Queries.Tables.客户.订单明细());
            if(q.Where == null) q.SetWhere(o => o.产品编号 == parent.产品编号);
            else q.Where.And(o => o.产品编号 == parent.产品编号);
            return 订单明细.Select(q);
        }

        public static List<订单明细> Select(Database.Tables.客户.订单 parent, Queries.Tables.客户.订单明细.Handler query = null) {
            if(query == null) return 订单明细.Select(where: o => o.订单编号 == parent.订单编号);
            var q = query(new Queries.Tables.客户.订单明细());
            if(q.Where == null) q.SetWhere(o => o.订单编号 == parent.订单编号);
            else q.Where.And(o => o.订单编号 == parent.订单编号);
            return 订单明细.Select(q);
        }

        #endregion

        #region Insert

		public static int Insert(订单明细 o, ColumnEnums.Tables.客户.订单明细 ics, ColumnEnums.Tables.客户.订单明细 fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [客户].[订单明细] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("订单编号", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "订单编号", DataRowVersion.Current, false, o.订单编号, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[订单编号]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@订单编号");
				isFirst = false;
			}
			if (ics == null || ics.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("产品编号", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "产品编号", DataRowVersion.Current, false, o.产品编号, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[产品编号]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@产品编号");
				isFirst = false;
			}
			if (ics == null || ics.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("数量", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "数量", DataRowVersion.Current, false, o.数量, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[数量]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@数量");
				isFirst = false;
			}
			if (ics == null || ics.Contains(4))
			{
                cmd.Parameters.Add(new SqlParameter("单价", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "单价", DataRowVersion.Current, false, o.单价, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[单价]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@单价");
				isFirst = false;
			}
            if(isFillAfterInsert)
            {
                if(fcs == null)
                {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else
                {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++)
                    {
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
                        o.订单明细编号 = reader.GetInt32(0);
                        o.订单编号 = reader.GetInt32(1);
                        o.产品编号 = reader.GetInt32(2);
                        o.数量 = reader.GetDecimal(3);
                        o.单价 = reader.GetDecimal(4);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.订单明细编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.订单编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.产品编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.数量 = reader.GetDecimal(i); i++; }
                            else if(i < fccount && fcs.Contains(4)) {o.单价 = reader.GetDecimal(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(订单明细 o, ColumnEnums.Tables.客户.订单明细.Handler insertCols = null, ColumnEnums.Tables.客户.订单明细.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.客户.订单明细()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.客户.订单明细()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(订单明细 o, Expressions.Tables.客户.订单明细 eh = null, ColumnEnums.Tables.客户.订单明细 ucs = null, ColumnEnums.Tables.客户.订单明细 fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [客户].[订单明细]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("订单编号", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "订单编号", DataRowVersion.Current, false, o.订单编号, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[订单编号] = @订单编号");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("产品编号", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "产品编号", DataRowVersion.Current, false, o.产品编号, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[产品编号] = @产品编号");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("数量", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "数量", DataRowVersion.Current, false, o.数量, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[数量] = @数量");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(4))
			{
                cmd.Parameters.Add(new SqlParameter("单价", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "单价", DataRowVersion.Current, false, o.单价, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[单价] = @单价");
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
                        o.订单明细编号 = reader.GetInt32(0);
                        o.订单编号 = reader.GetInt32(1);
                        o.产品编号 = reader.GetInt32(2);
                        o.数量 = reader.GetDecimal(3);
                        o.单价 = reader.GetDecimal(4);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.订单明细编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.订单编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.产品编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.数量 = reader.GetDecimal(i); i++; }
                            else if(i < fccount && fcs.Contains(4)) {o.单价 = reader.GetDecimal(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(订单明细 o, Expressions.Tables.客户.订单明细.Handler eh = null, ColumnEnums.Tables.客户.订单明细.Handler updateCols = null, ColumnEnums.Tables.客户.订单明细.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.客户.订单明细()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.客户.订单明细()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.客户.订单明细()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.客户.订单明细 eh)
		{
			var s = @"
DELETE FROM [客户].[订单明细]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.客户.订单明细.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.客户.订单明细()));
        }
        #endregion

        #region Others

        #region Count

        public static int Count(
            Expressions.Tables.客户.订单明细 where,
            ColumnEnums.Tables.客户.订单明细 column,
            bool isDistinct
        )
        {
            string tsql;
            if (where == null)
            {
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [客户].[订单明细]";
                    else tsql = "SELECT COUNT(*) FROM [客户].[订单明细]";
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [客户].[订单明细]";
                    else tsql = "SELECT COUNT(" + c + ") FROM [客户].[订单明细]";
                }
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [客户].[订单明细]" + w;
                    else tsql = "SELECT COUNT(*) FROM [客户].[订单明细]" + w;
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [客户].[订单明细]" + w;
                    else tsql = "SELECT COUNT(" + c + ") FROM [客户].[订单明细]" + w;
                }
            }
            return SqlHelper.ExecuteScalar<int>(tsql);
        }

        public static int Count(
            Expressions.Tables.客户.订单明细.Handler where = null,
            ColumnEnums.Tables.客户.订单明细.Handler column = null,
            bool isDistinct = false
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.客户.订单明细());
            var c = column == null ? null : column(new ColumnEnums.Tables.客户.订单明细());
            return Count(w, c, isDistinct);
        }

        #endregion

        #region Exists

        public static bool Exists(
            Expressions.Tables.客户.订单明细 where
        )
        {
            string tsql;
            if (where == null)
            {
                tsql = "SELECT TOP(1) 1 FROM [客户].[订单明细]";
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                tsql = "SELECT TOP(1) 1 FROM [客户].[订单明细]" + w;
            }
            var o = SqlHelper.ExecuteScalar(tsql);
            return !(o == null || o == DBNull.Value);
        }
        public static bool Exists(
            Expressions.Tables.客户.订单明细.Handler where = null
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.客户.订单明细());
            return Exists(w);
        }

        #endregion

        #endregion

    }
    partial class 客户
    {

        #region Select

        public static List<客户> Select(Queries.Tables.客户.客户 q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<客户>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new 客户();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.客户编号 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.姓名 = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.联系方式 = reader.GetString(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new 客户
                        {
                            客户编号 = reader.GetInt32(0),
                            姓名 = reader.GetString(1),
                            联系方式 = reader.GetString(2)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<客户> Select(
            Expressions.Tables.客户.客户.Handler where = null
            , Orientations.Tables.客户.客户.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.客户.客户.Handler columns = null
            )
        {
            return Select(Queries.Tables.客户.客户.New(where, orderby, pageSize, pageIndex, columns));
        }

        public static 客户 Select(int c0, ColumnEnums.Tables.客户.客户.Handler columns = null)
        {
            return Select(o => o.客户编号.Equal(c0), columns: columns).FirstOrDefault();
        }

        #endregion

        #region Insert

		public static int Insert(客户 o, ColumnEnums.Tables.客户.客户 ics, ColumnEnums.Tables.客户.客户 fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [客户].[客户] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("姓名", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "姓名", DataRowVersion.Current, false, o.姓名, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[姓名]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@姓名");
				isFirst = false;
			}
			if (ics == null || ics.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("联系方式", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "联系方式", DataRowVersion.Current, false, o.联系方式, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[联系方式]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@联系方式");
				isFirst = false;
			}
            if(isFillAfterInsert)
            {
                if(fcs == null)
                {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else
                {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++)
                    {
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
                        o.客户编号 = reader.GetInt32(0);
                        o.姓名 = reader.GetString(1);
                        o.联系方式 = reader.GetString(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.客户编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.姓名 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.联系方式 = reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(客户 o, ColumnEnums.Tables.客户.客户.Handler insertCols = null, ColumnEnums.Tables.客户.客户.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.客户.客户()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.客户.客户()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(客户 o, Expressions.Tables.客户.客户 eh = null, ColumnEnums.Tables.客户.客户 ucs = null, ColumnEnums.Tables.客户.客户 fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [客户].[客户]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("姓名", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "姓名", DataRowVersion.Current, false, o.姓名, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[姓名] = @姓名");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("联系方式", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "联系方式", DataRowVersion.Current, false, o.联系方式, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[联系方式] = @联系方式");
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
                        o.客户编号 = reader.GetInt32(0);
                        o.姓名 = reader.GetString(1);
                        o.联系方式 = reader.GetString(2);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.客户编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.姓名 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.联系方式 = reader.GetString(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(客户 o, Expressions.Tables.客户.客户.Handler eh = null, ColumnEnums.Tables.客户.客户.Handler updateCols = null, ColumnEnums.Tables.客户.客户.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.客户.客户()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.客户.客户()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.客户.客户()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.客户.客户 eh)
		{
			var s = @"
DELETE FROM [客户].[客户]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.客户.客户.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.客户.客户()));
        }
        #endregion

        #region Others

        #region Count

        public static int Count(
            Expressions.Tables.客户.客户 where,
            ColumnEnums.Tables.客户.客户 column,
            bool isDistinct
        )
        {
            string tsql;
            if (where == null)
            {
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [客户].[客户]";
                    else tsql = "SELECT COUNT(*) FROM [客户].[客户]";
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [客户].[客户]";
                    else tsql = "SELECT COUNT(" + c + ") FROM [客户].[客户]";
                }
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [客户].[客户]" + w;
                    else tsql = "SELECT COUNT(*) FROM [客户].[客户]" + w;
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [客户].[客户]" + w;
                    else tsql = "SELECT COUNT(" + c + ") FROM [客户].[客户]" + w;
                }
            }
            return SqlHelper.ExecuteScalar<int>(tsql);
        }

        public static int Count(
            Expressions.Tables.客户.客户.Handler where = null,
            ColumnEnums.Tables.客户.客户.Handler column = null,
            bool isDistinct = false
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.客户.客户());
            var c = column == null ? null : column(new ColumnEnums.Tables.客户.客户());
            return Count(w, c, isDistinct);
        }

        #endregion

        #region Exists

        public static bool Exists(
            Expressions.Tables.客户.客户 where
        )
        {
            string tsql;
            if (where == null)
            {
                tsql = "SELECT TOP(1) 1 FROM [客户].[客户]";
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                tsql = "SELECT TOP(1) 1 FROM [客户].[客户]" + w;
            }
            var o = SqlHelper.ExecuteScalar(tsql);
            return !(o == null || o == DBNull.Value);
        }
        public static bool Exists(
            Expressions.Tables.客户.客户.Handler where = null
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.客户.客户());
            return Exists(w);
        }

        #endregion

        #endregion

    }
}
namespace DAL.Database.Tables.系统
{

    partial class 管理员
    {

        #region Select

        public static List<管理员> Select(Queries.Tables.系统.管理员 q)
        {
            var tsql = q.ToSqlString();
            var rows = new List<管理员>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                var count = q.Columns == null ? 0 : q.Columns.Count();
                if(count > 0) {
                    while(reader.Read()) {
                        var row = new 管理员();
                        var cols = q.Columns;
                        for(int i = 0; i < count; i++) {
                            if(cols.Contains(0)) {row.管理员编号 = reader.GetInt32(i); i++; }
                            else if(i < count && cols.Contains(1)) {row.登录名 = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(2)) {row.密码 = reader.GetString(i); i++; }
                            else if(i < count && cols.Contains(3)) {row.创建时间 = reader.GetDateTime(i); i++; }
                        }
                        rows.Add(row);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        rows.Add(new 管理员
                        {
                            管理员编号 = reader.GetInt32(0),
                            登录名 = reader.GetString(1),
                            密码 = reader.GetString(2),
                            创建时间 = reader.GetDateTime(3)
                        });
                    }
                }

            }
            return rows;
        }

        public static List<管理员> Select(
            Expressions.Tables.系统.管理员.Handler where = null
            , Orientations.Tables.系统.管理员.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnEnums.Tables.系统.管理员.Handler columns = null
            )
        {
            return Select(Queries.Tables.系统.管理员.New(where, orderby, pageSize, pageIndex, columns));
        }

        public static 管理员 Select(int c0, ColumnEnums.Tables.系统.管理员.Handler columns = null)
        {
            return Select(o => o.管理员编号.Equal(c0), columns: columns).FirstOrDefault();
        }

        #endregion

        #region Insert

		public static int Insert(管理员 o, ColumnEnums.Tables.系统.管理员 ics, ColumnEnums.Tables.系统.管理员 fcs = null, bool isFillAfterInsert = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
INSERT INTO [系统].[管理员] (");
			var sb2 = new StringBuilder();
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ics == null || ics.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("登录名", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "登录名", DataRowVersion.Current, false, o.登录名, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[登录名]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@登录名");
				isFirst = false;
			}
			if (ics == null || ics.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("密码", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "密码", DataRowVersion.Current, false, o.密码, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[密码]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@密码");
				isFirst = false;
			}
			if (ics == null || ics.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("创建时间", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "创建时间", DataRowVersion.Current, false, o.创建时间, "", "", ""));
				sb.Append((isFirst ? @"
       " : @"
     , ") + "[创建时间]");
				sb2.Append((isFirst ? @"
       " : @"
     , ") + "@创建时间");
				isFirst = false;
			}
            if(isFillAfterInsert)
            {
                if(fcs == null)
                {
                    sb.Append(@"
) 
OUTPUT INSERTED.* VALUES (");
                }
                else
                {
                    sb.Append(@"
) 
OUTPUT ");
                    for(int i = 0; i < fccount; i++)
                    {
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
                        o.管理员编号 = reader.GetInt32(0);
                        o.登录名 = reader.GetString(1);
                        o.密码 = reader.GetString(2);
                        o.创建时间 = reader.GetDateTime(3);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.管理员编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.登录名 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.密码 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.创建时间 = reader.GetDateTime(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
		}

		public static int Insert(管理员 o, ColumnEnums.Tables.系统.管理员.Handler insertCols = null, ColumnEnums.Tables.系统.管理员.Handler fillCols = null, bool isFillAfterInsert = true)
		{
            return Insert(o,
                insertCols == null ? null : insertCols(new ColumnEnums.Tables.系统.管理员()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.系统.管理员()),
                isFillAfterInsert
            );
        }

        #endregion

        #region Update

		public static int Update(管理员 o, Expressions.Tables.系统.管理员 eh = null, ColumnEnums.Tables.系统.管理员 ucs = null, ColumnEnums.Tables.系统.管理员 fcs = null, bool isFillAfterUpdate = true)
		{
			var cmd = new SqlCommand();
			var sb = new StringBuilder(@"
UPDATE [系统].[管理员]
   SET ");
			var isFirst = true;
            var fccount = fcs == null ? 0 : fcs.Count();
			if (ucs == null || ucs.Contains(1))
			{
                cmd.Parameters.Add(new SqlParameter("登录名", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "登录名", DataRowVersion.Current, false, o.登录名, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[登录名] = @登录名");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(2))
			{
                cmd.Parameters.Add(new SqlParameter("密码", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "密码", DataRowVersion.Current, false, o.密码, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[密码] = @密码");
				isFirst = false;
			}
			if (ucs == null || ucs.Contains(3))
			{
                cmd.Parameters.Add(new SqlParameter("创建时间", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "创建时间", DataRowVersion.Current, false, o.创建时间, "", "", ""));
				sb.Append((isFirst ? @"" : @"
     , ") + "[创建时间] = @创建时间");
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
                        o.管理员编号 = reader.GetInt32(0);
                        o.登录名 = reader.GetString(1);
                        o.密码 = reader.GetString(2);
                        o.创建时间 = reader.GetDateTime(3);
                    }
                }
                else
                {
                    while(reader.Read())
                    {
                        for(int i = 0; i < fccount; i++)
                        {
                            if(fcs.Contains(0)) {o.管理员编号 = reader.GetInt32(i); i++; }
                            else if(i < fccount && fcs.Contains(1)) {o.登录名 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(2)) {o.密码 = reader.GetString(i); i++; }
                            else if(i < fccount && fcs.Contains(3)) {o.创建时间 = reader.GetDateTime(i); i++; }
                        }
                    }
                }
                return reader.RecordsAffected;
            }
            
		}
        public static int Update(管理员 o, Expressions.Tables.系统.管理员.Handler eh = null, ColumnEnums.Tables.系统.管理员.Handler updateCols = null, ColumnEnums.Tables.系统.管理员.Handler fillCols = null, bool isFillAfterUpdate = true)
        {
            return Update(o,
                eh == null ? null : eh(new Expressions.Tables.系统.管理员()),
                updateCols == null ? null : updateCols(new ColumnEnums.Tables.系统.管理员()),
                fillCols == null ? null : fillCols(new ColumnEnums.Tables.系统.管理员()),
                isFillAfterUpdate
            );
        }
        #endregion

        #region Delete

		public static int Delete(Expressions.Tables.系统.管理员 eh)
		{
			var s = @"
DELETE FROM [系统].[管理员]";
            if (eh != null)
            {
                var ws = eh.ToString();
                if(ws.Length > 0)
    			    s += @"
 WHERE " + ws;
            }
			return SqlHelper.ExecuteNonQuery(s);
		}
        public static int Delete(Expressions.Tables.系统.管理员.Handler eh)
        {
            return Delete(eh(new Expressions.Tables.系统.管理员()));
        }
        #endregion

        #region Others

        #region Count

        public static int Count(
            Expressions.Tables.系统.管理员 where,
            ColumnEnums.Tables.系统.管理员 column,
            bool isDistinct
        )
        {
            string tsql;
            if (where == null)
            {
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [系统].[管理员]";
                    else tsql = "SELECT COUNT(*) FROM [系统].[管理员]";
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [系统].[管理员]";
                    else tsql = "SELECT COUNT(" + c + ") FROM [系统].[管理员]";
                }
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                if (column == null)
                {
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT *) FROM [系统].[管理员]" + w;
                    else tsql = "SELECT COUNT(*) FROM [系统].[管理员]" + w;
                }
                else
                {
                    var c = column.ToString();
                    if (c.Length == 0) c = "*";
                    if (isDistinct) tsql = "SELECT COUNT(DISTINCT " + c + ") FROM [系统].[管理员]" + w;
                    else tsql = "SELECT COUNT(" + c + ") FROM [系统].[管理员]" + w;
                }
            }
            return SqlHelper.ExecuteScalar<int>(tsql);
        }

        public static int Count(
            Expressions.Tables.系统.管理员.Handler where = null,
            ColumnEnums.Tables.系统.管理员.Handler column = null,
            bool isDistinct = false
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.系统.管理员());
            var c = column == null ? null : column(new ColumnEnums.Tables.系统.管理员());
            return Count(w, c, isDistinct);
        }

        #endregion

        #region Exists

        public static bool Exists(
            Expressions.Tables.系统.管理员 where
        )
        {
            string tsql;
            if (where == null)
            {
                tsql = "SELECT TOP(1) 1 FROM [系统].[管理员]";
            }
            else
            {
                var w = where.ToString();
                if (w.Length > 0) w = " WHERE " + w;
                tsql = "SELECT TOP(1) 1 FROM [系统].[管理员]" + w;
            }
            var o = SqlHelper.ExecuteScalar(tsql);
            return !(o == null || o == DBNull.Value);
        }
        public static bool Exists(
            Expressions.Tables.系统.管理员.Handler where = null
        )
        {
            var w = where == null ? null : where(new Expressions.Tables.系统.管理员());
            return Exists(w);
        }

        #endregion

        #endregion

    }
}