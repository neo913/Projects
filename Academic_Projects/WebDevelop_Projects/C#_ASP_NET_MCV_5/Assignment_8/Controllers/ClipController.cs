using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class ClipController : Controller
    {
        Manager man = new Manager();
        // GET: Clip
        public ActionResult Index()
        {
            return View("index", "home");
        }

        // GET: Clip/Details/5
        [Route("clip/{id}")]
        public ActionResult Details(int? id)
        {
            var o = man.TrackClipGetOne(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                /*
                System.Diagnostics.Debug.WriteLine("In Clip Controller");
                System.Diagnostics.Debug.WriteLine("TrackID " + o.Id);
                System.Diagnostics.Debug.WriteLine("TrackLength " + o.Content.Length);
                System.Diagnostics.Debug.WriteLine("ContentType " + o.ContentType);
                */
                return File(o.Content, o.ContentType);
            }
        }
    }
}
        