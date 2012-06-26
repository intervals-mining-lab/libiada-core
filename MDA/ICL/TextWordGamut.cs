using System;
using System.Collections.Generic;
using System.Text;
using MDA.OIP.BorodaDivider;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Root.Characteristics;

namespace MDA.ICL
{
    public static class TextWordGamut
    {
        // глубина слов при чтении текста методом - по одинаковым словам, прочитываю всю длину каждого слова 
        // иными словами удаленность одинаковых слов помноженная на длину слова
        static private double Gamut = 0;
        static private double GamutW = 0;
        static private int Vlen = 0;

        static public double CalculateTextWordGamut(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return Gamut;
            throw new Exception("Word Gamut in words not calculated, ask specialist!");
        }

        static public double CalculateVlen(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return Vlen;
            throw new Exception("Word Vlen in words not calculated, ask specialist!");
        }

        static public double CalculateTextWordGamutW(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return GamutW;
            throw new Exception("Word GamutW in words not calculated, ask specialist!");
        }


        static private bool Calculate(FmotivChain FmChain)
        {
            if (FmChain.FmotivList.Count < 1) throw new Exception("Unaible to count text word gamut with no elements in chain!");


            /*// Создаем обычную цепочку индексов - строй цепи данной цепи фмотивов
            Chain FmIndexChain = new Chain(FmChain.FmotivList.Count);
            int k=0;
            foreach (Fmotiv fmotiv in FmChain.FmotivList)
            {
                if ((k+1)>FmChain.FmotivList.Count) 
                { // в случае не совпадения к и счетчика фмотивов
                    throw new Exception("Unaible to count text word gamut: wrong counter k value");
                }

                FmIndexChain[k] = new ValueInt(fmotiv.Id);
                k = k+1;                
            }*/
            
            // Составление словаря из ф-мотивов
            FmotivChain FmLex = new FmotivChain(); // словарь в виде цепочки из уникальных объектов, по порядку возрастанияя индекса

            // поиск мощности словаря = максимальный индекс + 1
            int MaxId = 0;
            for (int i=0; i < FmChain.FmotivList.Count; i++)
            {

                if (MaxId < FmChain.FmotivList[i].Id)
                {
                    MaxId = FmChain.FmotivList[i].Id;
                }
            }

            // заполнение словаря фмотивами с поиском их из данной цепи по идентификатору
            /*for(int i=0 ; i< MaxId+1; i++)
            {
                for(int j=0; j< FmChain.FmotivList.Count; j++)
                { 
                  if (FmChain.FmotivList[j].Id==i)
                  {
                      FmLex.FmotivList.Add((Fmotiv)FmChain.FmotivList[j].Clone());
                      break;
                  }                  
                }
            }
             */

            // заполнение словаря уникальными фмотивами

            for (int i = 0; i < FmChain.FmotivList.Count; i++)
            {
                bool uniq = true; // флаг уникальности фмотива, для его дальнейшего занесения в словарь

                for (int j = 0; j < FmLex.FmotivList.Count; j++)
                {
                    if (FmChain.FmotivList[i].Equals(FmLex.FmotivList[j]))
                    {
                        uniq = false;
                    }
                }

                if (uniq) 
                {
                    FmLex.FmotivList.Add((Fmotiv)FmChain.FmotivList[i].Clone());
                }

                uniq = true;
            }

            // подсчет значения используя: строй (цепь идентификаторов), алфавит - из которого вытаскивается длина слова, конкретной однородной знаковой цепи

            double GiVal = 0; // глубина одной i-ой однородной цепи
            double GVal = 0; // глубина всей цепи, прочитаной словами = Сумма по i: длина i-ого слова * (Gival  - уже в лог масштабе)
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
            
            for (int m = 0; m < FmLex.FmotivList.Count; m++)
            {
                int interval = 0; // интервал в буквах между двумя словами одинаковыми
                int intervalW = 0; // интервал в словах между двумя словами одинаковыми
                for (int i = 0; i < FmChain.FmotivList.Count; i++)
                {
                    //накполение интервала, сложение букв фмотивов
                    interval = interval + FmChain.FmotivList[FmChain.FmotivList.Count -1 - i].PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;
                    // накопление интервала слов
                    intervalW = intervalW + 1;
                    
                    if (FmChain.FmotivList[FmChain.FmotivList.Count - 1 - i].Equals((Fmotiv)FmLex.FmotivList[m]))
                    {
                        GiVal = GiVal + Math.Log(interval, 2);// при сложении логарифмов интервалов в буквах
                        GiWVal = GiWVal + Math.Log(intervalW, 2);// при сложении логарифмов интервалов в словах;
                        intervalW = 0; // обнуляем накопление слов для подсчета рассотяния другог одинакового следующего слова
                        interval = 0; // обнуляем накопление букв для подсчета рассотяния другог одинакового следующего слова
                    }
                                        
                }

                GVal = GVal + GiVal * FmLex.FmotivList[m].PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;
                GWVal = GWVal + GiWVal * FmLex.FmotivList[m].PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;

                GiVal = 0; // для след однородной цепи - обнуляем что считать заново
                GiWVal = 0; // для след однородной цепи - обнуляем что считать заново
                interval = 0; // обнуляем накопление букв для подсчета рассотяния другого слова
                intervalW = 0; // обнуляем накопление слов для подсчета рассотяния другого слова
            }


                /*
                 for (int i = 0; i < FmChain.FmotivList.Count; i++) 
                {
                    int j = 0; // счетчик для поиска предыдущего такого же элемента, либо начала цепи
                    int deltaV = 0; // счетчик для сложения нот очередного интервала

                    do
                    {
                        deltaV = deltaV + FmChain.FmotivList[i - j].PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList.Count; 
                        // умножаем общий объем на буквенное рассояние текущего (уходящего на 1 слово назад, в случаях не нахождения такого слова) слова
                        j = j + 1; // увеличиваем счетчик предыдущего

                    } while ((j <= i) && (!(FmChain.FmotivList[i].Equals((Fmotiv)FmChain.FmotivList[i - j]))));

                    Vg = Vg + Math.Log(deltaV,2)*FmChain.FmotivList[i].NoteList.Count; // при сложении логарифмов интервалов,
                    //мы еще умножаем каждый интервал между двумя одинаковыми словами на длину этого слова
                    V = V + Math.Log(deltaV,2);
                    Vj = Vj + Math.Log(j,2); // умножаем объем слов на интервал между одинаковыми словами
                }
                 */




                /*
                for (int i=0 ; i<FmLex.FmotivList.Count; i++)
                {
                    GiVal = new Characteristic(new Gamut()).Value(FmIndexChain.GetUniformChain(i),LinkUp.End);
                    GVal = GVal + (FmLex.FmotivList[i].NoteList.Count)*GiVal;
                }*/

                Gamut = GVal;
                GamutW = GWVal;

            // длина словаря
            Vlen = 0;
            for(int i=0; i< FmLex.FmotivList.Count; i++)
            {
                Vlen = Vlen + FmLex.FmotivList[i].PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList.Count;
            }
            
            return true;
        }
    }
}
