using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;
using Domain.Entities.Order.ValueObject;
using Domain.Validations;
using FluentAssertions;

namespace Tests.Entities.OrderTests
{
    public class ProductTests
    {
        [Fact]
        public void CreateProduct_Sucess()
        {

            //Arrange
            Price price = new Price(55.0m);
            Stock stock = new Stock(3);
            Product product;

            //Action
            product = new Product("prod1", "desct", price, stock);

            //Assert
            product.Name.Should().Be("prod1");
            product.Description.Should().Be("desct");
            product.Price.Should().Be(price);
            product.Stock.Should().Be(stock);
        }

        [Fact]
        public void CreateProduct_Error()
        {

            //Arrange
            Price price = new Price(5);
            Stock stock = new Stock(3);

            //Action
            Action act = () => new Product("", "desct", price, stock);

            //Assert
            act.Should().Throw<ValidationDefaultException>();
        }
    }
}