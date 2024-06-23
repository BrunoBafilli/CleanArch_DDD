using Application.DTOs.Client;
using Application.DTOs.Order;
using AutoMapper;

namespace Application.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreteNewOrderDTO, Domain.Entities.Order.Order>().ReverseMap();
            CreateMap<CreateNewClientDTO, Domain.Entities.Client.Client>()
            .ConstructUsing(dto => new Domain.Entities.Client.Client(dto.Name, dto.Email, dto.PhoneNumber.Number))
                .ForMember(dest => dest.OrdersIds, opt => opt.Ignore());
        }
    }
}
