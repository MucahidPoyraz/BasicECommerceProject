using AutoMapper;
using Common.PageModels;
using DTOs.PageDtos;
using DTOs.ProductDtos;
using Entities.Concrete;

namespace DTOs.AutoMappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();

            CreateMap<PaginatedList<Product>, PaginatedResponseDto<ProductDto>>().ReverseMap();
        }
    }
}
