namespace LoggerTest
{
    using Logger.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestFileAppender
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileAppender fileAppender = new FileAppender(simpleLayout);
        }
    }
}
