using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogViewer.Models.Configuration
{
    public class Tabs
    {
        public bool ShowApplicationLogs { get; set; }
        public bool ShowGDSLogs { get; set; }
        public bool ShowLCCLogs { get; set; }
        public bool ShowEncryptionDecryption { get; set; }
    }
}
