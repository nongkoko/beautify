// See https://aka.ms/new-console-template for more information
using beautify;
using Newtonsoft.Json.Linq;

internal class JArraySolver(object? dummy, dataSourceSolver _dataSourceSolver)
{
    internal JArray? jArray { get; }
    public JArraySolver(dataSourceSolver nb5m23bn5) : this(null, nb5m23bn5)
    {
        jArray = JArray.Parse(nb5m23bn5.dataSource);
    }

}