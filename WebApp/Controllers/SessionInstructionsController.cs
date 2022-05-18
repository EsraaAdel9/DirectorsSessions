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
    public class SessionInstructionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SessionInstructions
        public ActionResult Index()
        {
            var sessionInstructions = db.SessionInstructions.Include(s => s.NewSession);
            return View(sessionInstructions.ToList());
        }

        // GET: SessionInstructions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionInstructions sessionInstructions = db.SessionInstructions.Find(id);
            if (sessionInstructions == null)
            {
                return HttpNotFound();
            }
            return View(sessionInstructions);
        }

        // GET: SessionInstructions/Create
        public ActionResult Create()
        {
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num");
            return View();
        }

        // POST: SessionInstructions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionInstructions sessionInstructions, HttpPostedFileBase upload)
        {           
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/FileUpload"), upload.FileName);
                upload.SaveAs(path);
                sessionInstructions.Sessionnstructions = upload.FileName;

                db.SessionInstructions.Add(sessionInstructions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", sessionInstructions.NewSessionID);
            return View(sessionInstructions);
        }

        // GET: SessionInstructions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionInstructions sessionInstructions = db.SessionInstructions.Find(id);
            if (sessionInstructions == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", sessionInstructions.NewSessionID);
            ViewBag.NewSessionNum = sessionInstructions.NewSession.Session_Num;
            return View(sessionInstructions);
        }

        // POST: SessionInstructions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SessionInstructions sessionInstructions, HttpPostedFileBase upload)
        {
            //System.IO.File.Delete(oldPath);
            string path = Path.Combine(Server.MapPath("~/FileUpload"), upload.FileName);
            upload.SaveAs(path);
            sessionInstructions.Sessionnstructions = upload.FileName;

            if (ModelState.IsValid)
            {
                db.Entry(sessionInstructions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", sessionInstructions.NewSessionID);
            return View(sessionInstructions);
        }

        // GET: SessionInstructions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionInstructions sessionInstructions = db.SessionInstructions.Find(id);
            if (sessionInstructions == null)
            {
                return HttpNotFound();
            }
            return View(sessionInstructions);
        }

        // POST: SessionInstructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SessionInstructions sessionInstructions = db.SessionInstructions.Find(id);
            db.SessionInstructions.Remove(sessionInstructions);
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
