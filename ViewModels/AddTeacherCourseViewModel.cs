using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.ViewModels
{
    public class AddTeacherCourseViewModel
    {
        public Teacher Teacher { get; set; }
        public List<SelectListItem> Courses { get; set; }

        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public AddTeacherCourseViewModel()
        {

        }

        public AddTeacherCourseViewModel(Teacher teacher, IEnumerable<Course> courses)
        {
            Courses = new List<SelectListItem>();

            foreach (var item in courses)
            {
                Courses.Add(new SelectListItem
                {
                    Value = item.CourseId.ToString(),
                    Text = item.Name
                });
            }
        }
    }
}
