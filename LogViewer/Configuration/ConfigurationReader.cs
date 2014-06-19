using LogViewer.Models;
using LogViewer.Models.Configuration;
using LogViewer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace LogViewer.Configuration
{
    public class ConfigurationReader
    {
        public static LogViewer.Models.Configuration.Configuration ReadConfiguration(string _strPath)
        {            
            LogViewer.Models.Configuration.Configuration _objConfiguration = new LogViewer.Models.Configuration.Configuration();
            
            XmlDocument _xDoc = new XmlDocument();
            _xDoc.Load(_strPath);

            //Get reference to the root element
            XmlNode _xRootNode = _xDoc.DocumentElement;
                        
            #region Default Configurations

            Defaults _objConfigDefaults = new Defaults();
            XmlNode _xDefaults = _xRootNode.SelectSingleNode("Defaults");
            XmlNode _xExceptionLogDefaults = _xDefaults.SelectSingleNode("ExceptionLogPath");
            _objConfigDefaults.ExceptionLogPath = new ExceptionLogPath
            {
                Path = _xExceptionLogDefaults.SelectSingleNode("Path").InnerText,
                Nature = Utility.StringToEnum<Enums.ExceptionLogPathNature>(_xExceptionLogDefaults.SelectSingleNode("Nature").InnerText)
            };
            _objConfigDefaults.ConnectionString = _xDefaults.SelectSingleNode("ConnectionString").InnerText;

            _objConfiguration.Defaults = _objConfigDefaults;

            #endregion

            #region Modules

            XmlNodeList _xModules = _xRootNode.SelectNodes("Modules/Module");
            _objConfiguration.Modules = new List<Module>();
            Module _objModule = null;
            Application _objApplication = null;

            foreach (XmlNode module in _xModules)
            {
                _objModule = new Module();
                _objModule.Name = module.SelectSingleNode("Name").InnerText;

                if (module.SelectSingleNode("IsLCC") != null)
                {
                    _objModule.IsLCC = Convert.ToBoolean(module.SelectSingleNode("IsLCC").InnerText);
                }

                #region Applications

                XmlNodeList _xApplications = module.SelectNodes("Applications/Application");
                _objModule.Applications = new List<Application>();

                foreach (XmlNode app in _xApplications)
                {
                    _objApplication = new Application();

                    //Application Name
                    _objApplication.Name = app.SelectSingleNode("Name").InnerText;

                    #region Connection String

                    if (app.SelectSingleNode("ConnectionString") == null)
                    {
                        _objApplication.ConnectionString = _objConfigDefaults.ConnectionString;
                    }
                    else
                    {
                        _objApplication.ConnectionString = app.SelectSingleNode("ConnectionString").InnerText;
                    } 

                    #endregion

                    _objApplication.HasWBSLogs = Convert.ToBoolean(app.SelectSingleNode("HasWBSLogs").InnerText);

                    #region Exception Log Path

                    XmlNode _xExceptionLogPath = app.SelectSingleNode("ExceptionLogPath");
                    if (_xExceptionLogPath == null)
                    {
                        _objApplication.ExceptionLogPath = _objConfigDefaults.ExceptionLogPath;
                    }
                    else
                    {
                        _objApplication.ExceptionLogPath = new ExceptionLogPath
                        {
                            Path = _xExceptionLogPath.SelectSingleNode("Path").InnerText,
                            Nature = Utility.StringToEnum<Enums.ExceptionLogPathNature>(_xExceptionLogPath.SelectSingleNode("Nature").InnerText)
                        };
                    } 

                    #endregion

                    _objModule.Applications.Add(_objApplication);

                }

                #endregion

                _objConfiguration.Modules.Add(_objModule);
            }
            
            #endregion

            #region Tabs

            Tabs _objTabs = new Tabs();
            XmlNode _xTabs = _xRootNode.SelectSingleNode("Tabs");
            _objTabs.ShowApplicationLogs = Convert.ToBoolean(_xTabs.SelectSingleNode("ShowApplicationLogs").InnerText);
            _objTabs.ShowEncryptionDecryption = Convert.ToBoolean(_xTabs.SelectSingleNode("ShowEncryptionDecryption").InnerText);
            _objTabs.ShowGDSLogs = Convert.ToBoolean(_xTabs.SelectSingleNode("ShowGDSLogs").InnerText);
            _objTabs.ShowLCCLogs = Convert.ToBoolean(_xTabs.SelectSingleNode("ShowLCCLogs").InnerText);

            _objConfiguration.Tabs = _objTabs;

            #endregion

            _objConfiguration.LastModifiedDate = File.GetLastWriteTime(_strPath);

            return _objConfiguration;
        }
    }
}