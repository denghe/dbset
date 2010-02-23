using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SpResultConfig
{
    public class Config
    {
        public Options Options { get; set; }
        public List<Result> Results { get; set; }
        public List<Struct> Structs { get; set; }
    }
    public class Options
    {
        public bool Select { get; set; }
        public bool Return { get; set; }
        public bool Print { get; set; }
        public bool Raiserror { get; set; }
    }
    public class Result
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public Type Type { get; set; }
        public string Struct { get; set; }
        public string Schema { get; set; }
        public string Description { get; set; }
    }
    public class Struct
    {
        public string Name { get; set; }
        public List<Column> Columns { get; set; }
    }
    public class Column
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public bool Nullable { get; set; }
        public string Description { get; set; }
    }
    public enum Category
    {
        Unknown,
        Scalar,
        TableRow,
        ViewRow,
        TableTypeRow,
        TableRows,
        ViewRows,
        TableTypeRows,
        StructRow,
        StructRows
    }
    public enum Type
    {
        Unknown,
        Byte,
        Bytes,
        Int16,
        Int32,
        Int64,
        Decimal,
        DateTime,
        String
    }

    public static partial class Extensions
    {
        public static string GetXml(this Config cfg)
        {
            // todo
            return "";
        }
        public static Config GetConfig(this string xml)
        {
            var xe = XElement.Parse(xml);
            var config = new Config
            {
                Options = (from XElement ele in xe.Elements("Options")
                           select new Options
                           {
                               Return = ele.Attribute("Return").GetValue<bool>(true),
                               Print = ele.Attribute("Print").GetValue<bool>(false),
                               Raiserror = ele.Attribute("Raiserror").GetValue<bool>(false),
                               Select = ele.Attribute("Select").GetValue<bool>(true),
                           }).First(),
                Results = (from XElement ele in xe.Elements("Result")
                           select new Result
                           {
                               Name = ele.Attribute("Name").GetValue<string>(""),
                               Category = ele.Attribute("Category").GetCategoryValue(),
                               Type = ele.Attribute("Type").GetTypeValue(),
                               Struct = ele.Attribute("Struct").GetValue<string>(""),
                               Schema = ele.Attribute("Schema").GetValue<string>(""),
                               Description = ele.Attribute("Description").GetValue<string>("")
                           }).ToList(),
                Structs = (from XElement ele in xe.Elements("Struct")
                           select new Struct
                           {
                               Name = ele.Attribute("Name").GetValue<string>(""),
                               Columns = (from XElement e in ele.Elements("Column")
                                          select new Column
                                          {
                                              Name = e.Attribute("Name").GetValue<string>(""),
                                              Type = e.Attribute("Type").GetTypeValue(),
                                              Nullable = e.Attribute("Nullable").GetValue<bool>(false),
                                              Description = e.Attribute("Description").GetValue<string>("")
                                          }).ToList()
                           }).ToList()
            };

            // todo: check
            return config;
        }
        public static T GetValue<T>(this XAttribute att, T deft)
        {
            if (att == null) return deft;
            return (T)Convert.ChangeType(att.Value, typeof(T));
        }
        public static Type GetTypeValue(this XAttribute att)
        {
            if (att == null) return Type.Unknown;
            Type t;
            if (Enum.TryParse<Type>(att.Value, out t)) return t;
            return Type.Unknown;
        }
        public static Category GetCategoryValue(this XAttribute att)
        {
            if (att == null) return Category.Unknown;
            Category t;
            if (Enum.TryParse<Category>(att.Value, out t)) return t;
            return Category.Unknown;
        }
    }

}
