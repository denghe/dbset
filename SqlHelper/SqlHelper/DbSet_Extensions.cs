namespace SqlLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class DbSet_Extensions
    {
        public static DbSet Dump(this DbSet ds)
        {
            if (ds.Tables.Count > 0)
            {
                Console.Write("\r\nData Dump:");
                foreach (var dt in ds.Tables) Dump(dt);
            }
            if (ds.Messages.Count > 0)
            {
                Console.Write("\r\n\r\nPrint Messages:\r\n");
                foreach (var m in ds.Messages) Console.Write("\r\n" + m);
            }
            if (ds.Errors.Count > 0)
            {
                Console.Write("\r\n\r\nRaise Errors:");
                foreach (var e in ds.Errors) Console.Write("\r\n\r\n" + ToErrorString(e));
            }
            Console.Write("\r\n\r\nRecords Affected:" + ds.RecordsAffected);
            Console.Write("\r\n\r\nReturn:" + ds.ReturnValue);
            return ds;
        }
        public static DbTable Dump(this DbTable dt)
        {
            var count = dt.Columns.Count;
            Console.WriteLine("\r\n\r\nTable:" + ToNameString(dt.Name));
            Console.Write(ToNameString(dt.Columns[0].Name));
            for (var i = 1; i < count; i++)
                Console.Write("\t" + ToNameString(dt.Columns[i].Name));
            foreach (var dr in dt.Rows)
            {
                Console.Write("\r\n" + ToValueString(dr[0]));
                for (var i = 1; i < count; i++)
                    Console.Write("\t" + ToValueString(dr[i]));
            }
            return dt;
        }
        public static string ToNameString(string s)
        {
            if (string.IsNullOrEmpty(s)) return "[NoName]";
            return s;
        }
        public static string ToValueString(object o)
        {
            return o == DBNull.Value ? "[Null]" : o.ToString();
        }
        public static string ToErrorString(SqlError e)
        {
            return string.Format(@"Class       = {0}
LineNumber  = {1}
Message     = {2}
Number      = {3}
Procedure   = {4}
Server      = {5}
Source      = {6}
State       = {7}",
        e.Class, e.LineNumber, e.Message, e.Number, e.Procedure, e.Server, e.Source, e.State);
        }
    }
}