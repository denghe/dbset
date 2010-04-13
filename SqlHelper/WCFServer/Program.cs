using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;

namespace WCFServer
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlLib.SqlHelper.InitConnectString(server: "sql");

            Console.WriteLine("Starting host...");

            var host = new ServiceHost(typeof(MyService));
            host.Open();
            Console.WriteLine("Started.");

            Console.Write("Press <ENTER> to exit");
            Console.ReadLine();
            host.Close();

        }
    }
}