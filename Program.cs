// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.RegularExpressions;
var stringFromPipeline = Console.In.ReadToEndAsync();
var sanitiedString = (await stringFromPipeline).Trim('\n', '\r', ' ');
var itsAJson = Regex.IsMatch(sanitiedString, @"^[{\[].*[\]}]$");
var itsAnXml = Regex.IsMatch(sanitiedString, @"^<.*>$");
if (itsAJson)
{
    using JsonDocument doc = JsonDocument.Parse(await stringFromPipeline);
    var root = doc.RootElement;
    var options = new JsonSerializerOptions{WriteIndented = true};
    string prettyJson = JsonSerializer.Serialize(root, options);
    Console.WriteLine(prettyJson);
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
}