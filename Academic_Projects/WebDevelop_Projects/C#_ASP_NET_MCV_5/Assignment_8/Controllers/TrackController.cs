using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_8.Controllers
{
    public class TrackController : Controller
    {
        Manager man = new Manager();
        // GET: Track
        public ActionResult Index()
        {
            return View(man.TrackGetAll());
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            var o = man.TrackGetOne(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                o.Clerk = User.Identity.Name;
                return View(o);
            }
        }

        [Authorize(Roles = "Clerk")]
        public ActionResult Create()
        {
            var form = new TrackAddForm();
            form.GenreList = new SelectList(man.GenreGetAll(), "Id", "Name");
            return View(form);
        }

        // POST: Track/Create
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Create(TrackAdd newItem)
        {
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
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

        // GET: Track/Edit/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id)
        {
            var o = man.TrackGetOne(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = AutoMapper.Mapper.Map<TrackEditForm>(o);
                var selectedValues = o.Albums.Select(e => e.Id);

                form.GenreList = new SelectList(man.GenreGetAll(), "Id", "Name", selectedValue: o.GenreId);
                form.AlbumList = new MultiSelectList(items: man.AlbumGetAll(),
                                                    dataValueField: "Id",
                                                    dataTextField: "Name",
                                                    selectedValues: selectedValues);
                form.CurrentAlbums = o.Albums;
                form.Composer = o.Composers;

                return View(form);
            }
        }

        // POST: Track/Edit/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Edit(int? id, TrackEditForm newItem)
        {
            newItem.GenreList = new SelectList(man.GenreGetAll(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newItem.Id });
            }
            if (id.GetValueOrDefault() != newItem.Id)
            {
                return RedirectToAction("index");
            }

            var editedItem = man.TrackEdit(newItem);

            if (editedItem == null)
            {
                return RedirectToAction("edit", new { id = newItem.Id });
            }
            else
            {
                return RedirectToAction("details", new { id = newItem.Id });
            }
        }

        // GET: Track/Delete/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = man.TrackGetOne(id.GetValueOrDefault());
            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Track/Delete/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = man.TrackDelete(id.GetValueOrDefault());
            return RedirectToAction("index");
        }
    }
}
