namespace Sample
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using exp = DAL.Expressions.dbo;
    using db = DAL.Tables.dbo;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 160;

            // step construct
            var e = exp.t2.New();
            if (true) e.And(o => o.id.Equal(1));
            if (false) e.And(o => o.id.Equal(2));
            if (true) e.And(o => o.id.Between(3, 4));
            var rows = db.t2.Select(e);
            Console.WriteLine(e);

            // direct
            Console.WriteLine(DAL.Expressions.dbo.t2.New(o =>
                    (o.id.IsNull() | o.id.GreaterEqual(2)) & (o.id.Equal(null) | o.id.Between(3, 4)).Not()
                )
            );

            Console.ReadLine();
        }
    }
}


namespace DAL.Tables.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class t2
    {
        // todo: columns properties here

        public static List<t2> Select(Expressions.dbo.t2.ExpHandler eh)
        {
            return Select(eh.Invoke(new Expressions.dbo.t2()));
        }
        public static List<t2> Select(Expressions.dbo.t2 exp)
        {
            var where = exp.ToString();
            var tsql = "SELECT * FROM t2" + (where.Length > 0 ? " WHERE " : "") + where;

            // todo: get data & return
            return new List<t2>();
        }
    }
}



namespace DAL.Expressions.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SqlLib.Expressions;

    public partial class t2 : SqlLogicalNode<t2>
    {
        public override string ToString()
        {
            return base.ToSqlString("dbo", "t2");
        }

        public SqlExpressionNode_Nullable_Int32<t2> id { get { return this.New_SqlExpressionNode_Nullable_Int32("id"); } }

        // todo: more columns here
    }
}
