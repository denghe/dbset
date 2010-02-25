using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SpResultConfig
{
    /*

    XML 示例：
     
<Config>
	<Options Select=""True"" Return=""True"" Print=""True"" Raiserror=""True"" />

	<Result Name=""Total"" 		Category=""Scalar"" 	Type=""Int32"" 	Description=""总行数"" />
	<Result Name=""PageSize"" 	Category=""Scalar"" 	Type=""Int32"" 	Description=""每页行数"" />
	<Result Name=""Rows"" 		Category=""TableRows"" 	Struct=""xxx""  Schema=""dbo"" 	 			Description=""dbo.xxx表当前页的数据"" />
	<Result Name=""SomeData1""  Category=""StructRow""  Struct=""asdf"" Description=""附带的相关明细数据1（单行）"" />
	<Result Name=""SomeData2""  Category=""StructRows"" Struct=""qwer"" Description=""附带的相关明细数据2（多行）"" />

    <Struct Name=""asdf"">
		<Column Name=""ID"" 	    Type=""Int32"" 	    Nullable=""False""  Description=""编号"" />
		<Column Name=""Name"" 	    Type=""String"" 	Nullable=""False""  Description=""名称"" />
		<Column Name=""SaleTime"" 	Type=""DateTime"" 	Nullable=""True""   Description=""出货时间"" />
    </Struct>
    <Struct Name=""qwer"">
		<Column Name=""ID"" 	    Type=""Int32"" 	    Nullable=""False""  Description=""编号"" />
		<Column Name=""Price"" 	    Type=""Decimal""    Nullable=""False""  Description=""价格"" />
    </Struct>
</Config>

    */

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
            throw new Exception("todo");
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
