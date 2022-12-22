using AutoMapper;
using Catalog.Api.Dtos;
using Catalog.Api.Models;

namespace Catalog.Api.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }

    }
}
