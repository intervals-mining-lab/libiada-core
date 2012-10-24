using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;
using MDA.OIP.ScoreModel;

namespace MDATest.OIPTest.BorodaDivider
{
    [TestClass]
    public class TestFmotivChain
    {
        [TestMethod]
        public void TestFmotivChain1()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(0, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(0, 'B', 0), new Duration(1, 2, false, 480), false, Tie.None));

            FmotivChain fmchain = new FmotivChain(1);
            fmchain.Add(fmotiv1, 0);
            Assert.AreEqual('A', ((Fmotiv)fmchain[0]).NoteList[0].Pitch.Step);
            Assert.AreEqual('B', ((Fmotiv)fmchain[0]).NoteList[1].Pitch.Step);
        }

        [TestMethod]
        public void TestFmotivChainEquals1()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);

            FmotivChain fmchain2 = new FmotivChain(2);
            fmchain2.Add(fmotiv1, 0);
            fmchain2.Add(fmotiv2, 1);

            FmotivChain fmchain3 = new FmotivChain(2);
            fmchain3.Add(fmotiv2, 0);
            fmchain3.Add(fmotiv2, 1);

            FmotivChain fmchain4 = new FmotivChain(2);
            fmchain4.Add(fmotiv1, 0);
            fmchain4.Add(fmotiv1, 1);

            Assert.IsTrue(fmchain1.Equals(fmchain2));
            Assert.IsFalse(fmchain1.Equals(fmchain3));
            Assert.IsFalse(fmchain1.Equals(fmchain4));

        }
    }
}
