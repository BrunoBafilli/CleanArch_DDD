using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainEvents.Interfaces;
using Domain.DomainEvents.Order.Handlers;
using Domain.Events.Interfaces;
using Domain.Events.Order.Events;

namespace Domain.DomainEvents.Order.Dispatcher
{
    public class CompletedOrderEventDispatcher : IEventDespatcher
    {
        private readonly ICollection<IEventHandler<CompletedOrderEvent>> _completedEventHandlers;

        public CompletedOrderEventDispatcher(ICollection<IEventHandler<CompletedOrderEvent>> completedEventHandler)
        {
            _completedEventHandlers = completedEventHandler;
        }

        public void Dispatcher(IEnumerable<IEventDomain> events)
        {
            foreach (var domainEvent in events)
            {
                if (domainEvent is CompletedOrderEvent completedOrderEvent)
                {
                    foreach (var completedEventHandlers in _completedEventHandlers)
                    {
                        completedEventHandlers.Handler(completedOrderEvent);
                    }
                }
            }
        }
    }
}
