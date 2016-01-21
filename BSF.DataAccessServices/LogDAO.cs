using BSF.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.DataAccessServices
{
    public class LogDao : BaseDao<Log>
    {
        public LogDao(IDatabase db) : base(db) {}
        public override void Add(Log entity)
        {
            var parameters = new List<Tuple<string, object>>();
            parameters.Add(new Tuple<string, object>("@MESSAGE", entity.Message));
            parameters.Add(new Tuple<string, object>("@LOG_TYPE", entity.LogType));
            _db.ExecuteCommand("INSERT INTO LOG VALUES(@MESSAGE, @LOG_TYPE)", parameters);
        }
    }
}
