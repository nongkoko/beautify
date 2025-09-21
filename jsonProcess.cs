using System.Text.Json;

namespace beautify;

internal class jsonProcess(dataSourceSolver _dsSolver)
{
    internal void execute()
    {
        using JsonDocument doc = JsonDocument.Parse(_dsSolver.dataSource);
        var root = doc.RootElement;
        var options = new JsonSerializerOptions { WriteIndented = true };
        string prettyJson = JsonSerializer.Serialize(root, options);
        Console.WriteLine(prettyJson);
    }
}
