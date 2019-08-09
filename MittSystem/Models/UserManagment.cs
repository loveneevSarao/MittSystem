using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MittSystem.Models
{
    public class UserManagment
    {
        ApplicationDbContext db = new ApplicationDbContext();//will take an instance of the batabase

        public ICollection<ApplicationUser> Teachers()
        {
            var allTeachers = db.Users.Where(t => t.Type == PersonType.Teacher).ToList();
            return allTeachers;
        }
        public ICollection<ApplicationUser> Students()
        {
            var allStudents = db.Users.Where(t => t.Type == PersonType.Student).ToList();
            return allStudents;
        }
        public ICollection<ApplicationUser> Admins()
        {
            var allAdmins = db.Users.Where(t => t.Type == PersonType.Admin).ToList();
            return allAdmins;
        }

        //


        UserManager<ApplicationUser> usersManager;
        public UserManagment(ApplicationDbContext db)
        {
            this.db = db;
            usersManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ;
        }
        public bool IsUserInRole(string userId, string RoleName)
        {
            return usersManager.IsInRole(userId, RoleName);
        }
        public bool AddUserToRole(string userId, string roleName)
        {
            var result = usersManager.AddToRole(userId, roleName);
            return result.Succeeded;
        }
        public bool RemoveUserFromRole(string userId, string roleName)
        {
            var result = usersManager.RemoveFromRole(userId, roleName);
            return result.Succeeded;
        }
        public bool RemoveUser(string userId, string roleName)
        {
            var result = usersManager.AddToRole(userId, roleName);
            return result.Succeeded;
        }
        public ICollection<ApplicationUser> UsersInRole(string roleName)
        {
            var result = new List<ApplicationUser>();
            var allUsers = db.Users.ToList();
            foreach (var user in allUsers)
            {
                if (IsUserInRole(user.Id, roleName))
                {
                    result.Add(user);
                }
            }
            //Another method with LINQ
            //return db.Users.Where(u => IsUserInRole(u.Id, roleName)).ToList();
            return result;
        }
    }
}