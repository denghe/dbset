using System;
using System.Collections.Generic;
using SqlLib.Queries;

namespace DAL.Queries.UserDefinedTableTypes.dbo
{

    partial class FS
    {
        #region Serial

        public FS() { }
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
    }
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
    partial class G_INT_STR
    {
        #region Serial

        public G_INT_STR() { }
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
    }
    partial class MyType1
    {
        #region Serial

        public MyType1() { }
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
    }
    partial class ParentChildOrg
    {
        #region Serial

        public ParentChildOrg() { }
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
    }
}