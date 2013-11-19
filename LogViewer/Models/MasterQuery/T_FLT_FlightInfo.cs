using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogViewer.Models.MasterQuery
{
    public class T_FLT_FlightInfo
    {
        public string FLT_InfoPK { get; set; }
        public string FLT_HeaderFK { get; set; }
        public string FLT_Header { get; set; }
        public string SectorRef { get; set; }
        public string AirlineCode { get; set; }
        public string AirlineName { get; set; }
        public string FlightNo { get; set; }
        public string DepCityCode { get; set; }
        public string ArrCityCode { get; set; }
        public string DepAirportName { get; set; }
        public string ArrAirportName { get; set; }
        public string DepTerminal { get; set; }
        public string ArrTerminal { get; set; }
        public string DepDate { get; set; }
        public string ArrDate { get; set; }
        public string DepTime { get; set; }
        public string ArrTime { get; set; }
        public string BookingDate { get; set; }
        public string ServiceClass { get; set; }
        public string Cabin { get; set; }
        public string Equipment { get; set; }
        public string AvailabilityStatus { get; set; }
        public string CreationDate { get; set; }
        public string UpdationDate { get; set; }
        public string IsDeleted { get; set; }
        public string Duration { get; set; }
        public string AirlinePNR { get; set; }
        public string ItineraryIdentifier { get; set; }
        public string FareBasis { get; set; }
        public string BreakPoint { get; set; }
        public string OperatingCarrierCode { get; set; }
        public string OperatingCarrierName { get; set; }
        public string ValidatingCarrierCode { get; set; }
        public string GOSecurityGUID { get; set; }
        public string FareType { get; set; }
    }
}