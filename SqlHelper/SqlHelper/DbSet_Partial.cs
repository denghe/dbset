namespace SqlLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    partial class DbSet
    {
        public DbSet(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbSet(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }
        public byte[] GetBytes()
        {
            var buffers = new List<byte[]>();
            buffers.Add(this.RecordsAffected.GetBytes());
            buffers.Add(this.ReturnValue.GetBytes());
            buffers.Add(this.Errors.GetBytes());
            buffers.Add(this.Messages.GetBytes());
            buffers.Add(this.Tables.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.RecordsAffected = buffer.ToInt32(ref startIndex);
            this.ReturnValue = buffer.ToInt32(ref startIndex);
            this.Errors.Fill(buffer, ref startIndex);
            this.Messages.Fill(buffer, ref startIndex);
            this.Tables.Fill(buffer, ref startIndex, this);
        }
    }

    partial class Errors
    {
        public byte[] GetBytes()
        {
            var buffers = new List<byte[]>();
            buffers.Add(this.Count.GetBytes());
            foreach (var s in this) buffers.Add(s.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex)
        {
            var count = buffer.ToInt32(ref startIndex);
            for (int i = 0; i < count; i++)
            {
                var se = new SqlError();
                se.Fill(buffer, ref startIndex);
                this.Add(se);
            }
        }
    }

    partial class Messages
    {
        public byte[] GetBytes()
        {
            var buffers = new List<byte[]>();
            buffers.Add(this.Count.GetBytes());
            foreach (var s in this) buffers.Add(s.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex)
        {
            var count = buffer.ToInt32(ref startIndex);
            for (int i = 0; i < count; i++)
            {
                this.Add(buffer.ToString(ref startIndex));
            }
        }
    }

    partial class Tables
    {
        public byte[] GetBytes()
        {
            var buffers = new List<byte[]>();
            buffers.Add(this.Count.GetBytes());
            foreach (var table in this) buffers.Add(table.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex, DbSet ds)
        {
            var count = buffer.ToInt32(ref startIndex);
            for (int i = 0; i < count; i++)
            {
                var t = new DbTable { Set = ds };
                t.Fill(buffer, ref startIndex);
                ds.Tables.Add(t);
            }
        }
    }

    partial class DbTable
    {
        public DbTable(byte[] buffer, ref int startIndex)
            : this()
        {
            Fill(buffer, ref startIndex);
        }
        public DbTable(byte[] buffer)
            : this()
        {
            var startIndex = 0;
            Fill(buffer, ref startIndex);
        }
        public byte[] GetBytes()
        {
            var buffers = new List<byte[]>();
            buffers.Add(this.Name.GetBytes());
            buffers.Add(this.Schema.GetBytes());
            buffers.Add(this.Columns.GetBytes());
            buffers.Add(this.Rows.GetBytes());
            //buffers.Add(this.Set.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Name = buffer.ToString(ref startIndex);
            this.Schema = buffer.ToString(ref startIndex);
            this.Columns.Fill(buffer, ref startIndex, this);
            this.Rows.Fill(buffer, ref startIndex, this);
        }
    }

    partial class Columns
    {
        public byte[] GetBytes()
        {
            var buffers = new List<byte[]>();
            buffers.Add(this.Count.GetBytes());
            foreach (var col in this) buffers.Add(col.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex, DbTable t)
        {
            var count = buffer.ToInt32(ref startIndex);
            for (int i = 0; i < count; i++)
            {
                var col = new DbColumn(t);
                col.Fill(buffer, ref startIndex);
            }
        }
    }

    partial class Rows
    {
        public byte[] GetBytes()
        {
            var buffers = new List<byte[]>();
            buffers.Add(this.Count.GetBytes());
            foreach (var row in this) buffers.Add(row.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex, DbTable t)
        {
            var count = buffer.ToInt32(ref startIndex);
            for (int i = 0; i < count; i++)
            {
                var row = new DbRow(t);
                row.Fill(buffer, ref startIndex);
            }
        }
    }

    partial class DbColumn
    {
        public byte[] GetBytes()
        {
            var buffers = new List<byte[]>();
            buffers.Add(this.AllowDBNull.GetBytes());
            buffers.Add(this.Name.GetBytes());
            buffers.Add(this.Type.GetBytes());
            //buffers.Add(this.Table.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.AllowDBNull = buffer.ToBoolean(ref startIndex);
            this.Name = buffer.ToString(ref startIndex);
            this.Type = buffer.ToType(ref startIndex);
        }
    }

    partial class DbRow
    {
        public byte[] GetBytes()
        {
            // DbRow 对象的数据操作，依赖于 Table.Columns 的数据类型数据
            // 如果字段可空 则前置 1 byte 标记位( 1 不空， 0 空 )

            var buffers = new List<byte[]>();
            for (int i = 0; i < _itemArray.Length; i++)
            {
                var column = Table.Columns[i];
                if (column.AllowDBNull)
                {
                    if (_itemArray[i] == DBNull.Value)
                    {
                        buffers.Add(new byte[] { (byte)0 });
                        continue;
                    }
                    else buffers.Add(new byte[] { (byte)1 });
                }
                buffers.Add(DbSet_Utils.GetBytes(_itemArray[i]));
            }
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex)
        {
            for (int i = 0; i < _itemArray.Length; i++)
            {
                var column = Table.Columns[i];
                if (column.AllowDBNull)
                {
                    if (buffer[startIndex++] == (byte)0)
                        _itemArray[i] = DBNull.Value;
                    else
                        _itemArray[i] = DbSet_Utils.ToObject(buffer, column.Type, ref startIndex);
                }
                else _itemArray[i] = DbSet_Utils.ToObject(buffer, column.Type, ref startIndex);
            }
        }
    }

    partial class SqlError
    {
        public byte[] GetBytes()
        {
            var buffers = new List<byte[]>();
            buffers.Add(this.Class.GetBytes());
            buffers.Add(this.State.GetBytes());
            buffers.Add(this.LineNumber.GetBytes());
            buffers.Add(this.Number.GetBytes());
            buffers.Add(this.Message.GetBytes());
            buffers.Add(this.Procedure.GetBytes());
            buffers.Add(this.Server.GetBytes());
            buffers.Add(this.Source.GetBytes());
            return buffers.Combine();
        }
        public void Fill(byte[] buffer, ref int startIndex)
        {
            this.Class = buffer.ToByte(ref startIndex);
            this.State = buffer.ToByte(ref startIndex);
            this.LineNumber = buffer.ToInt32(ref startIndex);
            this.Number = buffer.ToInt32(ref startIndex);
            this.Message = buffer.ToString(ref startIndex);
            this.Procedure = buffer.ToString(ref startIndex);
            this.Server = buffer.ToString(ref startIndex);
            this.Source = buffer.ToString(ref startIndex);
        }
    }
}