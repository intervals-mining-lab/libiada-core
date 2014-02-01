﻿using System;
using LibiadaMusic.BorodaDivider;
using LibiadaMusic.Characteristics;
using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTest.Characteristics
{
    [TestClass]
    public class AverageLengthTest
    {
        [TestMethod]
        public void TestAverageLength2()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0};
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            Assert.AreEqual(2, AverageLength.Calculate(fmchain1));
        }

        [TestMethod]
        public void TestAverageLength4()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0};
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            Assert.AreEqual(4, AverageLength.Calculate(fmchain1));
        }

        [TestMethod]
        public void TestAverageLength4pause()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note((Pitch) null, new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0};
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            Assert.AreEqual(4, AverageLength.Calculate(fmchain1));
        }

        [TestMethod]
        public void TestAverageLength4tie()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.Start));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.StartStop));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.Stop));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0};
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            Assert.AreEqual(4, AverageLength.Calculate(fmchain1));
        }

        [TestMethod]
        public void TestAverageLength0()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0};
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            Assert.AreEqual(0, AverageLength.Calculate(fmchain1));
        }

        [TestMethod]
        public void TestAverageLengthHalf()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0};
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(AverageLength.Calculate(fmchain1) - 1.5) < 0.000001);
        }

        [TestMethod]
        public void TestAverageLengtherr()
        {
            try
            {
                var fmchain1 = new FmotivChain {Id = 0};
            }
            catch (Exception e)
            {
                if (e.Message != "Unaible to count average length with no elements in chain!")
                {
                    Assert.Fail();
                }
            }
        }
    }
}