using System.Collections.Generic;

namespace LogViewer.Models.Configuration
{
    public class Module
    {
        public string Name { get; set; }
        public List<Application> Applications { get; set; }
    }
}