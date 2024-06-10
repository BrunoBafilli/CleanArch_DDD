using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;

namespace Domain
{
    public interface ICreateOrderService
    {
        Task CreateOrder(int clintId, OrderItem orderItem, Product product);
        Task UpdateOrder(int clintId, Order orderItem);
    }
}
