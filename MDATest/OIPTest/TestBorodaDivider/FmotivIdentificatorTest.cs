using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibiadaMusic.OIP.BorodaDivider;
using LibiadaMusic.OIP.ScoreModel;

namespace LibiadaMusicTest.OIPTest.TestBorodaDivider
{   [TestClass]
    public class FmotivIdentificatorTest
    {
    [TestMethod]
    public void TestFmotivIdentification1() 
    {
        // создание ф-мотивов
        Fmotiv fmotiv1 = new Fmotiv(0, "ПМТ");
        Fmotiv fmotiv2 = new Fmotiv(1, "ПМТ");
        Fmotiv fmotiv3 = new Fmotiv(2, "ПМТ");
        Fmotiv fmotiv4 = new Fmotiv(3, "ПМТ");
        Fmotiv fmotiv5 = new Fmotiv(4, "ПМТ");
        Fmotiv fmotiv6 = new Fmotiv(5, "ПМТ");

        fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

        fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv2.NoteList.Add(new Note(new Pitch(3, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));

        fmotiv3.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv3.NoteList.Add(new Note(new Pitch(3, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));

        fmotiv4.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv4.NoteList.Add(new Note(new Pitch(3, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));

        fmotiv5.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv5.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

        fmotiv6.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv6.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotivChain fmchain1 = new FmotivChain();
        fmchain1.Id = 0;
        fmchain1.Name = "track1";
        fmchain1.FmotivList.Add(fmotiv1);
        fmchain1.FmotivList.Add(fmotiv2);
        fmchain1.FmotivList.Add(fmotiv3);
        fmchain1.FmotivList.Add(fmotiv4);
        fmchain1.FmotivList.Add(fmotiv5);
        fmchain1.FmotivList.Add(fmotiv6);

        FmotivIdentificator fmid = new FmotivIdentificator();
//        FmotivChain fmidentedchain = new FmotivChain();
        Assert.AreEqual(0, fmid.GetIdentification(fmchain1,ParamPauseTreatment.Ignore,ParamEqualFM.Sequent).FmotivList[0].Id);
        Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[1].Id);
        Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[2].Id);
        Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[3].Id);
        Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[4].Id);
        Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[5].Id);

    }
    [TestMethod]
    public void TestFmotivIdentification2()
    {
        // создание ф-мотивов
        Fmotiv fmotiv1 = new Fmotiv(0, "ПМТ");
        Fmotiv fmotiv2 = new Fmotiv(1, "ПМТ");
        Fmotiv fmotiv3 = new Fmotiv(2, "ПМТ");
        Fmotiv fmotiv4 = new Fmotiv(3, "ПМТ");
        Fmotiv fmotiv5 = new Fmotiv(4, "ПМТ");
        Fmotiv fmotiv6 = new Fmotiv(5, "ПМТ");

        fmotiv1.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

        fmotiv2.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv2.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

        fmotiv3.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv3.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

        fmotiv4.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv4.NoteList.Add(new Note(new Pitch(3, 'B', 0), new Duration(1, 4, false, 512), false, Tie.None));

        fmotiv5.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv5.NoteList.Add(new Note(new Pitch(3, 'C', 0), new Duration(1, 4, false, 512), false, Tie.None));

        fmotiv6.NoteList.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
        fmotiv6.NoteList.Add(new Note(new Pitch(3, 'D', 0), new Duration(1, 4, false, 512), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotivChain fmchain1 = new FmotivChain();
        fmchain1.Id = 0;
        fmchain1.Name = "track1";
        fmchain1.FmotivList.Add(fmotiv1);
        fmchain1.FmotivList.Add(fmotiv2);
        fmchain1.FmotivList.Add(fmotiv3);
        fmchain1.FmotivList.Add(fmotiv4);
        fmchain1.FmotivList.Add(fmotiv5);
        fmchain1.FmotivList.Add(fmotiv6);

        FmotivIdentificator fmid = new FmotivIdentificator();
        //        FmotivChain fmidentedchain = new FmotivChain();
        Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[0].Id);
        Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[1].Id);
        Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[2].Id);
        Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[3].Id);
        Assert.AreEqual(2, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[4].Id);
        Assert.AreEqual(3, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent ).FmotivList[5].Id);

    }
    }
}
