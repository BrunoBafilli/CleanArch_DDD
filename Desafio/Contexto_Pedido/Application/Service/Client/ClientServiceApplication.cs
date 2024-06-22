using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Service.Client.Interfaces;
using AutoMapper;
using Domain.ArchPatterns.UnitOfWork;
using Domain.DomainEvents.Interfaces;
using Domain.DomainEvents.Order.Dispatcher;
using Domain.DomainEvents.Order.Handlers;
using Domain.DomainEvents.Order.Interfaces;
using Domain.Events.Order.Events;
using ClientEntity = Domain.Entities.Client.Client;

namespace Application.Service.Client
{
    public class ClientServiceApplication : IClienteServiceApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientServiceApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateNewUser(ClientDTO clientDTO)
        {
            ClientEntity clientEntity = _mapper.Map<ClientEntity>(clientDTO);

            await _unitOfWork.ClientRepository.CreateAsync(clientEntity);

            await _unitOfWork.CommitAsync();

            SendEvents(clientEntity);
        }

        public void SendEvents(ClientEntity clientEntity)
        {
            //clientEntity.PlaceOrder();

            //var completedOrderEventHandlers = new List<IEventHandler<CompletedOrderEvent>>()
            //{
            //    new SendEmailCompletedOrderHandle(_sendEmail)
            //};

            //var completedOrderEventDispatcher = new CompletedOrderEventDispatcher(completedOrderEventHandlers);

            //completedOrderEventDispatcher.Dispatcher(order.CompletedOrderEvents);

            //order.ClearEvents();
        }
    }
}
