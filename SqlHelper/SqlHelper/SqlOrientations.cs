namespace SqlLib.Orientations {
    using System;
    using System.Collections.Generic;
    using System.Text;


    public partial class LogicalNode {
        public LogicalNode First__;
        public LogicalNode Second__;
        public ExpNode Expression__;
    }

    public partial class ExpNode {
        public LogicalNode Parent;
        public string ColumnName;
        public Orientations Operate = Orientations.NotSet;
    }

    public enum Orientations : int {
        NotSet = 0,
        Ascending,
        Descending
    }

    partial class LogicalNode {
        public void CopyTo(LogicalNode o) {
            o.First__ = this.First__;
            o.Second__ = this.Second__;
            o.Expression__ = this.Expression__;
        }

        public override string ToString() {
            return this.ToSqlString();
        }

        public virtual string ToSqlString(string schema = null, string name = null) {
            schema = SqlUtils.EscapeSqlObjectName(schema);
            name = SqlUtils.EscapeSqlObjectName(name);
            if(this.Expression__ == null) {
                if(this.Second__ == null) return "";
                var s = this.Second__.ToSqlString(schema, name);
                return this.First__.ToSqlString(schema, name) + (s.Length > 0 ? ", " : "") + s;
            }
            return this.Expression__.ToSqlString(schema, name);
        }

    }

    public class LogicalNode<T> : LogicalNode where T : LogicalNode, new() {
        public delegate T Handler(T eh);
        public static T New(Handler eh) { return eh.Invoke(new T()); }
        public static T New() { return new T(); }

        public T And(T L) { return new T { First__ = this, Second__ = L }; }

        public void And(Handler eh) {
            if(this.First__ == null && this.Expression__ == null) {
                New(eh).CopyTo(this);
            } else {
                var child = new T();
                this.CopyTo(child);

                this.First__ = eh.Invoke(new T());
                this.Second__ = child;
                this.Expression__ = null;
            }
        }

        public static T operator &(LogicalNode<T> a, LogicalNode<T> b) { return new T { First__ = a, Second__ = b }; }

        protected void Check() {
            if(this.Expression__ != null)
                throw new Exception("do not support column.operate().column.operate().....");
        }


        protected ExpNode<T> New_Column(string column) {
            Check();
            var L = new T();
            var e = new ExpNode<T> { Parent = L, ColumnName = column };
            L.Expression__ = e;
            return e;
        }

    }

    partial class ExpNode {
        public override string ToString() {
            return this.ToSqlString();
        }

        public virtual string ToSqlString(string schema = null, string name = null) {
            var sn = (string.IsNullOrEmpty(schema) ? "" : ("[" + schema + "]."))
                + (string.IsNullOrEmpty(name) ? "" : ("[" + name + "]."))
                + "[" + this.ColumnName + "]";

            return sn + (this.Operate == Orientations.Descending ? " DESC" : "");
        }
    }


    public partial class ExpNode<T> : ExpNode where T : LogicalNode, new() {
        public T ASC {
            get {
                this.Operate = Orientations.Ascending;
                return (T)this.Parent;
            }
        }

        public T DESC {
            get {
                this.Operate = Orientations.Descending;
                return (T)this.Parent;
            }
        }
    }
}
