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
            var prevsession = db.NewSessions.Max(u => u.ID-1);
            if (prevsession!=0)
            {
                var currentsessionnum = db.NewSessions.Max(u => u.ID);

                ViewBag.sessionid = currentsessionnum.ToString();
                var currentnum = db.NewSessions.SingleOrDefault(m => m.ID == currentsessionnum);
                var num = db.NewSessions.SingleOrDefault(m => m.ID == prevsession);
                var report = db.SessionReports.SingleOrDefault(m => m.NewSessionID == prevsession);
                var schadule = db.SessionSchedules.SingleOrDefault(m => m.NewSessionID == prevsession);
                var instraction = db.SessionInstructions.SingleOrDefault(m => m.NewSessionID == prevsession);

                ViewBag.prevsessionnum = num.Session_Num;
                ViewBag.currentsessionnum = currentnum.Session_Num;
                ViewBag.currentsessionday = currentnum.Session_Day;

                ViewBag.sessiondate = currentnum.Session_Date.ToString("dd-MM-yyyy");


                if (report != null)
                    ViewBag.rep = report.SessionFile;
                else
                    ViewBag.rep = "";


                if (schadule != null)
                    ViewBag.sch = schadule.ScheduleFile;
                else
                    ViewBag.sch = "";

                if (instraction != null)
                    ViewBag.instract = instraction.Sessionnstructions;
                else
                    ViewBag.instract = "";
            }
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
