using System;
using System.Xml;
using System.Data;
using System.IO;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using System.Security;
//using System.Security.Permissions;

namespace GenericCLX.CS
{
    /// <summary>
    /// Summary description for XML.
    /// </summary>
    /// 

    //// Demand the zone requirement for the calling application.
    //[ZoneIdentityPermission(SecurityAction.Demand, Zone = SecurityZone.Trusted)]
    public class XML
    {
        public XML() 
        {
        
        }

        public static XmlNode CreateNode(XmlDocument p_objXmlDocument, string p_strName)
        {
            XmlNode objXmlNode = p_objXmlDocument.CreateNode(XmlNodeType.Element, p_strName, "");
            return objXmlNode;
        }

        public static XmlAttribute CreateAttribute(XmlDocument p_objXmlDocument, string p_strName, string p_strValue)
        {
            XmlAttribute objXmlAttribute = p_objXmlDocument.CreateAttribute(p_strName);
            objXmlAttribute.Value = p_strValue;
            return objXmlAttribute;
        }

        public static int LengthXml(string p_strXml)
        {
            XmlDocument objXmlDocument = new XmlDocument();

            if (p_strXml.Trim() != "")
            {
                try
                {
                    objXmlDocument.LoadXml(XML.CleanXml(p_strXml));
                    return objXmlDocument.DocumentElement.ChildNodes.Count;
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }

        public static bool ExistsChildNodes(string p_strXml)
        {
            return (p_strXml != "" && p_strXml.ToUpper().IndexOf("<ROOT></ROOT>") == -1 && p_strXml.ToUpper().IndexOf("<ROOT/>") == -1);
        }

        public static XmlElement Load(string p_strPath)
        {
            XmlDocument objXmlDocument = new XmlDocument();
            if (p_strPath.Trim() != "")
                objXmlDocument.Load(p_strPath);

            return objXmlDocument.DocumentElement;
        }

        public static XmlElement LoadXml(string p_strXml)
        {
            XmlDocument objXmlDocument = new XmlDocument();
            if (p_strXml.Trim() != "")
                objXmlDocument.LoadXml(p_strXml);
            return objXmlDocument.DocumentElement;
        }

        public static XmlDocument ConvertXmlNodeListToXmlDocument(XmlNodeList p_objXmlNodeList)
        {
            XmlDocument objXmlDocument = new XmlDocument();
            objXmlDocument.AppendChild(objXmlDocument.CreateXmlDeclaration("1.0", "iso-8859-1", null));
            objXmlDocument.AppendChild(objXmlDocument.CreateElement("ROOT"));

            foreach (XmlNode objXmlNode in p_objXmlNodeList)
            {
                if (objXmlNode.Name != "ROOT")
                    objXmlDocument.DocumentElement.AppendChild(objXmlDocument.ImportNode(objXmlNode, true));
            }

            return objXmlDocument;
        }

        /*public static XmlDocument ConvertXmlNodeToXmlDocument(XmlNode p_objXmlNode)
        {
            XmlDocument objXmlDocument = new XmlDocument();
            objXmlDocument.AppendChild(objXmlDocument.CreateXmlDeclaration("1.0", "iso-8859-1", null));
            objXmlDocument.AppendChild(objXmlDocument.CreateElement("ROOT"));

            foreach (XmlNode objXmlNode in p_objXmlNode)
            {
                if (objXmlNode.Name != "ROOT")
                    objXmlDocument.DocumentElement.AppendChild(objXmlDocument.ImportNode(objXmlNode, true));
            }

            return objXmlDocument;
        }*/

        public static XmlDocument ReturnXmlDocument()
        {
            XmlDocument objXmlDocument = new XmlDocument();
            objXmlDocument.LoadXml("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><ROOT></ROOT>");
            return objXmlDocument;
        }

        public static XmlElement ReturnXmlElement()
        {
            XmlDocument objXmlDocument = ReturnXmlDocument();
            return objXmlDocument.DocumentElement;
        }

        public static XmlDocument ReturnXmlDocument(string p_strXml)
        {
            XmlDocument objXmlDocument = new XmlDocument();
            objXmlDocument.LoadXml(p_strXml);
            return objXmlDocument;
        }

        public static string ReturnInnerRoot(string p_strXml)
        {
            p_strXml = p_strXml.Replace("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>", "").Replace("<?xml version=\"1.0\" encoding=\"ISO8859-1\"?>", "").Replace("<ROOT>", "").Replace("</ROOT>", "").Replace("<ROOT/>","");
            return p_strXml;
        }

        public static string InsertOuterRoot(string p_strXml)
        {
            return String.Concat("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><ROOT>", p_strXml, "</ROOT>");
        }

        public static string UnionXml(string p_strXml1, string p_strXml2)
        {
            return InsertOuterRoot(ReturnInnerRoot(p_strXml1) + ReturnInnerRoot(p_strXml2));
        }

        public static string CleanXml(string p_strXml)
        {
            string strSearch = "<root xmlns:sql=\"urn:schemas-microsoft-com:xml-sql\">";

            if (p_strXml.IndexOf(strSearch) != -1)
                p_strXml = p_strXml.Substring(p_strXml.IndexOf(strSearch) + strSearch.Length).Replace("</root>", "");

            p_strXml = p_strXml.Replace("<rs:data xmlns:rs=\"urn:schemas-microsoft-com:rowset\">", "");
            p_strXml = p_strXml.Replace("<rs:data>", "");
            p_strXml = p_strXml.Replace("</rs:data>", "");
            p_strXml = p_strXml.Replace("<rs:insert>", "");
            p_strXml = p_strXml.Replace("</rs:insert>", "");
            p_strXml = p_strXml.Replace("z:row xmlns:z=\"#RowsetSchema\"", "Xml");
            p_strXml = p_strXml.Replace("", " ");
            p_strXml = p_strXml.Replace("&amp;", "'");
            p_strXml = p_strXml.Replace("&quot;", "'");
            p_strXml = p_strXml.Replace("&APOS;", "'");
            p_strXml = p_strXml.Replace("&apos;", "'");
            p_strXml = p_strXml.Replace("&GT;", " ");
            p_strXml = p_strXml.Replace("&gt;", " ");
            p_strXml = p_strXml.Replace("", " ");
            p_strXml = p_strXml.Replace("<ROOT/>", " ");
            p_strXml = p_strXml.Replace("&LT;", " ");
            p_strXml = p_strXml.Replace("&lt;", " ");
            p_strXml = p_strXml.Replace("*", " ");

            if (p_strXml.ToUpper().IndexOf("<ROOT>") != -1)
                p_strXml = p_strXml.Substring(p_strXml.ToUpper().IndexOf("<ROOT>") + 6);

            if (p_strXml.ToUpper().IndexOf("</ROOT>") != -1)
                p_strXml = p_strXml.Substring(0, p_strXml.ToUpper().IndexOf("</ROOT>"));

            if(p_strXml.ToUpper().IndexOf("?XML VERSION") == -1)
                p_strXml = String.Concat("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><ROOT>", p_strXml, "</ROOT>");

            return p_strXml;
        }

        public static string ConvertDtToXml(System.Data.DataTable p_objDt)
        {
            string strXml = "";

            if(p_objDt.IsInitialized)
            {
                if(p_objDt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow objDataRow in p_objDt.Rows)
                    {
                        strXml += "<XML ";
                        foreach (System.Data.DataColumn objDataColumn in objDataRow.Table.Columns)
                        {
                            strXml += objDataColumn.Caption.ToUpper() + "=\"" + objDataRow[objDataColumn.Caption.ToUpper()].ToString().ToUpper() + "\" ";
                        }
                        strXml += "/>";
                    }
                }
            }

            return InsertOuterRoot(strXml);
        }

        /*public static string ConvertRsToXml(ADODB.Recordset p_objRs)
        {
            string strXml = "";

            while(! p_objRs.EOF)
            {
                strXml += "<XML ";
                
                foreach(ADODB.Field p_objRsField in p_objRs.Fields)
                    strXml += p_objRsField.Name.ToUpper() + "=\"" + p_objRsField.Value + "\" ";
                    
                strXml += "/>";

                p_objRs.MoveNext(); 
            }

            return InsertOuterRoot(strXml);
        }*/

        public static System.Data.DataView ConvertXmlToDv(string p_strXml)
        {
            DataView objDv = new DataView();

            if (p_strXml != "")
            {
                StringReader objRdr = new StringReader(p_strXml);
                DataSet objDs = new DataSet();

                objDs.ReadXml(objRdr);

                objRdr.Close();
                objRdr.Dispose();
                objRdr = null;

                if (objDs.Tables.Count > 0)
                    objDv = new DataView(objDs.Tables[0]);
                else
                    objDv = new DataView();

                objDs.Dispose();
                objDs = null;
            }

            return objDv;
        }
    }
}
