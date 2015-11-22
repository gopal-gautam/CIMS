using CMISProject.DAL;
using CMISProject.Models;
using CMISProject.ViewModels;
using CMISProject.ViewModels.GroupViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CMISProject.Controllers
{
    
    public class GroupController : Controller
    {
        private CIMSEntities db = new CIMSEntities();
        private List<GroupListViewModel> viewModels = new List<GroupListViewModel>();
        //
        // GET: /Group/
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Index()
        {
            foreach (var group in db.Groups)
            {
                var viewModel = new GroupListViewModel()
                {
                    GroupName = group.GroupName,
                    //Password = group.Password,
                    //CreatedBy = group.CreatedBy,
                    //CreatedDate = group.CreatedDate,
                    Status = group.Status,
                    //ModifiedBy = group.ModifiedBy,
                    //ModifiedDate = group.ModifiedDate,
                    
                };
                viewModels.Add(viewModel);
            }
            return View(viewModels);
        }

        //
        // GET: /Group/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        //
        // GET: /Group/Create
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Create()
        {
            return View(new GroupViewModel());
        }

        //
        // POST: /Group/Create
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public ActionResult Create(GroupViewModel groupViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Group group = new Group()
                    {
                        GroupName = groupViewModel.GroupName,
                        Password = groupViewModel.Password,
                        //CreatedBy = groupViewModel.CreatedBy,
                        //CreatedDate = groupViewModel.CreatedDate,
                        Status = groupViewModel.Status,
                        //ModifiedBy = groupViewModel.ModifiedBy,
                        //ModifiedDate = groupViewModel.ModifiedDate,

                    };
                    db.Groups.Add(group);
                    db.SaveChanges();

                    IdentityManager im = new IdentityManager();
                    ApplicationUser user = new ApplicationUser() { UserName=group.GroupName, };
                    im.CreateUser(user, group.Password);
                return RedirectToAction("Index");
            }
                return View(groupViewModel);

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Group/Edit/5
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            GroupViewModel groupViewModel = new GroupViewModel()
            {
                GroupName = group.GroupName,
                Password = group.Password,
                //CreatedBy = group.CreatedBy,
                //CreatedDate = group.CreatedDate,
                Status = group.Status,
                //ModifiedBy = group.ModifiedBy,
                //ModifiedDate = group.ModifiedDate,
            };
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(groupViewModel);
        }

        //
        // POST: /Group/Edit/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public ActionResult Edit(int id, GroupViewModel groupViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Group group = new Group()
                    {
                        GroupName = groupViewModel.GroupName,
                        Password = groupViewModel.Password,
                        //CreatedBy = groupViewModel.CreatedBy,
                        //CreatedDate = groupViewModel.CreatedDate,
                        Status = groupViewModel.Status,
                        //ModifiedBy = groupViewModel.ModifiedBy,
                        //ModifiedDate = groupViewModel.ModifiedDate,
                    };
                    db.Entry(group).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(groupViewModel);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Group/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            var groupViewModel = new GroupListViewModel()
            {
                GroupName = group.GroupName,
                //Password = group.Password,
                //CreatedBy = group.CreatedBy,
                //CreatedDate = group.CreatedDate,
                Status = group.Status,
                //ModifiedBy = group.ModifiedBy,
                //ModifiedDate = group.ModifiedDate,
            };

            return View(groupViewModel);
        }

        //
        // POST: /Group/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Group group = db.Groups.Find(id);
                db.Groups.Remove(group);
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
