using NUnit.Framework;
using SortingHomework;
using System.Collections.Generic;

namespace TestSortableCollection
{
    [TestFixture]
    public class SortableCollectionTester
    {
        static IEnumerable<int> items = new List<int>
        {
            1, 2, 3, 5, 8, 9
        };

        SortableCollection<int> sortableCollection = new SortableCollection<int>(items);

        [Test]
        public void LinearSearch_ShouldReturnTrue_WhenItemFound()
        {
            bool answer = sortableCollection.LinearSearch(1);
            Assert.IsTrue(answer);
        }

        [Test]
        public void LinearSearch_ShouldReturnFalse_WhenItemNotFound()
        {
            bool answer = sortableCollection.LinearSearch(10);
            Assert.IsFalse(answer);
        }



        [Test]
        public void BinarySearch_ShouldReturnTrue_WhenItemFound()
        {
            bool answer = sortableCollection.BinarySearch(1);
            Assert.IsTrue(answer);
        }

        [Test]
        public void BinarySearch_ShouldReturnFalse_WhenItemNotFound()
        {
            bool answer = sortableCollection.BinarySearch(10);
            Assert.IsFalse(answer);
        }
    }
}
