using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogViewer.Models.MasterQuery
{
    public class T_FLT_PaxInfo
    {
        public string FLT_PaxInfoPK { get; set; }
        public string FLT_HeaderFK { get; set; }
        public string FLT_Header { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PaxTypeCode { get; set; }
        public string DOB { get; set; }
        public string MealRequest { get; set; }
        public string SeatRequest { get; set; }
        public string IsPrimaryPax { get; set; }
        public string InfantIndicator { get; set; }
        public string FreqFlyerNo { get; set; }
        public string CreationDate { get; set; }
        public string UpdationDate { get; set; }
        public string IsDeleted { get; set; }
        public string FFNAirCode { get; set; }
    }
}