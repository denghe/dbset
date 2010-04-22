using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SqlLib;

namespace DAL.Database.UserDefinedTableTypes.表类型
{

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
    partial class G_INT_INT : ISerial
    {
        #region Constructor

        public G_INT_INT() {
        }
        public G_INT_INT(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public G_INT_INT(byte[] buffer)
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
            this.c1 = buffer.ToInt32(ref startIndex);
            this.c2 = buffer.ToInt32(ref startIndex);
        }
        #endregion

    }
    partial class G_INT_STRING : ISerial
    {
        #region Constructor

        public G_INT_STRING() {
        }
        public G_INT_STRING(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public G_INT_STRING(byte[] buffer)
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
            this.c1 = buffer.ToInt32(ref startIndex);
            this.c2 = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class G_INT_STRING_STRING : ISerial
    {
        #region Constructor

        public G_INT_STRING_STRING() {
        }
        public G_INT_STRING_STRING(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public G_INT_STRING_STRING(byte[] buffer)
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
                this.c3.GetBytes(),
            }.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.c1 = buffer.ToInt32(ref startIndex);
            this.c2 = buffer.ToString(ref startIndex);
            this.c3 = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class G_STRING : ISerial
    {
        #region Constructor

        public G_STRING() {
        }
        public G_STRING(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public G_STRING(byte[] buffer)
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
            this.c1 = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class G_STRING_DATETIME : ISerial
    {
        #region Constructor

        public G_STRING_DATETIME() {
        }
        public G_STRING_DATETIME(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public G_STRING_DATETIME(byte[] buffer)
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
            this.c1 = buffer.ToString(ref startIndex);
            this.c2 = buffer.ToDateTime(ref startIndex);
        }
        #endregion

    }
}