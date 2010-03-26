using System;
using System.Collections.Generic;
using SqlLib.ColumnEnums;

namespace DAL.ColumnEnums.Tables.dbo
{

    public partial class Child : ColumnList<Child>
    {
        public Child TreeID { get { __columns.Add(0); return this; } }
        public Child ChildID { get { __columns.Add(1); return this; } }
        public Child Name { get { __columns.Add(2); return this; } }
        public Child CreateTime { get { __columns.Add(3); return this; } }
        public Child Memo { get { __columns.Add(4); return this; } }
        protected static string[] __cns = new string[]
        {
            @"TreeID",
            @"ChildID",
            @"Name",
            @"CreateTime",
            @"Memo"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class ChildLog : ColumnList<ChildLog>
    {
        public ChildLog ChildID { get { __columns.Add(0); return this; } }
        public ChildLog ChildLogID { get { __columns.Add(1); return this; } }
        public ChildLog CreateTime { get { __columns.Add(2); return this; } }
        public ChildLog LogContent { get { __columns.Add(3); return this; } }
        protected static string[] __cns = new string[]
        {
            @"ChildID",
            @"ChildLogID",
            @"CreateTime",
            @"LogContent"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class DoublePK : ColumnList<DoublePK>
    {
        public DoublePK ID1 { get { __columns.Add(0); return this; } }
        public DoublePK ID2 { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"ID1",
            @"ID2"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class Orders : ColumnList<Orders>
    {
        public Orders OrderID { get { __columns.Add(0); return this; } }
        public Orders memberID { get { __columns.Add(1); return this; } }
        public Orders orderDate { get { __columns.Add(2); return this; } }
        protected static string[] __cns = new string[]
        {
            @"OrderID",
            @"memberID",
            @"orderDate"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class t1 : ColumnList<t1>
    {
        public t1 ID { get { __columns.Add(0); return this; } }
        public t1 Name { get { __columns.Add(1); return this; } }
        public t1 XML { get { __columns.Add(2); return this; } }
        protected static string[] __cns = new string[]
        {
            @"ID",
            @"Name",
            @"XML"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class TA : ColumnList<TA>
    {
        public TA AID { get { __columns.Add(0); return this; } }
        public TA AData { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"AID",
            @"AData"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class TB : ColumnList<TB>
    {
        public TB BID { get { __columns.Add(0); return this; } }
        public TB BData { get { __columns.Add(1); return this; } }
        protected static string[] __cns = new string[]
        {
            @"BID",
            @"BData"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
    public partial class Tree : ColumnList<Tree>
    {
        public Tree TreeID { get { __columns.Add(0); return this; } }
        public Tree TreePID { get { __columns.Add(1); return this; } }
        public Tree Name { get { __columns.Add(2); return this; } }
        public Tree Memo { get { __columns.Add(3); return this; } }
        protected static string[] __cns = new string[]
        {
            @"TreeID",
            @"TreePID",
            @"Name",
            @"Memo"
        };
        public override string GetColumnName(int i) {
            return __cns[i];
        }
    }
}