using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApplication1.Models;

namespace WebApp.Controllers
{
    public class SessionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Session
        public ActionResult Index()
        {
            return View(db.NewSessions.ToList());
        }

       
        // GET: Session/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewSession newSession = db.NewSessions.Find(id);
            if (newSession == null)
            {
                return HttpNotFound();
            }
            return View(newSession);
        }

        // GET: Session/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Session/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Session_Num,Session_Date")] NewSession newSession)
        {
            if (ModelState.IsValid)
            {
                db.NewSessions.Add(newSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newSession);
        }

        // GET: Session/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewSession newSession = db.NewSessions.Find(id);
            if (newSession == null)
            {
                return HttpNotFound();
            }
            return View(newSession);
        }

        // POST: Session/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Session_Num,Session_Date")] NewSession newSession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newSession);
        }

        // GET: Session/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewSession newSession = db.NewSessions.Find(id);
            if (newSession == null)
            {
                return HttpNotFound();
            }
            return View(newSession);
        }

        // POST: Session/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewSession newSession = db.NewSessions.Find(id);
            db.NewSessions.Remove(newSession);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult View1(int? id)
        {
            var sessionSubjects = db.SessionSubjects.Include(s => s.NewSession).Where(m => m.NewSessionID == 2).ToList();
            if (sessionSubjects.Count <1)
            {
                return HttpNotFound();
            }
            else
                return View(sessionSubjects);
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
