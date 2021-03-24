using CSVDataExtractor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CSVDataExtractor
{
    public class ExportData
    {
        public static string ExportJson(List<CsvFileDto> Data)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Data,Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine("Application ran successfully Json Result:");
            return json;
        }

    }
}
