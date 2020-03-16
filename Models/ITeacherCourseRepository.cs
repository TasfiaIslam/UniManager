using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public interface ITeacherCourseRepository
    {
        IEnumerable<TeacherCourse> GetTeacherCourses(int Id);
        IEnumerable<TeacherCourse> ExistingCourses(int teacherId, int courseId);
        void AddCourse(int teacherId, int courseId);
    }
}
