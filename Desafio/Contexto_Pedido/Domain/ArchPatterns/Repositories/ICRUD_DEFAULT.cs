using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ArchPatterns.Repositories
{
    namespace Domain.ArchPatterns.Repositories
    {
        public interface ICRUD_DEFAULT<T> : ICreate<T>, IRead<T>, IUpdate<T>, IDelete
        { }

        public interface ICreate<T>
        {
            Task CreateAsync(T data);
        }

        public interface IRead<T>
        {
            Task<List<T>> ReadAllAsync();
            Task<T> ReadByIdAsync(int dataId);
        }

        public interface IUpdate<T>
        {
            Task UpdateAsync(T data);
        }

        public interface IDelete
        {
            Task DeleteAsync(int dataId);
        }
    }

}
