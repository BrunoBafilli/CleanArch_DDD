using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Interfaces;
using Domain.Entities.Order;
using Domain.Entities.Order.ValueObject;
using Domain.Validations;

namespace Domain.Entities.Product
{
    public sealed class Product : EntityDefault<int>, IAgregateRoot<int>
    {
        //Propriedades
        public string Name { get; private set; }
        public string Description { get; set; }
        public Price Price { get; private set; }
        public Stock Stock { get; private set; }

        //Construtores
        public Product() { } //EF

        public Product(string name, string description, Price price, Stock stock)
        {
            ValidationDefaultException.IsNullOrEmpty(name, nameof(name));
            ValidationDefaultException.IsNullOrEmpty(description, nameof(description));

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
        }

        public void ChangeName(string newName)
        {
            ValidationDefaultException.IsNullOrEmpty(newName, nameof(newName));
            Name = newName;
        }

        public void ChangeDescription(string newDescription)
        {
            ValidationDefaultException.IsNullOrEmpty(newDescription, nameof(newDescription));
            Description = newDescription;
        }

        public void ChangePrice(decimal newPrice)
        {
            ValidationDefaultException.NumberLessThanZero(newPrice, nameof(newPrice));
            Price = new Price(newPrice);
        }

        public void ChangeStock(int newStock)
        {
            ValidationDefaultException.NumberLessThanZero(newStock, nameof(newStock));
            Stock = new Stock(newStock);
        }
    }
}
