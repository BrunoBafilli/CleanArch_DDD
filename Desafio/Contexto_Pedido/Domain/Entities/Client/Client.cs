using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainEvents.Client.Events;
using Domain.Entities.Client.ValueObjects;
using Domain.Entities.Interfaces;
using Domain.Validations;

namespace Domain.Entities.Client
{
    public class Client : EntityDefault<int>, IAgregateRoot<int>
    {
        //Events
        public ICollection<CreateClientEvent> CreateClientEvents => _createClientEvents.AsReadOnly();
        private List<CreateClientEvent> _createClientEvents = new List<CreateClientEvent>();

        //Propriedades
        public string Name { get; private set; }
        public string Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

        //Relacionamento
        private List<int> _ordersIDs;

        public IReadOnlyList<int> OrdersIds => _ordersIDs;

        public Client() { }//EF

        public Client(string name, string email, string phoneNumber)
        {
            ValidationDefaultException.IsNullOrEmpty(name, nameof(name));
            ValidationDefaultException.IsEmail(email, nameof(email));

            Name = name;
            Email = email;
            OccuredOn = DateTime.Now;
            PhoneNumber = new PhoneNumber(phoneNumber);
            _ordersIDs = new List<int>();//No mapping

        }

        public void CreateClint()
        {
            CreateClientEvent createClientEvent = new CreateClientEvent(Id, Email, OccuredOn);
            CreateClientOn(createClientEvent);
        }

        private void CreateClientOn(CreateClientEvent createClientEvent)
        {
            _createClientEvents.Add(createClientEvent);
        }

        public void ClearEvents()
        {
            _createClientEvents.Clear();
        }

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
    }
}