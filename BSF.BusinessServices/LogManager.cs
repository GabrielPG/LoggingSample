using BSF.BusinessEntities;
using BSF.DataAccessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.BusinessServices
{
    public class LogManager : EntityManager<Log>
    {
        public LogManager(IDatabase db) : base(db) { }

        public override void Add(Log entity)
        {
            var dao = new LogDao(_db);
            dao.Add(entity);
        }
    }
}
