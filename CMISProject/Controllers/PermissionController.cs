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
    [Authorize(Roles="SuperAdmin")]
    public class PermissionController : Controller
    {
        //
        // GET: /Permission/

        CIMSEntities db = new CIMSEntities();

        public ActionResult Index()
        {
            
            return View(db.Permissions.ToList());
        }

        //
        // GET: /Permission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return new HttpNotFoundResult();
            }
            return View(permission);
        }

        //
        // GET: /Permission/Create
        public ActionResult Create()
        {
            return View(new Permission());
        }

        //
        // POST: /Permission/Create
        [HttpPost]
        public ActionResult Create(Permission permission)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Permissions.Add(permission);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(permission);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Permission/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permissions.Find(id);
            if (permission== null)
            {
                return new HttpNotFoundResult();
            }

            return View(permission);
        }

        //
        // POST: /Permission/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Permission permission)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(permission).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(permission);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Permission/Delete/5
        public ActionResult Delete(int? id)
        {
            Permission permission = db.Permissions.Find(id);
            return View(permission);
        }

        //
        // POST: /Permission/Delete/5
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
    }
}
