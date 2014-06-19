using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogViewer.Models;

namespace LogViewer.Models.FileSystem
{
    public class LogFile
    {
        public Enums.DirectoryItemType DirectoryItemType { get; set; }
        public string DirectoryItemName { get; set; }
        public string DirectoryItemPath { get; set; }
        public string DirectoryItemParentPath { get; set; }
    }
}