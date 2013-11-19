using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogViewer.Models.MasterQuery
{
    public class T_FLT_PaymentInfo
    {
        public string FLT_PaymentDetailPK { get; set; }
        public string FLT_HeaderFK { get; set; }
        public string FLT_Header { get; set; }
        public string PGTypeCode { get; set; }
        public string TrackID { get; set; }
        public string TransactionID { get; set; }
        public string PaymentID { get; set; }
        public string PaymentStatus { get; set; }
        public string SysIP { get; set; }
        public string AmountPaid { get; set; }
        public string CreationDate { get; set; }
        public string UpdationDate { get; set; }
        public string IsDeleted { get; set; }
        public string PGErrorText { get; set; }
        public string PGErrorNo { get; set; }
        public string PayPageUrl { get; set; }
        public string ResponseQueryString { get; set; }
        public string RequestQueryString { get; set; }
        public string TransStatus { get; set; }
        public string VerifyPortalRedirectUrl { get; set; }
        public string VerifyBookConfirmUrl { get; set; }
    }
}