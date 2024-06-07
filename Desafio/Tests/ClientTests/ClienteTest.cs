using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Client;
using FluentAssertions;

namespace Tests.ClientTests
{
    public class ClienteTest
    {
        [Fact]
        public void CreateClient_Sucess()
        {
            //Arrange
            Cliente cliente = new Cliente("bruno", "brunobafilli@gmail.com", "123123213");

            string newEmail = "brunobafilli1@gmail.com";
            string newName = "teste";
            string newPhoneNumber = "22222";

            //Action
            cliente.ChangeEmail(newEmail);
            cliente.ChangeName(newName);
            cliente.ChangePhoneNumber(newPhoneNumber);

            //Assert
            cliente.Email.Should().Be(newEmail);
            cliente.Name.Should().Be(newName);
            cliente.PhoneNumber.Should().Be(newPhoneNumber);
        }
    }
}
