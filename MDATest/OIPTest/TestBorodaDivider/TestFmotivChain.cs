using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;
using MDA.OIP.ScoreModel;

namespace MDATest.OIPTest.TestBorodaDivider
{
    [TestClass]
    public class TestFmotivChain
    {
        [TestMethod]
        public void TestFmotivChain1() 
        {
            FmotivChain fmchain = new FmotivChain();
            fmchain.Id = 0;
            fmchain.FmotivList.Add(new Fmotiv(0,"ПМТ"));
            fmchain.FmotivList[0].NoteList.Add(new Note(new Pitch(0,'A',0),new Duration(1,4,false,480),false,Tie.None));
            fmchain.FmotivList[0].NoteList.Add(new Note(new Pitch(0,'B',0),new Duration(1,2,false,480),false,Tie.None));
            Assert.AreEqual(0, fmchain.FmotivList[0].Id);
            Assert.AreEqual('A',fmchain.FmotivList[0].NoteList[0].Pitch.Step);
            Assert.AreEqual('B', fmchain.FmotivList[0].NoteList[1].Pitch.Step);
        }

    }
}
