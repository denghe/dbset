using System;
using System.Collections.Generic;
using SqlLib.Orientations;

namespace DAL.Orientations.Tables.产品
{

    public partial class 产品 : LogicalNode<产品>
    {
        public ExpNode<产品> 产品编号 { get { return this.New_Column(@"产品编号"); } }
        public ExpNode<产品> 名称 { get { return this.New_Column(@"名称"); } }
        public ExpNode<产品> 说明 { get { return this.New_Column(@"说明"); } }
    }
}
namespace DAL.Orientations.Tables.雇员
{

    public partial class 雇员 : LogicalNode<雇员>
    {
        public ExpNode<雇员> 雇员编号 { get { return this.New_Column(@"雇员编号"); } }
        public ExpNode<雇员> 姓名 { get { return this.New_Column(@"姓名"); } }
        public ExpNode<雇员> 性别 { get { return this.New_Column(@"性别"); } }
        public ExpNode<雇员> 年龄 { get { return this.New_Column(@"年龄"); } }
        public ExpNode<雇员> 照片 { get { return this.New_Column(@"照片"); } }
    }
}
namespace DAL.Orientations.Tables.客户
{

    public partial class 订单 : LogicalNode<订单>
    {
        public ExpNode<订单> 订单编号 { get { return this.New_Column(@"订单编号"); } }
        public ExpNode<订单> 客户编号 { get { return this.New_Column(@"客户编号"); } }
        public ExpNode<订单> 经办雇员编号 { get { return this.New_Column(@"经办雇员编号"); } }
        public ExpNode<订单> 下单时间 { get { return this.New_Column(@"下单时间"); } }
    }
    public partial class 订单明细 : LogicalNode<订单明细>
    {
        public ExpNode<订单明细> 订单明细编号 { get { return this.New_Column(@"订单明细编号"); } }
        public ExpNode<订单明细> 订单编号 { get { return this.New_Column(@"订单编号"); } }
        public ExpNode<订单明细> 产品编号 { get { return this.New_Column(@"产品编号"); } }
        public ExpNode<订单明细> 数量 { get { return this.New_Column(@"数量"); } }
        public ExpNode<订单明细> 单价 { get { return this.New_Column(@"单价"); } }
    }
    public partial class 客户 : LogicalNode<客户>
    {
        public ExpNode<客户> 客户编号 { get { return this.New_Column(@"客户编号"); } }
        public ExpNode<客户> 姓名 { get { return this.New_Column(@"姓名"); } }
        public ExpNode<客户> 联系方式 { get { return this.New_Column(@"联系方式"); } }
    }
}
namespace DAL.Orientations.Tables.系统
{

    public partial class 管理员 : LogicalNode<管理员>
    {
        public ExpNode<管理员> 管理员编号 { get { return this.New_Column(@"管理员编号"); } }
        public ExpNode<管理员> 登录名 { get { return this.New_Column(@"登录名"); } }
        public ExpNode<管理员> 密码 { get { return this.New_Column(@"密码"); } }
        public ExpNode<管理员> 创建时间 { get { return this.New_Column(@"创建时间"); } }
    }
}