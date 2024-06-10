using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;

namespace Domain.ArchPatterns.Repositories
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
        Task<Order> ReadOrderByIdAndClientIdAsync(int orderId, int clientId);
        Task<ICollection<Order>> ReadOrdersByClientIdAsync(int clientId);
        Task<Order> ReadOrdersByClientIdAndOrderItemIdAsync(int clientId, int orderItemId);
        Task UpdateAsync (Order order);
    }
}
