using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class ValidationPhoneNumberException : Exception
    {
        public ValidationPhoneNumberException(string message) : base(message)
        { }

        public static void IsPhoneNumber(string propValue, string propName)
        {
            string pattern = @"^(?:(?:\+?55\s?)?(?:\(?\d{2}\)?\s?)?(?:9\d{4}|\d{4})-?\d{4})$";

            ValidationDefaultException.IsNullOrEmpty(propValue, propName);

            if (propValue is string value && !Regex.IsMatch(value, pattern))
                throw new ValidationPhoneNumberException($"{propName} is not a valid phone number");

        }
    }
}
