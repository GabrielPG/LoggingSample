using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.BusinessEntities
{
    public class Log : BusinessEntity
    {
        public string Message { get; set; }
        public int LogType { get; set; }
    }
}
