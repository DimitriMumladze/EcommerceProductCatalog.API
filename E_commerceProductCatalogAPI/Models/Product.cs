namespace E_commerceProductCatalogAPI.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? SKU { get; set; }
    public int StockQuantity { get; set; }
    public ICollection<Category>? Categories { get; set; }
    public ICollection<ProductVariant>? Variants { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}
