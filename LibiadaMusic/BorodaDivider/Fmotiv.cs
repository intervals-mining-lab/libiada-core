using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.BorodaDivider
{
    public class Fmotiv : IBaseObject // класс для хранения ф-мотива
    {
        // (-1 значит не определен) порядковый номер - идентификатор (возможно введения доп id - глобального для словаря ф-мотивов)

        private List<Note> noteList; // список нот, входящих в  ф-мотив

        public Fmotiv(string type, int id = -1)
        {
            Id = id;
            Type = type;
            noteList = new List<Note>();
        }

        public List<Note> NoteList
        {
            get { return noteList; }
        }

        public string Type { get; set; }

        public int Id { get; set; }

        // TODO: убрать все частные и заменить на общие!!!!!!!!! заменил все withoutpauses() на PauseTreatment с параметорм ignore
        public Fmotiv PauseTreatment(int paramPause)
        {
            //возвращает копию этого объекта

            switch (paramPause)
            {
                case 0:
                {
// удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)
                    var temp = (Fmotiv) Clone();
                    for (int i = 0; i < temp.noteList.Count; i++)
                    {
                        if (temp.noteList[i].Pitch != null && temp.noteList[i].Pitch.Count == 0)
                        {
                            temp.noteList.RemoveAt(i);
                            i = i - 1;
                        }
                    }
                    return temp;
                }
                case 1:
                {
// длительность паузы прибавляется к предыдущей ноте, а она сама удаляется из текста (1) (пауза - звуковой след ноты)
                    var temp = (Fmotiv) Clone();

                    // если пауза стоит вначале текста (и текст не пустой) то она удаляется
                    while (temp.noteList.Count > 0)
                    {
                        if (temp.noteList[0].Pitch != null && temp.NoteList[0].Pitch.Count > 0)
                        {
                            break;
                        }
                        temp.noteList.RemoveAt(0);
                    }

                    for (int i = 0; i < temp.noteList.Count; i++)
                    {

                        if (temp.noteList[i].Pitch.Count == 0)
                        {
                            // к длительности предыдущего звука добавляем длительность текущей паузы 
                            temp.noteList[i - 1].Duration.AddDuration((Duration) temp.noteList[i].Duration.Clone());
                            // удаляем паузу
                            temp.noteList.RemoveAt(i);
                            i = i - 1;
                        }
                    }
                    return temp;
                }
                case 2:
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
            Note buffNote = null;
            var temp = (Fmotiv) Clone();
            var tempGathered = new Fmotiv(Type, Id);

            int count = temp.noteList.Count;

            for (int i = 0; i < count; i++)
            {
                // неправильный код лиги, лига кодируется {-1,0,1,2}
                if (((int) temp.NoteList[0].Tie > 2) || ((int) temp.NoteList[0].Tie < -1))
                {
                    throw new Exception("LibiadaMusic: Tie is not valid!");
                }

                // если лига отсутствует
                if ((int) temp.NoteList[0].Tie == -1)
                {
                    if (buffNote != null)
                    {
                        throw new Exception("LibiadaMusic: Tie started but (stop)/(startstop) note NOT following!");
                    }
                    tempGathered.NoteList.Add(((Note) temp.NoteList[0].Clone()));
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
                    if (temp.NoteList[0].Tie == 0)
                    {
                        // если уже был старт лиги, и еще раз начинается старт
                        if (buffNote != null)
                        {
                            throw new Exception("LibiadaMusic: Tie note start after existing start note!");
                        }
                        buffNote = ((Note) temp.NoteList[0].Clone());
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
                        if ((int) temp.NoteList[0].Tie == 2)
                        {
                            // добавляется длительность, и копируется старая высота звучания и приоритет
                            buffNote = new Note(buffNote.Pitch, buffNote.Duration.AddDuration(temp.NoteList[0].Duration),
                                buffNote.Triplet, Tie.None, buffNote.Priority);
                            // очистка текущей позиции ноты, для перехода к следущей в очереди
                            temp.NoteList.RemoveAt(0);
                        }
                        else
                        {
                            // конечная нота в последовательности лигованных нот
                            if ((int) temp.NoteList[0].Tie == 1)
                            {
                                // добавляется длительность, и копируется старая высота звучания и приоритет
                                buffNote = new Note(buffNote.Pitch,
                                    buffNote.Duration.AddDuration(temp.NoteList[0].Duration), buffNote.Triplet, Tie.None,
                                    buffNote.Priority);
                                // завершен сбор лигованных нот, результат кладется в возвращаемый буфер.
                                tempGathered.NoteList.Add(((Note) buffNote.Clone()));
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

        #region IBaseMethods

        public IBaseObject Clone()
        {
            var temp = new Fmotiv(Type, Id);
            foreach (Note note in noteList)
            {
                temp.noteList.Add((Note) note.Clone());
            }
            return temp;
        }


        //TODO: убрал метод override , соотвественно euals сейчас просто выполняет сравнение ссылок объектов переделать все частные
        public override bool Equals(object obj)
        {
            // для сравнения паузы не нужны, поэтому сравнивае ф-мотивы без пауз (они игнорируются, но входят в состав ф-мотива)
            Fmotiv temp1 = PauseTreatment((int) ParamPauseTreatment.Ignore).TieGathered();
            Fmotiv temp2 = ((Fmotiv) obj).PauseTreatment((int) ParamPauseTreatment.Ignore).TieGathered();
            int modulation = 0;
            bool firstTime = true;

            if (temp1.NoteList.Count != temp2.NoteList.Count)
            {
                //фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for (int i = 0; i < temp1.noteList.Count; i++)
            {
                // одинаково ли количество высот в этих нотах?
                if ((temp1.noteList[i].Pitch == null) != (temp2.noteList[i].Pitch == null))
                {
                    return false;
                }
                if (temp1.noteList[i].Pitch != null && temp1.noteList[i].Pitch.Count != temp2.noteList[i].Pitch.Count)
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }
                // одинаковы ли длительности у нот?
                if (!temp1.noteList[i].Duration.Equals(temp2.noteList[i].Duration))
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }

                for (int j = 0; j < temp1.noteList[i].Pitch.Count; j++)
                {
                    if (firstTime)
                    {
                        // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                        //последущие должны отличаться на столько же, чтобы фмотивы были равны
                        modulation = temp1.NoteList[i].Pitch[j].MidiNumber - temp2.NoteList[i].Pitch[j].MidiNumber;
                        firstTime = false;
                    }

                    // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                    if (modulation != (temp1.NoteList[i].Pitch[j].MidiNumber - temp2.NoteList[i].Pitch[j].MidiNumber))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool FmEquals(object obj, int paramPause, int paramEqual)
        {
            // для сравнения паузы не нужны, поэтому сравнивае ф-мотивы без пауз (они игнорируются, но входят в состав ф-мотива)
            Fmotiv temp1 = PauseTreatment(paramPause).TieGathered();
            Fmotiv temp2 = ((Fmotiv) obj).PauseTreatment(paramPause).TieGathered();
            int modulation = 0;
            bool firstTime = true;

            if (temp1.NoteList.Count != temp2.NoteList.Count)
            {
                //фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for (int i = 0; i < temp1.noteList.Count; i++)
            {
                // одинаково ли количество высот у нот?
                if (temp1.noteList[i].Pitch.Count != (temp2.noteList[i].Pitch.Count))
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }

                // одинаковы ли длительности у нот?
                if (!temp1.noteList[i].Duration.Equals(temp2.noteList[i].Duration))
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }

                if ((temp1.noteList[i].Pitch.Count == 0) || (temp2.noteList[i].Pitch.Count == 0))
                {
                    if (!((temp1.noteList[i].Pitch.Count == 0) && (temp2.noteList[i].Pitch.Count == 0)))
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
                        case 0: // учитывая секентный перенос (Sequent)
                        {
                            for (int j = 0; j < temp1.NoteList[i].Pitch.Count; j++)
                            {
                                if (firstTime)
                                {
                                    // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                                    //последущие должны отличаться на столько же, чтобы фмотивы были равны
                                    modulation = temp1.NoteList[i].Pitch[j].MidiNumber -
                                                 temp2.NoteList[i].Pitch[j].MidiNumber;
                                    firstTime = false;
                                }

                                // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                                if (modulation !=
                                    (temp1.NoteList[i].Pitch[j].MidiNumber - temp2.NoteList[i].Pitch[j].MidiNumber))
                                {
                                    return false;
                                }
                            }
                        }
                            break;

                        case 1:
                        {
                            //без секвентного переноса (NonSequent)
                            for (int j = 0; j < temp1.NoteList[i].Pitch.Count; j++)
                                if (temp1.NoteList[i].Pitch[j].MidiNumber != temp2.NoteList[i].Pitch[j].MidiNumber)
                                {
                                    return false;
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
