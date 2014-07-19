using System;
using LibiadaMusic.BorodaDivider;
using LibiadaMusic.Characteristics;
using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusic.Tests.Characteristics
{
    [TestClass]
    public class NoteRemotenessTests
    {
        [TestMethod]
        public void ValueNoteRemotenessTest()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.75 - NoteCharacteristic.CalculateRemoteness(chain)) < 0.000001);
        }

        [TestMethod]
        public void ValueNoteRemotenessPauseTest()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote((Pitch) null, new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.75 - NoteCharacteristic.CalculateRemoteness(chain)) < 0.000001);
        }

        [TestMethod]
        public void ValueNoteRemotenessTieTest()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 2, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.Start));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.Stop));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(0.75 - NoteCharacteristic.CalculateRemoteness(chain)) < 0.000001);
        }

        [TestMethod]
        public void ValueNoteRemotenessOctTest()
        {
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(2, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 2, false, 512), false, Tie.None));

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 2, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var chain = new FmotivChain {Id = 0};
            chain.FmotivList.Add(fmotiv1);
            chain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(Math.Abs(1.14624062 - NoteCharacteristic.CalculateRemoteness(chain)) < 0.000001);
        }
    }
}