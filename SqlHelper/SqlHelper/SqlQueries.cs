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
        public static T New(int pageSize, int pageIndex
            , SqlLib.Expressions.LogicalNode<W>.Handler where
            , SqlLib.Orientations.LogicalNode<O>.Handler orderby) {
                return new T {
                     PageIndex = pageIndex,
                     PageSize = pageSize,
                     Where = where.Invoke(new W()),
                     OrderBy = orderby.Invoke(new O())
                };
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public W Where { get; set; }
        public O OrderBy { get; set; }

        public T SetPageIndex(int pageIndex) {
            this.PageIndex = pageIndex;
            return (T)this;
        }
        public T SetPageSize(int pageSize) {
            this.PageSize = pageSize;
            return (T)this;
        }
        public T SetWhere(SqlLib.Expressions.LogicalNode<W>.Handler h) {
            this.Where = h.Invoke(new W());
            return (T)this;
        }
        public T SetOrderBy(SqlLib.Orientations.LogicalNode<O>.Handler h) {
            this.OrderBy = h.Invoke(new O());
            return (T)this;
        }


        public override string ToString() {
            return this.ToSqlString();
        }
        public virtual string ToSqlString(string schema = null, string name = null, List<string> columns = null) {
            string ssn = "", stn = "", sw = "", so = "", st = "", scs="*";
            if(!string.IsNullOrEmpty(schema)) ssn = "[" + schema.Replace("]", "]]") + "].";
            if(!string.IsNullOrEmpty(name)) stn = "[" + name.Replace("]", "]]") + "]";
            sw = this.Where.ToSqlString("", "");
            so = this.OrderBy.ToSqlString("", "");
            if(columns != null && columns.Count > 0) {
                if(columns.Count == 1) scs = "[" + columns[0].Replace("]", "]]") + "]";
                else {
                    var sb = new StringBuilder("[" + columns[0].Replace("]", "]]") + "]");
                    for(int i = 1; i < columns.Count; i++)
                        sb.Append(", " + "[" + columns[i].Replace("]", "]]") + "]");
                    scs = sb.ToString();
                }
            }
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
    }
}
