using Domain.Entities.Order.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;

namespace Domain.Entities.Client.GOFPatterns
{
    public class ProductBuilder
    {
        private string _name;
        private string _description;
        private Price _price;
        private Stock _stock;

        public ProductBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ProductBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public ProductBuilder SetPrice(decimal price)
        {
            _price = new Price(price);
            return this;
        }

        public ProductBuilder SetStock(int stock)
        {
            _stock = new Stock(stock);
            return this;
        }

        public void Build(List<Product> products)
        {
            products.Add(new Product(_name, _description, _price, _stock));
        }
    }
}
