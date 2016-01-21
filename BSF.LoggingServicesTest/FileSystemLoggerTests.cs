using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BSF.CommonServices;
using BSF.LoggingServices;

namespace BSF.LoggingServicesTest
{
    [TestClass]
    public class FileSystemLoggerTests
    {
        private string GetExpectedLogMessage(string message, LogType logType)
        {
            return string.Format("{0} {1}: {2}", DateTime.Now.ToShortDateString(), logType.ToString(), message.Trim());
        }

        [TestMethod]
        public void TestErrorLogging()
        {
            var fsMock = new Mock<IFileSystem>();

            var fileLogger = new FileLogger(fsMock.Object, "basepath", "logfile");

            var message = "This is an error message";
            fileLogger.Log(message, LogType.Error);

            fsMock.Verify(m => m.AppendLine(It.IsAny<string>(), GetExpectedLogMessage(message, LogType.Error)));
       }

        [TestMethod]
        public void TestWarningLogging()
        {
            var fsMock = new Mock<IFileSystem>();

            var fileLogger = new FileLogger(fsMock.Object, "basepath", "logfile");

            var message = "This is a warning message";
            fileLogger.Log(message, LogType.Warning);

            fsMock.Verify(m => m.AppendLine(It.IsAny<string>(), GetExpectedLogMessage(message, LogType.Warning)));
        }

        [TestMethod]
        public void TestMessageLogging()
        {
            var fsMock = new Mock<IFileSystem>();

            var fileLogger = new FileLogger(fsMock.Object, "basepath", "logfile");

            var message = "This is a plain message";
            fileLogger.Log(message, LogType.Message);

            fsMock.Verify(m => m.AppendLine(It.IsAny<string>(), GetExpectedLogMessage(message, LogType.Message)));
        }

        [TestMethod]
        public void TestEmptyText()
        {
            var fsMock = new Mock<IFileSystem>(MockBehavior.Strict);

            var fileLogger = new FileLogger(fsMock.Object, "basepath", "logfile");

            var message = "  ";
            fileLogger.Log(message, LogType.Message);
        }
    }
}
