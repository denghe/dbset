namespace SqlLib.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class Query<T> where T : Query<T>, new()
    {
        public delegate T Handler(T eh);
        public static T New(Handler eh) { return eh.Invoke(new T()); }
        public static T New() { return new T(); }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Expressions.LogicalNode Expression { get; set; }
        public Orientations.LogicalNode Orientation { get; set; }

        public string ToSqlString(string schema, string name, bool isSimpleMode = true)
        {
            string ssn = "", stn = "", sw = "", so = "", st = "";
            if (!string.IsNullOrEmpty(schema)) ssn = "[" + schema + "].";
            if (!string.IsNullOrEmpty(name)) stn = "[" + name + "]";
            sw = isSimpleMode ? this.Expression.ToSqlString("", "") : this.Expression.ToSqlString(schema, name);
            so = isSimpleMode ? this.Orientation.ToSqlString("", "") : this.Orientation.ToSqlString(schema, name);

            // todo: 分页处理

            if (this.PageIndex == 0 && this.PageSize > 0) st = "TOP (" + this.PageSize + ") ";

            return "SELECT " + st + @"* FROM " + ssn + stn + (sw.Length > 0 ? " WHERE " : "") + sw + (so.Length > 0 ? " ORDER BY " : "") + so;
        }
    }
}
