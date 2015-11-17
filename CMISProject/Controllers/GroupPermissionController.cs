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
    public class GroupPermissionController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        // GET: /GroupPermission/
        public ActionResult Index()
        {
            return View(db.GroupPermissions.ToList());
        }

        // GET: /GroupPermission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPermission grouppermission = db.GroupPermissions.Find(id);
            if (grouppermission == null)
            {
                return HttpNotFound();
            }
            return View(grouppermission);
        }

        // GET: /GroupPermission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GroupPermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GroupPermissionId")] GroupPermission grouppermission)
        {
            if (ModelState.IsValid)
            {
                db.GroupPermissions.Add(grouppermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grouppermission);
        }

        // GET: /GroupPermission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPermission grouppermission = db.GroupPermissions.Find(id);
            if (grouppermission == null)
            {
                return HttpNotFound();
            }
            return View(grouppermission);
        }

        // POST: /GroupPermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GroupPermissionId")] GroupPermission grouppermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grouppermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grouppermission);
        }

        // GET: /GroupPermission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPermission grouppermission = db.GroupPermissions.Find(id);
            if (grouppermission == null)
            {
                return HttpNotFound();
            }
            return View(grouppermission);
        }

        // POST: /GroupPermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupPermission grouppermission = db.GroupPermissions.Find(id);
            db.GroupPermissions.Remove(grouppermission);
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
