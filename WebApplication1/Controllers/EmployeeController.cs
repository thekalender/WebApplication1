using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Services.Logging;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        //Dependency Injection
        private ILogger _logger;
        public EmployeeController(ILogger logger)
        {
            _logger = logger;
        }
        //Dependency Injection
        public IActionResult Add()
        {
            var employeeAddViewModel = new EmployeeAddViewModel
            {
                Employee = new Employee(),
                Cities = new List<SelectListItem>
                {
                    new SelectListItem{Text = "Ankara", Value = "6"},
                    new SelectListItem{Text = "İstanbul", Value = "34"}
                }
            };

            return View(employeeAddViewModel);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            Employee employee1 = new Employee();

            employee1.ID = employee.ID;
            employee1.FirstName = employee.FirstName;
            employee1.LastName = employee.LastName;
            employee1.CityId = employee.CityId;

            return View(employee1);
        }
    }
}
