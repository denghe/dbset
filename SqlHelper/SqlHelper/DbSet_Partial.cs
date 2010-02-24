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
partial class DbTable
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
partial class DbColumn
{
    public byte[] GetBytes()
    {
        var buffers = new List<byte[]>();
        buffers.Add(this.Name.GetBytes());
        throw new Exception("todo");
    }
    public void Fill(byte[] buffer, ref int startIndex)
    {
        throw new Exception("todo");
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
            buffers.Add(_itemArray[i].GetBytes());
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
                    _itemArray[i] = buffer.ToObject(column.Type, ref startIndex);
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
        this.Class = (byte)buffer.ToObject(typeof(byte), ref startIndex);
        this.State = (byte)buffer.ToObject(typeof(byte), ref startIndex);
        this.LineNumber = (int)buffer.ToObject(typeof(int), ref startIndex);
        this.Number = (int)buffer.ToObject(typeof(int), ref startIndex);
        this.Message = (string)buffer.ToObject(typeof(string), ref startIndex);
        this.Procedure = (string)buffer.ToObject(typeof(string), ref startIndex);
        this.Server = (string)buffer.ToObject(typeof(string), ref startIndex);
        this.Source = (string)buffer.ToObject(typeof(string), ref startIndex);
    }
}
