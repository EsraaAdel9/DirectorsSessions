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
using WebApp.ViewModel;
using WebApplication1.Models;

namespace WebApp.Controllers
{
    public class SubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subjects

        //public ActionResult Index()
        //{
        //    var sessionSubjects = db.SessionSubjects.Include(s => s.NewSession);
        //    return View(sessionSubjects.ToList());
        //}

        public ActionResult Index(int? id)
        {
            var sessionSubjects = db.SessionSubjects.Include(s => s.NewSession);

            if (id != null)
            {
                sessionSubjects = db.SessionSubjects.Include(s => s.NewSession).Where(m => m.NewSessionID == id);
                return View(sessionSubjects.ToList());
            }
            return View(sessionSubjects.ToList());
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionSubjects sessionSubjects = db.SessionSubjects.Find(id);
            if (sessionSubjects == null)
            {
                return HttpNotFound();
            }
            return View(sessionSubjects);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", "اختر");
            var viewmodel = new SubjectViewMode
            {
                MemoTypes = db.MemoTypes.ToList()
            };        
            return View(viewmodel);
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectViewMode model, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {


                //string filename = Path.GetFileName(upload.FileName);
                //string filepath = Path.Combine(Server.MapPath("~/Uploads"), filename);
                //upload.SaveAs(filepath);
                
                //ViewBag.Message = "Uploded";

                string path = Path.Combine(Server.MapPath("~/FileUpload"), upload.FileName);
                upload.SaveAs(path);
                model.Sub_File = upload.FileName;

                //model.Sub_File = path;

                var Sub = new SessionSubjects()
                {
                    Sub_ID = model.Sub_ID,
                    Sub_Name = model.Sub_Name,
                    Sub_File = model.Sub_File,
                    NewSessionID = model.NewSessionID,
                    MemoTypesID = model.MemoTypesID
                };

                db.SessionSubjects.Add(Sub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num");
            var viewmodel = new SubjectViewMode
            {
                MemoTypes = db.MemoTypes.ToList()
            }; 
            
            return View(viewmodel);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionSubjects sessionSubjects = db.SessionSubjects.Find(id);
            if (sessionSubjects == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", sessionSubjects.NewSessionID);
            var viewmodel = new SubjectViewMode
            {
                Sub_ID= sessionSubjects.Sub_ID,
                Sub_Name = sessionSubjects.Sub_Name,
                MemoTypesID = sessionSubjects.MemoTypesID,
                NewSessionID = sessionSubjects.NewSessionID,
                Sub_File = sessionSubjects.Sub_File,
                MemoTypes = db.MemoTypes.ToList()
            };
            return View(viewmodel);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Sub_ID,Sub_Name,Sub_File,NewSessionID,MemoTypesID")] SessionSubjects Sub, HttpPostedFileBase upload)
        {
            //string oldPath = Path.Combine(Server.MapPath("~/FileUpload"), Sub.Sub_File);

            if (upload != null)
            {
                //System.IO.File.Delete(oldPath);
                string path = Path.Combine(Server.MapPath("~/FileUpload"), upload.FileName);
                upload.SaveAs(path);
                Sub.Sub_File = upload.FileName;
            }

            if (ModelState.IsValid)
            {
                

                db.Entry(Sub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NewSessionID = new SelectList(db.NewSessions, "ID", "Session_Num", Sub.NewSessionID);
            var viewmodel = new SubjectViewMode
            {
                Sub_ID = Sub.Sub_ID,
                Sub_Name = Sub.Sub_Name,
                MemoTypesID = Sub.MemoTypesID,
                NewSessionID = Sub.NewSessionID,
                Sub_File = Sub.Sub_File,
                MemoTypes = db.MemoTypes.ToList()
            };
            return View(viewmodel);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionSubjects sessionSubjects = db.SessionSubjects.Find(id);
            if (sessionSubjects == null)
            {
                return HttpNotFound();
            }
            return View(sessionSubjects);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SessionSubjects sessionSubjects = db.SessionSubjects.Find(id);
            db.SessionSubjects.Remove(sessionSubjects);
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
