using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EFstore.Models;
using System.Web.Mvc;

namespace EFstore.Filters
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        private AccDbContext db = new AccDbContext();
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //if (!httpContext.User.Identity.IsAuthenticated)
            //    return false;
            //var userRole = db.Users.Include(t => t.UserRole).Where(u => u.Username == httpContext.User.Identity.Name).FirstOrDefault().UserRole;
            //if (userRole == null) return false;
            //return Roles.Split(',').Any(s => s == userRole.Rolename);
            //return userRole.RoleName == "Admin";
            // return base.AuthorizeCore(httpContext);

            if (!httpContext.User.Identity.IsAuthenticated)
                return false;
            var userRole = db.Users.Where(u => u.Username == httpContext.User.Identity.Name).FirstOrDefault().UserRole;
            if (userRole == null) 
                return false;
            return userRole == "Admin";
        }
    }
}