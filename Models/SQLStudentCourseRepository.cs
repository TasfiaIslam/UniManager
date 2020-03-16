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

        public IEnumerable<StudentCourse> ExistingCourses(int studentId, int courseId)
        {
            return _context.StudentCourses.Where(x => x.StudentId == studentId)
                                          .Where(x => x.CourseId == courseId).ToList();
        }

        public void AddCourse(int studentId, int courseId)
        {
            StudentCourse courseItem = new StudentCourse
            {
                Course = _context.Courses.FirstOrDefault(c => c.CourseId == courseId),
                Student = _context.Students.FirstOrDefault(s => s.StudentId == studentId)
            };

            _context.StudentCourses.Add(courseItem);
            _context.SaveChanges();
        }
    }
}
