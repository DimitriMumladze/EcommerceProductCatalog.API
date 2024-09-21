using E_commerceProductCatalogAPI.Data;
using E_commerceProductCatalogAPI.Interfaces;
using E_commerceProductCatalogAPI.Models;

namespace E_commerceProductCatalogAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.Id).ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public Product GetProduct(string name)
        {
            return _context.Products.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetProductRating(int productId)
        {
            var reviews = _context.Reviews.Where(r => r.ProductId == productId);
            if (reviews.Any())
                return (decimal)reviews.Average(r => r.Rating);
            return 0;
        }

        public bool ProductExists(int productId)
        {
            return _context.Products.Any(p => p.Id == productId);
        }

        public bool CreateProduct(int categoryId, Product product)
        {
            var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            if (category == null)
                return false;

            product.Categories = new List<Category> { category };
            _context.Add(product);
            return Save();
        }

        public bool UpdateProduct(int categoryId, Product product)
        {
            _context.Update(product);
            return Save();
        }

        public bool DeleteProduct(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}