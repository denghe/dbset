namespace SqlLib.Orientations
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public partial class LogicalNode
    {
        public LogicalNode First;
        public LogicalNode Second;
        public ExpNode Expression;
    }

    public partial class ExpNode
    {
        public LogicalNode Parent;
        public string ColumnName;
        public Orientations Operate = Orientations.NotSet;
    }

    public enum Orientations : int
    {
        NotSet = 0,
        Ascending,
        Descending
    }

    partial class LogicalNode
    {
        public void CopyTo(LogicalNode o)
        {
            o.First = this.First;
            o.Second = this.Second;
            o.Expression = this.Expression;
        }

        public override string ToString()
        {
            return this.ToSqlString();
        }

        public string ToSqlString(string schema = null, string name = null)
        {
            schema = SqlUtils.EscapeSqlObjectName(schema);
            name = SqlUtils.EscapeSqlObjectName(name);
            if (this.Expression == null)
            {
                var s = this.Second.ToSqlString(schema, name);
                return this.First.ToSqlString(schema, name) + (s.Length > 0 ? ", " : "") + s;
            }
            return this.Expression.ToSqlString(schema, name);
        }

    }

    public class LogicalNode<T> : LogicalNode where T : LogicalNode, new()
    {
        public delegate T Handler(T eh);
        public static T New(Handler eh) { return eh.Invoke(new T()); }
        public static T New() { return new T(); }

        public T And(T L) { return new T { First = this, Second = L }; }

        public void And(Handler eh)
        {
            if (this.First == null && this.Expression == null)
            {
                New(eh).CopyTo(this);
            }
            else
            {
                var child = new T();
                this.CopyTo(child);

                this.First = eh.Invoke(new T());
                this.Second = child;
                this.Expression = null;
            }
        }

        public static T operator &(LogicalNode<T> a, LogicalNode<T> b) { return new T { First = a, Second = b }; }

        protected void Check()
        {
            if (this.Expression != null)
                throw new Exception("do not support column.operate().column.operate().....");
        }


        protected ExpNode<T> New_Column(string column)
        {
            Check();
            var L = new T();
            var e = new ExpNode<T> { Parent = L, ColumnName = column };
            L.Expression = e;
            return e;
        }

    }

    partial class ExpNode
    {
        public override string ToString()
        {
            return this.ToSqlString();
        }

        public virtual string ToSqlString(string schema = null, string name = null)
        {
            var sn = (string.IsNullOrEmpty(schema) ? "" : ("[" + schema + "]."))
                + (string.IsNullOrEmpty(name) ? "" : ("[" + name + "]."))
                + "[" + this.ColumnName + "]";

            return sn + (this.Operate == Orientations.Descending ? " DESC" : "");
        }
    }


    public partial class ExpNode<T> : ExpNode where T : LogicalNode, new()
    {
        public T Asceding()
        {
            this.Operate = Orientations.Ascending;
            return (T)this.Parent;
        }

        public T Desceding()
        {
            this.Operate = Orientations.Descending;
            return (T)this.Parent;
        }
    }
}
