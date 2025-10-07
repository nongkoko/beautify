using jomiunsCli;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace beautify;

internal class JObjectSolver(object? dummy, iCLIparser _cliParser)
{
    private iKommandOne<int> _ambilItemKe = (iKommandOne<int>)_cliParser["itemKe"];

    public JObjectSolver(IServiceProvider sp, dataSourceSolver nb5m23bn5, iCLIparser nbm3623) : this((object?)null, nbm3623)
    {
        if (_ambilItemKe.Results.Any())
        {
            var index = _ambilItemKe.Results.First().theResult;
            jObject = sp.GetRequiredService<JArraySolver>().jArray.ElementAtOrDefault(index - 1) as JObject;
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
