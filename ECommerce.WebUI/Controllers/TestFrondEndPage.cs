using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class TestFrondEndPage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult betuflpage()
        {
            return View();
        }

        public IActionResult buyProduct()
        {
            return View();
        }

        public IActionResult features()
        {
            return View();
        }
        public IActionResult mycart()
        {
            return View();
        }

        public IActionResult sign_in_page()
        {
            return View();
        }

        public IActionResult sign_up_page()
        {
            return View();
        }
    }
}
