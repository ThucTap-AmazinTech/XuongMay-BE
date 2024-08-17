using Microsoft.AspNetCore.Mvc;

namespace XuongMay_BE.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
