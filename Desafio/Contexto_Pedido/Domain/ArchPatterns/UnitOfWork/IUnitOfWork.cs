using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArchPatterns.Repositories;

namespace Domain.ArchPatterns.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IClientRepository ClientRepository { get; }

        Task Commit();
    }
}
