using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class SearchController : Controller
    {
        Manager m = new Manager();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        
        // POST: Search
        [HttpPost]
        public ActionResult Index(String str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return HttpNotFound();
            }
            var foundItem = m.SearchId(str);
            if(foundItem == null)
            {
                return View();
            }
            else
            {
                TempData["foundItem"] = foundItem;
                return RedirectToAction("SearchedResult");
            }
        }

        // GET: SearchedResult/5
        [HttpGet]
        public ActionResult SearchedResult()
        {
            var foundItem = TempData["foundItem"] as List<CardWithDetails>;
            return View(foundItem);
        }
        
        // GET: Search/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.CardGetOne(id.GetValueOrDefault());
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
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

        // GET: Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Search/Edit/5
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

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Search/Delete/5
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
