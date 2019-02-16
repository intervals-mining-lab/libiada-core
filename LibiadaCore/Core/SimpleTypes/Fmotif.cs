namespace LibiadaCore.Core.SimpleTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security.Cryptography;

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
        /// <param name="id">
        /// The id.
        /// порядковый номер - идентификатор
        /// (возможно введения доп id - глобального для словаря ф-мотивов)
        /// </param>
        public Fmotif(FmotifType type, ParamPauseTreatment pauseTreatmentParameter, int id = -1)
        {
            Id = id;
            Type = type;
            NoteList = new List<ValueNote>();
            PauseTreatmentParameter = pauseTreatmentParameter;
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
        public int Id { get; set; }

        /// <summary>
        /// Gets the pause treatment parameter.
        /// </summary>
        private ParamPauseTreatment PauseTreatmentParameter { get; }

        // TODO: убрать все частные и заменить на общие!!!!!!!!! заменил все withoutpauses() на PauseTreatment с параметорм ignore

        /// <summary>
        /// The pause treatment.
        /// </summary>
        /// <param name="paramPauseTreatment">
        /// The param pause treatment.
        /// </param>
        /// <returns>
        /// The <see cref="Fmotif"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if paramPauseTreatment is unknown.
        /// </exception>
        public Fmotif PauseTreatment(ParamPauseTreatment paramPauseTreatment)
        {
            // возвращает копию этого объекта
            switch (paramPauseTreatment)
            {
                case ParamPauseTreatment.Ignore:
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

                case ParamPauseTreatment.NoteTrace:
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

                case ParamPauseTreatment.SilenceNote:
                        // Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                        // ничего не треуется
                        return (Fmotif)Clone();

                default:
                    throw new InvalidEnumArgumentException(nameof(paramPauseTreatment), (int)paramPauseTreatment, typeof(ParamPauseTreatment));
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
            var tempGathered = new Fmotif(Type, PauseTreatmentParameter, Id);

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
            var clone = new Fmotif(Type, PauseTreatmentParameter, Id);
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
            // для сравнения паузы не нужны, поэтому сравнивае ф-мотивы без пауз (они игнорируются, но входят в состав ф-мотива)
            Fmotif self = PauseTreatment(ParamPauseTreatment.Ignore).TieGathered();
            Fmotif other = ((Fmotif)obj).PauseTreatment(ParamPauseTreatment.Ignore).TieGathered();
            int modulation = 0;
            bool firstTime = true;

            if (self.NoteList.Count != other.NoteList.Count)
            {
                // фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for (int i = 0; i < self.NoteList.Count; i++)
            {
                // одинаково ли количество высот в этих нотах?
                if ((self.NoteList[i].Pitches == null) != (other.NoteList[i].Pitches == null))
                {
                    return false;
                }

                if (self.NoteList[i].Pitches == null || self.NoteList[i].Pitches.Count != other.NoteList[i].Pitches.Count)
                {
                    // если нет - фмотивы - неодинаковы
                    return false;
                }

                // одинаковы ли длительности у нот?
                if (!self.NoteList[i].Duration.Equals(other.NoteList[i].Duration))
                {
                    // если нет - фмотивы - неодинаковы
                    return false;
                }

                for (int j = 0; j < self.NoteList[i].Pitches.Count; j++)
                {
                    if (firstTime)
                    {
                        // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                        // последущие должны отличаться на столько же, чтобы фмотивы были равны
                        modulation = self.NoteList[i].Pitches[j].MidiNumber - other.NoteList[i].Pitches[j].MidiNumber;
                        firstTime = false;
                    }

                    // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                    if (modulation != (self.NoteList[i].Pitches[j].MidiNumber - other.NoteList[i].Pitches[j].MidiNumber))
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
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <param name="paramPauseTreatment">
        /// The param pause treatment.
        /// </param>
        /// <param name="paramEqualFM">
        /// The param equal fm.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if paramEqualFM is unknown.
        /// </exception>
        public bool FmEquals(object obj, ParamPauseTreatment paramPauseTreatment, ParamEqualFM paramEqualFM)
        {
            // для сравнения паузы не нужны, поэтому сравнивае ф-мотивы без пауз (они игнорируются, но входят в состав ф-мотива)
            Fmotif self = PauseTreatment(paramPauseTreatment).TieGathered();
            Fmotif other = ((Fmotif)obj).PauseTreatment(paramPauseTreatment).TieGathered();
            int modulation = 0;
            bool firstTime = true;

            if (self.NoteList.Count != other.NoteList.Count)
            {
                // фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for (int i = 0; i < self.NoteList.Count; i++)
            {
                // одинаково ли количество высот у нот?
                if (self.NoteList[i].Pitches.Count != other.NoteList[i].Pitches.Count)
                {
                    // если нет - фмотивы - неодинаковы
                    return false;
                }

                // одинаковы ли длительности у нот?
                if (!self.NoteList[i].Duration.Equals(other.NoteList[i].Duration))
                {
                    // если нет - фмотивы - неодинаковы
                    return false;
                }

                if ((self.NoteList[i].Pitches.Count == 0) || (other.NoteList[i].Pitches.Count == 0))
                {
                    if (!((self.NoteList[i].Pitches.Count == 0) && (other.NoteList[i].Pitches.Count == 0)))
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
                            for (int j = 0; j < self.NoteList[i].Pitches.Count; j++)
                            {
                                if (firstTime)
                                {
                                    // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                                    // последущие должны отличаться на столько же, чтобы фмотивы были равны
                                    modulation = self.NoteList[i].Pitches[j].MidiNumber -
                                                 other.NoteList[i].Pitches[j].MidiNumber;
                                    firstTime = false;
                                }

                                // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                                if (modulation !=
                                    (self.NoteList[i].Pitches[j].MidiNumber - other.NoteList[i].Pitches[j].MidiNumber))
                                {
                                    return false;
                                }
                            }

                            break;

                        case ParamEqualFM.NonSequent:
                            // без секвентного переноса (NonSequent)
                            for (int j = 0; j < self.NoteList[i].Pitches.Count; j++)
                            {
                                if (self.NoteList[i].Pitches[j].MidiNumber != other.NoteList[i].Pitches[j].MidiNumber)
                                {
                                    return false;
                                }
                            }

                            break;

                        default:
                            throw new InvalidEnumArgumentException(nameof(paramEqualFM), (int)paramEqualFM, typeof(ParamEqualFM));
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Calculates MD5 hash code using
        /// notes, fmotif type and param pause treatment.
        /// </summary>
        /// <returns>
        /// The <see cref="T:byte[]"/>.
        /// </returns>
        public byte[] GetMD5HashCode()
        {
            var hash = new List<byte>();
            foreach (ValueNote note in NoteList)
            {
                hash.AddRange(note.GetMD5HashCode());
            }
            hash.Add((byte)Type);
            hash.Add((byte)(PauseTreatmentParameter));
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(hash.ToArray());
        }

        /// <summary>
        /// Calculates hash code using
        /// notes, fmotif type and param pause treatment.
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
                hashCode = (hashCode * -1521134295) + PauseTreatmentParameter.GetHashCode();
                foreach (ValueNote note in NoteList)
                {
                    hashCode = (hashCode * -1521134295) + note.GetHashCode();
                }

                return hashCode;
            }

        }
    }
}
