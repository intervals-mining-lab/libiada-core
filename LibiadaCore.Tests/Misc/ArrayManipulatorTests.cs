namespace LibiadaCore.Tests.Misc
{
    using LibiadaCore.Misc;

    using NUnit.Framework;

    /// <summary>
    /// The array manipulator tests.
    /// </summary>
    [TestFixture]
    public class ArrayManipulatorTests
    {
        /// <summary>
        /// The rotate array test.
        /// </summary>
        [Test]
        public void RotateArrayTest()
        {
            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = ArrayManipulator.RotateArray(source, 1);
            var expected = new[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 };
            Assert.AreEqual(expected, result);

            result = ArrayManipulator.RotateArray(source, 2);
            expected = new[] { 3, 4, 5, 6, 7, 8, 9, 10, 1, 2 };
            Assert.AreEqual(expected, result);

            result = ArrayManipulator.RotateArray(source, 10);
            expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// The is sorted test.
        /// </summary>
        [Test]
        public void IsSortedTest()
        {
            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.IsTrue(ArrayManipulator.IsSorted(source));

            source = new[] { 1 };
            Assert.IsTrue(ArrayManipulator.IsSorted(source));

            source = new[] { 1, 2, 2, 2, 2, 10, 100, 10000 };
            Assert.IsTrue(ArrayManipulator.IsSorted(source));

            source = new[] { 1, 2, 1, 3, 4, 10 };
            Assert.IsFalse(ArrayManipulator.IsSorted(source));
        }
    }
}
