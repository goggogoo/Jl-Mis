using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class WJ_BASE1Controller : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: WJ_BASE1
        public ActionResult Index()
        {
            return View(db.WJ_BASE.ToList());
        }

        // GET: WJ_BASE1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WJ_BASE wJ_BASE = db.WJ_BASE.Find(id);
            if (wJ_BASE == null)
            {
                return HttpNotFound();
            }
            return View(wJ_BASE);
        }

        // GET: WJ_BASE1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WJ_BASE1/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LS_NO,LL_SIGN,LS_FBBMMC,LS_FBBMBH,LS_FBRXM,LS_FBRBH,LDT_FBRRQ,LS_FBZT,LS_GJC,LS_WJSM,LS_WJLX,LS_WJBZ,LL_WJCZ,LL_FJCZ,LS_WJHZ,LS_FJHZ,LS_WJMC,LS_FJMC,LS_JSRLB,LS_JSBMLB,LS_JSRXS,LS_JSBMXS,LL_YBGS,LL_YYGS,LL_ELSE,LS_ELSE")] WJ_BASE wJ_BASE)
        {
            if (ModelState.IsValid)
            {
                db.WJ_BASE.Add(wJ_BASE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wJ_BASE);
        }

        // GET: WJ_BASE1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WJ_BASE wJ_BASE = db.WJ_BASE.Find(id);
            if (wJ_BASE == null)
            {
                return HttpNotFound();
            }
            return View(wJ_BASE);
        }

        // POST: WJ_BASE1/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LS_NO,LL_SIGN,LS_FBBMMC,LS_FBBMBH,LS_FBRXM,LS_FBRBH,LDT_FBRRQ,LS_FBZT,LS_GJC,LS_WJSM,LS_WJLX,LS_WJBZ,LL_WJCZ,LL_FJCZ,LS_WJHZ,LS_FJHZ,LS_WJMC,LS_FJMC,LS_JSRLB,LS_JSBMLB,LS_JSRXS,LS_JSBMXS,LL_YBGS,LL_YYGS,LL_ELSE,LS_ELSE")] WJ_BASE wJ_BASE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wJ_BASE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wJ_BASE);
        }

        // GET: WJ_BASE1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WJ_BASE wJ_BASE = db.WJ_BASE.Find(id);
            if (wJ_BASE == null)
            {
                return HttpNotFound();
            }
            return View(wJ_BASE);
        }

        // POST: WJ_BASE1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WJ_BASE wJ_BASE = db.WJ_BASE.Find(id);
            db.WJ_BASE.Remove(wJ_BASE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
