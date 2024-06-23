using Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Order.Interfaces
{
    public interface IOrderServiceAplication
    {
        Task CreateNewOrderAsync(CreteNewOrderDTO orderDTO);
        Task<ReadOrderDTO> ReadOrderByorderIdClientIdAsync(int orderId, int clientId);
        Task<List<ReadOrderDTO>> ReadOrdersByClientIdAsync(int clientId);
    }
}