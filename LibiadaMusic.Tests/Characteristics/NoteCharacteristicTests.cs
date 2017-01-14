namespace LibiadaMusic.Tests.Characteristics
{
    using System;

    using LibiadaMusic.BorodaDivider;
    using LibiadaMusic.Characteristics;
    using LibiadaMusic.ScoreModel;

    using NUnit.Framework;

    /// <summary>
    /// The note characteristic tests.
    /// </summary>
    [TestFixture]
    public class NoteCharacteristicTests
    {
        /// <summary>
        /// The value note remoteness test.
        /// </summary>
        [Test]
        public void ValueNoteRemotenessTest()
        {
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain { Id = 0 };
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.75 - NoteCharacteristic.CalculateRemoteness(chain)) < 0.000001);
        }

        /// <summary>
        /// The value note remoteness pause test.
        /// </summary>
        [Test]
        public void ValueNoteRemotenessPauseTest()
        {
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain { Id = 0 };
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.75 - NoteCharacteristic.CalculateRemoteness(chain)) < 0.000001);
        }

        /// <summary>
        /// The value note remoteness tie test.
        /// </summary>
        [Test]
        public void ValueNoteRemotenessTieTest()
        {
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 2, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.Start));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.End));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain { Id = 0 };
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.75 - NoteCharacteristic.CalculateRemoteness(chain)) < 0.000001);
        }

        /// <summary>
        /// The value note remoteness oct test.
        /// </summary>
        [Test]
        public void ValueNoteRemotenessOctTest()
        {
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 2, false, 512), false, Tie.None));

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(4, NoteSymbol.A, 0), new Duration(1, 2, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain { Id = 0 };
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(1.14624062 - NoteCharacteristic.CalculateRemoteness(chain)) < 0.000001);
        }
    }
}
