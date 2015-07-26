namespace LoggerTest
{
    using Logger.Interfaces;
    using Logger.Models.Layouts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestLayouts
    {
        [TestMethod]
        public void TestSimpleLayoutIsILayout()
        {
            ILayout simpleLayout = new SimpleLayout();
            Assert.IsInstanceOfType(simpleLayout, typeof(ILayout), "This simpleLayout is not type ILayout.");
        }

        [TestMethod]
        public void TestXmlLayoutIsILayout()
        {
            ILayout xmlLayout = new XmlLayout();
            Assert.IsInstanceOfType(xmlLayout, typeof(ILayout), "This xmlLayout is not type ILayout.");
        }
    }
}
