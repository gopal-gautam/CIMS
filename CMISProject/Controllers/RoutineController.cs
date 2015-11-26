using CMISProject.DAL;
using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CMISProject.Controllers
{
    public class RoutineController : Controller
    {
        //
        private CIMSEntities db = new CIMSEntities();

        // GET: /Routine/
        public ActionResult Index()
        {
                return View(db.Routines.ToList());
        }

        //
        // GET: /Routine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = db.Routines.Find(id);
            if (routine == null)
            {
                return new HttpNotFoundResult();
            }

            return View(routine);
        }

        //
        // GET: /Routine/Create
        public ActionResult Create()
        {
            return View(new Routine());
        }

        //
        // POST: /Routine/Create
        [HttpPost]
        public ActionResult Create(Routine routine)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Routines.Add(routine);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(routine);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Routine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = db.Routines.Find(id);
            if (routine == null)
            {
                return new HttpNotFoundResult();
            }

            return View(routine);
        }

        //
        // POST: /Routine/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Routine routine)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(routine).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(routine);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Routine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Routine routine = db.Routines.Find(id);

            if (routine == null)
            {
                return new HttpNotFoundResult();
            }
            return View(routine);
        }

        //
        // POST: /Routine/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Routine routine = db.Routines.Find(id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
