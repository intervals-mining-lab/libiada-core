namespace LibiadaMusic.Characteristics
{
    using System;
    using LibiadaMusic.BorodaDivider;

    /// <summary>
    /// средняя длина ф-мотива для моно цепи.
    /// </summary>
    public static class AverageLength
    {
        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if chain doesn't contain fmotives.
        /// </exception>
        public static double Calculate(FmotivChain chain)
        {
            if (chain.FmotivList.Count < 1)
            {
                throw new Exception("Unable to count average length with no elements in chain!");
            }

            int noteCount = 0; // счетчик нот всей цепочки фмотивов

            foreach (Fmotiv fmotiv in chain.FmotivList)
            {
                // заполняем счетчик складывая кол-во поф-мотивно
                noteCount = noteCount + fmotiv.TieGathered().PauseTreatment((int)ParamPauseTreatment.Ignore).NoteList.Count;
            }

            return (double)noteCount / chain.FmotivList.Count;
        }
    }
}
