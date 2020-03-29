using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public interface ICourseRepository
    {
        Course GetCourse(int Id);
        IEnumerable<Course> GetAllCourses();
        IEnumerable<Course> SearchByName(string search);
        IEnumerable<Course> SearchByCredit(string search);
        Course AddCourse(Course course);
    }
}
