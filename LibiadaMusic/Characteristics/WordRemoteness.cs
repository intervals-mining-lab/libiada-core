using System;
using LibiadaMusic.BorodaDivider;

namespace LibiadaMusic.Characteristics
{
    public static class WordRemoteness
    {
        /// <summary>
        /// удаленность в словах между словами
        /// </summary>
        private static double inWordRemoteness;
        /// <summary>
        /// удаленность в буквах между словами
        /// </summary>
        private static double inLettersRemoteness;
        /// <summary>
        /// глубина всего текста если читать по словам в буквах
        /// </summary>
        private static double textDepth;

        public static double CalculateInWords(FmotivChain chain)
        {
            if (Calculate(chain))
            {
                return inWordRemoteness;
            }
            throw new Exception("Word Remoteness in words not calculated, ask specialist!");
        }

        public static double CalculateInLetters(FmotivChain chain)
        {
            if (Calculate(chain))
            {
                return inLettersRemoteness;
            }
            throw new Exception("Word Remoteness in letters not calculated, ask specialist!");
        }

        public static double CalculateTextDepth(FmotivChain chain)
        {
            if (Calculate(chain))
            {
                return textDepth;
            }
            throw new Exception("Text Depth in letters not calculated, ask specialist!");
        }

        private static bool Calculate(FmotivChain chain)
        {
            double v = 0; // объем цепи в буквах
            double vj = 0; // объем цепи в словах
            double vg = 0; // глубина цепи в буквах

            if (chain.FmotivList.Count < 1)
                throw new Exception("Unable to count word remoteness with no elements in chain!");

            for (int i = 0; i < chain.FmotivList.Count; i++)
            {
                int j = 0; // счетчик для поиска предыдущего такого же элемента, либо начала цепи
                int deltaV = 0; // счетчик для сложения нот очередного интервала

                do
                {
                    deltaV = deltaV +
                             chain.FmotivList[chain.FmotivList.Count - 1 - i - j].PauseTreatment(
                                 (int) ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;
                    // умножаем общий объем на буквенное рассояние текущего (уходящего на 1 слово назад, в случаях не нахождения такого слова) слова
                    j = j + 1; // увеличиваем счетчик предыдущего

                } while (((i + j) < chain.FmotivList.Count - 1) &&
                         (!(chain.FmotivList[chain.FmotivList.Count - 1 - i].Equals(
                             chain.FmotivList[chain.FmotivList.Count - 1 - i - j]))));

                vg = vg + Math.Log(deltaV, 2)*chain.FmotivList[chain.FmotivList.Count - 1 - i].NoteList.Count;
                // при сложении логарифмов интервалов,
                //мы еще умножаем каждый интервал между двумя одинаковыми словами на длину этого слова
                v = v + Math.Log(deltaV, 2);
                vj = vj + Math.Log(j, 2); // умножаем объем слов на интервал между одинаковыми словами
            }

            inWordRemoteness = vj/chain.FmotivList.Count;
            inLettersRemoteness = v/chain.FmotivList.Count;
            textDepth = vg;
            return true;
        }
    }
}