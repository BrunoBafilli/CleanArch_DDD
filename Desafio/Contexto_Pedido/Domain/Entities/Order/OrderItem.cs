using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.Entities.Interfaces;
using Domain.Entities.Order.GOFPatterns;
using Domain.Entities.Order.ValueObject;
using Domain.Validations;

namespace Domain.Entities.Order
{
    public sealed class OrderItem : EntityDefault<int>, IAgregateRoot<int>
    {
        //Propriedades
        public int Quantity { get; private set; }
        public Price Price { get; private set; }

        private List<OrderItemProduct> _orderItemProducts;
        public IReadOnlyList<OrderItemProduct> OrderItemProducts => _orderItemProducts;

        //Relacionamento
        public Order Order { get; private set; }
        public int OrderId { get; set; }

        //Construtores
        public OrderItem() //EF
        {
            Quantity = 0;
            Price = new Price(0);
            _orderItemProducts = new List<OrderItemProduct>();
        }

        public void AddProduct(string name, string description, decimal price, int productId)
        {
            OrderItemProduct orderItemProduct = OrderItemProductFactory.OrderItemProductCreate(name, description, price, productId);

            _orderItemProducts.Add(orderItemProduct);

            AddPrice(price);
            Quantity++;
        }

        public void AddPrice(decimal newPrice)
        {
            ValidationDefaultException.NumberLessThanZero(newPrice, nameof(newPrice));

            Price = new Price(Price.Value += newPrice);
        }
    }
}
