using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public interface IStudentCourseRepository
    {
        IEnumerable<StudentCourse> GetStudentCourses(int Id);
    }
}
