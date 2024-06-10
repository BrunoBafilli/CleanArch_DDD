using Domain.ArchPatterns.Repositories;
using Domain.ArchPatterns.UnitOfWork;
using Infrastructure.Database.ArchPatterns.Repositories;
using Infrastructure.Database.EntityFramework;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _dataContext;

    private IClientRepository _clientRepository;
    private IOrderRepository _orderRepository;
    private IProductRepository _productRepository;

    public IClientRepository ClientRepository => _clientRepository ??= new ClientRepository(_dataContext);

    public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(_dataContext);

    public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_dataContext);

    public UnitOfWork(DataContext dataContext) => _dataContext = dataContext;

    public async Task CommitAsync() => await _dataContext.SaveChangesAsync();
}