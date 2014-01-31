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
            FmotivChain fmchain = new FmotivChain();
            fmchain.Id = 0;
            fmchain.FmotivList.Add(new Fmotiv(0, "ПМТ"));
            fmchain.FmotivList[0].NoteList.Add(new Note(new Pitch(0, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None));
            fmchain.FmotivList[0].NoteList.Add(new Note(new Pitch(0, 'B', 0), new Duration(1, 2, false, 480), false, Tie.None));
            Assert.AreEqual(0, fmchain.FmotivList[0].Id);
            Assert.AreEqual('A', fmchain.FmotivList[0].NoteList[0].Pitch[0].Step);
            Assert.AreEqual('B', fmchain.FmotivList[0].NoteList[1].Pitch[0].Step);
        }

        [TestMethod]
        public void TestFmotivChainEquals1()
        {
            Fmotiv fmotiv1 = new Fmotiv(0, "ПМТ");
            Fmotiv fmotiv2 = new Fmotiv(1, "ПМТ");

            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain();
            fmchain1.Id = 0;
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);

            FmotivChain fmchain2 = new FmotivChain();
            fmchain2.Id = 0;
            fmchain2.FmotivList.Add(fmotiv1);
            fmchain2.FmotivList.Add(fmotiv2);

            FmotivChain fmchain3 = new FmotivChain();
            fmchain3.Id = 1;
            fmchain3.FmotivList.Add(fmotiv1);
            fmchain3.FmotivList.Add(fmotiv2);

            FmotivChain fmchain4 = new FmotivChain();
            fmchain3.Id = 0;
            fmchain3.FmotivList.Add(fmotiv2);
            fmchain3.FmotivList.Add(fmotiv2);

            Assert.IsTrue(fmchain1.Equals(fmchain2));
            Assert.IsFalse(fmchain1.Equals(fmchain3));
            Assert.IsFalse(fmchain1.Equals(fmchain4));

        }
    }
}
