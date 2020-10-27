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
            //Declaration of import and export path
            string importFilePath = PathToFile.ImportedCsv;
            //if imported file doesn't exist, program terminates
            if (!File.Exists(importFilePath))
            {
                Console.WriteLine("The file to be imported on specified path is absent");
                return;
            }
            string exportFilePath = PathToFile.ExportedJson;

            //Initializes instance of stream reader on imported file
            using (var streamReader = new StreamReader(importFilePath))
            {
                //Initializes instance of csv reader using streamreader
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    //read data from imported csv and store as IEnumerable<AddressData> in records
                    var records = csvReader.GetRecords<AddressData>().ToList();
                    Console.WriteLine("Read data successfully from address.csv");

                    //Loop through records data
                    foreach (AddressData addressData in records)
                    {
                        Console.Write(addressData.FirstName + ",\t");
                        Console.Write(addressData.LastName + ",\t");
                        Console.Write(addressData.Address + ",\t");
                        Console.Write(addressData.City + ",\t");
                        Console.Write(addressData.State + ",\t");
                        Console.Write(addressData.Code + ",\t");
                        Console.WriteLine("\n");
                    }
                    //Declare instance of jsonserilizer class
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    //Initializes instance of stream writer on exported file
                    using (StreamWriter streamWriter = new StreamWriter(exportFilePath))
                    {
                        //Initializes instance of json text writer using streamwriter
                        using (JsonWriter writer = new JsonTextWriter(streamWriter))
                        {
                            //Use json serialize method to write data from records to exported json file
                            //If file is absent, it creates the file and write data in it
                            jsonSerializer.Serialize(streamWriter, records);
                        }
                    }
                    Console.WriteLine("Write data successfully to JSON file");
                }
            }
        }

        public static void JsonToCsv()
        {
            //Declaration of import and export path
            string importFilePath = PathToFile.ImportedJson;
            //if imported file doesn't exist, program terminates
            if (!File.Exists(importFilePath))
            {
                Console.WriteLine("The file to be imported on specified path is absent");
                return;
            }
            string exportFilePath = PathToFile.ExportedCsvFromJson;
            
            //Used Json deserializer to convert and store data from json file to list object
            IList<AddressData> addressData = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFilePath));
            Console.WriteLine("Read data successfully from address.json");
            //Initializes instance of stream writer on exported file path
            using (var writer = new StreamWriter(exportFilePath))
            {
                //Initializes instance of csv writer using stream writer
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    //write data from records into exported csv file
                    //If file is absent, it creates the file and write data in it
                    csvExport.WriteRecords(addressData);
                }
            }
            Console.WriteLine("Write data successfully to CSV file");
        }
    }
}
