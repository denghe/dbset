using System;
using System.Collections.Generic;
using SqlLib.Expressions;

namespace DAL.Expressions.UserDefinedTableTypes.dbo
{

    public partial class FS : LogicalNode<FS>
    {
        public ExpNode_Int32<FS> Col1 { get { return this.New_Int32(@"Col1"); } }
        public ExpNode_Int32<FS> Col2 { get { return this.New_Int32(@"Col2"); } }
        public ExpNode_Nullable_String<FS> Col3 { get { return this.New_Nullable_String(@"Col3"); } }
    }
    public partial class G_INT : LogicalNode<G_INT>
    {
        public ExpNode_Int32<G_INT> c1 { get { return this.New_Int32(@"c1"); } }
    }
    public partial class G_INT_STR : LogicalNode<G_INT_STR>
    {
        public ExpNode_Nullable_Int32<G_INT_STR> c1 { get { return this.New_Nullable_Int32(@"c1"); } }
        public ExpNode_Nullable_String<G_INT_STR> c2 { get { return this.New_Nullable_String(@"c2"); } }
    }
    public partial class MyType1 : LogicalNode<MyType1>
    {
        public ExpNode_String<MyType1> Str { get { return this.New_String(@"Str"); } }
        public ExpNode_Nullable_Int32<MyType1> Num { get { return this.New_Nullable_Int32(@"Num"); } }
    }
    public partial class ParentChildOrg : LogicalNode<ParentChildOrg>
    {
        public ExpNode_Int32<ParentChildOrg> EmployeeID { get { return this.New_Int32(@"EmployeeID"); } }
        public ExpNode_Nullable_Int32<ParentChildOrg> ManagerId { get { return this.New_Nullable_Int32(@"ManagerId"); } }
        public ExpNode_Nullable_String<ParentChildOrg> EmployeeName { get { return this.New_Nullable_String(@"EmployeeName"); } }
    }
}