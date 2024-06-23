using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Client;
using Application.Service.Client.Interfaces;
using AutoMapper;
using Domain.ArchPatterns.UnitOfWork;
using Domain.DomainEvents.Client.Events;
using Domain.DomainEvents.Client.Handlers;
using Domain.DomainEvents.Dispatcher;
using Domain.DomainEvents.Interfaces;
using Domain.DomainEvents.Order.Handlers;
using Domain.DomainEvents.Order.Interfaces;
using Domain.Entities.Client;
using Domain.Events.Order.Events;
using ClientEntity = Domain.Entities.Client.Client;

namespace Application.Service.Client
{
    public class ClientServiceApplication : IClienteServiceApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISendEmail _sendEmail;

        public ClientServiceApplication(IUnitOfWork unitOfWork, IMapper mapper, ISendEmail sendEmail)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sendEmail = sendEmail;
        }

        public async Task CreateNewClientAsync(CreateNewClientDTO clientDTO)
        {
            ClientEntity clientEntity = _mapper.Map<ClientEntity>(clientDTO);

            await _unitOfWork.ClientRepository.CreateAsync(clientEntity);

            await _unitOfWork.CommitAsync();

            SendEvents(clientEntity);
        }

        public async Task<ReadClientDTO> ReadClientByIdAsync(int clientId)
        {
            ClientEntity client = await _unitOfWork.ClientRepository.ReadByIdAsync(clientId);
;
            return _mapper.Map<ReadClientDTO>(client);
        }

        public void SendEvents(ClientEntity client)
        {
            client.CreateClint();

            var completedCreatEventHandlers = new List<IEventHandler<CreateClientEvent>>()
            {
                new SendEmailCreateClientHandle(_sendEmail)
            };

            var CompletedCreatedClientEventDispatcher = new CompletedEventDispatcher<CreateClientEvent>(completedCreatEventHandlers);

            CompletedCreatedClientEventDispatcher.Dispatcher(client.CreateClientEvents);

            client.ClearEvents();
        }
    }
}
