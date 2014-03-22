﻿using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.BorodaDivider
{
    /// <summary>
    /// класс для хранения ф-мотива
    /// </summary>
    public class Fmotiv : IBaseObject
    {
        /// <summary>
        /// список нот, входящих в  ф-мотив
        /// </summary>
        public List<ValueNote> NoteList { get; private set; }

        public string Type { get; set; }

        /// <summary>
        /// порядковый номер - идентификатор 
        /// (-1 значит не определен) 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id">
        /// порядковый номер - идентификатор 
        /// (возможно введения доп id - глобального для словаря ф-мотивов)
        /// </param>
        public Fmotiv(string type, int id = -1)
        {
            Id = id;
            Type = type;
            NoteList = new List<ValueNote>();
        }

        // TODO: убрать все частные и заменить на общие!!!!!!!!! заменил все withoutpauses() на PauseTreatment с параметорм ignore
        public Fmotiv PauseTreatment(ParamPauseTreatment paramPauseTreatment)
        {
            //возвращает копию этого объекта

            switch (paramPauseTreatment)
            {
                case ParamPauseTreatment.Ignore:
                {
                    // удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)
                    var temp = (Fmotiv) Clone();
                    for (int i = 0; i < temp.NoteList.Count; i++)
                    {
                        if (temp.NoteList[i].Pitch != null && temp.NoteList[i].Pitch.Count == 0)
                        {
                            temp.NoteList.RemoveAt(i);
                            i--;
                        }
                    }
                    return temp;
                }
                case ParamPauseTreatment.NoteTrace:
                {
                    // длительность паузы прибавляется к предыдущей ноте, 
                    //а она сама удаляется из текста (1) (пауза - звуковой след ноты)
                    var temp = (Fmotiv) Clone();

                    // если пауза стоит вначале текста (и текст не пустой) то она удаляется
                    while (temp.NoteList.Count > 0)
                    {
                        if (temp.NoteList[0].Pitch != null && temp.NoteList[0].Pitch.Count > 0)
                        {
                            break;
                        }
                        temp.NoteList.RemoveAt(0);
                    }

                    for (int i = 0; i < temp.NoteList.Count; i++)
                    {

                        if (temp.NoteList[i].Pitch.Count == 0)
                        {
                            // к длительности предыдущего звука добавляем длительность текущей паузы 
                            temp.NoteList[i - 1].Duration.AddDuration((Duration) temp.NoteList[i].Duration.Clone());
                            // удаляем паузу
                            temp.NoteList.RemoveAt(i);
                            i--;
                        }
                    }
                    return temp;
                }
                case ParamPauseTreatment.SilenceNote:
                {
                    // Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                    // ничего не треуется
                    return (Fmotiv) Clone();
                }
                default:
                    throw new Exception("Error Fmotiv.PauseTreatment parameter contains wrong value!");
            }

        }

        public Fmotiv TieGathered()
        {
            //возвращает копию этого объекта, соединив все залигованные ноты, если такие имеются
            // (тоесть вместо трех залигованных нот в фмотиве будет отображаться одна, с суммарной длительностью но такой же высотой
            ValueNote buffNote = null;
            var temp = (Fmotiv) Clone();
            var tempGathered = new Fmotiv(Type, Id);

            int count = temp.NoteList.Count;

            for (int i = 0; i < count; i++)
            {
                if (!Enum.IsDefined(typeof(Tie), temp.NoteList[0].Tie))
                {
                    throw new Exception("LibiadaMusic: Tie is not valid!");
                }
                // если лига отсутствует
                if (temp.NoteList[0].Tie == Tie.None)
                {
                    if (buffNote != null)
                    {
                        throw new Exception("LibiadaMusic: Tie started but (stop)/(startstop) note NOT following!");
                    }
                    tempGathered.NoteList.Add(((ValueNote) temp.NoteList[0].Clone()));
                    // очистка текущей позиции ноты, для перехода к следущей в очереди
                    temp.NoteList.RemoveAt(0);
                }
                else
                {
                    // пауза не может быть залигованна, ошибка если лига на паузе! 
                    if (temp.NoteList[0].Pitch.Count == 0)
                    {
                        throw new Exception("LibiadaMusic: Pause can't be with Tie! Sorry!");
                    }

                    // начало лиги стартовая нота
                    if (temp.NoteList[0].Tie == Tie.Start)
                    {
                        // если уже был старт лиги, и еще раз начинается старт
                        if (buffNote != null)
                        {
                            throw new Exception("LibiadaMusic: Tie note start after existing start note!");
                        }
                        buffNote = ((ValueNote) temp.NoteList[0].Clone());
                        // очистка текущей позиции ноты, для перехода к следущей в очереди
                        temp.NoteList.RemoveAt(0);
                    }
                    else
                    {
                        // должно быть уже собрано что то в буффере так как лига продолжающаяся или завершающаяся
                        if (buffNote == null)
                        {
                            throw new Exception(
                                "LibiadaMusic: Tie note (stopes and starts)/(stops), without previous note start!");
                        }
                        // высота залигованных нот должна быть одинакова
                        if (!buffNote.PitchEquals(temp.NoteList[0].Pitch))
                        {
                            throw new Exception("LibiadaMusic: Pitches of tie notes not equal!");
                        }

                        // уже начавшаяся лига продолжается, с условием что будет еще следущая лигованная нота
                        if ( temp.NoteList[0].Tie == Tie.StartStop)
                        {
                            // добавляется длительность, и копируется старая высота звучания и приоритет
                            buffNote = new ValueNote(buffNote.Pitch, buffNote.Duration.AddDuration(temp.NoteList[0].Duration),
                                buffNote.Triplet, Tie.None, buffNote.Priority);
                            // очистка текущей позиции ноты, для перехода к следущей в очереди
                            temp.NoteList.RemoveAt(0);
                        }
                        else
                        {
                            // конечная нота в последовательности лигованных нот
                            if (temp.NoteList[0].Tie == Tie.Stop)
                            {
                                // добавляется длительность, и копируется старая высота звучания и приоритет
                                buffNote = new ValueNote(buffNote.Pitch,
                                    buffNote.Duration.AddDuration(temp.NoteList[0].Duration), buffNote.Triplet, Tie.None,
                                    buffNote.Priority);
                                // завершен сбор лигованных нот, результат кладется в возвращаемый буфер.
                                tempGathered.NoteList.Add(((ValueNote) buffNote.Clone()));
                                // очистка буффера залигованных нот
                                buffNote = null;
                                // очистка текущей позиции ноты, для перехода к следущей в очереди
                                temp.NoteList.RemoveAt(0);
                            }
                            else
                            {
                                {
                                    throw new Exception("LibiadaMusic: Tie is not valid!");
                                }
                            }

                        }
                    }
                }
            }
            return tempGathered;
        }

        public IBaseObject Clone()
        {
            var clone = new Fmotiv(Type, Id);
            foreach (ValueNote note in NoteList)
            {
                clone.NoteList.Add((ValueNote) note.Clone());
            }
            return clone;
        }


        //TODO: убрал метод override , соотвественно euals сейчас просто выполняет сравнение ссылок объектов переделать все частные
        public override bool Equals(object obj)
        {
            // для сравнения паузы не нужны, поэтому сравнивае ф-мотивы без пауз (они игнорируются, но входят в состав ф-мотива)
            Fmotiv self = PauseTreatment(ParamPauseTreatment.Ignore).TieGathered();
            Fmotiv other = ((Fmotiv) obj).PauseTreatment(ParamPauseTreatment.Ignore).TieGathered();
            int modulation = 0;
            bool firstTime = true;

            if (self.NoteList.Count != other.NoteList.Count)
            {
                //фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for (int i = 0; i < self.NoteList.Count; i++)
            {
                // одинаково ли количество высот в этих нотах?
                if ((self.NoteList[i].Pitch == null) != (other.NoteList[i].Pitch == null))
                {
                    return false;
                }
                if (self.NoteList[i].Pitch == null || self.NoteList[i].Pitch.Count != other.NoteList[i].Pitch.Count)
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }
                // одинаковы ли длительности у нот?
                if (!self.NoteList[i].Duration.Equals(other.NoteList[i].Duration))
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }

                for (int j = 0; j < self.NoteList[i].Pitch.Count; j++)
                {
                    if (firstTime)
                    {
                        // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                        //последущие должны отличаться на столько же, чтобы фмотивы были равны
                        modulation = self.NoteList[i].Pitch[j].MidiNumber - other.NoteList[i].Pitch[j].MidiNumber;
                        firstTime = false;
                    }

                    // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                    if (modulation != (self.NoteList[i].Pitch[j].MidiNumber - other.NoteList[i].Pitch[j].MidiNumber))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool FmEquals(object obj, ParamPauseTreatment paramPauseTreatment, ParamEqualFM paramEqualFM)
        {
            // для сравнения паузы не нужны, поэтому сравнивае ф-мотивы без пауз (они игнорируются, но входят в состав ф-мотива)
            Fmotiv self = PauseTreatment(paramPauseTreatment).TieGathered();
            Fmotiv other = ((Fmotiv) obj).PauseTreatment(paramPauseTreatment).TieGathered();
            int modulation = 0;
            bool firstTime = true;

            if (self.NoteList.Count != other.NoteList.Count)
            {
                //фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for (int i = 0; i < self.NoteList.Count; i++)
            {
                // одинаково ли количество высот у нот?
                if (self.NoteList[i].Pitch.Count != (other.NoteList[i].Pitch.Count))
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }

                // одинаковы ли длительности у нот?
                if (!self.NoteList[i].Duration.Equals(other.NoteList[i].Duration))
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }

                if ((self.NoteList[i].Pitch.Count == 0) || (other.NoteList[i].Pitch.Count == 0))
                {
                    if (!((self.NoteList[i].Pitch.Count == 0) && (other.NoteList[i].Pitch.Count == 0)))
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
                    switch (paramEqualFM)
                    {
                        case ParamEqualFM.Sequent: // учитывая секентный перенос (Sequent)
                            for (int j = 0; j < self.NoteList[i].Pitch.Count; j++)
                            {
                                if (firstTime)
                                {
                                    // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                                    //последущие должны отличаться на столько же, чтобы фмотивы были равны
                                    modulation = self.NoteList[i].Pitch[j].MidiNumber -
                                                 other.NoteList[i].Pitch[j].MidiNumber;
                                    firstTime = false;
                                }

                                // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                                if (modulation !=
                                    (self.NoteList[i].Pitch[j].MidiNumber - other.NoteList[i].Pitch[j].MidiNumber))
                                {
                                    return false;
                                }
                            }
                            break;

                        case ParamEqualFM.NonSequent:
                            //без секвентного переноса (NonSequent)
                            for (int j = 0; j < self.NoteList[i].Pitch.Count; j++)
                                if (self.NoteList[i].Pitch[j].MidiNumber != other.NoteList[i].Pitch[j].MidiNumber)
                                {
                                    return false;
                                }
                            break;

                        default:
                            throw new Exception("Error Fmotiv.ParamEqualFM parameter contains wrong value!");
                    }
                }
            }
            return true;
        }
    }
}