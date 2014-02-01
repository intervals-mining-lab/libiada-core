using System;
using LibiadaMusic.BorodaDivider;

namespace LibiadaMusic.Characteristics
{
    public static class TextWordGamut
    {
        // глубина слов при чтении текста методом - по одинаковым словам, прочитываю всю длину каждого слова 
        // иными словами удаленность одинаковых слов помноженная на длину слова
        private static double Gamut;
        private static double GamutW;
        private static int Vlen;

        public static double CalculateTextWordGamut(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return Gamut;
            throw new Exception("Word Gamut in words not calculated, ask specialist!");
        }

        public static double CalculateVlen(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return Vlen;
            throw new Exception("Word Vlen in words not calculated, ask specialist!");
        }

        public static double CalculateTextWordGamutW(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return GamutW;
            throw new Exception("Word GamutW in words not calculated, ask specialist!");
        }


        private static bool Calculate(FmotivChain FmChain)
        {
            if (FmChain.FmotivList.Count < 1)
                throw new Exception("Unable to count text word gamut with no elements in chain!");

            // Составление словаря из ф-мотивов
            var fmLex = new FmotivChain();
            // словарь в виде цепочки из уникальных объектов, по порядку возрастанияя индекса

            // поиск мощности словаря = максимальный индекс + 1
            int MaxId = 0;
            for (int i = 0; i < FmChain.FmotivList.Count; i++)
            {

                if (MaxId < FmChain.FmotivList[i].Id)
                {
                    MaxId = FmChain.FmotivList[i].Id;
                }
            }
            // заполнение словаря уникальными фмотивами

            for (int i = 0; i < FmChain.FmotivList.Count; i++)
            {
                bool uniq = true; // флаг уникальности фмотива, для его дальнейшего занесения в словарь

                for (int j = 0; j < fmLex.FmotivList.Count; j++)
                {
                    if (FmChain.FmotivList[i].Equals(fmLex.FmotivList[j]))
                    {
                        uniq = false;
                    }
                }

                if (uniq)
                {
                    fmLex.FmotivList.Add((Fmotiv) FmChain.FmotivList[i].Clone());
                }

                uniq = true;
            }

            // подсчет значения используя: строй (цепь идентификаторов), алфавит - из которого вытаскивается длина слова, конкретной однородной знаковой цепи

            double GiVal = 0; // глубина одной i-ой однородной цепи
            double GVal = 0;
            // глубина всей цепи, прочитаной словами = Сумма по i: длина i-ого слова * (Gival  - уже в лог масштабе)
            double GiWVal = 0; // глубина в штуках слов для i-ой
            double GWVal = 0; // глубина в штуках слов

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
                for (int i = 0; i < FmChain.FmotivList.Count; i++)
                {
                    //накполение интервала, сложение букв фмотивов
                    interval = interval +
                               FmChain.FmotivList[FmChain.FmotivList.Count - 1 - i].PauseTreatment(
                                   (int) ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;
                    // накопление интервала слов
                    intervalW = intervalW + 1;

                    if (FmChain.FmotivList[FmChain.FmotivList.Count - 1 - i].Equals(fmLex.FmotivList[m]))
                    {
                        GiVal = GiVal + Math.Log(interval, 2); // при сложении логарифмов интервалов в буквах
                        GiWVal = GiWVal + Math.Log(intervalW, 2); // при сложении логарифмов интервалов в словах;
                        intervalW = 0;
                        // обнуляем накопление слов для подсчета рассотяния другог одинакового следующего слова
                        interval = 0;
                        // обнуляем накопление букв для подсчета рассотяния другог одинакового следующего слова
                    }

                }

                GVal = GVal +
                       GiVal*
                       fmLex.FmotivList[m].PauseTreatment((int) ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;
                GWVal = GWVal +
                        GiWVal*
                        fmLex.FmotivList[m].PauseTreatment((int) ParamPauseTreatment.Ignore)
                            .TieGathered()
                            .NoteList.Count;

                GiVal = 0; // для след однородной цепи - обнуляем что считать заново
                GiWVal = 0; // для след однородной цепи - обнуляем что считать заново
            }
            Gamut = GVal;
            GamutW = GWVal;

            // длина словаря
            Vlen = 0;
            for (int i = 0; i < fmLex.FmotivList.Count; i++)
            {
                Vlen = Vlen +
                       fmLex.FmotivList[i].PauseTreatment((int) ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;
            }
            return true;
        }
    }
}