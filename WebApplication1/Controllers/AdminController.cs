using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        [Route("")]
        public string Add()
        {
            return "Saved";
        }

        [Route("Delete/{id?}")]
        public string Delete(int id)
        {
            return string.Format("Deleted {0}",id);
        }

        [Route("Update")]
        public string Update()
        {
            return "Updated";
        }
    }
}
