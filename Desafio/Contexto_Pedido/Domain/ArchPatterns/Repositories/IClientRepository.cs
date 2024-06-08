using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Client;

namespace Domain.ArchPatterns.Repositories
{
    public interface IClientRepository : ICRUD<Client>
    { }
}
