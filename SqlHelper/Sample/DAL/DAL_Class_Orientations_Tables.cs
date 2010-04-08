using System;
using System.Collections.Generic;
using SqlLib.Orientations;

namespace DAL.Orientations.Tables.dbo
{

    public partial class Child : LogicalNode<Child>
    {
        public ExpNode<Child> TreeID { get { return this.New_Column(@"TreeID"); } }
        public ExpNode<Child> ChildID { get { return this.New_Column(@"ChildID"); } }
        public ExpNode<Child> Name { get { return this.New_Column(@"Name"); } }
        public ExpNode<Child> CreateTime { get { return this.New_Column(@"CreateTime"); } }
        public ExpNode<Child> Memo { get { return this.New_Column(@"Memo"); } }
    }
    public partial class ChildLog : LogicalNode<ChildLog>
    {
        public ExpNode<ChildLog> ChildID { get { return this.New_Column(@"ChildID"); } }
        public ExpNode<ChildLog> ChildLogID { get { return this.New_Column(@"ChildLogID"); } }
        public ExpNode<ChildLog> CreateTime { get { return this.New_Column(@"CreateTime"); } }
        public ExpNode<ChildLog> LogContent { get { return this.New_Column(@"LogContent"); } }
    }
    public partial class DoublePK : LogicalNode<DoublePK>
    {
        public ExpNode<DoublePK> ID1 { get { return this.New_Column(@"ID1"); } }
        public ExpNode<DoublePK> ID2 { get { return this.New_Column(@"ID2"); } }
    }
    public partial class Orders : LogicalNode<Orders>
    {
        public ExpNode<Orders> OrderID { get { return this.New_Column(@"OrderID"); } }
        public ExpNode<Orders> memberID { get { return this.New_Column(@"memberID"); } }
        public ExpNode<Orders> orderDate { get { return this.New_Column(@"orderDate"); } }
    }
    public partial class t1 : LogicalNode<t1>
    {
        public ExpNode<t1> ID { get { return this.New_Column(@"ID"); } }
        public ExpNode<t1> Name { get { return this.New_Column(@"Name"); } }
        public ExpNode<t1> XML { get { return this.New_Column(@"XML"); } }
    }
    public partial class TA : LogicalNode<TA>
    {
        public ExpNode<TA> AID { get { return this.New_Column(@"AID"); } }
        public ExpNode<TA> AData { get { return this.New_Column(@"AData"); } }
    }
    public partial class TB : LogicalNode<TB>
    {
        public ExpNode<TB> BID { get { return this.New_Column(@"BID"); } }
        public ExpNode<TB> BData { get { return this.New_Column(@"BData"); } }
    }
    public partial class Tree : LogicalNode<Tree>
    {
        public ExpNode<Tree> TreeID { get { return this.New_Column(@"TreeID"); } }
        public ExpNode<Tree> TreePID { get { return this.New_Column(@"TreePID"); } }
        public ExpNode<Tree> Name { get { return this.New_Column(@"Name"); } }
        public ExpNode<Tree> Memo { get { return this.New_Column(@"Memo"); } }
    }
}