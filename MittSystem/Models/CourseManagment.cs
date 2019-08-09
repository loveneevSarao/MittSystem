using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MittSystem.Models
{
    public class CourseManagment
    {
        ApplicationDbContext db;
        public CourseManagment(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Course CheckCourseId(int courseId)
        {
            var project = db.Courses.Find(courseId);
            if (project != null)
            {
                return project;
            }
            return null;
        }
        public Course CheckUserId(int userId)
        {
            var user = db.Courses.Find(userId);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public bool AssignUserToCourse(string userId, int courseId)
        {
            var user = db.Users.Find(userId);
            var course = db.Courses.Find(courseId);
            ApplicationUserCourses ap = new ApplicationUserCourses();
            ap.Course = course;   
            user.Courses.Add(ap);
            db.SaveChanges();
            return true;
        }

    }

}