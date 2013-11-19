
namespace LogViewer.Models.Configuration
{
    public class Application
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public bool HasWBSLogs { get; set; }
        public ExceptionLogPath ExceptionLogPath { get; set; }
    }
}