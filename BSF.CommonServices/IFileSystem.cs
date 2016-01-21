using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.CommonServices
{
    public interface IFileSystem
    {
        bool FileExists(string fileName);
        void CreateFile(string fileName);
        void AppendLine(string fileName, string line);
    }
}
