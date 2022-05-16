using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.ViewModel;
using WebApplication1.Models;

namespace WebApp.Controllers
{
    public class MemoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Memo
        public ActionResult Index(int id)
        {
            var list = db.MemoTypes.ToList();
            ViewBag.Result = id.ToString();

            return View(list);
        }


        // GET: Memo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Memo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Memo/Create
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

        // GET: Memo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Memo/Edit/5
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

        // GET: Memo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Memo/Delete/5
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
