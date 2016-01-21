using BSF.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.BusinessServices
{
    public interface IEntityManager<T>
    {
        void Add(T entity);
    }
}
