using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public class SQLTeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public SQLTeacherRepository(AppDbContext context)
        {
            _context = context;
        }
        public Teacher AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
           return _context.Teachers;
        }

        public Teacher GetTeacher(int Id)
        {
            return _context.Teachers.Find(Id);
        }

        public IEnumerable<Teacher> SearchTeachers(string search)
        {
            return _context.Teachers.Where(x => x.Name.Contains(search) ||
                                         x.Address.Contains(search));
        }
    }
}
