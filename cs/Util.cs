using System;
using System.Xml;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using System.Security;
//using System.Security.Permissions;

namespace GenericCLX.CS
{
    /// <summary>
    /// Summary description for Util.
    /// </summary>
    /// 

     //Demand the zone requirement for the calling application.
    //[ZoneIdentityPermission(SecurityAction.Demand, Zone = SecurityZone.Trusted)]
    public class Util
    {

        private string _Server;
        public string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }

        private string _DB;
        public string DB
        {
            get { return _DB; }
            set { _DB = value; }
        }

        private string _User;
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _WebServer;
        public string WebServer
        {
            get { return _WebServer; }
            set { _WebServer = value; }
        }

        private string _WebServerIP;
        public string WebServerIP
        {
            get { return _WebServerIP; }
            set { _WebServerIP = value; }
        }

        private string _WebServerPort;
        public string WebServerPort
        {
            get { return _WebServerPort; }
            set { _WebServerPort = value; }
        }

        private string _ReportServer;
        public string ReportServer
        {
            get { return _ReportServer; }
            set { _ReportServer = value; }
        }

        private string _ReportServerIP;
        public string ReportServerIP
        {
            get { return _ReportServerIP; }
            set { _ReportServerIP = value; }
        }

        private string _ReportServerPort;
        public string ReportServerPort
        {
            get { return _ReportServerPort; }
            set { _ReportServerPort = value; }
        }

        private string _SiteName;
        public string SiteName
        {
            get { return _SiteName; }
            set { _SiteName = value; }
        }

        private string _ProjectName;
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        private string _Module;
        public string Module
        {
            get { return _Module; }
            set { _Module = value; }
        }

        private string _Location;
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        private string _LocationUrlFull;
        public string LocationUrlFull
        {
            get { return _LocationUrlFull; }
            set { _LocationUrlFull = value; }
        }

        //private string _ConnectionString;
        //public string ConnectionString
        //{
        //    get { return _ConnectionString; }
        //    set { _ConnectionString = value; }
        //}

        //private string _ConnectionStringXML;
        //public string ConnectionStringXML
        //{
        //    get { return _ConnectionStringXML; }
        //    set { _ConnectionStringXML = value; }
        //}

        //public static string ProjectName = "DWWeb";
        //public static string Module = "Web";
        public static DateTime NullDateTime = Convert.ToDateTime("1900-01-01 00:00:00");
        public static string StrNullDateTime = "'1900-01-01 00:00:00'";
        public static string NowDateTime = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd hh:mm:ss");
        //public static string Location = "C:\\inetpub\\wwwroot\\GenericCLX\\";
        //public static string LocationUrl = "/" + ProjectName + "/";
        //public static string LocationUrlFull = "http://localhost/GenericCLX/";
         
        public Util() 
        {
            this._Server = "";
            this._DB = "";
            this._User = "";
            this._Password = "";
            this._WebServer = "";
            this._WebServerIP = "";
            this._WebServerPort = "";
            this._ReportServer = "";
            this._ReportServerIP = "";
            this._ReportServerPort = "";
            this._SiteName = "";
            this._ProjectName = "";
            this._Module = "";
            this._Location = "";
            this._LocationUrlFull = "";
            //this._ConnectionString = "";
            //this._ConnectionStringXML = "";
            GetConfig("");
        }
        public Util(string p_strConfiguracoes)
        {
            this._Server = "";
            this._DB = "";
            this._User = "";
            this._Password = "";
            this._WebServer = "";
            this._WebServerIP = "";
            this._WebServerPort = "";
            this._ReportServer = "";
            this._ReportServerIP = "";
            this._ReportServerPort = "";
            this._SiteName = "";
            this._ProjectName = "";
            this._Module = "";
            this._Location = "";
            this._LocationUrlFull = "";
            //this._ConnectionString = "";
            //this._ConnectionStringXML = "";
            GetConfig(p_strConfiguracoes);
        }

        public void GetConfig(string p_strConfiguracoes)
        {
            if (p_strConfiguracoes == null)
                p_strConfiguracoes = "DEFAULT";

            p_strConfiguracoes = p_strConfiguracoes.ToUpper();

            if (p_strConfiguracoes.Trim() == "")
                p_strConfiguracoes = "DEFAULT";

            //XmlElement objDocumentElement = XML.Load("configuracoes/configuracoes.xml");
            //XmlElement objDocumentElement = XML.Load("~/configuracoes/configuracoes.xml");

            ////UOL HOST
            //XmlElement objDocumentElement = XML.Load("E:\\home\\cobrancasu\\web\\configuracoes\\configuracoes.xml");

            //LOCAL HOST
            XmlElement objDocumentElement = XML.Load("C:\\inetpub\\wwwroot\\csf\\configuracoes\\configuracoes.xml");

            _SiteName = (objDocumentElement.ChildNodes[0].SelectSingleNode("SITENAME") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("SITENAME").Attributes.GetNamedItem("VALUE").Value) : "";
            _ProjectName = (objDocumentElement.ChildNodes[0].SelectSingleNode("PROJECTNAME") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("PROJECTNAME").Attributes.GetNamedItem("VALUE").Value) : "";
            _Module = (objDocumentElement.ChildNodes[0].SelectSingleNode("MODULE") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("MODULE").Attributes.GetNamedItem("VALUE").Value) : "";
            _Server = (objDocumentElement.ChildNodes[0].SelectSingleNode("SERVER") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("SERVER").Attributes.GetNamedItem("VALUE").Value) : "";
            _DB = (objDocumentElement.ChildNodes[0].SelectSingleNode("DB") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("DB").Attributes.GetNamedItem("VALUE").Value) : "";
            _User = (objDocumentElement.ChildNodes[0].SelectSingleNode("USER") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("USER").Attributes.GetNamedItem("VALUE").Value) : "";
            _Password = (objDocumentElement.ChildNodes[0].SelectSingleNode("PASSWORD") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("PASSWORD").Attributes.GetNamedItem("VALUE").Value) : "";
            _WebServer = (objDocumentElement.ChildNodes[0].SelectSingleNode("WEBSERVER") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("WEBSERVER").Attributes.GetNamedItem("VALUE").Value) : "";
            _WebServerIP = (objDocumentElement.ChildNodes[0].SelectSingleNode("WEBSERVERIP") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("WEBSERVERIP").Attributes.GetNamedItem("VALUE").Value) : "";
            _WebServerPort = (objDocumentElement.ChildNodes[0].SelectSingleNode("WEBSERVERPORT") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("WEBSERVERPORT").Attributes.GetNamedItem("VALUE").Value) : "";
            _ReportServer = (objDocumentElement.ChildNodes[0].SelectSingleNode("REPORTSERVER") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("REPORTSERVER").Attributes.GetNamedItem("VALUE").Value) : "";
            _ReportServerIP = (objDocumentElement.ChildNodes[0].SelectSingleNode("REPORTSERVERIP") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("REPORTSERVERIP").Attributes.GetNamedItem("VALUE").Value) : "";
            _ReportServerPort = (objDocumentElement.ChildNodes[0].SelectSingleNode("REPORTSERVERPORT") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("REPORTSERVERPORT").Attributes.GetNamedItem("VALUE").Value) : "";
            _Location = (objDocumentElement.ChildNodes[0].SelectSingleNode("FILELOCATION") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("FILELOCATION").Attributes.GetNamedItem("VALUE").Value) : "";
            _LocationUrlFull = (objDocumentElement.ChildNodes[0].SelectSingleNode("FULLURLLOCATION") != null) ? Convert.ToString(objDocumentElement.ChildNodes[0].SelectSingleNode("FULLURLLOCATION").Attributes.GetNamedItem("VALUE").Value) : "";

            ////UOL HOST
            //if (_User == null || _User.ToString().Trim() == "") _User = "cobrancasu1";
            //if (_Password == null || _Password.ToString().Trim() == "") _Password = "csf2011uolhost";

            //LOCAL HOST
            if (_User == null || _User.ToString().Trim() == "") _User = "csf_user";
            if (_Password == null || _Password.ToString().Trim() == "") _Password = "csf123!@#";
        }

        public string ConnectionString()
        {
            return  "Server=" + _Server + ";UID=" + _User + ";PWD=" + _Password + ";Connection Timeout=30;Database=" + _DB;
        }

        public string ConnectionStringXML()
        {
            return "Provider=SQLOLEDB.1;Password=" + _Password + ";Persist Security Info=True;User ID=" + _User + ";Initial Catalog=" + _DB + ";Connection Timeout=30;Data Source=" + _Server;
        }

        //public static string ReturnServer(string p_strDatabase)
        //{
        //    return ReturnServer(p_strDatabase);
        //}

        //public string ReturnServer(string p_strDatabase, string p_strLocation)
        //{
        //    if (Location.Trim() == "") GetConfigs(p_strDatabase);

        //    p_strLocation = Location;

        //    if (p_strLocation.Trim() != "")
        //    {
        //        p_strLocation = "C:\\";
        //    }

        //    if (p_strDatabase == null)
        //        p_strDatabase = "DEFAULT";

        //    p_strDatabase = p_strDatabase.ToUpper();

        //    if (p_strDatabase.Trim() == "")
        //        p_strDatabase = "DEFAULT";
        //    //else if (p_strDatabase.Trim() == "TODOS")
        //    //    p_strDatabase = "UTIL";

        //    System.Xml.XmlDocument objXmlDocumentDB = new System.Xml.XmlDocument();
        //    objXmlDocumentDB.Load(p_strLocation + "configuracoes.xml");
        //    return (objXmlDocumentDB.DocumentElement.GetElementsByTagName(p_strDatabase.ToUpper().Trim()).Item(0).Attributes.GetNamedItem("SERVER") != null) ? Convert.ToString(objXmlDocumentDB.DocumentElement.GetElementsByTagName(p_strDatabase.ToUpper().Trim()).Item(0).Attributes.GetNamedItem("SERVER").Value) : "";

        //    //if (System.IO.File.Exists(p_strLocation + "db.xml"))
        //    //{
        //    //    System.Xml.XmlDocument objXmlDocumentDB = new System.Xml.XmlDocument();
        //    //    objXmlDocumentDB.Load(p_strLocation + "db.xml");

        //    //    if (objXmlDocumentDB.DocumentElement.GetElementsByTagName(p_strDatabase.ToUpper().Trim()).Count > 0)
        //    //        return objXmlDocumentDB.DocumentElement.GetElementsByTagName(p_strDatabase.ToUpper().Trim()).Item(0).Attributes.GetNamedItem("SERVER").Value;
        //    //    else
        //    //        return "RODRIGO";
        //    //}
        //    //else
        //    //    return "RODRIGO";
        //}

        public void SetConn(ref string p_intServer, ref string p_intDB, ref string p_intUser, ref string p_intPassword)
        {
            p_intServer = _Server;
            p_intDB = _DB;
            p_intUser = _User;
            p_intPassword = _Password;
        }

        public static bool TreatedError(string p_strError)
        {
            string strError = Functions.FilterError(p_strError).ToUpper();
            return (strError.IndexOf("TIMEOUT EXPIRED") != -1 || strError.IndexOf("OBJECT REFERENCE NOT") != -1 || strError.IndexOf("OBJECT VARIABLE OR WITH") != -1);
        }
    }
}
