using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogViewer.Models.MasterQuery
{
    public class T_FLT_FareInfo
    {
        public string FLT_FareInfoFK { get; set; }
        public string FLT_HeaderFK { get; set; }
        public string FLT_Header { get; set; }
        public string FLT_PaxInfoFK { get; set; }
        public string TotalFareAmt { get; set; }
        public string BaseFareAmt { get; set; }
        public string TaxAmt { get; set; }
        public string YQAmt { get; set; }
        public string WOAmt { get; set; }
        public string YRAmt { get; set; }
        public string INAmt { get; set; }
        public string ServiceTaxAmt { get; set; }
        public string TXNFeeAmt { get; set; }
        public string ServiceChargeAmt { get; set; }
        public string CommissionAmt { get; set; }
        public string CashBackAmt { get; set; }
        public string TDSPercentage { get; set; }
        public string TDSOn { get; set; }
        public string TDSAmt { get; set; }
        public string CreationDate { get; set; }
        public string UpdationDate { get; set; }
        public string IsDeleted { get; set; }
        public string IATACommission { get; set; }
        public string FareBasis { get; set; }
        public string BreakPoint { get; set; }
        public string ItineraryIdentifier { get; set; }
        public string QAmt { get; set; }
        public string JNAmt { get; set; }
        public string OTAmt { get; set; }
        public string EduCessAmt { get; set; }
        public string HighEduCessAmt { get; set; }
        public string IsRefundable { get; set; }
        public string FareNodes { get; set; }
        public string IsObsoleteFare { get; set; }
        public string YMAmt { get; set; }
        public string TxnCharges { get; set; }
        public string LCCTotalFareAmt { get; set; }
        public string IsTxnFeeIncluded { get; set; }
        public string LCCTotBaseFareAmt { get; set; }
        public string GOFareID { get; set; }
        public string OCAmt { get; set; }
    }
}