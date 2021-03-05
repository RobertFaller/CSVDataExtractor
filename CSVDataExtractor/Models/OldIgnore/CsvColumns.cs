using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSVDataExtractor.Models
{
    public class CsvColumns
    {
        [Key]
        public int columnID { get; set; }

        public string columnName { get; set; }
    }
}
