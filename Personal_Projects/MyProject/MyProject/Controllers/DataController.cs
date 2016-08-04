using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MyProject.Controllers
{
    public class DataController : Controller
    {
        Manager m = new Manager();
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ResetData()
        {
            String content = "";
            int falseCount = 0;
            if (m.RemoveDataBase())
            {
                content += "[DataBase has been Removed]\r\n]";
            }
            else
            {
                content += "[DataBase has NOT been Removed]\r\n";
                falseCount++;
            }

            if (m.RemoveData())
            {
                content += "[Data has been Removed]\r\n";
            }
            else
            {
                content += "[Data has NOT been Removed]\r\n";
                falseCount++;
            }

            if (m.LoadData())
            {
                content += "[Data has been Loaded]\r\n";
            }
            else
            {
                content += "[Data has NOT been Loaded]\r\n";
                falseCount++;
            }

            if(falseCount > 0)
            {
                content += "\r\n\r\n[Data has NOT been reset]";
                return Content(content);
            }
            else
            {
                content += "\r\n\r\n[Data has been reset]";
                return Content(content);
            }
        }
        public ActionResult LoadData()
        {
            if (m.LoadData())
            {
                return Content("Data has been loaded");
            }
            else
            {
                return Content("Data exists already");
            }
        }
        public ActionResult RemoveData()
        {
            if (m.RemoveData())
            {
                return Content("Data has been removed");
            }
            else
            {
                return Content("Could not remove data");
            }
        }
        public ActionResult RemoveDataBase()
        {
            if (m.RemoveDataBase())
            {
                return Content("Database has been removed");
            }
            else
            {
                return Content("Could not remove database");
            }
        }
    }
}
        