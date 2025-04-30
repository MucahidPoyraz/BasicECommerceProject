using AutoMapper;
using Common.PageModels;
using DTOs.OrderDetailDtos;
using DTOs.PageDtos;
using Entities.Concrete;

namespace DTOs.AutoMappers
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetailDto, Order>().ReverseMap();
            CreateMap<CreateOrderDetailDto, Order>().ReverseMap();
            CreateMap<UpdateOrderDetailDto, Order>().ReverseMap();
            CreateMap<PaginatedList<OrderDetail>, PaginatedResponseDto<OrderDetailDto>>().ReverseMap();
        }
    }
}
