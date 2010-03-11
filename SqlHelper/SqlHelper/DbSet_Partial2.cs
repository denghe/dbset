namespace SqlLib {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    partial class DbTable {
        public DbTable ( params Type[] types )
            : this () {
            foreach ( var t in types ) NewColumn ( t );
        }

        public DbTable ( Type[] types, params object[][] valuesCollection )
            : this () {
            foreach ( var t in types ) NewColumn ( t );
            foreach ( var values in valuesCollection ) AddRow ( values );
        }

        public DbTable ( int numCols, params object[][] valuesCollection )
            : this () {
            for ( int i = 0; i < numCols; i++ ) NewColumn ();
            foreach ( var values in valuesCollection ) AddRow ( values );
        }
    }
}
