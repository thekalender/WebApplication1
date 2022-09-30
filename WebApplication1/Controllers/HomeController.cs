using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        List<string> sehirler = new List<string>() { };
        public string Index()
        {
            return "Hellööö";
        }

        public IActionResult RazorDemo()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee{ID = 1,FirstName = "ahmet", LastName = "kalender",CityId = 80},
                new Employee{ID = 2,FirstName = "mehmet", LastName = "çanak",CityId = 80},
                new Employee{ID = 3,FirstName = "samet", LastName = "uydu",CityId = 80}
            };

            List<string> sehirler = new List<string>() {"Osmaniye","İstanbul" };

            var model = new EmployeeListViewModel
            {
                Employees = employees,
                Cities = sehirler
            };

            return View(model);
        }

        public JsonResult Index2(string key)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee{ID = 1,FirstName = "ahmet", LastName = "kalender",CityId = 80},
                new Employee{ID = 2,FirstName = "mehmet", LastName = "çanak",CityId = 80},
                new Employee{ID = 3,FirstName = "samet", LastName = "uydu",CityId = 80}
            };      

            if (String.IsNullOrEmpty(key))
            {
                return Json(employees);
            }

            var result = employees.Where(x => x.FirstName.ToLower().Contains(key));

            return Json(result);
        }

        public IActionResult EmployeeForm()
        {
            return View();
        }
    }
}
