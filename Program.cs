// See https://aka.ms/new-console-template for more information
using System.Text.Json;

Console.WriteLine("Hello, World!");

var stringFromPipeline = Console.In.ReadToEndAsync();
using JsonDocument doc = JsonDocument.Parse(await stringFromPipeline);
var root = doc.RootElement;
var options = new JsonSerializerOptions
{
    WriteIndented = true
};
string prettyJson = JsonSerializer.Serialize(root, options);
Console.WriteLine(prettyJson);