using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;
using MDA.OIP.ScoreModel;
using MDA.ICL;

namespace MDATest.ICL
{
    [TestClass]
    public class TestAverageLength
    {
        [TestMethod]
        public void TestAverageLength2() 
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.AreEqual(2, AverageLength.Calculate(fmchain1));
        }
        [TestMethod]
        public void TestAverageLength4()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.AreEqual(4, AverageLength.Calculate(fmchain1));
        }

        [TestMethod]
        public void TestAverageLength4Pause()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 512), false, (int)Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.AreEqual(4, AverageLength.Calculate(fmchain1));
        }

        [TestMethod]
        public void TestAverageLength4tie()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, (int)Tie.Start));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, (int)Tie.StartStop));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, (int)Tie.Stop));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, (int)Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.AreEqual(4, AverageLength.Calculate(fmchain1));
        }

        [TestMethod]
        public void TestAverageLength0()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.AreEqual(0, AverageLength.Calculate(fmchain1));
        }

        [TestMethod]       
        public void TestAverageLengthHalf()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            
            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.IsTrue(Math.Abs(AverageLength.Calculate(fmchain1)-1.5)<0.000001);
        }
        [TestMethod]
        public void TestAverageLengtherr()
        {
            try
            {
                FmotivChain fmchain1 = new FmotivChain();
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
