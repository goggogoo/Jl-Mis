using Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using WebUI.Utilities;

namespace WebUI.Ashxs
{
    /// <summary>
    /// Staffmng 的摘要说明
    /// </summary>
    public class Staffmng : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request["action"].ToString())
            {
                case "getstafflistjson":
                    getstafflistjson(context);
                    break;
                case "getstaffrowjson":
                    getstaffrowjson(context);
                    break;
                case "getstaffimg":
                    getstaffimg(context);
                    break;
                case "delstaffrow":
                    delstaffrow(context);
                    break;
                case "savestaffrow":
                    savestaffrow(context);
                    break;
                case "savebmtv":
                    savebmtv(context);
                    break;
                case "getpartmtree":
                    getpartmtree(context);
                    break;
                case "getpartmtree1":
                    getpartmtree1(context);
                    break;

                default: break;
            }
        }
        public void getstafflistjson(HttpContext context)
        {
            int pageNumber = Convert.ToInt32(context.Request["page"]); 
            int pageSize = Convert.ToInt32(context.Request["rows"]);
            string querystr =  Convert.ToString(context.Request["querystr"]);
            int total = 0;
            string sqlstr ;
            if (string.IsNullOrEmpty(querystr))
            {
                querystr = "";
            }
            else {
                querystr = " WHERE LS_BZ LIKE '%" + querystr + "%'";
            }
            if (pageNumber == 0 && pageSize == 0) {
                sqlstr = "SELECT ID,LS_GH,LS_XM,LI_XB,LS_BZ FROM RS_USERS" + querystr + " ORDER BY ID";
            }
            else
            {
                sqlstr = "SELECT * FROM(SELECT T.*, ROWNUM RN FROM" +
                "(SELECT ID,LS_GH,LS_XM,LI_XB,LS_BZ FROM RS_USERS" + querystr + " ORDER BY ID)T" +
                " WHERE ROWNUM <= " + ((pageNumber - 1) * pageSize + pageSize).ToString() +
                ") WHERE RN > " + ((pageNumber - 1) * pageSize).ToString();
            }
            
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            total = Convert.ToInt32(new Dbopr().getstr("SELECT COUNT(*) FROM RS_USERS"));

            var data = new
            {
                total = total,
                rows = dt
            };

            string json = JsonConvert.SerializeObject(data);
            context.Response.Write(json);
        }

        public void getstaffrowjson(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["id"]);
            string sqlstr = "SELECT * FROM RS_USERS WHERE ID = " + id.ToString();
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];

            string jsonstr = JsonConvert.SerializeObject(dt);
            JObject jsonobj = (JObject)(((JArray)(JsonConvert.DeserializeObject(jsonstr)))[0]);
            string json = JsonConvert.SerializeObject(jsonobj);
            context.Response.Write(json);
        }

        public void getstaffimg(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["id"]);
            object obj=new object();
            using (OracleDataReader dr = new Dbopr().getdr("SELECT LB_ZP FROM RS_USERS WHERE ID = " + id.ToString()))
            {
                if (dr.Read())
                {
                    obj = dr["LB_ZP"];
                }
            }
            if (obj != System.DBNull.Value)
            {
                context.Response.BinaryWrite((byte[])obj);
            }
            else
            {
                //string ss1 = HttpContext.Current.Server.MapPath("~/content/images/nophoto.jpg");
                //string ss3 = HttpContext.Current.Server.MapPath("/content/images/nophoto.jpg");//均可
                //string ss4 = HttpContext.Current.Server.MapPath("content/images/nophoto.jpg");//相对路径
                //string ss2 = HttpContext.Current.Request.PhysicalApplicationPath + "content/images/nophoto.jpg";//均可

                FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/content/images/nophoto.jpg"), FileMode.Open);
                byte[] byteData = new byte[fs.Length];
                fs.Read(byteData, 0, byteData.Length);
                fs.Close();
                context.Response.BinaryWrite(byteData);
            }
        }
        public void delstaffrow(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["id"]);
            int result;
            result = new Dbopr().getexc("DELETE FROM RS_USERS WHERE ID = " + id.ToString());
            context.Response.Write(result);
        }
        public void savestaffrow(HttpContext context)
        {
            string jsonstr = context.Request["param"];
            JObject jsonobj = (JObject)JsonConvert.DeserializeObject(jsonstr);
            if (jsonobj.ContainsKey("editing")) jsonobj.Property("editing").Remove();
            int staffid;
            int.TryParse(jsonobj.Value<string>("ID"), out staffid);

            EFDbContext cont = new EFDbContext();
            RS_USERS user = cont.RS_USERS.FirstOrDefault(p => p.ID == staffid);
            int isnew = 0;
            if (user == null|| staffid==0)
            {
                user = new RS_USERS();
                isnew = 1;
            }
            user = new Common().getitem(user, jsonobj, "ID");

            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            HttpPostedFile file1 = context.Request.Files["file1"];
            int imglen = file1.ContentLength;
            Stream ImageStream;
            Byte[] ImageByte;
            if (file1.ContentLength > 0 && file1.ContentLength < 2048000)
            {
                ImageStream = file1.InputStream;
                ImageByte = new Byte[imglen];
                ImageStream.Read(ImageByte, 0, imglen);
                user.LB_ZP = ImageByte;
            }

            if (isnew == 1)
            {
                if (staffid == 0) { staffid = Convert.ToInt32(new Dbopr().getstr("SELECT SEQ_DOC.NEXTVAL FROM DUAL")); }
                user.ID = staffid;
                cont.RS_USERS.Add(user);
            }

            cont.SaveChanges();

            string json = JsonConvert.SerializeObject(jsonobj);
            context.Response.Write(json);

        }

        public void savebmtv(HttpContext context)
        {
            int rowc = 0;
            string jsonstr = context.Request["param"];
            JObject jobj = (JObject)JsonConvert.DeserializeObject(jsonstr);
            JArray jaryinorup = (JArray)jobj["inoruprows"];
            JArray jarydel = (JArray)jobj["deletedrows"];
            EFDbContext efcont = new EFDbContext();

            foreach (JObject jobjinorup in jaryinorup)
            {
                int isnew = 0;
                int node = jobjinorup.Value<int>("NODE");
                RS_BMTV bmtvitem = efcont.RS_BMTV.FirstOrDefault(p=>p.NODE==node);
                if (bmtvitem == null)
                {
                    bmtvitem = new RS_BMTV();
                    bmtvitem.NODE = (short)node;
                    isnew = 1;
                }
                bmtvitem = new Common().getitem(bmtvitem, jobjinorup, "NODE");
                if (isnew == 1) efcont.RS_BMTV.Add(bmtvitem);
                rowc++;
            }
            foreach (JObject jobjdel in jarydel)
            {
                int node = jobjdel.Value<int>("NODE");
                RS_BMTV bmtvitem = efcont.RS_BMTV.FirstOrDefault(p => p.NODE == node);
                if (bmtvitem != null)
                {
                    efcont.RS_BMTV.Remove(bmtvitem);
                    rowc++;
                }
            }

            efcont.SaveChanges();

            context.Response.Write("更新:" + rowc.ToString());

        }


        public class partmentt
        {
            public int NODE;
            public int PARENTNODE;
            public string DISPLAYTEXT;
            public string TAGDATA;
            public List<partmentt> children;
        }
        public void getpartmtree(HttpContext context)
        {
            DataTable dtpartm2 = new Dbopr().getds("SELECT NODE,PARENTNODE,DISPLAYTEXT,TAGDATA FROM RS_BMTV ORDER BY PARENTNODE,NODE").Tables[0];
            List<partmentt> partmenttlist = getpartmlist(dtpartm2, -1);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string result = JsonConvert.SerializeObject(partmenttlist, settings);

            if (context.Request["iscomb"] == "y")
            {
                result = result.Replace("\"NODE\"", "\"id\"");
                result = result.Replace("\"DISPLAYTEXT\"", "\"text\"");
                //result = result.Replace("NODE", "id");
                //result = result.Replace("DISPLAYTEXT", "text");

            }
            context.Response.Write(result);
        }
        public List<partmentt> getpartmlist(DataTable dt, int pid)
        {
            DataRow[] drws0 = dt.Select(string.Format("{0}={1}", "PARENTNODE", pid));
            List<partmentt> tree = new List<partmentt>();
            foreach (DataRow drw in drws0)
            {
                partmentt pt0 = new partmentt()
                {
                    NODE = (int)drw["NODE"],
                    PARENTNODE = (int)drw["PARENTNODE"],
                    DISPLAYTEXT = (string)drw["DISPLAYTEXT"],
                    TAGDATA = (string)drw["TAGDATA"],
                    children = getpartmlist(dt, (int)drw["NODE"])
                };
                tree.Add(pt0);
            }
            return tree;
        }







        DataTable dtpartm = new Dbopr().getds("SELECT NODE,PARENTNODE,DISPLAYTEXT,TAGDATA FROM RS_BMTV ORDER BY PARENTNODE,NODE").Tables[0];
        public void getpartmtree1(HttpContext context)
        {
            DataRow[] drws = dtpartm.Select();
            List<partmentt> partmenttlist = new List<partmentt>();
            foreach (DataRow drw in dtpartm.Select(string.Format("{0}={1}", "PARENTNODE", "0")))
            {
                partmentt pt = new partmentt();
                pt.NODE = (int)drw["NODE"];
                pt.PARENTNODE = (int)drw["PARENTNODE"];
                pt.DISPLAYTEXT = (string)drw["DISPLAYTEXT"];
                pt.TAGDATA = (string)drw["TAGDATA"];
                pt.children = new List<partmentt> { };
                DataRow[] drws0 = dtpartm.Select(string.Format("{0}={1}", "PARENTNODE", pt.NODE));
                if(drws0.Length>0) getpartmlist1(drws0, pt);
                partmenttlist.Add(pt);
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string result = JsonConvert.SerializeObject(partmenttlist, settings);
            context.Response.Write(result);
        }
        partmentt pt = new partmentt();
        public void getpartmlist1(DataRow[] drws, partmentt pt)
        {
            foreach (DataRow drw in drws)
            {
                partmentt pt0 = new partmentt();
                pt0.NODE = (int)drw["NODE"];
                pt0.PARENTNODE = (int)drw["PARENTNODE"];
                pt0.DISPLAYTEXT = (string)drw["DISPLAYTEXT"];
                pt0.TAGDATA = (string)drw["TAGDATA"];
                pt0.children = new List<partmentt> { };
                pt.children.Add(pt0);
                DataRow[] drws0 = dtpartm.Select(string.Format("{0}={1}", "PARENTNODE", pt0.NODE));
                if (drws0.Length > 0) getpartmlist1(drws0, pt0);
            }
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