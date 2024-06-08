using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ArchPatterns.Repositories
{
    public interface ICRUD<T>
    {
        Task Create(T data);
        Task<List<T>> ReadAll();
        Task<T> ReadById(int dataId);
        Task Update(T data);
        Task Delete(int dataId);
    }
}
