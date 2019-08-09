using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MittSystem.Models;

namespace MittSystem.Controllers
{
    public class AdminsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        RoleManager<IdentityRole> rolesManager;
        UserManager<ApplicationUser> usersManager;
        // GET: Admins
        public AdminsController()
        {
            rolesManager = new RoleManager<IdentityRole>
          (new RoleStore<IdentityRole>(db));
            usersManager = new UserManager<ApplicationUser>
          (new UserStore<ApplicationUser>(db));
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AssignRoles()
        {
            ViewBag.userId = new SelectList(db.Users.ToList(), "Id", "UserName");
            ViewBag.role = new SelectList(db.Roles.ToList(), "Name", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult AssignRoles(string userId, string role)
        {
            usersManager.AddToRole(userId.ToString(), role);
            return RedirectToAction("Index");
        }
        public ActionResult DisplayAllAdmins()
        {
            UserManagment manager = new UserManagment(db);
            var allAdmins = manager.UsersInRole("Admin");
            return View(allAdmins);
        }

    }
}