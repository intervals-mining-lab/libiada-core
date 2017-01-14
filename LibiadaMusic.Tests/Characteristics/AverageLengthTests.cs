namespace LibiadaMusic.Tests.Characteristics
{
    using System;

    using LibiadaMusic.BorodaDivider;
    using LibiadaMusic.Characteristics;
    using LibiadaMusic.ScoreModel;

    using NUnit.Framework;

    /// <summary>
    /// The average length tests.
    /// </summary>
    [TestFixture]
    public class AverageLengthTests
    {
        /// <summary>
        /// The average length first test.
        /// </summary>
        [Test]
        public void AverageLengthFirstTest()
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
            Assert.AreEqual(2, AverageLength.Calculate(chain));
        }

        /// <summary>
        /// The average length second test.
        /// </summary>
        [Test]
        public void AverageLengthSecondTest()
        {
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain { Id = 0 };
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.AreEqual(4, AverageLength.Calculate(chain));
        }

        /// <summary>
        /// The average length pause test.
        /// </summary>
        [Test]
        public void AverageLengthPauseTest()
        {
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain { Id = 0 };
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.AreEqual(4, AverageLength.Calculate(chain));
        }

        /// <summary>
        /// The average length tie test.
        /// </summary>
        [Test]
        public void AverageLengthTieTest()
        {
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.Start));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.Continue));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.End));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain { Id = 0 };
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.AreEqual(4, AverageLength.Calculate(chain));
        }

        /// <summary>
        /// The average length third test.
        /// </summary>
        [Test]
        public void AverageLengthThirdTest()
        {
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain { Id = 0 };
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.AreEqual(0, AverageLength.Calculate(chain));
        }

        /// <summary>
        /// The average length half test.
        /// </summary>
        [Test]
        public void AverageLengthHalfTest()
        {
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain { Id = 0 };
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(AverageLength.Calculate(chain) - 1.5) < 0.000001);
        }

        /// <summary>
        /// The average length error test.
        /// </summary>
        [Test]
        public void AverageLengthErrorTest()
        {
            FmotivChain chain = new FmotivChain { Id = 0 };
            var exception = Assert.Throws<Exception>(() => AverageLength.Calculate(chain));
            Assert.AreEqual("Unable to count average length with no elements in chain!", exception.Message);
        }
    }
}
