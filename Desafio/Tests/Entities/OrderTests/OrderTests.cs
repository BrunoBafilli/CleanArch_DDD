using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;
using Domain.Entities.Order.ValueObject;
using Domain.Validations;
using FluentAssertions;

namespace Tests.Entities.OrderTests
{
    public class OrderTests
    {
        [Fact]
        public void CreateNewOrder_Sucess()
        {
            //Arrange
            Order order = new Order(5);


            //Action
            order.AddOrderItem();

            //Assert
            order.OrderItems.FirstOrDefault().Quantity.Should().Be(0);
            order.OrderItems.FirstOrDefault().Price.Value.Should().Be(0);
        }

        [Fact]
        public void RemoveItemOrder_Sucess()
        {
            //Arrange
            int quantity = 5;
            decimal price = 33.0m;
            Order order = new Order(5);

            //Action
            order.AddOrderItem();

            var findedItem = order.OrderItems.FirstOrDefault();

            //Assert
            order.RemoveOrderItem(findedItem);

            order.OrderItems.Count.Should().Be(0);
        }

        [Fact]
        public void RemoveItemOrder_Error()
        {
            //Arrange
            int quantity = 5;

            Order order = new Order(5);

            //Action
            order.AddOrderItem();

            var findedItem = new OrderItem();

            Action act = () => order.RemoveOrderItem(findedItem);

            //Assert
            act.Should().Throw<ValidationDefaultException>();
        }
    }
}
