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
    public DbSet Fill(byte[] buffer)
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
    public DbSet Fill(byte[] buffer)
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
    public DbSet Fill(byte[] buffer)
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
            var column = Table.Columns[i];
            switch (column.Type.Name)
            {
                case "System.Boolean":
                    buffers.Add(BitConverter.GetBytes((bool)_itemArray[i]));
                    break;
                case "System.Byte":
                    buffers.Add(new byte[] { (byte)_itemArray[i] });
                    break;
                case "System.Byte[]":
                    var bytes = (byte[])_itemArray[i];
                    buffers.Add(BitConverter.GetBytes(bytes.Length));
                    buffers.Add(bytes);
                    break;
                case "System.Char":
                    var charbytes = Encoding.Unicode.GetBytes(new char[] { (char)_itemArray[i] });
                    buffers.Add(new byte[] { (byte)charbytes.Length });
                    buffers.Add(charbytes);
                    break;
                case "System.DateTime":
                    buffers.Add(BitConverter.GetBytes(((DateTime)_itemArray[i]).ToBinary()));
                    break;
                case "System.Decimal":
                    var ints = Decimal.GetBits((Decimal)_itemArray[i]);
                    buffers.Add(BitConverter.GetBytes(ints.Length));
                    foreach (var a in ints)
                        buffers.Add(BitConverter.GetBytes(a));
                    break;
                case "System.Double":
                    buffers.Add(BitConverter.GetBytes((double)_itemArray[i]));
                    break;
                case "System.Guid":
                    buffers.Add(((Guid)_itemArray[i]).ToByteArray());
                    break;
                case "System.Int16":
                    buffers.Add(BitConverter.GetBytes((short)_itemArray[i]));
                    break;
                case "System.Int32":
                    buffers.Add(BitConverter.GetBytes((int)_itemArray[i]));
                    break;
                case "System.Int64":
                    buffers.Add(BitConverter.GetBytes((long)_itemArray[i]));
                    break;
                // todo:
                //System.SByte
                //System.Single
                //System.String
                //System.TimeSpan
                //System.UInt16
                //System.UInt32
                //System.UInt64
            }
        }
        throw new Exception("todo");
    }
    public DbSet Fill(byte[] buffer)
    {
        throw new Exception("todo");
    }
}

partial class SqlError
{
    public byte[] GetBytes()
    {
        var bytes_LineNumber = BitConverter.GetBytes(LineNumber);
        var length_bytes_LineNumber = bytes_LineNumber.Length;

        var bytes_Number = BitConverter.GetBytes(Number);
        var length_bytes_Number = bytes_Number.Length;

        var bytes_Message = Encoding.Unicode.GetBytes(this.Message);
        var length_bytes_Message = bytes_Message.Length;
        var bytes_length_bytes_Message = BitConverter.GetBytes(length_bytes_Message);
        var length_bytes_length_bytes_Message = bytes_length_bytes_Message.Length;

        var bytes_Procedure = Encoding.Unicode.GetBytes(this.Procedure);
        var length_bytes_Procedure = bytes_Procedure.Length;
        var bytes_length_bytes_Procedure = BitConverter.GetBytes(length_bytes_Procedure);
        var length_bytes_length_bytes_Procedure = bytes_length_bytes_Procedure.Length;

        var bytes_Server = Encoding.Unicode.GetBytes(this.Server);
        var length_bytes_Server = bytes_Server.Length;
        var bytes_length_bytes_Server = BitConverter.GetBytes(length_bytes_Server);
        var length_bytes_length_bytes_Server = bytes_length_bytes_Server.Length;

        var bytes_Source = Encoding.Unicode.GetBytes(this.Source);
        var length_bytes_Source = bytes_Source.Length;
        var bytes_length_bytes_Source = BitConverter.GetBytes(length_bytes_Source);
        var length_bytes_length_bytes_Source = bytes_length_bytes_Source.Length;

        var buffer = new byte[
            sizeof(byte)
            + sizeof(byte)
            + length_bytes_LineNumber
            + length_bytes_Number
            + length_bytes_length_bytes_Message
            + length_bytes_Message
            + length_bytes_length_bytes_Procedure
            + length_bytes_Procedure
            + length_bytes_length_bytes_Server
            + length_bytes_Server
            + length_bytes_length_bytes_Source
            + length_bytes_Source
        ];
        var idx = 0;

        buffer[idx] = Class; idx++;

        buffer[idx] = State; idx++;

        Array.Copy(bytes_LineNumber, 0, buffer, idx, length_bytes_LineNumber); idx += length_bytes_LineNumber;

        Array.Copy(bytes_Number, 0, buffer, idx, length_bytes_Number); idx += length_bytes_Number;

        Array.Copy(bytes_length_bytes_Message, 0, buffer, idx, length_bytes_length_bytes_Message); idx += length_bytes_length_bytes_Message;
        Array.Copy(bytes_Message, 0, buffer, idx, length_bytes_Message); idx += length_bytes_Message;

        Array.Copy(bytes_length_bytes_Procedure, 0, buffer, idx, length_bytes_length_bytes_Procedure); idx += length_bytes_length_bytes_Procedure;
        Array.Copy(bytes_Procedure, 0, buffer, idx, length_bytes_Procedure); idx += length_bytes_Procedure;

        Array.Copy(bytes_length_bytes_Server, 0, buffer, idx, length_bytes_length_bytes_Server); idx += length_bytes_length_bytes_Server;
        Array.Copy(bytes_Server, 0, buffer, idx, length_bytes_Server); idx += length_bytes_Server;

        Array.Copy(bytes_length_bytes_Source, 0, buffer, idx, length_bytes_Source); idx += length_bytes_length_bytes_Source;
        Array.Copy(bytes_Source, 0, buffer, idx, length_bytes_Source); idx += length_bytes_Source;

        return buffer;
    }
    public DbSet Fill(byte[] buffer)
    {
        throw new Exception("todo");
    }
}
