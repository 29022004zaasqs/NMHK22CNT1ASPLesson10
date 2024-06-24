using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NMHLesson10.Models;

namespace NMHLesson10.Controllers
{
    public class KhoasController : Controller
    {
        private NmhK22CNT1Lesson10Entities db = new NmhK22CNT1Lesson10Entities();

        // GET: Khoas
        public ActionResult NmhIndex()
        {
            return View(db.Khoa.ToList());
        }

        // GET: Khoas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa khoa = db.Khoa.Find(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // GET: Khoas/NmhCreate
        public ActionResult NmhCreate()
        {
            return View();
        }

        // POST: Khoas/NmhCreate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NmhCreate([Bind(Include = "MaKH,TenKH")] Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                db.Khoa.Add(khoa);
                db.SaveChanges();
                return RedirectToAction("NmhIndex");
            }

            return View(khoa);
        }

        // GET: Khoas/NmhEdit/5
        public ActionResult NmhEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa khoa = db.Khoa.Find(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // POST: Khoas/NmhEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NmhEdit([Bind(Include = "MaKH,TenKH")] Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NmhIndex");
            }
            return View(khoa);
        }

        // GET: Khoas/NmhDelete/5
        public ActionResult NmhDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa khoa = db.Khoa.Find(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // POST: Khoas/NmhDelete/5
        [HttpPost, ActionName("NmhDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult NmhDeleteConfirmed(string id)
        {
            Khoa khoa = db.Khoa.Find(id);
            db.Khoa.Remove(khoa);
            db.SaveChanges();
            return RedirectToAction("NmhIndex");
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
