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
    public class CustomGroupPropertyController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        // GET: /CustomGroupProperty/
        public ActionResult Index()
        {
            return View(db.CustomGroupProperties.ToList());
        }

        // GET: /CustomGroupProperty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomGroupProperty customgroupproperty = db.CustomGroupProperties.Find(id);
            if (customgroupproperty == null)
            {
                return HttpNotFound();
            }
            return View(customgroupproperty);
        }

        // GET: /CustomGroupProperty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CustomGroupProperty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CustomGroupPropertyId,Property,Value")] CustomGroupProperty customgroupproperty)
        {
            if (ModelState.IsValid)
            {
                db.CustomGroupProperties.Add(customgroupproperty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customgroupproperty);
        }

        // GET: /CustomGroupProperty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomGroupProperty customgroupproperty = db.CustomGroupProperties.Find(id);
            if (customgroupproperty == null)
            {
                return HttpNotFound();
            }
            return View(customgroupproperty);
        }

        // POST: /CustomGroupProperty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CustomGroupPropertyId,Property,Value")] CustomGroupProperty customgroupproperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customgroupproperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customgroupproperty);
        }

        // GET: /CustomGroupProperty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomGroupProperty customgroupproperty = db.CustomGroupProperties.Find(id);
            if (customgroupproperty == null)
            {
                return HttpNotFound();
            }
            return View(customgroupproperty);
        }

        // POST: /CustomGroupProperty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomGroupProperty customgroupproperty = db.CustomGroupProperties.Find(id);
            db.CustomGroupProperties.Remove(customgroupproperty);
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
