﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MDA.OIP.BorodaDivider
{
    public static class ParamPauseTreatment // класс для выбора отношения к паузам (игнорировать, длительность добавлять к предыдущему звуку, рассматривать как ноту "тишины")
    {
        static public int Ignore // Игнорировать паузы (но не удалять) - однако они имеют значение при выделении приоритетов нот (0)
        {
            get
            {
                return 0;
            }
        }

        static public int NoteTrace // Пауза - звуковой след ноты, длительность паузы прибавляется к предыдущей ноте, а она сама удаляется из текста (1)
        {
            get
            {
                return 1;
            }
        }

        static public int SilenceNote // Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
        {
            get
            {
                return 2;
            }
        }
    }
}
