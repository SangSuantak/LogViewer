using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogViewer.Models
{
    public class WBSLog
    {
        public string ReferenceId { get; set; }
        public string TransactionName { get; set; }
        public string InputXML { get; set; }
        public string OutputXML { get; set; }
        public DateTime CreationDate { get; set; }
    }
}