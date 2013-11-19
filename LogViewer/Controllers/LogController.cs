using LogViewer.Data;
using LogViewer.Models;
using LogViewer.Models.MasterQuery;
using LogViewer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogViewer.Controllers
{
    public class LogController : ApiController
    {
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

        [HttpPost]
        public HttpResponseMessage GetWBSLog([FromBody]QueryInput QueryInput)
        {
            try
            {
                string _strConStr = Global.Configuration.Modules.SelectMany(m => m.Applications)
                    .Where(a => a.Name == QueryInput.Application).FirstOrDefault()
                    .ConnectionString;

                WBSLogData _objWBSLogData = new WBSLogData(_strConStr);
                var _lstWBSLog = _objWBSLogData.GetWBSLog(QueryInput.ReferenceID);
                if (_lstWBSLog != null && _lstWBSLog.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                    new { WBSLog = _objWBSLogData.GetWBSLog(QueryInput.ReferenceID) });
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

        public HttpResponseMessage GetMasterQueryData(QueryInput QueryInput)
        {
            try
            {

                string _strConStr = Global.Configuration.Modules.SelectMany(m => m.Applications)
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

        [HttpGet]
        public HttpResponseMessage GetMasterData()
        {
            var _lstModules = Global.Configuration.Modules.Select(m => new { Name = m.Name, Applications = m.Applications.Select(a => a.Name) });

            return Request.CreateResponse(HttpStatusCode.OK,
                new { Modules = _lstModules });
        }

        [HttpGet]
        public HttpResponseMessage GetWBSApplications()
        {
            var _lstApplications = Global.Configuration.Modules
                .SelectMany(m => m.Applications)
                .Where(a => a.HasWBSLogs)
                .Select(a => a.Name);

            return Request.CreateResponse(HttpStatusCode.OK,
                new { Applications = _lstApplications });
        }
    }
}
