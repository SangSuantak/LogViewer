using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogViewer.Models;
using System.IO;
using System.Text;

namespace LogViewer.Data
{
    public class ApplicationLogData
    {

        QueryInput QueryInput;

        public ApplicationLogData(QueryInput QInput)
        {
            this.QueryInput = QInput;
        }

        public string GetApplicationLog()
        {
            string _strLog = string.Empty;
            try
            {
                string _strLogPath = string.Empty,
                    _strFileName = QueryInput.LogDate.ToString("dd-MMM-yyyy") + ".txt";

                Enums.ExceptionLogPathNature _eExLogPathNature = Enums.ExceptionLogPathNature.Absolute;                
                var _matchedApp = Global.GetGlobalValues().Modules
                    .Where(m => m.Name == QueryInput.Module)
                    .Select(m => new { Application = m.Applications.Where(a => a.Name == QueryInput.Application).First() })
                    .FirstOrDefault();

                _strLogPath = _matchedApp.Application.ExceptionLogPath.Path;
                _eExLogPathNature = _matchedApp.Application.ExceptionLogPath.Nature;

                if (_eExLogPathNature == Enums.ExceptionLogPathNature.Relative)
                {                    
                    _strLogPath = Directory.GetParent(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath).Parent.FullName 
                        + "/" + QueryInput.Application + "/" + _strLogPath;
                }

                _strLogPath += "/" + _strFileName;

                if (File.Exists(_strLogPath))
                {
                    string[] _arrLog = File.ReadAllLines(_strLogPath);
                    //_strLog = string.Join("<br />", _arrLog);
                    _strLog = string.Join("ƀ", _arrLog).Replace("<br/>", "ƀ");
                    //_strLog = File.ReadAllText(_strLogPath);
                }
                else
                {
                    _strLog = "No Log found for the selected Date";
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            return _strLog;
        }
    }
}