namespace Sample
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using exp = DAL.Expressions.Tables.dbo;
    using db = DAL.Tables.dbo;

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WindowWidth = 160;

            // step construct
            var e = exp.t2.New();
            if (true) e.And(o => o.Boolean.Equal(true));
            if (true) e.And(o => o.Bytes.Equal(null));
            if (true) e.And(o => o.DateTime.Between(DateTime.Now, DateTime.Now));
            var rows = db.t2.Select(e);
            Console.WriteLine(e);

            // direct
            Console.WriteLine(DAL.Expressions.Tables.dbo.t2.New(o =>
                      o.Boolean.Equal(true)
                    | o.Bytes.Equal(null)
                    | o.DateTime.Between(DateTime.Now, DateTime.Now)
                    | o.Decimal.LessEqual(23)
                    | o.Int16.GreaterThan(12)
                    | o.Int32.LessThan(34)
                    | o.Int64.GreaterEqual(45)
                    | o.Guid.Equal(Guid.NewGuid())
                    | o.String.Like(null)

                    | o.NBoolean.Equal(null)
                    | o.NBoolean.IsNull()
                    | o.NBytes.Equal(null)
                    | o.NDateTime.Equal(null)
                    | o.NDecimal.GreaterThan(null)
                    | o.NGuid.Equal(null)
                    | o.NInt16.Equal(null)
                    | o.NInt32.Equal(null)
                    | o.NInt64.Equal(null)
                    | o.NString.Equal(null)

                    | o.NBoolean.Equal(true)
                    | o.NBytes.Equal(new byte[] { 1, 2, 3, 4, 5 })
                    | o.NDateTime.Between(null, DateTime.Now)
                    | o.NDecimal.LessEqual(23)
                    | o.NInt16.GreaterThan(12)
                    | o.NInt32.LessThan(34)
                    | o.NInt64.GreaterEqual(45)
                    | o.NGuid.Equal(Guid.NewGuid())
                    | o.NString.Like("'")
                )
            );

            DAL.Tables.dbo.t2.Select(o => o.Boolean.Equal(true));

            Console.ReadLine();
        }
    }
}

//namespace DAL
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Text;

//    public interface IDataObject
//    {
//    }
//}

namespace DAL.Tables.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;

    using SqlLib;

    /// <summary>
    /// Table Name : [..].[..].[..]
    /// Description: .......
    /// </summary>
    public partial class t2
    {
        /// <summary>
        /// Field Name : ID
        /// Property   : PrimaryKey, AutoIncrease, NotNull, int
        /// Description: .......
        /// </summary>
        public int      ID { get; set; }

        /// <summary>
        /// Field Name : Name
        /// Property   : PrimaryKey, AutoIncrease, NotNull, int
        /// Description: .......
        /// </summary>
        public string   Name { get; set; }

        /// <summary>
        /// Field Name : CreateTime
        /// Property   : PrimaryKey, AutoIncrease, NotNull, int
        /// Description: .......
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Execute following TSQL and return： 
        /// 
        /// SELECT ID
        ///      , Name
        ///      , CreateTime
        ///   FROM t2
        ///  WHERE exp
        /// </summary>
        public static List<t2> Select(Expressions.Tables.dbo.t2 exp)
        {
            var where = exp.ToString();
            var tsql = "SELECT * FROM t2" + (where.Length > 0 ? " WHERE " : "") + where;
            var rows = new List<t2>();
            using (var reader = SqlHelper.ExecuteDataReader(tsql))
            {
                while (reader.Read())
                {
                    rows.Add(new t2
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        CreateTime = reader.GetDateTime(2)
                    });
                }
            }
            return rows;
        }

        public static List<t2> Select(Expressions.Tables.dbo.t2.ExpHandler eh)
        {
            return Select(eh.Invoke(new Expressions.Tables.dbo.t2()));
        }
    }
}



namespace DAL.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SqlLib.Expressions;

    namespace Tables
    {
        namespace dbo
        {
            public partial class t2 : LogicalNode<t2>
            {
                public ExpNode_Int16<t2> Int16 { get { return this.New_Int16("Int16"); } }
                public ExpNode_Int32<t2> Int32 { get { return this.New_Int32("Int32"); } }
                public ExpNode_Int64<t2> Int64 { get { return this.New_Int64("Int64"); } }
                public ExpNode_Decimal<t2> Decimal { get { return this.New_Decimal("Decimal"); } }
                public ExpNode_DateTime<t2> DateTime { get { return this.New_DateTime("DateTime"); } }
                public ExpNode_Boolean<t2> Boolean { get { return this.New_Boolean("Boolean"); } }
                public ExpNode_Bytes<t2> Bytes { get { return this.New_Bytes("Bytes"); } }
                public ExpNode_String<t2> String { get { return this.New_String("String"); } }
                public ExpNode_Guid<t2> Guid { get { return this.New_Guid("Guid"); } }

                public ExpNode_Nullable_Int16<t2> NInt16 { get { return this.New_Nullable_Int16("NInt16"); } }
                public ExpNode_Nullable_Int32<t2> NInt32 { get { return this.New_Nullable_Int32("NInt32"); } }
                public ExpNode_Nullable_Int64<t2> NInt64 { get { return this.New_Nullable_Int64("NInt64"); } }
                public ExpNode_Nullable_Decimal<t2> NDecimal { get { return this.New_Nullable_Decimal("NDecimal"); } }
                public ExpNode_Nullable_DateTime<t2> NDateTime { get { return this.New_Nullable_DateTime("NDateTime"); } }
                public ExpNode_Nullable_Boolean<t2> NBoolean { get { return this.New_Nullable_Boolean("NBoolean"); } }
                public ExpNode_Nullable_Bytes<t2> NBytes { get { return this.New_Nullable_Bytes("NBytes"); } }
                public ExpNode_Nullable_String<t2> NString { get { return this.New_Nullable_String("NString"); } }
                public ExpNode_Nullable_Guid<t2> NGuid { get { return this.New_Nullable_Guid("NGuid"); } }
                // todo: more columns here

                public override string ToString()
                {
                    return base.ToSqlString("dbo", "t2");
                }
            }
        }
    }
}


//namespace DAL.Extensions
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Text;

//    public static partial class Extensions
//    {
//        public static T First<T>(this List<T> list)
//        {
//            if (list == null || list.Count == 0) return default(T);
//            return list[0];
//        }

//        public static void First<T>(this List<T> list, Action<T> action)
//        {
//            if (list == null || list.Count == 0) return;
//            action.Invoke(list[0]);
//        }
//    }
//}
