using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events.Interfaces;

namespace Domain.Events.Order.Events
{
    public class CompletedOrderEvent : EventArgs, IEventDomain
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime OcurredOn { get; set; }

        public CompletedOrderEvent(int id, string email)
        {
            Id = id;
            Email = email;
            OcurredOn = DateTime.Now;
        }
    }
}