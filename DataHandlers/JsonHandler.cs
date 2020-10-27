using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ThirdPartyLibDemoLive
{
    class JsonHandler
    {
        public static void CsvToJson()
        {
            string importPath = PathToFile.ImportedCsv;
            string exportPath = PathToFile.ExportedJson;

            using(var streamReader = new StreamReader(importPath))
            {
                using(var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<AddressData>().ToList();
                    Console.WriteLine("Read data successfully from address.csv");
                    foreach(AddressData addressData in records)
                    {
                        Console.Write(addressData.FirstName + ",\t");
                        Console.Write(addressData.LastName + ",\t");
                        Console.Write(addressData.Address + ",\t");
                        Console.Write(addressData.City + ",\t");
                        Console.Write(addressData.State + ",\t");
                        Console.Write(addressData.Code + ",\t");
                        Console.WriteLine("\n");
                    }

                    JsonSerializer jsonSerializer = new JsonSerializer();
                    using(StreamWriter streamWriter = new StreamWriter(exportPath))
                    {
                        using(JsonWriter writer = new JsonTextWriter(streamWriter))
                        {
                            jsonSerializer.Serialize(streamWriter, records);
                        }
                    }
                    Console.WriteLine("Write data successfully to JSON file");
                }
            }
        }

        public static void JsonToCsv()
        {
            string exportPath = PathToFile.ExportedCsvFromJson;
            string importPath = PathToFile.ImportedJson;
            IList<AddressData> addressData = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importPath));
            Console.WriteLine("Read data successfully from address.json");
            using (var writer = new StreamWriter(exportPath))
            {
                using(var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(addressData);
                }
            }
            Console.WriteLine("Write data successfully to CSV file");
        }
    }
}
