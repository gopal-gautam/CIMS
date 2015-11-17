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
    public class GroupResourceController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        // GET: /GroupResource/
        public ActionResult Index()
        {
            return View(db.GroupResources.ToList());
        }

        // GET: /GroupResource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupResource groupresource = db.GroupResources.Find(id);
            if (groupresource == null)
            {
                return HttpNotFound();
            }
            return View(groupresource);
        }

        // GET: /GroupResource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GroupResource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GroupResourceId,GrpResId")] GroupResource groupresource)
        {
            if (ModelState.IsValid)
            {
                db.GroupResources.Add(groupresource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupresource);
        }

        // GET: /GroupResource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupResource groupresource = db.GroupResources.Find(id);
            if (groupresource == null)
            {
                return HttpNotFound();
            }
            return View(groupresource);
        }

        // POST: /GroupResource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GroupResourceId,GrpResId")] GroupResource groupresource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupresource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupresource);
        }

        // GET: /GroupResource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupResource groupresource = db.GroupResources.Find(id);
            if (groupresource == null)
            {
                return HttpNotFound();
            }
            return View(groupresource);
        }

        // POST: /GroupResource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupResource groupresource = db.GroupResources.Find(id);
            db.GroupResources.Remove(groupresource);
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
