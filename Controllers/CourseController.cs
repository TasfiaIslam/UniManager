using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.ViewModels;

namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public CourseController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _courseRepository.GetAllCourses();
            var count = _courseRepository.GetAllCourses().Count();
            ViewBag.Total = count;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string searchName, string searchCredit)
        {
            var model = _courseRepository.GetAllCourses();

            if (!String.IsNullOrEmpty(searchName))
            {
                 model = _courseRepository.SearchByName(searchName);
                //var countFoundCourses = foundCourses.Count();
                //ViewBag.Total = countFoundCourses;
                return View(model);
            }

            if (!String.IsNullOrEmpty(searchCredit))
            {
                model = _courseRepository.SearchByCredit(searchCredit);
                //var countFoundCourses = foundCourses.Count();
                //ViewBag.Total = countFoundCourses;
                return View(model);
            }

            

            var count = _courseRepository.GetAllCourses().Count();
            ViewBag.Total = count;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CourseCreateViewModel model = new CourseCreateViewModel();

            var departments = _departmentRepository.GetAllDepartments().ToList();
            model.Departments = departments;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CourseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course
                {
                    Name = model.Course.Name,
                    Credit = model.Course.Credit,
                    DeptId = model.Dept.DeptId
                };
                _courseRepository.AddCourse(course);
                return Redirect("/Course");
            }
            
            return View(model);
        }

        [HttpPost]
        public IActionResult GroupByDepartment()
        {
            var courseGroups = _courseRepository.GetAllCourses().GroupBy(t => t.DeptId);
            return View(courseGroups);
        }


    }
}