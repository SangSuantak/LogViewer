using LogViewer.Models.MasterQuery;
using LogViewer.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LogViewer.Data
{
    public class MasterQueryData
    {
        string _strConnectionString;
        SqlCommand sqlcmd;
        SqlConnection sqlCon;

        public MasterQueryData(string ConnectionString)
        {
            _strConnectionString = ConnectionString;            
        }

        public MasterQuery GetMasterQueryData(string ReferenceId)
        {
            MasterQuery objMasterQuery = null;
            try
            {
                using (sqlCon = new SqlConnection(_strConnectionString))
                {
                    sqlCon.Open();
                    using (sqlcmd = new SqlCommand())
                    {
                        sqlcmd.Connection = sqlCon;
                        sqlcmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "usp_util_FetchMasterQuery";

                        int intTableIndex = 0;
                        objMasterQuery = new MasterQuery();
                        objMasterQuery.FlightInfo = new List<T_FLT_FlightInfo>();
                        objMasterQuery.PaxInfo = new List<T_FLT_PaxInfo>();
                        objMasterQuery.PaxInfoDetail = new List<T_FLT_PaxInfoDetail>();
                        objMasterQuery.FareInfo = new List<T_FLT_FareInfo>();
                        objMasterQuery.ChangedFareInfo = new List<T_FLT_ChangedFareInfo>();
                        objMasterQuery.UserProfile = new List<T_FLT_UserProfile>();
                        objMasterQuery.PaymentInfo = new List<T_FLT_PaymentInfo>();

                        using (IDataReader dr = sqlcmd.ExecuteReader())
                        {
                            do
                            {
                                while (dr.Read())
                                {
                                    switch (intTableIndex)
                                    {
                                        case 0:
                                            #region Header
                                            objMasterQuery.Header = new T_FLT_Header
                                            {
                                                FLT_HeaderPK = Utility.IsStringNullOrEmpty(dr["FLT_HeaderPK"]),
                                                FLT_HeaderID = Utility.IsStringNullOrEmpty(dr["FLT_HeaderID"]),
                                                JourneyTypeCode = Utility.IsStringNullOrEmpty(dr["JourneyTypeCode"]),
                                                RequestTypeCode = Utility.IsStringNullOrEmpty(dr["RequestTypeCode"]),
                                                TripTypeCode = Utility.IsStringNullOrEmpty(dr["TripTypeCode"]),
                                                GDSPNR = Utility.IsStringNullOrEmpty(dr["GDSPNR"]),
                                                TotalBookingAmount = Utility.IsStringNullOrEmpty(dr["TotalBookingAmount"]),
                                                NumAdult = Utility.IsStringNullOrEmpty(dr["NumAdult"]),
                                                NumChild = Utility.IsStringNullOrEmpty(dr["NumChild"]),
                                                NumInfant = Utility.IsStringNullOrEmpty(dr["NumInfant"]),
                                                ValidatingCarrier = Utility.IsStringNullOrEmpty(dr["ValidatingCarrier"]),
                                                BookingStatus = Utility.IsStringNullOrEmpty(dr["BookingStatus"]),
                                                PNRStatus = Utility.IsStringNullOrEmpty(dr["PNRStatus"]),
                                                CorporateCode = Utility.IsStringNullOrEmpty(dr["CorporateCode"]),
                                                PNRLockStatus = Utility.IsStringNullOrEmpty(dr["PNRLockStatus"]),
                                                CreationDate = Utility.IsStringNullOrEmpty(dr["CreationDate"]),
                                                UpdationDate = Utility.IsStringNullOrEmpty(dr["UpdationDate"]),
                                                IsDeleted = Utility.IsStringNullOrEmpty(dr["IsDeleted"]),
                                                PNRBookUserID = Utility.IsStringNullOrEmpty(dr["PNRBookUserID"]),
                                                FQPnr = Utility.IsStringNullOrEmpty(dr["FQPnr"]),
                                                IsLTC = Utility.IsStringNullOrEmpty(dr["IsLTC"]),
                                                InfantIndicator = Utility.IsStringNullOrEmpty(dr["InfantIndicator"]),
                                                BookingType = Utility.IsStringNullOrEmpty(dr["BookingType"]),
                                                SpecialTripCode = Utility.IsStringNullOrEmpty(dr["SpecialTripCode"]),
                                                CabinClass = Utility.IsStringNullOrEmpty(dr["CabinClass"])
                                            };
                                            break;
                                            #endregion
                                        case 1:
                                            #region Flight Info
                                            objMasterQuery.FlightInfo.Add(new T_FLT_FlightInfo
                                            {
                                                FLT_InfoPK = Utility.IsStringNullOrEmpty(dr["FLT_InfoPK"]),
                                                FLT_HeaderFK = Utility.IsStringNullOrEmpty(dr["FLT_HeaderFK"]),
                                                FLT_Header = Utility.IsStringNullOrEmpty(dr["FLT_Header"]),
                                                SectorRef = Utility.IsStringNullOrEmpty(dr["SectorRef"]),
                                                AirlineCode = Utility.IsStringNullOrEmpty(dr["AirlineCode"]),
                                                AirlineName = Utility.IsStringNullOrEmpty(dr["AirlineName"]),
                                                FlightNo = Utility.IsStringNullOrEmpty(dr["FlightNo"]),
                                                DepCityCode = Utility.IsStringNullOrEmpty(dr["DepCityCode"]),
                                                ArrCityCode = Utility.IsStringNullOrEmpty(dr["ArrCityCode"]),
                                                DepAirportName = Utility.IsStringNullOrEmpty(dr["DepAirportName"]),
                                                ArrAirportName = Utility.IsStringNullOrEmpty(dr["ArrAirportName"]),
                                                DepTerminal = Utility.IsStringNullOrEmpty(dr["DepTerminal"]),
                                                ArrTerminal = Utility.IsStringNullOrEmpty(dr["ArrTerminal"]),
                                                DepDate = Utility.IsStringNullOrEmpty(dr["DepDate"]),
                                                ArrDate = Utility.IsStringNullOrEmpty(dr["ArrDate"]),
                                                DepTime = Utility.IsStringNullOrEmpty(dr["DepTime"]),
                                                ArrTime = Utility.IsStringNullOrEmpty(dr["ArrTime"]),
                                                BookingDate = Utility.IsStringNullOrEmpty(dr["BookingDate"]),
                                                ServiceClass = Utility.IsStringNullOrEmpty(dr["ServiceClass"]),
                                                Cabin = Utility.IsStringNullOrEmpty(dr["Cabin"]),
                                                Equipment = Utility.IsStringNullOrEmpty(dr["Equipment"]),
                                                AvailabilityStatus = Utility.IsStringNullOrEmpty(dr["AvailabilityStatus"]),
                                                CreationDate = Utility.IsStringNullOrEmpty(dr["CreationDate"]),
                                                UpdationDate = Utility.IsStringNullOrEmpty(dr["UpdationDate"]),
                                                IsDeleted = Utility.IsStringNullOrEmpty(dr["IsDeleted"]),
                                                Duration = Utility.IsStringNullOrEmpty(dr["Duration"]),
                                                AirlinePNR = Utility.IsStringNullOrEmpty(dr["AirlinePNR"]),
                                                ItineraryIdentifier = Utility.IsStringNullOrEmpty(dr["ItineraryIdentifier"]),
                                                FareBasis = Utility.IsStringNullOrEmpty(dr["FareBasis"]),
                                                BreakPoint = Utility.IsStringNullOrEmpty(dr["BreakPoint"]),
                                                OperatingCarrierCode = Utility.IsStringNullOrEmpty(dr["OperatingCarrierCode"]),
                                                OperatingCarrierName = Utility.IsStringNullOrEmpty(dr["OperatingCarrierName"])
                                            });
                                            break;
                                            #endregion
                                        case 2:
                                            #region PaxInfo
                                            objMasterQuery.PaxInfo.Add(new T_FLT_PaxInfo
                                            {
                                                FLT_PaxInfoPK = Utility.IsStringNullOrEmpty(dr["FLT_PaxInfoPK"]),
                                                FLT_HeaderFK = Utility.IsStringNullOrEmpty(dr["FLT_HeaderFK"]),
                                                FLT_Header = Utility.IsStringNullOrEmpty(dr["FLT_Header"]),
                                                Title = Utility.IsStringNullOrEmpty(dr["Title"]),
                                                FirstName = Utility.IsStringNullOrEmpty(dr["FirstName"]),
                                                MiddleName = Utility.IsStringNullOrEmpty(dr["MiddleName"]),
                                                LastName = Utility.IsStringNullOrEmpty(dr["LastName"]),
                                                PaxTypeCode = Utility.IsStringNullOrEmpty(dr["PaxTypeCode"]),
                                                DOB = Utility.IsStringNullOrEmpty(dr["DOB"]),
                                                MealRequest = Utility.IsStringNullOrEmpty(dr["MealRequest"]),
                                                SeatRequest = Utility.IsStringNullOrEmpty(dr["SeatRequest"]),
                                                IsPrimaryPax = Utility.IsStringNullOrEmpty(dr["IsPrimaryPax"]),
                                                InfantIndicator = Utility.IsStringNullOrEmpty(dr["InfantIndicator"]),
                                                FreqFlyerNo = Utility.IsStringNullOrEmpty(dr["FreqFlyerNo"]),
                                                CreationDate = Utility.IsStringNullOrEmpty(dr["CreationDate"]),
                                                UpdationDate = Utility.IsStringNullOrEmpty(dr["UpdationDate"]),
                                                IsDeleted = Utility.IsStringNullOrEmpty(dr["IsDeleted"]),
                                                FFNAirCode = Utility.IsStringNullOrEmpty(dr["FFNAirCode"])
                                            });
                                            break;
                                            #endregion
                                        case 3:
                                            #region PaxInfo Detail
                                            objMasterQuery.PaxInfoDetail.Add(new T_FLT_PaxInfoDetail
                                            {
                                                FLT_PaxInfoDetailPK = Utility.IsStringNullOrEmpty(dr["FLT_PaxInfoDetailPK"]),
                                                FLT_PaxInfoFK = Utility.IsStringNullOrEmpty(dr["FLT_PaxInfoFK"]),
                                                FLT_HeaderFK = Utility.IsStringNullOrEmpty(dr["FLT_HeaderFK"]),
                                                FLT_FlightInfoFK = Utility.IsStringNullOrEmpty(dr["FLT_FlightInfoFK"]),
                                                FLT_Header = Utility.IsStringNullOrEmpty(dr["FLT_Header"]),
                                                AirCode = Utility.IsStringNullOrEmpty(dr["AirCode"]),
                                                TicketNo = Utility.IsStringNullOrEmpty(dr["TicketNo"]),
                                                ItineraryIdentifier = Utility.IsStringNullOrEmpty(dr["ItineraryIdentifier"]),
                                                CreationDate = Utility.IsStringNullOrEmpty(dr["CreationDate"]),
                                                UpdationDate = Utility.IsStringNullOrEmpty(dr["UpdationDate"]),
                                                IsDeleted = Utility.IsStringNullOrEmpty(dr["IsDeleted"]),
                                                BaggageType = Utility.IsStringNullOrEmpty(dr["BaggageType"]),
                                                BaggageMeasureUnit = Utility.IsStringNullOrEmpty(dr["BaggageMeasureUnit"]),
                                                BaggageWeight = Utility.IsStringNullOrEmpty(dr["BaggageWeight"])
                                            });
                                            break;
                                            #endregion
                                        case 4:
                                            #region Fare Info
                                            objMasterQuery.FareInfo.Add(new T_FLT_FareInfo
                                            {
                                                FLT_FareInfoFK = Utility.IsStringNullOrEmpty(dr["FLT_FareInfoFK"]),
                                                FLT_HeaderFK = Utility.IsStringNullOrEmpty(dr["FLT_HeaderFK"]),
                                                FLT_Header = Utility.IsStringNullOrEmpty(dr["FLT_Header"]),
                                                FLT_PaxInfoFK = Utility.IsStringNullOrEmpty(dr["FLT_PaxInfoFK"]),
                                                TotalFareAmt = Utility.IsStringNullOrEmpty(dr["TotalFareAmt"]),
                                                BaseFareAmt = Utility.IsStringNullOrEmpty(dr["BaseFareAmt"]),
                                                TaxAmt = Utility.IsStringNullOrEmpty(dr["TaxAmt"]),
                                                YQAmt = Utility.IsStringNullOrEmpty(dr["YQAmt"]),
                                                WOAmt = Utility.IsStringNullOrEmpty(dr["WOAmt"]),
                                                YRAmt = Utility.IsStringNullOrEmpty(dr["YRAmt"]),
                                                INAmt = Utility.IsStringNullOrEmpty(dr["INAmt"]),
                                                ServiceTaxAmt = Utility.IsStringNullOrEmpty(dr["ServiceTaxAmt"]),
                                                TXNFeeAmt = Utility.IsStringNullOrEmpty(dr["TXNFeeAmt"]),
                                                ServiceChargeAmt = Utility.IsStringNullOrEmpty(dr["ServiceChargeAmt"]),
                                                CommissionAmt = Utility.IsStringNullOrEmpty(dr["CommissionAmt"]),
                                                CashBackAmt = Utility.IsStringNullOrEmpty(dr["CashBackAmt"]),
                                                TDSPercentage = Utility.IsStringNullOrEmpty(dr["TDSPercentage"]),
                                                TDSOn = Utility.IsStringNullOrEmpty(dr["TDSOn"]),
                                                TDSAmt = Utility.IsStringNullOrEmpty(dr["TDSAmt"]),
                                                CreationDate = Utility.IsStringNullOrEmpty(dr["CreationDate"]),
                                                UpdationDate = Utility.IsStringNullOrEmpty(dr["UpdationDate"]),
                                                IsDeleted = Utility.IsStringNullOrEmpty(dr["IsDeleted"]),
                                                IATACommission = Utility.IsStringNullOrEmpty(dr["IATACommission"]),
                                                FareBasis = Utility.IsStringNullOrEmpty(dr["FareBasis"]),
                                                BreakPoint = Utility.IsStringNullOrEmpty(dr["BreakPoint"]),
                                                ItineraryIdentifier = Utility.IsStringNullOrEmpty(dr["ItineraryIdentifier"]),
                                                QAmt = Utility.IsStringNullOrEmpty(dr["QAmt"]),
                                                JNAmt = Utility.IsStringNullOrEmpty(dr["JNAmt"]),
                                                OTAmt = Utility.IsStringNullOrEmpty(dr["OTAmt"]),
                                                EduCessAmt = Utility.IsStringNullOrEmpty(dr["EduCessAmt"]),
                                                HighEduCessAmt = Utility.IsStringNullOrEmpty(dr["HighEduCessAmt"]),
                                                IsRefundable = Utility.IsStringNullOrEmpty(dr["IsRefundable"]),
                                                FareNodes = Utility.IsStringNullOrEmpty(dr["FareNodes"]),
                                                IsObsoleteFare = Utility.IsStringNullOrEmpty(dr["IsObsoleteFare"]),
                                                YMAmt = Utility.IsStringNullOrEmpty(dr["YMAmt"]),
                                                TxnCharges = Utility.IsStringNullOrEmpty(dr["TxnCharges"]),
                                                LCCTotalFareAmt = Utility.IsStringNullOrEmpty(dr["LCCTotalFareAmt"]),
                                                IsTxnFeeIncluded = Utility.IsStringNullOrEmpty(dr["IsTxnFeeIncluded"]),
                                                LCCTotBaseFareAmt = Utility.IsStringNullOrEmpty(dr["LCCTotBaseFareAmt"]),
                                                GOFareID = Utility.IsStringNullOrEmpty(dr["GOFareID"]),
                                                OCAmt = Utility.IsStringNullOrEmpty(dr["OCAmt"])
                                            });
                                            break;
                                            #endregion
                                        case 5:
                                            #region Changed Fare Info
                                            objMasterQuery.ChangedFareInfo.Add(new T_FLT_ChangedFareInfo
                                            {
                                                FLT_ChangedFareInfoFK = Utility.IsStringNullOrEmpty(dr["FLT_ChangedFareInfoFK"]),
                                                FLT_HeaderFK = Utility.IsStringNullOrEmpty(dr["FLT_HeaderFK"]),
                                                FLT_Header = Utility.IsStringNullOrEmpty(dr["FLT_Header"]),
                                                FLT_PaxInfoFK = Utility.IsStringNullOrEmpty(dr["FLT_PaxInfoFK"]),
                                                TotalFareAmt = Utility.IsStringNullOrEmpty(dr["TotalFareAmt"]),
                                                BaseFareAmt = Utility.IsStringNullOrEmpty(dr["BaseFareAmt"]),
                                                TaxAmt = Utility.IsStringNullOrEmpty(dr["TaxAmt"]),
                                                YQAmt = Utility.IsStringNullOrEmpty(dr["YQAmt"]),
                                                WOAmt = Utility.IsStringNullOrEmpty(dr["WOAmt"]),
                                                YRAmt = Utility.IsStringNullOrEmpty(dr["YRAmt"]),
                                                INAmt = Utility.IsStringNullOrEmpty(dr["INAmt"]),
                                                ServiceTaxAmt = Utility.IsStringNullOrEmpty(dr["ServiceTaxAmt"]),
                                                TXNFeeAmt = Utility.IsStringNullOrEmpty(dr["TXNFeeAmt"]),
                                                ServiceChargeAmt = Utility.IsStringNullOrEmpty(dr["ServiceChargeAmt"]),
                                                CommissionAmt = Utility.IsStringNullOrEmpty(dr["CommissionAmt"]),
                                                CashBackAmt = Utility.IsStringNullOrEmpty(dr["CashBackAmt"]),
                                                TDSPercentage = Utility.IsStringNullOrEmpty(dr["TDSPercentage"]),
                                                TDSOn = Utility.IsStringNullOrEmpty(dr["TDSOn"]),
                                                TDSAmt = Utility.IsStringNullOrEmpty(dr["TDSAmt"]),
                                                CreationDate = Utility.IsStringNullOrEmpty(dr["CreationDate"]),
                                                UpdationDate = Utility.IsStringNullOrEmpty(dr["UpdationDate"]),
                                                IsDeleted = Utility.IsStringNullOrEmpty(dr["IsDeleted"]),
                                                IATACommission = Utility.IsStringNullOrEmpty(dr["IATACommission"]),
                                                FareBasis = Utility.IsStringNullOrEmpty(dr["FareBasis"]),
                                                BreakPoint = Utility.IsStringNullOrEmpty(dr["BreakPoint"]),
                                                ItineraryIdentifier = Utility.IsStringNullOrEmpty(dr["ItineraryIdentifier"]),
                                                QAmt = Utility.IsStringNullOrEmpty(dr["QAmt"]),
                                                JNAmt = Utility.IsStringNullOrEmpty(dr["JNAmt"]),
                                                OTAmt = Utility.IsStringNullOrEmpty(dr["OTAmt"]),
                                                EduCessAmt = Utility.IsStringNullOrEmpty(dr["EduCessAmt"]),
                                                HighEduCessAmt = Utility.IsStringNullOrEmpty(dr["HighEduCessAmt"]),
                                                IsRefundable = Utility.IsStringNullOrEmpty(dr["IsRefundable"]),
                                                FareNodes = Utility.IsStringNullOrEmpty(dr["FareNodes"]),
                                                IsObsoleteFare = Utility.IsStringNullOrEmpty(dr["IsObsoleteFare"]),
                                                YMAmt = Utility.IsStringNullOrEmpty(dr["YMAmt"]),
                                                TxnCharges = Utility.IsStringNullOrEmpty(dr["TxnCharges"]),
                                                LCCTotalFareAmt = Utility.IsStringNullOrEmpty(dr["LCCTotalFareAmt"]),
                                                IsTxnFeeIncluded = Utility.IsStringNullOrEmpty(dr["IsTxnFeeIncluded"]),
                                                LCCTotBaseFareAmt = Utility.IsStringNullOrEmpty(dr["LCCTotBaseFareAmt"]),
                                                GOFareID = Utility.IsStringNullOrEmpty(dr["GOFareID"]),
                                                OCAmt = Utility.IsStringNullOrEmpty(dr["OCAmt"])
                                            });
                                            break;
                                            #endregion
                                        case 6:
                                            #region User Profile
                                            //ideally this should return only one row
                                            //however making it a list to check if our application is not behaving as it should and check if more than one record
                                            //is being saved.
                                            objMasterQuery.UserProfile.Add(new T_FLT_UserProfile
                                            {
                                                FLT_UserProfilePK = Utility.IsStringNullOrEmpty(dr["FLT_UserProfilePK"]),
                                                FLT_HeaderFK = Utility.IsStringNullOrEmpty(dr["FLT_HeaderFK"]),
                                                FLT_Header = Utility.IsStringNullOrEmpty(dr["FLT_Header"]),
                                                Title = Utility.IsStringNullOrEmpty(dr["Title"]),
                                                FirstName = Utility.IsStringNullOrEmpty(dr["FirstName"]),
                                                MiddleName = Utility.IsStringNullOrEmpty(dr["MiddleName"]),
                                                LastName = Utility.IsStringNullOrEmpty(dr["LastName"]),
                                                AddressLine1 = Utility.IsStringNullOrEmpty(dr["AddressLine1"]),
                                                AddressLine2 = Utility.IsStringNullOrEmpty(dr["AddressLine2"]),
                                                CityFK = Utility.IsStringNullOrEmpty(dr["CityFK"]),
                                                StateFK = Utility.IsStringNullOrEmpty(dr["StateFK"]),
                                                CountryFK = Utility.IsStringNullOrEmpty(dr["CountryFK"]),
                                                ZipCode = Utility.IsStringNullOrEmpty(dr["ZipCode"]),
                                                Phone = Utility.IsStringNullOrEmpty(dr["Phone"]),
                                                Mobile = Utility.IsStringNullOrEmpty(dr["Mobile"]),
                                                Email = Utility.IsStringNullOrEmpty(dr["Email"]),
                                                UserType = Utility.IsStringNullOrEmpty(dr["UserType"]),
                                                UserInputCode = Utility.IsStringNullOrEmpty(dr["UserInputCode"]),
                                                CreationDate = Utility.IsStringNullOrEmpty(dr["CreationDate"]),
                                                UpdationDate = Utility.IsStringNullOrEmpty(dr["UpdationDate"]),
                                                IsDeleted = Utility.IsStringNullOrEmpty(dr["IsDeleted"])
                                            });
                                            break;
                                            #endregion
                                        case 7:
                                            #region Payment Info
                                            //ideally this should return only one row
                                            //however making it a list to check if our application is not behaving as it should and check if more than one record
                                            //is being saved.
                                            objMasterQuery.PaymentInfo.Add(new T_FLT_PaymentInfo
                                            {
                                                FLT_PaymentDetailPK = Utility.IsStringNullOrEmpty(dr["FLT_PaymentDetailPK"]),
                                                FLT_HeaderFK = Utility.IsStringNullOrEmpty(dr["FLT_HeaderFK"]),
                                                FLT_Header = Utility.IsStringNullOrEmpty(dr["FLT_Header"]),
                                                PGTypeCode = Utility.IsStringNullOrEmpty(dr["PGTypeCode"]),
                                                TrackID = Utility.IsStringNullOrEmpty(dr["TrackID"]),
                                                TransactionID = Utility.IsStringNullOrEmpty(dr["TransactionID"]),
                                                PaymentID = Utility.IsStringNullOrEmpty(dr["PaymentID"]),
                                                PaymentStatus = Utility.IsStringNullOrEmpty(dr["PaymentStatus"]),
                                                SysIP = Utility.IsStringNullOrEmpty(dr["SysIP"]),
                                                AmountPaid = Utility.IsStringNullOrEmpty(dr["AmountPaid"]),
                                                CreationDate = Utility.IsStringNullOrEmpty(dr["CreationDate"]),
                                                UpdationDate = Utility.IsStringNullOrEmpty(dr["UpdationDate"]),
                                                IsDeleted = Utility.IsStringNullOrEmpty(dr["IsDeleted"]),
                                                PGErrorText = Utility.IsStringNullOrEmpty(dr["PGErrorText"]),
                                                PGErrorNo = Utility.IsStringNullOrEmpty(dr["PGErrorNo"]),
                                                PayPageUrl = Utility.IsStringNullOrEmpty(dr["PayPageUrl"]),
                                                ResponseQueryString = Utility.IsStringNullOrEmpty(dr["ResponseQueryString"]),
                                                RequestQueryString = Utility.IsStringNullOrEmpty(dr["RequestQueryString"]),
                                                TransStatus = Utility.IsStringNullOrEmpty(dr["TransStatus"]),
                                                VerifyPortalRedirectUrl = Utility.IsStringNullOrEmpty(dr["VerifyPortalRedirectUrl"]),
                                                VerifyBookConfirmUrl = Utility.IsStringNullOrEmpty(dr["VerifyBookConfirmUrl"])
                                            });
                                            break;
                                            #endregion
                                    }
                                }
                                intTableIndex++;
                            } while (dr.NextResult());
                        }
                    }
                }
                return objMasterQuery;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}