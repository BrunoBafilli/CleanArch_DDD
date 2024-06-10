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
        Task CreateNewOrder(int quantity, int clientId, Product product);
    }
}
