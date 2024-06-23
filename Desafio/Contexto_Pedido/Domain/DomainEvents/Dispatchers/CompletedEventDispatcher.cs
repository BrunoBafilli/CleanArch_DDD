using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainEvents.Interfaces;
using Domain.DomainEvents.Order.Handlers;
using Domain.Events.Interfaces;
using Domain.Events.Order.Events;

namespace Domain.DomainEvents.Dispatcher
{
    public class CompletedEventDispatcher<TEvent> : IEventDespatcher where TEvent : IEventDomain
    {
        private readonly ICollection<IEventHandler<TEvent>> _completedEventHandlers;

        public CompletedEventDispatcher(ICollection<IEventHandler<TEvent>> completedEventHandler)
        {
            _completedEventHandlers = completedEventHandler;
        }

        public void Dispatcher(IEnumerable<IEventDomain> events)
        {
            foreach (var domainEvent in events)
            {
                if (domainEvent is TEvent completedOrderEvent)
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
