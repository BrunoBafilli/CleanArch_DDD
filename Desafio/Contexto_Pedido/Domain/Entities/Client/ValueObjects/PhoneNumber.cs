using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Client.ValueObjects
{
    public sealed record PhoneNumber
    {
        public string Number { get; set; }

        public PhoneNumber(string number)
        {
            ValidationPhoneNumberException.IsPhoneNumber(number, nameof(number));
            Number = number;
        }
    }
}
