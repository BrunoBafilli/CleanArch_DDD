using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ArchPatterns.Repositories
{
    public interface ICRUD<T>
    {
        Task CreateAsync(T data);
        Task<List<T>> ReadAllAsync();
        Task<T> ReadByIdAsync(int dataId);
        Task UpdateAsync(T data);
        Task DeleteAsync(int dataId);
    }
}
