using sb_admin_2.Web1.Domain;
using sb_admin_2.Web1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMISProject.Models;

namespace sb_admin_2.Web1.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Navbar
        public ActionResult Index()
        {
            var data = new Data();
            var navBarItems = data.navbarItems().ToList();
            int totalNavItem = data.navbarItems().Count();
            if(User.Identity.IsAuthenticated)
            {
                var db = new CMISProject.DAL.CIMSEntities();
                if ((bool)Session["isAdmin"])
                {
                    foreach (var group in db.Groups)
                    {
                        navBarItems.Add(new Navbar { Id = totalNavItem + 1, nameOption = group.GroupName, status = true, isParent = false, parentId = 19 });
                        totalNavItem++;
                    }
                    foreach (var user in db.Users)
                    {
                        navBarItems.Add(new Navbar { Id = totalNavItem + 1, nameOption = user.UserName, status = true, isParent = false, parentId = 23 });
                        totalNavItem++;
                    }
                }
                else
                {

                    int curUserId = (int)HttpContext.Session["UserId"];

                    var groupsUsers = db.Users.Join(db.GroupUserRelations.Where(s => s.UserId == curUserId), o => o.UserId, i => i.UserId, (c, o) => new { c, o });
                    foreach (var groupUser in groupsUsers)
                    {
                        Group group = groupUser.o.Group;
                        navBarItems.Add(new Navbar { Id = totalNavItem + 1, nameOption = group.GroupName, status = true, isParent = false, parentId = 19 });
                        totalNavItem++;
                    }
                }

            }
            return PartialView("_Navbar", navBarItems);
        }
    }
}