using System;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using System.Security;
//using System.Security.Permissions;

namespace GenericCLX.CS
{
	/// <summary>
	/// Summary description for DropDownList.
	/// </summary>
    /// 

    //// Demand the zone requirement for the calling application.
    //[ZoneIdentityPermission(SecurityAction.Demand, Zone = SecurityZone.Trusted)]
    public class DropDownList
	{
		char chrDelimiter = Convert.ToChar(",");

		private bool _Select;
		public bool Select
		{
			get { return _Select; }
			set { _Select = value; }
		}

		private string _Xml;
		public string Xml
		{
			get { return _Xml; }
			set { _Xml = value; }
		}

		private string _ColumnValue;
		public string ColumnValue
		{
			get { return _ColumnValue; }
			set { _ColumnValue = value; }
		}

		private string _ColumnText;
		public string ColumnText
		{
			get { return _ColumnText; }
			set { _ColumnText = value; }
		}

		public DropDownList()
		{
			this._Select = true;
			this._Xml = "";
			this._ColumnValue = "";
			this._ColumnText = "";
		}

		public DataView ReturnDataSource()
		{
			DataTable objDT = new DataTable("DropDownList");

			DataColumn objDC = objDT.Columns.Add(this._ColumnValue, typeof(String));
			objDC.AllowDBNull = false;
			objDC.Unique = true;
			objDT.Columns.Add(this._ColumnText, typeof(String));

			if(this._Select)
                objDT.Rows.Add(new Object[] { "0", "Selecione" });

            if (this._Xml.Trim() != "")
            {
                XmlDocument objXml = new XmlDocument();
                objXml.LoadXml(this._Xml);

                string[] arrColumnValue = this._ColumnValue.Split(chrDelimiter);
                string[] arrColumnText = this._ColumnText.Split(chrDelimiter);

                for (int i = 0; i < objXml.DocumentElement.ChildNodes.Count; i++)
                {
                    string strValue = "";
                    string strText = "";

                    XmlAttributeCollection objAttribute = objXml.DocumentElement.ChildNodes[i].Attributes;

                    for (int w = 0; w < arrColumnValue.Length; w++)
                        strValue += objAttribute.GetNamedItem(arrColumnValue[w]).Value + " - ";

                    for (int w = 0; w < arrColumnText.Length; w++)
                        strText += objAttribute.GetNamedItem(arrColumnText[w]).Value + " - ";

                    strValue = strValue.Trim();

                    strText = strText.Trim();

                    strValue = strValue.Substring(0, strValue.Length - 1).Trim();

                    strText = strText.Substring(0, strText.Length - 1).Trim();

                    objDT.Rows.Add(new Object[] { strValue.Trim(), strText.Trim() });
                }
            }

			DataView objDV = new DataView(objDT);
	
			return objDV;
		}
	}
}