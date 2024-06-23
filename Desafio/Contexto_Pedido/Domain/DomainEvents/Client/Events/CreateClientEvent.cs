using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events.Interfaces;

namespace Domain.DomainEvents.Client.Events
{
    public class CreateClientEvent : IEventDomain
    {
        public int Id { get; set; }
        public DateTime OcurredOn { get; set; }
        public string Email { get; set; }

        public CreateClientEvent(int id, string email, DateTime ocurredOn)
        {
            Id = id;
            Email = email;
            ocurredOn = OcurredOn;
        }
    }
}
