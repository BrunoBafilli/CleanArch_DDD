using Domain.ArchPatterns.Repositories;
using Domain.Entities.Order;
using Infrastructure.Database.EntityFramework;

namespace Infrastructure.Database.ArchPatterns.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task Create(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Order> ReadById(int dataId)
        {
            throw new NotImplementedException();
        }

        public Task Update(Order data)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int dataId)
        {
            throw new NotImplementedException();
        }
    }
}
