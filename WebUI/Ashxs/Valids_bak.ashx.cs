using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebUI.Utilities;
using System.Web.SessionState;
using Domain.Entities;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WebUI.Ashxs
{
    /// <summary>
    /// Valids 的摘要说明
    /// </summary>
    public class Valids_bak : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (context.Request["action"].ToString())
            {
                case "getname":
                    getname(context);
                    break;
                case "getname1":
                    getname1(context);
                    break;
                case "getsnimg":
                    getsnimg(context);
                    break;
                case "logandrec":
                    logandrec(context);
                    break;
                case "logout":
                    logout(context);
                    break;
                case "getmenu":
                    getmenu(context);
                    break;
                case "getmenu1":
                    getmenu1(context);
                    break;
                case "gettree1":
                    gettree1(context);
                    break;
                case "getwjlistjson":
                    getwjlistjson(context);
                    break;
                case "getmenulistjson":
                    getmenulistjson(context);
                    break;
                case "getlxlistjson":
                    getlxlistjson(context);
                    break;
                case "getlxlistjson2":
                    getlxlistjson2(context);
                    break;
                case "getwjrowjson":
                    getwjrowjson(context);
                    break;
                case "saverowjson":
                    saverowjson(context);
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
                case "savemenu":
                    savemenu(context);
                    break;
                case "getid":
                    getid(context);
                    break;
                case "savetos":
                    savetos(context);
                    break;

                default: break;
            }
        }
        public void getname(HttpContext context)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string lsgh = context.Request["lsgh"].ToString();
            Domain.Abstract.IUserRepo users = new Domain.Concrete.EFUserRepo();
            Domain.Entities.RS_USERS user = users.Rs_users.FirstOrDefault(p => p.LS_GH == lsgh);
            string name = null;
            if(user!=null)name = user.LS_XM;
            sw.Stop();
            name += sw.ElapsedMilliseconds.ToString();
            context.Response.Write(name);
        }

        public void getname1(HttpContext context)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string lsgh = context.Request["lsgh"].ToString();
            string name="";
            RS_USERS user = new RS_USERS();
            //name = Convert.ToString(new Dbopr().getstr("SELECT LS_XM FROM RS_USERS WHERE LS_GH = :LS_GH", new OracleParameter[] { new OracleParameter (":LS_GH", lsgh ) }));
            using (OracleDataReader dr = new Dbopr().getdr("SELECT * FROM RS_USERS WHERE LS_GH = :LS_GH", new OracleParameter[] { new OracleParameter(":LS_GH", lsgh) }))
            {
                if (dr.Read())
                {
                    name = dr["LS_XM"].ToString();
                    user.LS_GH = dr["LS_GH"].ToString();
                    user.LS_XM = dr["LS_XM"].ToString();
                    object obj = dr["LB_ZP"];
                    if (obj != System.DBNull.Value) { user.LB_ZP = (byte[])obj; }
                    context.Session["user"] = user;
                }
            }

            sw.Stop();
            name += sw.ElapsedMilliseconds.ToString();

            string jsonText = @"{""input"" : ""value"", ""output"" : """ + name + @"""}";
            context.Response.Write(jsonText);
        }
        public void getsnimg(HttpContext context)
        {
            RS_USERS user = (RS_USERS)HttpContext.Current.Session["user"];
            if (user != null)
            {
                if (user.LB_ZP != null) {
                    //context.Response.ContentType = "image/Jpeg";
                    context.Response.BinaryWrite(user.LB_ZP);
                }  
            }
        }
        public void logandrec(HttpContext context)
        {
            string lsgh = context.Request["lsgh"].ToString();
            string lspwd = context.Request["lspwd"].ToString();
            bool issave = Convert.ToBoolean(context.Request["issave"]);

            string lsxm = "";
            string result = "";
            RS_USERS user = new RS_USERS();
            using (OracleDataReader dr = new Dbopr().getdr("SELECT * FROM RS_USERS WHERE LS_GH = :LS_GH AND LS_PWD=:LS_PWD", new OracleParameter[] { new OracleParameter(":LS_GH", lsgh), new OracleParameter(":LS_PWD", lspwd) }))
            {
                if (dr.Read())
                {
                    lsxm = dr["LS_XM"].ToString();
                    user.LS_GH = dr["LS_GH"].ToString();
                    user.LS_XM = dr["LS_XM"].ToString();
                    object obj = dr["LB_ZP"];
                    if (obj != System.DBNull.Value) { user.LB_ZP = (byte[])obj; }
                    context.Session["user"] = user;
                    result = "success";
                    if (issave == true)
                    {
                        context.Response.SetCookie(new HttpCookie("Usergh") { Value = lsgh, Expires = DateTime.Now.AddDays(3) });
                        context.Response.SetCookie(new HttpCookie("Userxm") { Value = user.LS_XM, Expires = DateTime.Now.AddDays(3) });
                        context.Response.SetCookie(new HttpCookie("Userpwd") { Value = lspwd, Expires = DateTime.Now.AddDays(3) });
                        context.Response.SetCookie(new HttpCookie("Useriss") { Value = issave.ToString(), Expires = DateTime.Now.AddDays(3) });
                    }
                    else
                    {
                        context.Response.SetCookie(new HttpCookie("Usergh") { Expires = DateTime.Now.AddDays(-3) });
                        context.Response.SetCookie(new HttpCookie("Userxm") { Expires = DateTime.Now.AddDays(-3) });
                        context.Response.SetCookie(new HttpCookie("Userpwd") { Expires = DateTime.Now.AddDays(-3) });
                        context.Response.SetCookie(new HttpCookie("Useriss") { Expires = DateTime.Now.AddDays(-3) });
                    }

                }
                else
                {
                    result = "false";
                }
            }

            context.Response.Write(result);
        }
        public void logout(HttpContext context)
        {
            context.Session["user"] = null;
            context.Session.Remove("user");
            context.Response.Redirect("/home/logon");
        }
            public void getmenu(HttpContext context)
        {
            DataTable dt = new Dbopr().getds("SELECT * FROM PB_MMENU").Tables[0];
            string results = "";
            int lev = 0;
            menu(0);
            void menu(int i)
            {
                lev++;
                foreach (DataRow drw in dt.Rows)
                {
                    if (Convert.ToInt32(drw["PNODE"]) == i)
                    {
                        results += Convert.ToString(drw["TEXT"]) + "<br>";
                        menu(Convert.ToInt32(drw["NODE"]));
                    }
                }
            }
            context.Response.Write(results);
        }
        private class MenuTreeViewModel
        {
            public string text { set; get; }
            public string url { set; get; }
            public List<MenuTreeViewModel> children { set; get; }
        }
        private static List<MenuTreeViewModel> GetMenuTree(List<Hashtable> list, int pid)
        {
            List<MenuTreeViewModel> tree = new List<MenuTreeViewModel>();
            var children = list.Where(m => m["PNODE"].ToString() == pid.ToString()).ToList();
            if (children.Count > 0)
            {
                for (var i = 0; i < children.Count; i++)
                {
                    MenuTreeViewModel itemMenu = new MenuTreeViewModel();
                    itemMenu.text = (String)children[i]["TEXT"];
                    itemMenu.url = children[i]["TAG"] is System.DBNull?null:(String)children[i]["TAG"];
                    itemMenu.children = GetMenuTree(list, Convert.ToInt32(children[i]["NODE"]));
                    tree.Add(itemMenu);
                }
            }
            return tree;
        }
        public List<Hashtable> GetList(DataTable dt)
        {
            List<Hashtable> mList = new List<Hashtable>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i <= count - 1; i++)
                {
                    Hashtable ht = new Hashtable();
                    foreach (DataColumn col in dt.Columns)
                    {
                        ht.Add(col.ColumnName, dt.Rows[i][col.ColumnName]);
                    }
                    mList.Add(ht);
                }
            }
            return mList;
        }
        public void getmenu1(HttpContext context)
        {
            DataTable dt = new Dbopr().getds("SELECT * FROM PB_MMENU").Tables[0];

            List<MenuTreeViewModel> ltree = GetMenuTree(GetList(dt),0);
            
            context.Response.Write(JsonConvert.SerializeObject(ltree).Replace(",\"children\":[]", ""));

        }
        StringBuilder result = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        public void gettree1(HttpContext context)
        {
            DataTable dt = new Dbopr().getds("SELECT * FROM PB_MMENU").Tables[0];
            string json = GetTreeJsonByTable(dt, "NODE", "TEXT", "TAG", "PNODE", "0");
            context.Response.Write(json);
        }
        private string GetTreeJsonByTable(DataTable tabel, string idCol, string txtCol, string url, string rela, object pId)
        {
            result.Append(sb.ToString());
            sb.Clear();
            if (tabel.Rows.Count > 0)
            {
                sb.Append("[");
                string filer = string.Format("{0}='{1}'", rela, pId);
                DataRow[] rows = tabel.Select(filer);
                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        sb.Append("{\"id\":\"" + row[idCol] + "\",\"text\":\"" + row[txtCol] + "\",\"attributes\":\"" + row[url] + "\"");
                        if (tabel.Select(string.Format("{0}='{1}'", rela, row[idCol])).Length > 0)
                        {
                            //点击展开
                            sb.Append(",\"state\":\"open\",\"children\":");
                            GetTreeJsonByTable(tabel, idCol, txtCol, url, rela, row[idCol]);
                            result.Append(sb.ToString());
                            sb.Clear();
                        }
                        result.Append(sb.ToString());
                        sb.Clear();
                        sb.Append("},");
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("]");
                result.Append(sb.ToString());
                sb.Clear();
            }
            return result.ToString();
        }
        public void getwjlistjson(HttpContext context)
        {
            int pageNumber = Convert.ToInt32(context.Request["page"]); //获取当前页码，easyui默认传到后台
            int pageSize = Convert.ToInt32(context.Request["rows"]);
            int total = 0;
            string sqlstr = "SELECT * FROM(SELECT T.*, ROWNUM RN FROM" +
                "(SELECT ID,LS_NO,LL_SIGN,LS_FBBMMC,LS_FBBMBH,LS_FBRXM,to_char(LDT_FBRRQ,'yyyy-mm-dd') as LDT_FBRRQ,LS_FBZT FROM WJ_BASE ORDER BY ID)T" +
                " WHERE ROWNUM <= " + ((pageNumber - 1) * pageSize + pageSize).ToString() +
                ") WHERE RN > "+((pageNumber - 1) * pageSize).ToString();
;
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            total = Convert.ToInt32(new Dbopr().getstr("SELECT COUNT(*) FROM WJ_BASE"));

            var data = new
            {
                total = total,   
                rows = dt
            };

            string json = JsonConvert.SerializeObject(data);
            context.Response.Write(json);
        }
        public void getmenulistjson(HttpContext context)
        {
            int total = 0;
            string sqlstr = "SELECT * FROM PB_MMENU ORDER BY NODE";
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            total = Convert.ToInt32(new Dbopr().getstr("SELECT COUNT(*) FROM PB_MMENU"));
            var data = new
            {
                total = total,
                rows = dt
            };
            string json = JsonConvert.SerializeObject(data);
            context.Response.Write(json);
        }
        public void getlxlistjson(HttpContext context)
        {
            string sqlstr = "SELECT ID,LS_FBZT FROM WJ_BASE ORDER BY ID";
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            string json = JsonConvert.SerializeObject(dt);
            context.Response.Write(json);
        }
        public void getlxlistjson2(HttpContext context)
        {
            string sqlstr = "SELECT LS_FBZT as \"text\" FROM WJ_BASE ORDER BY ID";
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];
            string json = JsonConvert.SerializeObject(dt);
            //json=json.Replace("LS_FBZT", "text");

            context.Response.Write(json);
        }

        public void getwjrowjson(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["id"]);
            //string sqlstr = "SELECT ID,LS_NO,LL_SIGN,LS_FBBMMC,LS_FBBMBH,LS_FBRXM,to_char(LDT_FBRRQ,'yyyy-mm-dd') as LDT_FBRRQ,LS_FBZT FROM WJ_BASE WHERE ID = " + id.ToString();
            string sqlstr = "SELECT * FROM WJ_BASE WHERE ID = " + id.ToString();
            DataTable dt = new Dbopr().getds(sqlstr).Tables[0];

            string jsonstr = JsonConvert.SerializeObject(dt);
            JObject jsonobj = (JObject)(((JArray)(JsonConvert.DeserializeObject(jsonstr)))[0]);
            //JObject jobj = (JObject)jsonobj[0];
            string json = JsonConvert.SerializeObject(jsonobj);
            context.Response.Write(json);
        }
        public void getid(HttpContext context)
        {
            string idstr = Convert.ToString(new Dbopr().getstr("SELECT SEQ_DOC.NEXTVAL FROM DUAL"));
            context.Response.Write(idstr);
        }
        public void saverowjson(HttpContext context)
        {
            string jsonstr = context.Request["param"];
            JObject jsonobj = (JObject)JsonConvert.DeserializeObject(jsonstr);
            if(jsonobj.ContainsKey("editing")) jsonobj.Property("editing").Remove();

            int wjid = jsonobj.Value<int>("ID");
            EFDbContext cont = new EFDbContext();
            WJ_BASE wj = cont.WJ_BASE.FirstOrDefault(p=>p.ID==wjid);
            if (wj != null)
            {
                //wj.LDT_FBRRQ = jsonobj.Value<DateTime>("LDT_FBRRQ");
                //wj.LS_FBZT= jsonobj.Value<string>("LS_FBZT");
                foreach(var key in jsonobj)
                {
                    if (key.Key != "ID")
                    {
                        foreach (System.Reflection.PropertyInfo info in wj.GetType().GetProperties())
                        {
                            if (info.Name == key.Key)
                            {
                                if (key.Key == "ID"|| string.IsNullOrEmpty(key.Value.ToObject<string>())) { }
                                else {
                                    Type baseType;
                                    if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                    {
                                        Type[] typeArray = info.PropertyType.GetGenericArguments();
                                        baseType = typeArray[0];
                                    }
                                    else
                                    {
                                        baseType = info.PropertyType;
                                    }
                                    //info.SetValue(wj, (baseType)key.Value);

                                    switch (baseType.Name)
                                    {

                                        case "DateTime":
                                            info.SetValue(wj, (DateTime)key.Value);
                                            break;
                                        case "String":
                                            info.SetValue(wj, (string)key.Value);
                                            break;
                                        case "Decimal":
                                            info.SetValue(wj, (int)key.Value);
                                            break;
                                        case "Int32":
                                            info.SetValue(wj, (int)key.Value);
                                            break;
                                        default:
                                            break;

                                    }
                                }

                            }
                        }
                    }
                }

            }
            else
            {
                wj = new WJ_BASE();
                wj.ID = wjid;
                //wj.LL_SIGN = jsonobj.Value<int>("LL_SIGN");
                if(!string.IsNullOrEmpty(jsonobj["LL_SIGN"].Value<string>())) wj.LL_SIGN = jsonobj.Value<int>("LL_SIGN");
                if(!string.IsNullOrEmpty(jsonobj["LDT_FBRRQ"].Value<string>())) wj.LDT_FBRRQ = jsonobj.Value<DateTime>("LDT_FBRRQ");
                wj.LS_FBZT = jsonobj.Value<string>("LS_FBZT");
                cont.WJ_BASE.Add(wj);
            }
            cont.SaveChanges();

            string json = JsonConvert.SerializeObject(jsonobj);
            context.Response.Write(json);
        }

        public void saverowform(HttpContext context)
        {
            WJ_BASE wjform = new WJ_BASE();
            foreach (System.Reflection.PropertyInfo info in wjform.GetType().GetProperties())
            {
                if (null != (context.Request[info.Name]))
                {
                    string reqobj = context.Request[info.Name].ToString();
                    Type baseType;
                    if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        Type[] typeArray = info.PropertyType.GetGenericArguments();
                        baseType = typeArray[0];
                    }
                    else
                    {
                        baseType = info.PropertyType;
                    }
                    switch (baseType.Name)
                    {

                        case "DateTime":
                            info.SetValue(wjform, Convert.ToDateTime(reqobj));
                            break;
                        case "String":
                            info.SetValue(wjform, (string)reqobj);
                            break;
                        case "Int32":
                            info.SetValue(wjform, Convert.ToInt32(reqobj));
                            break;
                        default:
                            break;

                    }
                }
            }


            int wjid = wjform.ID;
            EFDbContext cont = new EFDbContext();
            WJ_BASE wj = cont.WJ_BASE.FirstOrDefault(p => p.ID == wjid);
            if (wj != null)
            {

                foreach (System.Reflection.PropertyInfo info in wj.GetType().GetProperties())
                {
                    if (info.Name != "ID")
                    {
                        foreach (System.Reflection.PropertyInfo info0 in wjform.GetType().GetProperties())
                        {
                            if (info.Name == info0.Name)
                            {
                                info.SetValue(wj, info0.GetValue(wjform));
                            }
                        }
                    }
                }
            }
            else
            {
                wj = new WJ_BASE();
                wj.ID = wjid;
                wj.LS_NO = wjform.LS_NO;
                wj.LL_SIGN = wjform.LL_SIGN;
                wj.LS_FBBMMC = wjform.LS_FBBMMC;
                wj.LS_FBRXM = wjform.LS_FBRXM;
                wj.LDT_FBRRQ = wjform.LDT_FBRRQ;
                wj.LS_FBZT = wjform.LS_FBZT;

                cont.WJ_BASE.Add(wj);
            }
            cont.SaveChanges();

            string json = JsonConvert.SerializeObject(wjform);
            context.Response.Write(json);
        }

        public void saverowformfile(HttpContext context)
        {


            WJ_BASE wjform = getwjfromform(context);

            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            HttpPostedFile file1 = context.Request.Files["file1"];
            HttpPostedFile file2 = context.Request.Files["file2"];
            if (file1.ContentLength > 0) wjform.LS_WJMC = file1.FileName;
            if (file2.ContentLength > 0) wjform.LS_FJMC = file2.FileName;


            int wjid = wjform.ID;
            EFDbContext cont = new EFDbContext();
            WJ_BASE wj = cont.WJ_BASE.FirstOrDefault(p => p.ID == wjid);
            int wjisnull = 0;
            if (wj != null)
            {
                wjisnull = 0;
            }
            else
            {
                wjisnull = 1;
                wj = new WJ_BASE();
            }

                foreach (System.Reflection.PropertyInfo info in wj.GetType().GetProperties())
                {
                    if (info.Name != "ID")
                    {
                        foreach (System.Reflection.PropertyInfo info0 in wjform.GetType().GetProperties())
                        {
                            if (info.Name == info0.Name)
                            {
                                info.SetValue(wj, info0.GetValue(wjform));
                            }
                        }
                    }else 
                    {
                        if (wjisnull == 1) wj.ID = wjform.ID;
                    }
                }
            if (wjisnull == 1) cont.WJ_BASE.Add(wj);
            cont.SaveChanges();

            //定义文件存放的目标路径
            string targetDir = System.Web.HttpContext.Current.Server.MapPath("~/FileUpLoad/Wjfiles/"+ context.Request["ID"].ToString()+"/");
            //创建目标路径
            System.IO.Directory.CreateDirectory(targetDir);
            //组合成文件的完整路径
            string path1 = System.IO.Path.Combine(targetDir, System.IO.Path.GetFileName(file1.FileName));
            string path2 = System.IO.Path.Combine(targetDir, System.IO.Path.GetFileName(file2.FileName));
            //保存上传的文件到指定路径中
            string json;
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
            
            context.Response.Write(json);
        }

        //从前端form获取WJ_BASE
        private WJ_BASE getwjfromform(HttpContext context) { 
            WJ_BASE wjform = new WJ_BASE();
                foreach (System.Reflection.PropertyInfo info in wjform.GetType().GetProperties())
                {
                    if (null != (context.Request[info.Name]))
                    {
                        string reqobj = context.Request[info.Name].ToString();
            Type baseType;
                        if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            Type[] typeArray = info.PropertyType.GetGenericArguments();
            baseType = typeArray[0];
                        }
                        else
                        {
                            baseType = info.PropertyType;
                        }
                        switch (baseType.Name)
                        {

                            case "DateTime":
                                info.SetValue(wjform, Convert.ToDateTime(reqobj));
                                break;
                            case "String":
                                info.SetValue(wjform, (string) reqobj);
                                break;
                            case "Int32":
                                info.SetValue(wjform, Convert.ToInt32(reqobj));
                                break;
                            default:
                                break;

                        }
                    }
                }
            return wjform;
        }




        EFDbContext efcont = new EFDbContext();
        public void saveallrowjson(HttpContext context)
        {
            int rowc = 0;
            string jsonstr = context.Request["param"];
            JObject jobj= (JObject)JsonConvert.DeserializeObject(jsonstr);
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

        private int getuporinscontt(JObject jsonobj)
        {
            int sign = 0;
            int wjid = jsonobj.Value<int>("ID");
            //if (wjid==null||wjid==0) wjid = Convert.ToInt32(new Dbopr().getstr("SELECT SEQ_DOC.NEXTVAL FROM DUAL"));
            WJ_BASE wj = efcont.WJ_BASE.FirstOrDefault(p => p.ID == wjid);
            if (wj != null)
            {
                foreach (var key in jsonobj)
                {
                    if (key.Key != "ID")
                    {
                        foreach (System.Reflection.PropertyInfo info in wj.GetType().GetProperties())
                        {
                            if (info.Name == key.Key)
                            {
                                if (key.Key == "ID" || string.IsNullOrEmpty(key.Value.ToObject<string>())) { }
                                else
                                {
                                    Type baseType;
                                    if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                    {
                                        Type[] typeArray = info.PropertyType.GetGenericArguments();
                                        baseType = typeArray[0];
                                    }
                                    else
                                    {
                                        baseType = info.PropertyType;
                                    }
                                    //info.SetValue(wj, (baseType)key.Value);

                                    switch (baseType.Name)
                                    {

                                        case "DateTime":
                                            info.SetValue(wj, (DateTime)key.Value);
                                            break;
                                        case "String":
                                            info.SetValue(wj, (string)key.Value);
                                            break;
                                        case "Decimal":
                                            info.SetValue(wj, (Decimal)key.Value);
                                            break;
                                        case "Int32":
                                            info.SetValue(wj, (int)key.Value);
                                            break;
                                        default:
                                            break;

                                    }
                                }

                            }
                        }
                    }
                }
                sign = 1;

            }
            else
            {
                wj = new WJ_BASE();
                wj.ID = wjid;
                if (!string.IsNullOrEmpty(jsonobj["LL_SIGN"].Value<string>())) wj.LL_SIGN = jsonobj.Value<int>("LL_SIGN");
                if (!string.IsNullOrEmpty(jsonobj["LDT_FBRRQ"].Value<string>())) wj.LDT_FBRRQ = jsonobj.Value<DateTime>("LDT_FBRRQ");
                wj.LS_FBZT = jsonobj.Value<string>("LS_FBZT");
                efcont.WJ_BASE.Add(wj);

                sign = 1;
            }

            return sign;
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
  

            int i = new Dbopr().getexc("INSERT INTO TICK_OPR_SUM(ID,LLTYPE,LLSIGN,LSDW,LSCZR,LSRW)VALUES(:id,:lltype,:llsign,:lsdw,:lsczr,:lsrw)",op);
            //int i = new Dbopr().getexc("INSERT INTO TICK_OPR_SUM(ID,LLTYPE,LLSIGN,LSDW,LSCZR,LSRW)VALUES(1,0,0,'kkk','lll','kkk')");
            context.Response.Write(i.ToString() + lsrw);
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


        public void savemenu(HttpContext context)
        {
            int rowc = 0;
            string jsonstr = context.Request["param"];
            JObject jobj = (JObject)JsonConvert.DeserializeObject(jsonstr);
            JArray jaryinst = (JArray)jobj["insertedrows"];
            JArray jarydel = (JArray)jobj["deletedrows"];
            JArray jaryup = (JArray)jobj["updatedrows"];
            JArray jaryuporins = new JArray(jaryup.Union(jaryinst));
            foreach (JObject jobjinst in jaryuporins)
            {
                int menuid = jobjinst.Value<int>("NODE");
                PB_MMENU menu = efcont.PB_MMENU.FirstOrDefault(p=>p.NODE==menuid);
                if (menu == null)
                {
                    menu = new PB_MMENU();
                    menu.NODE = menuid;
                }
                if (menu != null)
                {
                    menu = getitem(menu, jobjinst,"NODE");
                }
                else
                {
                    efcont.PB_MMENU.Add(menu);
                }
                rowc++;
            }
            foreach (JObject jobjdel in jarydel)
            {
               int menuid = jobjdel.Value<int>("NODE");
                PB_MMENU menu = efcont.PB_MMENU.FirstOrDefault(p => p.NODE == menuid);

                if (menu != null)
                {
                    efcont.PB_MMENU.Remove(menu);
                }
                rowc++;
            }

            efcont.SaveChanges();

            context.Response.Write("更新:" + rowc.ToString());
        }

        public T getitem<T>(T t1, JObject t2,string idstr)
        {
            foreach (var key in t2)
            {
                if (key.Key != idstr)
                {
                    foreach (System.Reflection.PropertyInfo info in t1.GetType().GetProperties())
                    {
                        if (info.Name == key.Key)
                        {
                            if (key.Key == idstr || string.IsNullOrEmpty(key.Value.ToObject<string>())) { }
                            else
                            {
                                Type baseType;
                                if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                {
                                    Type[] typeArray = info.PropertyType.GetGenericArguments();
                                    baseType = typeArray[0];
                                }
                                else
                                {
                                    baseType = info.PropertyType;
                                }

                                switch (baseType.Name)
                                {

                                    case "DateTime":
                                        info.SetValue(t1, (DateTime)key.Value);
                                        break;
                                    case "String":
                                        info.SetValue(t1, (string)key.Value);
                                        break;
                                    case "Decimal":
                                        info.SetValue(t1, (Decimal)key.Value);
                                        break;
                                    case "Int32":
                                        info.SetValue(t1, (int)key.Value);
                                        break;
                                    case "Boolean":
                                        info.SetValue(t1, Convert.ToBoolean((int)key.Value));
                                        break;
                                    default:
                                        break;

                                }
                            }

                        }
                    }
                }
            }
            return (T)(Object)t1;
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