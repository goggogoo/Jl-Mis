using Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebUI.Utilities;

namespace WebUI.Ashxs
{
    /// <summary>
    /// Tktopr 的摘要说明
    /// </summary>
    public class Tktopr : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request["action"].ToString())
            {
                case "gettktlistjson":
                    gettktlistjson(context);
                    break;
                case "gettktdetlistjson":
                    gettktdetlistjson(context);
                    break;
                case "gettktsumrowjson":
                    gettktsumrowjson(context);
                    break;
                case "savetos":
                    savetos(context);
                    break;
                case "savesumform":
                    savesumform(context);
                    break;
                case "savetktdet":
                    savetktdet(context);
                    break;
                case "sendtkt":
                    sendtkt(context);
                    break;


                default: break;
            }
        }
        EFDbContext efcont = new EFDbContext();
        public void gettktlistjson(HttpContext context)
        {
            int pageNumber = Convert.ToInt32(context.Request["page"]); //获取当前页码，easyui默认传到后台
            int pageSize = Convert.ToInt32(context.Request["rows"]);
            int sign = Convert.ToInt32(context.Request["sign"]);
            string ssign = "";
            if (sign == 0)
            {
                ssign = "WHERE LLSIGN <= 0";
            }
            else
            {
                ssign = "WHERE LLSIGN = " + sign.ToString();
            }
            int total = 0;
            string sqlstr = "SELECT * FROM(SELECT T.*, ROWNUM RN FROM" +
                "(SELECT ID,LSNO,LLSIGN,LSRW,to_char(LDTOPRS,'yyyy-mm-dd') as LDTOPRS FROM TICK_OPR_SUM " + ssign + " ORDER BY ID DESC)T" +
                " WHERE ROWNUM <= " + ((pageNumber - 1) * pageSize + pageSize).ToString() +
                ") WHERE RN > " + ((pageNumber - 1) * pageSize).ToString();
            ;
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            total = Convert.ToInt32(new Dbopr().getstr("SELECT COUNT(*) FROM TICK_OPR_SUM"));

            var data = new
            {
                total = total,
                rows = dt
            };

            string json = JsonConvert.SerializeObject(data);
            context.Response.Write(json);
        }
        public void gettktdetlistjson(HttpContext context)
        {
            string lspid = Convert.ToString(context.Request["pid"]);
            string sqlstr = "SELECT * FROM TICK_OPR_DET WHERE PID=" + lspid + "  ORDER BY ID ASC";
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            var data = new
            {
                rows = dt
            };

            string json = JsonConvert.SerializeObject(data);
            context.Response.Write(json);
        }

        public void gettktsumrowjson(HttpContext context)
        {
            string lsid = Convert.ToString(context.Request["id"]);
            string sqlstr = "SELECT * FROM TICK_OPR_SUM WHERE ID = " + lsid;
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];

            string jsonstr = JsonConvert.SerializeObject(dt);
            JObject jsonobj = (JObject)(((JArray)(JsonConvert.DeserializeObject(jsonstr)))[0]);
            string json = JsonConvert.SerializeObject(jsonobj);
            context.Response.Write(json);
        }

        public void savetos(HttpContext context)
        {
            string lsczr = context.Request["LSCZR"];
            string lsdw = context.Request["LSDW"];
            string lsrw = context.Request["LSRW"];
            int lltype = Convert.ToInt32(context.Request["LLTYPE"]);
            int llsign = 0;
            int id = Convert.ToInt32(new Dbopr().getstr("SELECT SEQ_DOC.NEXTVAL FROM DUAL"));
            ArrayList arrl = new ArrayList();
            OracleParameter[] op = new OracleParameter[] { new OracleParameter(":id", id), new OracleParameter(":lltype", lltype),
                    new OracleParameter(":llsign", llsign), new OracleParameter(":lsdw", lsdw),new OracleParameter(":lsczr", lsczr), new OracleParameter(":lsrw", lsrw),
                    };


            int i = new Dbopr().getexc("INSERT INTO TICK_OPR_SUM(ID,LLTYPE,LLSIGN,LSDW,LSCZR,LSRW)VALUES(:id,:lltype,:llsign,:lsdw,:lsczr,:lsrw)", op);
            //int i = new Dbopr().getexc("INSERT INTO TICK_OPR_SUM(ID,LLTYPE,LLSIGN,LSDW,LSCZR,LSRW)VALUES(1,0,0,'kkk','lll','kkk')");
            context.Response.Write(i.ToString() + lsrw);
        }
        public void savesumform(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["ID"]);
            int lltype = Convert.ToInt32(context.Request["LLTYPE"]);
            int llsign = Convert.ToInt32(context.Request["LLSIGN"]);
            string lsno = context.Request["LSNO"];
            string lsdw = context.Request["LSDW"];
            string lsrw = context.Request["LSRW"];
            string lsczr = context.Request["LSCZR"];
            string lsjhr = context.Request["LSJHR"];
            string lsfzr = context.Request["LSFZR"];
            string lszzr = context.Request["LSZZR"];
            string lsbz = context.Request["LSBZ"];
            DateTime? ldtoprs, ldtopre;
            ldtoprs = dtparse(context.Request["LDTOPRS"]);
            ldtopre = dtparse(context.Request["LDTOPRE"]);

            OracleParameter[] op = new OracleParameter[] { new OracleParameter(":lltype", lltype),
                    new OracleParameter(":llsign", llsign), new OracleParameter(":lsno", lsno), new OracleParameter(":lsdw", lsdw), new OracleParameter(":lsrw", lsrw),
                    new OracleParameter(":lsczr", lsczr),new OracleParameter(":lsjhr", lsjhr),new OracleParameter(":lsfzr", lsfzr),new OracleParameter(":lszzr", lszzr), new OracleParameter(":lsbz", lsbz),
                    new OracleParameter(":ldtoprs", ldtoprs), new OracleParameter(":ldtopre", ldtopre),
                    new OracleParameter(":id", id),
            };


            int i = new Dbopr().getexc("UPDATE TICK_OPR_SUM SET LLTYPE=:lltype,LLSIGN=:llsign,LSNO=:lsno,LSDW=:lsdw,LSRW=:lsrw,LSCZR=:lsczr,LSJHR=:lsjhr,LSFZR=:lsfzr,LSZZR=:lszzr,LSBZ=:lsbz,LDTOPRS=:ldtoprs,LDTOPRE=:ldtopre WHERE ID=:id", op);


            context.Response.Write(i.ToString() + lsrw);
        }
        public void savetktdet(HttpContext context)
        {
            int rowc = 0;
            string jsonstr = context.Request["param"];
            JObject jobj = (JObject)JsonConvert.DeserializeObject(jsonstr);
            JArray jaryinst = (JArray)jobj["insertedrows"];
            JArray jarydel = (JArray)jobj["deletedrows"];
            JArray jaryup = (JArray)jobj["updatedrows"];
            JArray jaryuporins = new JArray(jaryup.Union(jaryinst));
            int pid = (int)jobj["pid"];
            foreach (JObject jobjinst in jaryuporins)
            {
                int detid = jobjinst.Value<int>("ID");
                if (detid == 0)
                {
                    detid = new Dbopr().getnextid();
                }
                int isnew = 0;
                TICK_OPR_DET tickdet = efcont.TICK_OPR_DET.FirstOrDefault(p => p.ID == detid);
                if (tickdet == null)
                {
                    tickdet = new TICK_OPR_DET();
                    tickdet.ID = detid;
                    isnew = 1;
                }
                if (tickdet != null)
                {
                    tickdet = new Common().getitem(tickdet, jobjinst, "ID");
                }
                if (isnew == 1)
                {
                    tickdet.PID = pid;
                    efcont.TICK_OPR_DET.Add(tickdet);
                }
                rowc++;
            }
            foreach (JObject jobjdel in jarydel)
            {
                int detid = jobjdel.Value<int>("ID");
                TICK_OPR_DET tickdet = efcont.TICK_OPR_DET.FirstOrDefault(p => p.ID == detid);

                if (tickdet != null)
                {
                    efcont.TICK_OPR_DET.Remove(tickdet);
                }
                rowc++;
            }

            efcont.SaveChanges();

            context.Response.Write("更新:" + rowc.ToString());
        }
        public void sendtkt(HttpContext context)
        {
            string sid = context.Request["id"].Trim();
            string ssign = context.Request["sign"].Trim();
            if (string.IsNullOrEmpty(sid)) return;
            int i = new Dbopr().getexc("UPDATE TICK_OPR_SUM SET LLSIGN = " + ssign + " WHERE ID = " + sid + "");
            context.Response.Write(i.ToString());
        }

        public static DateTime? dtparse(string text)
        {
            DateTime date;
            return DateTime.TryParse(text, out date) ? date : (DateTime?)null;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}