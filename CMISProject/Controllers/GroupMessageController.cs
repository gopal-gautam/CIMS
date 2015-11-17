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
    public class GroupMessageController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        // GET: /GroupMessage/
        public ActionResult Index()
        {
            return View(db.GroupMessages.ToList());
        }

        // GET: /GroupMessage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMessage groupmessage = db.GroupMessages.Find(id);
            if (groupmessage == null)
            {
                return HttpNotFound();
            }
            return View(groupmessage);
        }

        // GET: /GroupMessage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GroupMessage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GroupMessageId")] GroupMessage groupmessage)
        {
            if (ModelState.IsValid)
            {
                db.GroupMessages.Add(groupmessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupmessage);
        }

        // GET: /GroupMessage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMessage groupmessage = db.GroupMessages.Find(id);
            if (groupmessage == null)
            {
                return HttpNotFound();
            }
            return View(groupmessage);
        }

        // POST: /GroupMessage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GroupMessageId")] GroupMessage groupmessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupmessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupmessage);
        }

        // GET: /GroupMessage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMessage groupmessage = db.GroupMessages.Find(id);
            if (groupmessage == null)
            {
                return HttpNotFound();
            }
            return View(groupmessage);
        }

        // POST: /GroupMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupMessage groupmessage = db.GroupMessages.Find(id);
            db.GroupMessages.Remove(groupmessage);
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
