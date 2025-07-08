using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using MVCDemo.ViewModel;

namespace MVCDemo.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };

            return View(salesViewModel);
        }

    }
}
