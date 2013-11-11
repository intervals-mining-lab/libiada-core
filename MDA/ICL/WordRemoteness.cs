﻿using System;
using System.Collections.Generic;
using System.Text;
using MDA.OIP.BorodaDivider;
using MDA.OIP.ScoreModel;

namespace MDA.ICL
{
    public static class WordRemoteness
    {
        static private double InWordRem = 0; // удаленность в словах между словами
        static private double InLettersRem = 0; // удаленность в буквах между словами
        static private double TextGamut = 0; // глубина всего текста если читать по словам в буквах

        static public double CalculateInWords(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return InWordRem;
            throw new Exception("Word Remoteness in words not calculated, ask specialist!");
        }
        static public double CalculateInLetters(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return InLettersRem;
            throw new Exception("Word Remoteness in letters not calculated, ask specialist!");
        }
        static public double CalculateTextGamut(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return TextGamut;
            throw new Exception("Text Gamut in letters not calculated, ask specialist!");
        }
        static private bool Calculate(FmotivChain FmChain)
        {
            double  V = 0; // объем цепи в буквах
            double  Vj = 0; // объем цепи в словах
            double  Vg = 0; // глубина цепи в буквах

            if (FmChain.FmotivList.Count < 1) throw new Exception("Unaible to count word remoteness with no elements in chain!");

            for (int i = 0; i < FmChain.FmotivList.Count; i++) 
            {
                int j = 0; // счетчик для поиска предыдущего такого же элемента, либо начала цепи
                int deltaV = 0; // счетчик для сложения нот очередного интервала

                do
                {
                    deltaV = deltaV + FmChain.FmotivList[ FmChain.FmotivList.Count -1 -i -j].PauseTreatment(ParamPauseTreatment.Ignore).TieGathered().NoteList.Count; 
                    // умножаем общий объем на буквенное рассояние текущего (уходящего на 1 слово назад, в случаях не нахождения такого слова) слова
                    j = j + 1; // увеличиваем счетчик предыдущего

                } while (((i + j) < FmChain.FmotivList.Count - 1) && (!(FmChain.FmotivList[FmChain.FmotivList.Count - 1 - i].Equals((Fmotiv)FmChain.FmotivList[FmChain.FmotivList.Count - 1 - i - j]))));

                Vg = Vg + Math.Log(deltaV, 2) * FmChain.FmotivList[FmChain.FmotivList.Count - 1 - i].NoteList.Count; // при сложении логарифмов интервалов,
                //мы еще умножаем каждый интервал между двумя одинаковыми словами на длину этого слова
                V = V + Math.Log(deltaV,2);
                Vj = Vj + Math.Log(j,2); // умножаем объем слов на интервал между одинаковыми словами
            }

            InWordRem = Vj/FmChain.FmotivList.Count;
            InLettersRem = V/FmChain.FmotivList.Count;
            TextGamut = Vg;

            return true;
        }
    }
}
