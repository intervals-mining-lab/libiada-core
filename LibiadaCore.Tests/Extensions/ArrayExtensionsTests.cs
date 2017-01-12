namespace LibiadaCore.Tests.Extensions
{
    using System;
    using System.Linq;

    using LibiadaCore.Extensions;

    using NUnit.Framework;

    /// <summary>
    /// The array manipulator tests.
    /// </summary>
    [TestFixture(TestOf = typeof(ArrayExtensions))]
    public class ArrayExtensionsTests
    {
        /// <summary>
        /// The test enum.
        /// </summary>
        private enum TestEnum : byte
        {
            /// <summary>
            /// The first.
            /// </summary>
            First = 1,

            /// <summary>
            /// The second.
            /// </summary>
            Second = 2,

            /// <summary>
            /// The third.
            /// </summary>
            Third = 3
        }

        /// <summary>
        /// Tests ToArray method.
        /// </summary>
        [Test]
        public void ToArrayTest()
        {
            var actual = ArrayExtensions.ToArray<TestEnum>();
            var expected = new[] { TestEnum.First, TestEnum.Second, TestEnum.Third };

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Delete element at position test.
        /// </summary>
        [Test]
        public void DeleteAtIntArrayTest()
        {
            var source = new[] { 1, 2, 2, 4, 4, 2, 7, 2, 3, 1 };

            var result = source.DeleteAt(6);
            var expected = new[] { 1, 2, 2, 4, 4, 2, 2, 3, 1 };
            Assert.AreEqual(expected, result);

            result = result.DeleteAt(4);
            expected = new[] { 1, 2, 2, 4, 2, 2, 3, 1 };
            Assert.AreEqual(expected, result);

            result = result.DeleteAt(0);
            expected = new[] { 2, 2, 4, 2, 2, 3, 1 };
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Delete element at position test.
        /// </summary>
        [Test]
        public void DeleteAtTest()
        {
            var source = new[] { "test", "a", "a", "test", "test", "b", "1" };

            var result = source.DeleteAt(6);
            var expected = new[] { "test", "a", "a", "test", "test", "b" };
            Assert.AreEqual(expected, result);

            result = result.DeleteAt(4);
            expected = new[] { "test", "a", "a", "test", "b" };
            Assert.AreEqual(expected, result);

            result = result.DeleteAt(0);
            expected = new[] { "a", "a", "test", "b" };
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// All indexes of element search test.
        /// </summary>
        [Test]
        public void AllIndexesOfIntArrayTest()
        {
            var source = new[] { 1, 2, 2, 4, 4, 2, 7, 2, 3, 1 };

            var expected = new[] { 1, 2, 5, 7 };
            Assert.AreEqual(expected, source.AllIndexesOf(2));

            expected = new[] { 6 };
            Assert.AreEqual(expected, source.AllIndexesOf(7));

            expected = new int[0];
            Assert.AreEqual(expected, source.AllIndexesOf(11));
        }

        /// <summary>
        /// All indexes of element search test.
        /// </summary>
        [Test]
        public void AllIndexesOfTest()
        {
            var source = new[] { "a", "test", "a", "aa", "test", "test", "c" };

            var expected = new[] { 0, 2 };
            Assert.AreEqual(expected, source.AllIndexesOf("a"));

            expected = new[] { 6 };
            Assert.AreEqual(expected, source.AllIndexesOf("c"));

            expected = new[] { 1, 4, 5 };
            Assert.AreEqual(expected, source.AllIndexesOf("test"));

            expected = new int[0];
            Assert.AreEqual(expected, source.AllIndexesOf("another test"));
        }

        /// <summary>
        /// Array content to string test.
        /// </summary>
        [Test]
        public void ToStringTest()
        {
            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var expected = "1 2 3 4 5 6 7 8 9 10";
            Assert.AreEqual(expected, source.ToString(" "));

            expected = "1, 2, 3, 4, 5, 6, 7, 8, 9, 10";
            Assert.AreEqual(expected, source.ToString(", "));
        }

        /// <summary>
        /// Array content to string with default delimiter test.
        /// </summary>
        [Test]
        public void ToStringWithDefaultDelimiterTest()
        {
            var source = new[] { 1, 2, 3 };

            var expected = "1" + Environment.NewLine + "2" + Environment.NewLine + "3";
            Assert.AreEqual(expected, source.ToStringWithDefaultDelimiter());
        }

        /// <summary>
        /// Array content to string without delimiter test.
        /// </summary>
        [Test]
        public void ToStringWithoutDelimiterTest()
        {
            var source = new[] { 1, 2, 3, 2, 2 };

            var expected = "12322";
            Assert.AreEqual(expected, source.ToStringWithoutDelimiter());
        }

        /// <summary>
        /// Array rotation test.
        /// </summary>
        [Test]
        public void RotateTest()
        {
            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = source.Rotate(1);
            var expected = new[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 };
            Assert.AreEqual(expected, result);

            result = source.Rotate(2);
            expected = new[] { 3, 4, 5, 6, 7, 8, 9, 10, 1, 2 };
            Assert.AreEqual(expected, result);

            result = source.Rotate(10);
            expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Array sorting check test.
        /// </summary>
        [Test]
        public void IsSortedTest()
        {
            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.IsTrue(source.IsSorted());
            Assert.IsTrue(source.ToList().IsSorted());

            source = new[] { 1 };
            Assert.IsTrue(source.IsSorted());
            Assert.IsTrue(source.ToList().IsSorted());

            source = new[] { 1, 2, 2, 2, 2, 10, 100, 10000 };
            Assert.IsTrue(source.IsSorted());
            Assert.IsTrue(source.ToList().IsSorted());

            source = new[] { 1, 2, 1, 3, 4, 10 };
            Assert.IsFalse(source.IsSorted());
            Assert.IsFalse(source.ToList().IsSorted());
        }
    }
}
