using System;
using System.Collections.Generic;
using MDA.OIP.BorodaDivider;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using MDA.OIP.ScoreModel;

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
            if (fmChain.Length < 1)
            {throw new Exception("Unaible to count within word remoteness with no elements in chain!");}

            double ArRemVal = 0; // среднее арифметическое средней удаленности слова

            for (int j = 0; j < fmChain.Length; j++)
            {
                Fmotiv fmotiv = ((Fmotiv)fmChain[j]).Clone(PauseTreatment.Ignore);

                List<ValueNote> noteList = fmotiv.TieGathered().NoteList;

                Chain notechain = new Chain(noteList.Count);
                for (int i = 0; i < noteList.Count; i++)
                {
                    //TODO: переделать нормально чтоб цепочка складывалась из ValueNote, а не как попало
                    notechain[i] = noteList[i];
                }

                Characteristic R = new Characteristic(new Depth());
                double val = R.Value(notechain, LinkUp.Start);

                ArRemVal = ArRemVal + val;
            }

            ArRemVal = ArRemVal/fmChain.Length; // берем среднее от суммы всех удаленностей слов

            return ArRemVal;
        }

    }
}
