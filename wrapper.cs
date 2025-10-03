using jomiunsCli;

namespace beautify;

internal class wrapper(dataSourceSolver _dataSourceSolver, projectionService _projService)
{
    internal void execute(string awal, string akhir)
    {
        if (_projService.getProjections().Any())
        {
            foreach(var item in _projService.getProjections())
            {
                Console.WriteLine($"{awal}{item}{akhir}");
            }
            return;
        }

        Console.WriteLine($"{awal}{_dataSourceSolver.dataSource}{akhir}");
    }

}
