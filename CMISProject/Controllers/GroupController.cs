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
    [Authorize]
    public class GroupController : Controller
    {
        private CIMSEntities db = new CIMSEntities();

        //
        // GET: /Group/
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult ListAllGroups()
        {
            List<GroupListViewModel> viewModels = new List<GroupListViewModel>();
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

        public ActionResult Index()
        {
            return View(db.GroupUserRelations.Where(s => s.User.UserName == HttpContext.User.Identity.Name).ToList());
        }

        public ActionResult ListMembers(int id)
        {
            Group group = db.Groups.Find(id);
            List<User> users = new List<User>();
            foreach (var groupUserRow in db.GroupUserRelations.Where(s => s.GroupId == group.GroupId).ToList())
            {
                users.Add(groupUserRow.User);
            }
            return View(users);
        }

        public ActionResult AddMember(int id, int userId)
        {
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            if (group.CreatedBy != User.Identity.Name)
            {
                return RedirectToAction("Index");
            }
            User user = db.Users.Find(userId);
            if (user == null)
            {
                return HttpNotFound();
            }
            GroupsUsers groupsUsers = new GroupsUsers()
            {
                GroupId = id,
                UserId = userId,
            };
            try
            {
                db.GroupUserRelations.Add(groupsUsers);
                db.SaveChanges();

                return RedirectToAction("ListMembers", new { id = id });
            }
            catch
            {
                return RedirectToAction("ListMembers", new { id = id });

            }

        }

        public ActionResult DeleteMember(int id, int userid)
        {
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound("The specified Group doen't exist");
            }


            User user = db.Users.Find(userid);
            if (user == null)
            {
                return HttpNotFound("Specified user doesn't exist");
            }

            if (group.CreatedBy != User.Identity.Name || db.Users.Find(userid).UserName != User.Identity.Name)
            {
                return RedirectToAction("Index");
            }

            foreach (var groupUser in db.GroupUserRelations.Where(s => s.GroupId == id & s.UserId == userid).ToList())
            {
                try
                {
                    db.GroupUserRelations.Remove(groupUser);
                }
                catch
                {
                }

            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public static bool CheckMemeber(int GroupId, int UserId)
        {
            bool isMember = false;
            CIMSEntities db = new CIMSEntities();
            Group group = db.Groups.Find(GroupId);
            if (group == null)
            {
                return isMember;
            }


            User user = db.Users.Find(UserId);
            if (user == null)
            {
                return isMember;
            }
            foreach (var groupUser in db.GroupUserRelations.Where(p => p.GroupId == GroupId).ToList())
            {
                if (groupUser.UserId == UserId)
                {
                    isMember = true;
                    break;
                }
            }
            return isMember;
        }

        /// <summary>
        /// This function is used to delete a group from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteGroup(int? id)
        {
            try
            {
                if (id == null)
                {
                    return HttpNotFound();
                }
                foreach (var group in db.Groups.Where(s => s.GroupId == id).ToList())
                {
                    db.Groups.Remove(group);
                }
                foreach (var groupMessage in db.GroupMessages.Where(s => s.GroupId == id).ToList())
                {
                    db.GroupMessages.Remove(groupMessage);
                }
                foreach (var groupPermission in db.GroupPermissions.Where(s => s.GroupId == id).ToList())
                {
                    db.GroupPermissions.Remove(groupPermission);
                }
                foreach (var groupResource in db.GroupResources.Where(s => s.GroupId == id).ToList())
                {
                    db.GroupResources.Remove(groupResource);
                }
                foreach (var routine in db.Routines.Where(s => s.GroupId == id).ToList())
                {
                    db.Routines.Remove(routine);
                }
                foreach (var subject in db.Subjects.Where(s => s.SubjectId == id).ToList())
                {
                    subject.Group = null;
                    db.Entry(subject).State = EntityState.Modified;
                }
                foreach (var customGroupProperty in db.CustomGroupProperties.Where(s => s.GroupId == id).ToList())
                {
                    customGroupProperty.Group = null;
                    db.Entry(customGroupProperty).State = EntityState.Modified;
                }
                foreach (var groupsUsers in db.GroupUserRelations.Where(s => s.GroupId == id).ToList())
                {
                    db.GroupUserRelations.Remove(groupsUsers);
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        //
        // GET: /Group/Details/5
        public ActionResult Details(int? id)
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
        //[Authorize(Roles = "SuperAdmin")]
        public ActionResult Create()
        {
            return View(new GroupViewModel());
        }

        //
        // POST: /Group/Create
        //[Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    ApplicationUser user = new ApplicationUser() { UserName = group.GroupName, };
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
        //[Authorize(Roles = "SuperAdmin")]
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
        //[Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GroupViewModel groupViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Group group = new Group()
                    {
                        GroupId = id,
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
        //[Authorize(Roles = "SuperAdmin")]
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

        [HttpPost]
        public JsonResult doesGroupNameExist(string groupName)
        {
            if (db.Groups.Single(s => s.GroupName == groupName) != null)
            {
                return Json(false);
            }
            return Json(true);
        }

        public ActionResult ChangeStatus(int id)
        {
            if (db.Groups.Find(id).CreatedBy != HttpContext.User.Identity.Name)
            {
                return RedirectToAction("Index");
            }
            if (db.Groups.Find(id) != null)
            {
                return View(new ChangeStatusViewModel());
            }
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult ChangeStatus(int id, ChangeStatusViewModel changeStatusViewModel)
        {
            if (db.Groups.Find(id).CreatedBy != HttpContext.User.Identity.Name)
            {
                return RedirectToAction("Index");
            }
            if (db.Groups.Find(id) != null)
            {
                Group group = new Group()
                {
                    GroupId = id,
                    Status = changeStatusViewModel.Status,
                };
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return new HttpNotFoundResult();
        }
    }

}