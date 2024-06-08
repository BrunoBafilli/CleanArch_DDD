using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Client.ValueObjects;
using Domain.Entities.Interfaces;
using Domain.Validations;

namespace Domain.Entities.Client
{
    public class Client : EntityDefault<int>, IAgregateRoot<int>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

        //Relacionamento
        private List<int> _ordersIDs;

        public Client() { }//EF

        public Client(string name, string email, string phoneNumber)
        {
            ValidationDefaultException.IsNullOrEmpty(name, nameof(name));
            ValidationDefaultException.IsEmail(email, nameof(email));
            ValidationPhoneNumberException.IsPhoneNumber(phoneNumber, nameof(phoneNumber));

            Name = name;
            Email = email;
            PhoneNumber = new PhoneNumber(phoneNumber);
            _ordersIDs = new List<int>();//No mapping
        }

        public IReadOnlyList<int> OrdersIds => _ordersIDs;

        public void ChangeName(string nome)
        {
            Name = nome;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            PhoneNumber = new PhoneNumber(phoneNumber);
        }

        public void CreateOrder(int orderId)
        {
            ValidationDefaultException.NumberLessThanZero(orderId, nameof(orderId));
            _ordersIDs.Add(orderId);
        }
    }
}