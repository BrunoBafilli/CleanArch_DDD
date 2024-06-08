using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class ValidationDefaultException : Exception
    {
        public ValidationDefaultException(string message) : base(message)
        { }

        public static void IsNullOrEmpty<T>(T propValue, string propName)
        {
            if (propValue == null || propValue is string && string.IsNullOrEmpty(propValue.ToString()))
                throw new ValidationDefaultException($"Prop: {propName} is null or empty");
        }

        public static void NumberLessThanZero<T>(T propValue, string propName)
        {
            IsNullOrEmpty(propValue, propName);

            if (Convert.ToInt32(propValue) < 0)
                throw new ValidationDefaultException($"Prop: {propName} Less than 0");
        }

        public static void IsEmail(string propValue, string propName)
        {
            IsNullOrEmpty(propValue, propName);

            string email = propValue;
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                throw new ValidationDefaultException($"Prop: {propName} is not a valid email address");
            }
        }
    }
}
