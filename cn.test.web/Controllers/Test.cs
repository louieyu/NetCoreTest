using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace cn.test.web.Controllers
{
    [Route("[controller]")]
    public class Test : Controller
    {
        [NonAction]
        public IActionResult Hello()
        {
            ViewBag.ServerTime = System.DateTime.Now;
            return Content("test,h!");
        }

        /// <summary>
        /// 返回一个文本的ActionResult
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult ContetTest()
        {
            return Content("hello");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult JsonTest()
        {
            return Json(new { Message = "Json Test", Author = "test" });
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult FileTest()
        {
            var bytes = Encoding.Default.GetBytes("FileResult Test");
            return File(bytes, contentType: "application/text", "test.txt");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult RedirectTest()
        {
            return Redirect("http://www.baidu.com");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult RedirectToActionTest()
        {
            return RedirectToAction("JsonTest");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult RedirectToRouteTest()
        {
            return RedirectToRoute("default", new { Controller = "home", action = "index" });
        }
    }
}