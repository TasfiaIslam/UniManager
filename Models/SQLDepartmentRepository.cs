using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public class SQLDepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public SQLDepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Department AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments;
        }

        public Department GetDepartment(int Id)
        {
            return _context.Departments.Find(Id);
        }

        public IEnumerable<Department> SearchDepartments(string search)
        {
            return _context.Departments.Where(x => x.DeptName.Contains(search)).ToList();
        }
    }
}
