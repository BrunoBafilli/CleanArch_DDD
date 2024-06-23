using System.ComponentModel.DataAnnotations;
using Application.DTOs.Order;
using Application.GOFPatterns;
using Application.Service.Order.Interfaces;
using AutoMapper;
using Domain.ArchPatterns.UnitOfWork;
using Domain.DomainEvents.Dispatcher;
using Domain.DomainEvents.Interfaces;
using Domain.DomainEvents.Order.Handlers;
using Domain.DomainEvents.Order.Interfaces;
using Domain.Entities.Client;
using Domain.Entities.Order;
using Domain.Entities.Order.ValueObject;
using Domain.Events.Order.Events;
using OrderEntity = Domain.Entities.Order.Order;

namespace Application.Service.Order
{
    public class OrderServiceAplication : IOrderServiceAplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISendEmail _sendEmail;
        private readonly IMapper _mapper;

        public OrderServiceAplication(IUnitOfWork unitOfWork, ISendEmail sendEmail, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _sendEmail = sendEmail;
            _mapper = mapper;
        }

        public async Task CreateNewOrderAsync(CreteNewOrderDTO orderDTO)
        {
            var order = await CreateProductsByIdFactory.CreateProducts(orderDTO, _unitOfWork);

            await _unitOfWork.OrderRepository.CreateAsync(order);

            await _unitOfWork.CommitAsync();

            SendEvents(order, orderDTO.ClientEmail);
        }

        public async Task<List<ReadOrderDTO>> ReadOrdersByClientIdAsync(int clientId)
        {
            var orders = await _unitOfWork.OrderRepository.ReadOrdersByClientIdAsync(clientId);

            return ReadOrderListByUserIdFromDTO.Map(orders);
        }


        public async Task<ReadOrderDTO> ReadOrderByorderIdClientIdAsync(int orderId, int clientId)
        {
            var order = await _unitOfWork.OrderRepository.ReadOrderByIdAndClientIdAsync(orderId, clientId);

            return _mapper.Map<ReadOrderDTO>(order);
        }

        public void SendEvents(OrderEntity order, string email)
        {
            order.PlaceOrder(order.Id, email);

            var completedOrderEventHandlers = new List<IEventHandler<CompletedOrderEvent>>()
            {
                new SendEmailCompletedOrderHandle(_sendEmail)
            };

            var completedOrderEventDispatcher = new CompletedEventDispatcher<CompletedOrderEvent>(completedOrderEventHandlers);

            completedOrderEventDispatcher.Dispatcher(order.CompletedOrderEvents);

            order.ClearEvents();
        }
    }
}
