namespace CustomLinkedListTest
{
    using System;

    using CustomLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTest
    {
        [TestMethod]
        public void TestEmptyConstructorSetCountToZero()
        {
            var dynamicList = new DynamicList<int>();
            Assert.AreEqual(0, dynamicList.Count, "Dynamic list, constructor not set Count to zero.");
        }

        [TestMethod]
        public void TestAdd()
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
        public void TestRemoveAt()
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAtForExceptionWhenCountIsZeroOrNegative()
        {
            var dynamicList = new DynamicList<int>();
            var elementForRemove = 1;

            // Act
            dynamicList.RemoveAt(elementForRemove);
        }

        [TestMethod]
        public void TestRemove()
        {
            var dynamicList = new DynamicList<int>();
            var elementForRemove = 2;
            dynamicList.Add(0);
            dynamicList.Add(elementForRemove);
            dynamicList.Add(4);

            // Act
            var removedElementIndex = dynamicList.Remove(elementForRemove);

            // Assert
            Assert.AreEqual(dynamicList[1], 4, "Element for remove not removed.");
            Assert.AreEqual(2, dynamicList.Count, "Dynamic list not remove element.");
        }

        [TestMethod]
        public void TestRemoveWhenListIsEmptyOrNotFound()
        {
            var dynamicList = new DynamicList<int>();

            // Act
            var removedElementIndex = dynamicList.Remove(1);

            // Assert
            Assert.IsTrue(removedElementIndex < 0, "List in not empty or not found");
        }

        [TestMethod]
        public void TestIndexOf()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(0);
            dynamicList.Add(2);
            dynamicList.Add(4);
            dynamicList.Add(8);

            // Act
            var returnetIndex = dynamicList.IndexOf(4);

            // Assert
            Assert.AreEqual(2, returnetIndex, "This index is not valid index.");
        }

        [TestMethod]
        public void TestIndexOfForIsEmptyList()
        {
            var dynamicList = new DynamicList<int>();

            // Act
            var returnetIndex = dynamicList.IndexOf(0);

            // Assert
            Assert.IsTrue(returnetIndex < 0, "This list is not empty.");
        }

        [TestMethod]
        public void TestContains()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(0);
            dynamicList.Add(2);
            dynamicList.Add(4);
            dynamicList.Add(8);

            // Act
            var isFound = dynamicList.Contains(4);

            // Assert
            Assert.IsTrue(isFound, "This elements is not found.");
        }

        [TestMethod]
        public void TestDynamicListIndexGetSet()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(3);
            dynamicList.Add(6);

            // Act
            int index = dynamicList[0];
            dynamicList[1] = 5;

            // Assert
            Assert.AreEqual(3, index);
            Assert.AreEqual(5, dynamicList[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDynamicListIndexGetSetException()
        {
            var dynamicList = new DynamicList<int>();

            // Assert
            Assert.AreEqual(1, dynamicList[0]);
        }
    }
}
