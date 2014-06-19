using LogViewer.Configuration;
using System;
using System.IO;
using System.Web;

namespace LogViewer.Models
{
    public class Global
    {
        public static Configuration.Configuration Configuration { get; set; }
        public static Configuration.Configuration GetGlobalValues()
        {
            string _strConfigUrl = HttpContext.Current.Server.MapPath("~/Configuration/Configuration.xml");

            if (Configuration == null)
            {
                Configuration = ConfigurationReader.ReadConfiguration(_strConfigUrl);                
            }
            else
            {
                //Referesh data only if last modified date has changed
                DateTime _dtLastModifiedDate = File.GetLastWriteTime(_strConfigUrl);
                if (_dtLastModifiedDate.CompareTo(Configuration.LastModifiedDate) != 0)
                {
                    Configuration = ConfigurationReader.ReadConfiguration(_strConfigUrl);
                }                
            }
            return Configuration;
        }
    }
}