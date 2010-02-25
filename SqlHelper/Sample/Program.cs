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

    using DAL;
    using SpResultConfig;
    using System.Diagnostics;
    using System.IO;

    public class Test
    {
        public static void Main()
        {
            // 初始化连接串
            SqlHelper.InitConnectString("sql", password: "1");


        }
    }
}
