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
            foreach (var e in ds.Errors) Console.Write("\r\n\r\n" + e.ToString());
        }
        Console.Write("\r\n\r\nRecords Affected:" + ds.RecordsAffected);
        Console.Write("\r\n\r\nReturn:" + ds.ReturnValue);
        return ds;
    }
    public static byte[] GetBytes(this DbSet ds)
    {
        throw new Exception("todo");
    }
    public static DbSet ToDbSet(this byte[] bytes)
    {
        throw new Exception("todo");
    }

    public static DbTable Dump(this DbTable dt)
    {
        var count = dt.Columns.Count;
        Console.WriteLine("\r\n\r\nTable:" + dt.Name.ToNameString());
        Console.Write(dt.Columns[0].Name.ToNameString());
        for (var i = 1; i < count; i++)
            Console.Write("\t" + dt.Columns[i].Name.ToNameString());
        foreach (var dr in dt.Rows)
        {
            Console.Write("\r\n" + dr[0].ToValueString());
            for (var i = 1; i < count; i++)
                Console.Write("\t" + dr[i].ToValueString());
        }
        return dt;
    }
    public static string ToNameString(this string s)
    {
        if (string.IsNullOrEmpty(s)) return "[NoName]";
        return s;
    }
    public static string ToValueString(this object o)
    {
        return o == DBNull.Value ? "[Null]" : o.ToString();
    }
}