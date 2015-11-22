using CMISProject.DAL;
using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMISProject.Filters
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class Permit : ActionFilterAttribute
    {
        public string Permission { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(! filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Account", Action = "Login" }));
                return;
            }
            var currentUser = HttpContext.Current.User.Identity.Name;
            CIMSEntities db = new CIMSEntities();
            User user = db.Users.Single(s => s.UserName == currentUser);
            Permission permission = db.Permissions.Single(s => s.Perm == Permission);
            if (permission == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Index" }));
                return;
            }
            var userPermissions = db.UserPermissions.Where(s=>s.UserId == user.UserId & s.Permission == permission).ToList();
            var userGroupRelations = db.GroupUserRelations.Where(s => s.UserId == user.UserId);
            List<GroupPermission> groupPermissions = new List<GroupPermission>(); ;
            foreach( var userGroupRelation in userGroupRelations)
            {
                var group = db.Groups.Find(userGroupRelation.GroupId);
                groupPermissions.AddRange(db.GroupPermissions.Where(s => s.GroupId == group.GroupId).ToList());
            }
            if(userPermissions.Count() == 0 || groupPermissions.Count() == 0 || db.Admins.Single( s=> s.AdminName == currentUser) != null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Index" }));
                return;
            }
            base.OnActionExecuted(filterContext);
        }
    }
}