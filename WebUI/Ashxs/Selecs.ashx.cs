using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WebUI.Utilities;

namespace WebUI.Ashxs
{
    /// <summary>
    /// Selecs 的摘要说明
    /// </summary>
    public class Selecs : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request["action"].ToString())
            {
                case "getbmlist":
                    getbmlist(context);
                    break;
                case "getxmlist":
                    getxmlist(context);
                    break;
                default:
                    break;

            }
        }

        public void getbmlist(HttpContext context)
        {
            string sqlstr = "SELECT NODE,DISPLAYTEXT FROM RS_BMTV WHERE PARENTNODE=0 ORDER BY NODE";
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            string json = JsonConvert.SerializeObject(dt);
            context.Response.Write(json);
        }
        public void getxmlist(HttpContext context)
        {
            string sqlstr = "SELECT ID,LS_GH,LS_XM FROM RS_USERS ORDER BY ID";
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            string json = JsonConvert.SerializeObject(dt);
            context.Response.Write(json);
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