using System;
using System.Collections.Generic;
using SqlLib.Orientations;

namespace DAL.Orientations.UserDefinedTableTypes.dbo
{

    partial class udt_INT
    {
        #region Serial

        public udt_INT() { }
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
    }
    partial class udt_INT_STRING
    {
        #region Serial

        public udt_INT_STRING() { }
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
    }
    partial class udt_test1
    {
        #region Serial

        public udt_test1() { }
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
    }
}