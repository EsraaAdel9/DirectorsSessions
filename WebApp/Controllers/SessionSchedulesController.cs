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
    public class SessionSchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SessionSchedules
        public ActionResult Index()
        {
            var sessionSchedules = db.SessionSchedules.Include(s => s.NewSession);
            return View(sessionSchedules.ToList());
        }

        // GET: SessionSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionSchedule sessionSchedule = db.SessionSchedules.Find(id);
            if (sessionSchedule == null)
            {
                return HttpNotFound();
            }
            return View(sessionSchedule);
        }

        // GET: SessionSchedules/Create
        public ActionResult Create()
        {
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num");
            return View();
        }

        // POST: SessionSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionSchedule sessionSchedule, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/FileUpload"), upload.FileName);
                upload.SaveAs(path);
                sessionSchedule.ScheduleFile = upload.FileName;

                db.SessionSchedules.Add(sessionSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", sessionSchedule.NewSessionID);
            return View(sessionSchedule);
        }

        // GET: SessionSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionSchedule sessionSchedule = db.SessionSchedules.Find(id);
            if (sessionSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", sessionSchedule.NewSessionID);
            return View(sessionSchedule);
        }

        // POST: SessionSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SessionSchedule sessionSchedule, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string path = Path.Combine(Server.MapPath("~/FileUpload"), upload.FileName);
                upload.SaveAs(path);
                sessionSchedule.ScheduleFile = upload.FileName;
            }

            if (ModelState.IsValid)
            {
                db.Entry(sessionSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", sessionSchedule.NewSessionID);
            return View(sessionSchedule);
        }

        // GET: SessionSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionSchedule sessionSchedule = db.SessionSchedules.Find(id);
            if (sessionSchedule == null)
            {
                return HttpNotFound();
            }
            return View(sessionSchedule);
        }

        // POST: SessionSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SessionSchedule sessionSchedule = db.SessionSchedules.Find(id);
            db.SessionSchedules.Remove(sessionSchedule);
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
