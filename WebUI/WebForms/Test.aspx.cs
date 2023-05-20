using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.OracleClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

namespace WebUI.WebForms
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        protected void Button1_Click(object sender, EventArgs e)
        {
            //OracleConnection conn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EFDbContext"].ToString());
            //OracleDataAdapter ad = new OracleDataAdapter("SELECT * FROM RS_USERS",conn);
            OracleDataAdapter ad = new OracleDataAdapter("SELECT * FROM RS_USERS", System.Configuration.ConfigurationManager.ConnectionStrings["EFDbContext"].ToString());
            DataSet ds = new DataSet();
            ad.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            ds.Dispose();
            ad.Dispose(); 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ClassName1 = TextBox1.Text.Trim();
            string ClassExp1 = TextBox2.Text.Trim();
            string NameSpace1 = TextBox3.Text.Trim();
            string strClass;
            ClassName1 = ClassName1 == "" ? "ClassName" : ClassName1;
            ClassExp1 = ClassExp1 == "" ? "ClassExp1" : ClassExp1;
            NameSpace1 = NameSpace1 == "" ? "NameSpace1" : NameSpace1;
            strClass = "namespace " + NameSpace1+"{\n";
            NameSpace1+= " public class " + ClassName1 + "\n  {\n";
            System.Windows.Forms.MessageBox.Show(GridView1.Columns.Count.ToString());
                foreach (System.Web.UI.WebControls.BoundField Row in GridView1.Columns)
                {
                    if (Row.HeaderText != null && Row.HeaderText != null)
                    {
                        string propname = Row.HeaderText.ToString();
                        string type = Row.HeaderStyle.ToString();
                    strClass += "        private " + type + " " + propname + ";\n";

                        string propname1 = System.Text.RegularExpressions.Regex.Replace(propname, "^_+", "");
                        string functionName = propname1.Substring(0, 1).ToUpper() + propname1.Substring(1);
                    strClass += "         public " + type + " " + functionName + "\n";
                    strClass += "        {\n";
                    strClass += "            get { return " + propname + "; }\n";
                    strClass += "            set { " + propname + " = value; }\n";
                    strClass += "        }\n";
                    }
                }
            strClass += "}\n";
            strClass += "}\n";

            TextBox4.Text = strClass;
          

        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        Response.Write("<li>列名=" + e.Row.Cells[i].Text);
                    }
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        Response.Write("<li>内容=" + e.Row.Cells[i].Text);
                    }
                }

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {


            //DataContext ctx = new DataContext("Provider=OraOLEDB.Oracle.1;Data Source=orcl;Persist Security Info=True;User ID=jl_mis;Password=jl_mis");
            //GridView1.DataSource = ctx.GetTable<RS_USERS>();


            Response.Write(new EFHtRepo().Ht_files.Count().ToString());

            Response.Write(new EFUserRepo().Rs_users.Count().ToString());
            Response.Write(new EFWjtypeRepo().Wj_types.Count().ToString());


            Response.Write(new EFProductRepo().Products.Count().ToString());

            IEnumerable<WJ_BASE> wjss = new EFWjRepo().wjs;

            Response.Write("<li>" + wjss.Count().ToString() + "</li>");

            foreach (WJ_BASE wj in wjss)
            {
                //Response.Write("<li>");
                Response.Write("<li>" + wj.ID.ToString() + "  " + (wj.LS_NO ?? "null").ToString() + "  " + (wj.LS_FBZT ?? "null").ToString() + "</li>");
                //Response.Write("</li>");
            }
            Response.Write("<li>hello</li>");

            //var vv = from i in wjss select i;

            GridView1.DataSource = wjss.ToList();
            GridView1.DataBind();

            //GridView1.DataSource = new EFWjRepo().wjs;
            //GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox5.Text = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(TextBox4.Text.Trim()));

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox4.Text = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(TextBox5.Text));
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            byte[] bykey = System.Text.ASCIIEncoding.ASCII.GetBytes("12345678");//只能8位
            byte[] byiv = System.Text.ASCIIEncoding.ASCII.GetBytes("aaaaaaaa");
            string data = TextBox4.Text.Trim();
            System.Security.Cryptography.DESCryptoServiceProvider csp = new System.Security.Cryptography.DESCryptoServiceProvider();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cts = new System.Security.Cryptography.CryptoStream(ms, csp.CreateEncryptor(bykey, byiv), System.Security.Cryptography.CryptoStreamMode.Write);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(cts);
            sw.Write(data);
            sw.Flush();
            cts.FlushFinalBlock();
            sw.Flush();
            TextBox5.Text = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string key = "12345678";
            string iv = "aaaaaaaa";
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);
            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(TextBox5.Text.Trim());
            }
            catch
            {
                return;
            }
            System.Security.Cryptography.DESCryptoServiceProvider cryptoProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byEnc);
            System.Security.Cryptography.CryptoStream cst = new System.Security.Cryptography.CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), System.Security.Cryptography.CryptoStreamMode.Read);
            System.IO.StreamReader sr = new System.IO.StreamReader(cst);
            TextBox5.Text = sr.ReadToEnd();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            TextBox5.Text =  System.Configuration.ConfigurationManager.ConnectionStrings["EFDbContext"].ToString();
        }
    }
}