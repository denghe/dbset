using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SqlLib;

namespace DAL.Database.UserDefinedTableTypes.dbo
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
            return new byte[][]
            {
                this.Col1.GetBytes(),
                this.Col2.GetBytes(),
                this.Col3.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.Col1 = buffer.ToInt32(ref startIndex);
            this.Col2 = buffer.ToInt32(ref startIndex);
            this.Col3 = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class G_INT : ISerial
    {
        #region Constructor

        public G_INT() {
        }
        public G_INT(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public G_INT(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            return new byte[][]
            {
                this.c1.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.c1 = buffer.ToInt32(ref startIndex);
        }
        #endregion

    }
    partial class G_INT_STR : ISerial
    {
        #region Constructor

        public G_INT_STR() {
        }
        public G_INT_STR(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public G_INT_STR(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            return new byte[][]
            {
                this.c1.GetBytes(),
                this.c2.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.c1 = buffer.ToNullableInt32(ref startIndex);
            this.c2 = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class MyType1 : ISerial
    {
        #region Constructor

        public MyType1() {
        }
        public MyType1(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public MyType1(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            return new byte[][]
            {
                this.Str.GetBytes(),
                this.Num.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.Str = buffer.ToString(ref startIndex);
            this.Num = buffer.ToNullableInt32(ref startIndex);
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
            return new byte[][]
            {
                this.EmployeeID.GetBytes(),
                this.ManagerId.GetBytes(),
                this.EmployeeName.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.EmployeeID = buffer.ToInt32(ref startIndex);
            this.ManagerId = buffer.ToNullableInt32(ref startIndex);
            this.EmployeeName = buffer.ToString(ref startIndex);
        }
        #endregion

    }
}