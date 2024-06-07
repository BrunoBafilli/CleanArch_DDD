using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class ValidationStockException : Exception
    {
        public ValidationStockException(string message) : base(message)
        { }

        public static void IsLessThatCurrentStock(int removeQuantity, int stockQuantity)
        {
            if (removeQuantity < stockQuantity)
                throw new ValidationStockException($"The quantity: {removeQuantity} to be removed is greater than the stock quantity: {stockQuantity}.");
        }
    }
}
