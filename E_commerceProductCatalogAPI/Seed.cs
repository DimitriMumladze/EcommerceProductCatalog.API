using E_commerceProductCatalogAPI.Data;
using E_commerceProductCatalogAPI.Models;

namespace E_commerceProductCatalogAPI
{
    public class Seed
    {
        private readonly ApplicationDbContext dataContext;
        public Seed(ApplicationDbContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Products.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Electronics", Description = "Electronic devices and accessories" },
                    new Category { Name = "Clothing", Description = "Apparel and fashion items" }
                };

                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Smartphone X",
                        Description = "Latest model smartphone with advanced features",
                        Price = 999.99m,
                        SKU = "PHONE-X-001",
                        StockQuantity = 100,
                        Categories = new List<Category> { categories[0] },
                        Variants = new List<ProductVariant>
                        {
                            new ProductVariant { Name = "Black", PriceModifier = 0, StockQuantity = 50 },
                            new ProductVariant { Name = "Red", PriceModifier = 10, StockQuantity = 30 }
                        },
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Rating = 5,
                                Comment = "Great phone, very fast!",
                                CreatedAt = DateTime.Now,
                                User = new User { Username = "john_doe", Email = "john@example.com", PasswordHash = "hashed_password_here" }
                            },
                            new Review
                            {
                                Rating = 4,
                                Comment = "Good phone, but a bit expensive",
                                CreatedAt = DateTime.Now,
                                User = new User { Username = "jane_smith", Email = "jane@example.com", PasswordHash = "hashed_password_here" }
                            }
                        }
                    },
                    new Product
                    {
                        Name = "Laptop Pro",
                        Description = "High-performance laptop for professionals",
                        Price = 1499.99m,
                        SKU = "LAPTOP-PRO-001",
                        StockQuantity = 50,
                        Categories = new List<Category> { categories[0] },
                        Variants = new List<ProductVariant>
                        {
                            new ProductVariant { Name = "8GB RAM", PriceModifier = 0, StockQuantity = 30 },
                            new ProductVariant { Name = "16GB RAM", PriceModifier = 200, StockQuantity = 20 }
                        },
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Rating = 5,
                                Comment = "Excellent performance for work and gaming",
                                CreatedAt = DateTime.Now,
                                User = new User { Username = "tech_enthusiast", Email = "tech@example.com", PasswordHash = "hashed_password_here" }
                            }
                        }
                    },
                    new Product
                    {
                        Name = "Cotton T-Shirt",
                        Description = "Comfortable 100% cotton t-shirt",
                        Price = 19.99m,
                        SKU = "SHIRT-COT-001",
                        StockQuantity = 200,
                        Categories = new List<Category> { categories[1] },
                        Variants = new List<ProductVariant>
                        {
                            new ProductVariant { Name = "Small", PriceModifier = 0, StockQuantity = 70 },
                            new ProductVariant { Name = "Medium", PriceModifier = 0, StockQuantity = 80 },
                            new ProductVariant { Name = "Large", PriceModifier = 2, StockQuantity = 50 }
                        },
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Rating = 4,
                                Comment = "Very comfortable, but runs a bit small",
                                CreatedAt = DateTime.Now,
                                User = new User { Username = "fashion_lover", Email = "fashion@example.com", PasswordHash = "hashed_password_here" }
                            }
                        }
                    }
                };

                dataContext.Categories.AddRange(categories);
                dataContext.Products.AddRange(products);
                dataContext.SaveChanges();
            }
        }
    }
}