using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Validations;

namespace Domain.Entities.Order.ValueObject
{
    public sealed record Stock
    {
        public int Quantity { get; set; }

        public Stock(int quantity)
        {
            ValidationDefaultException.IsNullOrEmpty(quantity, nameof(quantity));
            Quantity = quantity;
        }

        public void RemoveItem(int removeQuantity)
        {
            ValidationStockException.IsLessThatCurrentStock(removeQuantity, Quantity);
            Quantity -= removeQuantity;
        }

        public void AddItem(int AddQuantity)
        {
            Quantity += AddQuantity;
        }
    }
}
