using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SqlLib;

namespace DAL.Database.Tables.产品
{

    partial class 产品 : ISerial
    {

        #region Constructor

        public 产品() {
        }
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

        #region Serial
        public byte[] GetBytes()
        {
            return new byte[][]
            {
                this.产品编号.GetBytes(),
                this.名称.GetBytes(),
                this.说明.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.产品编号 = buffer.ToInt32(ref startIndex);
            this.名称 = buffer.ToString(ref startIndex);
            this.说明 = buffer.ToString(ref startIndex);
        }
        #endregion

    }
}
namespace DAL.Database.Tables.雇员
{

    partial class 雇员 : ISerial
    {

        #region Constructor

        public 雇员() {
        }
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

        #region Serial
        public byte[] GetBytes()
        {
            return new byte[][]
            {
                this.雇员编号.GetBytes(),
                this.姓名.GetBytes(),
                this.性别.GetBytes(),
                this.年龄.GetBytes(),
                this.照片.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.雇员编号 = buffer.ToInt32(ref startIndex);
            this.姓名 = buffer.ToString(ref startIndex);
            this.性别 = buffer.ToBoolean(ref startIndex);
            this.年龄 = buffer.ToInt32(ref startIndex);
            this.照片 = buffer.ToBytes(ref startIndex);
        }
        #endregion

    }
}
namespace DAL.Database.Tables.客户
{

    partial class 订单 : ISerial
    {

        #region Constructor

        public 订单() {
        }
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

        #region Serial
        public byte[] GetBytes()
        {
            return new byte[][]
            {
                this.订单编号.GetBytes(),
                this.客户编号.GetBytes(),
                this.经办雇员编号.GetBytes(),
                this.下单时间.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.订单编号 = buffer.ToInt32(ref startIndex);
            this.客户编号 = buffer.ToInt32(ref startIndex);
            this.经办雇员编号 = buffer.ToInt32(ref startIndex);
            this.下单时间 = buffer.ToDateTime(ref startIndex);
        }
        #endregion

    }
    partial class 订单明细 : ISerial
    {

        #region Constructor

        public 订单明细() {
        }
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

        #region Serial
        public byte[] GetBytes()
        {
            return new byte[][]
            {
                this.订单明细编号.GetBytes(),
                this.订单编号.GetBytes(),
                this.产品编号.GetBytes(),
                this.数量.GetBytes(),
                this.单价.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.订单明细编号 = buffer.ToInt32(ref startIndex);
            this.订单编号 = buffer.ToInt32(ref startIndex);
            this.产品编号 = buffer.ToInt32(ref startIndex);
            this.数量 = buffer.ToDecimal(ref startIndex);
            this.单价 = buffer.ToDecimal(ref startIndex);
        }
        #endregion

    }
    partial class 客户 : ISerial
    {

        #region Constructor

        public 客户() {
        }
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

        #region Serial
        public byte[] GetBytes()
        {
            return new byte[][]
            {
                this.客户编号.GetBytes(),
                this.姓名.GetBytes(),
                this.联系方式.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.客户编号 = buffer.ToInt32(ref startIndex);
            this.姓名 = buffer.ToString(ref startIndex);
            this.联系方式 = buffer.ToString(ref startIndex);
        }
        #endregion

    }
}
namespace DAL.Database.Tables.系统
{

    partial class 管理员 : ISerial
    {

        #region Constructor

        public 管理员() {
        }
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

        #region Serial
        public byte[] GetBytes()
        {
            return new byte[][]
            {
                this.管理员编号.GetBytes(),
                this.登录名.GetBytes(),
                this.密码.GetBytes(),
                this.创建时间.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.管理员编号 = buffer.ToInt32(ref startIndex);
            this.登录名 = buffer.ToString(ref startIndex);
            this.密码 = buffer.ToString(ref startIndex);
            this.创建时间 = buffer.ToDateTime(ref startIndex);
        }
        #endregion

    }
}