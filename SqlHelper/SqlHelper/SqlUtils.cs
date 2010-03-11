﻿namespace SqlLib {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;

    public partial class Pair<T1, T2> {
        public T1 First { get; set; }
        public T2 Second { get; set; }
    }


    public static partial class SqlUtils {
        #region string methods

        /// <summary>
        /// combine a list to string like  xx,xxx,xx,xx,...
        /// </summary>
        public static string Combine<T> ( this IEnumerable<T> list, string separator, string prefix, string suffix ) {
            if ( list == null ) return "";
            if ( prefix == null ) prefix = "";
            if ( suffix == null ) suffix = "";
            var sb = new StringBuilder ();
            foreach ( T item in list ) {
                if ( item.ToString ().Length == 0 ) continue;
                if ( sb.Length > 0 ) sb.Append ( separator );
                if ( typeof ( T ) == typeof ( object ) )
                    if ( item is string || item is Guid || item is Guid? || item is DateTime || item is DateTime? )
                        sb.Append ( "'" + item.ToString ().Replace ( "'", "''" ) + "'" );
                    else sb.Append ( item.ToString ().Replace ( "'", "''" ) );
                else sb.Append ( prefix + item.ToString ().Replace ( "'", "''" ) + suffix );
            }
            return sb.ToString ();
        }

        /// <summary>
        /// combine a list to string like  xx,xxx,xx,xx,...
        /// </summary>
        public static string Combine<T> ( this IEnumerable<T> list ) {
            if ( typeof ( T ) == typeof ( string ) || typeof ( T ) == typeof ( Guid ) || typeof ( T ) == typeof ( Guid? ) || typeof ( T ) == typeof ( DateTime ) || typeof ( T ) == typeof ( DateTime? ) ) return Combine<T> ( list, ",", "'", "'" );
            return Combine<T> ( list, ",", "", "" );
        }


        /// <summary>
        /// escape string for MSSQL LIKE statment
        /// </summary>
        public static string EscapeLike ( this string s ) {
            return string.IsNullOrEmpty ( s ) ? s : s.Replace ( "'", "''" ).Replace ( "[", "[[]" ).Replace ( "_", "[_]" ).Replace ( "%", "[%]" ).Replace ( "-", "[-]" ).Replace ( "^", "[^]" );
        }

        /// <summary>
        /// escape string for MSSQL = operator
        /// </summary>
        public static string EscapeEqual ( this string s ) {
            return string.IsNullOrEmpty ( s ) ? s : s.Replace ( "'", "''" );
        }

        /// <summary>
        /// escape SQL Object's name for TSQL
        /// </summary>
        public static string EscapeSqlObjectName ( string s ) {
            return s.Replace ( "]", @"]]" );
        }

        private static string[] _hexs = new string[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D", "0E", "0F", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "1A", "1B", "1C", "1D", "1E", "1F", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "2A", "2B", "2C", "2D", "2E", "2F", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "3A", "3B", "3C", "3D", "3E", "3F", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "4A", "4B", "4C", "4D", "4E", "4F", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "5A", "5B", "5C", "5D", "5E", "5F", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "6A", "6B", "6C", "6D", "6E", "6F", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "7A", "7B", "7C", "7D", "7E", "7F"
			, "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "8A", "8B", "8C", "8D", "8E", "8F", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "9A", "9B", "9C", "9D", "9E", "9F", "A0", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "AA", "AB", "AC", "AD", "AE", "AF", "B0", "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "BA", "BB", "BC", "BD", "BE", "BF", "C0", "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "CA", "CB", "CC", "CD", "CE", "CF", "D0", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "DA", "DB", "DC", "DD", "DE", "DF", "E0", "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9", "EA", "EB", "EC", "ED", "EE", "EF", "F0", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "FA", "FB", "FC", "FD", "FE", "FF" };
        /// <summary>
        /// convert byte[] to string for MSSQL 'value'
        /// </summary>
        public static string ToHexString ( this byte[] bytes ) {
            if ( bytes == null || bytes.Length == 0 ) return "0x";
            var sb = new StringBuilder ( "0x" );
            for ( int i = 0; i < bytes.Length; i++ ) {
                sb.Append ( _hexs[bytes[i]] );
            }
            return sb.ToString ();
        }
        #endregion

    }
}