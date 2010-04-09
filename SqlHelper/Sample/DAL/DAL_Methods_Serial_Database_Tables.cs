using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SqlLib;

namespace DAL.Database.Tables.dbo
{

    partial class A : ISerial
    {

        #region Constructor

        public A() {
        }
        public A(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public A(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.AID.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.AID = buffer.ToInt32(ref startIndex);
        }
        #endregion

    }
    partial class B : ISerial
    {

        #region Constructor

        public B() {
        }
        public B(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public B(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.BID.GetBytes());
            buffers.Add(this.AID.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.BID = buffer.ToInt32(ref startIndex);
            this.AID = buffer.ToInt32(ref startIndex);
        }
        #endregion

    }
    partial class Formula_890 : ISerial
    {

        #region Constructor

        public Formula_890() {
        }
        public Formula_890(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public Formula_890(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.Name.GetBytes());
            buffers.Add(this.Expression.GetBytes());
            buffers.Add(this.Value.GetBytes());
            buffers.Add(this.IsGenerator.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.Name = buffer.ToString(ref startIndex);
            this.Expression = buffer.ToString(ref startIndex);
            this.Value = buffer.ToString(ref startIndex);
            this.IsGenerator = buffer.ToNullableBoolean(ref startIndex);
        }
        #endregion

    }
    partial class FS : ISerial
    {

        #region Constructor

        public FS() {
        }
        public FS(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public FS(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.ID.GetBytes());
            buffers.Add(this.Category.GetBytes());
            buffers.Add(this.Stream.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.ID = buffer.ToGuid(ref startIndex);
            this.Category = buffer.ToBytes(ref startIndex);
            this.Stream = buffer.ToBytes(ref startIndex);
        }
        #endregion

    }
    partial class ParentChildOrg : ISerial
    {

        #region Constructor

        public ParentChildOrg() {
        }
        public ParentChildOrg(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public ParentChildOrg(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.EmployeeID.GetBytes());
            buffers.Add(this.ManagerId.GetBytes());
            buffers.Add(this.EmployeeName.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.EmployeeID = buffer.ToInt32(ref startIndex);
            this.ManagerId = buffer.ToNullableInt32(ref startIndex);
            this.EmployeeName = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class t : ISerial
    {

        #region Constructor

        public t() {
        }
        public t(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public t(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.a.GetBytes());
            buffers.Add(this.b.GetBytes());
            buffers.Add(this.c.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.a = buffer.ToInt32(ref startIndex);
            this.b = buffer.ToInt32(ref startIndex);
            this.c = buffer.ToBytes(ref startIndex);
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
            buffers.Add(this.PID.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.ID = buffer.ToInt32(ref startIndex);
            this.PID = buffer.ToNullableInt32(ref startIndex);
        }
        #endregion

    }
    partial class t2 : ISerial
    {

        #region Constructor

        public t2() {
        }
        public t2(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public t2(byte[] buffer)
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
            buffers.Add(this.CreateTime.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.ID = buffer.ToInt32(ref startIndex);
            this.Name = buffer.ToString(ref startIndex);
            this.CreateTime = buffer.ToDateTime(ref startIndex);
        }
        #endregion

    }
    partial class t3 : ISerial
    {

        #region Constructor

        public t3() {
        }
        public t3(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public t3(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.c1.GetBytes());
            buffers.Add(this.c2.GetBytes());
            buffers.Add(this.c3.GetBytes());
            buffers.Add(this.c4.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.c1 = buffer.ToInt32(ref startIndex);
            this.c2 = buffer.ToGuid(ref startIndex);
            this.c3 = buffer.ToDateTime(ref startIndex);
            this.c4 = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class tree : ISerial
    {

        #region Constructor

        public tree() {
        }
        public tree(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public tree(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.Parent.GetBytes());
            buffers.Add(this.Children.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.Parent = buffer.ToString(ref startIndex);
            this.Children = buffer.ToString(ref startIndex);
        }
        #endregion

    }
}
namespace DAL.Database.Tables.MySchema
{

    partial class FS : ISerial
    {

        #region Constructor

        public FS() {
        }
        public FS(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public FS(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.dbo_FSID.GetBytes());
            buffers.Add(this.asdf.GetBytes());
            buffers.Add(this.ID.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.dbo_FSID = buffer.ToGuid(ref startIndex);
            this.asdf = buffer.ToString(ref startIndex);
            this.ID = buffer.ToInt32(ref startIndex);
        }
        #endregion

    }
}
namespace DAL.Database.Tables.Schema1
{

    partial class T1 : ISerial
    {

        #region Constructor

        public T1() {
        }
        public T1(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public T1(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.ID.GetBytes());
            buffers.Add(this.PID.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.ID = buffer.ToInt32(ref startIndex);
            this.PID = buffer.ToNullableInt32(ref startIndex);
        }
        #endregion

    }
}