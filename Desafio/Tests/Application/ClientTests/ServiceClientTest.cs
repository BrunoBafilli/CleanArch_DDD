using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Client;
using Application.Service.Client.Interfaces;
using Domain.ArchPatterns.Repositories.IClientRepository;
using Domain.ArchPatterns.UnitOfWork;
using Domain.Entities.Client;
using Domain.Entities.Client.ValueObjects;
using Infrastructure.IOC.ContainerDI;
using Microsoft.Identity.Client;

namespace Tests.Application.ClientTests
{
    public class ServiceClientTest
    {

        private IClienteServiceApplication _clienteServiceApplication;

        public ServiceClientTest()
        {
            _clienteServiceApplication = DI.GetService<IClienteServiceApplication>();
        }

        [Fact]
        public async Task CreateNewUser_Sucess()
        {
            Guid clientId = Guid.NewGuid();

            string name = "bruno";
            string email = $"{clientId}@gmail.com";
            string phoneNumber = "1234567890";
            PhoneNumber newPhoneNumber = new PhoneNumber(phoneNumber);

            //Arrange
            CreateNewClientDTO clientDTO = new CreateNewClientDTO(){ Email = email, Name = name, PhoneNumber = newPhoneNumber};

            //Action
            await _clienteServiceApplication.CreateNewUser(clientDTO);

            //GetUser

        }
    }
}
