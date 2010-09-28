using System;
using System.Collections.Generic;
using UDTT = DAL.Database.UserDefinedTableTypes;
using SqlLib;

namespace DAL.Database.StoredProcedures.dbo
{

	/// <summary>
	/// 
	/// </summary>
    public static partial class StoredProcedure1
    {

        public partial class Parameters
        {
            #region parameter1

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_parameter1;

            private int?       _v_parameter1;

			/// <summary>
			/// 
			/// </summary>
            public int?       parameter1
            {
                get
                {
                    return _v_parameter1;
                }
                set
                {
                    _f_parameter1 = true;
                    _v_parameter1 = value;
                }
            }

            #endregion
            #region parameter2

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_parameter2;

            private int?       _v_parameter2;

			/// <summary>
			/// 
			/// </summary>
            public int?       parameter2
            {
                get
                {
                    return _v_parameter2;
                }
                set
                {
                    _f_parameter2 = true;
                    _v_parameter2 = value;
                }
            }

            #endregion
        }
    }
	/// <summary>
	/// 
	/// </summary>
    public static partial class xxx
    {

        public partial class Parameters
        {
            #region iib

			/// <summary>
			/// 
			/// </summary>
            private bool       _f_iib;

            private IEnumerable<UDTT.表类型.G_INT_INT_BIT> _v_iib;

			/// <summary>
			/// 
			/// </summary>
            public IEnumerable<UDTT.表类型.G_INT_INT_BIT> iib
            {
                get
                {
                    return _v_iib;
                }
                set
                {
                    _f_iib = true;
                    _v_iib = value;
                }
            }

            #endregion
        }
    }
}