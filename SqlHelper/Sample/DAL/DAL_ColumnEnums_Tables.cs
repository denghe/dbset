using System;
using System.Collections.Generic;
using SqlLib.ColumnEnums;

namespace DAL.ColumnEnums.Tables.dbo
{

    public partial class Formula_890 : ColumnList<Formula_890>
    {
        public Formula_890 Name { get { __columns.Add(0); return this; } }
        public Formula_890 Expression { get { __columns.Add(1); return this; } }
        public Formula_890 Value { get { __columns.Add(2); return this; } }
        public Formula_890 IsGenerator { get { __columns.Add(3); return this; } }
        protected static string[] __cns = new string[]
        {
            @"Name",
            @"Expression",
            @"Value",
            @"IsGenerator"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class FS : ColumnList<FS>
    {
        public FS ID { get { __columns.Add(0); return this; } }
        public FS Category { get { __columns.Add(1); return this; } }
        public FS Stream { get { __columns.Add(2); return this; } }
        protected static string[] __cns = new string[]
        {
            @"ID",
            @"Category",
            @"Stream"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class ParentChildOrg : ColumnList<ParentChildOrg>
    {
        public ParentChildOrg EmployeeID { get { __columns.Add(0); return this; } }
        public ParentChildOrg ManagerId { get { __columns.Add(1); return this; } }
        public ParentChildOrg EmployeeName { get { __columns.Add(2); return this; } }
        protected static string[] __cns = new string[]
        {
            @"EmployeeID",
            @"ManagerId",
            @"EmployeeName"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class t : ColumnList<t>
    {
        public t a { get { __columns.Add(0); return this; } }
        public t b { get { __columns.Add(1); return this; } }
        public t c { get { __columns.Add(2); return this; } }
        protected static string[] __cns = new string[]
        {
            @"a",
            @"b",
            @"c"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class t1 : ColumnList<t1>
    {
        public t1 ID { get { __columns.Add(0); return this; } }
        public t1 PID { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"ID",
            @"PID"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class t2 : ColumnList<t2>
    {
        public t2 ID { get { __columns.Add(0); return this; } }
        public t2 Name { get { __columns.Add(1); return this; } }
        public t2 CreateTime { get { __columns.Add(2); return this; } }
        protected static string[] __cns = new string[]
        {
            @"ID",
            @"Name",
            @"CreateTime"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class tree : ColumnList<tree>
    {
        public tree Parent { get { __columns.Add(0); return this; } }
        public tree Children { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"Parent",
            @"Children"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
}
namespace DAL.ColumnEnums.Tables.MySchema
{

    public partial class FS : ColumnList<FS>
    {
        public FS dbo_FSID { get { __columns.Add(0); return this; } }
        public FS asdf { get { __columns.Add(1); return this; } }
        public FS ID { get { __columns.Add(2); return this; } }
        protected static string[] __cns = new string[]
        {
            @"dbo_FSID",
            @"asdf",
            @"ID"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
}
namespace DAL.ColumnEnums.Tables.Schema1
{

    public partial class T1 : ColumnList<T1>
    {
        public T1 ID { get { __columns.Add(0); return this; } }
        public T1 PID { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"ID",
            @"PID"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
}