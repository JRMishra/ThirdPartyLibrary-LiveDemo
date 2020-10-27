namespace ThirdPartyLibDemoLive
{
    using CsvHelper;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    class CsvHandler
    {
        public static void ImplementCsvDataHandling()
        {
            //Declaration of import and export path
            string importFilePath = PathToFile.ImportedCsv;
            //if imported file doesn't exist, program terminates
            if (!File.Exists(importFilePath))
            {
                Console.WriteLine("The file to be imported on specified path is absent");
                return;
            }
            string exportFilePath = PathToFile.ExportedCsv;

            //Initializes instance of stream reader on imported file
            using (var streamReader = new StreamReader(importFilePath))
            {
                //Initializes instance of csv reader using prev streamreader
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    //read data from imported csv and store as IEnumerable<AddressData> in records
                    var records = csvReader.GetRecords<AddressData>().ToList();
                    Console.WriteLine("Data Reading Done Successfully from Address.csv file");
                    //Loop through records data
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
                    //Initializes instance of stream writer on exported file path

                    using (var streamWriter = new StreamWriter(exportFilePath))
                    {
                        //Initializes instance of csv writer using streamwriter
                        using (var csvExport = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                        {
                            //write data from records into exported csv file
                            //If file is absent, it creates the file and write data in it
                            csvExport.WriteRecords(records);
                        }
                    }
                    Console.WriteLine("Data successfully exported to another CSV file");
                }    
            }   
        }
    }
}
