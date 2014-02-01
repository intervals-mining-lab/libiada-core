using LibiadaMusic.BorodaDivider;
using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTest.BorodaDivider
{
    [TestClass]
    public class FmotivChainTest
    {
        [TestMethod]
        public void TestFmotivChain1()
        {
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(new Fmotiv("ПМТ", 0));
            chain.FmotivList[0].NoteList.Add(new Note(new Pitch(0, 'A', 0), new Duration(1, 4, false, 480), false,
                Tie.None));
            chain.FmotivList[0].NoteList.Add(new Note(new Pitch(0, 'B', 0), new Duration(1, 2, false, 480), false,
                Tie.None));
            Assert.AreEqual(0, chain.FmotivList[0].Id);
            Assert.AreEqual('A', chain.FmotivList[0].NoteList[0].Pitch[0].Step);
            Assert.AreEqual('B', chain.FmotivList[0].NoteList[1].Pitch[0].Step);
        }

        [TestMethod]
        public void TestFmotivChainEquals1()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var firstChain = new FmotivChain {Id = 0};
            firstChain.FmotivList.Add(fmotiv1);
            firstChain.FmotivList.Add(fmotiv2);

            var secondChain = new FmotivChain {Id = 0};
            secondChain.FmotivList.Add(fmotiv1);
            secondChain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(firstChain.Equals(secondChain));

            secondChain = new FmotivChain {Id = 1};
            secondChain.FmotivList.Add(fmotiv1);
            secondChain.FmotivList.Add(fmotiv2);
            Assert.IsFalse(firstChain.Equals(secondChain));

            secondChain = new FmotivChain {Id = 0};
            secondChain.FmotivList.Add(fmotiv2);
            secondChain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(firstChain.Equals(secondChain));

            secondChain = new FmotivChain {Id = 1};
            secondChain.FmotivList.Add(fmotiv2);
            secondChain.FmotivList.Add(fmotiv2);
            Assert.IsFalse(firstChain.Equals(secondChain));
        }
    }
}