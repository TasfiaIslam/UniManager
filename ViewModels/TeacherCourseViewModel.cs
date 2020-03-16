using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.ViewModels
{
    public class TeacherCourseViewModel
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<TeacherCourse> TeacherCourses { get; set; }
    }
}
