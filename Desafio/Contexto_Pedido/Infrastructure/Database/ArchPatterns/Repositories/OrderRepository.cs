using Domain.Validations;
using Infrastructure.Database.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities.Order;
using OrderEntity = Domain.Entities.Order.Order;
using Domain.ArchPatterns.Repositories.OrderRepository;

namespace Infrastructure.Database.ArchPatterns.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(OrderEntity order)
        {
            //throw new Exception("" + order.OrderItems.FirstOrDefault().OrderItemProducts.Count + "fafafafe");
            await _dataContext.Orders.AddAsync(order);
        }

        public async Task<OrderEntity> ReadOrderByIdAndClientIdAsync(int orderId, int clientId)
        {
            var findedOrder = await _dataContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.OrderItemProducts)
                .FirstOrDefaultAsync(o => o.Id == orderId && o.ClientId == clientId);

            ValidationDefaultException.IsNullOrEmpty(findedOrder, nameof(findedOrder));

            return findedOrder;
        }

        public async Task<ICollection<OrderEntity>> ReadOrdersByClientIdAsync(int clientId)
        {
            var findedOrders = await _dataContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.OrderItemProducts)
                .Where(o => o.ClientId == clientId).ToListAsync();

            ValidationDefaultException.IsNullOrEmpty(findedOrders, nameof(findedOrders));

            return findedOrders;
        }

        public async Task<OrderEntity> ReadOrdersByClientIdAndOrderItemIdAsync(int clientId, int orderItemId)
        {
            var findedOrder = await _dataContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.OrderItemProducts)
                .Where(o => o.ClientId == clientId && o.Id == orderItemId).FirstOrDefaultAsync();

            ValidationDefaultException.IsNullOrEmpty(findedOrder, nameof(findedOrder));

            return findedOrder;
        }

        public async Task UpdateAsync(OrderEntity order)
        {
            var findedOrder = await _dataContext.Orders.FindAsync(order.Id);

            ValidationDefaultException.IsNullOrEmpty(findedOrder, nameof(findedOrder));

            _dataContext.Entry(findedOrder).CurrentValues.SetValues(order);
        }
    }
}
