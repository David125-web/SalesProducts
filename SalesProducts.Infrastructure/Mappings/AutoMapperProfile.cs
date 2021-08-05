using AutoMapper;
using SalesProducts.Core.DTOs;
using SalesProducts.Core.Entities;

namespace SalesProducts.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTo>();
            CreateMap<UserDTo, User>();

            CreateMap<Product, ProductDTo>();
            CreateMap<ProductDTo, Product>();

            CreateMap<Order, OrderDTo>();
            CreateMap<OrderDTo, Order>();
        }
    }
}
