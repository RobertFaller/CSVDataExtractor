using CSVDataExtractor.Models;
using System;
using System.Collections.Generic;

namespace CSVDataExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            string DataLocation = "C:\\Users\\rfaller\\Desktop\\TestData.csv";
            
            //check to see if the Data location contains CSV if so then read the columns Dynamically, and then populate the data against these into the DataModel.
            if (DataLocation.Contains(".csv"))
            {

                List<CsvFileDto> Data = new List<CsvFileDto>();

                try
                {
                    Console.WriteLine("Read in the CSV file to an Object");
                    Data = ReadData.GetCsvFileData(DataLocation);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Getting CSV File Failed, please see the following message:");
                    Console.WriteLine(ex);
                }
                //Old Code kept for future reference
                #region OldCode
                //List<CsvColumns> DataCols = new List<CsvColumns>();
                //List<CsvData> Data = new List<CsvData>();
                //try
                //{
                //    Console.WriteLine("Read in the Columns from the CSV file");
                //    DataCols = ReadData.getCSVColumns(DataLocation);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Getting Columns Failed, please see the following message:");
                //    Console.WriteLine(ex);
                //}

                //try
                //{
                //    Console.WriteLine("Read in the Data from the CSV file");
                //    Data = ReadData.getCSVData(DataLocation);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Getting Data Failed, please see the following message:");
                //    Console.WriteLine(ex);
                //}
                #endregion

                try
                {
                    Console.WriteLine("Export the Data to JSON");
                    ExportData.ExportJson(Data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exporting Data Failed, please see the following message:");
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
