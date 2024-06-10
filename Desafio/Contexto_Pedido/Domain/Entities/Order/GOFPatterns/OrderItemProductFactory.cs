using Domain.Entities.Order.ValueObject;
using Domain.Entities.Product;
using System.Diagnostics;
using System.Xml.Linq;

namespace Domain.Entities.Order.GOFPatterns
{
    public class OrderItemProductFactory
    {
        public static OrderItemProduct OrderItemProductCreate(string name, string description, decimal price, int productId)
        {
            var newPrice = new Price(price);

            return new OrderItemProduct(name, description, newPrice, productId);
        }
    }
}