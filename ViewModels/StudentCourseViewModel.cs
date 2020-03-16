using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.ViewModels
{
    public class StudentCourseViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<StudentCourse> StudentCourses { get; set; }

    }
}
