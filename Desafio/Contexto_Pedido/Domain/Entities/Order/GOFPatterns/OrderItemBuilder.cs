using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;
using Domain.Entities.Order.ValueObject;

namespace Domain.Entities.Order.GOFPatterns
{
    public class OrderBuilder
    {
        private int _quantity;
        private decimal _price;

        public OrderBuilder SetQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public OrderBuilder SetPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public OrderItem Builder()
        {
            return new OrderItem();
        }
    }
}
