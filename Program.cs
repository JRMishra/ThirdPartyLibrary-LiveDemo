using System;

namespace ThirdPartyLibDemoLive
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvHandler.ImplementCsvDataHandling();
            JsonHandler.CsvToJson();
            JsonHandler.JsonToCsv();
        }
    }
}
