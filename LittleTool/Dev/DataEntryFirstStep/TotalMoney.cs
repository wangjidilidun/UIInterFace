using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntryFirstStep
{
    class TotalMoney
    {
        private static TotalMoney instance;
        private TotalMoney()
        {

        }
        public static string strFirstTotal { get; set; }
        public static string strSecondTotal { get; set; }
        public static string strThirdTotal { get; set; }
        public static string strForthTotal { get; set; }
        public static string strFifthTotal { get; set; }
        public static string strSixthTotal { get; set; }
        public static string strSeventhTotal { get; set; }
        public static string strTotal { get; set; }

        public static TotalMoney getInstance()
        {
            if (instance == null)
            {
                instance = new TotalMoney();
                return instance;
            }
            else
            {
                return instance;
            }
        }


        protected bool isNumberic(string message, out double doubleVal)
        {
            //System.Text.RegularExpressions.Regex rex =
            //new System.Text.RegularExpressions.Regex(@"^\d{0,8}\.{0,1}(\d{1,2})?$");
            ////int.Parse(message);
            bool flag = false;
            doubleVal = -1;

            if (string.IsNullOrEmpty(message))
            {
                doubleVal = 0.00;
                return true;
            }

            //判断是否为两位小数
            if (message.IndexOf(".") == -1)
            {
                return false;
            }
            else
            {
                if ((message.Length - message.IndexOf('.') - 1) != 2)
                {
                    return false;
                }
            }

            try
            {
                doubleVal = System.Convert.ToDouble(message);
                //System.Console.WriteLine("{0} as a double is: {1}",
                //    str, doubleVal);
                flag = true;
            }
            catch (System.OverflowException)
            {
                //System.Console.WriteLine(
                //    "Conversion from string-to-double overflowed.");
                flag = false;
            }
            catch (System.FormatException)
            {
                //System.Console.WriteLine(
                //    "The string was not formatted as a double.");
                flag = false;
            }
            return flag;
        }


        public bool isEqualTotal()
        {
            double nFirst = 0.0;
            double nSecond = 0.0;
            double nThird = 0.0;
            double nForth = 0.0;
            double nFifth = 0.0;
            double nSixth = 0.0;
            double nSeventh = 0.0;
            double nTotal = 0.0;


            if (!(isNumberic(strFirstTotal, out nFirst) && isNumberic(strSecondTotal, out nSecond) && isNumberic(strThirdTotal, out nThird)
                && isNumberic(strForthTotal, out nForth) && isNumberic(strFifthTotal, out nFifth) && isNumberic(strSixthTotal, out nSixth)
                && isNumberic(strSeventhTotal, out nSeventh) && isNumberic(strTotal, out nTotal)))
            {
                return false;
            }
            if (Math.Abs(nTotal - nSecond - nThird - nForth - nFifth - nSixth - nSeventh) < 0.01)
            {
                return true;
            }
            return false;
            
        }
    }
}
