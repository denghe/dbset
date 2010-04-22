using System;
using System.Collections.Generic;
using SqlLib.ColumnEnums;

namespace DAL.ColumnEnums.Tables.产品
{

    public partial class 产品 : ColumnList<产品>
    {
        public 产品 产品编号 { get { __columns.Add(0); return this; } }
        public 产品 名称 { get { __columns.Add(1); return this; } }
        public 产品 说明 { get { __columns.Add(2); return this; } }
        protected static string[] __cns = new string[]
        {
            @"产品编号",
            @"名称",
            @"说明"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
}
namespace DAL.ColumnEnums.Tables.雇员
{

    public partial class 雇员 : ColumnList<雇员>
    {
        public 雇员 雇员编号 { get { __columns.Add(0); return this; } }
        public 雇员 姓名 { get { __columns.Add(1); return this; } }
        public 雇员 性别 { get { __columns.Add(2); return this; } }
        public 雇员 年龄 { get { __columns.Add(3); return this; } }
        public 雇员 照片 { get { __columns.Add(4); return this; } }
        protected static string[] __cns = new string[]
        {
            @"雇员编号",
            @"姓名",
            @"性别",
            @"年龄",
            @"照片"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
}
namespace DAL.ColumnEnums.Tables.客户
{

    public partial class 订单 : ColumnList<订单>
    {
        public 订单 订单编号 { get { __columns.Add(0); return this; } }
        public 订单 客户编号 { get { __columns.Add(1); return this; } }
        public 订单 经办雇员编号 { get { __columns.Add(2); return this; } }
        public 订单 下单时间 { get { __columns.Add(3); return this; } }
        protected static string[] __cns = new string[]
        {
            @"订单编号",
            @"客户编号",
            @"经办雇员编号",
            @"下单时间"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class 订单明细 : ColumnList<订单明细>
    {
        public 订单明细 订单明细编号 { get { __columns.Add(0); return this; } }
        public 订单明细 订单编号 { get { __columns.Add(1); return this; } }
        public 订单明细 产品编号 { get { __columns.Add(2); return this; } }
        public 订单明细 数量 { get { __columns.Add(3); return this; } }
        public 订单明细 单价 { get { __columns.Add(4); return this; } }
        protected static string[] __cns = new string[]
        {
            @"订单明细编号",
            @"订单编号",
            @"产品编号",
            @"数量",
            @"单价"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class 客户 : ColumnList<客户>
    {
        public 客户 客户编号 { get { __columns.Add(0); return this; } }
        public 客户 姓名 { get { __columns.Add(1); return this; } }
        public 客户 联系方式 { get { __columns.Add(2); return this; } }
        protected static string[] __cns = new string[]
        {
            @"客户编号",
            @"姓名",
            @"联系方式"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
}
namespace DAL.ColumnEnums.Tables.系统
{

    public partial class 管理员 : ColumnList<管理员>
    {
        public 管理员 管理员编号 { get { __columns.Add(0); return this; } }
        public 管理员 登录名 { get { __columns.Add(1); return this; } }
        public 管理员 密码 { get { __columns.Add(2); return this; } }
        public 管理员 创建时间 { get { __columns.Add(3); return this; } }
        protected static string[] __cns = new string[]
        {
            @"管理员编号",
            @"登录名",
            @"密码",
            @"创建时间"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
}