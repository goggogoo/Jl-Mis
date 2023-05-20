using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebUI.Utilities
{
    public class Dbopr
    {
        public OracleConnection getconn()
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["EFDbContext"].ToString();
            OracleConnection oraconn = new OracleConnection(constr);
            return oraconn;
        }
        public DataSet getds(string sqlstr)
        {
            using (OracleConnection oraconn = getconn()){
                try
                {
                    OracleDataAdapter da = new OracleDataAdapter(sqlstr, oraconn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
            }
        }
        public DataSet getds(string sqlstr,OracleParameter[]param)
        {
            using (OracleConnection oraconn = getconn())
            {
                try
                {
                    OracleCommand com = new OracleCommand(sqlstr, oraconn);
                    com.Parameters.AddRange(param);
                    OracleDataAdapter da = new OracleDataAdapter(com);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
            }
        }
        public OracleDataReader getdr(string sqlstr)
        {
            //OracleConnection oraconn = getconn();
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["EFDbContext"].ToString();
            OracleConnection oraconn = new OracleConnection(constr);
            try
            {
                oraconn.Open();
                OracleCommand com = new OracleCommand(sqlstr,oraconn);
                OracleDataReader dr = com.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch
            {
                oraconn.Close();
                return null;
            }

        }
        public OracleDataReader getdr(string sqlstr,OracleParameter[] param)
        {
            //OracleConnection oraconn = getconn();
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["EFDbContext"].ToString();
            OracleConnection oraconn = new OracleConnection(constr);
            try
            {
                oraconn.Open();
                OracleCommand com = new OracleCommand(sqlstr, oraconn);
                com.Parameters.AddRange(param);
                OracleDataReader dr = com.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch
            {
                oraconn.Close();
                return null;
            }

        }
        public object getstr(string sqlstr)
        {
            using (OracleConnection oraconn = getconn())
            {
                try
                {
                    oraconn.Open();
                    OracleCommand com = new OracleCommand(sqlstr, oraconn);
                    return com.ExecuteScalar();
                }
                catch
                {
                    return null;
                }
            }
        }
        public object getstr(string sqlstr,OracleParameter[]param)
        {
            using (OracleConnection oraconn = getconn())
            {
                try
                {
                    oraconn.Open();
                    OracleCommand com = new OracleCommand(sqlstr, oraconn);
                    com.Parameters.AddRange(param);
                    return com.ExecuteScalar();
                }
                catch
                {
                    return null;
                }
            }
        }
        public int getexc(string sqlstr)
        {
            using (OracleConnection oraconn = getconn())
            {
                try
                {
                    oraconn.Open();
                    OracleCommand com = new OracleCommand(sqlstr, oraconn);
                    return com.ExecuteNonQuery();
            }
                catch
            {
                return 0;
            }
        }
        }
        public int getexc(string sqlstr, OracleParameter[] param)
        {
            using (OracleConnection oraconn = getconn())
            {
                try
                {
                    oraconn.Open();
                    OracleCommand com = new OracleCommand(sqlstr, oraconn);
                    com.Parameters.AddRange(param);
                    return com.ExecuteNonQuery();
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int getnextid()
        {
            string idstr = getstr("SELECT SEQ_DOC.NEXTVAL FROM DUAL").ToString();
            return Convert.ToInt32(idstr);
        }
    }
}