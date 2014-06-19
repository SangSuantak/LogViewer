using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogViewer.Models
{
    public class QueryInput
    {
        public DateTime LogDate { get; set; }
        public string LogDateString { get; set; }
        public string ReferenceID { get; set; }
        public string Module { get; set; }
        public string Application { get; set; }

        public string EncrInputText { get; set; }
        public string SaltText { get; set; }

        public string Path { get; set; }
    }
}