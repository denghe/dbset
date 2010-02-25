using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class DbSet
{
    public DbSet()
    {
        this.Tables = new Tables();
        this.Messages = new Messages();
        this.Errors = new Errors();
    }

    public Tables Tables { get; private set; }
    public Messages Messages { get; private set; }
    public Errors Errors { get; private set; }
    public int ReturnValue { get; set; }
    public int RecordsAffected { get; set; }

    public DbTable this[int index] { get { return Tables[index]; } }
    public DbTable this[string name] { get { return Tables.Find(o => o.Name == name); } }
    public DbTable this[string name, string schema] { get { return Tables.Find(o => o.Name == name && o.Schema == schema); } }
}

public partial class Tables : List<DbTable>
{
}
public partial class Messages : List<string>
{
}
public partial class Errors : List<SqlError>
{
}

public partial class DbTable
{
    public DbTable()
    {
        this.Rows = new Rows();
        this.Columns = new Columns();
    }

    public DbSet Set { get; set; }
    public string Name { get; set; }
    public string Schema { get; set; }
    public Rows Rows { get; private set; }
    public Columns Columns { get; private set; }

    public DbRow this[int rowIdx] { get { return this.Rows[rowIdx]; } }
    public int GetOrdinal() { if (Set == null) return 0; return Set.Tables.IndexOf(this); }
    public DbRow NewRow(params object[] data) { return new DbRow(this, data); }

    public DbColumn NewColumn() { return new DbColumn(this); }
    public DbColumn NewColumn(string name, Type type, bool nullable) { return new DbColumn(this, name, type, nullable); }
    public DbColumn NewColumn(string name, Type type) { return new DbColumn(this, name, type); }
    public DbColumn NewColumn(string name) { return new DbColumn(this, name); }
}

public partial class Rows : List<DbRow>
{
}
public partial class Columns : List<DbColumn>
{
}

public partial class DbColumn
{
    private DbColumn() { }
    public DbColumn(DbTable parent, string name, Type type, bool nullable)
    {
        this.Table = parent; parent.Columns.Add(this); this.Name = name; this.Type = type; this.AllowDBNull = nullable;
        if (parent.Rows.Count > 0) foreach (DbRow row in parent.Rows) row.Increase();
    }
    public DbColumn(DbTable parent, string name, Type type) : this(parent, name, type, true) { }
    public DbColumn(DbTable parent, string name) : this(parent, name, typeof(string)) { }
    public DbColumn(DbTable parent) : this(parent, null, typeof(string)) { }

    public DbTable Table { get; set; }
    public string Name { get; set; }
    public Type Type { get; set; }
    public bool AllowDBNull { get; set; }

    public int GetOrdinal() { return this.Table.Columns.IndexOf(this); }
}

public partial class DbRow
{
    private DbRow() { }
    public DbRow(DbTable parent, params object[] data)
    {
        var count = parent.Columns.Count;
        if (count == 0 && (data == null || data.Length > 0))
            throw new Exception("Beyond the limited number of fields");
        else
        {
            if (data == null || data.Length == 0)
            {
                this._itemArray = new object[count];
                for (int i = 0; i < count; i++)
                {
                    this._itemArray[i] = DBNull.Value;
                }
            }
            else if (data.Length != count)
            {
                throw new Exception("Insufficient data or Beyond the limited number of fields");
            }
            else
            {
                this._itemArray = data;
            }
            this.Table = parent;
            parent.Rows.Add(this);
        }
    }

    public DbTable Table { get; private set; }
    private object[] _itemArray;
    public object[] ItemArray() { return this._itemArray; }

    public object this[int idx] { get { return this._itemArray[idx]; } set { this._itemArray[idx] = value; } }
    public object this[DbColumn col] { get { return this._itemArray[col.GetOrdinal()]; } set { this._itemArray[col.GetOrdinal()] = value; } }
    public object this[string name]
    {
        get { return this._itemArray[this.Table.Columns.Find(o => o.Name == name).GetOrdinal()]; }
        set { this._itemArray[this.Table.Columns.Find(o => o.Name == name).GetOrdinal()] = value; }
    }
    public void SetValues(params object[] data) { this._itemArray = data; }
    internal void Increase()
    {
        if (this._itemArray == null) this._itemArray = new object[] { null };
        else Array.Resize<object>(ref this._itemArray, this._itemArray.Length + 1);
    }
}

/// <summary>
///  Collects information relevant to a warning or error returned by SQL Server.
/// </summary>
public partial class SqlError
{
    /// <summary>
    ///     Gets the severity level of the error returned from SQL Server.
    ///
    /// Returns:
    ///     A value from 1 to 25 that indicates the severity level of the error. The
    ///     default is 0.
    /// </summary>
    public byte Class { get; set; }
    /// <summary>
    ///     Gets a numeric error code from SQL Server that represents an error, warning
    ///     or "no data found" message.
    ///
    /// Returns:
    ///     The number that represents the error code.
    /// </summary>
    public byte State { get; set; }
    /// <summary>
    ///     Gets the line number within the Transact-SQL command batch or stored procedure
    ///     that contains the error.
    ///
    /// Returns:
    ///     The line number within the Transact-SQL command batch or stored procedure
    ///     that contains the error.
    /// </summary>
    public int LineNumber { get; set; }
    /// <summary>
    ///     Gets a number that identifies the type of error.
    ///
    /// Returns:
    ///     The number that identifies the type of error.
    /// </summary>
    public int Number { get; set; }
    /// <summary>
    ///     Gets the text describing the error.
    ///
    /// Returns:
    ///     The text describing the error.For more information on errors generated by
    ///     SQL Server, see SQL Server Books Online.
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    ///     Gets the name of the stored procedure or remote procedure call (RPC) that
    ///     generated the error.
    ///
    /// Returns:
    ///     The name of the stored procedure or RPC.For more information on errors generated
    ///     by SQL Server, see SQL Server Books Online.
    /// </summary>
    public string Procedure { get; set; }
    /// <summary>
    ///     Gets the name of the instance of SQL Server that generated the error.
    ///
    /// Returns:
    ///     The name of the instance of SQL Server.
    /// </summary>
    public string Server { get; set; }
    /// <summary>
    ///     Gets the name of the provider that generated the error.
    ///
    /// Returns:
    ///     The name of the provider that generated the error.
    /// </summary>
    public string Source { get; set; }
}