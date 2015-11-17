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
    public class CustomUserPropertyController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        // GET: /CustomUserProperty/
        public ActionResult Index()
        {
            return View(db.CustomUserProperties.ToList());
        }

        // GET: /CustomUserProperty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomUserProperty customuserproperty = db.CustomUserProperties.Find(id);
            if (customuserproperty == null)
            {
                return HttpNotFound();
            }
            return View(customuserproperty);
        }

        // GET: /CustomUserProperty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CustomUserProperty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CustomUserPropertyId,Property,Value")] CustomUserProperty customuserproperty)
        {
            if (ModelState.IsValid)
            {
                db.CustomUserProperties.Add(customuserproperty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customuserproperty);
        }

        // GET: /CustomUserProperty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomUserProperty customuserproperty = db.CustomUserProperties.Find(id);
            if (customuserproperty == null)
            {
                return HttpNotFound();
            }
            return View(customuserproperty);
        }

        // POST: /CustomUserProperty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CustomUserPropertyId,Property,Value")] CustomUserProperty customuserproperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customuserproperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customuserproperty);
        }

        // GET: /CustomUserProperty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomUserProperty customuserproperty = db.CustomUserProperties.Find(id);
            if (customuserproperty == null)
            {
                return HttpNotFound();
            }
            return View(customuserproperty);
        }

        // POST: /CustomUserProperty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomUserProperty customuserproperty = db.CustomUserProperties.Find(id);
            db.CustomUserProperties.Remove(customuserproperty);
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
