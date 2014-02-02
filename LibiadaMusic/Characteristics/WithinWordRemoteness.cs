using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaMusic.BorodaDivider;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.Characteristics
{
    /// <summary>
    /// удаленность внутри слов
    /// </summary>
    public static class WithinWordRemoteness
    {
        /// <summary>
        /// среднее арифметическое средней удаленности слова среди всех слов цепи [в буквах]
        /// </summary>
        /// <param name="chain"></param>
        /// <returns></returns>
        public static double Calculate(FmotivChain chain)
        {
            if (chain.FmotivList.Count < 1)
                throw new Exception("Unable to count within word remoteness with no elements in chain!");

            double arRemVal = 0; // среднее арифметическое средней удаленности слова
            string temp; // строка для временного хранения набора высот

            foreach (Fmotiv fmotiv in chain.FmotivList)
            {
                var noteChain =
                    new Chain(fmotiv.PauseTreatment((int) ParamPauseTreatment.Ignore).TieGathered().NoteList.Count);
                for (int i = 0;
                    i < fmotiv.PauseTreatment((int) ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;
                    i++)
                {
                    temp = String.Empty;
                    foreach (Pitch pitch in fmotiv.PauseTreatment((int) ParamPauseTreatment.Ignore).TieGathered().NoteList[i].Pitch)
                    {
                        temp += Convert.ToString(pitch.MidiNumber);
                    }
                    //TODO: переделать нормально чтоб цепочка складывалась из ValueNote, а не как попало
                    noteChain[i] = new ValueString(temp + " " + Convert.ToString(fmotiv.PauseTreatment((int) ParamPauseTreatment.Ignore).TieGathered().NoteList[i].Duration.Value*10000000));
                }
                double val = new Depth().Calculate(noteChain, Link.Start);

                arRemVal = arRemVal + val;
            }

            arRemVal = arRemVal/chain.FmotivList.Count; // берем среднее от суммы всех удаленностей слов

            return arRemVal;
        }
    }
}