using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace DataEntryFirstStep
{
    class DataEntryRules
    {
        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strMoney1">0 0 0 1 0 1 1 1</param>
        /// <param name="strMoney2">0 0 1 0 1 0 1 1</param>
        /// <param name="strMoney3">0 1 0 0 1 1 0 1</param>
        /// <returns></returns>
        public bool TotalMoneyFieldProof(string strMoney1, string strMoney2, string strMoney3)
        {
            bool bNum1 = string.IsNullOrEmpty(strMoney1);
            bool bNum2 = string.IsNullOrEmpty(strMoney2);
            bool bNum3 = string.IsNullOrEmpty(strMoney3);
            double nNum1 = 0.00;
            double nNum2 = 0.00;
            double nNum3 = 0.00;

            if (!isNumberic(strMoney1, out nNum1) || !isNumberic(strMoney2, out nNum2) || !isNumberic(strMoney3, out nNum3))
            {
                return false;
            }
            if (bNum1 && bNum2 && bNum3)
            {
                return true;
            }
            else if ((bNum1 && bNum2 & !bNum3) || (bNum1 && !bNum2 & bNum3) || (!bNum1 && !bNum2 & bNum3) || (!bNum1 && bNum2 & bNum3))
            {
                return false;
            }
            else
            {
                //if (nNum3 == nNum1 - nNum2)
                if (Math.Abs(nNum1 - nNum2 - nNum3) < 0.01)
                {
                    return true;
                }
            }
            return false;

        }

        public bool MoneyProof(List<string> eachMoney, string strDebit)
        {
            double sum = 0.0;
            double temp = 0.0;
            double sumCalcu = 0.0;

            if (!isNumberic(strDebit, out sum))
            {
                return false;
            }
            foreach (string s in eachMoney)
            {
                if (isNumberic(s, out temp))
                {
                    sumCalcu += temp;
                }
                else
                {
                    return false;
                }
            }
            if (sum == sumCalcu)
            {
                return true;
            }
            else
            {
                return false;
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

        public bool JudgeVeticalColumnNull(SourceGrid.Grid grid, int nIndexColumn)
        {
            for (int r = grid.FixedRows; r < grid.RowsCount; r++)
            {
                if (grid[r, nIndexColumn].Value != null)
                {
                    return false;
                }
            }
            return true;
        }

        private double VerticalMoneyPlus(SourceGrid.Grid grid, int nIndexColumn)
        {
            double temp = 0;
            double dSummary = 0;

            for (int r = grid.FixedRows; r < grid.RowsCount; r++)
            {
                if (grid[r, nIndexColumn].Value != null)
                {
                    isNumberic(grid[r, nIndexColumn].Value.ToString(), out temp);
                    dSummary += temp;
                }
            }
            Console.WriteLine("summary:\t" + dSummary);
            return dSummary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid">目标表格</param>
        /// <param name="nIndexColumn">要验证的列</param>
        /// <param name="strLittleTotal">竖向相加的总额</param>
        /// <returns></returns>
        public bool VerifyVerticalMoney(SourceGrid.Grid grid, int nIndexColumn, string strLittleTotal)
        {
            double dCalcuTotal = 0.0;
            double dTotal = 0.0;

            if (!isNumberic(strLittleTotal, out dTotal))
            {
                return false;
            }
            dCalcuTotal = VerticalMoneyPlus(grid, nIndexColumn);
            if (Math.Abs(dCalcuTotal - dTotal) < 0.01)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 税号的自校验
        public bool TaxCodeProof(string strTaxCode)
        {
            if (strTaxCode == "")
            {
                return true;
            }
            string strTaxCodeCalcu = "";
            if (strTaxCode.Length == 16)
            {
                //strTaxCodeCalcu = strTaxCode.Substring(0, 15);
                //strTaxCodeCalcu += CalcuControlChar(strTaxCodeCalcu);
                //if (strTaxCodeCalcu.Equals(strTaxCode))
                //{
                //    return true;
                //}
                return CheckCodiceFiscale(strTaxCode);
            }
            else if (strTaxCode.Length == 11)
            {
                return CheckPartitaIva(strTaxCode);
            }
            return false;
        }

        private static bool CheckCodiceFiscale(string codiceFiscale)
        {
            if (codiceFiscale == null || codiceFiscale.Length != 16)
                return false;

            // stringa per controllo e calcolo omocodia
            const string omocodici = "LMNPQRSTUV";
            // per il calcolo del check digit e la conversione in numero
            const string listaControllo = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int[] listaPari =
                {
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24,
                    25
                };
            int[] listaDispari =
                {
                    1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25,
                    24, 23
                };

            codiceFiscale = codiceFiscale.ToUpper();
            var cCodice = codiceFiscale.ToCharArray();

            // check della correttezza formale del codice fiscale
            // elimino dalla stringa gli eventuali caratteri utilizzati negli
            // spazi riservati ai 7 che sono diventati carattere in caso di omocodia
            for (var k = 6; k < 15; k++)
            {
                if ((k == 8) || (k == 11))
                    continue;
                var x = (omocodici.IndexOf(cCodice[k]));
                if (x != -1)
                    cCodice[k] = x.ToString(CultureInfo.InvariantCulture).ToCharArray()[0];
            }

            var somma = 0;
            // ripristino il codice fiscale originario 
            cCodice = codiceFiscale.ToCharArray();
            for (var i = 0; i < 15; i++)
            {
                var c = cCodice[i];
                var x = "0123456789".IndexOf(c);
                if (x != -1)
                    c = listaControllo.Substring(x, 1).ToCharArray()[0];
                x = listaControllo.IndexOf(c);
                // i modulo 2 = 0 è dispari perchè iniziamo da 0
                x = (i % 2) == 0 ? listaDispari[x] : listaPari[x];
                somma += x;
            }

            return (listaControllo.Substring(somma % 26, 1) == codiceFiscale.Substring(15, 1));
        }


        public static bool CheckPartitaIva(string partitaIva)
        {
            int[] listaPari = { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };
            // normalizziamo la cifra
            if (partitaIva.Length < 11)
                partitaIva = partitaIva.PadLeft(11, '0');
            // lunghezza errata non fa neanche il controllo
            if (partitaIva.Length != 11)
                return false;
            var somma = 0;
            for (var k = 0; k < 11; k++)
            {
                var s = partitaIva.Substring(k, 1);
                // otteniamo contemporaneamente
                // il valore, la posizione e testiamo se ci sono
                // caratteri non numerici
                var i = "0123456789".IndexOf(s);
                if (i == -1)
                    return false;
                var x = int.Parse(s);
                if (k % 2 == 1) // Pari perchè iniziamo da zero
                    x = listaPari[i];
                somma += x;
            }
            return ((somma % 10 == 0) && (somma != 0));
        }

        private char CalcuControlChar(string strTaxCode)
        {

            string str1 = "";
            string str2 = "";
            int AlphbetaIndex = 0;
            char controlChar = 'A';
            if (strTaxCode.Length != 15)
            {
                return (char)0;
            }
            int index = 0;

            while (index < 14)
            {
                str1 = strTaxCode[index] + str1;
                index++;
                str2 = strTaxCode[index] + str2;
                index++;
            }
            str1 = strTaxCode[index] + str1;
            AlphbetaIndex += CalcuCtrlStr1(str1);
            AlphbetaIndex += CalcuCtrlStr2(str2);

            AlphbetaIndex = AlphbetaIndex % 26;
            controlChar = (char)(controlChar + AlphbetaIndex);
            return controlChar;
        }

        /// <summary>
        /// 计算八位的
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int CalcuCtrlStr1(string str)
        {
            int[] intCodiciXposDispari = {1,0,5,7,9,13,15,17,19,21,2,4,18,20,11,3,6,8,12,
											 14,16,10,22,25,24,23,1,0,5,7,9,13,15,17,19,21};
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                sum += intCodiciXposDispari[ConvetChartoIntByRules(str[i])];
            }
            return sum;
        }

        private int ConvetChartoIntByRules(char c)
        {
            int index = 0;

            if (char.IsLetter(c))
            {
                index = c - 'A';
            }
            if (char.IsNumber(c))
            {
                index = c - '0' + 26;
            }
            return index;
        }

        /// <summary>
        /// 计算七位的
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int CalcuCtrlStr2(string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    sum += str[i] - 'A';
                }
                if (char.IsNumber(str[i]))
                {
                    sum += str[i] - '0';
                }
            }
            return sum;
        }
        #endregion

        #region
        public bool DateAreaProof(string strBirthDate)
        {
            if (strBirthDate == "")
            {
                return true;
            }
            strBirthDate = strBirthDate.Trim();
            IFormatProvider ifp = new CultureInfo("it-IT", true);
            DateTime temp;
            if (string.IsNullOrEmpty(strBirthDate.Trim()))
            {
                return true;
            }
            if (DateTime.TryParseExact(strBirthDate, "ddMMyyyy", ifp, DateTimeStyles.None, out temp))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
