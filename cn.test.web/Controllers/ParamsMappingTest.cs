using System;
using Microsoft.AspNetCore.Mvc;
using cn.test.web.Models;
using System.Collections.Generic;

namespace cn.test.web.Controllers
{
    public class ParamsMappingTest : Controller
    {
        [HttpGet]
        public IActionResult GetId(int id)
        {
            return Content($"This action params mapping test by me ,is :{id}");
        }

        public IActionResult GetArray(string[] arr)
        {
            var temp = "Action getarray params mapping test by me ,is :";
            if (arr != null)
            {
                temp += string.Join(",", arr);
            }
            return Content(temp);
        }

        public IActionResult GetPerson(Person person)
        {
            return Json(new { text = "Action getperson params mapping test", data = person });
        }

        public IActionResult GetList(List<Person> list)
        {
            return Json(new { text = "Action getperson params mapping test", data = list });
        }

        public IActionResult GetPersonJson([FromBody]Person person)
        {
            return Json(new { text = "Action getperson params mapping test", data = person });
        }

        public IActionResult GetByManual()
        {
            var age = Request.Form["age"];
            return Json(new
            {
                id = RouteData.Values["id"],
                name = Request.Query["name"],
                age = age
            });
        }
    }
}