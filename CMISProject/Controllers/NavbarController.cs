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
            if(User.Identity.IsAuthenticated)
            {
                int curUserId = (int) HttpContext.Session["UserId"];
                var db = new CMISProject.DAL.CIMSEntities();
                int totalNavItem = data.navbarItems().Count();
                var groupsUsers = db.Users.Join(db.GroupUserRelations.Where(s => s.UserId == curUserId), o => o.UserId, i => i.UserId, (c, o) => new { c, o });
                foreach( var groupUser in groupsUsers)
                {
                    Group group = groupUser.o.Group;
                    navBarItems.Add(new Navbar { Id = totalNavItem+1, nameOption = group.GroupName, controller = "Group", action = "Create", status = true, isParent = false, parentId = 19 });

                }

            }
            return PartialView("_Navbar", navBarItems);
        }
    }
}