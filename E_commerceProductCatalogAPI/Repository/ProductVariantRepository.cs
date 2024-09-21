using E_commerceProductCatalogAPI.Data;
using E_commerceProductCatalogAPI.Interfaces;
using E_commerceProductCatalogAPI.Models;

namespace E_commerceProductCatalogAPI.Repositories
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductVariantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<ProductVariant> GetProductVariants()
        {
            return _context.ProductVariants.OrderBy(pv => pv.Id).ToList();
        }

        public ProductVariant GetProductVariant(int id)
        {
            return _context.ProductVariants.Where(pv => pv.Id == id).FirstOrDefault();
        }

        public ICollection<ProductVariant> GetProductVariantsByProduct(int productId)
        {
            return _context.ProductVariants.Where(pv => pv.ProductId == productId).ToList();
        }

        public bool ProductVariantExists(int id)
        {
            return _context.ProductVariants.Any(pv => pv.Id == id);
        }

        public bool CreateProductVariant(int productId, ProductVariant productVariant)
        {
            var product = _context.Products.Where(p => p.Id == productId).FirstOrDefault();
            if (product == null)
                return false;

            productVariant.Product = product;
            _context.Add(productVariant);
            return Save();
        }

        public bool UpdateProductVariant(ProductVariant productVariant)
        {
            _context.Update(productVariant);
            return Save();
        }

        public bool DeleteProductVariant(ProductVariant productVariant)
        {
            _context.Remove(productVariant);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}