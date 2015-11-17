using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMISProject.Models;
using CMISProject.DAL;

namespace CMISProject.Controllers
{
    public class UserPermissionController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        // GET: /UserPermission/
        public ActionResult Index()
        {
            return View(db.UserPermissions.ToList());
        }

        // GET: /UserPermission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPermission userpermission = db.UserPermissions.Find(id);
            if (userpermission == null)
            {
                return HttpNotFound();
            }
            return View(userpermission);
        }

        // GET: /UserPermission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserPermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserPermissionId")] UserPermission userpermission)
        {
            if (ModelState.IsValid)
            {
                db.UserPermissions.Add(userpermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userpermission);
        }

        // GET: /UserPermission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPermission userpermission = db.UserPermissions.Find(id);
            if (userpermission == null)
            {
                return HttpNotFound();
            }
            return View(userpermission);
        }

        // POST: /UserPermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="UserPermissionId")] UserPermission userpermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userpermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userpermission);
        }

        // GET: /UserPermission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPermission userpermission = db.UserPermissions.Find(id);
            if (userpermission == null)
            {
                return HttpNotFound();
            }
            return View(userpermission);
        }

        // POST: /UserPermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserPermission userpermission = db.UserPermissions.Find(id);
            db.UserPermissions.Remove(userpermission);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
