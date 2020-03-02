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

        public StudentController(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _studentRepository.GetAllStudents();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
               var foundStudents = _studentRepository.SearchStudents(search);
                return View(foundStudents);
            }
            var model = _studentRepository.GetAllStudents();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            StudentCreateViewModel model = new StudentCreateViewModel();
            var departments = _departmentRepository.GetAllDepartments().ToList();
            model.Departments = departments;
            //ViewBag.DepartmentNames = _departmentRepository.GetAllDepartments().Select(r => new SelectListItem 
            //{ Value = r.DeptId.ToString(), Text = r.DeptName }).ToList();
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
                    Department = new Department
                    {
                        DeptId = model.SelectedDepartment
                    }
                };
                _studentRepository.AddStudent(student);
                return Redirect("/Student");
            }

            return View(model);
        }

    }
}