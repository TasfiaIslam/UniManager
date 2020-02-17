using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public IActionResult Index()
        {
            var model = _teacherRepository.GetAllTeachers();
            return View(model);
        }
    }
}