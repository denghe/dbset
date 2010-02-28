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
            Console.SetWindowSize(Console.WindowWidth, 50);

            // int sql connection
            SqlHelper.InitConnectString("data,14333", username: "admin");



            Console.ReadLine();
        }
    }
}
