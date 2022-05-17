using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApplication1.Models;

namespace WebApp.Controllers
{
    public class SessionReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SessionReports
        public ActionResult Index()
        {
            var sessionReports = db.SessionReports.Include(s => s.NewSession);
            return View(sessionReports.ToList());
        }

        // GET: SessionReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionReport sessionReport = db.SessionReports.Find(id);
            if (sessionReport == null)
            {
                return HttpNotFound();
            }
            return View(sessionReport);
        }

        // GET: SessionReports/Create
        public ActionResult Create()
        {
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num");
            return View();
        }

        // POST: SessionReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionReport sessionReport, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/FileUpload"), upload.FileName);
                upload.SaveAs(path);
                sessionReport.SessionFile = upload.FileName;

                db.SessionReports.Add(sessionReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", sessionReport.NewSessionID);
            return View(sessionReport);
        }

        // GET: SessionReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionReport sessionReport = db.SessionReports.Find(id);
            if (sessionReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", sessionReport.NewSessionID);
            return View(sessionReport);
        }

        // POST: SessionReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SessionReport sessionReport, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                //System.IO.File.Delete(oldPath);
                string path = Path.Combine(Server.MapPath("~/FileUpload"), upload.FileName);
                upload.SaveAs(path);
                sessionReport.SessionFile = upload.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(sessionReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", sessionReport.NewSessionID);
            return View(sessionReport);
        }

        // GET: SessionReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionReport sessionReport = db.SessionReports.Find(id);
            if (sessionReport == null)
            {
                return HttpNotFound();
            }
            return View(sessionReport);
        }

        // POST: SessionReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SessionReport sessionReport = db.SessionReports.Find(id);
            db.SessionReports.Remove(sessionReport);
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
