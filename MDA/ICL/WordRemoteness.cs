using System;
using MDA.OIP.BorodaDivider;

namespace MDA.ICL
{
    public static class WordRemoteness
    {
        /// <summary>
        /// удаленность в словах между словами
        /// </summary>
        private static double InWordRem = 0;

        /// <summary>
        /// удаленность в буквах между словами
        /// </summary>
        private static double InLettersRem = 0;

        /// <summary>
        /// глубина всего текста если читать по словам в буквах
        /// </summary>
        private static double TextGamut = 0;

        public static double CalculateInWords(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return InWordRem;
            throw new Exception("Word Remoteness in words not calculated, ask specialist!");
        }

        public static double CalculateInLetters(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return InLettersRem;
            throw new Exception("Word Remoteness in letters not calculated, ask specialist!");
        }

        public static double CalculateTextGamut(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return TextGamut;
            throw new Exception("Text Gamut in letters not calculated, ask specialist!");
        }

        private static bool Calculate(FmotivChain FmChain)
        {
            double V = 0; // объем цепи в буквах
            double Vj = 0; // объем цепи в словах
            double Vg = 0; // глубина цепи в буквах

            if (FmChain.Length < 1)
                throw new Exception("Unaible to count word remoteness with no elements in chain!");

            for (int i = 0; i < FmChain.Length; i++)
            {
                int j = 0; // счетчик для поиска предыдущего такого же элемента, либо начала цепи
                int deltaV = 0; // счетчик для сложения нот очередного интервала

                do
                {
                    Fmotiv current = ((Fmotiv) FmChain[FmChain.Length - 1 - i - j]).Clone(PauseTreatment.Ignore);
                    deltaV = deltaV + current.TieGathered().NoteList.Count;
                    // умножаем общий объем на буквенное рассояние текущего (уходящего на 1 слово назад, в случаях не нахождения такого слова) слова
                    j = j + 1; // увеличиваем счетчик предыдущего

                } while (((i + j) < FmChain.Length - 1) && (!(FmChain[FmChain.Length - 1 - i].Equals(FmChain[FmChain.Length - 1 - i - j]))));

                Vg = Vg + Math.Log(deltaV, 2)*((Fmotiv)FmChain[FmChain.Length - 1 - i]).NoteList.Count;
                // при сложении логарифмов интервалов,
                // мы еще умножаем каждый интервал между двумя одинаковыми словами на длину этого слова
                V = V + Math.Log(deltaV, 2);
                Vj = Vj + Math.Log(j, 2); // умножаем объем слов на интервал между одинаковыми словами
            }

            InWordRem = Vj/FmChain.Length;
            InLettersRem = V/FmChain.Length;
            TextGamut = Vg;

            return true;
        }
    }
}
