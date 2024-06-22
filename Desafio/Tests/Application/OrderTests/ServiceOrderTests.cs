using Domain.ArchPatterns.UnitOfWork;
using Domain.DomainEvents.Interfaces;
using Domain.DomainEvents.Order.Dispatcher;
using Domain.DomainEvents.Order.Handlers;
using Domain.Entities.Order;
using Domain.Events.Order.Events;
using Infrastructure.IOC.ContainerDI;
using FluentAssertions;
using Application.Service.Interfaces;
using Domain.DomainEvents.Order.Interfaces;

namespace Tests.Application.OrderTests
{
    public class ServiceOrderTests
    {
        private IOrderServiceAplication _orderServiceAplication;
        private ISendEmail _sendEmail;

        public ServiceOrderTests()
        {
            _orderServiceAplication = DI.GetService<IOrderServiceAplication>();
            _sendEmail = DI.GetService<ISendEmail>();
        }

        [Fact]
        public async Task CreateNewOrder()
        {
            // Arrange
            int clientId = 1;

            List<int> productsIds = new List<int>() { 1, 2 };

            // Act
            await _orderServiceAplication.CreateNewOrder(clientId, productsIds);
        }

        [Fact]
        public void SendEvents_ShouldPlaceOrderAndDispatchCompletedOrderEvents()
        {
            // Arrange
            var order = new Order(1);
            var completedOrderEventHandlers = new List<IEventHandler<CompletedOrderEvent>>()
            {
                new SendEmailCompletedOrderHandle(_sendEmail)
            };
            var completedOrderEventDispatcher = new CompletedOrderEventDispatcher(completedOrderEventHandlers);

            // Act
            order.PlaceOrder();
            completedOrderEventDispatcher.Dispatcher(order.CompletedOrderEvents);
            order.ClearEvents();

            // Assert
            order.CompletedOrderEvents.Should().BeEmpty();
        }
    }
}
