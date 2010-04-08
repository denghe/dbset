using System;
using System.Collections.Generic;
using SqlLib.Orientations;

namespace DAL.Orientations.UserDefinedTableTypes.dbo
{

    public partial class udt_INT : LogicalNode<udt_INT>
    {
        public ExpNode<udt_INT> id { get { return this.New_Column(@"id"); } }
    }
    public partial class udt_INT_STRING : LogicalNode<udt_INT_STRING>
    {
        public ExpNode<udt_INT_STRING> column1 { get { return this.New_Column(@"column1"); } }
        public ExpNode<udt_INT_STRING> column2 { get { return this.New_Column(@"column2"); } }
    }
    public partial class udt_test1 : LogicalNode<udt_test1>
    {
        public ExpNode<udt_test1> id { get { return this.New_Column(@"id"); } }
    }
}