﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.ViewModels;
using X.PagedList;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITeacherCourseRepository _teacherCourseRepository;
        private readonly ICourseRepository _courseRepository;

        public TeacherController(ITeacherRepository teacherRepository, IDepartmentRepository departmentRepository,
                                   ITeacherCourseRepository teacherCourseRepository, ICourseRepository courseRepository)
        {
            _teacherRepository = teacherRepository;
            _departmentRepository = departmentRepository;
            _teacherCourseRepository = teacherCourseRepository;
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            var model = _teacherRepository.GetAllTeachers();
            var count = _teacherRepository.GetAllTeachers().Count();
            ViewBag.Total = count;
            return View(model.ToPagedList(page ?? 1, 3));
        }

        [HttpPost]
        public IActionResult Index(string search, int? page)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var foundTeachers = _teacherRepository.SearchTeachers(search);
                var countFoundTeachers = foundTeachers.Count();
                ViewBag.Total = countFoundTeachers;
                return View(foundTeachers.ToPagedList(page ?? 1, 3));
            }

            var model = _teacherRepository.GetAllTeachers();

            var count = _teacherRepository.GetAllTeachers().Count();
            ViewBag.Total = count;

            return View(model.ToPagedList(page ?? 1, 3));
        }

        [HttpGet]
        public IActionResult Create()
        {
            TeacherCreateViewModel model = new TeacherCreateViewModel();

            var departments = _departmentRepository.GetAllDepartments().ToList();
            model.Departments = departments;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TeacherCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Teacher teacher = new Teacher
                {
                    Name = model.Teacher.Name,
                    Address = model.Teacher.Address,
                    DeptId = model.Dept.DeptId
                };
                _teacherRepository.AddTeacher(teacher);
                return Redirect("/Teacher");
            } 
            
            return View(model);
        }

        public IActionResult ViewCourse(int Id)
        {
            var courses = _teacherCourseRepository.GetTeacherCourses(Id);
            var teacher = _teacherRepository.GetTeacher(Id);

            TeacherCourseViewModel viewModel = new TeacherCourseViewModel
            {
                Teacher = teacher,
                TeacherCourses = courses
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddCourse(int Id)
        {
            var teacher = _teacherRepository.GetTeacher(Id);
            IEnumerable<Course> courses = _courseRepository.GetAllCourses();

            return View(new AddTeacherCourseViewModel(teacher, courses));
        }

        [HttpPost]
        public IActionResult AddCourse(AddTeacherCourseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var teacherId = viewModel.TeacherId;
                var courseId = viewModel.CourseId;

                IEnumerable<TeacherCourse> existingCourses = _teacherCourseRepository.ExistingCourses(teacherId, courseId);

                if (existingCourses.Count() == 0)
                {
                    _teacherCourseRepository.AddCourse(teacherId, courseId);
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult OrderTeachersByName(int? page)
        {
            var result = _teacherRepository.GetAllTeachers().OrderBy(t => t.Name);
            return View(result.ToPagedList(page ?? 1, 3));
        }

        [HttpPost]
        public IActionResult GroupByDepartment(int? page)
        {
            var teacherGroups = _teacherRepository.GetAllTeachers().GroupBy(t => t.DeptId);
            return View(teacherGroups.ToPagedList(page ?? 1, 3));
        }

        public IActionResult Details(int id)
        {
            Teacher teacher = _teacherRepository.GetTeacher(id);
            //Error Handling if Employee ID not found
            if (teacher == null)
            {
                Response.StatusCode = 404;
                return View("TeacherNotFound", id);
            }
            TeacherDetailsViewModel teacherDetailsViewModel = new TeacherDetailsViewModel()
            {
                Teacher = teacher,
                PageTitle = "Teacher Details"
            };
            return View(teacherDetailsViewModel);
        }

        public IActionResult Delete(int id)
        {
            var model = _teacherRepository.DeleteTeacher(id);
            ViewBag.Message = "Teacher Id " + model.TeacherId + " is deleted.";
            return View(model);
        }
    }
}