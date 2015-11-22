using CMISProject.DAL;
using CMISProject.Models;
using CMISProject.ViewModels.AdminViewModels;
using CMISProject.ViewModels.SubjectViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CMISProject.Controllers
{
    public class SubjectController : Controller
    {
        //
        private CIMSEntities db = new CIMSEntities();
        private List<SubjectListViewModel> viewModels = new List<SubjectListViewModel>();

        // GET: /Subject/
        public ActionResult Index()
        {
            foreach (var subject in db.Subjects)
            {
                var viewModel = new SubjectListViewModel()
                {
                    CreditHours = subject.CreditHours,
                    SubjectName = subject.SubjectName,
                    SubjectTeacher = subject.SubjectTeacher,
                };
                viewModels.Add(viewModel);
            }
            return View();
        }

        //
        // GET: /Subject/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if(subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        //
        // GET: /Subject/Create
        public ActionResult Create()
        {

            return View(new SubjectViewModel);
        }

        //
        // POST: /Subject/Create
        [HttpPost]
        public ActionResult Create(SubjectViewModel subjectViewModel)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Subject/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Subject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Subject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Subject/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
