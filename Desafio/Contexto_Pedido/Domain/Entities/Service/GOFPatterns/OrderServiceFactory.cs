using Domain.Entities.Order;
using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderEntity = Domain.Entities.Order.Order;

namespace Domain.Entities.Service.GOFPatterns
{
    public class OrderServiceFactory
    {
        public static OrderEntity createOrderService(int quantity, int clientId, Product product)
        {
            // Validação dos parâmetros de entrada
            ValidationDefaultException.NumberLessThanZero(quantity, "quantity");
            ValidationDefaultException.NumberLessThanZero(clientId, "clientId");
            ValidationDefaultException.IsNullOrEmpty(product, "product");

            // Criação da entidade de pedido com o ID do cliente
            OrderEntity order = new OrderEntity(clientId);

            // Adição de itens ao pedido
            order.AddOrderItem(product.Price.Value, quantity);

            // Recuperação do primeiro item do pedido
            OrderItem orderItem = order.OrderItems.FirstOrDefault();
            if (orderItem != null)
            {
                orderItem.AddProduct(product.Name, product.Description, product.Price.Value, product.Stock.Quantity, quantity);
            }
            else
            {
                throw new InvalidOperationException("Falha ao adicionar item ao pedido.");
            }

            return order;
        }
    }
}
