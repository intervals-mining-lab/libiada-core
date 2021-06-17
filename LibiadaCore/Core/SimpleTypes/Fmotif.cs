namespace LibiadaCore.Core.SimpleTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using LibiadaCore.Music;

    /// <summary>
    /// Class representing formal motif.
    /// </summary>
    public class Fmotif : IBaseObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fmotif"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="pauseTreatment">
        /// Pause treatment parameter.
        /// </param>
        /// <param name="id">
        /// The id.
        /// порядковый номер - идентификатор
        /// (возможно введения доп id - глобального для словаря ф-мотивов)
        /// </param>
        public Fmotif(FmotifType type, PauseTreatment pauseTreatment, long id = -1)
        {
            Id = id;
            Type = type;
            NoteList = new List<ValueNote>();
            PauseTreatment = pauseTreatment;
        }

        /// <summary>
        /// Gets list of notes in fmotif.
        /// </summary>
        public List<ValueNote> NoteList { get; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public FmotifType Type { get; set; }

        /// <summary>
        /// Gets or sets id (-1 means not defined).
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets the pause treatment parameter.
        /// </summary>
        private PauseTreatment PauseTreatment { get; }

        // TODO: убрать все частные и заменить на общие!!!!!!!!! заменил все withoutpauses() на PauseTreatment с параметорм ignore

        /// <summary>
        /// The pause treatment procedure.
        /// </summary>
        /// <param name="pauseTreatment">
        /// The param pause treatment.
        /// </param>
        /// <returns>
        /// Copy of the current <see cref="Fmotif"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if pauseTreatment is unknown.
        /// </exception>
        public Fmotif PauseTreatmentProcedure(PauseTreatment pauseTreatment)
        {
            switch (pauseTreatment)
            {
                case PauseTreatment.Ignore:
                    // удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)
                    var temp = (Fmotif)Clone();
                    for (int i = 0; i < temp.NoteList.Count; i++)
                    {
                        if (temp.NoteList[i].Pitches != null && temp.NoteList[i].Pitches.Count == 0)
                        {
                            temp.NoteList.RemoveAt(i);
                            i--;
                        }
                    }

                    return temp;

                case PauseTreatment.NoteTrace:
                    // длительность паузы прибавляется к предыдущей ноте,
                    // а она сама удаляется из текста (1) (пауза - звуковой след ноты)
                    var temp2 = (Fmotif)Clone();

                    // если пауза стоит вначале текста (и текст не пустой) то она удаляется
                    while (temp2.NoteList.Count > 0)
                    {
                        if (temp2.NoteList[0].Pitches != null && temp2.NoteList[0].Pitches.Count > 0)
                        {
                            break;
                        }

                        temp2.NoteList.RemoveAt(0);
                    }

                    for (int i = 0; i < temp2.NoteList.Count; i++)
                    {
                        if (temp2.NoteList[i].Pitches.Count == 0)
                        {
                            // к длительности предыдущего звука добавляем длительность текущей паузы
                            temp2.NoteList[i - 1].Duration.AddDuration((Duration)temp2.NoteList[i].Duration.Clone());

                            // удаляем паузу
                            temp2.NoteList.RemoveAt(i);
                            i--;
                        }
                    }

                    return temp2;

                case PauseTreatment.SilenceNote:
                    // Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                    // ничего не треуется
                    return (Fmotif)Clone();

                default:
                    throw new InvalidEnumArgumentException(nameof(pauseTreatment), (int)pauseTreatment, typeof(PauseTreatment));
            }
        }

        /// <summary>
        /// The tie gathered.
        /// </summary>
        /// <returns>
        /// The <see cref="Fmotif"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown in many cases.
        /// </exception>
        public Fmotif TieGathered()
        {
            // возвращает копию этого объекта, соединив все залигованные ноты, если такие имеются
            // (то есть вместо трех залигованных нот в фмотиве будет отображаться одна, с суммарной длительностью но такой же высотой
            ValueNote buffNote = null;
            var temp = (Fmotif)Clone();
            var tempGathered = new Fmotif(Type, PauseTreatment, Id);

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

                    tempGathered.NoteList.Add((ValueNote)temp.NoteList[0].Clone());

                    // очистка текущей позиции ноты, для перехода к следущей в очереди
                    temp.NoteList.RemoveAt(0);
                }
                else
                {
                    // пауза не может быть залигованна, ошибка если лига на паузе!
                    if (temp.NoteList[0].Pitches.Count == 0)
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

                        buffNote = (ValueNote)temp.NoteList[0].Clone();

                        // очистка текущей позиции ноты, для перехода к следущей в очереди
                        temp.NoteList.RemoveAt(0);
                    }
                    else
                    {
                        // должно быть уже собрано что то в буффере так как лига продолжающаяся или завершающаяся
                        if (buffNote == null)
                        {
                            throw new Exception("LibiadaMusic: Tie note (stopes and starts)/(stops), without previous note start!");
                        }

                        // высота залигованных нот должна быть одинакова
                        if (!buffNote.PitchEquals(temp.NoteList[0].Pitches))
                        {
                            throw new Exception("LibiadaMusic: Pitches of tie notes not equal!");
                        }

                        // уже начавшаяся лига продолжается, с условием что будет еще следущая лигованная нота
                        if (temp.NoteList[0].Tie == Tie.Continue)
                        {
                            // добавляется длительность, и копируется старая высота звучания и приоритет
                            buffNote = new ValueNote(buffNote.Pitches, buffNote.Duration.AddDuration(temp.NoteList[0].Duration), buffNote.Triplet, Tie.None, buffNote.Priority);

                            // очистка текущей позиции ноты, для перехода к следущей в очереди
                            temp.NoteList.RemoveAt(0);
                        }
                        else
                        {
                            // конечная нота в последовательности лигованных нот
                            if (temp.NoteList[0].Tie == Tie.End)
                            {
                                // добавляется длительность, и копируется старая высота звучания и приоритет
                                buffNote = new ValueNote(buffNote.Pitches, buffNote.Duration.AddDuration(temp.NoteList[0].Duration), buffNote.Triplet, Tie.None, buffNote.Priority);

                                // завершен сбор лигованных нот, результат кладется в возвращаемый буфер.
                                tempGathered.NoteList.Add((ValueNote)buffNote.Clone());

                                // очистка буффера залигованных нот
                                buffNote = null;

                                // очистка текущей позиции ноты, для перехода к следущей в очереди
                                temp.NoteList.RemoveAt(0);
                            }
                            else
                            {
                                throw new Exception("LibiadaMusic: Tie is not valid!");
                            }
                        }
                    }
                }
            }

            return tempGathered;
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var clone = new Fmotif(Type, PauseTreatment, Id);
            foreach (ValueNote note in NoteList)
            {
                clone.NoteList.Add((ValueNote)note.Clone());
            }

            return clone;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Fmotif))
            {
                return false;
            }
            // для сравнения паузы не нужны, поэтому сравниваем ф-мотивы без пауз (они игнорируются, но входят в состав ф-мотива)
            Fmotif self = PauseTreatmentProcedure(PauseTreatment.Ignore).TieGathered();
            Fmotif other = ((Fmotif)obj).PauseTreatmentProcedure(PauseTreatment.Ignore).TieGathered();
            int modulation = 0;
            bool firstTime = true;

            if (self.NoteList.Count != other.NoteList.Count)
            {
                // фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for (int i = 0; i < self.NoteList.Count; i++)
            {
                ValueNote selfNote = self.NoteList[i];
                ValueNote otherNote = other.NoteList[i];

                // одинаково ли количество высот в этих нотах?
                if ((selfNote.Pitches == null) != (otherNote.Pitches == null))
                {
                    return false;
                }

                if (selfNote.Pitches == null || selfNote.Pitches.Count != otherNote.Pitches.Count)
                {
                    // если нет - фмотивы - неодинаковы
                    return false;
                }

                // одинаковы ли длительности у нот?
                if (!selfNote.Duration.Equals(otherNote.Duration))
                {
                    // если нет - фмотивы - неодинаковы
                    return false;
                }

                for (int j = 0; j < selfNote.Pitches.Count; j++)
                {
                    var selfPitch = selfNote.Pitches[j];
                    var otherPitch = otherNote.Pitches[j];

                    if (firstTime)
                    {
                        // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                        // последущие должны отличаться на столько же, чтобы фмотивы были равны
                        modulation = selfPitch.MidiNumber - otherPitch.MidiNumber;
                        firstTime = false;
                    }

                    // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                    if (modulation != (selfPitch.MidiNumber - otherPitch.MidiNumber))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// The fm equals.
        /// </summary>
        /// <param name="other">
        /// Fmotif for comparison.
        /// </param>
        /// <param name="paramPauseTreatment">
        /// The param pause treatment.
        /// </param>
        /// <param name="sequentialTransfer">
        /// The sequential transfer parameter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if sequential transfer parameter is unknown.
        /// </exception>
        public bool FmEquals(Fmotif other, PauseTreatment paramPauseTreatment, bool sequentialTransfer)
        {
            // для сравнения паузы не нужны, поэтому сравнивае ф-мотивы без пауз (они игнорируются, но входят в состав ф-мотива)
            Fmotif self = PauseTreatmentProcedure(paramPauseTreatment).TieGathered();
            other = other.PauseTreatmentProcedure(paramPauseTreatment).TieGathered();
            int modulation = 0;
            bool firstTime = true;

            if (self.NoteList.Count != other.NoteList.Count)
            {
                // фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for (int i = 0; i < self.NoteList.Count; i++)
            {
                ValueNote selfNote = self.NoteList[i];
                ValueNote otherNote = other.NoteList[i];
                // одинаково ли количество высот у нот?
                if (selfNote.Pitches.Count != otherNote.Pitches.Count)
                {
                    // если нет - фмотивы - неодинаковы
                    return false;
                }

                // одинаковы ли длительности у нот?
                if (!selfNote.Duration.Equals(otherNote.Duration))
                {
                    // если нет - фмотивы - неодинаковы
                    return false;
                }

                if ((selfNote.Pitches.Count == 0) || (otherNote.Pitches.Count == 0))
                {
                    if (!((selfNote.Pitches.Count == 0) && (otherNote.Pitches.Count == 0)))
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
                    if (sequentialTransfer)
                    {
                        // учитывая секентный перенос (Sequent)
                        for (int j = 0; j < selfNote.Pitches.Count; j++)
                        {
                            var selfPitch = selfNote.Pitches[j];
                            var otherPitch = otherNote.Pitches[j];
                            if (firstTime)
                            {
                                // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                                // последущие должны отличаться на столько же, чтобы фмотивы были равны
                                modulation = selfPitch.MidiNumber - otherPitch.MidiNumber;
                                firstTime = false;
                            }

                            // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                            if (modulation != (selfPitch.MidiNumber - otherPitch.MidiNumber))
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        // без секвентного переноса (NonSequent)
                        for (int j = 0; j < selfNote.Pitches.Count; j++)
                        {
                            if (selfNote.Pitches[j].MidiNumber != otherNote.Pitches[j].MidiNumber)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Calculates hash code using
        /// <see cref="NoteList"/>, fmotif <see cref="Type"/> and param pause treatment.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = -2024996526;
                hashCode = (hashCode * -1521134295) + ((byte)Type).GetHashCode();
                hashCode = (hashCode * -1521134295) + ((byte)PauseTreatment).GetHashCode();

                foreach (ValueNote note in NoteList)
                {
                    hashCode = (hashCode * -1521134295) + note.GetHashCode();
                }

                return hashCode;
            }

        }
    }
}
