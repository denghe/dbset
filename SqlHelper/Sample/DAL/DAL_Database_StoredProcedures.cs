using System;
using System.Collections.Generic;
using UDTT = DAL.Database.UserDefinedTableTypes;
using SqlLib;

namespace DAL.Database.StoredProcedures.dbo
{

	/// <summary>
	/// 返回一个字段（INT) 的表
	/// </summary>
    public static partial class GetIntList
    {

    }
	/// <summary>
	/// asdf
	/// </summary>
    public static partial class GetIntStringList
    {

        public partial class Parameters
        {
            #region IntList

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_IntList;

            private UDTT.dbo.udt_INT_Collection _v_IntList;

			/// <summary>
			/// 
			/// </summary>
            public UDTT.dbo.udt_INT_Collection IntList
            {
                get
                {
                    return _v_IntList;
                }
                set
                {
                    _f_IntList = true;
                    _v_IntList = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// as
	/// </summary>
    public static partial class MergeTest
    {

    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class test
    {

        public partial class Parameters
        {
            #region p1

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_p1;

            private object     _v_p1;

			/// <summary>
			/// 
			/// </summary>
            public object     p1
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

            private object     _v_p2;

			/// <summary>
			/// 
			/// </summary>
            public object     p2
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
	/// asdf
	/// </summary>
    public static partial class usp_Tree_Delete
    {

        public partial class Parameters
        {
            #region Original_TreeID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_Original_TreeID;

            private int?       _v_Original_TreeID;

			/// <summary>
			/// 
			/// </summary>
            public int?       Original_TreeID
            {
                get
                {
                    return _v_Original_TreeID;
                }
                set
                {
                    _f_Original_TreeID = true;
                    _v_Original_TreeID = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// xxx
	/// </summary>
    public static partial class usp_Tree_Delete_ForSqlDataSource
    {

        public partial class Parameters
        {
            #region TreeID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_TreeID;

            private int?       _v_TreeID;

			/// <summary>
			/// 
			/// </summary>
            public int?       TreeID
            {
                get
                {
                    return _v_TreeID;
                }
                set
                {
                    _f_TreeID = true;
                    _v_TreeID = value;
                }
            }

            #endregion
            #region Original_TreeID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_Original_TreeID;

            private int?       _v_Original_TreeID;

			/// <summary>
			/// 
			/// </summary>
            public int?       Original_TreeID
            {
                get
                {
                    return _v_Original_TreeID;
                }
                set
                {
                    _f_Original_TreeID = true;
                    _v_Original_TreeID = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class usp_Tree_Insert
    {

        public partial class Parameters
        {
            #region TreeID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_TreeID;

            private int?       _v_TreeID;

			/// <summary>
			/// 
			/// </summary>
            public int?       TreeID
            {
                get
                {
                    return _v_TreeID;
                }
                set
                {
                    _f_TreeID = true;
                    _v_TreeID = value;
                }
            }

            #endregion
            #region TreePID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_TreePID;

            private int?       _v_TreePID;

			/// <summary>
			/// 
			/// </summary>
            public int?       TreePID
            {
                get
                {
                    return _v_TreePID;
                }
                set
                {
                    _f_TreePID = true;
                    _v_TreePID = value;
                }
            }

            #endregion
            #region Name

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_Name;

            private string     _v_Name;

			/// <summary>
			/// 
			/// </summary>
            public string     Name
            {
                get
                {
                    return _v_Name;
                }
                set
                {
                    _f_Name = true;
                    _v_Name = value;
                }
            }

            #endregion
            #region Memo

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_Memo;

            private string     _v_Memo;

			/// <summary>
			/// 
			/// </summary>
            public string     Memo
            {
                get
                {
                    return _v_Memo;
                }
                set
                {
                    _f_Memo = true;
                    _v_Memo = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class usp_Tree_Select
    {

        public partial class Parameters
        {
            #region TreeID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_TreeID;

            private int?       _v_TreeID;

			/// <summary>
			/// 
			/// </summary>
            public int?       TreeID
            {
                get
                {
                    return _v_TreeID;
                }
                set
                {
                    _f_TreeID = true;
                    _v_TreeID = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class usp_Tree_SelectAll
    {

    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class usp_Tree_Update
    {

        public partial class Parameters
        {
            #region Original_TreeID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_Original_TreeID;

            private int?       _v_Original_TreeID;

			/// <summary>
			/// 
			/// </summary>
            public int?       Original_TreeID
            {
                get
                {
                    return _v_Original_TreeID;
                }
                set
                {
                    _f_Original_TreeID = true;
                    _v_Original_TreeID = value;
                }
            }

            #endregion
            #region TreeID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_TreeID;

            private int?       _v_TreeID;

			/// <summary>
			/// 
			/// </summary>
            public int?       TreeID
            {
                get
                {
                    return _v_TreeID;
                }
                set
                {
                    _f_TreeID = true;
                    _v_TreeID = value;
                }
            }

            #endregion
            #region TreePID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_TreePID;

            private int?       _v_TreePID;

			/// <summary>
			/// 
			/// </summary>
            public int?       TreePID
            {
                get
                {
                    return _v_TreePID;
                }
                set
                {
                    _f_TreePID = true;
                    _v_TreePID = value;
                }
            }

            #endregion
            #region Name

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_Name;

            private string     _v_Name;

			/// <summary>
			/// 
			/// </summary>
            public string     Name
            {
                get
                {
                    return _v_Name;
                }
                set
                {
                    _f_Name = true;
                    _v_Name = value;
                }
            }

            #endregion
            #region Memo

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_Memo;

            private string     _v_Memo;

			/// <summary>
			/// 
			/// </summary>
            public string     Memo
            {
                get
                {
                    return _v_Memo;
                }
                set
                {
                    _f_Memo = true;
                    _v_Memo = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class usp_Tree_Update_For_SqlDataSource
    {

        public partial class Parameters
        {
            #region TreeID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_TreeID;

            private int?       _v_TreeID;

			/// <summary>
			/// 
			/// </summary>
            public int?       TreeID
            {
                get
                {
                    return _v_TreeID;
                }
                set
                {
                    _f_TreeID = true;
                    _v_TreeID = value;
                }
            }

            #endregion
            #region TreePID

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_TreePID;

            private int?       _v_TreePID;

			/// <summary>
			/// 
			/// </summary>
            public int?       TreePID
            {
                get
                {
                    return _v_TreePID;
                }
                set
                {
                    _f_TreePID = true;
                    _v_TreePID = value;
                }
            }

            #endregion
            #region Name

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_Name;

            private string     _v_Name;

			/// <summary>
			/// 
			/// </summary>
            public string     Name
            {
                get
                {
                    return _v_Name;
                }
                set
                {
                    _f_Name = true;
                    _v_Name = value;
                }
            }

            #endregion
            #region Memo

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_Memo;

            private string     _v_Memo;

			/// <summary>
			/// 
			/// </summary>
            public string     Memo
            {
                get
                {
                    return _v_Memo;
                }
                set
                {
                    _f_Memo = true;
                    _v_Memo = value;
                }
            }

            #endregion
        }
    }
}