using System;
using LibiadaMusic.BorodaDivider;
using LibiadaMusic.Characteristics;
using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusic.Tests.Characteristics
{
    [TestClass]
    public class WithinWordRemotenessTests
    {
        [TestMethod]
        public void WithinWordRemotenessFirstTest()
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
            Assert.IsTrue(Math.Abs(0.5 - WithinWordRemoteness.Calculate(chain)) < 0.000001);
        }

        [TestMethod]
        public void WithinWordRemotenessSecondTest()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.597493 - WithinWordRemoteness.Calculate(chain)) < 0.000001);
        }

        [TestMethod]
        public void WithinWordRemotenessThirdTest()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.Start));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.Stop));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.625 - WithinWordRemoteness.Calculate(chain)) < 0.000001);
        }
    }
}
