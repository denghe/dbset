using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using SqlLib;

namespace DAL.Database.UserDefinedTableTypes.dbo
{

    partial class udt_INT : ISerial
    {
        #region Constructor

        public udt_INT() {
        }
        public udt_INT(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public udt_INT(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.id.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.id = buffer.ToInt32(ref startIndex);
        }
        #endregion

    }
    partial class udt_INT_STRING : ISerial
    {
        #region Constructor

        public udt_INT_STRING() {
        }
        public udt_INT_STRING(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public udt_INT_STRING(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.column1.GetBytes());
            buffers.Add(this.column2.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.column1 = buffer.ToNullableInt32(ref startIndex);
            this.column2 = buffer.ToString(ref startIndex);
        }
        #endregion

    }
    partial class udt_test1 : ISerial
    {
        #region Constructor

        public udt_test1() {
        }
        public udt_test1(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public udt_test1(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion

        #region Serial
        public byte[] GetBytes() {
            var buffers = new List<byte[]>();
            buffers.Add(this.id.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex) {
            this.id = buffer.ToInt32(ref startIndex);
        }
        #endregion

    }
}