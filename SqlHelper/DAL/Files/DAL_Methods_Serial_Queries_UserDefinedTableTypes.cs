using System;
using System.Collections.Generic;
using SqlLib.Queries;

namespace DAL.Queries.UserDefinedTableTypes.表类型
{

    partial class G_INT
    {
        #region Serial

        public G_INT() { }
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
    }
    partial class G_INT_INT
    {
        #region Serial

        public G_INT_INT() { }
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
    }
    partial class G_INT_INT_BIT
    {
        #region Serial

        public G_INT_INT_BIT() { }
        public G_INT_INT_BIT(byte[] buffer, ref int startIndex)
            : this() {
            Fill(buffer, ref startIndex);
        }
        public G_INT_INT_BIT(byte[] buffer)
            : this() {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }

        #endregion
    }
    partial class G_INT_STRING
    {
        #region Serial

        public G_INT_STRING() { }
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
    }
    partial class G_INT_STRING_STRING
    {
        #region Serial

        public G_INT_STRING_STRING() { }
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
    }
    partial class G_STRING
    {
        #region Serial

        public G_STRING() { }
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
    }
    partial class G_STRING_DATETIME
    {
        #region Serial

        public G_STRING_DATETIME() { }
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
    }
}