using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.ViewModels
{
    public class AddStudentCourseViewModel
    {
        public Student Student { get; set; }
        public List<SelectListItem> Courses { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public AddStudentCourseViewModel()
        {

        }

        public AddStudentCourseViewModel(Student student, IEnumerable<Course> courses)
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
