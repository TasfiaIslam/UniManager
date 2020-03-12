﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.ViewModels;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public TeacherController(ITeacherRepository teacherRepository, IDepartmentRepository departmentRepository)
        {
            _teacherRepository = teacherRepository;
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _teacherRepository.GetAllTeachers();
            var count = _teacherRepository.GetAllTeachers().Count();
            ViewBag.Total = count;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var foundTeachers = _teacherRepository.SearchTeachers(search);
                var countFoundTeachers = foundTeachers.Count();
                ViewBag.Total = countFoundTeachers;
                return View(foundTeachers);
            }

            var model = _teacherRepository.GetAllTeachers();

            var count = _teacherRepository.GetAllTeachers().Count();
            ViewBag.Total = count;

            return View(model);
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
    }
}