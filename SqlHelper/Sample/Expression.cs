namespace Sample {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using SqlLib;
    using db = DAL.Database.Tables.dbo;
    using query = DAL.Queries.Tables.dbo;






    class Program {
        static void Main(string[] args) {
            // init connect string
            SqlHelper.InitConnectString(server: "data,14333", username: "admin");
            // dump all dbo.t2 data
            SqlHelper.ExecuteDbSet(query.t2.New().ToString()).Dump();

            // select method test
            var row = db.t2.Select(5);                          // return t2(id=5)
            var row2 = db.t2.Select(6);                         // return null

            var q = query.t2.New(o => o.Name >= "a"             // where
                , o => o.CreateTime.ASC & o.Name.DESC           // order by
                , 3                                             // pagesize
                , 1                                             // pageindex
                , o => o.ID.Name.CreateTime);                   // column list

            var rows = db.t2.Select(q);                         // return List<t2>

            Console.WriteLine("\r\n\r\nresult: "
                + (row == null ? 0 : row.ID) + " "
                + (row2 == null ? 0 : row.ID) + " "
                + rows.Count
                );

            Console.WriteLine(q.ToString());

            Console.ReadLine();

            //var rows = db.t2.Select();

            //// construct query
            //var q = query.t2.New(pageSize: 3, pageIndex: 1);
            //if(true) q.Where.And(o => o.ID.Between(1,5));
            //if(true) q.OrderBy.And(o => o.Name.Desceding());
            //// show query TSQL
            //Console.WriteLine(q);
            //// get data & dump
            //var ds = SqlHelper.ExecuteDbSet(q.ToString());
            //ds.Dump();
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
            public partial class t2 : Query<t2, Expressions.Tables.dbo.t2, Orientations.Tables.dbo.t2, ColumnEnums.Tables.dbo.t2> {
                public override string ToSqlString(string schema = null, string name = null, List<string> columns = null) {
                    return base.ToSqlString(schema ?? "dbo", name ?? "t2", columns);
                }
            }
        }
    }
}

namespace DAL.ColumnEnums {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SqlLib.Queries;

    namespace Tables {
        namespace dbo {
            public partial class t2 : ColumnList<t2> {
                public t2 ID {
                    get { __columns.Add(0); return this; }
                }
                public t2 Name {
                    get { __columns.Add(1); return this; }
                }
                public t2 CreateTime {
                    get { __columns.Add(2); return this; }
                }

                protected static string[] __cns = new string[]{
                    "ID", "Name", "CreateTime"
                };
                public override string GetColumnName(int i) {
                    return __cns[i];
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
                public ExpNode_Int32<t2> ID { get { return this.New_Int32("ID"); } }
                public ExpNode_String<t2> Name { get { return this.New_String("Name"); } }
                public ExpNode_DateTime<t2> CreateTime { get { return this.New_DateTime("CreateTime"); } }
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


namespace DAL.Database {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;
    using System.Linq;

    using SqlLib;

    namespace Tables {
        namespace dbo {

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

                public static t2 Select(int id) {
                    return Select(o => o.ID.Equal(id)).FirstOrDefault();
                }

                /// <summary>
                /// Execute following TSQL and return： 
                /// 
                /// SELECT ID
                ///      , Name
                ///      , CreateTime
                ///   FROM t2
                ///  WHERE exp
                /// </summary>
                public static List<t2> Select(Queries.Tables.dbo.t2 q) {
                    var tsql = q.ToSqlString();
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

                public static List<t2> Select(
                    Expressions.Tables.dbo.t2.Handler where = null
                    , Orientations.Tables.dbo.t2.Handler orderby = null
                    , int pageSize = 0
                    , int pageIndex = 0
                    , ColumnEnums.Tables.dbo.t2.Handler columns = null
                    ) {
                    return Select(Queries.Tables.dbo.t2.New(where, orderby, pageSize, pageIndex, columns));
                }
            }
        }
    }
}