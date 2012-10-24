using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;
using MDA.OIP.ScoreModel;

namespace MDATest.OIPTest.BorodaDivider
{
    [TestClass]
    public class TestFmotivIdentificator
    {

        [TestMethod]
        public void TestFmotivIdentification1()
        {
            // создание ф-мотивов
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");
            Fmotiv fmotiv3 = new Fmotiv("ПМТ");
            Fmotiv fmotiv4 = new Fmotiv("ПМТ");
            Fmotiv fmotiv5 = new Fmotiv("ПМТ");
            Fmotiv fmotiv6 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv4.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv5.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv5.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv6.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv6.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(6);
            fmchain1.Name = "track1";
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            fmchain1.Add(fmotiv3, 2);
            fmchain1.Add(fmotiv4, 3);
            fmchain1.Add(fmotiv5, 4);
            fmchain1.Add(fmotiv6, 5);

            FmotivIdentificator fmid = new FmotivIdentificator();
            //        FmotivChain fmidentedchain = new FmotivChain();
            Assert.AreEqual(1,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[0]);
            Assert.AreEqual(2,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[1]);
            Assert.AreEqual(2,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[2]);
            Assert.AreEqual(2,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[3]);
            Assert.AreEqual(1,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[4]);
            Assert.AreEqual(1,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[5]);

        }

        [TestMethod]
        public void TestFmotivIdentification2()
        {
            // создание ф-мотивов
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");
            Fmotiv fmotiv3 = new Fmotiv("ПМТ");
            Fmotiv fmotiv4 = new Fmotiv("ПМТ");
            Fmotiv fmotiv5 = new Fmotiv("ПМТ");
            Fmotiv fmotiv6 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv4.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv5.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv5.NoteList.Add(new ValueNote(new Pitch(3, 'C', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv6.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv6.NoteList.Add(new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(6);
            fmchain1.Name = "track1";
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            fmchain1.Add(fmotiv3, 2);
            fmchain1.Add(fmotiv4, 3);
            fmchain1.Add(fmotiv5, 4);
            fmchain1.Add(fmotiv6, 5);

            FmotivIdentificator fmid = new FmotivIdentificator();
            //        FmotivChain fmidentedchain = new FmotivChain();
            Assert.AreEqual(1,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[0]);
            Assert.AreEqual(1,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[1]);
            Assert.AreEqual(1,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[2]);
            Assert.AreEqual(2,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[3]);
            Assert.AreEqual(3,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[4]);
            Assert.AreEqual(4,
                            fmid.GetIdentification(fmchain1, PauseTreatment.Ignore, FMSequentEquality.Sequent).
                                Building[5]);

        }
    }
}
