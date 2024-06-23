using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events.Interfaces;

namespace Domain.DomainEvents.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : IEventDomain
    {
        void Handler(TEvent domainEvent);
    }
}
