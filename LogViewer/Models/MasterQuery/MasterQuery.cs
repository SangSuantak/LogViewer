using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogViewer.Models.MasterQuery
{
    public class MasterQuery
    {
        public T_FLT_Header Header { get; set; }
        public List<T_FLT_FlightInfo> FlightInfo { get; set; }
        public List<T_FLT_PaxInfo> PaxInfo { get; set; }
        public List<T_FLT_PaxInfoDetail> PaxInfoDetail { get; set; }
        public List<T_FLT_FareInfo> FareInfo { get; set; }
        public List<T_FLT_ChangedFareInfo> ChangedFareInfo { get; set; }
        public List<T_FLT_UserProfile> UserProfile { get; set; }
        public List<T_FLT_PaymentInfo> PaymentInfo { get; set; }
    }
}