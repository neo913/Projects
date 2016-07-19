using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class ArtistController : Controller
    {
        Manager man = new Manager();
        // GET: Artist
        public ActionResult Index()
        {
            return View(man.ArtistGetAll());
        }

        // GET: Artist/Details/5
        public ActionResult Details(int? id)
        {
            var o = man.ArtistGetOne(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                o.Executive = User.Identity.Name;
                return View(o);
            }
        }

        //GET: Artists/DetailsWithMediaItemInfo/5
        public ActionResult DetailsWithMediaInfo(int? id)
        {
            var o = man.ArtistGetByIdWithMediaItemInfo(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Artist/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddForm();
            form.GenreList = new SelectList(man.GenreGetAll(), "Id", "Name");
            return View(form);
        }

        // POST: Artist/Create
        [Authorize(Roles = "Executive")]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ArtistAddForm newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }
            var addedItem = man.ArtistAdd(newItem);
            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }
        // Get: Artist/AddAlbum
        [Authorize(Roles = "Coordinator")]
        [Route("artist/{Id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var o = man.ArtistGetOne(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new AlbumAddForm();
                form.CurrentArtist = o;
                form.GenreList = new SelectList(man.GenreGetAll(), "Id", "Name");
                return View(form);
            }
        }

        // POST: Artist/AddAlbum
        [Authorize(Roles = "Coordinator")]
        [Route("artist/{Id}/addalbum")]
        [HttpPost]
        public ActionResult AddAlbum(AlbumAddForm newItem)
        {
            Debug.WriteLine("In Post 1");
            Debug.WriteLine("Coordinator : " + newItem.Coordinator);
            Debug.WriteLine("Description : " + newItem.Description);
            Debug.WriteLine("GenreId : " + newItem.GenreId);
            Debug.WriteLine("Name : " + newItem.Name);
            Debug.WriteLine("ReleaseDate : " + newItem.ReleaseDate);
            Debug.WriteLine("UrlAlbum : " + newItem.UrlAlbum);

            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            var addedItem = man.AlbumAdd(newItem);
            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                Debug.WriteLine("In Post 2");
                Debug.WriteLine("Coordinator : " + newItem.Coordinator);
                Debug.WriteLine("Description : " + newItem.Description);
                Debug.WriteLine("Name : " + newItem.Name);
                Debug.WriteLine("ReleaseDate : " + newItem.ReleaseDate);
                Debug.WriteLine("UrlAlbum : " + newItem.UrlAlbum);

                return RedirectToAction("../Album/details", new { id = addedItem.Id });
            }
        }

        //GET: Artist/AddMediaItem
        [Route("artists/{Id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id)
        {
            var o = man.ArtistGetOne(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                //Crete a form
                var form = new MediaItemAddForm();
                //Configure its property values
                form.ArtistId = o.Id;
                form.AtistInfo = $"{o.Name}";

                //Pass the object to the view
                return View(form);
            }
        }

        //POST: Artist/5/AddMediaItem
        [HttpPost]
        [Route("artists/{Id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id, MediaItemAdd newItem)
        {
            //Validate the input
            //Two conditions must be checked
            if (!ModelState.IsValid && id.GetValueOrDefault() == newItem.ArtistId)
            {
                return View(newItem);
            }

            //Process the input
            var addedItem = man.ArtistMediaItemAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }
        }

        // GET: Artist/Edit/5
        [Authorize(Roles = "Executive")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artist/Edit/5
        [Authorize(Roles = "Executive")]
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

        [Authorize(Roles = "Executive")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = man.ArtistGetOne(id.GetValueOrDefault());
            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Artist/Delete/5
        [Authorize(Roles = "Executive")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = man.ArtistDelete(id.GetValueOrDefault());
            return RedirectToAction("index");
        }
    }
}
