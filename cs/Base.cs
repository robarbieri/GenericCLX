using System;
using System.Xml;
using System.Data.SqlClient;
using GenericCLX.CS;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using System.Security;
//using System.Security.Permissions;

namespace GenericCLX.CS
{
	/// <summary>
	/// Summary description for Base.
	/// </summary>
    /// 

    //// Demand the zone requirement for the calling application.
    //[ZoneIdentityPermission(SecurityAction.Demand, Zone = SecurityZone.Trusted)]
    public class Base : Conn 
	{
		public Base()
		{
			
		}

		private string _Xml;
		public string Xml
		{
			get { return _Xml; }
			set { _Xml = value; }
		}

		private XmlAttributeCollection _Attribute;
		public XmlAttributeCollection Attribute
		{
			get { return _Attribute; }
			set { _Attribute = value; }
		}

		public bool Loading()
		{
            if (this._Xml != "")
            {
                XmlElement objXmlElement = XML.LoadXml(this._Xml);

                if (objXmlElement.FirstChild != null)
                {
                    this._Attribute = objXmlElement.FirstChild.Attributes;

                    return true;
                }
                else
                    return false;
            }else
                return false;
		}

		public virtual string Select()
		{
			return base.ReturnStrXml();
		}

		public virtual void InsertUpdate()
		{
			base.ExecuteNonQuery();
		}

		public virtual void Delete()
		{
			base.ExecuteNonQuery();
		}

        public virtual int ExecuteScalar()
        {
            return base.ExecuteScalar();
        }

        public virtual int ExecuteScalar(string p_strSql)
        {
            return base.ExecuteScalar();
        }
	}
}
