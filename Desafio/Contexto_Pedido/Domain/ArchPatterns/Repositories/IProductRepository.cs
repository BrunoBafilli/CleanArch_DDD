using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ArchPatterns.Repositories
{
    public interface IProductRepository : ICRUD<Product>
    {

    }
}
