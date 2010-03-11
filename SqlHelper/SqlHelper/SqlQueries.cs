namespace SqlLib.Queries {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class Query<T, W, O>
        where T : Query<T, W, O>, new()
        where W : SqlLib.Expressions.LogicalNode<W>, new()
        where O : SqlLib.Orientations.LogicalNode<O>, new() {
        public delegate T Handler(T eh);
        public static T New(Handler eh) { return eh.Invoke(new T()); }
        public static T New() { return new T(); }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public W Expression { get; set; }
        public O Orientation { get; set; }

        public override string ToString() {
            return this.ToSqlString();
        }
        public virtual string ToSqlString(string schema = null, string name = null, List<string> columns = null, bool isSimpleMode = true) {
            string ssn = "", stn = "", sw = "", so = "", st = "", scs="*";
            if(!string.IsNullOrEmpty(schema)) ssn = "[" + schema.Replace("]", "]]") + "].";
            if(!string.IsNullOrEmpty(name)) stn = "[" + name.Replace("]", "]]") + "]";
            sw = isSimpleMode ? this.Expression.ToSqlString("", "") : this.Expression.ToSqlString(schema, name);
            so = isSimpleMode ? this.Orientation.ToSqlString("", "") : this.Orientation.ToSqlString(schema, name);
            if(columns != null && columns.Count > 0) {
                if(columns.Count == 1) scs = "[" + columns[0].Replace("]", "]]") + "]";
                else {
                    var sb = new StringBuilder("[" + columns[0].Replace("]", "]]") + "]");
                    for(int i = 1; i < columns.Count; i++)
                        sb.Append(", " + "[" + columns[i].Replace("]", "]]") + "]");
                    scs = sb.ToString();
                }
            }


            // todo: 传入指定字段列表处理

            if(this.PageIndex > 0 && this.PageSize > 0 && so.Length > 0) {
                var rowIndexFrom = PageIndex * PageSize + 1;
                var rowIndexTo = rowIndexFrom + PageSize - 1;
                return @"
WITH __T AS (
    SELECT *
         , ROW_NUMBER() OVER (ORDER BY " + so + @") AS '__ROWNUMBER'
      FROM " + ssn + stn + (sw.Length > 0 ? @"
     WHERE " : "") + sw + @"
) SELECT *
    FROM __T
   WHERE __ROWNUMBER BETWEEN " + rowIndexFrom + " AND " + rowIndexTo;
            }
            if(this.PageIndex == 0 && this.PageSize > 0) st = "TOP (" + this.PageSize + ") ";
            return @"
SELECT " + st + @"*
  FROM " + ssn + stn + (sw.Length > 0 ? @"
 WHERE " : "") + sw + (so.Length > 0 ? @"
 ORDER BY " : "") + so;
        }

        public T Where(SqlLib.Expressions.LogicalNode<W>.Handler h) {
            this.Expression = h.Invoke(new W());
            return (T)this;
        }
        public T OrderBy(SqlLib.Orientations.LogicalNode<O>.Handler h) {
            this.Orientation = h.Invoke(new O());
            return (T)this;
        }

    }
}
