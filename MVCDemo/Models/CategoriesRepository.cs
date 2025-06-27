namespace MVCDemo.Models
{
    public static class CategoriesRepository
    {

        private static List<Category> _categories = new List<Category>()
        {
            new Category { Id = 1 , Name = "Beverage", Description ="Beverages description"},
            new Category { Id = 2 , Name = "Bakery", Description ="Bakery description"},
            new Category { Id = 3 , Name = "Books", Description ="Books description"},
        };

        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(c => c.Id);
            category.Id = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() 
        {
            return _categories; 
        }

        public static Category? GetCategoryById(int categoryId) 
        { 
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                return new Category 
                { 
                    Description = category.Description,
                    Name = category.Name,
                    Id = category.Id
                };
            }
            return null; 
        }
        public static void UpdateCategory(int categoryId, Category category)
        {
            if(categoryId != category.Id)
            {
                return;
            }

            // var categoryToUpdate = GetCategoryById(categoryId);
            var categoryToUpdate = _categories.FirstOrDefault(c => c.Id == categoryId);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        
        }

        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.Id == categoryId);
            if(category != null)
            {
                _categories.Remove(category);
            }
        
        }
    }
}
