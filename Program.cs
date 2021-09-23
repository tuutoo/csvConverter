using System;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.IO;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace csvConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CSV Converter started...");
            using (var streamReader = new StreamReader(@"./test.csv"))
            {
                string jsonString;
                using (var csvreader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvreader.GetRecords<Invoice>().ToList();
                    //Csv data as Json string if needed
                    jsonString = JsonConvert.SerializeObject(records);
                }

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine("./", "output.json")))
                {
                    outputFile.WriteLine(jsonString);
                }
            }
        }
    }

    public class Invoice
    {
        [Name("Name")]
        public string Name { get; set; }

        [Name("Date")]
        public DateTime EventDate { get; set; }

        [Name("Project")]
        public string Project { get; set; }

        [Name("Category")]
        public string Category { get; set; }

        [Name("Status")]
        public string Status { get; set; }

        [Name("Remarks")]
        public string Remarks { get; set; }
    }
}
