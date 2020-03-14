using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.ViewModels;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStudentCourseRepository _stdCourseRepository;

        public StudentController(IStudentRepository studentRepository, IDepartmentRepository departmentRepository,
                                     IStudentCourseRepository stdCourseRepository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            _stdCourseRepository = stdCourseRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _studentRepository.GetAllStudents();
            var count = _studentRepository.GetAllStudents().Count();
            ViewBag.Total = count;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var foundStudents = _studentRepository.SearchStudents(search);
                var countFoundStudents = foundStudents.Count();
                ViewBag.Total = countFoundStudents;
                return View(foundStudents);
            }
            var model = _studentRepository.GetAllStudents();
            
            var count = _studentRepository.GetAllStudents().Count();
            ViewBag.Total = count;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            StudentCreateViewModel model = new StudentCreateViewModel();
            var departments = _departmentRepository.GetAllDepartments().ToList();
            model.Departments = departments;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {     
                Student student = new Student
                {
                    Name = model.Student.Name,
                    RegNumber = model.Student.RegNumber,
                    Address = model.Student.Address,
                    DeptId = model.Dept.DeptId,
                };
                _studentRepository.AddStudent(student);
                return Redirect("/Student");
            }

            return View(model);
        }

        public IActionResult ViewCourse(int Id)
        {
            var courses = _stdCourseRepository.GetStudentCourses(Id);
            var student = _studentRepository.GetStudent(Id);

            StudentCourseViewModel viewModel = new StudentCourseViewModel
            {
                Student = student,
                StudentCourses = courses
            };

            return View(viewModel);
        }

    }
}