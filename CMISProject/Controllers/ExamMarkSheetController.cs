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
    public class ExamMarkSheetController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        // GET: /ExamMarkSheet/
        public ActionResult Index()
        {
            return View(db.ExamMarkSheets.ToList());
        }

        // GET: /ExamMarkSheet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamMarkSheet exammarksheet = db.ExamMarkSheets.Find(id);
            if (exammarksheet == null)
            {
                return HttpNotFound();
            }
            return View(exammarksheet);
        }

        // GET: /ExamMarkSheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ExamMarkSheet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ExamMarkSheetId,Marks,ExamType,FullMarks,PassMarks,ExamDate,SubjectRank,Semester,SGPA")] ExamMarkSheet exammarksheet)
        {
            if (ModelState.IsValid)
            {
                db.ExamMarkSheets.Add(exammarksheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exammarksheet);
        }

        // GET: /ExamMarkSheet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamMarkSheet exammarksheet = db.ExamMarkSheets.Find(id);
            if (exammarksheet == null)
            {
                return HttpNotFound();
            }
            return View(exammarksheet);
        }

        // POST: /ExamMarkSheet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ExamMarkSheetId,Marks,ExamType,FullMarks,PassMarks,ExamDate,SubjectRank,Semester,SGPA")] ExamMarkSheet exammarksheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exammarksheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exammarksheet);
        }

        // GET: /ExamMarkSheet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamMarkSheet exammarksheet = db.ExamMarkSheets.Find(id);
            if (exammarksheet == null)
            {
                return HttpNotFound();
            }
            return View(exammarksheet);
        }

        // POST: /ExamMarkSheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamMarkSheet exammarksheet = db.ExamMarkSheets.Find(id);
            db.ExamMarkSheets.Remove(exammarksheet);
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
