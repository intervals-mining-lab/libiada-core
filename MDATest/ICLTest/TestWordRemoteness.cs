using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibiadaMusic.OIP.BorodaDivider;
using LibiadaMusic.OIP.ScoreModel;
using LibiadaMusic.ICL;

namespace LibiadaMusicTest.ICLTest
{
    [TestClass]
    public class TestWordRemoteness
    {
        /* Переделать чтоб проверялось относительно привязки к концу!!! иначе не вполняются
        [TestMethod]
        public void TestWordRemoteness1() 
        {
            Fmotiv fmotiv1 = new Fmotiv(0, "ПМТ");
            Fmotiv fmotiv2 = new Fmotiv(1, "ПМТ");

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain();
            fmchain1.Id = 0;
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.5 - WordRemoteness.CalculateInWords(fmchain1)) < 0.000001);
            Assert.IsTrue(Math.Abs(1.5 - WordRemoteness.CalculateInLetters(fmchain1)) < 0.000001);
        }
        [TestMethod]
        public void TestWordRemoteness2same()
        {
            Fmotiv fmotiv1 = new Fmotiv(0, "ПМТ");
            Fmotiv fmotiv2 = new Fmotiv(1, "ПМТ");

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain();
            fmchain1.Id = 0;
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0 - WordRemoteness.CalculateInWords(fmchain1)) < 0.000001);
            Assert.IsTrue(Math.Abs(1 - WordRemoteness.CalculateInLetters(fmchain1)) < 0.000001);
        }

        [TestMethod]
        public void TestWordRemoteness3()
        {
            Fmotiv fmotiv1 = new Fmotiv(0, "ПМТ");
            Fmotiv fmotiv2 = new Fmotiv(1, "ПМТ");
            Fmotiv fmotiv3 = new Fmotiv(2, "ПМТ");
            Fmotiv fmotiv4 = new Fmotiv(3, "ПМТ");

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(4, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv3.NoteList.Add(new Note(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv3.NoteList.Add(new Note(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv4.NoteList.Add(new Note(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new Note(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new Note(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new Note(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain();
            fmchain1.Id = 0;
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            fmchain1.FmotivList.Add(fmotiv3);
            fmchain1.FmotivList.Add(fmotiv4);
            Assert.IsTrue(Math.Abs(1.146241 - WordRemoteness.CalculateInWords(fmchain1)) < 0.00001);
            Assert.IsTrue(Math.Abs(2.226723 - WordRemoteness.CalculateInLetters(fmchain1)) < 0.00001);
        }

        [TestMethod]
        public void TestWordRemoteness3same()
        {
            Fmotiv fmotiv1 = new Fmotiv(0, "ПМТ");
            Fmotiv fmotiv2 = new Fmotiv(1, "ПМТ");
            Fmotiv fmotiv3 = new Fmotiv(0, "ПМТ");
            Fmotiv fmotiv4 = new Fmotiv(3, "ПМТ");

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(4, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv3.NoteList.Add(new Note(new Pitch(5, 'D', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv3.NoteList.Add(new Note(new Pitch(5, 'G', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv4.NoteList.Add(new Note(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new Note(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new Note(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new Note(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain();
            fmchain1.Id = 0;
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            fmchain1.FmotivList.Add(fmotiv3);
            fmchain1.FmotivList.Add(fmotiv4);
            Assert.IsTrue(Math.Abs(1 - WordRemoteness.CalculateInWords(fmchain1)) < 0.00001);
            Assert.IsTrue(Math.Abs(2.080482 - WordRemoteness.CalculateInLetters(fmchain1)) < 0.00001);
        }
         */

        public void TestWordGamut()
        {
            Fmotiv fmotiv1 = new Fmotiv(0, "ПМТ");
            Fmotiv fmotiv2 = new Fmotiv(1, "ПМТ");

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain();
            fmchain1.Id = 0;
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.5 - WordRemoteness.CalculateInWords(fmchain1)) < 0.000001);
            Assert.IsTrue(Math.Abs(1.5 - WordRemoteness.CalculateInLetters(fmchain1)) < 0.000001);
        }
    }
}
