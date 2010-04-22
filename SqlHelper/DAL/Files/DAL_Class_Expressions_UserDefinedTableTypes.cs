using System;
using System.Collections.Generic;
using SqlLib.Expressions;

namespace DAL.Expressions.UserDefinedTableTypes.表类型
{

    public partial class G_INT : LogicalNode<G_INT>
    {
        public ExpNode_Int32<G_INT> c1 { get { return this.New_Int32(@"c1"); } }
    }
    public partial class G_INT_INT : LogicalNode<G_INT_INT>
    {
        public ExpNode_Int32<G_INT_INT> c1 { get { return this.New_Int32(@"c1"); } }
        public ExpNode_Int32<G_INT_INT> c2 { get { return this.New_Int32(@"c2"); } }
    }
    public partial class G_INT_STRING : LogicalNode<G_INT_STRING>
    {
        public ExpNode_Int32<G_INT_STRING> c1 { get { return this.New_Int32(@"c1"); } }
        public ExpNode_String<G_INT_STRING> c2 { get { return this.New_String(@"c2"); } }
    }
    public partial class G_INT_STRING_STRING : LogicalNode<G_INT_STRING_STRING>
    {
        public ExpNode_Int32<G_INT_STRING_STRING> c1 { get { return this.New_Int32(@"c1"); } }
        public ExpNode_String<G_INT_STRING_STRING> c2 { get { return this.New_String(@"c2"); } }
        public ExpNode_String<G_INT_STRING_STRING> c3 { get { return this.New_String(@"c3"); } }
    }
    public partial class G_STRING : LogicalNode<G_STRING>
    {
        public ExpNode_String<G_STRING> c1 { get { return this.New_String(@"c1"); } }
    }
    public partial class G_STRING_DATETIME : LogicalNode<G_STRING_DATETIME>
    {
        public ExpNode_String<G_STRING_DATETIME> c1 { get { return this.New_String(@"c1"); } }
        public ExpNode_DateTime<G_STRING_DATETIME> c2 { get { return this.New_DateTime(@"c2"); } }
    }
}