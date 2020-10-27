using System;
using System.Collections.Generic;
using System.Text;

namespace ThirdPartyLibDemoLive
{
    //Common class having address of all paths
    class PathToFile
    {
        public static string ImportedCsv = @"C:\Users\user\source\repos\ThirdPartyLibDemoLive\fileStorage\Address.csv";
        public static string ExportedCsv = @"C:\Users\user\source\repos\ThirdPartyLibDemoLive\fileStorage\Exported.csv";
        public static string ExportedCsvFromJson = @"C:\Users\user\source\repos\ThirdPartyLibDemoLive\fileStorage\AddressFromJson.csv";
        public static string ExportedJson = @"C:\Users\user\source\repos\ThirdPartyLibDemoLive\fileStorage\Address.json";
        public static string ImportedJson = ExportedJson;
    }
}
