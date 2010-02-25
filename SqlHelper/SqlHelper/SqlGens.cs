using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public static class SqlGens
{
    #region SQL 拼接方法

    /// <summary>
    /// 根据一个 DataRow 对象的内容拼接成一个 Insert TSQL 语句。
    /// 要求 r 所在 Table 的表名 须和 数据表 相符， 字段名和 数据表字段名 相符，具有相同主键和只读属性。
    /// </summary>
    public static string Gen_InsertCommandText(DataRow r)
    {
        return Gen_InsertCommandText(r, null, null);
    }

    /// <summary>
    /// 根据一个 DataRow 对象的内容拼接成一个 Insert TSQL 语句。 可设置允许和禁止字段名列表。
    /// 要求 r 所在 Table 的表名 须和 数据表 相符， 字段名和 数据表字段名 相符，具有相同主键和只读属性。
    /// </summary>
    private static string Gen_InsertCommandText(DataRow r, string allowCols, string denyCols)
    {
        DataTable dt = r.Table;
        string tn = dt.TableName;

        List<string> allows;
        if (string.IsNullOrEmpty(allowCols)) allows = new List<string>();
        else allows = new List<string>(allowCols.Split(','));

        List<string> denys;
        if (string.IsNullOrEmpty(denyCols)) denys = new List<string>();
        else denys = new List<string>(denyCols.Split(','));

        StringBuilder sb = new StringBuilder("INSERT [" + tn + @"] (");
        StringBuilder sb2 = new StringBuilder();
        int counter = 0;
        foreach (DataColumn c in dt.Columns)
        {
            string cn = c.ColumnName;
            if (allows.Count > 0 && !allows.Contains(cn)) continue;
            if (denys.Count > 0 && denys.Contains(cn)) continue;
            if (c.ReadOnly) continue;
            string quote = c.DataType == typeof(string) || c.DataType == typeof(Guid) || c.DataType == typeof(DateTime) ? "'" : "";

            if (counter > 0)
            {
                sb.Append(@", ");
                sb2.Append(@", ");
            }

            sb.Append("[" + c.ColumnName + "]");
            if (c.AllowDBNull && r.IsNull(c))
            {
                sb2.Append(@"NULL");
            }
            else if (c.DataType == typeof(byte[]))
            {
                sb2.Append(((byte[])r[c]).ToHexString());
            }
            else if (c.DataType == typeof(bool))
            {
                sb2.Append((bool)r[c] ? "1" : "0");
            }
            else
            {
                if (c.DataType == typeof(string))
                {
                    sb2.Append(quote + ((string)r[c]).EscapeEqual() + quote);
                }
                else
                    sb2.Append(quote + r[c].ToString() + quote);
            }
            counter++;
        }
        sb.Append(@") VALUES (");
        sb.Append(sb2);
        sb.Append(")");

        return sb.ToString();
    }



    /// <summary>
    /// 根据一个 DataRow 对象的内容拼接成一个 Update TSQL 语句。
    /// 要求 r 所在 Table 的表名 须和 数据表 相符， 字段名和 数据表字段名 相符，具有相同主键和只读属性。
    /// </summary>
    public static string Gen_UpdateCommandText(DataRow r)
    {
        return Gen_UpdateCommandText(r, null, null);
    }

    /// <summary>
    /// 根据一个 DataRow 对象的内容拼接成一个 Update TSQL 语句。 可设置允许和禁止字段名列表。
    /// 要求 r 所在 Table 的表名 须和 数据表 相符， 字段名和 数据表字段名 相符，具有相同主键和只读属性。
    /// </summary>
    public static string Gen_UpdateCommandText(DataRow r, string allowCols, string denyCols)
    {
        DataTable dt = r.Table;
        string tn = dt.TableName;

        List<string> allows;
        if (string.IsNullOrEmpty(allowCols)) allows = new List<string>();
        else allows = new List<string>(allowCols.Split(','));

        List<string> denys;
        if (string.IsNullOrEmpty(denyCols)) denys = new List<string>();
        else denys = new List<string>(denyCols.Split(','));

        StringBuilder sb = new StringBuilder("UPDATE [" + tn + @"] SET ");
        StringBuilder sb2 = new StringBuilder();
        int counter = 0;
        foreach (DataColumn c in dt.Columns)
        {
            string cn = c.ColumnName;
            if (allows.Count > 0 && !allows.Contains(cn)) continue;
            if (denys.Count > 0 && denys.Contains(cn)) continue;
            if (c.ReadOnly) continue;
            string quote = c.DataType == typeof(string) || c.DataType == typeof(Guid) || c.DataType == typeof(DateTime) ? "'" : "";

            if (counter > 0)
            {
                sb.Append(@", ");
            }

            sb.Append("[" + c.ColumnName + "] = ");
            if (c.AllowDBNull && r.IsNull(c))
            {
                sb.Append(@"NULL");
            }
            else if (c.DataType == typeof(byte[]))
            {
                sb.Append(((byte[])r[c]).ToHexString());
            }
            else if (c.DataType == typeof(bool))
            {
                sb.Append((bool)r[c] ? "1" : "0");
            }
            else
            {
                if (c.DataType == typeof(string))
                {
                    sb.Append(quote + ((string)r[c]).EscapeEqual() + quote);
                }
                else
                    sb.Append(quote + r[c].ToString() + quote);

            }
            counter++;
        }
        sb.Append(@" WHERE ");
        DataRowVersion version = r.HasVersion(DataRowVersion.Original) ? DataRowVersion.Original : DataRowVersion.Current;
        for (int i = 0; i < dt.PrimaryKey.Length; i++)
        {
            DataColumn c = dt.PrimaryKey[i];
            string quote = c.DataType == typeof(string) || c.DataType == typeof(Guid) || c.DataType == typeof(DateTime) ? "'" : "";

            if (i > 0) sb.Append(@" AND ");
            sb.Append("[" + c.ColumnName + "] = ");

            if (c.DataType == typeof(bool))
            {
                sb.Append((bool)r[c, version] ? "1" : "0");
            }
            else
            {
                if (c.DataType == typeof(string))
                {
                    sb.Append(quote + ((string)r[c, version]).EscapeEqual() + quote);
                }
                else
                    sb.Append(quote + r[c, version].ToString() + quote);
            }
        }

        return sb.ToString();
    }


    /// <summary>
    /// 根据一个 DataRow 对象的内容拼接成一个 Delete TSQL 语句。
    /// 要求 r 所在 Table 的表名 须和 数据表 相符， 字段名和 数据表字段名 相符，具有相同主键。
    /// 注意：该方法现在只支持架构名不重复的表
    /// </summary>
    public static string Gen_DeleteCommandText(DataRow r)
    {
        DataTable dt = r.Table;
        string tn = dt.TableName;
        DataRowVersion version = r.HasVersion(DataRowVersion.Original) ? DataRowVersion.Original : DataRowVersion.Current;
        StringBuilder sb = new StringBuilder("DELETE FROM [" + tn + @"] WHERE ");
        for (int i = 0; i < dt.PrimaryKey.Length; i++)
        {
            DataColumn c = dt.PrimaryKey[i];
            string quote = c.DataType == typeof(string) || c.DataType == typeof(Guid) || c.DataType == typeof(DateTime) ? "'" : "";

            if (i > 0) sb.Append(@" AND ");
            sb.Append("[" + c.ColumnName + "] = ");

            if (c.DataType == typeof(bool))
            {
                sb.Append((bool)r[c, version] ? "1" : "0");
            }
            else
            {
                if (c.DataType == typeof(string))
                {
                    sb.Append(quote + ((string)r[c, version]).EscapeEqual() + quote);
                }
                else
                    sb.Append(quote + r[c, version].ToString() + quote);
            }
        }

        return sb.ToString();
    }


    /// <summary>
    /// 返回多关键字模糊查找的 SQL 拼接语句。SQL 语句运行结果为主键序列
    /// </summary>
    /// <param name="keywords">关键字序列</param>
    /// <param name="tableName">表名</param>
    /// <param name="primaryKey">主键字段名</param>
    /// <param name="searchForCol">要找的字段名</param>
    /// <param name="orderByCol">排序字段名（默认情况下认为会传入时间字段并倒序排列）</param>
    /// <returns>用于该查询的 TSQL 语句</returns>
    public static string Gen_KeywordsSearch(IList<string> keywords, string tableName, string primaryKey, string searchForCol, string orderByCol, string whereExpression)
    {
        return Gen_KeywordsSearch(keywords, tableName, new string[] { primaryKey }, new string[] { searchForCol }, new KeyValuePair<string, bool>[] { new KeyValuePair<string, bool>(orderByCol, true) }, null, whereExpression);
    }

    /// <summary>
    /// 返回多关键字模糊查找的 SQL 拼接语句。
    /// </summary>
    /// <param name="keywords">关键字序列</param>
    /// <param name="tableName">表名</param>
    /// <param name="primaryKey">主键字段名序列</param>
    /// <param name="searchForCol">要找的字段名序列</param>
    /// <param name="orderByCol">排序字段名序列</param>
    /// <param name="returnCols"> TSQL 执行结果包含的字段（无则只返回主键） </param>
    /// <param name="where"> 欲传入的 TSQL 判断表达式字串 （主键字段须带 a. 开头） </param>
    /// <returns>用于该查询的 TSQL 语句</returns>
    public static string Gen_KeywordsSearch(IList<string> keywords, string tableName, IList<string> primaryKeys, IList<string> searchForCols, IList<KeyValuePair<string, bool>> orderByCols, IList<string> returnCols, string whereExpression)
    {
        List<KeyValuePair<string, IList<string>>> colKeywords = new List<KeyValuePair<string, IList<string>>>();
        foreach (string s in searchForCols)
        {
            colKeywords.Add(new KeyValuePair<string, IList<string>>(s, keywords));
        }
        return Gen_KeywordsSearch(tableName, primaryKeys, colKeywords.ToArray(), orderByCols, returnCols, whereExpression);
    }




    /// <summary>
    /// 返回多关键字多字段对应模糊查找的 SQL 拼接语句。
    /// </summary>
    /// <param name="tableName">表名</param>
    /// <param name="primaryKey">主键字段名序列</param>
    /// <param name="colKeywords">字段，关键字序列对应字典</param>
    /// <param name="orderByCol">排序字段名序列</param>
    /// <param name="returnCols"> TSQL 执行结果包含的字段（无则只返回主键） </param>
    /// <param name="where"> 欲传入的 TSQL 判断表达式字串 （主键字段须带 a. 开头） </param>
    /// <returns>用于该查询的 TSQL 语句</returns>
    public static string Gen_KeywordsSearch(string tableName, IList<string> primaryKeys, IList<KeyValuePair<string, IList<string>>> colKeywords, IList<KeyValuePair<string, bool>> orderByCols, IList<string> returnCols, string whereExpression)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"SELECT ");
        if (returnCols == null || returnCols.Count == 0)
        {
            for (int i = 0; i < primaryKeys.Count; i++)
            {
                if (i > 0) sb.Append(@", ");
                sb.Append(@"a.[" + primaryKeys[i] + @"]");
            }
        }
        else
        {
            for (int i = 0; i < returnCols.Count; i++)
            {
                if (i > 0) sb.Append(@", ");
                sb.Append(@"a.[" + returnCols[i] + @"]");
            }
        }
        sb.Append(@" FROM [" + tableName + @"] a
JOIN (
	SELECT ");
        for (int i = 0; i < primaryKeys.Count; i++)
        {
            if (i > 0) sb.Append(@", ");
            sb.Append(@"[" + primaryKeys[i] + @"]");
        }
        sb.Append(@", COUNT(*) AS 'numof' FROM (");
        int sn = 0;	//子查询计数器。用来解决 union all 的添加问题
        for (int j = 0; j < colKeywords.Count; j++)
        {
            for (int k = 0; k < colKeywords[j].Value.Count; k++)
            {
                if (sn++ > 0) sb.Append(@"
		UNION ALL");
                sb.Append(@"
		SELECT ");
                for (int i = 0; i < primaryKeys.Count; i++)
                {
                    if (i > 0) sb.Append(@", ");
                    sb.Append(@"[" + primaryKeys[i] + @"]");
                }
                sb.Append(@" FROM [" + tableName + @"] WHERE [" + colKeywords[j].Key + @"] LIKE '%" + (colKeywords[j].Value[k]).EscapeLike() + @"%'");
            }
        }
        sb.Append(@"
	) a
	GROUP BY ");
        for (int i = 0; i < primaryKeys.Count; i++)
        {
            if (i > 0) sb.Append(@", ");
            sb.Append(@"[" + primaryKeys[i] + @"]");
        }
        sb.Append(@"
) b ON ");
        for (int i = 0; i < primaryKeys.Count; i++)
        {
            if (i > 0) sb.Append(@", ");
            sb.Append(@"a.[" + primaryKeys[i] + @"] = b.[" + primaryKeys[i] + @"]");
        }
        if (!string.IsNullOrEmpty(whereExpression)) sb.Append(@"
WHERE " + whereExpression);
        sb.Append(@"
ORDER BY b.numof DESC");
        if (orderByCols != null)
            foreach (KeyValuePair<string, bool> kvp in orderByCols)
            {
                sb.Append(@", a.[" + kvp.Key + @"]" + (kvp.Value ? " DESC" : ""));
            }
        return sb.ToString();
    }


    #endregion
}
