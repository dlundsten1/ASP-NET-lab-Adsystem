using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Annonssystem.Models;
using Newtonsoft.Json;

namespace Annonssystem.Controllers
{
    public class adsController : Controller
    {
        private adsEntities db = new adsEntities();

        // GET: ads
        public ActionResult Index()
        {



            var tbl_ads = db.tbl_ads.Include(t => t.tbl_annonsorer);

            return View(tbl_ads.ToList());



        }
        

        public ActionResult Index2()
        {
            ViewBag.collapse = "collapse";
            return View();

        }
       
        [HttpPost]
        public ActionResult Index2(FormCollection fc)
        {
            ViewBag.collapse = "collapse in";
            string url = "http://localhost:50127/api/tbl_sub/"+fc["ID"];
            WebClient syncCLient = new WebClient();
            string result = syncCLient.DownloadString(url);
         
                
               
            APIModel annonsor = JsonConvert.DeserializeObject<APIModel>(result);
            
            tbl_annonsorer TravAnnonsor = new tbl_annonsorer();
            long ID = Convert.ToInt64(fc["ID"]);

            TravAnnonsor.an_ID = ID;
            TravAnnonsor.an_name = annonsor.sub_frName;
            TravAnnonsor.an_srName = annonsor.sub_srName;
            TravAnnonsor.an_adr = annonsor.sub_adress;
            TravAnnonsor.an_poCode = annonsor.sub_poCode;

            ViewBag.ID = ID;

            db.tbl_annonsorer.Add(TravAnnonsor);
            db.SaveChanges();
                       
           tbl_annonsorer tbl_annonsorer = db.tbl_annonsorer.Find(ID);

            ViewBag.result = result;
            return View(tbl_annonsorer);
            

        }

        public ActionResult Private(int id)
        {
            ViewBag.Parameter = id.ToString();
            return View();

        }



        // GET: ads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ads tbl_ads = db.tbl_ads.Find(id);
            if (tbl_ads == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ads);
        }
     
        // GET: ads/Create
        public ActionResult Create()
        {
           
            ViewBag.ads_annonsor = new SelectList(db.tbl_annonsorer, "an_ID", "an_name");
            return View();
        }

        // POST: ads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ads_ID,ads_category,ads_content,ads_price,ads_annonsor")] tbl_ads tbl_ads)
        {           
            if (ModelState.IsValid)
            {
                db.tbl_ads.Add(tbl_ads);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ads_annonsor = new SelectList(db.tbl_annonsorer, "an_ID", "an_name", tbl_ads.ads_annonsor);
            return View(tbl_ads);
        }

        // GET: ads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ads tbl_ads = db.tbl_ads.Find(id);
            if (tbl_ads == null)
            {
                return HttpNotFound();
            }
            ViewBag.ads_annonsor = new SelectList(db.tbl_annonsorer, "an_ID", "an_name", tbl_ads.ads_annonsor);
            return View(tbl_ads);
        }

        // POST: ads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ads_ID,ads_category,ads_content,ads_price,ads_annonsor")] tbl_ads tbl_ads)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ads).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ads_annonsor = new SelectList(db.tbl_annonsorer, "an_ID", "an_name", tbl_ads.ads_annonsor);
            return View(tbl_ads);
        }

        // GET: ads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ads tbl_ads = db.tbl_ads.Find(id);
            if (tbl_ads == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ads);
        }

        // POST: ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ads tbl_ads = db.tbl_ads.Find(id);
            db.tbl_ads.Remove(tbl_ads);
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
