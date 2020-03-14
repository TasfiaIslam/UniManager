using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public class SQLStudentCourseRepository : IStudentCourseRepository
    {
        private readonly AppDbContext _context;

        public SQLStudentCourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<StudentCourse> GetStudentCourses(int Id)
        {
            return _context.StudentCourses.Include(item => item.Course)
                                          .Where(x => x.StudentId == Id).ToList();
        }
    }
}
