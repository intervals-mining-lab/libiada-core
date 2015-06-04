using System;
using System.Text;
using System.Collections.Generic;
using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusic.Tests.ScoreModel
{
    /// <summary>
    /// Сводное описание для PitchTests
    /// </summary>
    [TestClass]
    public class PitchTests
    {

        [TestMethod]
        public void PitchConstructorTest()
        {
            var initialPitch = new Pitch(1, 'A', 0);
            var midiNumberPitch = new Pitch(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.MidiNumber, midiNumberPitch.MidiNumber);
            initialPitch = new Pitch(5, 'C', 1);
            midiNumberPitch = new Pitch(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.MidiNumber, midiNumberPitch.MidiNumber);
        }
    }
}
