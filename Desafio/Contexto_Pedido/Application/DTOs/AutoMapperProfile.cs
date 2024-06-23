using Application.DTOs.Client;
using Application.DTOs.Order;
using AutoMapper;
using Domain.Entities.Order.ValueObject;
using Domain.Entities.Order;

namespace Application.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            OrderMap();
            ClientMap();
        }

        public void ClientMap()
        {
            CreateMap<ReadClientDTO, Domain.Entities.Client.Client>().ReverseMap();

            CreateMap<CreateNewClientDTO, Domain.Entities.Client.Client>()//Essa complexidade existe por conta da instancia no construtor.
                .ConstructUsing(dto => new Domain.Entities.Client.Client(dto.Name, dto.Email, dto.PhoneNumber.Number))
                .ForMember(dest => dest.OrdersIds, opt => opt.Ignore());
        }

        public void OrderMap()
        {
            
            CreateMap<CreteNewOrderDTO, Domain.Entities.Order.Order>().ReverseMap();

            //Agregados
            CreateMap<ReadOrderDTO, Domain.Entities.Order.Order>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<OrderItemProduct, OrderItemProductDTO>().ReverseMap();
            CreateMap<Price, PriceDTO>().ReverseMap();
        }
    }
}
