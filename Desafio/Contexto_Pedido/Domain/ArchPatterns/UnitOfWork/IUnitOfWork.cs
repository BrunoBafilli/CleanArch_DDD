using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArchPatterns.Repositories.IClientRepository;
using Domain.ArchPatterns.Repositories.IProductRepository;
using Domain.ArchPatterns.Repositories.OrderRepository;

namespace Domain.ArchPatterns.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IClientRepository ClientRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IProductRepository ProductRepository { get; }

        Task CommitAsync();
    }
}
