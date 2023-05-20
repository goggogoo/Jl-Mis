﻿using Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    /// Docmng1 的摘要说明
    /// </summary>
    public class Carapp : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request["action"].ToString())
            {
                case "getnextid":
                    getnextid(context);
                    break;
                case "getwjhdlist":
                    getwjhdlist(context);
                    break;
                case "getwjhdlist2":
                    getwjhdlist(context);
                    break;
                case "getcarapplist":
                    getcarapplist(context);
                    break;
                case "getcphlist":
                    getcphlist(context);
                    break;
                case "getcarapprowjson":
                    getcarapprowjson(context);
                    break;
                case "delcarapprow":
                    delcarapprow(context);
                    break;
                case "savecarappjson":
                    savecarappjson(context);
                    break;
                case "savewjhdrowjson":
                    savewjhdrowjson(context);
                    break;
                case "saverowform":
                    saverowform(context);
                    break;
                case "saverowformfile":
                    saverowformfile(context);
                    break;
                case "saveallrowjson":
                    saveallrowjson(context);
                    break;
                default: break;
            }
        }
        public void getnextid(HttpContext context)
        {
            string idstr = new Dbopr().getstr("SELECT SEQ_DOC.NEXTVAL FROM DUAL").ToString();
            context.Response.Write(idstr);
        }
        public void getcarapplist(HttpContext context)
        {
            int pageNumber = Convert.ToInt32(context.Request["page"]);
            int pageSize = Convert.ToInt32(context.Request["rows"]);
            string qsign = context.Request["qsign"];
            string querystr;
            if (string.IsNullOrEmpty(qsign)) { querystr = ""; } else { querystr = " WHERE SIGN = " + qsign; }
            int total = 0;
            string sqlstr = "SELECT * FROM(SELECT T.*, ROWNUM RN FROM" +
                "(SELECT * FROM CL_ASSTICKET" + querystr + " ORDER BY SQBH)T" +
                " WHERE ROWNUM <= " + ((pageNumber - 1) * pageSize + pageSize).ToString() +
                ") WHERE RN > " + ((pageNumber - 1) * pageSize).ToString();
            ;
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            total = Convert.ToInt32(new Dbopr().getstr("SELECT COUNT(*) FROM CL_ASSTICKET" + querystr));

            var data = new
            {
                total = total,
                rows = dt
            };

            string json = JsonConvert.SerializeObject(data);
            context.Response.Write(json);
        }
        public void getwjhdlist(HttpContext context)
        {
            string llwjid = context.Request["llwjid"];
            string llsign = context.Request["llsign"];
            string querystr = "";
            if (!string.IsNullOrEmpty(llwjid)) { querystr = " WHERE LL_WJID = " + llwjid; }
            if (!string.IsNullOrEmpty(llsign))
            {
                if (querystr.Length > 0) { querystr += " AND LL_SIGN = " + llsign; }
                else
                {
                    querystr = " WHERE LL_SIGN = " + llsign;
                }
            }
            int total = 0;
            string sqlstr = "SELECT * FROM WJ_HANDLE" + querystr + " ORDER BY ID";
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            total = Convert.ToInt32(new Dbopr().getstr("SELECT COUNT(*) FROM WJ_HANDLE" + querystr));

            var data = new
            {
                total = total,
                rows = dt
            };

            string json = JsonConvert.SerializeObject(data);
            context.Response.Write(json);
        }


        public void getcphlist(HttpContext context)
        {
            string sqlstr = "SELECT CHPHM,CHLLX FROM CL_CHLSHBTZH ORDER BY CHPHM";
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            string json = JsonConvert.SerializeObject(dt);
            context.Response.Write(json);
        }
        public void savewjhdrowjson(HttpContext context)
        {
            string jsonstr = context.Request["param"];
            JObject jsonobj = (JObject)JsonConvert.DeserializeObject(jsonstr);
            if (jsonobj.ContainsKey("editing")) jsonobj.Property("editing").Remove();
            int wjhdid = jsonobj.Value<int>("ID");
            if(wjhdid==0)
            {
                wjhdid = Convert.ToInt32(new Dbopr().getstr("SELECT SEQ_DOC.NEXTVAL FROM DUAL"));
            }
            EFDbContext cont = new EFDbContext();
            WJ_HANDLE wjhd = cont.WJ_HANDLE.FirstOrDefault(p => p.ID == wjhdid);
            int isnew = 0;
            if (wjhd == null)
            {
                wjhd = new WJ_HANDLE();
                wjhd.ID = wjhdid;
                isnew = 1;
            }
            if (wjhd != null)
            {
                wjhd = new Common().getitem(wjhd, jsonobj, "ID");
            }
            if (isnew == 1)
            {
                cont.WJ_HANDLE.Add(wjhd);
            }
            cont.SaveChanges();

            string json = JsonConvert.SerializeObject(jsonobj);
            context.Response.Write(json);
        }


        public void getcarapprowjson(HttpContext context)
        {
            string sqbh = context.Request["sqbh"];
            string sqlstr = "SELECT * FROM CL_ASSTICKET WHERE SQBH = '" + sqbh + "'";
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];

            var serializerSettings = new JsonSerializerSettings {
                DateFormatString = "yyyy-MM-dd HH:mm:ss" };


            string jsonstr = JsonConvert.SerializeObject(dt,serializerSettings);
            JObject jsonobj = (JObject)(((JArray)(JsonConvert.DeserializeObject(jsonstr)))[0]);
            string json = JsonConvert.SerializeObject(jsonobj,serializerSettings);
            context.Response.Write(json);
        }
        public void delcarapprow(HttpContext context)
        {
            string sqbh = context.Request["sqbh"];
            int result;
            result = new Dbopr().getexc("DELETE FROM CL_ASSTICKET WHERE SQBH =  '" + sqbh + "'");
            context.Response.Write(result);
        }

        public void savecarappjson(HttpContext context)
        {
            string jsonstr = context.Request["param"];
            JObject jsonobj = (JObject)JsonConvert.DeserializeObject(jsonstr);
            if (jsonobj.ContainsKey("editing")) jsonobj.Property("editing").Remove();
            string sqbh = jsonobj.Value<string>("SQBH");
            EFDbContext cont = new EFDbContext();
            CL_ASSTICKET carapp = cont.CL_ASSTICKET.FirstOrDefault(p => p.SQBH == sqbh);
            int isnew = 0;
            if (carapp == null)
            {
                carapp = new CL_ASSTICKET();
                carapp.SQBH = sqbh;
                isnew = 1;
            }
            if (carapp != null)
            {
                carapp = new Common().getitem(carapp, jsonobj, "SQBH");
            }
            if (isnew == 1)
            {
                cont.CL_ASSTICKET.Add(carapp);
            }
            cont.SaveChanges();

            string json = JsonConvert.SerializeObject(jsonobj);
            context.Response.Write(json);
        }

        public void saverowform(HttpContext context)
        {
            int wjid;
            int.TryParse(context.Request["ID"], out wjid);
            EFDbContext cont = new EFDbContext();
            WJ_BASE wj = cont.WJ_BASE.FirstOrDefault(p => p.ID == wjid);
            int isnew = 0;
            if (wj == null || wjid == 0)
            {
                wj = new WJ_BASE();
                isnew = 1;
            }
            wj = new Common().getitemform(wj, context, "ID");
            if (isnew == 1)
            {
                wj.ID = wjid;
                cont.WJ_BASE.Add(wj);
            }
            cont.SaveChanges();
            context.Response.Write("ok");
        }

        public void saverowformfile(HttpContext context)
        {
            int wjid;
            int.TryParse(context.Request["ID"], out wjid);
            EFDbContext cont = new EFDbContext();
            WJ_BASE wj = cont.WJ_BASE.FirstOrDefault(p => p.ID == wjid);
            int isnew = 0;
            if (wj == null || wjid == 0)
            {
                wj = new WJ_BASE();
                isnew = 1;
            }
            wj = new Common().getitemform(wj, context, "ID");
            if (isnew == 1)
            {
                wj.ID = wjid;
                cont.WJ_BASE.Add(wj);
            }

            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            HttpPostedFile file1 = context.Request.Files["file1"];
            HttpPostedFile file2 = context.Request.Files["file2"];

            if (file1.ContentLength > 0) wj.LS_WJMC = file1.FileName;
            if (file2.ContentLength > 0) wj.LS_FJMC = file2.FileName;
            string json = "nofile";
            if (file1.ContentLength > 0 || file2.ContentLength > 0)
            {
                //定义文件存放的目标路径
                string targetDir = System.Web.HttpContext.Current.Server.MapPath("~/FileUpLoad/Wjfiles/" + context.Request["ID"].ToString() + "/");
                //创建目标路径
                System.IO.Directory.CreateDirectory(targetDir);
                //组合成文件的完整路径
                string path1 = System.IO.Path.Combine(targetDir, System.IO.Path.GetFileName(file1.FileName));
                string path2 = System.IO.Path.Combine(targetDir, System.IO.Path.GetFileName(file2.FileName));
                //保存上传的文件到指定路径中
                try
                {
                    if (file1.ContentLength > 0) file1.SaveAs(path1);
                    if (file2.ContentLength > 0) file2.SaveAs(path2);
                    json = path1;
                }
                catch
                {
                    json = "不成功";
                }
            }

            cont.SaveChanges();
            context.Response.Write(json);
        }


        EFDbContext efcont = new EFDbContext();
        public void saveallrowjson(HttpContext context)
        {
            int rowc = 0;
            string jsonstr = context.Request["param"];
            JObject jobj = (JObject)JsonConvert.DeserializeObject(jsonstr);
            JArray jaryinst = (JArray)jobj["insertedrows"];
            JArray jarydel = (JArray)jobj["deletedrows"];
            JArray jaryup = (JArray)jobj["updatedrows"];
            foreach (JObject jobjinst in jaryinst)
            {
                getuporinscontt(jobjinst);
                rowc++;
            }
            foreach (JObject jobjdel in jarydel)
            {
                getdelcontt(jobjdel);
                rowc++;
            }
            foreach (JObject jobjup in jaryup)
            {
                getuporinscontt(jobjup);
                rowc++;
            }

            efcont.SaveChanges();

            context.Response.Write("更新:" + rowc.ToString());
        }

        private void getuporinscontt(JObject jsonobj)
        {
            int isnew = 0;
            int wjid = jsonobj.Value<int>("ID");
            WJ_BASE wj = efcont.WJ_BASE.FirstOrDefault(p => p.ID == wjid);
            if (wj == null)
            {
                wj = new WJ_BASE();
                wj.ID = wjid;
                isnew = 1;
            }
            wj = new Common().getitem(wj, jsonobj, "ID");
            if (isnew == 1) efcont.WJ_BASE.Add(wj);

        }
        private int getdelcontt(JObject jsonobj)
        {
            int sign = 0;
            int wjid = jsonobj.Value<int>("ID");
            WJ_BASE wj = efcont.WJ_BASE.FirstOrDefault(p => p.ID == wjid);

            if (wj != null)
            {
                efcont.WJ_BASE.Remove(wj);
                sign = 1;
            }
            return sign;
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