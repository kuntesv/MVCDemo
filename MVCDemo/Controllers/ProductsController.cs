using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using MVCDemo.ViewModel;

namespace MVCDemo.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {

            var products = ProductsRepository.GetProducts(true);

            return View(products);
        }


        public IActionResult Add()
        {
            var productViewModel = new ProductViewModel()
            {
                Categories = CategoriesRepository.GetCategories()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {

            return View(productViewModel);
        }



    }
}
