namespace LibiadaMusic.Tests.ScoreModel
{
    using System.Linq;

    using LibiadaCore.Extensions;

    using LibiadaMusic.ScoreModel;

    using NUnit.Framework;

    /// <summary>
    /// Accidental enum tests.
    /// </summary>
    [TestFixture(TestOf = typeof(Accidental))]
    public class AccidentalTests
    {
        /// <summary>
        /// The accidentals count.
        /// </summary>
        private const int AccidentalsCount = 5;

        /// <summary>
        /// Tests count of accidentals.
        /// </summary>
        [Test]
        public void AccidentalCountTest()
        {
            var actualCount = EnumExtensions.ToArray<Accidental>().Length;
            Assert.AreEqual(AccidentalsCount, actualCount);
        }

        /// <summary>
        /// Tests values of accidentals.
        /// </summary>
        [Test]
        public void AccidentalValuesTest()
        {
            var accidentals = EnumExtensions.ToArray<Accidental>();
            for (int i = -2; i < AccidentalsCount - 2; i++)
            {
                Assert.IsTrue(accidentals.Contains((Accidental)i));
            }
        }

        /// <summary>
        /// Tests names of accidentals.
        /// </summary>
        /// <param name="accidental">
        /// The accidental.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        [TestCase((Accidental)(-2), "DoubleFlat")]
        [TestCase((Accidental)(-1), "Flat")]
        [TestCase((Accidental)0, "Bekar")]
        [TestCase((Accidental)1, "Sharp")]
        [TestCase((Accidental)2, "DoubleSharp")]
        public void AccidentalNamesTest(Accidental accidental, string name)
        {
            Assert.AreEqual(name, accidental.GetName());
        }

        /// <summary>
        /// Tests that all accidentals have display value.
        /// </summary>
        /// <param name="accidental">
        /// The accidental.
        /// </param>
        [Test]
        public void AccidentalHasDisplayValueTest([Values]Accidental accidental)
        {
            Assert.IsFalse(string.IsNullOrEmpty(accidental.GetDisplayValue()));
        }

        /// <summary>
        /// Tests that all accidentals have description.
        /// </summary>
        /// <param name="accidental">
        /// The accidental.
        /// </param>
        [Test]
        public void AccidentalHasDescriptionTest([Values]Accidental accidental)
        {
            Assert.IsFalse(string.IsNullOrEmpty(accidental.GetDescription()));
        }

        /// <summary>
        /// Tests that all accidentals values are unique.
        /// </summary>
        [Test]
        public void AccidentalValuesUniqueTest()
        {
            var accidentals = EnumExtensions.ToArray<Accidental>();
            var accidentalValues = accidentals.Cast<short>();
            Assert.That(accidentalValues, Is.Unique);
        }
    }
}
