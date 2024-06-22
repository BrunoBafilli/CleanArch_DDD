using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEvents.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : class
    {
        void Handler(TEvent domainEvent);
    }
}
