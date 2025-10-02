using jomiunsCli;

namespace beautify;

internal class wrapper(dataSourceSolver _dataSourceSolver)
{
    internal void execute(string awal, string akhir)
    {
        Console.WriteLine($"{awal}{_dataSourceSolver.dataSource}{akhir}");
    }

}
