using LogViewer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LogViewer.Data
{
    public class WBSLogData
    {
        string _strConnectionString;
        SqlCommand sqlcmd;
        SqlConnection sqlCon;

        public WBSLogData(string ConnectionString)
        {
            _strConnectionString = ConnectionString;            
        }

        public List<WBSLog> GetWBSLog(string ReferenceId)
        {
            List<WBSLog> _lstWBSLog = new List<WBSLog>();
            try
            {
                using (sqlCon = new SqlConnection(_strConnectionString))
                {
                    sqlCon.Open();
                    using (sqlcmd = new SqlCommand())
                    {
                        sqlcmd.Connection = sqlCon;
                        sqlcmd.Parameters.AddWithValue("@FLT_HeaderID", ReferenceId);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "usp_util_FetchTransactionLog";
                        IDataReader dr = sqlcmd.ExecuteReader();
                        WBSLog _obWBSjLog;
                        while (dr.Read())
                        {
                            _obWBSjLog = new WBSLog();
                            _obWBSjLog.ReferenceId = Convert.ToString(dr["FLT_HeaderID"]);
                            _obWBSjLog.TransactionName = Convert.ToString(dr["TrnName"]);
                            _obWBSjLog.InputXML = Convert.ToString(dr["InputXML"]);
                            _obWBSjLog.OutputXML = Convert.ToString(dr["OutputXML"]);
                            _obWBSjLog.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                            _lstWBSLog.Add(_obWBSjLog);
                        }
                    }
                }
                return _lstWBSLog;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}