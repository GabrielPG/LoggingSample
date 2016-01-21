using BSF.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.DataAccessServices
{
    public abstract class BaseDao<T> where T : BusinessEntity
    {
        protected IDatabase _db;
        public BaseDao(IDatabase db)
        {
            _db = db;
        }

        public abstract void Add(Log entity);
    }
}
