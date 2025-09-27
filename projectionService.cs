using jomiunsCli;

namespace beautify;

internal class projectionService(jsonProcess _jsonProces, iCLIparser _cliParser)
{

    private iKommandOne<string> _dalamFormat = (iKommandOne<string>) _cliParser["dalamFormat"];

    internal void execute()
    {
        var aArrayOfObject = _jsonProces.getProperties();
        foreach(var item in _dalamFormat.Results)
        {
            var theResult = item.theResult;
            for(int intA = 0; intA < aArrayOfObject.Length; intA++)
            {
                var placeholder = $"hasil{intA + 1:D2}";
                theResult = theResult.Replace(placeholder, aArrayOfObject[intA]?.ToString() ?? string.Empty);
            }
            Console.WriteLine(theResult);
        }
    }
}
