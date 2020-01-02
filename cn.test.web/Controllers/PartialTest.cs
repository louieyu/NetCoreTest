using System;
using Microsoft.AspNetCore.Mvc;

namespace cn.test.web.Controllers
{
    public class PartialTest : Controller
    {
        public IActionResult demo()
        {
            return View();
        }
    }
}
