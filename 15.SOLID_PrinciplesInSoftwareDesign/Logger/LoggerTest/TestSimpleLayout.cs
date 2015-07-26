namespace LoggerTest
{
    using Logger.Interfaces;
    using Logger.Models.Layouts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestSimpleLayout
    {
        [TestMethod]
        public void TestSimpleLayoutIsInstanceOfType()
        {
            ILayout simpleLayout = new SimpleLayout();
            //var messages = simpleLayout.Layout(ReportLevel.Info, "This is test messages.");

            Assert.IsInstanceOfType(simpleLayout, typeof(ILayout), "This Layout is not type ILayout.");
        }
    }
}
