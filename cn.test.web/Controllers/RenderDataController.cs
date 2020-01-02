using System;
using Microsoft.AspNetCore.Mvc;
using cn.test.web.Models;

namespace cn.test.web.Controllers
{
    public class RenderDataController : Controller
    {
        public IActionResult ViewDataDemo()
        {
            ViewData["name"] = "test";
            ViewData["birthday"] = new DateTime(1999, 09, 09);
            ViewData["hobby"] = new string[] { "tt", "kk", "cc" };
            return View();
        }

        public IActionResult ViewModelDemo()
        {
            var person = new Person
            {
                Name = "heihei",
                Age = 31,
                Birthday = new DateTime(1999, 09, 09),
                Hobby = new string[] { "sing", "dance" }

            };

            return View(person);
        }
    }
}
