﻿using Domain.Entities.Client;
using Domain.Validations;
using FluentAssertions;
using Infrastructure.IOC.ContainerDI;
using Domain.ArchPatterns.Repositories;
using Domain.ArchPatterns.UnitOfWork;
using Domain.Entities.Client.ValueObjects;

namespace Tests.Infrastructure.ClientTests
{
    public class ClientTest
    {
        private IClientRepository _clientService;
        private IUnitOfWork _unitOfWork;

        public ClientTest()
        {
            _clientService = DI.GetService<IClientRepository>();
            _unitOfWork = DI.GetService<IUnitOfWork>();
        }

        [Fact]
        public async void CreateNewClient_Sucess()
        {
            Guid clientId = Guid.NewGuid();
            //Arrange
            string name = "bruno";
            string email = $"{clientId}@gmail.com";
            string phoneNumber = "1234567890";
            Client client = new Client(name, email, phoneNumber);

            //Action - Assert
            await _clientService.Create(client);
            await _unitOfWork.Commit();
        }

        [Fact]
        public async void ReadAllClients_Sucess()
        {
            //Action
            var clients = await _clientService.ReadAll();

            //Assert
            clients.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async void ReadClient_Sucess()
        {
            //Action
            var client = await _clientService.ReadById(4);

            //Assert
            client.Should().NotBeNull();
        }

        [Fact]
        public async void UpdateClient_Sucess()
        {
            //Arrage
            int clientId = 4;
            string newName = "testeee";
            string newEmail = "brunobafilli@gmail.com";
            string newPhoneNumber = "1234567890";

            var client = await _clientService.ReadById(clientId);

            //Action
            client.ChangeName(newName);
            client.ChangeEmail(newEmail);
            client.ChangePhoneNumber(newPhoneNumber);

            await _clientService.Update(client);

            await _unitOfWork.Commit();

            //Assert
            var newClient = await _clientService.ReadById(clientId);

            newClient.Name.Should().Be(newName);
        }

        [Fact]
        public async void DeleteClient_sucess()
        {
            Guid clientId = Guid.NewGuid();

            //Arrange
            string name = "bruno";
            string email = $"{clientId}@gmail.com";
            string phoneNumber = "1234567890";
            Client client = new Client(name, email, phoneNumber);

            //Action
            await _clientService.Create(client);

            await _unitOfWork.Commit();

            await _clientService.Delete(client.Id);

            await _unitOfWork.Commit();

            Func<Task> act = async () => await _clientService.ReadById(client.Id);

            //Assert
            await act.Should().ThrowAsync<ValidationDefaultException>();
        }
    }
}
