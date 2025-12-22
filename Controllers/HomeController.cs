using Microsoft.AspNetCore.Mvc;

namespace stokprojesi1.Controllers
{
    public class HomeController : Controller
    {
        // Ana Sayfa
        public IActionResult Index()
        {
            return View();
        }

               public IActionResult Error()
        {
            return View();
        }
    }
}