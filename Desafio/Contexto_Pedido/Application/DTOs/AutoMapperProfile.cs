using AutoMapper;
using Domain.Entities.Client;
using Domain.Entities.Order;

namespace Application.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<ClientDTO, Client>()
            .ConstructUsing(dto => new Client(dto.Name, dto.Email, dto.PhoneNumber.Number))
                .ForMember(dest => dest.OrdersIds, opt => opt.Ignore());
        }
    }
}
