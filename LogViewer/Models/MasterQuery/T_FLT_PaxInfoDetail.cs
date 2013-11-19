using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogViewer.Models.MasterQuery
{
    public class T_FLT_PaxInfoDetail
    {
        public string FLT_PaxInfoDetailPK { get; set; }
        public string FLT_PaxInfoFK { get; set; }
        public string FLT_HeaderFK { get; set; }
        public string FLT_FlightInfoFK { get; set; }
        public string FLT_Header { get; set; }
        public string AirCode { get; set; }
        public string TicketNo { get; set; }
        public string ItineraryIdentifier { get; set; }
        public string CreationDate { get; set; }
        public string UpdationDate { get; set; }
        public string IsDeleted { get; set; }
        public string BaggageType { get; set; }
        public string BaggageMeasureUnit { get; set; }
        public string BaggageWeight { get; set; }
    }
}