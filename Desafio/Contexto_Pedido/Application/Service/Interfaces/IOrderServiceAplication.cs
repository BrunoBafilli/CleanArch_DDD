using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface IOrderServiceAplication
    {
        Task CreateNewOrder(int clientId, List<int> productsId);
    }
}