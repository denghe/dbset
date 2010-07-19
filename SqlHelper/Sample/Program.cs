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

    public class Test
    {
        public static void Main()
        {
            // init connect string
            DAL.SqlHelper.InitConnectString(
                server: "data,14333",
                username: "admin",
                password: "1",
                dbname: "Test"
            );

            Step1_InitData.Execute();
            Step2_Stat.Execute();

            RL();
        }

        public static void RL()
        {
            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        public static void WL(this object o)
        {
            Console.WriteLine(o);
        }
        public static void WL(this byte[] buff)
        {
            buff.ToHexString().WL();
        }
    }

}
