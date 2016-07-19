using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class AlbumController : Controller
    {
        Manager man = new Manager();
        // GET: Album
        public ActionResult Index()
        {
            return View(man.AlbumGetAll());
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            var o = man.AlbumGetOne(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                o.Coordinator = User.Identity.Name;
                return View(o);
            }
        }

        // GET: Album/AddTrack
        [Authorize(Roles = "Clerk")]
        [Route("album/{Id}/addtrak")]
        public ActionResult AddTrack(int? id)
        {
            var o = man.AlbumGetOne(id.GetValueOrDefault());
            if (o == null)
            {
                return null;
            }
            else
            {
                var form = new TrackAddForm();
                form.AlbumId = (int)id;
                form.AlbumName = o.Name;
                form.GenreList = new SelectList(man.GenreGetAll(), "Id", "Name");

                return View(form);
            }
        }

        // POST: Album/AddTrack
        [Authorize(Roles = "Clerk")]
        [Route("album/{Id}/addtrak")]
        [HttpPost]
        public ActionResult AddTrack(TrackAdd newItem)
        {
            /*
            System.Diagnostics.Debug.WriteLine("In Post");
            System.Diagnostics.Debug.WriteLine("TrackID " + newItem.Id);
            System.Diagnostics.Debug.WriteLine("TrackName " + newItem.Name);
            System.Diagnostics.Debug.WriteLine("AlbumId " + newItem.AlbumId);
            System.Diagnostics.Debug.WriteLine("AlbumName " + newItem.AlbumName);
            System.Diagnostics.Debug.WriteLine("Composers " + newItem.Composers);
            System.Diagnostics.Debug.WriteLine("contentLength " + newItem.ClipUpload.ContentLength);
            System.Diagnostics.Debug.WriteLine("contentType " + newItem.ClipUpload.ContentType);
            //newItem.GenreList = new SelectList(man.GenreGetAll(), "Id", "Name");
            */
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }
            var addedItem = man.TrackAdd(newItem);
            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                /*
                System.Diagnostics.Debug.WriteLine("In Post2");
                System.Diagnostics.Debug.WriteLine("TrackID " + addedItem.Id);
                System.Diagnostics.Debug.WriteLine("TrackName " + addedItem.Name);
                System.Diagnostics.Debug.WriteLine("AlbumId " + addedItem.AlbumId);
                System.Diagnostics.Debug.WriteLine("AlbumName " + addedItem.AlbumName);
                System.Diagnostics.Debug.WriteLine("Composers " + addedItem.Composers);
                System.Diagnostics.Debug.WriteLine("contentLength " + addedItem.Content);
                System.Diagnostics.Debug.WriteLine("contentType " + addedItem.ContentType);
                */
                return RedirectToAction("../Track/details", new { id = addedItem.Id });
            }
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
        }

        // POST: Album/Edit/5
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

        // GET: Album/Delete/5
        [Authorize(Roles = "Coordinator")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = man.AlbumGetOne(id.GetValueOrDefault());
            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Album/Delete/5
        [Authorize(Roles = "Coordinator")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = man.AlbumDelete(id.GetValueOrDefault());
            return RedirectToAction("index");
        }
    }
}
