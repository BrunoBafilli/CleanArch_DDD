using Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ArchPatterns.Repositories.OrderRepository
{
    public interface IReadOrderRepository
    {
        Task<Order> ReadOrderByIdAndClientIdAsync(int orderId, int clientId);
        Task<ICollection<Order>> ReadOrdersByClientIdAsync(int clientId);
        Task<Order> ReadOrdersByClientIdAndOrderItemIdAsync(int clientId, int orderItemId);
    }
}
