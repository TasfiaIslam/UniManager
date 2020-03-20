using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _departmentRepository.GetAllDepartments();
            var count = _departmentRepository.GetAllDepartments().Count();
            ViewBag.Total = count;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var foundDepartments = _departmentRepository.SearchDepartments(search);
                var countFoundDepartments = foundDepartments.Count();
                ViewBag.Total = countFoundDepartments;
                return View(foundDepartments);
            }
            var model = _departmentRepository.GetAllDepartments();

            var count = _departmentRepository.GetAllDepartments().Count();
            ViewBag.Total = count;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            _departmentRepository.AddDepartment(department);
            return View();
        }
    }
}