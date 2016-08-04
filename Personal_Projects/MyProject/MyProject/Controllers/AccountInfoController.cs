using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class AccountInfoController : Controller
    {
        Manager m = new Manager();
        // GET: AccountInfo
        public ActionResult Index()
        {
            return View(m.AccountGetAll());
        }

        // GET: AccountInfo/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.AccountGetOne(id.GetValueOrDefault());
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: AccountInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            var o = m.AccountGetOne(id.GetValueOrDefault());
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = AutoMapper.Mapper.Map<AccountEditForm>(o);
                form.CurrentCustomer = o.Customer;
                return View(form);
            }
        }

        // POST: AccountInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, AccountEditForm newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = newItem.Id });
            }
            if(id.GetValueOrDefault() != newItem.Id)
            {
                return RedirectToAction("Index");
            }
            var editedItem = m.AccountEdit(newItem);
            if(editedItem == null)
            {
                return RedirectToAction("Edit", new { id = newItem.Id });
            }
            else
            {
                return RedirectToAction("Details", new { id = newItem.Id });
            }
        }

        // GET : AccountInfo/Transaction/5
        public ActionResult Transaction(int? id)
        {
            var o = m.AccountGetOne(id.GetValueOrDefault());
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = AutoMapper.Mapper.Map<AccountEditForm>(o);
                form.CurrentCustomer = o.Customer;
                return View(form);
            }
        }

        // POST : AccountInfo/Transaction/5
        [HttpPost]
        public ActionResult Transaction(int? id, AccountEditForm newItem)
        {
            if(id.GetValueOrDefault() != newItem.Id)
            {
                return RedirectToAction("Index");
            }
            var editedItem = m.Transaction(newItem);
            if (editedItem == null)
            {
                return RedirectToAction("Transaction", new { id = newItem.Id });
            }
            else
            {
                return RedirectToAction("Details", new { id = newItem.Id });
            }
        }

        // GET: AccountInfo/Records/{Id}
        [Route("AccountInfo/Records/{Id}")]
        public ActionResult Records(int? id)
        {
            var o = m.AccountGetOne(id.GetValueOrDefault());
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o.Records.OrderByDescending(d => d.Date));
            }
        }

        /*
        // GET: AccountInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountInfo/Create
        [HttpPost]
        public ActionResult Create(AccountAddForm newItem)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var addedItem = m.AccountAdd(newItem);
            if(addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }
        }

        // GET: AccountInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountInfo/Edit/5
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

        // GET: AccountInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountInfo/Delete/5
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
