using Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ArchPatterns.Repositories.OrderRepository
{
    public interface IUpdateOrderRepository
    {
        Task UpdateAsync(Order order);
    }
}
