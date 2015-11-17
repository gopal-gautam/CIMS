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
    public class UserResourceController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        // GET: /UserResource/
        public ActionResult Index()
        {
            return View(db.UserResources.ToList());
        }

        // GET: /UserResource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserResource userresource = db.UserResources.Find(id);
            if (userresource == null)
            {
                return HttpNotFound();
            }
            return View(userresource);
        }

        // GET: /UserResource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserResource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserResourceId")] UserResource userresource)
        {
            if (ModelState.IsValid)
            {
                db.UserResources.Add(userresource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userresource);
        }

        // GET: /UserResource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserResource userresource = db.UserResources.Find(id);
            if (userresource == null)
            {
                return HttpNotFound();
            }
            return View(userresource);
        }

        // POST: /UserResource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="UserResourceId")] UserResource userresource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userresource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userresource);
        }

        // GET: /UserResource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserResource userresource = db.UserResources.Find(id);
            if (userresource == null)
            {
                return HttpNotFound();
            }
            return View(userresource);
        }

        // POST: /UserResource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserResource userresource = db.UserResources.Find(id);
            db.UserResources.Remove(userresource);
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
