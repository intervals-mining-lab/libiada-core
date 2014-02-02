using System;
using LibiadaMusic.BorodaDivider;

namespace LibiadaMusic.Characteristics
{
    public static class TextWordDepth
    {
        /// <summary>
        /// глубина слов при чтении текста методом - по одинаковым словам, прочитываю всю длину каждого слова 
        /// иными словами удаленность одинаковых слов помноженная на длину слова
        /// </summary>
        private static double depth;
        private static double depthW;
        private static int vLen;

        private static bool Calculate(FmotivChain chain)
        {
            if (chain.FmotivList.Count < 1)
                throw new Exception("Unable to count text word depth with no elements in chain!");

            // Составление словаря из ф-мотивов
            var fmLex = new FmotivChain();
            // словарь в виде цепочки из уникальных объектов, по порядку возрастанияя индекса

            // заполнение словаря уникальными фмотивами

            for (int i = 0; i < chain.FmotivList.Count; i++)
            {
                bool uniq = true; // флаг уникальности фмотива, для его дальнейшего занесения в словарь

                for (int j = 0; j < fmLex.FmotivList.Count; j++)
                {
                    if (chain.FmotivList[i].Equals(fmLex.FmotivList[j]))
                    {
                        uniq = false;
                    }
                }

                if (uniq)
                {
                    fmLex.FmotivList.Add((Fmotiv) chain.FmotivList[i].Clone());
                }

                uniq = true;
            }

            // подсчет значения используя: строй (цепь идентификаторов), алфавит - из которого вытаскивается длина слова, конкретной однородной знаковой цепи

            double giVal = 0; // глубина одной i-ой однородной цепи
            double gVal = 0;
            // глубина всей цепи, прочитаной словами = Сумма по i: длина i-ого слова * (Gival  - уже в лог масштабе)
            double giWVal = 0; // глубина в штуках слов для i-ой
            double gwVal = 0; // глубина в штуках слов

            /*   
            * цикл по фмотивам, в нем
            сделать цикл провреки по айдишкам, по айдишкам из словаря вытаскивать длину, множить для каждой цепи уже логарифм интервал, складывать, 
            потом сумму для каждой цепи умножать на длину фмотива для которого искалась глубина
            * 
            * все в кучу складывать покамесь
            */

            // TODO: к чему привязка????????????????????????

            for (int m = 0; m < fmLex.FmotivList.Count; m++)
            {
                int interval = 0; // интервал в буквах между двумя словами одинаковыми
                int intervalW = 0; // интервал в словах между двумя словами одинаковыми
                for (int i = 0; i < chain.FmotivList.Count; i++)
                {
                    //накполение интервала, сложение букв фмотивов
                    interval = interval +
                               chain.FmotivList[chain.FmotivList.Count - 1 - i].PauseTreatment(
                                   (int) ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;
                    // накопление интервала слов
                    intervalW = intervalW + 1;

                    if (chain.FmotivList[chain.FmotivList.Count - 1 - i].Equals(fmLex.FmotivList[m]))
                    {
                        giVal = giVal + Math.Log(interval, 2); // при сложении логарифмов интервалов в буквах
                        giWVal = giWVal + Math.Log(intervalW, 2); // при сложении логарифмов интервалов в словах;
                        intervalW = 0;
                        // обнуляем накопление слов для подсчета рассотяния другог одинакового следующего слова
                        interval = 0;
                        // обнуляем накопление букв для подсчета рассотяния другог одинакового следующего слова
                    }

                }

                gVal = gVal +giVal*fmLex.FmotivList[m].PauseTreatment((int) ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;
                gwVal = gwVal +giWVal*fmLex.FmotivList[m].PauseTreatment((int) ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;

                giVal = 0; // для след однородной цепи - обнуляем что считать заново
                giWVal = 0; // для след однородной цепи - обнуляем что считать заново
            }
            depth = gVal;
            depthW = gwVal;

            // длина словаря
            vLen = 0;
            for (int i = 0; i < fmLex.FmotivList.Count; i++)
            {
                vLen = vLen + fmLex.FmotivList[i].PauseTreatment((int) ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;
            }
            return true;
        }
    }
}