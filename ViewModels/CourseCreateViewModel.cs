using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.ViewModels
{
    public class CourseCreateViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public Department Dept { get; set; }
    }
}
