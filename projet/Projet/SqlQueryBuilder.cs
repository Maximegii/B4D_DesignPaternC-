public class SqlQueryBuilder
{
    private string _table;
    private readonly List<string> _columns = new();
    private readonly List<string> _whereConditions = new();
    private string _orderBy;
    public SqlQueryBuilder From(string table)
    {
        _table = table;
        return this;
    }
    public SqlQueryBuilder Select(params string[] columns)
    {
        _columns.AddRange(columns);
        return this;
    }
    public SqlQueryBuilder Where(string condition)
    {
        _whereConditions.Add(condition);
        return this;
    }
    public string Build()
    {
        if (string.IsNullOrEmpty(_table))
            throw new InvalidOperationException("Table name is required to build a SQL query.");

        var query = "SELECT ";

        query += _columns.Count > 0 ? string.Join(", ", _columns) : "*";
        query += " FROM " + _table;

        if (_whereConditions.Count > 0)
            query += " WHERE " + string.Join(" AND ", _whereConditions);

        if (!string.IsNullOrEmpty(_orderBy))
            query += " ORDER BY " + _orderBy;

        return query + ";";
    }

}