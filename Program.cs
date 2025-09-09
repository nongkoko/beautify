// See https://aka.ms/new-console-template for more information
using jomiunsCli;
using jomiunsExtensions;
using System.Text.Json;
using System.Text.RegularExpressions;
var sourceString = "";

var aParser = new CLIparser(args);
var aClip = aParser.registerCommand("untuk ambil source data dari clipboard", "--clip", "dari clipboard");
var aShow = aParser.registerCommand("show the source data before execution", "show");
var aSplit = aParser.registerCommand<string[]>("untuk split source data by a delimiter", "delimiternya, contoh ;", "split", "splitby");
if (aParser.startParsing() == false)
    return;



if (aClip.Results.Any())
{
    var aClipboard = new TextCopy.Clipboard();
    sourceString = aClipboard.GetText();
    if (sourceString.isNullOrEmpty())
    {
        Console.WriteLine("Clipboard is empty");
        return;
    }
}
else
{
    var stringFromPipeline = Console.In.ReadToEndAsync();
    sourceString = await stringFromPipeline;
}

var sanitiedString = sourceString.Trim('\n', '\r', ' ');

if (aShow.Results.Any())
    Console.WriteLine(sourceString);

var itsAJson = Regex.IsMatch(sanitiedString, @"^\s*{[\s\S]*}\s*$");
var itsAnXml = Regex.IsMatch(sanitiedString, @"^<.*>$");

if (aSplit.Results.Any())
{
    var delimiter = aSplit.Results.First();
    var splitResults = sanitiedString.Split(delimiter.theResult, StringSplitOptions.None);
    var aJoined = string.Join("\n", splitResults);
    Console.WriteLine(aJoined);
    return;
}

if (itsAJson)
{
    using JsonDocument doc = JsonDocument.Parse(sanitiedString);
    var root = doc.RootElement;
    var options = new JsonSerializerOptions { WriteIndented = true };
    string prettyJson = JsonSerializer.Serialize(root, options);
    Console.WriteLine(prettyJson);
    return;
}

if (itsAnXml)
{
    var doc = new System.Xml.XmlDocument();
    doc.LoadXml(sanitiedString);
    var stringWriter = new System.IO.StringWriter();
    var xmlTextWriter = new System.Xml.XmlTextWriter(stringWriter) { Formatting = System.Xml.Formatting.Indented };
    doc.WriteTo(xmlTextWriter);
    xmlTextWriter.Flush();
    Console.WriteLine(stringWriter.GetStringBuilder().ToString());
    return;
}