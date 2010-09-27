namespace Sample
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Data;
    using System.Diagnostics;
    using System.IO;

    using SqlLib;
    using DAL.Database.Tables;
    using E = DAL.Database.Tables.雇员;
    using C = DAL.Database.Tables.客户;
    using P = DAL.Database.Tables.产品;

    public static class Step1_InitData
    {
        public static void Execute()
        {
            // 清空相关表的数据
            E.雇员.Delete(o => o);
            C.客户.Delete(o => o);
            P.产品.Delete(o => o);

            // 往目标库填充数据
            /*
要添加的数据有:

雇员Ａ, 雇员Ｂ
客户甲, 客户乙
产品１, 产品２

订单
序列号 1，客户甲，雇员Ａ
序列号 2，客户甲，雇员Ａ
序列号 3，客户甲，雇员Ａ
序列号 4，客户甲，雇员Ａ
序列号 5，客户甲，雇员Ｂ
序列号 6，客户甲，雇员Ｂ
序列号 7，客户乙，雇员Ａ
序列号 8，客户乙，雇员Ｂ
             */

            var e1 = new E.雇员
            {
                姓名 = "雇员Ａ",
                性别 = true,
                年龄 = 18,
                照片 = new byte[] { }
            };
            e1.Insert(
                fillCols: o => o.雇员编号
            );

            var e2 = new E.雇员
            {
                姓名 = "雇员Ｂ",
                性别 = false,
                年龄 = 38,
                照片 = new byte[] { }
            };
            e2.Insert(
                fillCols: o => o.雇员编号
            );

            var c1 = new C.客户
            {
                姓名 = "客户甲",
                联系方式 = "不清楚"
            };
            c1.Insert();

            var c2 = new C.客户
            {
                姓名 = "客户乙",
                联系方式 = "还是不清楚"
            };
            c2.Insert();

            var p1 = new P.产品
            {
                名称 = "产品１",
                说明 = "这是产品１说明喔"
            };
            p1.Insert();

            var p2 = new P.产品
            {
                名称 = "产品２",
                说明 = "这是产品２的说明喔"
            };
            p2.Insert();

            Func<string, C.客户, E.雇员, C.订单> MakeOrder = (serial, c, e) =>
            {
                var tmp = new C.订单
                {
                    序列号 = serial,
                    经办雇员编号 = e.雇员编号,
                    客户编号 = c.客户编号
                };
                tmp.Insert(
                    o => o.序列号.经办雇员编号.客户编号,
                    o => o.订单编号.下单时间
                );
                return tmp;
            };

            var o1 = MakeOrder("1", c1, e1);
            var o2 = MakeOrder("2", c1, e1);
            var o3 = MakeOrder("3", c1, e1);
            var o4 = MakeOrder("4", c1, e1);
            var o5 = MakeOrder("5", c1, e2);
            var o6 = MakeOrder("6", c1, e2);
            var o7 = MakeOrder("7", c2, e1);
            var o8 = MakeOrder("8", c2, e2);

            Func<C.订单, P.产品, int, double, C.订单明细> MakeOrderDetail = (o, p, n, m) =>
            {
                var tmp = new C.订单明细
                {
                    订单编号 = o.订单编号,
                    产品编号 = p.产品编号,
                    数量 = n,
                    单价 = (decimal)m
                };
                tmp.Insert();
                return tmp;
            };

            var od1_1 = MakeOrderDetail(o1, p1, 1, 1.23);

            var od2_2 = MakeOrderDetail(o1, p2, 3, 2.34);

            var od3_1 = MakeOrderDetail(o1, p1, 45, 1.23);
            var od3_2 = MakeOrderDetail(o1, p2, 2, 2.34);

            var od4_1 = MakeOrderDetail(o1, p1, 3, 1.23);
            var od4_2 = MakeOrderDetail(o1, p2, 67, 2.34);

            var od5_1 = MakeOrderDetail(o1, p1, 12, 1.23);
            var od5_2 = MakeOrderDetail(o1, p2, 27, 2.34);

            var od6_2 = MakeOrderDetail(o1, p2, 23, 2.34);

            var od7_2 = MakeOrderDetail(o1, p2, 25, 2.34);

            var od8_1 = MakeOrderDetail(o1, p1, 11, 1.23);

            "Step1_InitData Done.".WL();
        }
    }
}
