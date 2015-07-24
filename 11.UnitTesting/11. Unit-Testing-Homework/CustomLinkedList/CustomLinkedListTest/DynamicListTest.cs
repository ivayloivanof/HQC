namespace CustomLinkedListTest
{
    using CustomLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTest
    {
        [TestMethod]
        public void TestDynamicListConstructorSetCountToZero()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();
            Assert.AreEqual(0, dynamicList.Count, "Dynamic list, constructor not set Count to zero.");
        }

        [TestMethod]
        public void TestDynamicListAdd()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            // Act
            dynamicList.Add(0);
            dynamicList.Add(1);
            dynamicList.Add(2);

            // Assert
            Assert.AreEqual(0, dynamicList.Count, "Dynamic list, constructor not set Count to zero.");
        }
    }
}
