using System;
using System.Collections.Generic;
using SqlLib.Expressions;

namespace DAL.Expressions.UserDefinedTableTypes.dbo
{

    public partial class udt_INT : LogicalNode<udt_INT>
    {
        public ExpNode_Int32<udt_INT> id { get { return this.New_Int32(@"id"); } }
    }
    public partial class udt_INT_STRING : LogicalNode<udt_INT_STRING>
    {
        public ExpNode_Nullable_Int32<udt_INT_STRING> column1 { get { return this.New_Nullable_Int32(@"column1"); } }
        public ExpNode_Nullable_String<udt_INT_STRING> column2 { get { return this.New_Nullable_String(@"column2"); } }
    }
    public partial class udt_test1 : LogicalNode<udt_test1>
    {
        public ExpNode_Int32<udt_test1> id { get { return this.New_Int32(@"id"); } }
    }
}