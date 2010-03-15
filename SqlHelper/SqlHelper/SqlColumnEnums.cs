﻿namespace SqlLib.ColumnEnums {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class ColumnList<T> where T : ColumnList<T> {
        protected List<int> __columns = new List<int>();
        public virtual string ToSqlString(string schema = null, string name = null) {
            // todo: check schema , name generate [schema].[name].[col]
            if(__columns.Count == 0) return "*";
            var sb = new StringBuilder();
            foreach(var c in __columns) {
                if(sb.Length > 0) sb.Append(", ");
                sb.Append("[" + GetColumnName(c) + "]");
            }
            return sb.ToString();
        }
        public virtual string GetColumnName(int i) {
            return i.ToString();
        }
        public override string ToString() {
            return ToSqlString();
        }
        public delegate T Handler(T h);

        public string this[int i] {
            get {
                return GetColumnName(i);
            }
        }
        public int Count() {
            return __columns.Count;
        }
    }
}
