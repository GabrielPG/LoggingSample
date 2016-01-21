using BSF.CommonServices;
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
    public class ConsoleLoggerTests
    {
        private string GetExpectedLogMessage(string message)
        {
            return string.Format("{0} {1}", DateTime.Now.ToShortDateString(), message.Trim());
        }

        [TestMethod]
        public void TestErrorLogging()
        {
            var consoleMock = new Mock<IConsole>();

            var consoleLogger = new ConsoleLogger(consoleMock.Object);

            var message = "This is an error message";
            consoleLogger.Log(message, LogType.Error);
            
            consoleMock.Verify(m => m.WriteLine(GetExpectedLogMessage(message)));
            consoleMock.VerifySet(m => m.ForegroundColor = ConsoleColor.Red);
        }

        [TestMethod]
        public void TestWarningLogging()
        {
            var consoleMock = new Mock<IConsole>();

            var consoleLogger = new ConsoleLogger(consoleMock.Object);

            var message = "This is a warning message";
            consoleLogger.Log(message, LogType.Warning);

            consoleMock.Verify(m => m.WriteLine(GetExpectedLogMessage(message)));
            consoleMock.VerifySet(m => m.ForegroundColor = ConsoleColor.Yellow);
        }

        [TestMethod]
        public void TestMessageLogging()
        {
            var consoleMock = new Mock<IConsole>();

            var consoleLogger = new ConsoleLogger(consoleMock.Object);

            var message = "This is a plain message";
            consoleLogger.Log(message, LogType.Message);

            consoleMock.Verify(m => m.WriteLine(GetExpectedLogMessage(message)));
            consoleMock.VerifySet(m => m.ForegroundColor = ConsoleColor.White);
        }

        [TestMethod]
        public void TestEmptyLogging() 
        {
            var consoleMock = new Mock<IConsole>(MockBehavior.Strict);

            var consoleLogger = new ConsoleLogger(consoleMock.Object);

            var message = "  ";
            consoleLogger.Log(message, LogType.Message);
        }
    }
}
