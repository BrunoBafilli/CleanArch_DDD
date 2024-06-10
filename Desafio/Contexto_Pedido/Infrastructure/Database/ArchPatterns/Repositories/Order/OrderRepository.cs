using Domain.ArchPatterns.Repositories;
using Domain.Entities.Client;
using Domain.Entities.Order;
using Domain.Validations;
using Infrastructure.Database.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.ArchPatterns.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(Order order)
        {
           await _dataContext.Orders.AddAsync(order);
        }

        public Task<List<Order>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> ReadByIdAsync(int dataId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Order order)
        {
            var findedOrder = await _dataContext.Orders.FindAsync(order.Id);

            ValidationDefaultException.IsNullOrEmpty(findedOrder, nameof(findedOrder));

            _dataContext.Entry(findedOrder).CurrentValues.SetValues(order);
        }

        public Task DeleteAsync(int dataId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> ReadOrdersByUserId(int clientId, int orderId)
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
