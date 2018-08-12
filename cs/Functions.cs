using System;
using System.Text;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using System.Security;
//using System.Security.Permissions;

namespace GenericCLX.CS
{
	/// <summary>
	/// Summary description for Functions.
	/// </summary>
    /// 

    //// Demand the zone requirement for the calling application.
    //[ZoneIdentityPermission(SecurityAction.Demand, Zone = SecurityZone.Trusted)]
    public class Functions
	{
		public Functions()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public static bool ReturnBoolCheck(string p_strCheck)
        {
            return (p_strCheck == "on" || p_strCheck == "1") ? true : false;
        }
        
        public static string Filter(string p_strText)
        {
            if (p_strText != null)
            {
                string[] arrInput = new string[13];
                string[] arrOutput = new string[13];
                int intLength = 12;

                arrInput[1] = "‡·„‚‰Â";
                arrOutput[1] = "a";

                arrInput[2] = "¿¡√¬ƒ≈";
                arrOutput[2] = "A";

                arrInput[3] = "ËÈÍÎÍÎ";
                arrOutput[3] = "e";

                arrInput[4] = "»… À À";
                arrOutput[4] = "E";

                arrInput[5] = "ÏÌÓÔ";
                arrOutput[5] = "i";

                arrInput[6] = "ÃÕŒœ";
                arrOutput[6] = "I";

                arrInput[7] = "ÚÛıÙˆ";
                arrOutput[7] = "o";

                arrInput[8] = "“”’‘÷";
                arrOutput[8] = "O";

                arrInput[9] = "˘˙˚¸";
                arrOutput[9] = "u";

                arrInput[10] = "Ÿ⁄€‹";
                arrOutput[10] = "U";

                arrInput[11] = "Á";
                arrOutput[11] = "c";

                arrInput[12] = "«";
                arrOutput[12] = "C";

                for (int intCount1 = 1; intCount1 <= intLength; intCount1++)
                {
                    string strInput = arrInput[intCount1];
                    int intInputLength = strInput.Length;

                    for (int intCount2 = 0; intCount2 < intInputLength; intCount2++)
                    {
                        p_strText = p_strText.Replace(strInput.Substring(intCount2, 1), arrOutput[intCount1]);
                    }
                }

                p_strText = p_strText.Replace("√û", "C");
                p_strText = p_strText.Replace("¬∑", "U");
                p_strText = p_strText.Replace("¬ß", "O");
                p_strText = p_strText.Replace("√ë", "A");

                p_strText = p_strText.Trim();
            }

            return p_strText;
        }

        public static string FilterCharactersSpecial(string p_strText)
        {
            if (p_strText != null)
            {
                string strInput = "\"\'!@#$®&*()_+=`¥~^{}[]?/:;><|\\/.¶-,,Ç ™û˛“ﬂ›æ+§ÉâÇ";
                int intInputLength = strInput.Length;

                for (int intCount = 0; intCount < intInputLength; intCount++)
                    p_strText = p_strText.Replace(strInput.Substring(intCount, 1), " ");

                p_strText = p_strText.Trim();
            }

            return p_strText;
        }

        public static string FullFilterToString(string p_strText)
        {
            if (p_strText == null) p_strText = "";
            return CleanSpace(JustStringNumber(Filter(p_strText.ToString().ToUpper())));
        }

        public static string FullFilterToUpper(string p_strText)
        {
            if (p_strText == null) p_strText = "";
            return CleanSpace(JustStringNumber(Filter(p_strText.ToString().ToUpper())));
        }

        public static string FullFilterToNumber(string p_strText)
        {
            if (p_strText == null) p_strText = "";
            return CleanSpace(JustNumber(CleanSpace(FilterCharactersSpecial(p_strText.ToString()))));
        }

        public static string JustStringNumber(string p_strText)
        {
            if (p_strText != null)
            {
                string strInput = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
                int intInputLength = p_strText.Length;

                for (int intCount = 0; intCount < intInputLength; intCount++)
                {
                    if (strInput.IndexOf(p_strText.Substring(intCount, 1)) == -1)
                        p_strText = p_strText.Replace(p_strText.Substring(intCount, 1), " ");
                }

                p_strText = p_strText.Trim();
            }

            return p_strText;
        }

        public static string JustNumber(string p_strText)
        {
            for (int i = 0; i <= p_strText.Length; i++)
            {
                try
                {
                    int intNumber = Convert.ToInt32(p_strText.Substring(i, 1));
                }
                catch
                {
                    if (p_strText.Length > i)
                    {
                        p_strText = p_strText.Replace(p_strText.Substring(i, 1), "");
                        i--;
                    }
                }
            }

            return p_strText;
        }

        public static bool Bool(bool p_blnText)
        {
            return (p_blnText);
        }

        public static bool Bool(int p_intText)
        {
            return (p_intText == 1);
        }

        public static bool Bool(string p_strText)
        {
            return (p_strText.Trim() == "1");
        }

        public static bool VerifyUF(string p_strUF)
        {
            if (p_strUF == null)
                return false;
            else
            {
                if (p_strUF.Trim() == "")
                    return false;
                else
                    return (("RS|PR|SC|SP|RJ|ES|MG|GO|MT|MS|TO|DF|BA|SE|AL|PE|PB|RN|CE|PI|MA|PA|AM|AC|AP|RR|RO").IndexOf(p_strUF.ToString().Trim()) != -1);
            }
        }

        public static string CleanSpace(string p_strText)
        {
            if (p_strText == null)
                return "";
            else
            {
                while (p_strText.IndexOf("  ") != -1)
                    p_strText = p_strText.Replace("  ", " ");

                while (p_strText.IndexOf("	") != -1)
                    p_strText = p_strText.Replace("	", " ");

                return p_strText.Trim();
            }
        }

        public static string FixedLength(string p_strText, int p_intWidth, string p_strFormat)
        {
            if (p_intWidth > 0)
            {
                string strDefault = (p_strFormat == "A") ? " " : "0";
                string strFormat = "";

                if (p_strText.Length > p_intWidth)
                    p_strText = p_strText.Substring(0, p_intWidth);
                else
                    for (int i = p_strText.Length; i < p_intWidth; i++)
                        strFormat += strDefault;

                if (p_strFormat == "A")
                    p_strText += strFormat;
                else
                    p_strText = strFormat + p_strText;
            }

            return p_strText;
        }

        public static string TabDelimited(string p_strText, int p_intWidth, string p_strFormat)
        {
            if (p_intWidth > 0 && p_strFormat != "A")
            {
                string strFormat = "";

                for (int i = p_strText.Length; i < p_intWidth; i++)
                    strFormat += "0";

                p_strText = strFormat + p_strText;
            }

            p_strText += "	";

            return p_strText;
        }

        public static TimeSpan DateDiff(string p_strDate1)
        {
            TimeSpan tspDate1 = new TimeSpan(Convert.ToDateTime(p_strDate1).Ticks);
            TimeSpan tspDate2 = new TimeSpan(DateTime.Now.ToLocalTime().Ticks);

            TimeSpan tspInterval = tspDate1.Subtract(tspDate2);

            return tspInterval;
        }

        public static TimeSpan DateDiff(string p_strDate1, string p_strDate2)
        {
            TimeSpan tspDate1 = new TimeSpan(Convert.ToDateTime(p_strDate1).Ticks);
            TimeSpan tspDate2 = new TimeSpan(Convert.ToDateTime(p_strDate2).Ticks);

            TimeSpan tspInterval = tspDate2.Subtract(tspDate1);

            return tspInterval;
        }

        public static TimeSpan HourDiff(string p_strDate1)
        {
            char chrTwoPoint = Convert.ToChar(":");
            string[] arrDate1 = p_strDate1.Split(chrTwoPoint);

            TimeSpan tspDate1 = new TimeSpan(0, Convert.ToInt16(arrDate1[0]), Convert.ToInt16(arrDate1[1]), Convert.ToInt16(arrDate1[2]), Convert.ToInt16(arrDate1[3]));
            TimeSpan tspDate2 = new TimeSpan(DateTime.Now.Date.Ticks);

            TimeSpan tspInterval = tspDate2.Subtract(tspDate1);

            return tspInterval;
        }

        public static TimeSpan HourDiff(string p_strDate1, string p_strDate2)
        {
            char chrTwoPoint = Convert.ToChar(":");

            string[] arrDate1 = p_strDate1.Split(chrTwoPoint);
            string[] arrDate2 = p_strDate2.Split(chrTwoPoint);

            TimeSpan tspDate1 = new TimeSpan(0, Convert.ToInt16(arrDate1[0]), Convert.ToInt16(arrDate1[1]), Convert.ToInt16(arrDate1[2]), Convert.ToInt16(arrDate1[3]));
            TimeSpan tspDate2 = new TimeSpan(0, Convert.ToInt16(arrDate2[0]), Convert.ToInt16(arrDate2[1]), Convert.ToInt16(arrDate2[2]), Convert.ToInt16(arrDate2[3]));

            TimeSpan tspInterval = tspDate2.Subtract(tspDate1);

            return tspInterval;
        }

        public static string FilterError(string p_strError)
        {
            if (p_strError.IndexOf("Description=") != -1)
            {
                p_strError = p_strError.Substring(p_strError.IndexOf("Description=") + ("Description=".Length + 1));
                p_strError = p_strError.Substring(0, p_strError.Length - 3).Replace("\\n", "");
            }

            return p_strError;
        }

        public static string CDcm(string strValue)
        {
            return (strValue.Trim() != "") ? strValue.Replace(".", "") : "0.00";
        }

        public static bool CBln(string val)
        {
            return SQL.Bool(val);
        }

        public static string FormatCPF(string p_strValue)
        {
            return (p_strValue != null && p_strValue != "") ? String.Format("{0:00000000000000}", Convert.ToDouble(Functions.FullFilterToNumber(p_strValue.ToString().Trim()))) : "";
        }

        public static bool SendMail(string strFrom, string strTo, string strCc, string strSubject, string strBody)
        {
            System.Web.Mail.MailMessage objMailMessage = new System.Web.Mail.MailMessage();
            objMailMessage.From = strFrom;
            objMailMessage.To = strTo;
            objMailMessage.Cc = strCc;
            objMailMessage.Subject = strSubject;
            objMailMessage.BodyFormat = System.Web.Mail.MailFormat.Text;
            objMailMessage.Priority = System.Web.Mail.MailPriority.High;
            objMailMessage.Body = strBody;

            try
            {
                objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "USUARIO@visioncom.com.br");
                objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "SENHA");

                System.Web.Mail.SmtpMail.SmtpServer = "pop.visioncom.com.br";

                System.Web.Mail.SmtpMail.Send(objMailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool VerifyBrowser(string p_strHttp, string strType) //IE / FIREFOX
        {
            bool blnReturn = false;
            p_strHttp = p_strHttp.ToUpper();

            switch (strType.ToUpper())
            {
                case "IE":
                    try
                    {
                        string[] arrHttp = p_strHttp.Split(Convert.ToChar(";"));
                        string strVersion = arrHttp[1].Replace("MSIE", "").Trim();
                        blnReturn = (p_strHttp.IndexOf("MSIE") != -1 && Convert.ToDecimal(strVersion) > 5);
                    }
                    catch
                    {
                        blnReturn = false; 
                    }
                    break;
                case "FIREFOX":
                    blnReturn = (p_strHttp.IndexOf("FIREFOX") != -1);
                    break;
            }
 
            return blnReturn;
        }

        public static string FormatValidity(string p_strDay, string p_strMonth, string p_strYear)
        {
            int intDay = (p_strDay == null) ? DateTime.Now.Day : Convert.ToInt16(p_strDay);
            int intMonth = (p_strMonth == null) ? DateTime.Now.Month : Convert.ToInt16(p_strMonth);
            int intYear = (p_strYear == null) ? DateTime.Now.Year : Convert.ToInt16(p_strYear);

            if (p_strDay == "0") intDay = DateTime.Now.Day;
            if (p_strMonth == "0") intMonth = DateTime.Now.Month;
            if (p_strYear == "0") intYear = DateTime.Now.Year;

            /*intMonth++;

            if(intMonth == 13)
            {
                intMonth = 1;
                intYear++;
            }*/

            return intDay.ToString() + "/" + intMonth.ToString() + "/" + intYear.ToString();
        }

        public static string FormatValidity(string p_strMonth, string p_strYear)
        {
            int intMonth = (p_strMonth == null) ? DateTime.Now.Month : Convert.ToInt16(p_strMonth);
            int intYear = (p_strYear == null) ? DateTime.Now.Year : Convert.ToInt16(p_strYear);

            /*intMonth++;

            if(intMonth == 13)
            {
                intMonth = 1;
                intYear++;
            }*/

            return "01/" + intMonth.ToString() + "/" + intYear.ToString();
        }

        public static bool ValidateCpf(string p_strCpf)
        {
            string CPF = JustNumber(p_strCpf);
            CPF = String.Format(String.Format("{0:00000000000000}", Convert.ToDouble(FullFilterToNumber(CPF))));
            CPF = CPF.Substring(3);

            if (CPF.Length != 11 || CPF == "00000000000" || CPF == "11111111111" ||
                CPF == "22222222222" || CPF == "33333333333" || CPF == "44444444444" ||
                CPF == "55555555555" || CPF == "66666666666" || CPF == "77777777777" ||
                CPF == "88888888888" || CPF == "99999999999")
                return false;

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += Convert.ToInt16(CPF.Substring(i, 1)) * (10 - i);

            int resto = 11 - (soma % 11);

            if (resto == 10 || resto == 11)
                resto = 0;

            if (resto != Convert.ToInt16(CPF.Substring(9, 1)))
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += Convert.ToInt16(Convert.ToInt16(CPF.Substring(i, 1)) * (11 - i));

            resto = 11 - (soma % 11);

            if (resto == 10 || resto == 11)
                resto = 0;

            if (resto != Convert.ToInt16(CPF.Substring(10)))
                return false;

            return true;
        }

        public static string BreakString(string p_strText, int p_intNumber)
        {
            int intInitialNumber = p_intNumber;

            while (p_strText.Length > p_intNumber)
            {
                p_strText = p_strText.Substring(0, p_intNumber) + "\n" + p_strText.Substring(p_intNumber);
                p_intNumber += (intInitialNumber + "\n".Length);
            }

            return p_strText;
        }

        public static string PrepareSql(string p_strProc, params string[] p_strFields)
        {
            string p_strSql = "";
            
            p_strProc.Trim();
            p_strSql = p_strProc + " ";

            for (int i = 0; i < p_strFields.Length; i++)
            {
                if(i > 0) p_strSql += ",";
                p_strSql += p_strFields[i];
            }

            p_strSql.Trim();
            return p_strSql;
        }

        public static bool IsDateTime(object expression)
        {
            if(expression == null) return false;

            string stringExpression = System.Convert.ToString(expression);
            if(String.IsNullOrEmpty(stringExpression)) return false;

            long retLong;
            if(Int64.TryParse(stringExpression, out retLong)) {
            if((retLong < DateTime.MinValue.Ticks) || (retLong > DateTime.MaxValue.Ticks)) return false;
            return true;
            }

            DateTime retDateTime;
            return DateTime.TryParse(stringExpression, out retDateTime);
        }

        public static bool IsNumeric(object expression)
        {
            if (expression == null) return false;

            string stringExpression = System.Convert.ToString(expression);
            if (String.IsNullOrEmpty(stringExpression)) return false;

            long retLong;
            if(long.TryParse(stringExpression, out retLong)) return true;
            else
            {
                float retFloat;
                return (float.TryParse(stringExpression, out retFloat));
            }
        }

        public static string GetBasicSearchString(string p_strFieldsName, string p_strFieldsValue, string p_strOperator, bool p_blnForceStringType)
        {
            StringBuilder objSB = new StringBuilder(string.Empty);
            string strReturn = "";
            int x = 0;

            string[] arrFieldsName = p_strFieldsName.Split(',');
            string[] arrFieldsValue = p_strFieldsValue.Split(',');

            for (int i = 0; i < arrFieldsName.Length; i++)
            {
                if (arrFieldsName[i].Trim() != "" && arrFieldsValue[i].Trim() != "")
                {
                    strReturn = "";
                    if (x > 0) objSB.Append(" AND ");
                    strReturn = GetSearchFormattedFieldString(arrFieldsName[i], arrFieldsValue[i], p_strOperator, p_blnForceStringType);
                    objSB.Append(strReturn);
                    x += 1;
                }
            }

            string strSearch = objSB.ToString();
            return strSearch;
        }

        public static string GetSearchFormattedFieldString(string strField, string strValue, string strOperator, bool blnForceStringType)
        {
            if (strValue.Trim() == string.Empty)
                return string.Empty;

            string _newstrValue = strValue.Trim();
            string _invalidChars = "`~!@#$%^&()-_=+[{]}\\|;:<,>./?\"";

            string _operator = "=";
            if (strOperator != string.Empty)
                _operator = strOperator;

            if (Functions.IsDateTime(_newstrValue) == false)
            {
                for (int i = 0; i < _invalidChars.Length; i++)
                {
                    _newstrValue = _newstrValue.Replace(_invalidChars.Substring(i, 1), string.Empty);
                }

                _newstrValue = _newstrValue.Replace('*', '%');
                _newstrValue = _newstrValue.Replace("'", "''");
            }

            if (blnForceStringType == false)
            {
                if (Functions.IsNumeric(_newstrValue) == true)
                {
                    _newstrValue = strField + " " + _operator + " " + _newstrValue;
                }
                else if (Functions.IsDateTime(_newstrValue) == true)
                {
                    DateTime dtstrValue = DateTime.Parse(_newstrValue);
                    _newstrValue = strField + " " + _operator + " #" + dtstrValue.ToShortDateString() + "#";
                }
                else
                {
                    if (_newstrValue.IndexOf("%") > -1)
                        _newstrValue = strField + " LIKE '" + _newstrValue + "'";
                    else
                        _newstrValue = strField + " " + _operator + " '" + _newstrValue + "'";
                }
            }
            else
            {
                if (_newstrValue.IndexOf("%") > -1)
                    _newstrValue = strField + " LIKE '" + _newstrValue + "'";
                else
                    _newstrValue = strField + " " + _operator + " '" + _newstrValue + "'";
            }

            return _newstrValue;
        }
    }
}