using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMISProject.DAL;
using CMISProject.ViewModels;
using System.Net;
using CMISProject.Models;
using System.Data.Entity;

namespace CMISProject.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private CIMSEntities db = new CIMSEntities();
        private List<AdminViewModel> viewModels = new List<AdminViewModel>();

        public ActionResult Index()
        {
            foreach (var admin in db.Admins)
            {
                var viewModel = new AdminViewModel()
                {
                    AdminName = admin.AdminName,
                    Address = admin.Address,
                    //do as for other properties of AdminViewModel

                };
                viewModels.Add(viewModel);
            }
            return View(viewModels);
        }

        //
        // GET: /Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // GET: /Admin/Create
        public ActionResult Create()
        {
            return View(new AdminViewModel());
        }

        //
        // POST: /Admin/Create
        [HttpPost]
        public ActionResult Create(AdminViewModel adminViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Admin admin = new Admin()
                    {
                        AdminName = adminViewModel.AdminName,
                        Address = adminViewModel.Address,
                        // Do same for other properties
                    };
                    db.Admins.Add(admin);
                    db.SaveChanges();

                    IdentityManager im = new IdentityManager();
                    ApplicationUser user = new ApplicationUser() { UserName=admin.AdminName, };
                    im.CreateUser(user, admin.Password);
                    return RedirectToAction("Index");
                }

                return View(adminViewModel);

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            AdminViewModel adminViewModel = new AdminViewModel()
            {
                Address = admin.Address,
                AdminName = admin.AdminName,
                //Do same for other
            };
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(adminViewModel);
        }

        //
        // POST: /Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AdminViewModel adminViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Admin admin = new Admin()
                    {
                        AdminName = adminViewModel.AdminName,
                        Address = adminViewModel.Address,
                        // Do same for other properties
                    };
                    db.Entry(admin).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(adminViewModel);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            var adminViewModel = new AdminViewModel()
            {
                AdminName = admin.AdminName,
                Address = admin.Address,
                //do as for other properties of AdminViewModel

            };
            
            return View(adminViewModel);
        }

        //
        // POST: /Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Admin admin = db.Admins.Find(id);
                db.Admins.Remove(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
