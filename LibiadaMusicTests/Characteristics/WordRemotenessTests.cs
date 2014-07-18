using System;
using LibiadaMusic.BorodaDivider;
using LibiadaMusic.Characteristics;
using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusic.Tests.Characteristics
{
    [TestClass]
    public class WordRemotenessTests
    {
        //TODO: add SetUp 

        // Переделать чтоб проверялось относительно привязки к концу!!! иначе не вполняются
        [TestMethod]
        public void WordRemotenessFirstTest() 
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.5 - WordRemoteness.CalculateInWords(chain)) < 0.000001);
            Assert.IsTrue(Math.Abs(1.5 - WordRemoteness.CalculateInLetters(chain)) < 0.000001);
        }

        [TestMethod]
        public void WordRemotenessSameTest()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0 - WordRemoteness.CalculateInWords(chain)) < 0.000001);
            Assert.IsTrue(Math.Abs(1 - WordRemoteness.CalculateInLetters(chain)) < 0.000001);
        }

        [TestMethod]
        public void WordRemotenessSecondTest()
        {
            var fmotiv1 = new Fmotiv("ПМТ",0);
            var fmotiv2 = new Fmotiv("ПМТ",1);
            var fmotiv3 = new Fmotiv("ПМТ",2);
            var fmotiv4 = new Fmotiv("ПМТ",3);

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
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            chain.FmotivList.Add(fmotiv3);
            chain.FmotivList.Add(fmotiv4);
            Assert.IsTrue(Math.Abs(1.146241 - WordRemoteness.CalculateInWords(chain)) < 0.00001);
            Assert.IsTrue(Math.Abs(2.226723 - WordRemoteness.CalculateInLetters(chain)) < 0.00001);
        }

        [TestMethod]
        public void WordRemotenessSameSecondTest()
        {
            var fmotiv1 = new Fmotiv("ПМТ",0);
            var fmotiv2 = new Fmotiv("ПМТ",1);
            var fmotiv3 = new Fmotiv("ПМТ",2);
            var fmotiv4 = new Fmotiv("ПМТ",3);

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
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            chain.FmotivList.Add(fmotiv3);
            chain.FmotivList.Add(fmotiv4);
            Assert.IsTrue(Math.Abs(1 - WordRemoteness.CalculateInWords(chain)) < 0.00001);
            Assert.IsTrue(Math.Abs(2.080482 - WordRemoteness.CalculateInLetters(chain)) < 0.00001);
        }

        [TestMethod]
        public void WordDepthTest()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.5 - WordRemoteness.CalculateInWords(chain)) < 0.000001);
            Assert.IsTrue(Math.Abs(1.5 - WordRemoteness.CalculateInLetters(chain)) < 0.000001);
        }
    }
}
