using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogViewer.Models.MasterQuery
{
    public class T_FLT_Header
    {
        public string FLT_HeaderPK { get; set; }
        public string FLT_HeaderID { get; set; }
        public string JourneyTypeCode { get; set; }
        public string RequestTypeCode { get; set; }
        public string TripTypeCode { get; set; }
        public string GDSPNR { get; set; }
        public string TotalBookingAmount { get; set; }
        public string NumAdult { get; set; }
        public string NumChild { get; set; }
        public string NumInfant { get; set; }
        public string ValidatingCarrier { get; set; }
        public string BookingStatus { get; set; }
        public string PNRStatus { get; set; }
        public string CorporateCode { get; set; }
        public string PNRLockStatus { get; set; }
        public string CreationDate { get; set; }
        public string UpdationDate { get; set; }
        public string IsDeleted { get; set; }
        public string PNRBookUserID { get; set; }
        public string FQPnr { get; set; }
        public string IsLTC { get; set; }
        public string InfantIndicator { get; set; }
        public string BookingType { get; set; }
        public string SpecialTripCode { get; set; }
        public string CabinClass { get; set; }
    }
}