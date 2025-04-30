using AutoMapper;
using Common.PageModels;
using DTOs.OrderDtos;
using DTOs.PageDtos;
using Entities.Concrete;
using System.Collections.Specialized;

namespace DTOs.AutoMappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<UpdateOrderDto, Order>().ReverseMap();
            CreateMap<PaginatedList<Order>, PaginatedResponseDto<OrderDto>>().ReverseMap();
        }
    }
}
