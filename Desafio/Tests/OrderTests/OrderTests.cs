using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;
using Domain.Entities.Order.ValueObject;
using Domain.Validations;
using FluentAssertions;

namespace Tests.OrderTests
{
    public class OrderTests
    {
        [Fact]
        public void CreateNewOrder_Sucess()
        {
            //Arrange
            int quantity = 5;
            decimal price = 33.0m;
            Order order = new Order();

            //Action
            order.AddOrderItem(quantity, price);

            //Assert
            order.OrderItems.FirstOrDefault().Quantity.Should().Be(quantity);
            order.OrderItems.FirstOrDefault().Price.Value.Should().Be(price);
        }

        [Fact]
        public void CreateNewOrder_Error()
        {
            //Arrange
            int quantity = -5;
            decimal price = 33.0m;
            Order order = new Order();

            //Action
            Action act = () => order.AddOrderItem(quantity, price);

            //Assert
            act.Should().Throw<ValidationDefaultException>().WithMessage("*Less than 0*");
        }

        [Fact]
        public void RemoveItemOrder_Sucess()
        {
            //Arrange
            int quantity = 5;
            decimal price = 33.0m;
            Order order = new Order();

            //Action
            order.AddOrderItem(quantity, price);

            var findedItem = order.OrderItems.FirstOrDefault();

            //Assert
            order.OrderItems.FirstOrDefault().Quantity.Should().Be(quantity);
            order.OrderItems.FirstOrDefault().Price.Value.Should().Be(price);

            order.RemoveOrderItem(findedItem);

            order.OrderItems.Count.Should().Be(0);
        }

        [Fact]
        public void RemoveItemOrder_Error()
        {
            //Arrange
            int quantity = 5;

            Order order = new Order();
            Price price = new Price(5.50m);

            //Action
            order.AddOrderItem(quantity, 5.30m);

            var findedItem = new OrderItem(5, price);

            Action act = () => order.RemoveOrderItem(findedItem);

            //Assert
            act.Should().Throw<ValidationDefaultException>();
        }
    }
}
