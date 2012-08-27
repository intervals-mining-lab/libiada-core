using System;
using MDA.OIP.BorodaDivider;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace MDA.ICL
{
    /// <summary>
    /// удаленность внутри слов
    /// </summary>
    public static class WithinWordRemoteness
    {
        /// <summary>
        /// среднее арифметическое средней удаленности слова среди всех слов цепи [в буквах]
        /// </summary>
        /// <param name="fmChain"></param>
        /// <returns></returns>
        public static double Calculate(FmotivChain fmChain)
        {
            if (fmChain.FmotivList.Count < 1)
            {throw new Exception("Unaible to count within word remoteness with no elements in chain!");}

            double ArRemVal = 0; // среднее арифметическое средней удаленности слова

            foreach (Fmotiv fmotiv in fmChain.FmotivList)
            {
                Chain notechain =
                    new Chain(fmotiv.Clone(PauseTreatment.Ignore).TieGathered().NoteList.Count);
                for (int i = 0; i < fmotiv.Clone(PauseTreatment.Ignore).TieGathered().NoteList.Count; i++)
                {
                    //TODO: переделать нормально чтоб цепочка складывалась из ValueNote, а не как попало
                    notechain[i] =
                        new ValueString(
                            Convert.ToString(
                                fmotiv.Clone(PauseTreatment.Ignore).TieGathered().NoteList[i].Pitch.
                                    Midinumber) + " " +
                            Convert.ToString(
                                fmotiv.Clone(PauseTreatment.Ignore).TieGathered().NoteList[i].Duration.
                                    Value*10000000));
                }

                Characteristic R = new Characteristic(new Depth());
                double val = R.Value(notechain, LinkUp.Start);

                ArRemVal = ArRemVal + val;
            }

            ArRemVal = ArRemVal/fmChain.FmotivList.Count; // берем среднее от суммы всех удаленностей слов

            return ArRemVal;
        }

    }
}
