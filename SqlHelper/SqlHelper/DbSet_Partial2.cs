namespace SqlLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    partial class DbTable
    {
        public DbTable(params Type[] types)
            : this()
        {
            foreach (var t in types) NewColumn(t);
        }

        public DbTable(Type[] types, params object[][] valuesCollection)
            : this()
        {
            foreach (var t in types) NewColumn(t);
            foreach (var values in valuesCollection) AddRow(values);
        }

        public DbTable(int numCols, params object[][] valuesCollection)
            : this()
        {
            NewColumn(numCols);
            foreach (var values in valuesCollection) AddRow(values);
        }

        public DbTable(params object[][] valuesCollection)
            : this()
        {
            var maxCols = valuesCollection.Max(a => a.Length);
            NewColumn(maxCols);
            foreach (var values in valuesCollection) AddRow(values);
        }




        public DbTable(DbSet ds, params Type[] types)
            : this(types)
        {
            this.Set = ds;
            ds.Tables.Add(this);
        }

        public DbTable(DbSet ds, Type[] types, params object[][] valuesCollection)
            : this(types, valuesCollection)
        {
            this.Set = ds;
            ds.Tables.Add(this);
        }

        public DbTable(DbSet ds, int numCols, params object[][] valuesCollection)
            : this(numCols, valuesCollection)
        {
            this.Set = ds;
            ds.Tables.Add(this);
        }

        public DbTable(DbSet ds, params object[][] valuesCollection)
            : this(valuesCollection)
        {
            this.Set = ds;
            ds.Tables.Add(this);
        }

    }

    partial class DbSet
    {
        public DbTable NewTable(params Type[] types)
        {
            return new DbTable(this, types);
        }

        public DbTable NewTable(Type[] types, params object[][] valuesCollection)
        {
            return new DbTable(this, types, valuesCollection);
        }

        public DbTable NewTable(int numCols, params object[][] valuesCollection)
        {
            return new DbTable(this, numCols, valuesCollection);
        }

        public DbTable NewTable(params object[][] valuesCollection)
        {
            return new DbTable(this, valuesCollection);
        }



        public DbSet AddTable(params Type[] types)
        {
            new DbTable(this, types);
            return this;
        }

        public DbSet AddTable(Type[] types, params object[][] valuesCollection)
        {
            new DbTable(this, types, valuesCollection);
            return this;
        }

        public DbSet AddTable(int numCols, params object[][] valuesCollection)
        {
            new DbTable(this, numCols, valuesCollection);
            return this;
        }

        public DbSet AddTable(params object[][] valuesCollection)
        {
            new DbTable(this, valuesCollection);
            return this;
        }
    }
}
