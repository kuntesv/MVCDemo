using Microsoft.AspNetCore.Mvc;

namespace MVCDemo.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
