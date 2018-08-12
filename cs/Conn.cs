using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Microsoft.Data.SqlXml;
using ADODB;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using System.Security;
//using System.Security.Permissions;

namespace GenericCLX.CS
{
    /// <summary>
    /// Summary description for Conn.
    /// </summary>
    /// 

    //// Demand the zone requirement for the calling application.
    //[ZoneIdentityPermission(SecurityAction.Demand, Zone = SecurityZone.Trusted)]
    public class Conn
    {
        private bool _CloseConn;
        public bool CloseConn
        {
            get { return _CloseConn; }
            set { _CloseConn = value; }
        }

        private Connection _AdodbConn;
        public Connection AdodbConn
        {
            get { return _AdodbConn; }
            set { _AdodbConn = value; }
        }

        /*
        private SqlCommand _Cmd;
        public virtual SqlCommand Cmd
        {
            get { return _Cmd; }
            set { _Cmd = value; }
        }
        */

        private SqlXmlCommand _XmlCmd;
        public virtual SqlXmlCommand XmlCmd
        {
            get { return _XmlCmd; }
            set { _XmlCmd = value; }
        }

        private SqlConnection _SqlConn;
        public virtual SqlConnection SqlConn
        {
            get { return _SqlConn; }
            set { _SqlConn = value; }
        }

        private SqlTransaction _SqlTran;
        public virtual SqlTransaction SqlTran
        {
            get { return _SqlTran; }
            set { _SqlTran = value; }
        }

        private string _Error;
        public virtual string Error
        {
            get { return _Error; }
            set { _Error = value; }
        }

        private string _Sql;
        public virtual string Sql
        {
            get { return _Sql; }
            set { _Sql = value; }
        }

        private string _Server;
        public virtual string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }

        private string _DB;
        public virtual string DB
        {
            get { return _DB; }
            set { _DB = value; }
        }

        private string _User;
        public virtual string User
        {
            get { return _User; }
            set { _User = value; }
        }

        private string _Password;
        public virtual string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private int _CountError;
        /*public int CountError
        {
            get { return _CountError; }
            set { _CountError = value; }
        }*/

        private TimeSpan _TimeQuery;
        public TimeSpan TimeQuery
        {
            get { return _TimeQuery; }
            set { _TimeQuery = value; }
        }

        public Conn()
        {
            this._CloseConn = true;
            //this._Cmd = null;
            this._XmlCmd = null;
            this._SqlConn = null;
            this._SqlTran = null;
            this._Error = "";
            this._Sql = "";
            this._CountError = 0;
            this._TimeQuery = new TimeSpan();
        }

        public void CleanParameters()
        {
            this._Error = "";
            this._Sql = "";
        }

        public void Connect()
        {
            try
            {
                if (this._SqlConn == null || this._SqlConn.State == ConnectionState.Closed || this._SqlConn.State == ConnectionState.Broken)
                {
                    //SetConn();
                    GenericCLX.CS.Util objUtil = new GenericCLX.CS.Util();
                    //objUtil.GetConfig("");
                    this._SqlConn = new SqlConnection(objUtil.ConnectionString());
                    this._SqlConn.Open();
                }
            }
            catch (Exception e)
            {
                this.Error = e.Message;
            }
        }

        public void CloseConnect()
        {
            if (this._SqlConn != null)
            {
                this._SqlConn.Close();
                this._SqlConn.Dispose();
                this._SqlConn = null;
            }
        }

        public void BeginTransaction()
        {
            this.CommitTransaction();
            this.Connect();
            this._SqlTran = this._SqlConn.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (this._SqlTran != null)
            {
                this._SqlTran.Commit();
                this.CloseTransaction();
                this.CloseConnect();
            }
        }

        public void RollbackTransaction()
        {
            if (this._SqlTran != null)
            {
                this._SqlTran.Rollback();
                this.CloseTransaction();
                this.CloseConnect();
            }
        }

        public void CloseTransaction()
        {
            this._SqlTran.Dispose();
            this._SqlTran = null;
        }

        //RETORNA TABELA NO FORMATO DE STRING XML
        public string ReturnStrXml(string p_strSql) 
        {
            this._Sql = p_strSql;
            return ReturnStrXml();
        }

        //RETORNA TABELA NO FORMATO DE STRING XML
        public string ReturnStrXml()
        {
            string strXml = "";

            try
            {
                DateTime datStart = DateTime.Now;

                if (this._XmlCmd == null)
                {
                    SetConn();
                    GenericCLX.CS.Util objUtil = new GenericCLX.CS.Util();
                    //objUtil.GetConfig("");
                    _XmlCmd = new SqlXmlCommand(objUtil.ConnectionStringXML());
                    _XmlCmd.OutputEncoding = "ISO-8859-1";
                    _XmlCmd.RootTag = "ROOT";
                }

                _XmlCmd.CommandText = this._Sql;
                System.Xml.XmlReader objXr = _XmlCmd.ExecuteXmlReader();
                XmlDocument objXd = new XmlDocument();
                objXd.Load(objXr);
                strXml = objXd.OuterXml;
                objXd = null;
                objXr.Close();
                objXr = null;
                if (this._CloseConn) _XmlCmd = null;
                this._TimeQuery = Functions.DateDiff(datStart.ToLocalTime().ToString());
            }
            catch (Exception e)
            {
                if (TreatedError(e.Message)) this.ReturnStrXml();
            }

            return strXml;
        }

        //RETORNA TABELA NO FORMATO DATAREADER QUE EMBORA MAIS RÁPIDO É BEM MAIS LIMITADO COMPARADO AO DATABLE
        public SqlDataReader ReturnDr(string p_strSql)
        {
            SqlDataReader objDr = null;

            try
            {
                if (this._SqlConn == null || this._SqlConn.State == ConnectionState.Closed || this._SqlConn.State == ConnectionState.Broken)
                    this.Connect();

                SqlCommand objCmd = new SqlCommand(p_strSql, this._SqlConn);
                objDr = objCmd.ExecuteReader();
                if (this._CloseConn) this.CloseConnect();
                objCmd = null;
            }
            catch (Exception e)
            {
                if (TreatedError(e.Message)) this.ReturnDr(p_strSql);
            }

            return objDr;
        }

        //RETORNA PRIMEIRA TABELA DO DATASET NO FORMATO DATATABLE
        public DataTable ReturnDt(string p_strSql)
        {
            DataTable objDt = null;

            try
            {
                DataSet objDs = ReturnDs(p_strSql);
                if(objDs.Tables.Count > 0) objDt = objDs.Tables[0];
                objDs.Dispose();
                objDs = null;

            }
            catch (Exception e)
            {
                if (TreatedError(e.Message)) this.ReturnDt(p_strSql);
            }
            return objDt;
        }

        //RETORNA ARRAY DE TABELAS NO FORMATO DATASET
        public DataSet ReturnDs(string p_strSql)
        {
            DataSet objDs = null;

            try
            {
                if (this._SqlConn == null || this._SqlConn.State == ConnectionState.Closed || this._SqlConn.State == ConnectionState.Broken)
                    this.Connect();

                if (this.Error.Trim() == "")
                {
                    objDs = new DataSet();
                    SqlDataAdapter objAdpt = new SqlDataAdapter(p_strSql, this._SqlConn);
                    objAdpt.Fill(objDs);

                    if (this._CloseConn) this.CloseConnect();
                }
                else
                    objDs = null;
            }
            catch (Exception e)
            {
                if (TreatedError(e.Message))
                {
                    this.ReturnDs(p_strSql);
                }
                else
                {
                    this._Error = e.Message;
                    objDs = null;
                }
            }
            return objDs;
        }

        //RETORNA TABELA NO FORMATO DE RECORDSET
        public ADODB.Recordset ReturnRs(string p_strSql)
        {
           ADODB.Recordset objRS = new ADODB.Recordset();

            try
            {
                if (this._AdodbConn == null)
                {
                    SetConn();
                    this._AdodbConn = new Connection();
                    GenericCLX.CS.Util objUtil = new GenericCLX.CS.Util();
                    //objUtil.GetConfig("");
                    this._AdodbConn.Open(objUtil.ConnectionStringXML(), this._User, this._Password, 0);
                }

                objRS.CursorLocation = (ADODB.CursorLocationEnum) 3;

                objRS.Open(p_strSql, this._AdodbConn, (ADODB.CursorTypeEnum) 3, (ADODB.LockTypeEnum) 3 , 1);
                objRS.ActiveConnection = null;
            }
            catch (Exception e)
            {
                if (TreatedError(e.Message)) this.ReturnRs(p_strSql);
            }

            return objRS;
        }

        //EXECUTA INSTRUÇÃO SQL SE RETORNO
        public void ExecuteNonQuery(string p_strSql)
        {
            this._Sql = p_strSql;
            this.ExecuteNonQuery();
        }

        //EXECUTA INSTRUÇÃO SQL SE RETORNO
        public void ExecuteNonQuery()
        {
            try
            {
                if (this._SqlConn == null || this._SqlConn.State == ConnectionState.Closed || this._SqlConn.State == ConnectionState.Broken)
                    this.Connect();

                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = this._Sql;
                objCmd.Connection = this._SqlConn;
                objCmd.Transaction = this._SqlTran;
                objCmd.ExecuteNonQuery();

                if (this._CloseConn) this.CloseConnect();
            }
            catch (Exception e)
            {
                if (TreatedError(e.Message)) this.ExecuteNonQuery();
            }
        }

        //EXECUTA INSTRUÇÃO SQL RETORNANDO APENAS UM INTEIRO
        public int ExecuteScalar(string p_strSql)
        {
            this._Sql = p_strSql;
            return ExecuteScalar();
        }

        //EXECUTA INSTRUÇÃO SQL RETORNANDO APENAS UM INTEIRO
        public int ExecuteScalar()
        {
            int intID = 0;

            try
            {
                if (this._SqlConn == null || this._SqlConn.State == ConnectionState.Closed || this._SqlConn.State == ConnectionState.Broken)
                    this.Connect();

                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = this._Sql;
                objCmd.Connection = this._SqlConn;
                objCmd.Transaction = this._SqlTran;

                intID = Convert.ToInt32(objCmd.ExecuteScalar());

                if (this._CloseConn) this.CloseConnect();
            }
            catch (Exception e)
            {
                if (TreatedError(e.Message)) this.ExecuteScalar();
            }

            return intID;
        }

        //TRATA ERRO DE CONEXÕES, EXECUÇÕES...
        public bool TreatedError(string p_strError)
        {
            if (this._CountError < 3)
            {
                this._Error = Functions.FilterError(p_strError);

                p_strError = this._Error.ToUpper().Trim();

                if (p_strError.IndexOf("TIMEOUT EXPIRED") != -1 || p_strError.IndexOf("OBJECT REFERENCE") != -1 || p_strError.IndexOf("FAIL") != -1)
                {
                    this._CountError++;
                    this._SqlConn = null;
                    this.Connect();
                    this._Error = "";
                    return true;
                }
                else
                {
                    if (this._SqlTran != null)
                        this.RollbackTransaction();

                    return false;
                }
            }
            else
                return false;
        }

        public void SetConn()
        {
            //Util.Server = this._Server;
            //Util.DB = this._DB;
            //Util.User = this._User;
            //Util.Password = this._Password;

            GenericCLX.CS.Util objUtil = new GenericCLX.CS.Util();
            //objUtil.GetConfig("");
            objUtil.User = this._User;
            objUtil.Password = this._Password;
        }
    }
}
