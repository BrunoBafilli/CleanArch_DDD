using Domain.Events.Order.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events.Interfaces;

namespace Domain.DomainEvents.Interfaces
{
    public interface IEventDespatcher
    {
        public void Dispatcher(IEnumerable<IEventDomain> events);
    }
}
