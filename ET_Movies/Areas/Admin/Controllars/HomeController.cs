using Microsoft.AspNetCore.Mvc;

namespace ET_Movies.Areas.Admin.Controllars
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
