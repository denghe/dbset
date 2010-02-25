using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

partial class DbSet
{
    public byte[] GetBytes()
    {
        throw new Exception("todo");
    }
    public void Fill(byte[] buffer, ref int startIndex)
    {
        throw new Exception("todo");
    }
}

partial class Errors
{
    public byte[] GetBytes()
    {
        return null;
    }
    public void Fill(byte[] buffer, ref int startIndex)
    {
    }
}

partial class Messages
{
    public byte[] GetBytes()
    {
        return null;
    }
    public void Fill(byte[] buffer, ref int startIndex)
    {
    }
}

partial class Tables
{
    public byte[] GetBytes()
    {
        return null;
    }
    public void Fill(byte[] buffer, ref int startIndex)
    {
    }
}
partial class DbTable
{
    public byte[] GetBytes()
    {
        var buffers = new List<byte[]>();
        buffers.Add(this.Name.GetBytes());
        buffers.Add(this.Schema.GetBytes());
        //foreach (var col in this.Columns) buffers.Add(col.GetBytes());
        //foreach (var row in this.Rows) buffers.Add(row.GetBytes());
        //buffers.Add(this.Set.GetBytes());
        return buffers.Combine();
    }
    public void Fill(byte[] buffer, ref int startIndex)
    {
        throw new Exception("todo");
    }
}
partial class Columns
{
    public byte[] GetBytes()
    {
        return null;
    }
    public void Fill(byte[] buffer, ref int startIndex)
    {
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
partial class Rows
{
    public byte[] GetBytes()
    {
        return null;
    }
    public void Fill(byte[] buffer, ref int startIndex)
    {
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
