using jomiunsExtensions;

namespace theTester
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod("ambil property satu dua dalam format tertentu dari suatu file")]
        public void TestMethod1()
        {
            var commandLine = @"ambil property latitude longitude dalam format ""coordinate hasil01,hasil02"" dari file C:\Users\afrya\satuData.json";
            var theArgs = commandLine.toArgs();
            Program.Main(theArgs);
        }

        [TestMethod("ambil property latitude longitude dalam suatu format, dengan sumber data dari pipe")]
        public void TestMethod2()
        {
            var fileReader = new StreamReader(@"C:\Users\afrya\satuData.json");
            Console.SetIn(fileReader);

            var commandLine = @"ambil property latitude longitude dalam format ""coordinate hasil01,hasil02"" ";
            var theArgs = commandLine.toArgs();

            Program.Main(theArgs);

        }
        
        [TestMethod("dari item ke 1 ambil property latitude longitude dalam suatu format, dengan sumber data dari pipe")]
        public void TestMethod3()
        {
            var fileReader = new StreamReader(@"C:\Users\afrya\samplefile");
            Console.SetIn(fileReader);

            var commandLine = @"item ke 1 ambil property latitude longitude dalam format ""coordinate hasil01,hasil02"" ";
            var theArgs = commandLine.toArgs();

            Program.Main(theArgs);

        }
    }
}
