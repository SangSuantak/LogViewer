using System;
using System.Collections.Generic;

namespace LogViewer.Models.Configuration
{
    public class Configuration
    {
        public List<Module> Modules { get; set; }
        public Defaults Defaults { get; set; }
        public Tabs Tabs { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}