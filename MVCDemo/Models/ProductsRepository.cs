﻿namespace MVCDemo.Models
{
    public class ProductsRepository
    {
        private static List<Product> _products = new List<Product>()
    {
        new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
        new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
        new Product { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
        new Product { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
    };

        public static void AddProduct(Product product)
        {
            var maxId = _products.Max(x => x.ProductId);
            product.ProductId = maxId + 1;
            _products.Add(product);
        }

        public static List<Product> GetProducts(bool populateCategory = false)
        {
            if (!populateCategory)
            {
                return _products;

            }
            else {

                if (_products != null && _products.Any())
                {
                    foreach (var prod in _products)
                    {
                        if (prod.CategoryId != null)
                        {
                            prod.Category = CategoriesRepository.GetCategoryById(prod.CategoryId.Value);

                        }
                    }
                }
                return _products;
            }
        }

        public static Product? GetProductById(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                var prod = new Product
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                };

                if (prod.CategoryId.HasValue)
                {
                    prod.Category = CategoriesRepository.GetCategoryById(prod.CategoryId.Value);
                }

                return prod;
            }

            return null;
        }

        public static void UpdateProduct(int productId, Product product)
        {
            if (productId != product.ProductId) return;

            var productToUpdate = _products.FirstOrDefault(x => x.ProductId == productId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Price = product.Price;
                productToUpdate.CategoryId = product.CategoryId;
            }
        }

        public static void DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public static List<Product> GetProductsByCategoryId(int categoryId)
        {
            var prodcuts = _products.Where(x => x.CategoryId == categoryId);
            if (prodcuts != null)
            {
                return prodcuts.ToList();
            }
            else
            {
                return new List<Product>();
            }
        }


    }
}
