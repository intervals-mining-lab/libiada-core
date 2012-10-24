using System;
using MDA.ICL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;
using MDA.OIP.ScoreModel;

namespace MDATest.ICL
{
    [TestClass]
    public class TestWithinWordRemoteness
    {
        [TestMethod]
        [Ignore]
        public void TestWithinWordRemoteness1()
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
            Assert.IsTrue(Math.Abs(0.5 - WithinWordRemoteness.Calculate(fmchain1)) < 0.000001);
        }
        [TestMethod]
        [Ignore]
        public void TestWithinWordRemoteness2()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.IsTrue(Math.Abs(0.597493 - WithinWordRemoteness.Calculate(fmchain1)) < 0.000001);
        }

        [TestMethod]
        [Ignore]
        public void TestWithinWordRemoteness3()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.Start));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.Stop));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.IsTrue(Math.Abs(0.625 - WithinWordRemoteness.Calculate(fmchain1)) < 0.000001);
        }
    }
}
