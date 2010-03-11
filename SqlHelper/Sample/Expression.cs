namespace Sample {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using db    = DAL.Tables.dbo;
    using query = DAL.Queries.Tables.dbo;

    class Program {
        static void Main(string[] args) {
            //var q1 = query.t2.New(a => a
            //    .SetPageSize(20)
            //    .SetPageIndex(1)
            //    .SetWhere(o => o.Name.Like("%a%"))
            //    .SetOrderBy(o => o.CreateTime.Desceding())
            //);
            //if(true) q1.Where.And(o => o.ID.GreaterThan(5));
            //if(true) q1.OrderBy.And(o => o.Name.Asceding());
            //Console.WriteLine(q1);

            var q2 = query.t2.New(
                20
                , 0
                , o => o.Name.Like("%a%")
                , o => o.CreateTime.Desceding()
            );
            Console.WriteLine(q2);
            //var rows = db.t2.Select(query);

            Console.ReadLine();
        }
    }
}

namespace DAL.Queries {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SqlLib.Queries;

    namespace Tables {
        namespace dbo {
            public partial class t2 : Query<t2, Expressions.Tables.dbo.t2, Orientations.Tables.dbo.t2> {
                public override string ToSqlString(string schema = "dbo", string name = "t2", List<string> columns = null) {
                    return base.ToSqlString(schema, name, columns);
                }
            }
        }
    }
}


namespace DAL.Expressions {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SqlLib.Expressions;

    namespace Tables {
        namespace dbo {
            public partial class t2 : LogicalNode<t2> {
                public ExpNode_Int32<t2>    ID          { get { return this.New_Int32("ID"); } }
                public ExpNode_String<t2>   Name        { get { return this.New_String("Name"); } }
                public ExpNode_DateTime<t2> CreateTime  { get { return this.New_DateTime("CreateTime"); } }
            }
        }
    }
}


namespace DAL.Orientations {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SqlLib.Orientations;

    namespace Tables {
        namespace dbo {
            public partial class t2 : LogicalNode<t2> {
                public ExpNode<t2> ID { get { return this.New_Column("ID"); } }
                public ExpNode<t2> Name { get { return this.New_Column("Name"); } }
                public ExpNode<t2> CreateTime { get { return this.New_Column("CreateTime"); } }
            }
        }
    }
}



namespace DAL.Tables.dbo {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;

    using SqlLib;

    /// <summary>
    /// Table Name : [..].[..].[..]
    /// Description: .......
    /// </summary>
    public partial class t2 {
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
        public static List<t2> Select(Queries.Tables.dbo.t2 query) {
            var tsql = query.ToSqlString();
            var rows = new List<t2>();
            using(var reader = SqlHelper.ExecuteDataReader(tsql)) {
                while(reader.Read()) {
                    rows.Add(new t2 {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        CreateTime = reader.GetDateTime(2)
                    });
                }
            }
            return rows;
        }

        public static List<t2> Select(Queries.Tables.dbo.t2.Handler query) {
            return Select(query.Invoke(new Queries.Tables.dbo.t2()));
        }
    }
}

