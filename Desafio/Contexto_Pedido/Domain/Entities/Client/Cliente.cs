using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Interfaces;
using Domain.Validations;

namespace Domain.Entities.Client
{
    public class Cliente : EntityDefault<int>, IAgregateRoot<int>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public Cliente(string name, string email, string phoneNumber)
        {
            ValidationDefaultException.IsNullOrEmpty(name, nameof(name));
            ValidationDefaultException.IsEmail(email, nameof(email));
            ValidationDefaultException.IsNullOrEmpty(phoneNumber, nameof(phoneNumber));
            
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void ChangeName(string nome){
            ValidationDefaultException.IsNullOrEmpty(nome, nameof(nome));
            Name = nome;
        }

        public void ChangeEmail(string email){
            ValidationDefaultException.IsEmail(email, nameof(email));
            Email = email;
        }

        public void ChangePhoneNumber(string phoneNumber){
            ValidationDefaultException.IsNullOrEmpty(phoneNumber, nameof(phoneNumber));
            PhoneNumber = phoneNumber;
        }
    }
}
