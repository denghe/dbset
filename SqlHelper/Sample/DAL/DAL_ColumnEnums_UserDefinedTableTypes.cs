using System;
using System.Collections.Generic;
using SqlLib.ColumnEnums;

namespace DAL.ColumnEnums.UserDefinedTableTypes.dbo
{

    public partial class udt_INT : ColumnList<udt_INT>
    {
        public udt_INT id { get { __columns.Add(0); return this; } }
        protected static string[] __cns = new string[]
        {
            @"id"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class udt_INT_STRING : ColumnList<udt_INT_STRING>
    {
        public udt_INT_STRING column1 { get { __columns.Add(0); return this; } }
        public udt_INT_STRING column2 { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"column1",
            @"column2"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class udt_test1 : ColumnList<udt_test1>
    {
        public udt_test1 id { get { __columns.Add(0); return this; } }
        protected static string[] __cns = new string[]
        {
            @"id"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
}