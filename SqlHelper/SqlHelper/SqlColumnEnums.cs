namespace SqlLib.ColumnEnums {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class ColumnList<T> where T : ColumnList<T>, new() {
        public static T New(Handler h) { return h(new T()); }
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
                return GetColumnName(__columns[i]);
            }
        }
        public int this[string n] {
            get {
                foreach(var i in __columns) if(GetColumnName(i) == n) return i;
                return -1;
            }
        }
        public int Count() {
            return __columns.Count;
        }
        public virtual bool Contains(int idx) {
            return __columns.Contains(idx);
        }
        //public virtual IEnumerable<string> ColumnNames {
        //    get {
        //        foreach(var i in __columns) yield return GetColumnName(i);
        //    }
        //}
        //public virtual IEnumerable<int> ColumnNumbers {
        //    get {
        //        foreach(var i in __columns) yield return i;
        //    }
        //}


        public virtual byte[] GetBytes() {
            var buff = new List<byte[]>();
            buff.Add(__columns.Count.GetBytes());
            foreach (var c in __columns) buff.Add(c.GetBytes());
            return buff.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            var count = buffer.ToInt32(ref startIndex);
            for (int i = 0; i < count; i++) {
                __columns.Add(buffer.ToInt32(ref startIndex));
            }
        }
    }
}
