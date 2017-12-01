using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Annonssystem.Models;

namespace Annonssystem.Controllers
{
    public class annonsorerController : Controller
    {
        private adsEntities db = new adsEntities();

        // GET: annonsorer
        public ActionResult Index()
        {
            return View(db.tbl_annonsorer.ToList());
        }

        // GET: annonsorer/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_annonsorer tbl_annonsorer = db.tbl_annonsorer.Find(id);
           
            if (tbl_annonsorer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_annonsorer);
        }

        // GET: annonsorer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: annonsorer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "an_ID,an_corp,an_name,an_srName,an_adr,an_poCode,an_city")] tbl_annonsorer tbl_annonsorer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_annonsorer.Add(tbl_annonsorer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_annonsorer);
        }

        // GET: annonsorer/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_annonsorer tbl_annonsorer = db.tbl_annonsorer.Find(id);
            if (tbl_annonsorer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_annonsorer);
        }

        // POST: annonsorer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "an_ID,an_corp,an_name,an_srName,an_adr,an_poCode,an_city")] tbl_annonsorer tbl_annonsorer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_annonsorer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_annonsorer);
        }

        // GET: annonsorer/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_annonsorer tbl_annonsorer = db.tbl_annonsorer.Find(id);
            if (tbl_annonsorer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_annonsorer);
        }

        // POST: annonsorer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tbl_annonsorer tbl_annonsorer = db.tbl_annonsorer.Find(id);
            db.tbl_annonsorer.Remove(tbl_annonsorer);
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
