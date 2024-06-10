﻿using System;
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
            int quantity = 5;
            decimal price = 50.0m;
            Order order = new Order(5);

            decimal resultPrice = quantity * price;

            //Action
            order.AddOrderItem(price, quantity);

            //Assert
            order.OrderItems.FirstOrDefault().Quantity.Should().Be(quantity);
            order.OrderItems.FirstOrDefault().Price.Value.Should().Be(resultPrice);
        }

        [Fact]
        public void CreateNewOrder_Error()
        {
            //Arrange
            int quantity = -5;
            decimal price = 33.0m;
            Order order = new Order(5);

            //Action
            Action act = () => order.AddOrderItem(price, quantity);

            //Assert
            act.Should().Throw<ValidationDefaultException>().WithMessage("*Less than 0*");
        }

        [Fact]
        public void RemoveItemOrder_Sucess()
        {
            //Arrange
            int quantity = 5;
            decimal price = 33.0m;
            Order order = new Order(5);

            //Action
            order.AddOrderItem(price, quantity);

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
            Price price = new Price(5.50m);

            //Action
            order.AddOrderItem(price.Value, quantity);

            var findedItem = new OrderItem(quantity, price.Value);

            Action act = () => order.RemoveOrderItem(findedItem);

            //Assert
            act.Should().Throw<ValidationDefaultException>();
        }
    }
}
