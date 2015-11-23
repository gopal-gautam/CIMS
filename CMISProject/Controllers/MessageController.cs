using CMISProject.DAL;
using CMISProject.Models;
using CMISProject.ViewModels.MessageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CMISProject.Controllers
{
    public class MessageController : Controller
    {
        //
        private CIMSEntities db = new CIMSEntities();

        // GET: /Message/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Message/Details/5
        public ActionResult Details(int? id)
        {
            List<MessageViewModel> ViewModels = new List<MessageViewModel>();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if(message == null)
            {
                return HttpNotFound();
            }

            return View(message);
        }

        //
        // GET: /Message/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Message/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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
        // GET: /Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Message/Edit/5
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
        // GET: /Message/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Message/Delete/5
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
