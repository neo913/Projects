using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class CardController : Controller
    {
        Manager m = new Manager();
        // GET: Card
        public ActionResult Index()
        {
            return View(m.CardGetAll());
        }

        // GET: Card/Details/5
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

        // GET: Card/Create
        public ActionResult Create()
        {
            var form = new CardAddForm();
            form.Numbers = m.CardNumberGenerator();
            form.CVV = m.CVVGenerator();
            return View(form);
        }

        // POST: Card/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(CardAddForm newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }
            var addedItem = m.CardAdd(newItem);
            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }
        }

        // GET: Card/AddCustomer
        [Route("Card/{Id}/AddCustomer")]
        public ActionResult AddCustomer(int? id)
        {
            var o = m.CardGetOne(id.GetValueOrDefault());
            if (o == null)
            {
                return null; 
            }
            else
            {
                var form = new CustomerAddForm();
                return View(form);
            }
        }

        // POST: Card/AddCustomer
        [Route("Card/{Id}/AddCustomer")]
        [HttpPost]
        public ActionResult AddCustomer(CustomerAdd newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }
            var addedItem = m.CustomerAdd(newItem);
            if(addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("../Customer/Details", new { id = addedItem.Id });
            }
        }
        /*
        // GET: Card/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Card/Edit/5
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

        // GET: Card/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Card/Delete/5
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
        */
    }
}
