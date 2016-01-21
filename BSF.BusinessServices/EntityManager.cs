using BSF.BusinessEntities;
using BSF.BusinessServices;
using BSF.DataAccessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.BusinessServices
{
    public abstract class EntityManager<T> : IEntityManager<T> where T : BusinessEntity
    {
        protected IDatabase _db;

        public EntityManager(IDatabase db)
        {
            _db = db;
        }

        public abstract void Add(T entity);
    }
}
