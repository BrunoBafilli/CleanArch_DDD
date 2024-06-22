using Domain.ArchPatterns.UnitOfWork;
using Infrastructure.IOC.ContainerDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;
using FluentAssertions;

namespace Tests.Infrastructure.OrderTests
{
    public class OrderTest
    {
        private IUnitOfWork _unitOfWork;

        public OrderTest()
        {
            _unitOfWork = DI.GetService<IUnitOfWork>();
        }

        [Fact]
        public async void ReadOrderByIdAndClientId_Sucess()
        {
            //arrange
            int orderId = 1;

            //Action
            Order findedOrder = await _unitOfWork.OrderRepository.ReadOrderByIdAndClientIdAsync(1, 1);

            findedOrder.ClientId.Should().BeGreaterThan(0);
        }
    }
}
