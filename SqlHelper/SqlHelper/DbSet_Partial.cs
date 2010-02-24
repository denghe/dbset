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
        // 存储顺序：字段 Count 个 byte 的 0(DbNull), 1 标记， 非 DbNull 的字段长度 4 bytes (如果非定长) + 内容 bytes 若干

        var buffers = new List<byte[]>();
        var bytes_flags = new byte[_itemArray.Length];
        buffers.Add(bytes_flags);
        for (int i = 0; i < _itemArray.Length; i++)
        {
            if (_itemArray[i] == DBNull.Value)
            {
                bytes_flags[i] = 0;
                continue;
            }
            else bytes_flags[i] = 1;
            buffers.Add(_itemArray[i].GetBytes(Table.Columns[i].Type.Name));
        }
        return buffers.Combine();
    }
    public void Fill(byte[] buffer, ref int startIndex)
    {
        throw new Exception("todo");
    }
}

partial class SqlError
{
    public byte[] GetBytes()
    {
        var buffers = new List<byte[]>();
        buffers.Add(new byte[] { this.Class });
        buffers.Add(new byte[] { this.State });
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
        this.Class = buffer[startIndex++];
        this.State = buffer[startIndex++];
        this.LineNumber = (int)buffer.GetObject(typeof(int), ref startIndex);
        this.Number = (int)buffer.GetObject(typeof(int), ref startIndex);
        this.Message = (string)buffer.GetObject(typeof(string), ref startIndex);
        this.Procedure = (string)buffer.GetObject(typeof(string), ref startIndex);
        this.Server = (string)buffer.GetObject(typeof(string), ref startIndex);
        this.Source = (string)buffer.GetObject(typeof(string), ref startIndex);
    }
}
