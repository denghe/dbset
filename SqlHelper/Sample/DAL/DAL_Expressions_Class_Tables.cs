using System;
using System.Collections.Generic;
using SqlLib.Expressions;

namespace DAL.Expressions.Tables.dbo
{

    public partial class Child : LogicalNode<Child>
    {
        public ExpNode_Int32<Child> TreeID { get { return this.New_Int32(@"TreeID"); } }
        public ExpNode_Guid<Child> ChildID { get { return this.New_Guid(@"ChildID"); } }
        public ExpNode_String<Child> Name { get { return this.New_String(@"Name"); } }
        public ExpNode_DateTime<Child> CreateTime { get { return this.New_DateTime(@"CreateTime"); } }
        public ExpNode_String<Child> Memo { get { return this.New_String(@"Memo"); } }
    }
    public partial class ChildLog : LogicalNode<ChildLog>
    {
        public ExpNode_Guid<ChildLog> ChildID { get { return this.New_Guid(@"ChildID"); } }
        public ExpNode_Int32<ChildLog> ChildLogID { get { return this.New_Int32(@"ChildLogID"); } }
        public ExpNode_DateTime<ChildLog> CreateTime { get { return this.New_DateTime(@"CreateTime"); } }
        public ExpNode_String<ChildLog> LogContent { get { return this.New_String(@"LogContent"); } }
    }
    public partial class DoublePK : LogicalNode<DoublePK>
    {
        public ExpNode_Int32<DoublePK> ID1 { get { return this.New_Int32(@"ID1"); } }
        public ExpNode_Int32<DoublePK> ID2 { get { return this.New_Int32(@"ID2"); } }
    }
    public partial class Orders : LogicalNode<Orders>
    {
        public ExpNode_Int32<Orders> OrderID { get { return this.New_Int32(@"OrderID"); } }
        public ExpNode_Int32<Orders> memberID { get { return this.New_Int32(@"memberID"); } }
        public ExpNode_DateTime<Orders> orderDate { get { return this.New_DateTime(@"orderDate"); } }
    }
    public partial class t1 : LogicalNode<t1>
    {
        public ExpNode_Int32<t1> ID { get { return this.New_Int32(@"ID"); } }
        public ExpNode_String<t1> Name { get { return this.New_String(@"Name"); } }
        public ExpNode_Nullable_String<t1> XML { get { return this.New_Nullable_String(@"XML"); } }
    }
    public partial class TA : LogicalNode<TA>
    {
        public ExpNode_Nullable_Int32<TA> AID { get { return this.New_Nullable_Int32(@"AID"); } }
        public ExpNode_Nullable_String<TA> AData { get { return this.New_Nullable_String(@"AData"); } }
    }
    public partial class TB : LogicalNode<TB>
    {
        public ExpNode_Nullable_Int32<TB> BID { get { return this.New_Nullable_Int32(@"BID"); } }
        public ExpNode_Nullable_String<TB> BData { get { return this.New_Nullable_String(@"BData"); } }
    }
    public partial class Tree : LogicalNode<Tree>
    {
        public ExpNode_Int32<Tree> TreeID { get { return this.New_Int32(@"TreeID"); } }
        public ExpNode_Nullable_Int32<Tree> TreePID { get { return this.New_Nullable_Int32(@"TreePID"); } }
        public ExpNode_String<Tree> Name { get { return this.New_String(@"Name"); } }
        public ExpNode_String<Tree> Memo { get { return this.New_String(@"Memo"); } }
    }
}