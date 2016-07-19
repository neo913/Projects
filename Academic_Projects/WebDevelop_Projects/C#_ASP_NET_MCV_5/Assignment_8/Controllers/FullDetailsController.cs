using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class FullDetailsController : Controller
    {
        Manager man = new Manager();
        // GET: FullDetails
        public ActionResult Index()
        {
            return View(man.ArtistGetAll());
        }

        // GET: FullDetails/Details/5
        public ActionResult FullDetails(int? id)
        {
            var o = man.ArtistGetOne(id.GetValueOrDefault());
            return View(o);
        }

        // GET: FullDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FullDetails/Create
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

        // GET: FullDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FullDetails/Edit/5
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

        // GET: FullDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FullDetails/Delete/5
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
