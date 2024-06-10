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
    public class OrderServiceTests
    {
        private IUnitOfWork _unitOfWork;
        private ICreateOrderService _createOrderService;

        public OrderServiceTests()
        {
            _unitOfWork = DI.GetService<IUnitOfWork>();
            _createOrderService = DI.GetService<ICreateOrderService>();
        }

        [Fact]
        public async Task CreateNewOrder()
        {
            // Arrange
            int quantity = 3;
            int clientId = 21;
            var newName = "goiaba";

            Product product = new Product(newName, "meuProduto", new Price(50.50m), new Stock(5));

            // Act
            await _createOrderService.CreateNewOrder(quantity, clientId, product);

            // Assert
            product.Name.Should().Be(newName);
        }
    }
}
