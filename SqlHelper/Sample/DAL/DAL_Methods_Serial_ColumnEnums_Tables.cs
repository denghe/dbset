using System;
using System.Collections.Generic;
using SqlLib.ColumnEnums;

namespace DAL.ColumnEnums.Tables.dbo
{

    partial class Child
    {
        #region Serial

        public Child() { }
        public Child(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public Child(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
    partial class ChildLog
    {
        #region Serial

        public ChildLog() { }
        public ChildLog(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public ChildLog(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
    partial class DoublePK
    {
        #region Serial

        public DoublePK() { }
        public DoublePK(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public DoublePK(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
    partial class Orders
    {
        #region Serial

        public Orders() { }
        public Orders(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public Orders(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
    partial class t1
    {
        #region Serial

        public t1() { }
        public t1(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public t1(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
    partial class TA
    {
        #region Serial

        public TA() { }
        public TA(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public TA(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
    partial class TB
    {
        #region Serial

        public TB() { }
        public TB(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public TB(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
    partial class Tree
    {
        #region Serial

        public Tree() { }
        public Tree(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public Tree(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
}