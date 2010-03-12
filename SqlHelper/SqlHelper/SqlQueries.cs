namespace SqlLib.Queries {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class Query<Q, W, O>
        where Q : Query<Q, W, O>, new()
        where W : Expressions.LogicalNode<W>, new()
        where O : Orientations.LogicalNode<O>, new() {

        public delegate Q Handler(Q h);
        public static Q New(Handler h) { return h.Invoke(new Q()); }
        public static Q New(
            Expressions.LogicalNode<W>.Handler where = null
            , Orientations.LogicalNode<O>.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            ) {
            return new Q {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Where = where == null ? new W() : where.Invoke(new W()),
                OrderBy = orderby == null ? new O() : orderby.Invoke(new O())
            };
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public W Where { get; set; }
        public O OrderBy { get; set; }

        public Q SetPageIndex(int pageIndex) {
            this.PageIndex = pageIndex;
            return (Q)this;
        }
        public Q SetPageSize(int pageSize) {
            this.PageSize = pageSize;
            return (Q)this;
        }
        public Q SetWhere(Expressions.LogicalNode<W>.Handler h) {
            this.Where = h.Invoke(new W());
            return (Q)this;
        }
        public Q SetOrderBy(Orientations.LogicalNode<O>.Handler h) {
            this.OrderBy = h.Invoke(new O());
            return (Q)this;
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
            if(this.PageIndex > 0 && this.PageSize > 0 && so.Length == 0) {
                throw new Exception("select page must be contain orderby orientations");
            }
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
