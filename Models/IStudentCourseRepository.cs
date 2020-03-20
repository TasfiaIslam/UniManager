using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public interface IStudentCourseRepository
    {
        IEnumerable<StudentCourse> GetStudentCourses(int Id);
        IEnumerable<StudentCourse> ExistingCourses(int studentId, int courseId);
        void AddCourse(int studentId, int courseId);
        IEnumerable<StudentCourse> AllData();
    }
}
