using Microsoft.AspNetCore.Mvc;

namespace cn.test.web.Controllers
{
    [Route("[controller]/[action]")]
    public class Home : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Hello,World!");
        }
        [HttpGet]
        public IActionResult Time()
        {
            ViewBag.ServerTime = System.DateTime.Now;
            return View("Time");
        }

        /// <summary>
        /// 获取id
        /// </summary>
        /// <returns>id</returns>
        [HttpGet]
        public int get()
        {
            return 1;
        }
    }
}