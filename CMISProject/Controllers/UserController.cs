using CMISProject.DAL;
using CMISProject.Models;
using CMISProject.ViewModels;
using CMISProject.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CMISProject.Controllers
{
    
    public class UserController : Controller
    {
        //
        // GET: /User/
        private CIMSEntities db = new CIMSEntities();
        private List<UserListViewModel> viewModels = new List<UserListViewModel>();

        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Index()
        {
            foreach (var user in db.Users)
            {
                var viewModel = new UserListViewModel()
                {
                    Address = user.Address,
                    //BloodGroup = user.BloodGroup,
                    //CitizenShipNumber = user.CitizenShipNumber,
                    //CreatedBy = user.CreatedBy,
                    //CreatedDate = user.CreatedDate,
                    //DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    ImageFile = user.ImageFile,
                    //ModifiedBy = user.ModifiedBy,
                    //ModifiedDate = user.ModifiedDate,
                    //Nationality = user.Nationality,
                    //Password = user.Password,
                    //PhoneNumber = user.PhoneNumber,
                    //Religion = user.Religion,
                    //Sex = user.Sex,
                    //UserName = user.UserName,
                    Name = user.FirstName + " " +user.MiddleName + " " +user.LastName,
                    
                };
                viewModels.Add(viewModel);
            }
            return View();
        }

        //
        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User/Create
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Create()
        {
            return View(new UserViewModel());
        }

        //
        // POST: /User/Create
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    User user = new User()
                    {
                        Address = userViewModel.Address,
                        BloodGroup = userViewModel.BloodGroup,
                        CitizenShipNumber = userViewModel.CitizenShipNumber,
                        //CreatedBy = userViewModel.CreatedBy,
                        //CreatedDate = userViewModel.CreatedDate,
                        DateOfBirth = userViewModel.DateOfBirth,
                        Email = userViewModel.Email,
                        ImageFile = userViewModel.ImageFile.ToString(),
                        //ModifiedBy = userViewModel.ModifiedBy,
                        //ModifiedDate = userViewModel.ModifiedDate,
                        Nationality = userViewModel.Nationality,
                        Password = userViewModel.Password,
                        PhoneNumber = userViewModel.PhoneNumber,
                        Religion = userViewModel.Religion,
                        Sex = userViewModel.Sex,
                        UserName = userViewModel.UserName,
                        FirstName = userViewModel.FirstName,
                        MiddleName = userViewModel.MiddleName,
                        LastName = userViewModel.LastName,
                    };
                    db.Users.Add(user);
                    db.SaveChanges();

                    IdentityManager im = new IdentityManager();
                    ApplicationUser userForLogin = new ApplicationUser() { UserName = user.UserName, };
                    im.CreateUser(userForLogin, user.Password);
               
                    return RedirectToAction("Index");
            }
                return View(userViewModel);
        }
            
        catch
            {
                return View();
            }

        }

        //
        // GET: /User/Edit/5
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            UserViewModel userViewModel = new UserViewModel()
            {
                Address = user.Address,
                //BloodGroup = user.BloodGroup,
                CitizenShipNumber = user.CitizenShipNumber,
                //CreatedBy = user.CreatedBy,
                //CreatedDate = user.CreatedDate,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                //ImageFile = user.ImageFile,
                //ModifiedBy = user.ModifiedBy,
                //ModifiedDate = user.ModifiedDate,
                Nationality = user.Nationality,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Religion = user.Religion,
                //Sex = user.Sex,
                UserName = user.UserName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
            };
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserViewModel userViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    User user = new User()
                    {
                        UserId = id,
                        Address = userViewModel.Address,
                        //BloodGroup = userViewModel.BloodGroup,
                        CitizenShipNumber = userViewModel.CitizenShipNumber,
                        //CreatedBy = userViewModel.CreatedBy,
                        //CreatedDate = userViewModel.CreatedDate,
                        DateOfBirth = userViewModel.DateOfBirth,
                        Email = userViewModel.Email,
                        ImageFile = userViewModel.ImageFile.ToString(),
                        //ModifiedBy = userViewModel.ModifiedBy,
                        //ModifiedDate = userViewModel.ModifiedDate,
                        Nationality = userViewModel.Nationality,
                        Password = userViewModel.Password,
                        PhoneNumber = userViewModel.PhoneNumber,
                        Religion = userViewModel.Religion,
                        //Sex = userViewModel.Sex,
                        UserName = userViewModel.UserName,
                        FirstName = userViewModel.FirstName,
                        MiddleName = userViewModel.MiddleName,
                        LastName = userViewModel.LastName,
                    };
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(userViewModel);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5
        [Authorize(Roles="SuperAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var userViewModel = new UserListViewModel()
            {
                Address = user.Address,
                Name = user.FirstName + " " + user.MiddleName + " " + user.LastName,
                //BloodGroup = user.BloodGroup,
                //CitizenShipNumber = user.CitizenShipNumber,
                //CreatedBy = user.CreatedBy,
                //CreatedDate = user.CreatedDate,
                //DateOfBirth = user.DateOfBirth,
                //Email = user.Email,
                //ImageFile = user.ImageFile,
                //ModifiedBy = user.ModifiedBy,
                //ModifiedDate = user.ModifiedDate,
                //Nationality = user.Nationality,
                //Password = user.Password,
                //PhoneNumber = user.PhoneNumber,
                //Religion = user.Religion,
                //Sex = user.Sex,
                //UserName = user.UserName,
                //FirstName = user.FirstName,
                //MiddleName = user.MiddleName,
                //LastName = user.LastName,
            };
            return View(userViewModel);
        }

        //
        // POST: /User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public JsonResult doesUserNameExist(string UserName)
        {

            var user = Membership.GetUser(UserName);

            return Json(user == null);
        }

    }
}