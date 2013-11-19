
namespace LogViewer.Models
{
    public static class Enums
    {
        public enum TransactionName
        {
            None = 0,
            MasterPricerSearch = 1,
            SellSegments = 2,
            PnrAddMultipleElement = 3,
            PnrPricing = 4,
            CreateTST = 5,
            SignIn = 6,
            SignOut = 7,
            SavePnrMendatory = 8,
            IgnoreTransaction = 9,
            PaymentDone = 10,
            PaymentFailure = 11,
            PnrRetrieve = 13,
            TicketingDocIssuance = 12,
            DisplayTST = 14,
            AddOptionalPnrElement = 15,
            SavePnrAfterOptionalElement = 16,
            PnrRetrieveFinal = 17,
            Sellability = 18,
            InformativePricing = 19,
            CheckFareRule = 20,
            CrypticTTK = 21
        }

        public enum ExceptionLogPathNature
        {
            Absolute,
            Relative
        }

    }
}