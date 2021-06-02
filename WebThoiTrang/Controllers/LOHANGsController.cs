using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;

namespace WebThoiTrang.Controllers
{
    public class LOHANGsController : Controller
    {
        private CT25Team12Entities db = new CT25Team12Entities();

        // GET: LOHANGs
        public ActionResult Index()
        {
            var lOHANGs = db.LOHANGs.Include(l => l.NHAPHANKHOI);
            return View(lOHANGs.ToList());
        }

        // GET: LOHANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOHANG lOHANG = db.LOHANGs.Find(id);
            if (lOHANG == null)
            {
                return HttpNotFound();
            }
            return View(lOHANG);
        }

        // GET: LOHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MANPP = new SelectList(db.NHAPHANKHOIs, "MANPP", "QUAN");
            return View();
        }

        // POST: LOHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOHANG,NGAYNHAP,MANPP")] LOHANG lOHANG)
        {
            if (ModelState.IsValid)
            {
                db.LOHANGs.Add(lOHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MANPP = new SelectList(db.NHAPHANKHOIs, "MANPP", "QUAN", lOHANG.MANPP);
            return View(lOHANG);
        }

        // GET: LOHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOHANG lOHANG = db.LOHANGs.Find(id);
            if (lOHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MANPP = new SelectList(db.NHAPHANKHOIs, "MANPP", "QUAN", lOHANG.MANPP);
            return View(lOHANG);
        }

        // POST: LOHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOHANG,NGAYNHAP,MANPP")] LOHANG lOHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MANPP = new SelectList(db.NHAPHANKHOIs, "MANPP", "QUAN", lOHANG.MANPP);
            return View(lOHANG);
        }

        // GET: LOHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOHANG lOHANG = db.LOHANGs.Find(id);
            if (lOHANG == null)
            {
                return HttpNotFound();
            }
            return View(lOHANG);
        }

        // POST: LOHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOHANG lOHANG = db.LOHANGs.Find(id);
            db.LOHANGs.Remove(lOHANG);
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
