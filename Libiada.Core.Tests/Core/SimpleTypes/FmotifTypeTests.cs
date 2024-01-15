namespace LibiadaCore.Tests.Core.SimpleTypes
{
    using System.Linq;

    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Extensions;

    using NUnit.Framework;

    /// <summary>
    /// Fmotif type enum tests.
    /// </summary>
    [TestFixture(TestOf = typeof(FmotifType))]
    public class FmotifTypeTests
    {
        /// <summary>
        /// The fmotif types count.
        /// </summary>
        private const int FmotifTypesCount = 6;

        /// <summary>
        /// Tests count of fmotif types.
        /// </summary>
        [Test]
        public void FmotifTypeCountTest()
        {
            var actualCount = EnumExtensions.ToArray<FmotifType>().Length;
            Assert.AreEqual(FmotifTypesCount, actualCount);
        }

        /// <summary>
        /// Tests values of fmotif types.
        /// </summary>
        [Test]
        public void FmotifTypeValuesTest()
        {
            var fmotifTypes = EnumExtensions.ToArray<FmotifType>();
            for (int i = 0; i < FmotifTypesCount; i++)
            {
                Assert.IsTrue(fmotifTypes.Contains((FmotifType)i));
            }
        }

        /// <summary>
        /// Tests names of fmotif types.
        /// </summary>
        /// <param name="fmotifType">
        /// The fmotif type.
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
        public void FmotifTypeNamesTest(FmotifType fmotifType, string name)
        {
            Assert.AreEqual(name, fmotifType.GetName());
        }

        /// <summary>
        /// Tests that all fmotif types have display value.
        /// </summary>
        /// <param name="fmotifType">
        /// The fmotif type.
        /// </param>
        [Test]
        public void FmotifTypeHasDisplayValueTest([Values]FmotifType fmotifType)
        {
            Assert.IsFalse(string.IsNullOrEmpty(fmotifType.GetDisplayValue()));
        }

        /// <summary>
        /// Tests that all fmotif types have description.
        /// </summary>
        /// <param name="fmotifType">
        /// The fmotif type.
        /// </param>
        [Test]
        public void FmotifTypeHasDescriptionTest([Values]FmotifType fmotifType)
        {
            Assert.IsFalse(string.IsNullOrEmpty(fmotifType.GetDescription()));
        }

        /// <summary>
        /// Tests that all fmotif types values are unique.
        /// </summary>
        [Test]
        public void FmotifTypeValuesUniqueTest()
        {
            var fmotifTypes = EnumExtensions.ToArray<FmotifType>();
            var fmotifTypeValues = fmotifTypes.Cast<byte>();
            Assert.That(fmotifTypeValues, Is.Unique);
        }
    }
}
