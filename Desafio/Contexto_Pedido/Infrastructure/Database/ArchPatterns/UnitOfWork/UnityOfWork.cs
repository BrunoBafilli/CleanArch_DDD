using Domain.ArchPatterns.Repositories;
using Domain.ArchPatterns.UnitOfWork;
using Infrastructure.Database.ArchPatterns.Repositories;
using Infrastructure.Database.EntityFramework;

namespace Infrastructure.Database.ArchPatterns.UnitOfWork
{
    public class UnityOfWork : IUnitOfWork
    {
        private DataContext _dataContext;
        private IClientRepository _clieteClientRepository;

        public IClientRepository ClientRepository
        {
            get
            {
                return _clieteClientRepository ?? new ClientRepository(_dataContext);
            }
        }

        public UnityOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Commit()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
