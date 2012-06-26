using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.ScoreModel;

namespace MDATest.OIPTest.TestScoreModel
{
    [TestClass]
    public class TestNote1
    {
        [TestMethod]
        public void TestNoteEquals1() 
        {
            Note note1 = new Note(new Pitch(1,'A',0),new Duration(1,4,false,480),false,Tie.None);

            Note note2 = new Note(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.Start);

            Assert.IsTrue(!note1.Equals(note2));
        }

        [TestMethod]
        public void TestNoteEquals2()
        {
            Note note1 = new Note(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None);

            Note note2 = new Note(new Pitch(1, 'B', -2), new Duration(1, 4, false, 480), false, Tie.None);

            Assert.IsTrue(note1.Equals(note2));
        }

        [TestMethod]
        public void TestNoteClone1()
        {
            Note note1 = new Note(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.Stop);

            Note note2 =  (Note)note1.Clone();

            Assert.IsTrue(note1.Equals(note2));
        }
    }
}
