using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BSF.Application.DI;
using BSF.LoggingServices;
using Ninject;

namespace BSF.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var kernel = new StandardKernel(new AppModule()))
            {
                var jobsLogger = kernel.Get<IJobLogger>();

                //Kickstart app...
            }
        }
    }
}
