using E_commerceProductCatalogAPI.Models;

namespace E_commerceProductCatalogAPI.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        Product GetProduct(string name);
        decimal GetProductRating(int productId);
        bool ProductExists(int productId);
        bool CreateProduct(int categoryId, Product product);
        bool UpdateProduct(int categoryId, Product product);
        bool DeleteProduct(Product product);
        bool Save();
    }
}