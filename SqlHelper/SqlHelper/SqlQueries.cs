namespace SqlLib.Queries {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SqlLib.ColumnEnums;

    public partial class Query<Q, W, O, CS>
        where Q : Query<Q, W, O, CS>, new()
        where W : Expressions.LogicalNode<W>, new()
        where O : Orientations.LogicalNode<O>, new()
        where CS : ColumnList<CS>, new() {

        public delegate Q Handler(Q h);
        public static Q New(Handler h) { return h(new Q()); }
        public static Q New(
            Expressions.LogicalNode<W>.Handler where = null
            , Orientations.LogicalNode<O>.Handler orderby = null
            , int pageSize = 0
            , int pageIndex = 0
            , ColumnList<CS>.Handler columns = null
            ) {
            return new Q {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Where = where == null ? new W() : where(new W()),
                OrderBy = orderby == null ? new O() : orderby(new O()),
                Columns = columns == null ? new CS() : columns(new CS())
            };
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public W Where { get; set; }
        public O OrderBy { get; set; }
        public CS Columns { get; set; }

        public Q SetPageIndex(int pageIndex) {
            this.PageIndex = pageIndex;
            return (Q)this;
        }
        public Q SetPageSize(int pageSize) {
            this.PageSize = pageSize;
            return (Q)this;
        }
        public Q SetWhere(Expressions.LogicalNode<W>.Handler h) {
            this.Where = h(new W());
            return (Q)this;
        }
        public Q SetOrderBy(Orientations.LogicalNode<O>.Handler h) {
            this.OrderBy = h(new O());
            return (Q)this;
        }


        public override string ToString() {
            return this.ToSqlString();
        }
        public virtual string ToSqlString(string schema = null, string name = null, List<string> columns = null) {
            string ssn = "", stn = "", sw = "", so = "", st = "", scs="";
            if(!string.IsNullOrEmpty(schema)) ssn = "[" + schema.Replace("]", "]]") + "].";
            if(!string.IsNullOrEmpty(name)) stn = "[" + name.Replace("]", "]]") + "]";
            sw = this.Where.ToSqlString("", "");
            so = this.OrderBy.ToSqlString("", "");
            scs = this.Columns.ToSqlString("", "");
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
    SELECT " + scs + @"
         , ROW_NUMBER() OVER (ORDER BY " + so + @") AS '__ROWNUMBER'
      FROM " + ssn + stn + (sw.Length > 0 ? @"
     WHERE " : "") + sw + @"
) SELECT " + scs + @"
    FROM [__T]
   WHERE [__ROWNUMBER] BETWEEN " + rowIndexFrom + " AND " + rowIndexTo;
            }
            if(this.PageIndex == 0 && this.PageSize > 0) st = "TOP (" + this.PageSize + ") ";
            return @"
SELECT " + st + scs + @"
  FROM " + ssn + stn + (sw.Length > 0 ? @"
 WHERE " : "") + sw + (so.Length > 0 ? @"
 ORDER BY " : "") + so;
        }
    }
}
