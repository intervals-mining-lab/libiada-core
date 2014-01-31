using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using MDA.OIP.BorodaDivider;
using MDA.OIP.ScoreModel;

namespace MDA.ICL
{
    public static class WithinWordRemoteness
    {
        // удаленность внутри слов
        // среднее арифметическое средней удаленности слова среди всех слов цепи [в буквах]
        static public double Calculate(FmotivChain FmChain) 
        {
            if (FmChain.FmotivList.Count < 1) throw new Exception("Unaible to count within word remoteness with no elements in chain!");

            double ArRemVal = 0; // среднее арифметическое средней удаленности слова
            string temp; // строка для временного хранения набора высот

            foreach (Fmotiv fmotiv in FmChain.FmotivList)
            {
                Chain notechain = new Chain(fmotiv.PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList.Count);
                for (int i = 0; i < fmotiv.PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList.Count; i++)
                {
                    temp = "";
                    foreach (Pitch pitch in fmotiv.PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList[i].Pitch)
                    {
                        temp += Convert.ToString(pitch.Midinumber);
                    }
                    //TODO: переделать нормально чтоб цепочка складывалась из ValueNote, а не как попало
                    notechain[i] = new ValueString(temp + " " +
                        Convert.ToString(fmotiv.PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList[i].Duration.Value * 10000000));
                }

                Characteristic R = new Characteristic(new Depth());
                double val = R.Value(notechain, Link.Start);

                ArRemVal = ArRemVal + val;
            }

            ArRemVal = ArRemVal / FmChain.FmotivList.Count;  // берем среднее от суммы всех удаленностей слов

            return ArRemVal;
        }

    }
}
