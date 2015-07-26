namespace LoggerTest
{
    using System;

    using Logger.Interfaces;
    using Logger.Models.Appenders;
    using Logger.Models.Layouts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestAppenders
    {
        [TestMethod]
        public void TestAppendersIsIAppender()
        {
            var simpleLayout = new SimpleLayout();
            var xmlLayout = new XmlLayout();

            var fileAppender = new FileAppender(simpleLayout);
            IAppender fileAppenderXml = new FileAppender(xmlLayout);

            Assert.IsInstanceOfType(fileAppender, typeof(IAppender), "This fileAppender is not IAppender.");
            Assert.IsInstanceOfType(fileAppenderXml, typeof(IAppender), "This fileAppenderXml is not IAppender.");
        }

        [TestMethod]
        public void TestAppendersFilePath()
        {
            string pathTxt = "../../log.txt";
            string pathXml = "../../log.xml";

            var simpleLayout = new SimpleLayout();
            var xmlLayout = new XmlLayout();

            var fileAppender = new FileAppender(simpleLayout);
            IAppender fileAppenderXml = new FileAppender(xmlLayout);
            
            fileAppender.File = pathTxt;
            fileAppenderXml.File = pathXml;

            Assert.AreEqual(pathTxt, fileAppender.File, "This is not same path for log.txt.");
            Assert.AreEqual(pathXml, fileAppenderXml.File, "This is not same path for log.xml.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAppendersMissingFilePath()
        {
            var pathTxt = string.Empty;
            var pathXml = string.Empty;

            var simpleLayout = new SimpleLayout();
            var xmlLayout = new XmlLayout();

            var fileAppender = new FileAppender(simpleLayout);
            IAppender fileAppenderXml = new FileAppender(xmlLayout);

            fileAppender.File = pathTxt;
            fileAppenderXml.File = pathXml;
        }
    }
}
