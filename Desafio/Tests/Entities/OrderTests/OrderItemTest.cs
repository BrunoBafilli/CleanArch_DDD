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

    public class OrderItemTest
    {
        [Fact]
        public void ChangeOrderItem_Sucess()
        {
            //Arrange
            OrderItem orderItem;
            decimal addPrice = 60.6m;

            //Action
            orderItem = new OrderItem();
            orderItem.AddPrice(addPrice);

            //Assert
            orderItem.Price.Value.Should().Be(addPrice);
        }


        [Fact]
        public void ChangeOrderItem_Error()
        {
            //Arrange
            OrderItem orderItem;
            decimal newPrice = -5;

            //Action
            orderItem = new OrderItem();

            Action act = () => orderItem.AddPrice(newPrice);

            //Assert
            act.Should().Throw<ValidationDefaultException>().WithMessage("*Less than 0*");
        }

        [Fact]
        public void AddProduct_Sucess()
        {
            //Arrange

            OrderItem orderItem;
            decimal price = 5.50m;
            int productId = 1;

            //Action
            orderItem = new OrderItem();

            //orderItem.AddProduct(productId, price);//5.50

            var findedItem = orderItem.OrderItemProducts.FirstOrDefault();

            //Assert
            //decimal resultPrice = orderItem.OrderItemProducts.Sum(product => product.Price.Value);

            //findedItem.Name.Should().Be(name);
            //findedItem.Description.Should().Be(description);
            //findedItem.Price.Value.Should().Be(price);
            //findedItem.Stock.Quantity.Should().Be(stock);

            //Order price
            //orderItem.Price.Value.Should().Be(resultPrice);
        }
    }
}
