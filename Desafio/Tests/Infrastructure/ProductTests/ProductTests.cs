using Domain.ArchPatterns.Repositories;
using Domain.ArchPatterns.UnitOfWork;
using Domain.Entities.Client;
using Infrastructure.IOC.ContainerDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order.ValueObject;
using Domain.Entities.Product;

namespace Tests.Infrastructure.ProductTests
{
    public class ProductTests
    {
        private IUnitOfWork _unitOfWork;

        public ProductTests()
        {
            _unitOfWork = DI.GetService<IUnitOfWork>();
        }


        [Fact]
        public async void CreateNewProduct_Sucess()
        {
            //Arrange
            string name = "tomate";
            string description = $"meu produto";
            Price price = new Price(50.50m);
            Stock stock = new Stock(6);

            Product product = new Product(name, description, price, stock);

            await _unitOfWork.ProductRepository.CreateAsync(product);

            //Action - Assert
            await _unitOfWork.CommitAsync();
        }

    }
}
