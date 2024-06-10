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
using Domain.Entities.Order.ValueObject;
using FluentAssertions;
using Domain.Entities.Product;

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
            int clientId = 1;

            List<int> productsIds = new List<int>(){1,2};

            // Act
            await _createOrderService.CreateNewOrder(clientId, productsIds);
        }
    }
}
