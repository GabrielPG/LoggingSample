using BSF.BusinessEntities;
using BSF.BusinessServices;
using BSF.LoggingServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.LoggingServicesTest
{
    [TestClass]
    public class DatabaseLoggerTests
    {
        [TestMethod]
        public void TestErrorLogging()
        {
            var mgrMock = new Mock<IEntityManager<Log>>();

            var dbLogger = new DatabaseLogger(mgrMock.Object);

            Log log = null;
            mgrMock.Setup(repo => repo.Add(It.IsAny<Log>())).Callback<Log>(lg => log = lg);

            var errorMessage = "This is an error message ";
            dbLogger.Log(errorMessage, LogType.Error);

            Assert.IsTrue((log != null) && (log.Message == errorMessage.Trim()) && (log.LogType == (int)LogType.Error));
        }

        [TestMethod]
        public void TestWarningLogging()
        {
            var mgrMock = new Mock<IEntityManager<Log>>();

            var dbLogger = new DatabaseLogger(mgrMock.Object);

            Log log = null;
            mgrMock.Setup(repo => repo.Add(It.IsAny<Log>())).Callback<Log>(lg => log = lg);

            var errorMessage = "This is a warning message ";
            dbLogger.Log(errorMessage, LogType.Warning);

            Assert.IsTrue((log != null) && (log.Message == errorMessage.Trim()) && (log.LogType == (int)LogType.Warning));
        }

        [TestMethod]
        public void TestMessageLogging()
        {
            var mgrMock = new Mock<IEntityManager<Log>>();

            var dbLogger = new DatabaseLogger(mgrMock.Object);

            Log log = null;
            mgrMock.Setup(repo => repo.Add(It.IsAny<Log>())).Callback<Log>(lg => log = lg);

            var errorMessage = "This is a plain message ";
            dbLogger.Log(errorMessage, LogType.Message);

            Assert.IsTrue((log != null) && (log.Message == errorMessage.Trim()) && (log.LogType == (int)LogType.Message));
        }

        [TestMethod]
        public void TestEmptyLogging()
        {
            var mgrMock = new Mock<IEntityManager<Log>>(MockBehavior.Strict);

            var dbLogger = new DatabaseLogger(mgrMock.Object);

            var errorMessage = " ";
            dbLogger.Log(errorMessage, LogType.Message);
        }
    }
}
