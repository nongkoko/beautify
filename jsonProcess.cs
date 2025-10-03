using jomiunsCli;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace beautify;

internal class jsonProcess(dataSourceSolver _dsSolver, iCLIparser _cliParser, JObjectSolver _jObjectSolver)
{
    private iKommandOne<string[]> _ambilProperty = (iKommandOne<string[]>)_cliParser["ambilProperty"];
    
    internal void execute()
    {
        using JsonDocument doc = JsonDocument.Parse(_dsSolver.dataSource);
        var root = doc.RootElement;
        var options = new JsonSerializerOptions { WriteIndented = true };
        string prettyJson = JsonSerializer.Serialize(root, options);
        Console.WriteLine(prettyJson);
    }

    internal object[] getProperties()
    {

        if (_ambilProperty.Results.Any())
        {
            var thePaths = _ambilProperty.Results.First().theResult;
            var aList = new List<object>();
            foreach (var item in thePaths)
            {
                var aResult = _jObjectSolver.jObject?.SelectToken(item);
                if (aResult != null)
                {
                    aList.Add(aResult.Value<object>()!);
                }
            }
            var aArray = aList.ToArray();
            return aArray;
        }
        return default;
    }

}
