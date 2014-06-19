using LogViewer.Data;
using LogViewer.Models;
using LogViewer.Models.MasterQuery;
using LogViewer.Models.EncryptDecrypt;
using LogViewer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogViewer.Models.FileSystem;

namespace LogViewer.Controllers
{
    public class LogController : ApiController
    {
        #region Read the configuration settings
        
        [HttpGet]
        public HttpResponseMessage GetMasterData()
        {
            var _lstModules = Global.GetGlobalValues().Modules
                .Where(m => !m.IsLCC)
                .Select(m => new { Name = m.Name, Applications = m.Applications.Select(a => a.Name) });

            return Request.CreateResponse(HttpStatusCode.OK,
                new { Modules = _lstModules });
        } 

        #endregion

        #region Read Tab Configuration

        [HttpGet]
        public HttpResponseMessage GetTabConfiguration()
        {
            var _tabs = Global.GetGlobalValues().Tabs;

            return Request.CreateResponse(HttpStatusCode.OK,
                new { Tabs = _tabs });
        }
        
        #endregion

        #region Application Log

        /// <summary>
        /// Making the method HttpPost is necessary to receive the form search input
        /// </summary>
        /// <param name="QueryInput"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetApplicationLog([FromBody]QueryInput QueryInput)
        {
            try
            {
                DateTime _dtLogDate;
                bool _bIsValidDate = DateTime.TryParse(QueryInput.LogDateString, out _dtLogDate);
                if (_bIsValidDate)
                {
                    QueryInput.LogDate = _dtLogDate;
                    ApplicationLogData _objAppLog = new ApplicationLogData(QueryInput);
                    return Request.CreateResponse(HttpStatusCode.OK,
                    new { Log = _objAppLog.GetApplicationLog() });
                }
                else
                {
                    throw new FormatException("Date is not in the correct format");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                new { Log = e.Message });
            }
        } 
        
        #endregion
        
        #region GDS Log

        [HttpGet]
        public HttpResponseMessage GetWBSApplications()
        {
            var _lstApplications = Global.GetGlobalValues().Modules
                .SelectMany(m => m.Applications)
                .Where(a => a.HasWBSLogs)
                .Select(a => a.Name);

            return Request.CreateResponse(HttpStatusCode.OK,
                new { Applications = _lstApplications });
        }

        [HttpPost]
        public HttpResponseMessage GetGDSLog([FromBody]QueryInput QueryInput)
        {
            try
            {
                string _strConStr = Global.GetGlobalValues().Modules.SelectMany(m => m.Applications)
                    .Where(a => a.Name == QueryInput.Application).FirstOrDefault()
                    .ConnectionString;

                GDSLogData _objGDSLogData = new GDSLogData(_strConStr);
                var _lstGDSLog = _objGDSLogData.GetWBSLog(QueryInput.ReferenceID);
                if (_lstGDSLog != null && _lstGDSLog.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                    new { GDSLog = _objGDSLogData.GetWBSLog(QueryInput.ReferenceID) });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                    new { Error = "No log found for the given Reference ID" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                new { Error = e.Message });
            }
        } 
        
        #endregion

        #region Master Query to Read All Table Values - WIP
        
        public HttpResponseMessage GetMasterQueryData(QueryInput QueryInput)
        {
            try
            {

                string _strConStr = Global.GetGlobalValues().Modules.SelectMany(m => m.Applications)
                        .Where(a => a.Name == QueryInput.Application).FirstOrDefault()
                        .ConnectionString;

                MasterQueryData _objMasterQueryData = new MasterQueryData(_strConStr);
                MasterQuery _objMasterQuery = _objMasterQueryData.GetMasterQueryData(QueryInput.ReferenceID);

                if (_objMasterQuery != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new { MasterQueryData = _objMasterQuery });
                }
                else
                {
                    throw new Exception("No data found for the query");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                new { Error = e.Message });
            }
        } 
        
        #endregion
                               
        #region Encrypt/Decrypt
        
        [HttpPost]
        public HttpResponseMessage EncryptPlainText([FromBody]QueryInput QueryInput)
        {
            try
            {
                string _strSalt = Utility.GenerateSalt();
                string _strCipherText = EncryptDecrypt.Encrypt(QueryInput.EncrInputText, _strSalt);

                EncryptedValue _objEncrValue = new EncryptedValue
                {
                    CipherText = _strCipherText,
                    Salt = _strSalt
                };

                if (_objEncrValue != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new { EncryptedValue = _objEncrValue });
                }
                else
                {
                    throw new Exception("Encryption Failed");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                new { Error = e.Message });
            }
        }

        [HttpPost]
        public HttpResponseMessage DecryptText([FromBody]QueryInput QueryInput)
        {
            try
            {
                string _strDecryptedValue = EncryptDecrypt.Decrypt(QueryInput.EncrInputText, QueryInput.SaltText);

                if (!string.IsNullOrWhiteSpace(_strDecryptedValue))
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new { DecryptedValue = _strDecryptedValue });
                }
                else
                {
                    throw new Exception("Decryption Failed");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                new { Error = e.Message });
            }
        }

        [HttpPost]
        public HttpResponseMessage EncryptXML([FromBody]QueryInput QueryInput)
        {
            try
            {
                EncryptedValue _objEncrValue = EncryptDecrypt.EncryptDecryptConfigXML(true, QueryInput.EncrInputText);

                if (_objEncrValue != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new { EncryptedValue = _objEncrValue });
                }
                else
                {
                    throw new Exception("Encryption Failed");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                new { Error = e.Message });
            }
        }

        [HttpPost]
        public HttpResponseMessage DecryptXML([FromBody]QueryInput QueryInput)
        {
            try
            {
                string _strSalt = QueryInput.SaltText ?? Utility.GenerateSalt();
                string _strCipherText = EncryptDecrypt.Encrypt(QueryInput.EncrInputText, _strSalt);

                EncryptedValue _objEncrValue = EncryptDecrypt.EncryptDecryptConfigXML(false, QueryInput.EncrInputText);

                if (_objEncrValue != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new { EncryptedValue = _objEncrValue });
                }
                else
                {
                    throw new Exception("Encryption Failed");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                new { Error = e.Message });
            }
        }

        #endregion                

        #region LCC Logs

        [HttpGet]
        public HttpResponseMessage GetMasterDataForLCC()
        {
            var _lstModules = Global.GetGlobalValues().Modules
                .Where(m => m.IsLCC)
                .Select(m => new { Name = m.Name, Applications = m.Applications.Select(a => a.Name) });

            return Request.CreateResponse(HttpStatusCode.OK,
                new { Modules = _lstModules });
        }

        /// <summary>
        /// Read directory information
        /// </summary>
        /// <param name="QueryInput"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetLCCLogDirectory([FromBody]QueryInput QueryInput)
        {
            LCCLogData _objLCCLogData = new LCCLogData(QueryInput);

            return Request.CreateResponse(HttpStatusCode.OK,
                new { LCCLog = _objLCCLogData.GetLCCDirectoryList() });
        }

        /// <summary>
        /// Read file content
        /// </summary>
        /// <param name="QueryInput"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetLCCLogFileContent([FromBody]QueryInput QueryInput)
        {
            LCCLogData _objLCCLogData = new LCCLogData(QueryInput);

            return Request.CreateResponse(HttpStatusCode.OK,
                new { LogContent = _objLCCLogData.GetLCCFileContent() });
        } 

        #endregion

    }
}
