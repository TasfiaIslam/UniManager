using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public interface IStudentRepository
    {
        Student GetStudent(int Id);
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> SearchStudents(string search);
        Student AddStudent(Student student);
        Student DeleteStudent(int id);
    }
}
