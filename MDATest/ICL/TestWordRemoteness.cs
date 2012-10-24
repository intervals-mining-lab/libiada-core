using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;
using MDA.OIP.ScoreModel;
using MDA.ICL;

namespace MDATest.ICL
{
    [TestClass]
    public class TestWordRemoteness
    {
        //TODO: Переделать чтоб проверялось относительно привязки к концу!!! иначе не вполняются
        [TestMethod]
        [Ignore]
        public void TestWordRemoteness1() 
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.IsTrue(Math.Abs(0.5 - WordRemoteness.CalculateInWords(fmchain1)) < 0.000001);
            Assert.IsTrue(Math.Abs(1.5 - WordRemoteness.CalculateInLetters(fmchain1)) < 0.000001);
        }
        [TestMethod]
        [Ignore]
        public void TestWordRemoteness2Same()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.IsTrue(Math.Abs(0 - WordRemoteness.CalculateInWords(fmchain1)) < 0.000001);
            Assert.IsTrue(Math.Abs(1 - WordRemoteness.CalculateInLetters(fmchain1)) < 0.000001);
        }

        [TestMethod]
        [Ignore]
        public void TestWordRemoteness3()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");
            Fmotiv fmotiv3 = new Fmotiv("ПМТ");
            Fmotiv fmotiv4 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv4.NoteList.Add(new ValueNote(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new ValueNote(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(4);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            fmchain1.Add(fmotiv3, 2);
            fmchain1.Add(fmotiv4, 3);
            Assert.IsTrue(Math.Abs(1.146241 - WordRemoteness.CalculateInWords(fmchain1)) < 0.00001);
            Assert.IsTrue(Math.Abs(2.226723 - WordRemoteness.CalculateInLetters(fmchain1)) < 0.00001);
        }

        [TestMethod]
        [Ignore]
        public void TestWordRemoteness3Same()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");
            Fmotiv fmotiv3 = new Fmotiv("ПМТ");
            Fmotiv fmotiv4 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(5, 'D', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(5, 'G', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv4.NoteList.Add(new ValueNote(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new ValueNote(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(4);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            fmchain1.Add(fmotiv3, 2);
            fmchain1.Add(fmotiv4, 3);
            Assert.IsTrue(Math.Abs(1 - WordRemoteness.CalculateInWords(fmchain1)) < 0.00001);
            Assert.IsTrue(Math.Abs(2.080482 - WordRemoteness.CalculateInLetters(fmchain1)) < 0.00001);
        }

        [TestMethod]
        [Ignore]
        public void TestWordGamut()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.IsTrue(Math.Abs(0.5 - WordRemoteness.CalculateInWords(fmchain1)) < 0.000001);
            Assert.IsTrue(Math.Abs(1.5 - WordRemoteness.CalculateInLetters(fmchain1)) < 0.000001);
        }
    }
}
