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
    public class TestFmotivDivider
    {
        [TestMethod]
        public void TestFmotivDivider1() 
        {
            #region Creating Uniformscoretrack - unitrack
            // Создание атрибутов для такта
            Attributes attributes1 = new Attributes(new Size(7, 8, 1024), new Key(0, "major"));
            // Создание списков нот для каждого из 4 тактов
            List<Note> notes1 = new List<Note>();
            notes1.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 2, false, 2048), false, Tie.None));
            notes1.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes1.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes1.Add(new Note(new Pitch(3, 'F', 0), new Duration(1, 8, false, 512), false, Tie.Start));
            List<Note> notes2 = new List<Note>();
            notes2.Add(new Note(new Pitch(3, 'F', 0), new Duration(1, 8, false, 512), false, Tie.Stop));
            notes2.Add(new Note(new Pitch(3, 'B', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes2.Add(new Note(new Pitch(3, 'G', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes2.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes2.Add(new Note(new Pitch(3, 'G', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes2.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes2.Add(new Note(new Pitch(2, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));
            List<Note> notes3 = new List<Note>();
            notes3.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(3, 'G', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(4, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(3, 'B', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(4, 'D', 0), new Duration(1, 8, true, 768), false, Tie.None));
            notes3.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 8, true, 768), false, Tie.None));
            notes3.Add(new Note(null, new Duration(1, 8, false, 512), false, Tie.None)); // паузы, поэтому null вместо Pitch
            List<Note> notes4 = new List<Note>();
            notes4.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(2, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(4, 'D', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(2, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'G', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None));
            //создание списка тактов для монофонического трека p0
            List<Measure> measures1 = new List<Measure>();
            measures1.Add(new Measure(notes1, (Attributes)attributes1.Clone()));
            measures1.Add(new Measure(notes2, (Attributes)attributes1.Clone()));
            measures1.Add(new Measure(notes3, (Attributes)attributes1.Clone()));
            measures1.Add(new Measure(notes4, (Attributes)attributes1.Clone()));
            //создание списка монофонического трека
            UniformScoreTrack unitrack = new UniformScoreTrack("track1", measures1);

            #endregion

            FmotivDivider fmdivider = new FmotivDivider();
            FmotivChain fmchain;
            fmchain = fmdivider.GetDivision(unitrack);
            fmchain.Id = 0;



        }
    }
}
