using System;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using System.Security;
//using System.Security.Permissions;

namespace GenericCLX.CS
{
	/// <summary>
	/// Summary description for DataGrid.
	/// </summary>
    /// 

    //// Demand the zone requirement for the calling application.
    //[ZoneIdentityPermission(SecurityAction.Demand, Zone = SecurityZone.Trusted)]
    public class DataGrid
	{
		char chrDelimiter = Convert.ToChar(",");

		private System.Web.UI.WebControls.DataGrid _Grid;
		public System.Web.UI.WebControls.DataGrid Grid
		{
			get { return _Grid; }
			set { _Grid = value; }
		}

		private bool _FirstColumnVisible;
		public bool FirstColumnVisible
		{
			get { return _FirstColumnVisible; }
			set { _FirstColumnVisible = value; }
		}

		private string _InitialColumnSorting;
		public string InitialColumnSorting
		{
			get { return _InitialColumnSorting; }
			set { _InitialColumnSorting = value; }
		}

		private string _ColumnSorting;
		public string ColumnSorting
		{
			get { return _ColumnSorting; }
			set { _ColumnSorting = value; }
		}

		private string _ColumnsHeader;
		public string ColumnsHeader
		{
			get { return _ColumnsHeader; }
			set { _ColumnsHeader = value; }
		}

		private string _ColumnsName;
		public string ColumnsName
		{
			get { return _ColumnsName; }
			set { _ColumnsName = value; }
		}

		private string _ColumnsAlign;
		public string ColumnsAlign
		{
			get { return _ColumnsAlign; }
			set { _ColumnsAlign = value; }
		}

		private string _ColumnsFormat;
		public string ColumnsFormat
		{
			get { return _ColumnsFormat; }
			set { _ColumnsFormat = value; }
		}

        private string _ColumnsVisible;
        public string ColumnsVisible
		{
            get { return _ColumnsVisible; }
            set { _ColumnsVisible = value; }
		}

		private string _ColumnsHeaderChilds;
		public string ColumnsHeaderChilds
		{
			get { return _ColumnsHeaderChilds; }
			set { _ColumnsHeaderChilds = value; }
		}

		private string _ColumnsImgChilds;
		public string ColumnsImgChilds
		{
			get { return _ColumnsImgChilds; }
			set { _ColumnsImgChilds = value; }
		}

		private string _ColumnsLinkChilds;
		public string ColumnsLinkChilds
		{
			get { return _ColumnsLinkChilds; }
			set { _ColumnsLinkChilds = value; }
		}

		private string _Module;
		public string Module
		{
			get { return _Module; }
			set { _Module = value; }
		}

		private string _ID;
		public string ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _Title;
		public string Title
		{
			get { return _Title; }
			set { _Title = value; }
		}

		private string _Xml;
		public string Xml
		{
			get { return _Xml; }
			set { _Xml = value; }
		}

		private int _GridLength;
		public int GridLength
		{
			get { return _GridLength; }
			set { _GridLength = value; }
		}

        private string _Actions;
        public string Actions
        {
            get { return _Actions; }
            set { _Actions = value; }
        }

        private string _Acronyms;
        public string Acronyms
        {
            get { return _Acronyms; }
            set { _Acronyms = value; }
        }

		public DataGrid()
		{
			this._FirstColumnVisible = true;
			this._ColumnsHeader = "";
			this._ColumnsName = "";
			this._ColumnsAlign = "";
			this._ColumnsFormat = "";
            this._ColumnsVisible = "";
			this._ID = "";
			this._Title = "";
			this._Xml = "";
			this._GridLength = 0;
            this._Actions = "";
            this._Acronyms = "";
			this._Module = "Web";
		}

		public void DefineColumnsGrid()
		{
			string[] arrStrColumnsHeader = this._ColumnsHeader.Split(chrDelimiter);
			string[] arrColumnsName = this._ColumnsName.Split(chrDelimiter);
			string[] arrStrColumnsAlign = this._ColumnsAlign.Split(chrDelimiter);
            string[] arrStrColumnsFormat = this._ColumnsFormat.Split(chrDelimiter);
            string[] arrStrColumnsVisible = this._ColumnsVisible.Split(chrDelimiter);

			for(int i = 0; i < arrStrColumnsHeader.Length; i++)
			{
				arrStrColumnsHeader[i] = arrStrColumnsHeader[i].Replace("comma", ",");

                string strFormat = (i >= arrStrColumnsFormat.Length) ? "" : arrStrColumnsFormat[i];
                bool blnVisible = true;

                if(i >= arrStrColumnsVisible.Length)
                    blnVisible = true;
                else
                    blnVisible = (arrStrColumnsVisible[i].Trim() == "") ? true : Functions.CBln(arrStrColumnsVisible[i]);

				if(i == 0 && ! this._FirstColumnVisible)
                    this._Grid.Columns.Add(AddColumnGrid(arrStrColumnsHeader[i], arrColumnsName[i], Convert.ToInt32(arrStrColumnsAlign[i]), strFormat, false));
				else
                    this._Grid.Columns.Add(AddColumnGrid(arrStrColumnsHeader[i], arrColumnsName[i], Convert.ToInt32(arrStrColumnsAlign[i]), strFormat, blnVisible));
			}
		}

		public void DefineActionsGrid()
		{

            if (this._Actions.Trim() != "" && this._Actions.Trim() != "")
            {
                GenericCLX.CS.Util objUtil = new GenericCLX.CS.Util();
                //objUtil.GetConfig("");
                string strProjectName = objUtil.ProjectName.Trim();
                string[] arrStrActions = this._Actions.Split(chrDelimiter);
                string[] arrStrAcronyms = this._Acronyms.Split(chrDelimiter);

                for (int i = 0; i < arrStrActions.Length; i++)
                {
                    if (arrStrActions[i].Trim() != "" && arrStrAcronyms[i].Trim() != "")
                    {
                        HyperLinkColumn objLink = new HyperLinkColumn();
                        objLink.Text = "<img src=\"/GenericCLX/img/" + arrStrActions[i] + ".gif\" border=\"0\" class=\"hand\">";
                        //objLink.Text = "<img src=\"/GenericCLX/img/new/" + arrStrActions[i] + ".ico\" border=\"0\" class=\"hand\">";
                        objLink.DataNavigateUrlField = this._ID;
                        objLink.DataNavigateUrlFormatString = "javascript:redirect('" + "/" + strProjectName + "/" + this._Module + "/" + this._Title + "/" + this._Title + arrStrAcronyms[i] + ".aspx?" + this._ID + "={0}');";
                        //objLink.DataNavigateUrlFormatString = "javascript:popupcenter('../Includes/Pop.asp?tipo=<%=LCase(strFolder)%>&id=<%=intCount%>&titulo=<%=strTitulo%>&link=<%=strLink%>&texto=<%=strTexto%>&bgcolor=<%=strColor%>&w=190&h=83','POP<%=intCount%>',230,230,0,0);
                        objLink.HeaderText = arrStrActions[i];
                        objLink.HeaderStyle.HorizontalAlign = (HorizontalAlign)2;
                        objLink.ItemStyle.HorizontalAlign = (HorizontalAlign)2;
                        this._Grid.Columns.Add(objLink);
                    }
                }
            }
		}

		public void DefineChildsGrid()
		{
			string[] arrStrColumnsHeaderChilds = this._ColumnsHeaderChilds.Split(chrDelimiter);
			string[] arrStrColumnsImgChilds = this._ColumnsImgChilds.Split(chrDelimiter);
			string[] arrStrColumnsLinkChilds = this._ColumnsLinkChilds.Split(chrDelimiter);

			for(int i = 0; i < arrStrColumnsHeaderChilds.Length; i++)
			{
				HyperLinkColumn objLink = new HyperLinkColumn();
				objLink.Text = "<img src=\"" + arrStrColumnsImgChilds[i] + "\" border=\"0\" class=\"hand\">";
				objLink.DataNavigateUrlField = this._ID;
				objLink.DataNavigateUrlFormatString = "javascript:redirect('" + arrStrColumnsLinkChilds[i] + "');";
				objLink.HeaderText = arrStrColumnsHeaderChilds[i];
				objLink.HeaderStyle.HorizontalAlign = (HorizontalAlign)2;
				objLink.ItemStyle.HorizontalAlign = (HorizontalAlign)2;
				this._Grid.Columns.Add(objLink);
			}
		}

		private BoundColumn AddColumnGrid(string strHeader, string strColumn, int intAlign)
		{
			BoundColumn objField = new BoundColumn();
			objField.HeaderText = strHeader;
			objField.DataField = strColumn;
			objField.HeaderStyle.HorizontalAlign = (HorizontalAlign)intAlign;
			objField.ItemStyle.HorizontalAlign = (HorizontalAlign)intAlign;
			objField.ItemStyle.VerticalAlign = (VerticalAlign)1;

			if(strColumn.Trim() != "")
				objField.SortExpression = strColumn;
			
			return objField;
		}

		private BoundColumn AddColumnGrid(string strHeader, string strColumn, int intAlign, string strFormatValue)
		{
			BoundColumn objField = AddColumnGrid(strHeader, strColumn, intAlign);

            if (strFormatValue.Trim() != "")
            {
                switch (strFormatValue)
                {
                    case ("int"):
                        strFormatValue = "n0";
                        break;
                    case ("dcm"):
                        strFormatValue = "n";
                        break;
                    case ("dcm5"):
                        strFormatValue = "n5";
                        break;
                    case ("cur"):
                        strFormatValue = "c";
                        break;
                    case ("pct"):
                        strFormatValue = "p";
                        break;
                    case ("dat"):
                        strFormatValue = "dd/MM/yyyy";
                        break;
                    case ("datfull"):
                        strFormatValue = "dd/MM/yyyy hh:mm:ss";
                        break;
                }

                objField.DataFormatString = "{0:" + strFormatValue + "}";
            }

			return objField;
		}

        private BoundColumn AddColumnGrid(string strHeader, string strColumn, int intAlign, string strFormatValue, bool blnVisible)
        {
            BoundColumn objField = (strFormatValue.Trim() == "") ? AddColumnGrid(strHeader, strColumn, intAlign) : AddColumnGrid(strHeader, strColumn, intAlign, strFormatValue);
            objField.Visible = blnVisible;
            return objField;
        }

		public void AttributesTRTD(Object sender, DataGridItemEventArgs e)
		{
            if (e.Item.ItemIndex > -1)
            {
                e.Item.Attributes.Add("onmouseover", "javascript:paintLine(this,true);");
                e.Item.Attributes.Add("onmouseout", "javascript:paintLine(this,false);");
            }
		}

		public DataView ReturnDataSource()
		{
			DataView objDv = new DataView();

			this._GridLength = -1;

			if(this._Xml != "")
			{
				if(this._ColumnsFormat.Trim() != "")
				{
					string[] arrColumnsName = this._ColumnsName.Split(chrDelimiter);
					string[] arrStrColumnsFormat = this._ColumnsFormat.Split(chrDelimiter);

					DataTable objDt = new DataTable();
					DataRow objDr;
					
					XmlDocument objXml = new XmlDocument();
					objXml.LoadXml(this._Xml);

					for(int i = 0; i < arrColumnsName.Length; i++)
					{
						switch(arrStrColumnsFormat[i])
						{
							case("int"):
								objDt.Columns.Add(new DataColumn(arrColumnsName[i], typeof(int)));
								break;
							case("dcm"):
								objDt.Columns.Add(new DataColumn(arrColumnsName[i], typeof(decimal)));
								break;
							case("cur"):
								objDt.Columns.Add(new DataColumn(arrColumnsName[i], typeof(double)));
								break;
							case("pct"):
								objDt.Columns.Add(new DataColumn(arrColumnsName[i], typeof(decimal)));
								break;
							case("dat"):
								objDt.Columns.Add(new DataColumn(arrColumnsName[i], typeof(DateTime)));
								break;
							case("datfull"):
								objDt.Columns.Add(new DataColumn(arrColumnsName[i], typeof(DateTime)));
								break;
							default:
								objDt.Columns.Add(new DataColumn(arrColumnsName[i], typeof(string)));
								break;
						}
					}

					for(int i = 0; i < objXml.DocumentElement.ChildNodes.Count; i++)
					{
						objDr = objDt.NewRow();
 
						XmlAttributeCollection objAttribute = objXml.DocumentElement.ChildNodes[i].Attributes;

						for(int w = 0 ; w < arrColumnsName.Length; w++)
                            //objDr[w] = objAttribute.GetNamedItem(arrColumnsName[w]).Value;
                            objDr[w] = (objAttribute.GetNamedItem(arrColumnsName[w]) != null) ? objAttribute.GetNamedItem(arrColumnsName[w]).Value : "";
 
						objDt.Rows.Add(objDr);
					}

					objDv = new DataView(objDt);

					this._GridLength = objXml.DocumentElement.ChildNodes.Count;
				}
				else
				{
					StringReader objRdr = new StringReader(this._Xml);

					DataSet objDs = new DataSet();

					objDs.ReadXml(objRdr);
                    
                    objRdr.Close();
                    objRdr.Dispose();
                    objRdr = null;

    				if(objDs.Tables.Count > 0)
					{
						objDv = new DataView(objDs.Tables[0]);
						this._GridLength = objDv.Count;
					}
					else
					{
						objDv = new DataView();
						this._GridLength = 0;
					}

                    objDs.Dispose();
                    objDs = null;
				}
			}

			if(this._GridLength > 0 && (this._ColumnSorting != null || this._InitialColumnSorting != null))
				objDv.Sort = (this._ColumnSorting.ToString().Trim() != "") ? this._ColumnSorting : this._InitialColumnSorting;

			return objDv;
		}
	}
}
