using AutoMapper;
using Common.PageModels;
using DTOs.CustomerDtos;
using DTOs.PageDtos;
using Entities.Concrete;

namespace DTOs.AutoMappers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<UpdateCustomerDto, Customer>().ReverseMap();
            CreateMap<CreateCustomerDto, Customer>().ReverseMap();
            CreateMap<PaginatedList<Customer>, PaginatedResponseDto<CustomerDto>>().ReverseMap();
        }
    }
}
