// See https://aka.ms/new-console-template for more information
using beautify;
using Newtonsoft.Json.Linq;

internal class asTable(JArraySolver _jArraySolver)
{
    internal void execute()
    {
        var aList = new List<int>();

        var allDocs = _jArraySolver.jArray;
        foreach (var (idxidx, item) in allDocs.Select((oo,ii)=>(ii,oo)))
        {
            foreach (var (idx, prop) in item.Select((oo, ii) => (ii+1, oo)))
            {
                var jProp = prop as JProperty;

                var panjangnya = 10;
                if (idxidx == 0)
                    panjangnya = (jProp?.Name.Length ?? 0);
                else
                    panjangnya = (jProp?.Value.ToString().Length ?? 0);

                if (aList.Count < idx)
                    aList.Add(panjangnya);

                else if (aList[idx - 1] < panjangnya)
                    aList[idx - 1] = panjangnya;

                //Console.Write($"{jProp.Name} {jProp.Value}");
            }
            //break;
            //Console.WriteLine(item.ToString());
        }


        //mulai menggambar
        foreach (var (idxidx, item) in allDocs.Select((oo, ii) => (ii, oo)))
        {
            foreach (var (idx, prop) in item.Select((oo, ii) => (ii, oo)))
            {
                var jProp = prop as JProperty;
                var cellContent = "";
                if (idxidx == 0)
                    cellContent = jProp?.Name ?? "";
                else
                    cellContent = jProp?.Value.ToString() ?? "";
                var hasilKu = string.Format("{0," + aList[idx] + "}", cellContent);
                Console.Write($" {hasilKu}");
            }
            Console.WriteLine();
        }

    }
}