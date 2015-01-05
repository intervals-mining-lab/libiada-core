namespace LibiadaMusic.Characteristics
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;
    using LibiadaCore.Core.SimpleTypes;

    using LibiadaMusic.BorodaDivider;
    using LibiadaMusic.ScoreModel;

    /// <summary>
    /// The note characteristic.
    /// </summary>
    public static class NoteCharacteristic
    {
        /// <summary>
        /// удаленность между буквами в буквах
        /// </summary>
        private static double valR;

        /// <summary>
        /// глубина в буквах
        /// </summary>
        private static double valG;

        /// <summary>
        /// The calculate remoteness.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public static double CalculateRemoteness(FmotivChain chain)
        {
            if (Calculate(chain))
            {
                return valR;
            }

            throw new Exception("Word Remoteness in words not calculated, ask specialist!");
        }

        /// <summary>
        /// The calculate depth.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public static double CalculateDepth(FmotivChain chain)
        {
            if (Calculate(chain))
            {
                return valG;
            }

            throw new Exception("TextDepth in words not calculated, ask specialist!");
        }

        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if chain doesn't contain fmotives.
        /// </exception>
        private static bool Calculate(FmotivChain chain)
        {
            if (chain.FmotivList.Count < 1)
            {
                throw new Exception("Unable to count note remoteness with no elements in chain!");
            }

            var noteList = new List<ValueNote>(); // список нот, класса Note, всей цепи фмотивов

            foreach (Fmotiv fmotiv in chain.FmotivList)
            {
                foreach (ValueNote note in fmotiv.TieGathered().PauseTreatment((int)ParamPauseTreatment.Ignore).NoteList)
                {
                    noteList.Add((ValueNote)note.Clone());
                }
            }

            var noteChain = new Chain(noteList.Count);
            for (int i = 0; i < noteList.Count; i++)
            {
                string temp = string.Empty; // строка для временного хранения набора высот

                foreach (Pitch pitch in noteList[i].Pitch)
                {
                    temp += Convert.ToString(pitch.MidiNumber);
                }

                // TODO: переделать нормально чтоб цепочка складывалась из ValueNote, а не как попало
                noteChain[i] = new ValueString(temp + " " + Convert.ToString(noteList[i].Duration.Value * 10000000));
            }

            valR = new AverageRemoteness().Calculate(noteChain, Link.End);
            valG = new Depth().Calculate(noteChain, Link.End);
            return true;
        }
    }
}
