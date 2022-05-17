using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApp.Controllers
{
    public class MainController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Main
        public ActionResult Index()
        {
            var session = db.NewSessions.Max(u => u.ID);
            ViewBag.sessionid = session.ToString();
            var num = db.NewSessions.SingleOrDefault(m => m.ID == session);
            var report = db.SessionReports.SingleOrDefault(m => m.ID == session);
            var schadule = db.SessionSchedules.SingleOrDefault(m => m.ID == session);

            ViewBag.sessionnum = num.Session_Num;
            ViewBag.sessiondate = num.Session_Date;


            if (report.SessionFile!=null)
                ViewBag.rep = report.SessionFile;
            else
                ViewBag.rep = "";

            //if (schadule.ScheduleFile != null)
            //    ViewBag.sch = schadule.ScheduleFile;
            //else
            //    ViewBag.sch = "";


            return View();
        }

        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Main/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Main/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Main/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
