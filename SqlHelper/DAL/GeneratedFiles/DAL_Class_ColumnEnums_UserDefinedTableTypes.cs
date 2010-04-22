using System;
using System.Collections.Generic;
using SqlLib.ColumnEnums;

namespace DAL.ColumnEnums.UserDefinedTableTypes.表类型
{

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
    public partial class G_INT_INT : ColumnList<G_INT_INT>
    {
        public G_INT_INT c1 { get { __columns.Add(0); return this; } }
        public G_INT_INT c2 { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"c1",
            @"c2"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class G_INT_STRING : ColumnList<G_INT_STRING>
    {
        public G_INT_STRING c1 { get { __columns.Add(0); return this; } }
        public G_INT_STRING c2 { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"c1",
            @"c2"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class G_INT_STRING_STRING : ColumnList<G_INT_STRING_STRING>
    {
        public G_INT_STRING_STRING c1 { get { __columns.Add(0); return this; } }
        public G_INT_STRING_STRING c2 { get { __columns.Add(1); return this; } }
        public G_INT_STRING_STRING c3 { get { __columns.Add(2); return this; } }
        protected static string[] __cns = new string[]
        {
            @"c1",
            @"c2",
            @"c3"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class G_STRING : ColumnList<G_STRING>
    {
        public G_STRING c1 { get { __columns.Add(0); return this; } }
        protected static string[] __cns = new string[]
        {
            @"c1"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class G_STRING_DATETIME : ColumnList<G_STRING_DATETIME>
    {
        public G_STRING_DATETIME c1 { get { __columns.Add(0); return this; } }
        public G_STRING_DATETIME c2 { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"c1",
            @"c2"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
}