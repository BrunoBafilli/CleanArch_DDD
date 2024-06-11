using Domain.ArchPatterns.Repositories.IClientRepository;
using Domain.Entities.Client;
using Domain.Validations;
using Infrastructure.Database.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.ArchPatterns.Repositories
{
    public sealed class ClientRepository : IClientRepository
    {
        private readonly DataContext _datacontext;

        public ClientRepository(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task CreateAsync(Client client)
        {
            var findedClient = await _datacontext.Clients.FirstOrDefaultAsync(c => c.Email == client.Email);

            ValidationDefaultException.IsNotNullOrEmpty(findedClient, nameof(findedClient));

            _datacontext.Add(client);

            //await _datacontext.SaveChangesAsync();
        }

        public async Task<List<Client>> ReadAllAsync()
        {
            var findedClients = _datacontext.Clients.ToList();

            ValidationDefaultException.IsNullOrEmpty(findedClients, nameof(findedClients));

            return findedClients;
        }

        public async Task<Client> ReadByIdAsync(int clientId)
        {
            var findedClient = await _datacontext.Clients.FindAsync(clientId);

            ValidationDefaultException.IsNullOrEmpty(findedClient, nameof(findedClient));

            return findedClient;
        }

        public async Task UpdateAsync(Client client)
        {
            var findedClient = await _datacontext.Clients.FindAsync(client.Id);

            ValidationDefaultException.IsNullOrEmpty(findedClient, nameof(findedClient));

            var findedUserByEmail = await _datacontext.Clients.FirstOrDefaultAsync(x => x.Email == client.Email);

            ValidationDefaultException.IsNotNullOrEmpty(findedUserByEmail, nameof(findedUserByEmail));

            _datacontext.Entry(findedClient).CurrentValues.SetValues(client);

            //await _datacontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int clientId)
        {
            var findedClient = await _datacontext.Clients.FindAsync(clientId);

            ValidationDefaultException.IsNullOrEmpty(findedClient, nameof(findedClient));

            _datacontext.Clients.Remove(findedClient);

            //await _datacontext.SaveChangesAsync();
        }
    }
}
