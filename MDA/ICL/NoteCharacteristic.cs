using System;
using System.Collections.Generic;
using MDA.OIP.BorodaDivider;
using LibiadaCore.Classes.Root;
using MDA.OIP.ScoreModel;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace MDA.ICL
{
    public static class NoteCharacteristic
    {
        /// <summary>
        /// удаленность между буквами в буквах
        /// </summary>
        private static double valR = 0;

        /// <summary>
        /// глубина в буквах
        /// </summary>
        private static double valG = 0;

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
                throw new Exception("Unaible to count note remoteness with no elements in chain!");

            List<Note> notelist = new List<Note>(); // список нот, класса Note, всей цепи фмотивов

            foreach (Fmotiv fmotiv in FmChain.FmotivList)
            {
                foreach (Note note in fmotiv.TieGathered().Clone(PauseTreatment.Ignore).NoteList)
                {
                    notelist.Add((Note) note.Clone());
                }
            }

            Chain notechain = new Chain(notelist.Count);
            for (int i = 0; i < notelist.Count; i++)
            {
                double ostatok = 0;
                double midi = notelist[i].Pitch.Midinumber;

                ostatok = midi - 12*Math.Truncate(midi/12);

                //TODO: переделать нормально чтоб цепочка складывалась из ValueNote, а не как попало

                notechain[i] = new ValueString(Convert.ToString(notelist[i].Pitch.Midinumber) + " " +
                                               Convert.ToString(notelist[i].Duration.Value*10000000));


                /*
                Вариант когда ноты различимы только по ступени, не важно в какой октаве 
                                
                notechain[i] = new ValueString(Convert.ToString(Math.Round(ostatok)) + " " + 
                    Convert.ToString(notelist[i].Duration.Value*10000000));
                */
            }

            Characteristic R = new Characteristic(new AverageRemoteness());
            valR = R.Value(notechain, LinkUp.End);

            Characteristic G = new Characteristic(new Depth());
            valG = G.Value(notechain, LinkUp.End);

            return true;
        }
    }
}
