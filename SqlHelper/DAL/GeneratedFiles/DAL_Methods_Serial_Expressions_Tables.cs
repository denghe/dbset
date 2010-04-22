using System;
using System.Collections.Generic;
using SqlLib.Expressions;

namespace DAL.Expressions.Tables.产品
{

    partial class 产品
    {
        #region Serial

        public 产品() { }
        public 产品(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public 产品(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
}
namespace DAL.Expressions.Tables.雇员
{

    partial class 雇员
    {
        #region Serial

        public 雇员() { }
        public 雇员(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public 雇员(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
}
namespace DAL.Expressions.Tables.客户
{

    partial class 订单
    {
        #region Serial

        public 订单() { }
        public 订单(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public 订单(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
    partial class 订单明细
    {
        #region Serial

        public 订单明细() { }
        public 订单明细(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public 订单明细(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
    partial class 客户
    {
        #region Serial

        public 客户() { }
        public 客户(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public 客户(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
}
namespace DAL.Expressions.Tables.系统
{

    partial class 管理员
    {
        #region Serial

        public 管理员() { }
        public 管理员(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public 管理员(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
}