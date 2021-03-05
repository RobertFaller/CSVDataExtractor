using System;
using System.Collections.Generic;
using System.Text;

namespace CSVDataExtractor.Models
{
    public class CsvFileDto
    {
        public string name { get; set; }
        public Address address { get; set; }
        public class Address
        {
            public string line1 { get; set; }

            public string line2 { get; set; }
        }

        //OLD CODE TO TRY AND MAKE PROCESS FULL DYNAMIC
        #region OldCode
        //public List<CsvColumns> csvColumns { get; set; }
        //public List<CsvData> csvData { get; set; }
        #endregion
    }
}
