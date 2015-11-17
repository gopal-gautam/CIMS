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
    public class ExamRankController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        // GET: /ExamRank/
        public ActionResult Index()
        {
            return View(db.ExamRanks.ToList());
        }

        // GET: /ExamRank/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamRank examrank = db.ExamRanks.Find(id);
            if (examrank == null)
            {
                return HttpNotFound();
            }
            return View(examrank);
        }

        // GET: /ExamRank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ExamRank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ExamRankId,Percentage,TotalMarks,Rank,SGPA")] ExamRank examrank)
        {
            if (ModelState.IsValid)
            {
                db.ExamRanks.Add(examrank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examrank);
        }

        // GET: /ExamRank/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamRank examrank = db.ExamRanks.Find(id);
            if (examrank == null)
            {
                return HttpNotFound();
            }
            return View(examrank);
        }

        // POST: /ExamRank/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ExamRankId,Percentage,TotalMarks,Rank,SGPA")] ExamRank examrank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examrank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examrank);
        }

        // GET: /ExamRank/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamRank examrank = db.ExamRanks.Find(id);
            if (examrank == null)
            {
                return HttpNotFound();
            }
            return View(examrank);
        }

        // POST: /ExamRank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamRank examrank = db.ExamRanks.Find(id);
            db.ExamRanks.Remove(examrank);
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
