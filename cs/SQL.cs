using System;
using System.Data.SqlClient;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using System.Security;
//using System.Security.Permissions;

namespace GenericCLX.CS
{
	/// <summary>
	/// Summary description for SQL.
	/// </summary>
    /// 

    //// Demand the zone requirement for the calling application.
    //[ZoneIdentityPermission(SecurityAction.Demand, Zone = SecurityZone.Trusted)]
    public class SQL
	{
		public static string Varchar(string val)
		{
            if (val == null) val = "";
            return (val.Trim() == "") ? "NULL" : "'" + val.Replace("'","''").Replace("\"","''") + "'";
		}

        public static string Varchar(int val)
        {
            return Varchar(val.ToString());
        }

        public static string Int(string val)
        {
            if (val == null) val = "";
            return (val.Trim() == "") ? "NULL" : val.Replace("'","").ToString();
        }

		public static string Int(int val)
		{
            return Int(val.ToString()); 
		}

        public static string BigInt(string val)
        {
            if (val == null) val = "";
            return (val.Trim() == "") ? "NULL" : val.Replace("'", "").ToString();
        }

        public static string BigInt(long val)
        {
            return BigInt(val.ToString());
        }

		public static string Bit(int val)
		{
			return (val>0) ? "1" : "0";
		}

		public static string Bit(bool val)
		{
			return (val) ? "1" : "0";
		}

		public static bool Bool(int val)
		{
            return (val>0);
		}

		public static bool Bool(bool val)
		{
			return val;
		}

		public static bool Bool(string val)
		{
            return (val.Trim().ToLower() == "true" || val == "1");
		}

		public static string DateTime(string val)
		{
            if (val == null)
                return Util.StrNullDateTime.ToString();
            else if (val.Trim() == "")
                return Util.StrNullDateTime.ToString();
			
			char[] arrChar = {Convert.ToChar("-"), Convert.ToChar("/"), Convert.ToChar(" "), Convert.ToChar(":")};
			string[] arrDate = val.Split(arrChar);

			if(arrDate.Length < 6)
			{
				val += " 00:00:00";
				arrDate = val.Split(arrChar);
			}

            string strDate = (arrDate[2].Length > 2) ? arrDate[2] + "-" + arrDate[1] + "-" + arrDate[0] : arrDate[0] + "-" + arrDate[1] + "-" + arrDate[2];

            return "'" + strDate + " " + arrDate[3] + ":" + arrDate[4] + ":" + arrDate[5] + "'";
		}
		
		public static string DateTime(DateTime val)
		{
			return "'" + val.Year + "-" + val.Month + "-" + val.Day + " " + val.Hour + ":" + val.Minute + ":" + val.Second + "'";
		}

		public static string Decimal(decimal val)
		{
            return Decimal(val.ToString());
		}

		public static string Decimal(string val)
		{
            string strVal = val.ToString();
            if (strVal == null) strVal = "";
            if (strVal == null) return "NULL";
            return (strVal.ToString().IndexOf(",") == -1) ? strVal.ToString() : strVal.ToString().Replace(".", "").Replace(",", ".");
		}
	}
}
