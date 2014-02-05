using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogViewer.Models.EncryptDecrypt
{
    public class EncryptedValue
    {
        public string CipherText { get; set; }
        public string Salt { get; set; }
    }
}