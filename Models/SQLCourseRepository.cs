using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public class SQLCourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public SQLCourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public Course AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses;
        }

        public Course GetCourse(int Id)
        {
            return _context.Courses.Find(Id);
        }

        public IEnumerable<Course> SearchByName(string search)
        {
           return _context.Courses.Where(x => x.Name.Contains(search)).ToList();
        }

        public IEnumerable<Course> SearchByCredit(string search)
        {
            double credit = Convert.ToDouble(search);
            return _context.Courses.Where(x => x.Credit == credit).ToList();
        }
    }
}
