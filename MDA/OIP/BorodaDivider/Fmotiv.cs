﻿using System;
using System.Collections.Generic;
using MDA.OIP.ScoreModel;
using LibiadaCore.Classes.Root;

namespace MDA.OIP.BorodaDivider
{
    /// <summary>
    /// класс для хранения ф-мотива
    /// </summary>
    public class Fmotiv : IBaseObject
    {
        /// <summary>
        /// тип ф-мотива (ПМТ, МТ, ВП, ПМТВП, МТВП)
        /// </summary>
        private string type = "";

        /// <summary>
        /// список нот, входящих в  ф-мотив
        /// </summary>
        private List<ValueNote> notelist;

        /// <summary>
        /// конструктор для ф-мотива с неопределенным id
        /// </summary>
        /// <param name="type"></param>
        public Fmotiv(string type)
        {
            this.type = type;
            this.notelist = new List<ValueNote>();
        }

        public List<ValueNote> NoteList
        {
            get { return notelist; }
        }

        public string Type
        {
            get { return type; }
            set { this.type = value; }
        }

        // TODO: убрать все частные и заменить на общие!!!!!!!!! заменил все withoutpauses() на PauseTreatment с параметорм ignore
        /// <summary>
        /// возвращает копию этого объекта
        /// </summary>
        /// <param name="paramPause"></param>
        /// <returns></returns>
        public Fmotiv Clone(PauseTreatment paramPause)
        {
            switch (paramPause)
            {
                case PauseTreatment.Ignore:
                    {
                        // удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)
                        Fmotiv Temp = new Fmotiv(this.type);
                        Temp = (Fmotiv) this.Clone();
                        for (int i = 0; i < Temp.notelist.Count; i++)
                        {
                            if (Temp.notelist[i].Pitch.Count == 0)
                            {
                                Temp.notelist.RemoveAt(i);
                                i = i - 1;
                            }
                        }
                        return Temp;
                    }
                    //break;
                case PauseTreatment.NoteTrace:
                    {
                        // длительность паузы прибавляется к предыдущей ноте, а она сама удаляется из текста (1) (пауза - звуковой след ноты)
                        Fmotiv Temp = new Fmotiv(this.type);
                        Temp = (Fmotiv) this.Clone();

                        // если пауза стоит вначале текста (и текст не пустой) то она удаляется
                        while (Temp.notelist.Count > 0)
                        {
                            if (Temp.NoteList[0].Pitch != null)
                            {
                                break;
                            }
                            else
                            {
                                Temp.notelist.RemoveAt(0);
                            }
                        }

                        for (int i = 0; i < Temp.notelist.Count; i++)
                        {

                            if (Temp.notelist[i].Pitch == null)
                            {
                                // к длительности предыдущего звука добавляем длительность текущей паузы 
                                Temp.notelist[i - 1].Duration.AddDuration((Duration) Temp.notelist[i].Duration.Clone());
                                // удаляем паузу
                                Temp.notelist.RemoveAt(i);
                                i = i - 1;
                            }
                        }
                        return Temp;
                    }
                    //break;
                case PauseTreatment.SilenceNote:
                    {
                        // Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                        // ничего не треуется
                        Fmotiv Temp = new Fmotiv(this.type);
                        Temp = (Fmotiv) this.Clone();
                        return Temp;
                    }
                    //break;

                default:
                    throw new Exception("Error Fmotiv.PauseTreatment parameter contains wrong value!");
            }
        }

        /// <summary>
        /// возвращает копию этого объекта, соединив все залигованные ноты, если такие имеются
        /// (тоесть вместо трех залигованных нот в фмотиве будет отображаться одна, с суммарной длительностью но такой же высотой
        /// </summary>
        /// <returns></returns>
        public Fmotiv TieGathered()
        {
            ValueNote BuffNote = null;
            Fmotiv Temp = (Fmotiv) this.Clone();
            Fmotiv TempGathered = new Fmotiv(this.type);

            int count = Temp.notelist.Count;

            for (int i = 0; i < count; i++)
            {
                // неправильный код лиги, лига кодируется {-1,0,1,2}
                if ((Temp.NoteList[0].Tie > 2) || (Temp.NoteList[0].Tie < -1))
                {
                    throw new Exception("MDA: Tie is not valid!");
                }

                // если лига отсутствует
                if (Temp.NoteList[0].Tie == -1)
                {
                    if (BuffNote != null)
                    {
                        throw new Exception("MDA: Tie started but (stop)/(startstop) note NOT following!");
                    }
                    TempGathered.NoteList.Add(((ValueNote) Temp.NoteList[0].Clone()));
                    // очистка текущей позиции ноты, для перехода к следущей в очереди
                    Temp.NoteList.RemoveAt(0);
                }
                else
                {
                    // пауза не может быть залигованна, ошибка если лига на паузе! 
                    if (Temp.NoteList[0].Pitch == null)
                    {
                        throw new Exception("MDA: Pause can't be with Tie! Sorry!");
                    }

                    // начало лиги стартовая нота
                    if (Temp.NoteList[0].Tie == 0)
                    {
                        // если уже был старт лиги, и еще раз начинается старт
                        if (BuffNote != null)
                        {
                            throw new Exception("MDA: Tie note start after existing start note!");
                        }
                        BuffNote = ((ValueNote) Temp.NoteList[0].Clone());
                        // очистка текущей позиции ноты, для перехода к следущей в очереди
                        Temp.NoteList.RemoveAt(0);
                    }
                    else
                    {
                        // должно быть уже собрано что то в буффере так как лига продолжающаяся или завершающаяся
                        if (BuffNote == null)
                        {
                            throw new Exception(
                                "MDA: Tie note (stopes and starts)/(stops), without previous note start!");
                        }
                        // высота залигованных нот должна быть одинакова
                        if (!BuffNote.Pitch.Equals(Temp.NoteList[0].Pitch))
                        {
                            throw new Exception("MDA: Pitches of tie notes not equal!");
                        }

                        // уже начавшаяся лига продолжается, с условием что будет еще следущая лигованная нота
                        if (Temp.NoteList[0].Tie == 2)
                        {
                            // добавляется длительность, и копируется старая высота звучания и приоритет
                            BuffNote = new ValueNote(BuffNote.Pitch,
                                                     BuffNote.Duration.AddDuration(Temp.NoteList[0].Duration),
                                                     BuffNote.Triplet, -1, BuffNote.Priority);
                            // очистка текущей позиции ноты, для перехода к следущей в очереди
                            Temp.NoteList.RemoveAt(0);
                        }
                        else
                        {
                            // конечная нота в последовательности лигованных нот
                            if (Temp.NoteList[0].Tie == 1)
                            {
                                // добавляется длительность, и копируется старая высота звучания и приоритет
                                BuffNote = new ValueNote(BuffNote.Pitch,
                                                         BuffNote.Duration.AddDuration(Temp.NoteList[0].Duration),
                                                         BuffNote.Triplet, -1, BuffNote.Priority);
                                // завершен сбор лигованных нот, результат кладется в возвращаемый буфер.
                                TempGathered.NoteList.Add(((ValueNote) BuffNote.Clone()));
                                // очистка буффера залигованных нот
                                BuffNote = null;
                                // очистка текущей позиции ноты, для перехода к следущей в очереди
                                Temp.NoteList.RemoveAt(0);
                            }
                            else
                            {
                                {
                                    throw new Exception("MDA: Tie is not valid!");
                                }
                            }

                        }
                    }
                }
            }
            return TempGathered;
        }

        #region IBaseMethods

        private Fmotiv()
        {

        }

        public IBaseObject Clone()
        {
            Fmotiv Temp = new Fmotiv(this.type);
            foreach (ValueNote note in notelist)
            {
                Temp.notelist.Add((ValueNote) note.Clone());
            }
            return Temp;
        }


        //TODO: убрал метод override , соотвественно euals сейчас просто выполняет сравнение ссылок объектов переделать все частные
        public bool Equals(object obj)
        {
            /*
            // для сравнения паузы не нужны, поэтому сравнивае ф-мотивы без пауз (они игнорируются, но входят в состав ф-мотива)
            Fmotiv Temp1 = this.Clone(PauseTreatment.Ignore).TieGathered();
            Fmotiv Temp2 = ((Fmotiv) obj).Clone(PauseTreatment.Ignore).TieGathered();
            int Modulation = 0;
            int modi;
            bool FirstTime = true;

            if (Temp1.NoteList.Count != Temp2.NoteList.Count)
            {
                //фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for (int i = 0; i < Temp1.notelist.Count; i++)
            {
                // одинаковы ли длительности у нот?
                if (!Temp1.notelist[i].Duration.Equals(Temp2.notelist[i].Duration))
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }

                // одинаково ли количество высот у нот?
                if (Temp1.notelist[i].Pitch.Count != Temp2.notelist[i].Pitch.Count)
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }

                if (Temp1.NoteList[i].Pitch.Count > 0)
                {
                    if (FirstTime)
                    {
                        // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                        //последущие должны отличаться на столько же, чтобы фмотивы были равны
                        Modulation = Temp1.NoteList[i].Pitch[0].Midinumber - Temp2.NoteList[i].Pitch[0].Midinumber;
                        FirstTime = false;
                    }

                    for (modi = 0; modi < Temp1.NoteList[i].Pitch.Count; modi++)
                    {
                        if (Temp1.notelist[i].Pitch[modi].Instrument != Temp1.notelist[i].Pitch[modi].Instrument)
                        {
                            return false;
                        }
                        // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                        if (Modulation != (Temp1.NoteList[i].Pitch[modi].Midinumber - Temp2.NoteList[i].Pitch[modi].Midinumber))
                        {
                            return false;
                        }
                    }
                }
            }*/
            return Equals(obj, PauseTreatment.Ignore, FMSequentEquality.Sequent);
        }

        public bool Equals(object obj, PauseTreatment paramPause, FMSequentEquality paramEqual)
        {
            Fmotiv Temp1 = this.Clone(paramPause).TieGathered();
            Fmotiv Temp2 = ((Fmotiv) obj).Clone(paramPause).TieGathered();
            int Modulation = 0;
            int modi; // для циклической проверки модуляций
            bool FirstTime = true;

            if (Temp1.NoteList.Count != Temp2.NoteList.Count)
            {
                //фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for (int i = 0; i < Temp1.notelist.Count; i++)
            {
                // одинаковы ли длительности у нот?
                // одинаково ли количество высот у мультинот?
                if ((!Temp1.notelist[i].Duration.Equals(Temp2.notelist[i].Duration)) ||
                    (Temp1.notelist[i].Pitch.Count != Temp2.notelist[i].Pitch.Count))
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }
                if ((Temp1.notelist[i].Pitch.Count == 0) || (Temp2.notelist[i].Pitch.Count == 0))
                {
                    if ((Temp1.notelist[i].Pitch.Count != 0) || (Temp2.notelist[i].Pitch.Count != 0))
                    {
                        // если одна из нот пауза, а вторая - нет, то ф-мотивы не одинаковы 
                        return false; 
                    }
                    // если две паузы одно длительности то идем дальше. пропуская их (считаем что это две одинаковые ноты в любом случае)
                }
                else
                {
                    // если две ноты - не паузы
                    // в зависимости от параметра учета секвентного переноса
                    switch (paramEqual)
                    {
                        case FMSequentEquality.Sequent: // учитывая секентный перенос (Sequent)
                            {
                                if (Temp1.NoteList[i].Pitch.Count > 0)
                                {
                                    if (FirstTime)
                                    {
                                        // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                                        //последущие должны отличаться на столько же, чтобы фмотивы были равны
                                        Modulation = Temp1.NoteList[i].Pitch[0].Midinumber - Temp2.NoteList[i].Pitch[0].Midinumber;
                                        FirstTime = false;
                                    }

                                    for (modi = 0; modi < Temp1.NoteList[i].Pitch.Count; modi++)
                                    {
                                        // одинаковы ли инструменты сравняемых высот?
                                        // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                                        if ((Temp1.NoteList[i].Pitch[modi].Instrument != Temp2.NoteList[i].Pitch[modi].Instrument) ||
                                            (Modulation !=
                                            (Temp1.NoteList[i].Pitch[modi].Midinumber - Temp2.NoteList[i].Pitch[modi].Midinumber)))
                                        {
                                            // если не одинаковы, то и фмотивы неодинаковы
                                            return false;
                                        }
                                    }
                                }
                            }
                            break;

                        case FMSequentEquality.NonSequent:
                            {
                                //без секвентного переноса (NonSequent)
                                if (Temp1.notelist[i].Pitch.Count != 0)
                                {
                                    for (modi = 0; modi < Temp1.NoteList[i].Pitch.Count; modi++)
                                    {
                                        // одинаковы ли инструменты и высоты сравняемых высот?
                                        if ((Temp1.NoteList[i].Pitch[modi].Instrument != Temp2.NoteList[i].Pitch[modi].Instrument) ||
                                            (Temp1.NoteList[i].Pitch[modi].Midinumber != Temp2.NoteList[i].Pitch[modi].Midinumber))
                                        {
                                            // если не одинаковы, то и фмотивы неодинаковы
                                            return false;
                                        }
                                    }
                                }
                            }
                            break;

                        default:
                            throw new Exception("Error Fmotiv.ParamEqualFM parameter contains wrong value!");
                    }
                }
            }

            return true;
        }

        #endregion
    }
}
