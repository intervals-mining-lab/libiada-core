namespace LibiadaCore.Tests.Core.SimpleTypes
{
    using System.Linq;

    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Extensions;

    using NUnit.Framework;

    /// <summary>
    /// Fmotiv type enum tests.
    /// </summary>
    [TestFixture(TestOf = typeof(FmotifType))]
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
            var actualCount = EnumExtensions.ToArray<FmotifType>().Length;
            Assert.AreEqual(FmotivTypesCount, actualCount);
        }

        /// <summary>
        /// Tests values of fmotiv types.
        /// </summary>
        [Test]
        public void FmotivTypeValuesTest()
        {
            var fmotivTypes = EnumExtensions.ToArray<FmotifType>();
            for (int i = 0; i < FmotivTypesCount; i++)
            {
                Assert.IsTrue(fmotivTypes.Contains((FmotifType)i));
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
        [TestCase((FmotifType)0, "None")]
        [TestCase((FmotifType)1, "CompleteMinimalMeasure")]
        [TestCase((FmotifType)2, "PartialMinimalMeasure")]
        [TestCase((FmotifType)3, "IncreasingSequence")]
        [TestCase((FmotifType)4, "CompleteMinimalMetrorhythmicGroup")]
        [TestCase((FmotifType)5, "PartialMinimalMetrorhythmicGroup")]
        public void FmotivTypeNamesTest(FmotifType fmotivType, string name)
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
        public void FmotivTypeHasDisplayValueTest([Values]FmotifType fmotivType)
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
        public void FmotivTypeHasDescriptionTest([Values]FmotifType fmotivType)
        {
            Assert.IsFalse(string.IsNullOrEmpty(fmotivType.GetDescription()));
        }

        /// <summary>
        /// Tests that all fmotiv types values are unique.
        /// </summary>
        [Test]
        public void FmotivTypeValuesUniqueTest()
        {
            var fmotivTypes = EnumExtensions.ToArray<FmotifType>();
            var fmotivTypeValues = fmotivTypes.Cast<byte>();
            Assert.That(fmotivTypeValues, Is.Unique);
        }
    }
}
