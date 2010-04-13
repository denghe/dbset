using System;
using System.Collections.Generic;
using UDTT = DAL.Database.UserDefinedTableTypes;
using SqlLib;

namespace DAL.Database.StoredProcedures.dbo
{

	/// <summary>
	/// asdfsadf
	/// </summary>
    public static partial class GenT2
    {

        public partial class Parameters
        {
            #region count

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_count;

            private int?       _v_count;

			/// <summary>
			/// 
			/// </summary>
            public int?       count
            {
                get
                {
                    return _v_count;
                }
                set
                {
                    _f_count = true;
                    _v_count = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class ReturnParm
    {

        public partial class Parameters
        {
            #region r

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_r;

            private int?       _v_r;

			/// <summary>
			/// 
			/// </summary>
            public int?       r
            {
                get
                {
                    return _v_r;
                }
                set
                {
                    _f_r = true;
                    _v_r = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class SelectNode
    {

        public partial class Parameters
        {
            #region ID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_ID;

            private int?       _v_ID;

			/// <summary>
			/// 
			/// </summary>
            public int?       ID
            {
                get
                {
                    return _v_ID;
                }
                set
                {
                    _f_ID = true;
                    _v_ID = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class SelectNode_CTE
    {

        public partial class Parameters
        {
            #region ID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_ID;

            private int?       _v_ID;

			/// <summary>
			/// 
			/// </summary>
            public int?       ID
            {
                get
                {
                    return _v_ID;
                }
                set
                {
                    _f_ID = true;
                    _v_ID = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class StoredProcedure1
    {

        public partial class Parameters
        {
            #region s

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_s;

            private string     _v_s;

			/// <summary>
			/// 
			/// </summary>
            public string     s
            {
                get
                {
                    return _v_s;
                }
                set
                {
                    _f_s = true;
                    _v_s = value;
                }
            }

            #endregion
            #region dt

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_dt;

            private System.DateTime?  _v_dt;

			/// <summary>
			/// 
			/// </summary>
            public System.DateTime?  dt
            {
                get
                {
                    return _v_dt;
                }
                set
                {
                    _f_dt = true;
                    _v_dt = value;
                }
            }

            #endregion
            #region i

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_i;

            private int?       _v_i;

			/// <summary>
			/// 
			/// </summary>
            public int?       i
            {
                get
                {
                    return _v_i;
                }
                set
                {
                    _f_i = true;
                    _v_i = value;
                }
            }

            #endregion
            #region bytes

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_bytes;

            private byte[]     _v_bytes;

			/// <summary>
			/// 
			/// </summary>
            public byte[]     bytes
            {
                get
                {
                    return _v_bytes;
                }
                set
                {
                    _f_bytes = true;
                    _v_bytes = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class StoredProcedure2
    {

        public partial class Parameters
        {
            #region m

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_m;

            private string     _v_m;

			/// <summary>
			/// 
			/// </summary>
            public string     m
            {
                get
                {
                    return _v_m;
                }
                set
                {
                    _f_m = true;
                    _v_m = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class StoredProcedure3
    {

        public partial class Parameters
        {
            #region i

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_i;

            private int?       _v_i;

			/// <summary>
			/// 
			/// </summary>
            public int?       i
            {
                get
                {
                    return _v_i;
                }
                set
                {
                    _f_i = true;
                    _v_i = value;
                }
            }

            #endregion
            #region m

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_m;

            private decimal?   _v_m;

			/// <summary>
			/// 
			/// </summary>
            public decimal?   m
            {
                get
                {
                    return _v_m;
                }
                set
                {
                    _f_m = true;
                    _v_m = value;
                }
            }

            #endregion
            #region dt

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_dt;

            private System.DateTime?  _v_dt;

			/// <summary>
			/// 
			/// </summary>
            public System.DateTime?  dt
            {
                get
                {
                    return _v_dt;
                }
                set
                {
                    _f_dt = true;
                    _v_dt = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class TestReturn
    {

        public partial class Parameters
        {
            #region r

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_r;

            private int?       _v_r;

			/// <summary>
			/// 
			/// </summary>
            public int?       r
            {
                get
                {
                    return _v_r;
                }
                set
                {
                    _f_r = true;
                    _v_r = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class TestTableType
    {

        public partial class Parameters
        {
            #region T

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_T;

            private List<UDTT.dbo.G_INT_STR> _v_T;

			/// <summary>
			/// 
			/// </summary>
            public List<UDTT.dbo.G_INT_STR> T
            {
                get
                {
                    return _v_T;
                }
                set
                {
                    _f_T = true;
                    _v_T = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 测试自定义表类型
	/// </summary>
    public static partial class usp_NeedMyType1
    {

        public partial class Parameters
        {
            #region MyType1

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_MyType1;

            private List<UDTT.dbo.MyType1> _v_MyType1;

			/// <summary>
			/// 
			/// </summary>
            public List<UDTT.dbo.MyType1> MyType1
            {
                get
                {
                    return _v_MyType1;
                }
                set
                {
                    _f_MyType1 = true;
                    _v_MyType1 = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class usp_SelectP1
    {

        public partial class Parameters
        {
            #region P1

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_P1;

            private List<UDTT.dbo.FS> _v_P1;

			/// <summary>
			/// 
			/// </summary>
            public List<UDTT.dbo.FS> P1
            {
                get
                {
                    return _v_P1;
                }
                set
                {
                    _f_P1 = true;
                    _v_P1 = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class usp_testp1p2
    {

        public partial class Parameters
        {
            #region p1

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_p1;

            private int?       _v_p1;

			/// <summary>
			/// 
			/// </summary>
            public int?       p1
            {
                get
                {
                    return _v_p1;
                }
                set
                {
                    _f_p1 = true;
                    _v_p1 = value;
                }
            }

            #endregion
            #region p2

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_p2;

            private int?       _v_p2;

			/// <summary>
			/// 
			/// </summary>
            public int?       p2
            {
                get
                {
                    return _v_p2;
                }
                set
                {
                    _f_p2 = true;
                    _v_p2 = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class 需要传个表参
    {

        public partial class Parameters
        {
            #region T

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_T;

            private List<UDTT.dbo.G_INT_STR> _v_T;

			/// <summary>
			/// 
			/// </summary>
            public List<UDTT.dbo.G_INT_STR> T
            {
                get
                {
                    return _v_T;
                }
                set
                {
                    _f_T = true;
                    _v_T = value;
                }
            }

            #endregion
        }
    }
}
namespace DAL.Database.StoredProcedures.Schema1
{

	/// <summary>
	/// 
	/// </summary>
    public static partial class GenT1
    {

        public partial class Parameters
        {
            #region count

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_count;

            private int?       _v_count;

			/// <summary>
			/// 
			/// </summary>
            public int?       count
            {
                get
                {
                    return _v_count;
                }
                set
                {
                    _f_count = true;
                    _v_count = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 针对 表 [Schema1].[T1]
	/// 根据主键值返回一个节点的多行数据
	/// </summary>
    public static partial class usp_T1_SelectNode
    {

        public partial class Parameters
        {
            #region ID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_ID;

            private int?       _v_ID;

			/// <summary>
			/// 
			/// </summary>
            public int?       ID
            {
                get
                {
                    return _v_ID;
                }
                set
                {
                    _f_ID = true;
                    _v_ID = value;
                }
            }

            #endregion
        }
    }
}