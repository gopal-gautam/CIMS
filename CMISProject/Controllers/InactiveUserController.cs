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
    public class InactiveUserController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        // GET: /InactiveUser/
        public ActionResult Index()
        {
            return View(db.InactiveUsers.ToList());
        }

        // GET: /InactiveUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InactiveUser inactiveuser = db.InactiveUsers.Find(id);
            if (inactiveuser == null)
            {
                return HttpNotFound();
            }
            return View(inactiveuser);
        }

        // GET: /InactiveUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /InactiveUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="InactiveUserId,InactiveDate,Reason")] InactiveUser inactiveuser)
        {
            if (ModelState.IsValid)
            {
                db.InactiveUsers.Add(inactiveuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inactiveuser);
        }

        // GET: /InactiveUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InactiveUser inactiveuser = db.InactiveUsers.Find(id);
            if (inactiveuser == null)
            {
                return HttpNotFound();
            }
            return View(inactiveuser);
        }

        // POST: /InactiveUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="InactiveUserId,InactiveDate,Reason")] InactiveUser inactiveuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inactiveuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inactiveuser);
        }

        // GET: /InactiveUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InactiveUser inactiveuser = db.InactiveUsers.Find(id);
            if (inactiveuser == null)
            {
                return HttpNotFound();
            }
            return View(inactiveuser);
        }

        // POST: /InactiveUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InactiveUser inactiveuser = db.InactiveUsers.Find(id);
            db.InactiveUsers.Remove(inactiveuser);
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
