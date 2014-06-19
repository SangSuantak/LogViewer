using LogViewer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LogViewer.Data
{
    public class GDSLogData
    {
        string _strConnectionString;
        SqlCommand sqlcmd;
        SqlConnection sqlCon;

        public GDSLogData(string ConnectionString)
        {
            _strConnectionString = ConnectionString;            
        }

        public List<GDSLog> GetWBSLog(string ReferenceId)
        {
            List<GDSLog> _lstWBSLog = new List<GDSLog>();
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
                        GDSLog _obWBSjLog;
                        while (dr.Read())
                        {
                            _obWBSjLog = new GDSLog();
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