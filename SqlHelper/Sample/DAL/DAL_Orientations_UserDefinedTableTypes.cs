using System;
using System.Collections.Generic;
using SqlLib.Orientations;

namespace DAL.Orientations.UserDefinedTableTypes.dbo
{

    public partial class FS : LogicalNode<FS>
    {
        public ExpNode<FS> Col1 { get { return this.New_Column(@"Col1"); } }
        public ExpNode<FS> Col2 { get { return this.New_Column(@"Col2"); } }
        public ExpNode<FS> Col3 { get { return this.New_Column(@"Col3"); } }
    }
    public partial class G_INT : LogicalNode<G_INT>
    {
        public ExpNode<G_INT> c1 { get { return this.New_Column(@"c1"); } }
    }
    public partial class G_INT_STR : LogicalNode<G_INT_STR>
    {
        public ExpNode<G_INT_STR> c1 { get { return this.New_Column(@"c1"); } }
        public ExpNode<G_INT_STR> c2 { get { return this.New_Column(@"c2"); } }
    }
    public partial class MyType1 : LogicalNode<MyType1>
    {
        public ExpNode<MyType1> Str { get { return this.New_Column(@"Str"); } }
        public ExpNode<MyType1> Num { get { return this.New_Column(@"Num"); } }
    }
    public partial class ParentChildOrg : LogicalNode<ParentChildOrg>
    {
        public ExpNode<ParentChildOrg> EmployeeID { get { return this.New_Column(@"EmployeeID"); } }
        public ExpNode<ParentChildOrg> ManagerId { get { return this.New_Column(@"ManagerId"); } }
        public ExpNode<ParentChildOrg> EmployeeName { get { return this.New_Column(@"EmployeeName"); } }
    }
}