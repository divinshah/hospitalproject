using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HospitalNew.Controllers
{
    public class JobPositionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}