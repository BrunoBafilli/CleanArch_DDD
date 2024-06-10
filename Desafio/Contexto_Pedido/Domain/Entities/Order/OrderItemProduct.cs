using Domain.Entities.Order.ValueObject;
using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Order
{
    public sealed class OrderItemProduct
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; set; }
        public Price Price { get; private set; }

        //Relacionamento
        public int ProductId { get; private set; }

        public OrderItem OrderItem { get; private set; }
        public int OrderItemId { get; set; }

        //Construtores
        public OrderItemProduct() { } //EF

        public OrderItemProduct(string name, string description, Price price, int productId)
        {
            ValidationDefaultException.IsNullOrEmpty(name, nameof(name));
            ValidationDefaultException.IsNullOrEmpty(description, nameof(description));

            Name = name;
            Description = description;
            Price = price;
            ProductId = productId;
        }
    }
}
