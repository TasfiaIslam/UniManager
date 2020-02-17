using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public interface IDepartmentRepository
    {
        Department GetDepartment(int Id);
        IEnumerable<Department> GetAllDepartments();
        IEnumerable<Department> SearchDepartments(string search);
        Department AddDepartment(Department department);
    }
}
