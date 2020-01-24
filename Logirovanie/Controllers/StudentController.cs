using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logirovanie.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Logirovanie.Controllers
{
    public class StudentController : Controller
    {
        IEnumerable<Student> repo;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;

            repo = new List<Student>() {
                new Student() { Id = 1, Name = "Иванов" },
                new Student() { Id = 2, Name = "Петров" },
                new Student() { Id = 3, Name = "Сидоров" }, };

        }
        // GET: Student
        public ActionResult Index()
        {
            return View(repo.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student = repo.FirstOrDefault(x => x.Id == id);
            _logger.LogInformation("Переход на Student/Details (Id = " + student.Id + ", Name = " + student.Name + ")");
            return View(student);
        }

    }
}