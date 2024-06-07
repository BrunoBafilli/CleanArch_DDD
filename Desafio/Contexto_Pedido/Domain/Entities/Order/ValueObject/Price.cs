using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Validations;

namespace Domain.Entities.Order.ValueObject
{
    public sealed record Price
    {
        public decimal Value { get; set; }

        public Price(decimal value)
        {
            ValidationDefaultException.NumberLessThanZero(value, nameof(value));
            Value = value;
        }
    }
}
