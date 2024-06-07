using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Interfaces;

namespace Domain.Entities.Order
{
    public class EntityDefault<T> : IEntity<T>
    {
        public T Id { get; protected set; }
    }
}
