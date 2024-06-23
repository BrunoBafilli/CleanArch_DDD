using Domain.ArchPatterns.UnitOfWork;
using Domain.Entities.Client;
using Domain.Entities.Product;
using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;
using Application.DTOs.Order;

namespace Application.GOFPatterns
{
    public class CreateProductsByIdFactory
    {
        public static async Task<Order> CreateProducts(CreteNewOrderDTO orderDTO, IUnitOfWork unitOfWork)
        {
            Order order = new Order(orderDTO.ClientId);

            order.AddOrderItem();

            foreach (var productId in orderDTO.ProductsId)
            {
                var product = await unitOfWork.ProductRepository.ReadByIdAsync(productId);

                ValidationDefaultException.IsNullOrEmpty(product, nameof(product));

                order.OrderItems.First().AddProduct(product.Name, product.Description, product.Price.Value, product.Id);
            }

            return order;
        }
    }
}
