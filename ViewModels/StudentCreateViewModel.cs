using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.ViewModels
{
    public class StudentCreateViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public int SelectedDepartment { get; }
        public Department Dept { get; set; }

    }
}
