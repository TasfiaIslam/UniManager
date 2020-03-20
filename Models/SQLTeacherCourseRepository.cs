using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public class SQLTeacherCourseRepository : ITeacherCourseRepository
    {
        private readonly AppDbContext _context;

        public SQLTeacherCourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TeacherCourse> AllData()
        {
            return _context.TeacherCourses;
        }

        public IEnumerable<TeacherCourse> GetTeacherCourses(int Id)
        {
            return _context.TeacherCourses.Include(item => item.Course)
                                          .Where(x => x.TeacherId == Id).ToList();
        }

        public IEnumerable<TeacherCourse> ExistingCourses(int teacherId, int courseId)
        {
            return _context.TeacherCourses.Where(x => x.TeacherId == teacherId)
                                          .Where(x => x.CourseId == courseId).ToList();
        }


        public void AddCourse(int teacherId, int courseId)
        {
            TeacherCourse courseItem = new TeacherCourse
            {
                Course = _context.Courses.FirstOrDefault(c => c.CourseId == courseId),
                Teacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == teacherId)
            };

            _context.TeacherCourses.Add(courseItem);
            _context.SaveChanges();
        }
     
    }
}
