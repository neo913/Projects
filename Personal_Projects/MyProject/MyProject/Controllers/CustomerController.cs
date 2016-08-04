using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class CustomerController : Controller
    {
        Manager m = new Manager();
        // GET: Customer
        public ActionResult Index()
        {
            return View(m.CustomerGetAll());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.CustomerGetOne(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var form = new CustomerAddForm();
            return View(form);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerAddForm newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }
            var addedItem = m.CustomerAdd(newItem);
            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            var o = m.CustomerGetOne(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = AutoMapper.Mapper.Map<CustomerEditForm>(o);
                return View(form);
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, CustomerEditForm newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = newItem.Id });
            }
            if (id.GetValueOrDefault() != newItem.Id)
            {
                return RedirectToAction("Index");
            }
            var editedItem = m.CustomerEdit(newItem);
            if (editedItem == null)
            {
                return RedirectToAction("Edit", new { id = newItem.Id });
            }
            else
            {
                return RedirectToAction("Details", new { id = newItem.Id });
            }
        }
        
        //
        // GET: Customer/AddCardForCustomer
        [Route("Customer/AddCardForCustomer/{Id}")]
        public ActionResult AddCardForCustomer(int? id)
        {
            var o = m.CustomerGetOne(id.GetValueOrDefault());
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new CardAddForm();
                form.Customer = o;
                form.CustomerId = o.Id;
                form.Numbers = m.CardNumberGenerator();
                form.CVV = m.CVVGenerator();

                return View(form);
            }
        }

        //
        //POST: Customer/AddCardForCustomer
        [Route("Customer/AddCardForCustomer/{Id}")]
        [HttpPost]
        public ActionResult AddCardForCustomer(CardAddForm newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }
            var addedItem = m.CardAddForCustomer(newItem);
            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("../Card/Details", new { id = addedItem.Id });
            }
        }

        //
        // GET: Customer/AddAccountForCustomer
        [Route("Customer/AddAccountForCustomer{Id}")]
        public ActionResult AddAccountForCustomer(int? id)
        {
            var o = m.CustomerGetOne(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new AccountAddForm();
                form.Customer = o;
                form.CustomerId = o.Id;

                return View(form);
            }
        }

        //
        //POST: Customer/AddCardForCustomer
        [Route("Customer/AddAccountForCustomer{Id}/")]
        [HttpPost]
        public ActionResult AddAccountForCustomer(AccountAddForm newItem)
        {
            if (!ModelState.IsValid)
            {

                return View(newItem);
            }
            var addedItem = m.AccountAddForCustomer(newItem);
            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("../AccountInfo/Details", new { id = addedItem.Id });
            }
        }

        /*
        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
