using System;
using System.Collections.Generic;
using System.Text;
using MDA.OIP.BorodaDivider;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;

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

            foreach (Fmotiv fmotiv in FmChain.FmotivList)
            {
                Chain notechain = new Chain(fmotiv.PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList.Count);
                for (int i = 0; i < fmotiv.PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList.Count; i++)
                {
                    //TODO: переделать нормально чтоб цепочка складывалась из ValueNote, а не как попало
                    notechain[i] = new ValueString(Convert.ToString(fmotiv.PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList[i].Pitch[0].Midinumber) + " " +
                        Convert.ToString(fmotiv.PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList[i].Duration.Value * 10000000));
                }

                Characteristic R = new Characteristic(new Gamut());
                double val = R.Value(notechain, LinkUp.Start);

                ArRemVal = ArRemVal + val;
            }

            ArRemVal = ArRemVal / FmChain.FmotivList.Count;  // берем среднее от суммы всех удаленностей слов

            return ArRemVal;
        }

    }
}
