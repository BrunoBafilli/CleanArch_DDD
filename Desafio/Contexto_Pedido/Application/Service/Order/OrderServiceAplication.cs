using System.ComponentModel.DataAnnotations;
using Application.GOFPatterns;
using Application.Service.Interfaces;
using Domain.ArchPatterns.UnitOfWork;
using Domain.DomainEvents.Interfaces;
using Domain.DomainEvents.Order.Dispatcher;
using Domain.DomainEvents.Order.Handlers;
using Domain.DomainEvents.Order.Interfaces;
using Domain.Events.Order.Events;
using OrderEntity = Domain.Entities.Order.Order;

namespace Application.Service.Order
{
    public class OrderServiceAplication : IOrderServiceAplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISendEmail _sendEmail;

        public OrderServiceAplication(IUnitOfWork unitOfWork, ISendEmail sendEmail)
        {
            _unitOfWork = unitOfWork;
            _sendEmail = sendEmail;
        }

        public async Task CreateNewOrder(int clientId, List<int> productsId)
        {
            var order = await CreateProductsByIdFactory.CreateProducts(clientId, productsId, _unitOfWork);

            await _unitOfWork.OrderRepository.CreateAsync(order);

            await _unitOfWork.CommitAsync();

            SendEvents(order);
        }

        public void SendEvents(OrderEntity order)
        {
            order.PlaceOrder();

            var completedOrderEventHandlers = new List<IEventHandler<CompletedOrderEvent>>()
            {
                new SendEmailCompletedOrderHandle(_sendEmail)
            };

            var completedOrderEventDispatcher = new CompletedOrderEventDispatcher(completedOrderEventHandlers);

            completedOrderEventDispatcher.Dispatcher(order.CompletedOrderEvents);

            order.ClearEvents();
        }
    }
}
