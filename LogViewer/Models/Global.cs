using LogViewer.Configuration;
using System.Web;

namespace LogViewer.Models
{
    public class Global
    {
        public static Configuration.Configuration Configuration { get; set; }
        public static void SetValues()
        {
            string _strConfigUrl = HttpContext.Current.Server.MapPath("~/Configuration/Configuration.xml");
            Configuration = ConfigurationReader.ReadConfiguration(_strConfigUrl);
        }
    }
}