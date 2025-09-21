using jomiunsCli;
using jomiunsExtensions;

namespace beautify;

internal class dataSourceSolver(object? dummy, iCLIparser _parser)
{
    private iKommandFlag _dariClip = (iKommandFlag)_parser["dariClip"];
    private iKommandOne<string> _dariFile = (iKommandOne<string>)_parser["dariFile"];
    public dataSourceSolver(iCLIparser _parser) : this(null, _parser)
    {
        if (_dariClip.Results.Any())
        {
            var aClipboard = new TextCopy.Clipboard();
            dataSource = aClipboard.GetText();
            if (dataSource.isNullOrEmpty())
            {
                Console.WriteLine("Clipboard is empty");
                return;
            }
        }
        else if (_dariFile.Results.Any())
        {
            var PFN = _dariFile.Results.First().theResult;
            dataSource = System.IO.File.ReadAllText(PFN);
        }
        else
        {
            dataSource = Console.In.ReadToEnd();
        }
        dataSource = dataSource.Trim('\n', '\r', ' ');
    }

    internal string dataSource { get; }
}
