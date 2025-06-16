using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit([FromRoute]int? id)
        {
           // var category = new Category { Id = id.HasValue ? id.Value : 0 };
           
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View(category);
        }


    }
}
