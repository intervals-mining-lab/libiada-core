using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaMusic.BorodaDivider;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.Characteristics
{
    public static class NoteCharacteristic
    {
        private static double valR; // удаленность между буквами в буквах
        private static double valG; // глубина в буквах

        public static double CalculateRemoteness(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return valR;
            throw new Exception("Word Remoteness in words not calculated, ask specialist!");
        }

        public static double CalculateGamut(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return valG;
            throw new Exception("TextGamut in words not calculated, ask specialist!");
        }

        private static bool Calculate(FmotivChain FmChain)
        {
            if (FmChain.FmotivList.Count < 1)
                throw new Exception("Unable to count note remoteness with no elements in chain!");

            var notelist = new List<Note>(); // список нот, класса Note, всей цепи фмотивов

            foreach (Fmotiv fmotiv in FmChain.FmotivList)
            {
                foreach (Note note in fmotiv.TieGathered().PauseTreatment((int) ParamPauseTreatment.Ignore).NoteList)
                {
                    notelist.Add((Note) note.Clone());
                }
            }

            var noteChain = new Chain(notelist.Count);
            for (int i = 0; i < notelist.Count; i++)
            {
                string temp = String.Empty; // строка для временного хранения набора высот

                foreach (Pitch pitch in notelist[i].Pitch)
                {
                    temp += Convert.ToString(pitch.MidiNumber);
                }

                //TODO: переделать нормально чтоб цепочка складывалась из ValueNote, а не как попало

                noteChain[i] = new ValueString(temp + " " + Convert.ToString(notelist[i].Duration.Value*10000000));
            }

            var R = new Characteristic(new AverageRemoteness());
            valR = R.Value(noteChain, Link.End);

            var G = new Characteristic(new Depth());
            valG = G.Value(noteChain, Link.End);

            return true;
        }
    }
}
