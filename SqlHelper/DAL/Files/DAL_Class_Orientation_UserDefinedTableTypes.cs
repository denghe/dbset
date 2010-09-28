using System;
using System.Collections.Generic;
using SqlLib.Orientations;

namespace DAL.Orientations.UserDefinedTableTypes.表类型
{

    public partial class G_INT : LogicalNode<G_INT>
    {
        public ExpNode<G_INT> c1 { get { return this.New_Column(@"c1"); } }
    }
    public partial class G_INT_INT : LogicalNode<G_INT_INT>
    {
        public ExpNode<G_INT_INT> c1 { get { return this.New_Column(@"c1"); } }
        public ExpNode<G_INT_INT> c2 { get { return this.New_Column(@"c2"); } }
    }
    public partial class G_INT_INT_BIT : LogicalNode<G_INT_INT_BIT>
    {
        public ExpNode<G_INT_INT_BIT> c1 { get { return this.New_Column(@"c1"); } }
        public ExpNode<G_INT_INT_BIT> c2 { get { return this.New_Column(@"c2"); } }
        public ExpNode<G_INT_INT_BIT> c3 { get { return this.New_Column(@"c3"); } }
    }
    public partial class G_INT_STRING : LogicalNode<G_INT_STRING>
    {
        public ExpNode<G_INT_STRING> c1 { get { return this.New_Column(@"c1"); } }
        public ExpNode<G_INT_STRING> c2 { get { return this.New_Column(@"c2"); } }
    }
    public partial class G_INT_STRING_STRING : LogicalNode<G_INT_STRING_STRING>
    {
        public ExpNode<G_INT_STRING_STRING> c1 { get { return this.New_Column(@"c1"); } }
        public ExpNode<G_INT_STRING_STRING> c2 { get { return this.New_Column(@"c2"); } }
        public ExpNode<G_INT_STRING_STRING> c3 { get { return this.New_Column(@"c3"); } }
    }
    public partial class G_STRING : LogicalNode<G_STRING>
    {
        public ExpNode<G_STRING> c1 { get { return this.New_Column(@"c1"); } }
    }
    public partial class G_STRING_DATETIME : LogicalNode<G_STRING_DATETIME>
    {
        public ExpNode<G_STRING_DATETIME> c1 { get { return this.New_Column(@"c1"); } }
        public ExpNode<G_STRING_DATETIME> c2 { get { return this.New_Column(@"c2"); } }
    }
}