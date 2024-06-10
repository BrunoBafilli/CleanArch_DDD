using Domain.ArchPatterns.Repositories;
using Domain.ArchPatterns.UnitOfWork;
using Infrastructure.IOC.ContainerDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Entities.Client;
using Domain.Entities.Order;
using Domain.Entities.Order.ValueObject;
using FluentAssertions;

namespace Tests.Entities.Service
{
    public class CreateOrderServiceTests
    {
        private IUnitOfWork _unitOfWork;
        private ICreateOrderService _createOrderService;

        public CreateOrderServiceTests()
        {
            _unitOfWork = DI.GetService<IUnitOfWork>();
            _createOrderService = DI.GetService<ICreateOrderService>();
        }

        [Fact]
        public async Task CreateNewOrder()
        {
            //Arrange
            Client findedClient = await _unitOfWork.ClientRepository.ReadByIdAsync(2008);

            OrderItem orderItem = new OrderItem(5, new Price(0));

            Product product = new Product("product1", "minhadescricao", new Price(55.50m), new Stock(5));

            //Action - Assert
            await _createOrderService.CreateOrder(findedClient.Id, orderItem, product);
        }

        [Fact]
        public async Task UpdateOrder()
        {
            // Arrange
            var userId = 2008;
            var orderId = 21;
            var orderItemId = 16;
            var newName = "chocolate";

            var client = await _unitOfWork.ClientRepository.ReadByIdAsync(userId);
            var order = await _unitOfWork.OrderRepository.ReadOrdersByUserId(client.Id, orderId);
            var orderItem = order.OrderItems.FirstOrDefault(x => x.Id == orderItemId);
            var product = orderItem.Products.FirstOrDefault(x => x.Id == orderItemId);

            // Act
            product.ChangeName(newName);
            await _createOrderService.UpdateOrder(client.Id, order);

            // Assert
            product.Name.Should().Be(newName);
        }
    }
}
