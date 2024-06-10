using Domain.ArchPatterns.Repositories;
using Domain.Validations;
using Infrastructure.Database.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure.Database.ArchPatterns.Repositories.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(Domain.Entities.Order.Order order)
        {
           await _dataContext.Orders.AddAsync(order);
        }

        public Task<List<Domain.Entities.Order.Order>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Order.Order> ReadByIdAsync(int dataId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Domain.Entities.Order.Order order)
        {
            var findedOrder = await _dataContext.Orders.FindAsync(order.Id);

            ValidationDefaultException.IsNullOrEmpty(findedOrder, nameof(findedOrder));

            _dataContext.Entry(findedOrder).CurrentValues.SetValues(order);
        }

        public Task DeleteAsync(int dataId)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entities.Order.Order> ReadOrdersByUserId(int clientId, int orderId)
        {
            var findedOrder = await _dataContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Products)
                .FirstOrDefaultAsync(o => o.Id == orderId && o.ClientId == clientId);

            ValidationDefaultException.IsNullOrEmpty(findedOrder, nameof(findedOrder));

            return findedOrder;
        }
    }
}
