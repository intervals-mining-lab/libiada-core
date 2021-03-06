﻿namespace LibiadaCore.Tests.Core.SimpleTypes
{
    using System.Linq;

    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Extensions;

    using NUnit.Framework;

    /// <summary>
    /// Instrument enum tests.
    /// </summary>
    [TestFixture(TestOf = typeof(Instrument))]
    public class InstrumentTests
    {
        /// <summary>
        /// The instruments count.
        /// </summary>
        private const int InstrumentsCount = 1;

        /// <summary>
        /// Tests count of instruments.
        /// </summary>
        [Test]
        public void InstrumentCountTest()
        {
            var actualCount = EnumExtensions.ToArray<Instrument>().Length;
            Assert.AreEqual(InstrumentsCount, actualCount);
        }

        /// <summary>
        /// Tests values of instruments.
        /// </summary>
        [Test]
        public void InstrumentValuesTest()
        {
            var instruments = EnumExtensions.ToArray<Instrument>();
            for (int i = 0; i < InstrumentsCount; i++)
            {
                Assert.IsTrue(instruments.Contains((Instrument)i));
            }
        }

        /// <summary>
        /// Tests names of instruments.
        /// </summary>
        /// <param name="instrument">
        /// The instrument.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        [TestCase((Instrument)0, "AnyOrUnknown")]
        public void InstrumentNamesTest(Instrument instrument, string name)
        {
            Assert.AreEqual(name, instrument.GetName());
        }

        /// <summary>
        /// Tests that all instruments have display value.
        /// </summary>
        /// <param name="instrument">
        /// The instrument.
        /// </param>
        [Test]
        public void InstrumentHasDisplayValueTest([Values]Instrument instrument)
        {
            Assert.IsFalse(string.IsNullOrEmpty(instrument.GetDisplayValue()));
        }

        /// <summary>
        /// Tests that all instruments have description.
        /// </summary>
        /// <param name="instrument">
        /// The instrument.
        /// </param>
        [Test]
        public void InstrumentHasDescriptionTest([Values]Instrument instrument)
        {
            Assert.IsFalse(string.IsNullOrEmpty(instrument.GetDescription()));
        }

        /// <summary>
        /// Tests that all instruments values are unique.
        /// </summary>
        [Test]
        public void InstrumentValuesUniqueTest()
        {
            var instruments = EnumExtensions.ToArray<Instrument>();
            var instrumentValues = instruments.Cast<byte>();
            Assert.That(instrumentValues, Is.Unique);
        }
    }
}
