using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dfweb.Models;

namespace dfweb.Controllers
{
    public class dfmembersController : Controller
    {
        private azure_DBContext db = new azure_DBContext();

        // GET: dfmembers
        public ActionResult Index()
        {
            return View(db.dfmember.ToList());
        }

        // GET: dfmembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dfmember dfmember = db.dfmember.Find(id);
            if (dfmember == null)
            {
                return HttpNotFound();
            }
            return View(dfmember);
        }

        // GET: dfmembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dfmembers/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date,city,location,task,type,who,notion")] dfmember dfmember)
        {
            if (ModelState.IsValid)
            {
                db.dfmember.Add(dfmember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dfmember);
        }

        // GET: dfmembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dfmember dfmember = db.dfmember.Find(id);
            if (dfmember == null)
            {
                return HttpNotFound();
            }
            return View(dfmember);
        }

        // POST: dfmembers/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date,city,location,task,type,who,notion")] dfmember dfmember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dfmember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dfmember);
        }

        // GET: dfmembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dfmember dfmember = db.dfmember.Find(id);
            if (dfmember == null)
            {
                return HttpNotFound();
            }
            return View(dfmember);
        }

        // POST: dfmembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dfmember dfmember = db.dfmember.Find(id);
            db.dfmember.Remove(dfmember);
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
