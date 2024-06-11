using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArchPatterns.Repositories.Domain.ArchPatterns.Repositories;

namespace Domain.ArchPatterns.Repositories.IProductRepository
{
    public interface IProductRepository : ICRUD_DEFAULT<Product>
    { }
}
