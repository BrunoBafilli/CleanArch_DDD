using Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Order
{
    public class CreteNewOrderDTO
    {
        //Props
        public List<int> ProductsId { get; set; }

        //Relacionamento
        public int ClientId { get; set; }

        public string ClientEmail { get; set; }
    }
}
