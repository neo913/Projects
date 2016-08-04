using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class BankController : Controller
    {
        Manager m = new Manager();
        ApplicationDbContext ds = new ApplicationDbContext();

        // GET: Bank/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST: Bank/Index
        [HttpPost]
        public ActionResult Index(long Numbers)
        {
            var o = m.CardSearch(Numbers);
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                TempData["SearchedBank"] = o;
                return RedirectToAction("BankInfo");
            }
        }
        
        // GET: Bank/BankInfo
        [HttpGet]
        [Route("Bank/BankInfo/{Numbers}")]
        public ActionResult BankInfo(CardWithDetails foundItem)
        {
            foundItem = TempData["SearchedBank"] as CardWithDetails;
            var o = m.CustomerGetOne(foundItem.CustomerId);
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Bank/Customer/5
        public ActionResult BankCustomer(int? id)
        {
            var o = m.CustomerGetOne(id.GetValueOrDefault());
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Bank/BankCard/5
        public ActionResult BankCard(int? id)
        {
            var o = m.CardGetAllByCustomer(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        //GET: Bank/BankAccount/5
        public ActionResult BankAccount(int? id)
        {
            var o = m.AccountGetAllByCustomer(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Bank/Records/{Id}
        [Route("Bank/Records/{Id}")]
        public ActionResult Records(int? id)
        {
            var o = m.AccountGetOne(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o.Records.OrderByDescending(d => d.Date));
            }
        }
    }
}
