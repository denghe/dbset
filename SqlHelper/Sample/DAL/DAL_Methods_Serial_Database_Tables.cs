using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SqlLib;

namespace DAL.Database.Tables.dbo
{

    partial class Child : ISerial
    {

        #region Constructor

        public Child() {
        }
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

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.TreeID.GetBytes());
            buffers.Add(this.ChildID.GetBytes());
            buffers.Add(this.Name.GetBytes());
            buffers.Add(this.CreateTime.GetBytes());
            buffers.Add(this.Memo.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.TreeID = buffer.ToInt32(ref startIndex);
            this.ChildID = buffer.ToGuid(ref startIndex);
            this.Name = buffer.ToString(ref startIndex);
            this.CreateTime = buffer.ToDateTime(ref startIndex);
            this.Memo = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class ChildLog : ISerial
    {

        #region Constructor

        public ChildLog() {
        }
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

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.ChildID.GetBytes());
            buffers.Add(this.ChildLogID.GetBytes());
            buffers.Add(this.CreateTime.GetBytes());
            buffers.Add(this.LogContent.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.ChildID = buffer.ToGuid(ref startIndex);
            this.ChildLogID = buffer.ToInt32(ref startIndex);
            this.CreateTime = buffer.ToDateTime(ref startIndex);
            this.LogContent = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class DoublePK : ISerial
    {

        #region Constructor

        public DoublePK() {
        }
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

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.ID1.GetBytes());
            buffers.Add(this.ID2.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.ID1 = buffer.ToInt32(ref startIndex);
            this.ID2 = buffer.ToInt32(ref startIndex);
        }
        #endregion

    }
    partial class Orders : ISerial
    {

        #region Constructor

        public Orders() {
        }
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

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.OrderID.GetBytes());
            buffers.Add(this.memberID.GetBytes());
            buffers.Add(this.orderDate.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.OrderID = buffer.ToInt32(ref startIndex);
            this.memberID = buffer.ToInt32(ref startIndex);
            this.orderDate = buffer.ToDateTime(ref startIndex);
        }
        #endregion

    }
    partial class t1 : ISerial
    {

        #region Constructor

        public t1() {
        }
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

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.ID.GetBytes());
            buffers.Add(this.Name.GetBytes());
            buffers.Add(this.XML.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.ID = buffer.ToInt32(ref startIndex);
            this.Name = buffer.ToString(ref startIndex);
            this.XML = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class TA : ISerial
    {

        #region Constructor

        public TA() {
        }
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

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.AID.GetBytes());
            buffers.Add(this.AData.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.AID = buffer.ToNullableInt32(ref startIndex);
            this.AData = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class TB : ISerial
    {

        #region Constructor

        public TB() {
        }
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

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.BID.GetBytes());
            buffers.Add(this.BData.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.BID = buffer.ToNullableInt32(ref startIndex);
            this.BData = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class Tree : ISerial
    {

        #region Constructor

        public Tree() {
        }
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

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.TreeID.GetBytes());
            buffers.Add(this.TreePID.GetBytes());
            buffers.Add(this.Name.GetBytes());
            buffers.Add(this.Memo.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.TreeID = buffer.ToInt32(ref startIndex);
            this.TreePID = buffer.ToNullableInt32(ref startIndex);
            this.Name = buffer.ToString(ref startIndex);
            this.Memo = buffer.ToString(ref startIndex);
        }
        #endregion

    }
}