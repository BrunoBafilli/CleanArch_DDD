using Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderDTO
    {
        //Props
        public List<int> ProductsId { get; set; }

        //Relacionamento
        public int ClientId { get; set; }
    }
}
