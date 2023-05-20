using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Frameurl()
        {

            return View();
        }
        
        public ActionResult Mdfmenu()
        {
            return View();
        }
        public ActionResult Mdfmenutree()
        {
            return View();
        }
        public JsonResult jsr()
        {
            return Json(@"{""input"" : ""value"", ""output"" : ""result""}");
        }
        public ActionResult Logon()
        {
            if (HttpContext != null)
            {
                HttpCookie cookie1 = HttpContext.Request.Cookies["Usergh"];
                HttpCookie cookie2 = HttpContext.Request.Cookies["Userxm"];
                HttpCookie cookie3 = HttpContext.Request.Cookies["Userpwd"];
                HttpCookie cookie4 = HttpContext.Request.Cookies["Useriss"];
                if (cookie1 != null) ViewBag.Usergh = HttpContext.Request.Cookies["Usergh"].Value;
                if (cookie2 != null) ViewBag.Userxm = HttpContext.Request.Cookies["Userxm"].Value;
                if (cookie3 != null) ViewBag.Userpwd = HttpContext.Request.Cookies["Userpwd"].Value;
                if (cookie4 != null) Convert.ToBoolean(ViewBag.Useriss = HttpContext.Request.Cookies["Useriss"].Value);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult View1()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public FileContentResult Getimgfbyt(byte[] imgb,string mimetype)
        {
            if (imgb != null) {
                return File(imgb, mimetype);
            } else
            {
                return null;
            }
        }
        public FileContentResult Getimgfbyt1(string mimetype)
        {
            if (string.IsNullOrEmpty(mimetype)) mimetype = "image/gif";
            if(TempData["userzp"]!=null) {
                return File((byte[])TempData["userzp"], mimetype);
            }
            else
            {
                return null;
            }
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}