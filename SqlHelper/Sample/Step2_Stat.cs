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

    public static class Step2_Stat
    {
        public static void Execute()
        {
            /* 目标库中已被填充数据如下
            
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

            var e1 = E.雇员.Select(o => o.姓名 == "雇员Ａ").FirstOrDefault();
            var e2 = E.雇员.Select(o => o.姓名 == "雇员Ｂ").FirstOrDefault();

            var c1 = C.客户.Select(o => o.姓名 == "客户甲").FirstOrDefault();
            var c2 = C.客户.Select(o => o.姓名 == "客户乙").FirstOrDefault();

            var p1 = P.产品.Select(o => o.名称 == "产品１").FirstOrDefault();
            var p2 = P.产品.Select(o => o.名称 == "产品２").FirstOrDefault();

            var o1 = C.订单.Select(o => o.序列号 == "1").FirstOrDefault();
            var o2 = C.订单.Select(o => o.序列号 == "2").FirstOrDefault();
            var o3 = C.订单.Select(o => o.序列号 == "3").FirstOrDefault();
            var o4 = C.订单.Select(o => o.序列号 == "4").FirstOrDefault();
            var o5 = C.订单.Select(o => o.序列号 == "5").FirstOrDefault();
            var o6 = C.订单.Select(o => o.序列号 == "6").FirstOrDefault();
            var o7 = C.订单.Select(o => o.序列号 == "7").FirstOrDefault();
            var o8 = C.订单.Select(o => o.序列号 == "8").FirstOrDefault();

            P.产品.Count(o => o.名称.Like("%产品%"), o => o.产品编号, true).WL();

            "Step2_Stat Done.".WL();
        }
    }
}
