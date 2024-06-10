using Domain.ArchPatterns.Repositories;
using Domain.ArchPatterns.UnitOfWork;
using Infrastructure.Database.ArchPatterns.Repositories;
using Infrastructure.Database.ArchPatterns.Repositories.Order;
using Infrastructure.Database.EntityFramework;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _dataContext;

    private IClientRepository _clientRepository;
    private IOrderRepository _orderRepository;

    public IClientRepository ClientRepository
    {
        get
        {
            return _clientRepository ??= new ClientRepository(_dataContext);
        }
    }

    public IOrderRepository OrderRepository
    {
        get
        {
            return _orderRepository ??= new OrderRepository(_dataContext);
        }
    }

    public UnitOfWork(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task CommitAsync()
    {
        await _dataContext.SaveChangesAsync();
    }
}