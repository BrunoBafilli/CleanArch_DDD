using Application.DTOs.Client;

namespace Application.Service.Client.Interfaces
{
    public interface IClienteServiceApplication
    {
        public Task CreateNewClientAsync(CreateNewClientDTO clientDTO);
        public Task<ReadClientDTO> ReadClientByIdAsync(int clientId);
    }
}
