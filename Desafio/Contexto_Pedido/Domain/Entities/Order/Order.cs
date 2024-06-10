using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Interfaces;
using Domain.Entities.Order.GOFPatterns;
using Domain.Validations;

namespace Domain.Entities.Order
{
    public sealed class Order : EntityDefault<int>, IAgregateRoot<int>
    {
        //Props
        public DateTime OrderDate { get; private set; }
        private List<OrderItem> _orderItems;

        //Relacionamento
        public int ClientId { get; private set; }

        //Construtores
        public Order(int clientId)
        {
            ClientId = clientId;
            OrderDate = DateTime.Now;
            _orderItems = new List<OrderItem>();
        }

        public IReadOnlyList<OrderItem> OrderItems => _orderItems;

        public OrderItem AddOrderItem(int quantity, decimal price)
        {
            OrderItem order = new OrderBuilder()
                .SetQuantity(quantity)
                .SetPrice(price)
                .Builder();

            _orderItems.Add(order);

            return order;
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            var findedItem = OrderItems.FirstOrDefault(x => x == orderItem);

            ValidationDefaultException.IsNullOrEmpty(findedItem, nameof(findedItem));

            _orderItems.Remove(orderItem);
        }
    }
}
