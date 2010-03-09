namespace Sample
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using exp = DAL.Expressions.Tables.dbo;
    using ori = DAL.Orientations.Tables.dbo;
    using db = DAL.Tables.dbo;

    class Program
    {
        static void Main(string[] args)
        {
            var query = new DAL.Queries.Tables.dbo.t2 { PageIndex = 0, PageSize = 20 }
                .Where(o => o.c1.GreaterThan(123))
                .OrderBy(o => o.c1.Asceding());
            if (true) query.Expression.And(o => o.c2.LessThan(5));
            if (true) query.Orientation.And(o => o.c2.Desceding());

            Console.WriteLine(query);

            var rows = db.t2.Select(query);

            return;

            Console.ReadLine();
        }
    }
}

namespace DAL.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace Tables
    {
        namespace dbo
        {
            public partial class t2 : SqlLib.Queries.Query<t2, Expressions.Tables.dbo.t2, Orientations.Tables.dbo.t2>
            {
                public override string ToSqlString(string schema = "dbo", string name = "t2", bool isSimpleMode = true)
                {
                    return base.ToSqlString(schema, name, isSimpleMode);
                }
            }
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
                public ExpNode_Int32<t2> c1 { get { return this.New_Int32("c1"); } }
                public ExpNode_Int32<t2> c2 { get { return this.New_Int32("c2"); } }
                public ExpNode_Int32<t2> c3 { get { return this.New_Int32("c3"); } }
            }
        }
    }
}


namespace DAL.Orientations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SqlLib.Orientations;

    namespace Tables
    {
        namespace dbo
        {
            public partial class t2 : LogicalNode<t2>
            {
                public ExpNode<t2> c1 { get { return this.New_Column("c1"); } }
                public ExpNode<t2> c2 { get { return this.New_Column("c2"); } }
                public ExpNode<t2> c3 { get { return this.New_Column("c3"); } }
            }
        }
    }
}



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
        public int ID { get; set; }

        /// <summary>
        /// Field Name : Name
        /// Property   : PrimaryKey, AutoIncrease, NotNull, int
        /// Description: .......
        /// </summary>
        public string Name { get; set; }

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
        public static List<t2> Select(Expressions.Tables.dbo.t2 where, Orientations.Tables.dbo.t2 orderby)
        {
            var s1 = where.ToString();
            var s2 = orderby.ToString();
            var tsql = "SELECT * FROM t2" + (s1.Length > 0 ? " WHERE " : "") + where + (s2.Length > 0 ? " ORDER BY " : "") + s2;

            Console.WriteLine(tsql);

            return null;

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

        public static List<t2> Select(Expressions.Tables.dbo.t2.Handler where, Orientations.Tables.dbo.t2.Handler orderby)
        {
            return Select(where.Invoke(new Expressions.Tables.dbo.t2()), orderby.Invoke(new Orientations.Tables.dbo.t2()));
        }

        public static List<t2> Select(Queries.Tables.dbo.t2.Handler query)
        {
            return null;
        }

        public static List<t2> Select(Queries.Tables.dbo.t2 query)
        {
            return null;
        }

    }
}

