using AutoMapper;
using E_commerceProductCatalogAPI.DTO;
using E_commerceProductCatalogAPI.Models;

namespace E_commerceProductCatalogAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductVariant, ProductVariantDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
