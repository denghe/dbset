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
            //Console.WindowWidth = 160;

            //// step construct
            //var e = exp.t2.New();
            //if (true) e.And(o => o.id.Equal(1));
            //if (false) e.And(o => o.id.Equal(2));
            //if (true) e.And(o => o.id.Between(3, 4));
            //var rows = db.t2.Select(e);
            //Console.WriteLine(e);

            // direct
            Console.WriteLine(DAL.Expressions.dbo.t2.New(o =>
                    o.Boolean.Equal(null)
                    | o.Bytes.Equal(null)
                    | o.DateTime.Equal(null)
                    | o.Decimal.GreaterThan(null)
                    | o.Guid.Equal(null)
                    | o.Int16.Equal(null)
                    | o.Int32.Equal(null)
                    | o.Int64.Equal(null)
                    | o.String.Equal(null)

                    | o.Boolean.Equal(true)
                    | o.Bytes.Equal(new byte[] { 1, 2, 3, 4, 5 })
                    | o.DateTime.Between(null, DateTime.Now)
                    | o.Decimal.LessEqual(23)
                    | o.Int16.GreaterThan(12)
                    | o.Int32.LessThan(34)
                    | o.Int64.GreaterEqual(45)
                    | o.Guid.Equal(Guid.NewGuid())
                    | o.String.Like("'")
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

        public SqlExpressionNode_Nullable_Int16<t2> Int16 { get { return this.New_SqlExpressionNode_Nullable_Int16("Int16"); } }
        public SqlExpressionNode_Nullable_Int32<t2> Int32 { get { return this.New_SqlExpressionNode_Nullable_Int32("Int32"); } }
        public SqlExpressionNode_Nullable_Int64<t2> Int64 { get { return this.New_SqlExpressionNode_Nullable_Int64("Int64"); } }
        public SqlExpressionNode_Nullable_Decimal<t2> Decimal { get { return this.New_SqlExpressionNode_Nullable_Decimal("Decimal"); } }
        public SqlExpressionNode_Nullable_DateTime<t2> DateTime { get { return this.New_SqlExpressionNode_Nullable_DateTime("DateTime"); } }
        public SqlExpressionNode_Nullable_Boolean<t2> Boolean { get { return this.New_SqlExpressionNode_Nullable_Boolean("Boolean"); } }
        public SqlExpressionNode_Nullable_Bytes<t2> Bytes { get { return this.New_SqlExpressionNode_Nullable_Bytes("Bytes"); } }
        public SqlExpressionNode_Nullable_String<t2> String { get { return this.New_SqlExpressionNode_Nullable_String("String"); } }
        public SqlExpressionNode_Nullable_Guid<t2> Guid { get { return this.New_SqlExpressionNode_Nullable_Guid("Guid"); } }

        // todo: more columns here
    }
}
