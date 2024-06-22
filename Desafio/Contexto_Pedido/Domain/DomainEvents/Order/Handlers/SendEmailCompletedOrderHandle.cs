using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainEvents.Interfaces;
using Domain.DomainEvents.Order.Interfaces;
using Domain.Events.Order.Events;

namespace Domain.DomainEvents.Order.Handlers
{
    public class SendEmailCompletedOrderHandle : IEventHandler<CompletedOrderEvent>
    {
        private readonly ISendEmail _sendEmail;

        public SendEmailCompletedOrderHandle(ISendEmail sendEmail)
        {
            _sendEmail = sendEmail;
        }

        public void Handler(CompletedOrderEvent Tevent)
        {
            _sendEmail.Send("teste", "teste", "teste"+Tevent.Id);
            Console.WriteLine($"ID: {Tevent.Id} - ON:{Tevent.OcurredOn}");
        }
    }
}
