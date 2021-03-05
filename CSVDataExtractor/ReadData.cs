using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CSVDataExtractor.Models;
using CsvHelper;
using Newtonsoft.Json;

namespace CSVDataExtractor.Models
{
    public class ReadData
    {
        public static List<CsvFileDto> GetCsvFileData(string CSVFile)
        {
            List<CsvFileDto> CleanData = new List<CsvFileDto>();
            if (File.Exists(CSVFile))
            {
                using (var reader = new StreamReader(CSVFile))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    //string[] headerRow = csv.HeaderRecord;
                    
                    var RawData = csv.GetRecords<CsvRawData>().ToArray();

                    foreach (var d in RawData)
                    {
                        var Data = new CsvFileDto
                        {
                            name = d.name,
                            address = new CsvFileDto.Address
                            {
                                line1 = d.address_line1,
                                line2 = d.address_line2
                            }
                        };
                        CleanData.Add(Data);
                    }
                }
            }
            return CleanData;

        }
        //Old Code below kept, as could be useful to see where my train of thought was going.
        #region OldCode
        //public static List<CsvColumns> getCSVColumns(string CSVFile)
        //{
        //    if (File.Exists(CSVFile))
        //    {
        //        using (var reader = new StreamReader(CSVFile))
        //        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //        {
        //            List<CsvColumns> csvHeaders = new List<CsvColumns>();
        //            csv.Read();
        //            csv.ReadHeader();
        //            string[] headerRow = csv.HeaderRecord;

        //            var count = headerRow.Length;

        //            int i = 1;
        //            foreach (string head in headerRow)
        //            {
        //                var CsvHeader = new CsvColumns
        //                {
        //                    columnID = i,
        //                    columnName = head
        //                };
        //                i++;
        //                csvHeaders.Add(CsvHeader);
        //            }

        //            var test = csvHeaders;

        //            return csvHeaders;

        //        }
        //    }



        //    return null;
        //}

        //public static List<CsvData> getCSVData(string CSVFile)
        //{
        //    if (File.Exists(CSVFile))
        //    {
        //        using (var reader = new StreamReader(CSVFile))
        //        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //        {
        //            List<CsvData> csvDatas = new List<CsvData>();
        //            List<string> test = new List<string>();
        //            string value;
        //            csv.Read();
        //            var data = csv.GetRecords<dynamic>().ToList();
        //            //var dataString = List<String>;
        //            object o = data;
        //            string[] dataty = o.GetType().GetProperties().Select(p => p.Name).ToArray();
        //            //var test8 = JsonConvert.DeserializeObject(data);

        //            int i = 1;
        //            foreach (dynamic d in dataty)
        //            {
        //                var csvData = new CsvData
        //                {
        //                    DataID = i,
        //                    Value = o.GetType().GetProperty(d).GetValue(o, null)
        //                };
        //                i++;
        //                csvDatas.Add(csvData);
        //            }

        //            //while(csv.Read())
        //            //{
        //            //    for(int i = 0; csv.TryGetField<string>(i, out value); i++)
        //            //    {
        //            //        test.Add(value);
        //            //    }
        //            //}
        //            //csv.ReadHeader();
        //            //string[] DataRow = csv.HeaderRecord;

        //            //var count = DataRow.Length;

        //            //int i = 1;
        //            //foreach (string data in DataRow)
        //            //{
        //            //    var csvData = new CsvData
        //            //    {
        //            //        DataID = i,
        //            //        Value = data,
        //            //        ColumnPosition = 
        //            //    };
        //            //    i++;
        //            //    csvDatas.Add(csvData);
        //            //}

        //            var test2 = csvDatas;
        //            var test3 = test;

        //            return csvDatas;

        //        }
        //    }


        //    return null;
        //}
        #endregion
    }
}
