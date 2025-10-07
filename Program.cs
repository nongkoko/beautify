// See https://aka.ms/new-console-template for more information
using beautify;
using jomiunsCli;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        var aParser = factory.newCliParser(args);
        aParser.registerCommand<string, string>("wrap dengan awal dan akhir", "awal", "akhir", "wrap with").setKeyName("wrapthis");
        aParser.registerCommand("untuk ambil source data dari clipboard", "--clip", "dari clipboard").setKeyName("dariClip");
        aParser.registerCommand("tampilkan dalam bentuk table", commandTriggers: "view as table").setKeyName("asTable");
        aParser.registerCommand<int>("ambil item ke n dari array of object di json", "n starting 1", "item ke").setKeyName("itemKe");
        aParser.registerCommand<string>("untuk ambil source data dari file", "path file name", commandTriggers: "dari file").setKeyName("dariFile");
        aParser.registerCommand<string>("spread jarray file ke beberapa file", "file name pattern", commandTriggers: "spread to").setKeyName("spread");
        aParser.registerCommand("show the source data before execution", commandTriggers: "show").setKeyName("showContent");
        aParser.registerCommand<string[]>("ambil data untuk projection", "list properties delimited by space", commandTriggers: "ambil property").setKeyName("ambilProperty");
        aParser.registerCommand<string>("format projection", @"formatnya contoh ""coordinate hasil01,hasil02""", commandTriggers: "dalam format").setKeyName("dalamFormat");
        aParser.registerCommand<string[]>("untuk split source data by a delimiter", "delimiternya, contoh ;", "split", "splitby").setKeyName("split");

        if (aParser.startParsing() == false)
            return;

        var aBuilder = new ServiceCollection();
        aBuilder.AddScoped(oo => aParser);
        aBuilder.AddScoped<dataSourceSolver>();
        aBuilder.AddScoped<wrapper>();
        aBuilder.AddScoped<JObjectSolver>();
        aBuilder.AddScoped<JArraySolver>();
        aBuilder.AddScoped<spreader>();
        aBuilder.AddScoped<asTable>();
        aBuilder.AddScoped<projectionService>();
        aBuilder.AddScoped<jsonProcess>();
        var servProvider = aBuilder.BuildServiceProvider();
        var dataSource = servProvider.GetRequiredService<dataSourceSolver>().dataSource;

        if (aParser["showContent"].As<iKommandFlag>().Results.Any())
            Console.WriteLine(dataSource);


        var itsAJson = Regex.IsMatch(dataSource, @"^\s*[{\[][\s\S]*[}\]]\s*$");
        var itsAnXml = Regex.IsMatch(dataSource, @"^<[\s\S]*>$");

        if (aParser["spread"] is iKommandOne<string> theSpread && theSpread.Results.Any())
        {
            servProvider.GetRequiredService<spreader>().execute();
            return;
        }

        if (aParser["asTable"] is iKommandFlag viewAsTable && viewAsTable.Results.Any())
        {
            servProvider.GetRequiredService<asTable>().execute();
            return;
        }

        if (aParser["wrapthis"] is iKommandTwo<string, string> theWrap && theWrap.Results.Any())
        {
            var (awal, akhir) = theWrap.Results.First().theResult;
            servProvider.GetRequiredService<wrapper>().execute(awal, akhir);
            return;
        }

        if (aParser["dalamFormat"] is iKommandOne<string> theFormat && theFormat.Results.Any())
        {
            foreach(var item in servProvider.GetRequiredService<projectionService>().getProjections())
            {
                Console.WriteLine(item);
            }
            return;
        }

        if (aParser["split"] is iKommandOne<string[]> thePar && thePar.Results.Any())
        {
            var delimiter = thePar.Results.First();
            var splitResults = dataSource.Split(delimiter.theResult, StringSplitOptions.None);
            var aJoined = string.Join("\n", splitResults);
            Console.WriteLine(aJoined);
            return;
        }

        if (itsAJson)
        {
            servProvider.GetRequiredService<jsonProcess>().execute();
        }

        if (itsAnXml)
        {
            var doc = new System.Xml.XmlDocument();
            doc.LoadXml(dataSource);
            var stringWriter = new StringWriter();
            var xmlTextWriter = new System.Xml.XmlTextWriter(stringWriter) { Formatting = System.Xml.Formatting.Indented };
            doc.WriteTo(xmlTextWriter);
            xmlTextWriter.Flush();
            Console.WriteLine(stringWriter.GetStringBuilder().ToString());
            return;
        }
    }
}