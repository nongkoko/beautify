using jomiunsCli;
using Newtonsoft.Json.Linq;

namespace beautify;

internal class spreader(dataSourceSolver _dataSourceSolver, iCLIparser _cliParser)
{
    private iKommandOne<string> _theSpread = (iKommandOne<string>)_cliParser["spread"];

    internal void execute()
    {
        var thePattern = _theSpread.Results.First().theResult;
        var anArray = JArray.Parse(_dataSourceSolver.dataSource);
        foreach (var (item, ewbtnmb) in anArray.Select((aa, bb) => (aa, bb)))
        {
            var aFileName = thePattern.Replace("#", ewbtnmb.ToString());
            File.WriteAllText(aFileName, item.ToString(Newtonsoft.Json.Formatting.None));
            if (ewbtnmb % 10 == 0)
                Console.WriteLine($"written to {aFileName}");
        }
    }
}
