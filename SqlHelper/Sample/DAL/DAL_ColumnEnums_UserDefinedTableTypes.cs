using System;
using System.Collections.Generic;
using SqlLib.ColumnEnums;

namespace DAL.ColumnEnums.UserDefinedTableTypes.dbo
{

    public partial class FS : ColumnList<FS>
    {
        public FS Col1 { get { __columns.Add(0); return this; } }
        public FS Col2 { get { __columns.Add(1); return this; } }
        public FS Col3 { get { __columns.Add(2); return this; } }
        protected static string[] __cns = new string[]
        {
            @"Col1",
            @"Col2",
            @"Col3"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class G_INT : ColumnList<G_INT>
    {
        public G_INT c1 { get { __columns.Add(0); return this; } }
        protected static string[] __cns = new string[]
        {
            @"c1"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class G_INT_STR : ColumnList<G_INT_STR>
    {
        public G_INT_STR c1 { get { __columns.Add(0); return this; } }
        public G_INT_STR c2 { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"c1",
            @"c2"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class MyType1 : ColumnList<MyType1>
    {
        public MyType1 Str { get { __columns.Add(0); return this; } }
        public MyType1 Num { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"Str",
            @"Num"
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
}