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

    public class OrderItemTest
    {
        [Fact]
        public void ChangeOrderItem_Sucess()
        {
            //Arrange
            OrderItem orderItem;
            decimal newPrice = 60.6m;

            //Action
            orderItem = new OrderItem(5, new Price(50.0m));
            orderItem.ChangePrice(newPrice);

            //Assert
            orderItem.Price.Value.Should().Be(newPrice);
        }


        [Fact]
        public void ChangeOrderItem_Error()
        {
            //Arrange
            OrderItem orderItem;
            decimal newPrice = -5;

            //Action
            orderItem = new OrderItem(5, new Price(50.0m));

            Action act = () => orderItem.ChangePrice(newPrice);

            //Assert
            act.Should().Throw<ValidationDefaultException>().WithMessage("*Less than 0*");
        }

        [Fact]
        public void AddProduct_Sucess()
        {
            //Arrange

            OrderItem orderItem;
            string name = "bola";
            string description = "meu produto";
            decimal price = 5.50m;
            int stock = 7;

            //Action
            orderItem = new OrderItem(5, new Price(50.0m));

            orderItem.AddProduct(name, description, price, stock);

            var findedItem = orderItem.Products.FirstOrDefault();

            //Assert
            findedItem.Name.Should().Be(name);
            findedItem.Description.Should().Be(description);
            findedItem.Price.Value.Should().Be(price);
            findedItem.Stock.Quantity.Should().Be(stock);
        }
    }
}
