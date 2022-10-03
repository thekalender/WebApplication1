using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class SessionDemoController : Controller
    {
        public string Index1()
        {
            Employee employee = new Employee { ID = 1, FirstName = "ahmet",LastName="kalender",CityId = 80 };

            HttpContext.Session.SetString("isim", "Ahmet");
            HttpContext.Session.SetObject("musteri", employee);
            return "session gönderildi.";
        }

        public string Index2()
        {
            //return HttpContext.Session.GetString("isim");
            var res = HttpContext.Session.GetObject<Employee>("musteri");
            return res.FirstName;
        }
    }
}
