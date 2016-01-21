using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.DataAccessServices
{
    public interface IDatabase
    {
        string ConnectionString { get; set; }
        void ExecuteCommand(string commandText, List<Tuple<string, object>> parameters);
    }
}
