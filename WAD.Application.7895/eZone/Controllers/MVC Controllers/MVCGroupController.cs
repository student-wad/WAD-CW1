using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.Controllers.MVC_Controllers
{
    public class MVCGroupController : Controller
    {
        public IActionResult GroupIndex()
        {
            return View();
        }
    }
}
