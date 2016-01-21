using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

using BSF.LoggingServices;

namespace BSF.LoggingServicesTest
{
    [TestClass]
    public class JobLoggerTests
    {
        [TestMethod]
        public void TestErrorLogging()
        {
            var mocks = new List<Mock<ILogger>>() { new Mock<ILogger>(), new Mock<ILogger>(), new Mock<ILogger>() };

            var jobLogger = new JobLogger(mocks.Select(m => m.Object).ToList());

            var message = "This is an error message";

            jobLogger.LogError(message);

            mocks.ForEach(m => m.Verify(o => o.Log(message, LogType.Error)));
        }

        [TestMethod]
        public void TestWarningLogging()
        {
            var mocks = new List<Mock<ILogger>>() { new Mock<ILogger>(), new Mock<ILogger>(), new Mock<ILogger>() };

            var jobLogger = new JobLogger(mocks.Select(m => m.Object).ToList());

            var message = "This is a warning message";

            jobLogger.LogWarning(message);

            mocks.ForEach(m => m.Verify(o => o.Log(message, LogType.Warning)));
        }

        [TestMethod]
        public void TestMessageLogging()
        {
            var mocks = new List<Mock<ILogger>>() { new Mock<ILogger>(), new Mock<ILogger>(), new Mock<ILogger>() };

            var jobLogger = new JobLogger(mocks.Select(m => m.Object).ToList());

            var message = "This is a plain message";

            jobLogger.LogMessage(message);

            mocks.ForEach(m => m.Verify(o => o.Log(message, LogType.Message)));
        }       
    }
}
