using jomiunsCli;
using jomiunsExtensions;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace beautify;

internal class jsonProcess(dataSourceSolver _dsSolver, iCLIparser _cliParser)
{
    private iKommandOne<string[]> _ambilProperty = (iKommandOne<string[]>)_cliParser["ambilProperty"];
    private iKommandOne<int> _ambilItemKe = (iKommandOne<int>)_cliParser["itemKe"];
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
            JObject? aDoc;
            if (_ambilItemKe.Results.Any())
            {
                var anArray = JArray.Parse(_dsSolver.dataSource);
                var index = _ambilItemKe.Results.First().theResult;
                aDoc = anArray.ElementAtOrDefault(index - 1) as JObject;
            }
            else
            {
                aDoc = JObject.Parse(_dsSolver.dataSource);
            }

            var thePaths = _ambilProperty.Results.First().theResult;
            var aList = new List<object>();
            foreach (var item in thePaths)
            {
                var aResult = aDoc.SelectToken(item);
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
