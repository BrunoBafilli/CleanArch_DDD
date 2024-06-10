using Domain.ArchPatterns.UnitOfWork;
using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;
using OrderEntity = Domain.Entities.Order.Order;
using ProductEntity = Domain.Entities.Product.Product;
using Domain.Entities.Product;

namespace Domain.Entities.Service.GOFPatterns
{
    public class OrderServiceOneItemFactory
    {
        public async static Task<OrderEntity> createOrderService(int clientId, List<int> productsIds, IUnitOfWork _unitOfWork)
        {
            await _unitOfWork.ClientRepository.ReadByIdAsync(clientId);

            ValidationDefaultException.NumberLessThanZero(clientId, nameof(clientId));
            ValidationDefaultException.IsNullOrEmpty(productsIds, nameof(productsIds));

            OrderEntity order = new OrderEntity(clientId);

            order.AddOrderItem();

            OrderItem orderItem = order.OrderItems.First();

            foreach (var productId in productsIds)
            {
                ValidationDefaultException.NumberLessThanZero(productId, nameof(productId));

                ProductEntity findedProduct = await _unitOfWork.ProductRepository.ReadByIdAsync(productId);

                ValidationDefaultException.IsNullOrEmpty(findedProduct, nameof(findedProduct));

                orderItem.AddProduct(findedProduct.Name, findedProduct.Description, findedProduct.Price.Value, productId);
            }

            return order;
        }
    }
}
