using Microsoft.AspNetCore.Mvc;

namespace Eticaret.MVCUI.Controllers
{
   public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
