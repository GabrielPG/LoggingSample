using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.CommonServices
{
    public class FileSystem : IFileSystem
    {
        public void AppendLine(string fileName, string line)
        {
            using (StreamWriter wr = File.AppendText(fileName))
            {
                wr.WriteLine(line);
            }                
        }

        public void CreateFile(string fileName)
        {
            using (File.Create(fileName)) { };
        }

        public bool FileExists(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}
