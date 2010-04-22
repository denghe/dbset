using System;
using System.Collections.Generic;
using SqlLib.Expressions;

namespace DAL.Expressions.Tables.产品
{

    public partial class 产品 : LogicalNode<产品>
    {
        public ExpNode_Int32<产品> 产品编号 { get { return this.New_Int32(@"产品编号"); } }
        public ExpNode_String<产品> 名称 { get { return this.New_String(@"名称"); } }
        public ExpNode_String<产品> 说明 { get { return this.New_String(@"说明"); } }
    }
}
namespace DAL.Expressions.Tables.雇员
{

    public partial class 雇员 : LogicalNode<雇员>
    {
        public ExpNode_Int32<雇员> 雇员编号 { get { return this.New_Int32(@"雇员编号"); } }
        public ExpNode_String<雇员> 姓名 { get { return this.New_String(@"姓名"); } }
        public ExpNode_Boolean<雇员> 性别 { get { return this.New_Boolean(@"性别"); } }
        public ExpNode_Int32<雇员> 年龄 { get { return this.New_Int32(@"年龄"); } }
        public ExpNode_Bytes<雇员> 照片 { get { return this.New_Bytes(@"照片"); } }
    }
}
namespace DAL.Expressions.Tables.客户
{

    public partial class 订单 : LogicalNode<订单>
    {
        public ExpNode_Int32<订单> 订单编号 { get { return this.New_Int32(@"订单编号"); } }
        public ExpNode_Int32<订单> 客户编号 { get { return this.New_Int32(@"客户编号"); } }
        public ExpNode_Int32<订单> 经办雇员编号 { get { return this.New_Int32(@"经办雇员编号"); } }
        public ExpNode_DateTime<订单> 下单时间 { get { return this.New_DateTime(@"下单时间"); } }
    }
    public partial class 订单明细 : LogicalNode<订单明细>
    {
        public ExpNode_Int32<订单明细> 订单明细编号 { get { return this.New_Int32(@"订单明细编号"); } }
        public ExpNode_Int32<订单明细> 订单编号 { get { return this.New_Int32(@"订单编号"); } }
        public ExpNode_Int32<订单明细> 产品编号 { get { return this.New_Int32(@"产品编号"); } }
        public ExpNode_Decimal<订单明细> 数量 { get { return this.New_Decimal(@"数量"); } }
        public ExpNode_Decimal<订单明细> 单价 { get { return this.New_Decimal(@"单价"); } }
    }
    public partial class 客户 : LogicalNode<客户>
    {
        public ExpNode_Int32<客户> 客户编号 { get { return this.New_Int32(@"客户编号"); } }
        public ExpNode_String<客户> 姓名 { get { return this.New_String(@"姓名"); } }
        public ExpNode_String<客户> 联系方式 { get { return this.New_String(@"联系方式"); } }
    }
}
namespace DAL.Expressions.Tables.系统
{

    public partial class 管理员 : LogicalNode<管理员>
    {
        public ExpNode_Int32<管理员> 管理员编号 { get { return this.New_Int32(@"管理员编号"); } }
        public ExpNode_String<管理员> 登录名 { get { return this.New_String(@"登录名"); } }
        public ExpNode_String<管理员> 密码 { get { return this.New_String(@"密码"); } }
        public ExpNode_DateTime<管理员> 创建时间 { get { return this.New_DateTime(@"创建时间"); } }
    }
}