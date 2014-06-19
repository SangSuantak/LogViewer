using LogViewer.Models;
using LogViewer.Models.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LogViewer.Data
{
    public class LCCLogData
    {
        QueryInput QueryInput;

        public LCCLogData(QueryInput QInput)
        {
            this.QueryInput = QInput;
        }

        public List<LogFile> GetLCCDirectoryList()
        {
            var _lstLogFiles = new List<LogFile>();
            try
            {
                bool _bAddRootDirectory = false;

                string _strDir = QueryInput.Path,
                    _strSearchOption = QueryInput.ReferenceID;

                //This will be called when the View button is clicked
                if (string.IsNullOrWhiteSpace(_strDir))
                {
                    var _matchedApp = Global.GetGlobalValues().Modules
                        .Where(m => m.Name == QueryInput.Module)
                        .Select(m => new { Application = m.Applications.Where(a => a.Name == QueryInput.Application).First() })
                        .FirstOrDefault();

                    _strDir = _matchedApp.Application.ExceptionLogPath.Path;
                    Enums.ExceptionLogPathNature _eExLogPathNature = _matchedApp.Application.ExceptionLogPath.Nature;

                    if (_eExLogPathNature == Enums.ExceptionLogPathNature.Relative)
                    {
                        _strDir = Directory.GetParent(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath).Parent.FullName
                            + "/" + QueryInput.Application + "/" + _strDir;
                    }

                    _bAddRootDirectory = true;                                        
                }

                if (Directory.Exists(_strDir))
                {

                    DirectoryInfo _objDirInfo = new DirectoryInfo(_strDir);

                    IEnumerable<DirectoryInfo> _folders = null;
                    if (string.IsNullOrWhiteSpace(_strSearchOption))
                    {
                        _folders = _objDirInfo.EnumerateDirectories();
                    }
                    else
                    {
                        _folders = _objDirInfo.EnumerateDirectories("*" + _strSearchOption + "*", SearchOption.AllDirectories);
                    }
                    var _files = _objDirInfo.EnumerateFiles();

                    if (_folders.Count() > 0 || _files.Count() > 0)
                    {
                        if (_bAddRootDirectory)
                        {
                            _lstLogFiles.Add(new LogFile
                            {
                                DirectoryItemType = Enums.DirectoryItemType.Folder,
                                DirectoryItemName = " ",
                                DirectoryItemPath = _strDir,
                                DirectoryItemParentPath = _strDir
                            });
                        }

                        //parse all folders
                        if (_folders.Count() > 0)
                        {
                            _folders = _folders.OrderByDescending(f => f.LastWriteTime);
                            foreach (DirectoryInfo _objDirectory in _folders)
                            {
                                _lstLogFiles.Add(new LogFile
                                {
                                    DirectoryItemType = Enums.DirectoryItemType.Folder,
                                    DirectoryItemName = _objDirectory.Name.Trim(),
                                    DirectoryItemPath = _objDirectory.FullName.Trim(),
                                    DirectoryItemParentPath = _objDirectory.Parent.FullName.Trim()
                                });
                            }
                        }

                        //parse all files
                        if (_files.Count() > 0)
                        {
                            _files = _files.OrderByDescending(f => f.LastWriteTime);
                            foreach (FileInfo _objFile in _files)
                            {
                                _lstLogFiles.Add(new LogFile
                                {
                                    DirectoryItemType = Enums.DirectoryItemType.File,
                                    DirectoryItemName = _objFile.Name.Trim(),
                                    DirectoryItemPath = _objFile.FullName.Trim(),
                                    DirectoryItemParentPath = _objFile.DirectoryName.Trim()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _lstLogFiles;
        }

        public string GetLCCFileContent()
        {
            string _strFileContent = string.Empty;
            try
            {
                string _strDir = @QueryInput.Path;

                if (File.Exists(_strDir))
                {
                    _strFileContent = File.ReadAllText(_strDir);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _strFileContent;
        }
    }
}