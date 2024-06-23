using Domain.DomainEvents.Interfaces;
using Domain.DomainEvents.Order.Handlers;
using Domain.Entities.Order;
using Domain.Events.Order.Events;
using Infrastructure.IOC.ContainerDI;
using FluentAssertions;
using Domain.DomainEvents.Order.Interfaces;
using Application.Service.Order.Interfaces;
using Domain.DomainEvents.Dispatcher;
using Application.DTOs.Order;

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

            CreteNewOrderDTO orderDto = new CreteNewOrderDTO(){ClientId = clientId, ProductsId = productsIds};

            // Act
            await _orderServiceAplication.CreateNewOrder(orderDto);
        }

        [Fact]
        public void SendEvents_ShouldPlaceOrderAndDispatchCompletedOrderEvents()
        {
            // Arrange
            var order = new Order(1);
            string email = "brunobafilli@bla.com";
            var completedOrderEventHandlers = new List<IEventHandler<CompletedOrderEvent>>()
            {
                new SendEmailCompletedOrderHandle(_sendEmail)
            };
            var completedOrderEventDispatcher = new CompletedEventDispatcher<CompletedOrderEvent>(completedOrderEventHandlers);

            // Act
            order.PlaceOrder(order.Id, email);
            completedOrderEventDispatcher.Dispatcher(order.CompletedOrderEvents);
            order.ClearEvents();

            // Assert
            order.CompletedOrderEvents.Should().BeEmpty();
        }
    }
}
