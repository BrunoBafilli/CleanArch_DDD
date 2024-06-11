using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArchPatterns.Repositories.Domain.ArchPatterns.Repositories;
using Domain.Entities.Client;

namespace Domain.ArchPatterns.Repositories.IClientRepository
{
    public interface IClientRepository : ICRUD_DEFAULT<Client>
    { }
}
