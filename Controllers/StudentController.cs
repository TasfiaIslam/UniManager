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
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherCourseRepository _teacherCourseRepository;

        public StudentController(IStudentRepository studentRepository, IDepartmentRepository departmentRepository,
                                     IStudentCourseRepository stdCourseRepository, ICourseRepository courseRepository,
                                     ITeacherCourseRepository teacherCourseRepository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            _stdCourseRepository = stdCourseRepository;
            _courseRepository = courseRepository;
            _teacherCourseRepository = teacherCourseRepository;
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

            var result = _studentRepository.GetAllStudents().OrderBy(s => s.Name);

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

        [HttpGet]
        public IActionResult AddCourse(int Id)
        {
            var student = _studentRepository.GetStudent(Id);
            IEnumerable<Course> courses = _courseRepository.GetAllCourses();

            return View(new AddStudentCourseViewModel(student, courses));
        }

        [HttpPost]
        public IActionResult AddCourse(AddStudentCourseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var studentId = viewModel.StudentId;
                var courseId = viewModel.CourseId;

                IEnumerable<StudentCourse> existingCourses = _stdCourseRepository.ExistingCourses(studentId, courseId);

                if(existingCourses.Count() == 0)
                {
                    _stdCourseRepository.AddCourse(studentId , courseId);
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult OrderStudentsByName()
        {
            var result = _studentRepository.GetAllStudents().OrderBy(s => s.Name);
            return View(result);
        }

        [HttpPost]
        public IActionResult GroupByDepartment()
        {
            var studentGroups = _studentRepository.GetAllStudents().GroupBy(s => s.DeptId);
            return View(studentGroups);
        }

        public IActionResult Details(int id)
        {
            Student student = _studentRepository.GetStudent(id);
            //Error Handling if Employee ID not found
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", id);
            }
            StudentDetailsViewModel studentDetailsViewModel = new StudentDetailsViewModel()
            {
                Student = student,
                PageTitle = "Student Details"
            };
            return View(studentDetailsViewModel);
        }

        public IActionResult Delete(int id)
        {
            var model = _studentRepository.DeleteStudent(id);
            ViewBag.Message ="Student Id "+ model.StudentId + " is deleted.";
            return View(model);
        }

    }
}