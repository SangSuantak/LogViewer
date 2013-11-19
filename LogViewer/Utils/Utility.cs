using System;

namespace LogViewer.Utils
{
    public class Utility
    {
        /// <summary>
        /// Generic function to convert a string value to its enum equivalent
        /// No error/null handling done since there must be a problem with the calling code that leads to such situation
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="strVal">value of the enum in string</param>
        /// <returns>Enum value</returns>
        public static T StringToEnum<T>(string strVal) //where T : struct
        {
            return (T)Enum.Parse(typeof(T), strVal);
        }

        /// <summary>
        /// FormatDate for en-GB
        /// </summary>
        /// <param name="_Date"></param>
        /// <returns></returns>
        public static DateTime FormatDate(string _Date)
        {
            DateTime Dt = DateTime.Now;
            IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-GB");
            Dt = DateTime.Parse(_Date, mFomatter);
            return Dt;
        }

        public static string IsStringNullOrEmpty(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString().Trim();
            }
        }
    }
}