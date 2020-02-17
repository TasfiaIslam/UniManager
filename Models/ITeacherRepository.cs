using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public interface ITeacherRepository
    {
        Teacher GetTeacher(int Id);
        IEnumerable<Teacher> GetAllTeachers();
        IEnumerable<Teacher> SearchTeachers(string search);
        Teacher AddTeacher(Teacher teacher);
    }
}
