using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public SQLStudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public Student AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
           return _context.Students;
        }

        public Student GetStudent(int Id) 
        {
            return _context.Students.Find(Id);
        }

        public IEnumerable<Student> SearchStudents(string search)
        {
            int id;
            bool success = Int32.TryParse(search, out id);

            if (!success)
            {
                id = 0;
            }    
            return _context.Students.Where(x=>x.Name.Contains(search) || 
                                            x.RegNumber.Contains(search) ||
                                            x.Address.Contains(search) ||
                                            x.StudentId == id).ToList();
        }
    }
}
