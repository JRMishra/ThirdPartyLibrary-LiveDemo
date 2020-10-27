using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ThirdPartyLibDemoLive
{
    class CsvHandler
    {
        public static void ImplementCsvDataHandling()
        {
            string importFilePath = PathToFile.ImportedCsv;
            string exportFilePath = PathToFile.ExportedCsv;

            using (var reader = new StreamReader(importFilePath))
            {
                using(var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<AddressData>().ToList();
                    Console.WriteLine("Data Reading Done Successfully from Address.csv file");
                    foreach(AddressData addressData in records)
                    {
                        Console.Write(addressData.FirstName+",\t");
                        Console.Write(addressData.LastName+",\t");
                        Console.Write(addressData.Address+",\t");
                        Console.Write(addressData.City+",\t");
                        Console.Write(addressData.State+",\t");
                        Console.Write(addressData.Code+",\t");
                        Console.WriteLine("\n");
                    }

                    using (var writer = new StreamWriter(exportFilePath))
                    {
                        using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csvExport.WriteRecords(records);
                        }
                    }
                    Console.WriteLine("Data successfully exported to another CSV file");
                }

                
            }

            
        }
    }
}
