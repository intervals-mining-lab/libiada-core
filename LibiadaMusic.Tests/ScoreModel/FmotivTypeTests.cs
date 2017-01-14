namespace LibiadaMusic.Tests.ScoreModel
{
    using System.Linq;

    using LibiadaCore.Extensions;

    using LibiadaMusic.ScoreModel;

    using NUnit.Framework;

    /// <summary>
    /// Fmotiv type enum tests.
    /// </summary>
    [TestFixture(TestOf = typeof(FmotivType))]
    public class FmotivTypeTests
    {
        /// <summary>
        /// The fmotiv types count.
        /// </summary>
        private const int FmotivTypesCount = 6;

        /// <summary>
        /// Tests count of fmotiv types.
        /// </summary>
        [Test]
        public void FmotivTypeCountTest()
        {
            var actualCount = ArrayExtensions.ToArray<FmotivType>().Length;
            Assert.AreEqual(FmotivTypesCount, actualCount);
        }

        /// <summary>
        /// Tests values of fmotiv types.
        /// </summary>
        [Test]
        public void FmotivTypeValuesTest()
        {
            var fmotivTypes = ArrayExtensions.ToArray<FmotivType>();
            for (int i = 0; i < FmotivTypesCount; i++)
            {
                Assert.IsTrue(fmotivTypes.Contains((FmotivType)i));
            }
        }

        /// <summary>
        /// Tests names of fmotiv types.
        /// </summary>
        /// <param name="fmotivType">
        /// The fmotiv type.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        [TestCase((FmotivType)0, "None")]
        [TestCase((FmotivType)1, "CompleteMinimalMeasure")]
        [TestCase((FmotivType)2, "PartialMinimalMeasure")]
        [TestCase((FmotivType)3, "IncreasingSequence")]
        [TestCase((FmotivType)4, "CompleteMinimalMetrorhythmicGroup")]
        [TestCase((FmotivType)5, "PartialMinimalMetrorhythmicGroup")]
        public void FmotivTypeNamesTest(FmotivType fmotivType, string name)
        {
            Assert.AreEqual(name, fmotivType.GetName());
        }

        /// <summary>
        /// Tests that all fmotiv types have display value.
        /// </summary>
        /// <param name="fmotivType">
        /// The fmotiv type.
        /// </param>
        [Test]
        public void FmotivTypeHasDisplayValueTest([Values]FmotivType fmotivType)
        {
            Assert.IsFalse(string.IsNullOrEmpty(fmotivType.GetDisplayValue()));
        }

        /// <summary>
        /// Tests that all fmotiv types have description.
        /// </summary>
        /// <param name="fmotivType">
        /// The fmotiv type.
        /// </param>
        [Test]
        public void FmotivTypeHasDescriptionTest([Values]FmotivType fmotivType)
        {
            Assert.IsFalse(string.IsNullOrEmpty(fmotivType.GetDescription()));
        }

        /// <summary>
        /// Tests that all fmotiv types values are unique.
        /// </summary>
        [Test]
        public void FmotivTypeValuesUniqueTest()
        {
            var fmotivTypes = ArrayExtensions.ToArray<FmotivType>();
            var fmotivTypeValues = fmotivTypes.Cast<byte>();
            Assert.That(fmotivTypeValues, Is.Unique);
        }
    }
}
