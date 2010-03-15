namespace DAL.Expressions.Tables.dbo
{
    using System;
    using System.Collections.Generic;

    using SqlLib.Expressions;

    public partial class Formula_890 : LogicalNode<Formula_890>
    {
        public ExpNode_String<Formula_890> Name { get { return base.New_String(@"Name"); } }
        public ExpNode_Nullable_String<Formula_890> Expression { get { return this.New_Nullable_String(@"Expression"); } }
        public ExpNode_Nullable_String<Formula_890> Value { get { return this.New_Nullable_String(@"Value"); } }
        public ExpNode_Nullable_Boolean<Formula_890> IsGenerator { get { return this.New_Nullable_Boolean(@"IsGenerator"); } }
    }
    public partial class FS : LogicalNode<FS>
    {
        public ExpNode_Guid<FS> ID { get { return this.New_Guid(@"ID"); } }
        public ExpNode_Object<FS> Category { get { return this.New_Object(@"Category"); } }
        public ExpNode_Nullable_Bytes<FS> Stream { get { return this.New_Nullable_Bytes(@"Stream"); } }
    }
    public partial class ParentChildOrg : LogicalNode<ParentChildOrg>
    {
        public ExpNode_Int32<ParentChildOrg> EmployeeID { get { return this.New_Int32(@"EmployeeID"); } }
        public ExpNode_Nullable_Int32<ParentChildOrg> ManagerId { get { return this.New_Nullable_Int32(@"ManagerId"); } }
        public ExpNode_Nullable_String<ParentChildOrg> EmployeeName { get { return this.New_Nullable_String(@"EmployeeName"); } }
    }
    public partial class t : LogicalNode<t>
    {
        public ExpNode_Int32<t> a { get { return this.New_Int32(@"a"); } }
        public ExpNode_Int32<t> b { get { return this.New_Int32(@"b"); } }
        public ExpNode_Bytes<t> c { get { return this.New_Bytes(@"c"); } }
    }
    public partial class t1 : LogicalNode<t1>
    {
        public ExpNode_Int32<t1> ID { get { return this.New_Int32(@"ID"); } }
        public ExpNode_Nullable_Int32<t1> PID { get { return this.New_Nullable_Int32(@"PID"); } }
    }
    public partial class t2 : LogicalNode<t2>
    {
        public ExpNode_Int32<t2> ID { get { return this.New_Int32(@"ID"); } }
        public ExpNode_String<t2> Name { get { return this.New_String(@"Name"); } }
        public ExpNode_DateTime<t2> CreateTime { get { return this.New_DateTime(@"CreateTime"); } }
    }
    public partial class tree : LogicalNode<tree>
    {
        public ExpNode_String<tree> Parent { get { return this.New_String(@"Parent"); } }
        public ExpNode_Nullable_String<tree> Children { get { return this.New_Nullable_String(@"Children"); } }
    }
}namespace DAL.Expressions.Tables.MySchema
{
    using System;
    using System.Collections.Generic;

    using SqlLib.Expressions;

    public partial class FS : LogicalNode<FS>
    {
        public ExpNode_Guid<FS> dbo_FSID { get { return this.New_Guid(@"dbo_FSID"); } }
        public ExpNode_Nullable_String<FS> asdf { get { return this.New_Nullable_String(@"asdf"); } }
        public ExpNode_Int32<FS> ID { get { return this.New_Int32(@"ID"); } }
    }
}namespace DAL.Expressions.Tables.Schema1
{
    using System;
    using System.Collections.Generic;

    using SqlLib.Expressions;

    public partial class T1 : LogicalNode<T1>
    {
        public ExpNode_Int32<T1> ID { get { return this.New_Int32(@"ID"); } }
        public ExpNode_Nullable_Int32<T1> PID { get { return this.New_Nullable_Int32(@"PID"); } }
    }
}