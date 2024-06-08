using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.Entities.Client.GOFPatterns;
using Domain.Entities.Interfaces;
using Domain.Entities.Order.ValueObject;
using Domain.Validations;

namespace Domain.Entities.Order
{
    public sealed class OrderItem : EntityDefault<int>, IAgregateRoot<int>
    {
        //Propriedades
        public int Quantity { get; private set; }
        public Price Price { get; private set; }

        private List<Product> _products;
        public IReadOnlyList<Product> Products => _products;

        //Relacionamento
        public Order Order { get; private set; }
        public int OrderId { get; set; }

        //Construtores
        public OrderItem() { } //EF

        public OrderItem(int quantity, Price price = null)
        {
            ValidationDefaultException.NumberLessThanZero(quantity, nameof(quantity));
            Price = price;
            Quantity = quantity;
            _products = new List<Product>();
        }

        public void AddProduct(string name, string description, decimal price, int stock)
        {
            Product product = new ProductBuilder()
                .SetName(name)
                .SetDescription(description)
                .SetPrice(price)
                .SetStock(stock)
                .Build();

            _products.Add(product);

            ChangePrice(Price.Value + price);
        }

        public void ChangePrice(decimal newPrice)
        {
            ValidationDefaultException.NumberLessThanZero(newPrice, nameof(newPrice));

            Price = new Price(newPrice);
        }
    }
}
