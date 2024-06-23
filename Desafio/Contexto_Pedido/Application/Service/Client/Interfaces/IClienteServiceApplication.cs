using Application.DTOs.Client;

namespace Application.Service.Client.Interfaces
{
    public interface IClienteServiceApplication
    {
        public Task CreateNewUser(CreateNewClientDTO clientDTO);
    }
}
