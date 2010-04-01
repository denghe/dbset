using System;
using System.Collections.Generic;
using SqlLib.Orientations;

namespace DAL.Orientations.Tables.dbo
{

    public partial class Formula_890 : LogicalNode<Formula_890>
    {
        public ExpNode<Formula_890> Name { get { return this.New_Column(@"Name"); } }
        public ExpNode<Formula_890> Expression { get { return this.New_Column(@"Expression"); } }
        public ExpNode<Formula_890> Value { get { return this.New_Column(@"Value"); } }
        public ExpNode<Formula_890> IsGenerator { get { return this.New_Column(@"IsGenerator"); } }
    }
    public partial class FS : LogicalNode<FS>
    {
        public ExpNode<FS> ID { get { return this.New_Column(@"ID"); } }
        public ExpNode<FS> Category { get { return this.New_Column(@"Category"); } }
        public ExpNode<FS> Stream { get { return this.New_Column(@"Stream"); } }
    }
    public partial class ParentChildOrg : LogicalNode<ParentChildOrg>
    {
        public ExpNode<ParentChildOrg> EmployeeID { get { return this.New_Column(@"EmployeeID"); } }
        public ExpNode<ParentChildOrg> ManagerId { get { return this.New_Column(@"ManagerId"); } }
        public ExpNode<ParentChildOrg> EmployeeName { get { return this.New_Column(@"EmployeeName"); } }
    }
    public partial class t : LogicalNode<t>
    {
        public ExpNode<t> a { get { return this.New_Column(@"a"); } }
        public ExpNode<t> b { get { return this.New_Column(@"b"); } }
        public ExpNode<t> c { get { return this.New_Column(@"c"); } }
    }
    public partial class t1 : LogicalNode<t1>
    {
        public ExpNode<t1> ID { get { return this.New_Column(@"ID"); } }
        public ExpNode<t1> PID { get { return this.New_Column(@"PID"); } }
    }
    public partial class t2 : LogicalNode<t2>
    {
        public ExpNode<t2> ID { get { return this.New_Column(@"ID"); } }
        public ExpNode<t2> Name { get { return this.New_Column(@"Name"); } }
        public ExpNode<t2> CreateTime { get { return this.New_Column(@"CreateTime"); } }
    }
    public partial class t3 : LogicalNode<t3>
    {
        public ExpNode<t3> c1 { get { return this.New_Column(@"c1"); } }
        public ExpNode<t3> c2 { get { return this.New_Column(@"c2"); } }
        public ExpNode<t3> c3 { get { return this.New_Column(@"c3"); } }
        public ExpNode<t3> c4 { get { return this.New_Column(@"c4"); } }
    }
    public partial class tree : LogicalNode<tree>
    {
        public ExpNode<tree> Parent { get { return this.New_Column(@"Parent"); } }
        public ExpNode<tree> Children { get { return this.New_Column(@"Children"); } }
    }
}
namespace DAL.Orientations.Tables.MySchema
{

    public partial class FS : LogicalNode<FS>
    {
        public ExpNode<FS> dbo_FSID { get { return this.New_Column(@"dbo_FSID"); } }
        public ExpNode<FS> asdf { get { return this.New_Column(@"asdf"); } }
        public ExpNode<FS> ID { get { return this.New_Column(@"ID"); } }
    }
}
namespace DAL.Orientations.Tables.Schema1
{

    public partial class T1 : LogicalNode<T1>
    {
        public ExpNode<T1> ID { get { return this.New_Column(@"ID"); } }
        public ExpNode<T1> PID { get { return this.New_Column(@"PID"); } }
    }
}