using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArchPatterns.Repositories;
using Domain.ArchPatterns.UnitOfWork;
using Domain.Entities.Client;
using Domain.Entities.Order;
using Domain.Entities.Order.ValueObject;
using Domain.Validations;

namespace Domain
{
    public class OrderFactory
    {
        public static Order FactoryOrderAsync(int clientId, OrderItem orderItem, Product product)
        {
            Order order = new Order(clientId);

            OrderItem newOrderItem = order.AddOrderItem(orderItem.Quantity, orderItem.Price.Value);

            newOrderItem.AddProduct(product.Name, product.Description, product.Price.Value, product.Stock.Quantity);

            return order;
        }
    }
}
