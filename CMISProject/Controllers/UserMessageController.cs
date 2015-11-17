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
    public class UserMessageController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        // GET: /UserMessage/
        public ActionResult Index()
        {
            return View(db.UserMessages.ToList());
        }

        // GET: /UserMessage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMessage usermessage = db.UserMessages.Find(id);
            if (usermessage == null)
            {
                return HttpNotFound();
            }
            return View(usermessage);
        }

        // GET: /UserMessage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserMessage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserMessageId")] UserMessage usermessage)
        {
            if (ModelState.IsValid)
            {
                db.UserMessages.Add(usermessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usermessage);
        }

        // GET: /UserMessage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMessage usermessage = db.UserMessages.Find(id);
            if (usermessage == null)
            {
                return HttpNotFound();
            }
            return View(usermessage);
        }

        // POST: /UserMessage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="UserMessageId")] UserMessage usermessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usermessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usermessage);
        }

        // GET: /UserMessage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMessage usermessage = db.UserMessages.Find(id);
            if (usermessage == null)
            {
                return HttpNotFound();
            }
            return View(usermessage);
        }

        // POST: /UserMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMessage usermessage = db.UserMessages.Find(id);
            db.UserMessages.Remove(usermessage);
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
