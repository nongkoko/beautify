using jomiunsCli;
using Newtonsoft.Json.Linq;

namespace beautify;

internal class JObjectSolver(object? dummy, dataSourceSolver _dataSourceSolver, iCLIparser _cliParser)
{
    private iKommandOne<int> _ambilItemKe = (iKommandOne<int>)_cliParser["itemKe"];

    public JObjectSolver(dataSourceSolver nb5m23bn5, iCLIparser nbm3623) : this(null, nb5m23bn5, nbm3623)
    {
        if (_ambilItemKe.Results.Any())
        {
            var anArray = JArray.Parse(nb5m23bn5.dataSource);
            var index = _ambilItemKe.Results.First().theResult;
            jObject = anArray.ElementAtOrDefault(index - 1) as JObject;
        }
        else
        {
            try
            {
                jObject = JObject.Parse(nb5m23bn5.dataSource);
            }
            catch (Exception ex)
            {

            }
        }
    }

    public JObject? jObject { get; set; }

}
