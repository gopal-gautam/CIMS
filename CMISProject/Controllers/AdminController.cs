using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMISProject.DAL;
using CMISProject.ViewModels.AdminViewModels;
using System.Net;
using CMISProject.Models;
using System.Data.Entity;

namespace CMISProject.Controllers
{
    
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private CIMSEntities db = new CIMSEntities();
        private List<AdminListViewModel> viewModels = new List<AdminListViewModel>();

        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Index()
        {
            foreach (var admin in db.Admins)
            {
                var viewModel = new AdminListViewModel()
                {
                    //AdminName = admin.AdminName,
                    Address = admin.Address,
                    //CreatedBy = admin.CreatedBy,
                    //CreatedDate = admin.CreatedDate,
                    //DateOfEstablishment = admin.DateOfEstablishment,
                    //Email = admin.Email,
                    //FaxNumber = admin.FaxNumber,
                    LogoFile = admin.LogoFile,
                    //ModifiedDate = admin.ModifiedDate,
                    //ModifiedBy = admin.ModifiedBy,
                    OrganizationName = admin.OrganizationName,
                    //PanNo = admin.PanNo,
                    //PhoneNumbers = admin.PhoneNumbers,
                    //POBoxNumber = admin.POBoxNumber,
                    //VatNo = admin.VatNo,
                    //Website = admin.Website,
                    
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
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Create()
        {
            return View(new AdminViewModel());
        }

        //
        // POST: /Admin/Create
        [Authorize(Roles = "SuperAdmin")]
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
                        //CreatedBy = adminViewModel.CreatedBy,
                        //CreatedDate = adminViewModel.CreatedDate,
                        DateOfEstablishment = adminViewModel.DateOfEstablishment,
                        Email = adminViewModel.Email,
                        FaxNumber = adminViewModel.FaxNumber,
                        LogoFile = adminViewModel.LogoFile.ToString(),
                        //ModifiedDate = adminViewModel.ModifiedDate,
                        //ModifiedBy = adminViewModel.ModifiedBy,
                        OrganizationName = adminViewModel.OrganizationName,
                        PanNo = adminViewModel.PanNo,
                        PhoneNumbers = adminViewModel.PhoneNumbers,
                        POBoxNumber = adminViewModel.POBoxNumber,
                        VatNo = adminViewModel.VatNo,
                        Website = adminViewModel.Website,

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
        [Authorize(Roles = "SuperAdmin")]
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
                //CreatedBy = admin.CreatedBy,
                //CreatedDate = admin.CreatedDate,
                DateOfEstablishment = admin.DateOfEstablishment,
                Email = admin.Email,
                FaxNumber = admin.FaxNumber,
                //LogoFile = admin.LogoFile,
                //ModifiedDate = admin.ModifiedDate,
                //ModifiedBy = admin.ModifiedBy,
                OrganizationName = admin.OrganizationName,
                PanNo = admin.PanNo,
                PhoneNumbers = admin.PhoneNumbers,
                POBoxNumber = admin.POBoxNumber,
                VatNo = admin.VatNo,
                Website = admin.Website,
            };
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(adminViewModel);
        }

        //
        // POST: /Admin/Edit/5
        [Authorize(Roles = "SuperAdmin")]
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
                        AdminId = id,
                        AdminName = adminViewModel.AdminName,
                        Address = adminViewModel.Address,
                        //CreatedBy = adminViewModel.CreatedBy,
                        //CreatedDate = adminViewModel.CreatedDate,
                        DateOfEstablishment = adminViewModel.DateOfEstablishment,
                        Email = adminViewModel.Email,
                        FaxNumber = adminViewModel.FaxNumber,
                        //LogoFile = adminViewModel.LogoFile,
                        //ModifiedDate = adminViewModel.ModifiedDate,
                        //ModifiedBy = adminViewModel.ModifiedBy,
                        OrganizationName = adminViewModel.OrganizationName,
                        PanNo = adminViewModel.PanNo,
                        PhoneNumbers = adminViewModel.PhoneNumbers,
                        POBoxNumber = adminViewModel.POBoxNumber,
                        VatNo = adminViewModel.VatNo,
                        Website = adminViewModel.Website,
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
        [Authorize(Roles = "SuperAdmin")]
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
                //AdminName = admin.AdminName,
                Address = admin.Address,
                //CreatedBy = admin.CreatedBy,
                //CreatedDate = admin.CreatedDate,
                //DateOfEstablishment = admin.DateOfEstablishment,
                //Email = admin.Email,
                //FaxNumber = admin.FaxNumber,
                //LogoFile = admin.LogoFile,
                //ModifiedDate = admin.ModifiedDate,
                //ModifiedBy = admin.ModifiedBy,
                OrganizationName = admin.OrganizationName,
                //PanNo = admin.PanNo,
                //PhoneNumber = admin.PhoneNumbers,
                //POBoxNumber = admin.POBoxNumber,
                //VatNo = admin.VatNo,
                Website = admin.Website,

            };
            
            return View(adminViewModel);
        }

        //
        // POST: /Admin/Delete/5
        [Authorize(Roles = "SuperAdmin")]
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