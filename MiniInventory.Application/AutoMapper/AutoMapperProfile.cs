using AutoMapper;
using MiniInventory.Application.DTOs;
using MiniInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MiniInventory.Application.DTOs.OrderDTOs;

namespace MiniInventory.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {


            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));

            //CreateMap<OrderItem, OrderItemDetailDto>()
            //    .ForMember(d => d.ProductName, o => o.Ignore())
            //    .ForMember(d => d.UnitPrice, o => o.MapFrom(s => s.UnitPrice));
        }
    }
}
