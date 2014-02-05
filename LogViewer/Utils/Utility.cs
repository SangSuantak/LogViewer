using System;
using System.Text;

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

        public static string GenerateSalt()
        {
            Random objRandom = new Random();
            string _sAvailableCharacters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#*@$^";
            StringBuilder _sbGeneratedSalt = new StringBuilder();
            int _iSize = 10;
            for (int i = 0; i < _iSize; i++)
            {
                _sbGeneratedSalt.Append(_sAvailableCharacters[objRandom.Next(_sAvailableCharacters.Length)]);
            }
            return _sbGeneratedSalt.ToString();
        }
    }
}