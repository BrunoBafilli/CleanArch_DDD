using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainEvents.Client.Events;
using Domain.DomainEvents.Interfaces;
using Domain.DomainEvents.Order.Interfaces;

namespace Domain.DomainEvents.Client.Handlers
{
    public class SendEmailCreateClientHandle : IEventHandler<CreateClientEvent>
    {
        private readonly ISendEmail _sendEmail;

        public SendEmailCreateClientHandle(ISendEmail sendEmail)
        {
            _sendEmail = sendEmail;
        }

        public void Handler(CreateClientEvent domainEvent)
        {
            Console.WriteLine($"ClientID: {domainEvent.Id} Sended: {domainEvent.OcurredOn}");
            //_sendEmail.Send(domainEvent);
        }
    }
}
