using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Client;
using Domain.Validations;
using FluentAssertions;

namespace Tests.Entities.ClientTests
{
    public class ClientTest
    {
        [Fact]
        public void CreateClient_Sucess()
        {
            //Arrange
            Client client = new Client("bruno", "brunobafilli@gmail.com", "+55 (19) 98370-1756");

            string newEmail = "brunobafilli1@gmail.com";
            string newName = "teste";
            string newPhoneNumber = "+55 (19) 98370-1514";

            //Action
            client.ChangeEmail(newEmail);
            client.ChangeName(newName);
            client.ChangePhoneNumber(newPhoneNumber);

            //Assert
            client.Email.Should().Be(newEmail);
            client.Name.Should().Be(newName);
            client.PhoneNumber.Number.Should().Be(newPhoneNumber);
        }

        [Fact]
        public void CreateClient_Error()
        {
            //Arrange - Action
            Action act = () => new Client("bruno", "brunobafilli@gmail.com", "+55 (19) 98370-@1756");

            //Assert
            act.Should().Throw<ValidationPhoneNumberException>().WithMessage("*is not a valid phone number*");
        }
    }
}
