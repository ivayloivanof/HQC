namespace CustomLinkedListTest
{
    using CustomLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTest
    {
        [TestMethod]
        public void TestConstructorSetCountToZero()
        {
            var dynamicList = new DynamicList<int>();
            Assert.AreEqual(0, dynamicList.Count, "Dynamic list, constructor not set Count to zero.");
        }

        [TestMethod]
        public void TestAddThreeElements()
        {
            var dynamicList = new DynamicList<int>();

            // Act
            dynamicList.Add(0);
            dynamicList.Add(1);
            dynamicList.Add(2);

            // Assert
            Assert.AreEqual(3, dynamicList.Count, "Dynamic list not set Count to three elements.");
        }

        [TestMethod]
        public void TestRemoveAtElementsOfList()
        {
            var dynamicList = new DynamicList<int>();
            var elementForRemove = 1;
            dynamicList.Add(0);
            dynamicList.Add(elementForRemove);
            dynamicList.Add(2);

            // Act
            var removedElement = dynamicList.RemoveAt(1);

            // Assert
            Assert.AreEqual(elementForRemove, removedElement, "Element for remove not removed.");
            Assert.AreEqual(2, dynamicList.Count, "Dynamic list not remove element.");
        }
    }
}
