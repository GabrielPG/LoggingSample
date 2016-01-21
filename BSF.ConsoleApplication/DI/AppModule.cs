using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BSF.CommonServices;
using BSF.LoggingServices;
using BSF.BusinessEntities;
using BSF.DataAccessServices;
using BSF.BusinessServices;

namespace BSF.Application.DI
{
    public class AppModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabase>().To<Database>().WithPropertyValue("ConnectionString", ConfigurationManager.AppSettings["ConnectionString"]);

            Bind<IConsole>().To<AppConsole>();

            Bind<IFileSystem>().To<FileSystem>();                

            Bind<IEntityManager<Log>>().To<LogManager>();

            Bind<IJobLogger>().To<JobLogger>().InSingletonScope();

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableConsoleLogging"]))
            {
                Bind<ILogger>().To<ConsoleLogger>().Named("ConsoleLogger");
            }

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableFileLogging"]))
            {
                Bind<ILogger>().To<FileLogger>().Named("FileLogger").
                    WithConstructorArgument("logFilePath", ConfigurationManager.AppSettings["LogFileDirectory"]).
                    WithConstructorArgument("logBaseFileName", ConfigurationManager.AppSettings["LogFileBaseName"]);
            }

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDatabaseLogging"]))
            {
                Bind<ILogger>().To<DatabaseLogger>().Named("DatabaseLogger");
            }
        }
    }
}
