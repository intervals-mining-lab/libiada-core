namespace LibiadaCore.Music
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The priority discover.
    /// </summary>
    public class PriorityDiscover
    {
        /// <summary>
        /// The calculate.
        /// метод для подсчета приоритетов нот во всем Scoretrack
        /// </summary>
        /// <param name="scoreTrack">
        /// The score track.
        /// </param>
        public void Calculate(ScoreTrack scoreTrack)
        {
            foreach (CongenericScoreTrack congenericTrack in scoreTrack.CongenericScoreTracks)
            {
                Calculate(congenericTrack);
            }
        }

        /// <summary>
        /// The calculate.
        /// метод для подсчета приоритетов нот для каждого такта (Measure)
        /// в монофоническом треке (CongenericScoretrack)
        /// </summary>
        /// <param name="congenericTrack">
        /// The congeneric track.
        /// </param>
        public void Calculate(CongenericScoreTrack congenericTrack)
        {
            foreach (Measure measure in congenericTrack.MeasureList)
            {
                Calculate(measure);
            }
        }

        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="measure">
        /// The measure.
        /// </param>
        /// <exception cref="Exception">
        /// Thrown in different cases.
        /// </exception>
        /// <returns>
        /// The <see cref="Measure"/>.
        /// </returns>
        public void Calculate(Measure measure)
        {
            // создаем новый такт, куда будут складываться ноты, после определения их приоритета.
            var temp = new Measure(new List<ValueNote>(), (MeasureAttributes)measure.Attributes.Clone());

            // считаем маску приоритетов для такта
            var priorityMask = CalculatePriorityMask(measure);

            // соотнесение маски приоритетов и реального такта
            double durationBuffer = 0;

            // буфер длительности
            var noteBuffer = new List<ValueNote>();

            // буфер нот для сбора триоли и передачи в CollectTriplet
            var maskBuffer = new List<ValueNote>();

            // буфер маски приоритетов для сбора приоритетов маски под триолью и передачи в CollectTriplet
            double tripletDuration = 0;

            // для каждой ноты подсчет приоритета, либо собирание в триоль и отдельный подсчет приоритетов
            foreach (ValueNote note in measure.NoteList)
            {
                if (note.Triplet)
                {
                    // TODO: проверять случай когда у нас в триоли ноты разной длительности
                    // если идет две триоли подряд, то как только первая сменяет вторую - меняется размер длительности у след. ноты
                    // и как только это произошло, нужно сначала проанализировать первую триоль и потом начать заполнять вторую
                    if ((note.Duration.Value != tripletDuration) && (noteBuffer.Count > 0))
                    {
                        FillTripletNotesPriority(durationBuffer, maskBuffer, priorityMask, noteBuffer, temp);

                        durationBuffer = 0;
                    }

                    // последовательность реальных нот триоли (триплета) заносится в буфер для дальнейшей обработки
                    // считается суммарная длительность триоли
                    noteBuffer.Add((ValueNote)note.Clone());
                    tripletDuration = note.Duration.Value;

                    // сохраняем размерность триоли/ новой триоли (если две подряд)
                    durationBuffer += note.Duration.Value;
                }
                else
                {
                    // если следущая нота не триоль, то проверка, собиралась ли она шагом ранее, если да то вызов метода CollectTriplet,
                    if (noteBuffer.Count > 0)
                    {
                        FillTripletNotesPriority(durationBuffer, maskBuffer, priorityMask, noteBuffer, temp);
                    }

                    // так как следущая нота не триплет, то определяем ее приоритет по следущему алгоритму
                    // присвоение приоритета при нахожении начала позиции следущей ноты в маске приоритетов
                    note.Priority = priorityMask.NoteList[0].Priority;

                    // Обнуляем буфер длительности
                    durationBuffer = 0;

                    // цикл, если набралось в буфер нот общей длительностью равной реальной ноте, то переходим к следующей реальной ноте
                    while ((note.Duration.Value - durationBuffer) > 0.0000001)
                    {
                        if (priorityMask.NoteList.Count < 1)
                        {
                            throw new Exception("LibiadaMusic Priority Discover: такт построен не по правилам, не хватает ноты");
                        }

                        // набор длительностей нот маски, и их удаление из очереди
                        durationBuffer += priorityMask.NoteList[0].Duration.Value;
                        priorityMask.NoteList.RemoveAt(0);
                    }

                    // переход к следующей реальной ноте
                    temp.NoteList.Add((ValueNote)note.Clone());
                    durationBuffer -= note.Duration.Value;
                }
            }

            // проверка буфера триоли, на случай когда триоль стоит в конце, чтобы не было потери нот
            if (noteBuffer.Count > 0)
            {
                FillTripletNotesPriority(durationBuffer, maskBuffer, priorityMask, noteBuffer, temp);
            }

            // присваиваем полю приоритет входного объекта, вычисленный приоритет в Temp соответственно
            for (int i = 0; i < measure.NoteList.Count; i++)
            {
                measure.NoteList[i].Priority = temp.NoteList[i].Priority;
                if (measure.NoteList[i].Priority < 0)
                {
                    throw new Exception("LibiadaMusic.PriorityDiscover: не выявлен приоритет для одной из нот (равен -1)");
                }
            }
        }

        /// <summary>
        /// Fills triplet notes priority.
        /// </summary>
        /// <param name="durationBuffer">
        /// The duration buffer.
        /// </param>
        /// <param name="maskBuffer">
        /// The mask buffer.
        /// </param>
        /// <param name="priorityMask">
        /// The priority mask.
        /// </param>
        /// <param name="noteBuffer">
        /// The note buffer.
        /// </param>
        /// <param name="tempMeasure">
        /// The temp measure.
        /// </param>
        private void FillTripletNotesPriority(double durationBuffer, List<ValueNote> maskBuffer, Measure priorityMask, List<ValueNote> noteBuffer, Measure tempMeasure)
        {
            AlignPriorityMaskForNextNote(durationBuffer, maskBuffer, priorityMask);

            List<ValueNote> tripletPriority = CountTripletPriority(noteBuffer, maskBuffer);

            // передача методу CountTriplet notebuf + maskbuf и расстановка приоритетов + передача обратно
            // занесение в выходной буфер результата определения приоритета нот триоли
            foreach (ValueNote tripletNote in tripletPriority)
            {
                tempMeasure.NoteList.Add((ValueNote)tripletNote.Clone());
            }

            //tempMeasure.NoteList.AddRange(CountTripletPriority(noteBuffer, maskBuffer));

            // зануление буферов
            noteBuffer.Clear();
            maskBuffer.Clear();
        }

        /// <summary>
        /// Aligns priority mask for next note.
        /// </summary>
        /// <param name="durationBuffer">
        /// The duration buffer.
        /// </param>
        /// <param name="maskBuffer">
        /// The mask buffer.
        /// </param>
        /// <param name="priorityMask">
        /// The priority mask.
        /// </param>
        private void AlignPriorityMaskForNextNote(double durationBuffer, List<ValueNote> maskBuffer, Measure priorityMask)
        {
            while (durationBuffer > 0.0000001)
            {
                // собираем буфер маски приоритетов для триоли,
                // собираем пока суммарная длительность нот маски не превышает длительность реальных нот триоли
                maskBuffer.Add((ValueNote)priorityMask.NoteList[0].Clone());
                durationBuffer -= priorityMask.NoteList[0].Duration.Value;
                priorityMask.NoteList.RemoveAt(0);
            }
        }

        /// <summary>
        /// The count triplet priority.
        /// </summary>
        /// <param name="noteBuffer">
        /// The note buf.
        /// </param>
        /// <param name="maskBuffer">
        /// The mask buffer.
        /// </param>
        /// <returns>
        /// The <see cref="List{ValueNote}"/>.
        /// </returns>
        private List<ValueNote> CountTripletPriority(List<ValueNote> noteBuffer, List<ValueNote> maskBuffer)
        {
            // TODO: расчет приоритетов для триоли с числом нот больше 3 выполняется по четко не определенному правилу, сделать как должно быть
            var temp = new List<ValueNote>();

            // записываем в отдельный счетчик т.к. значение noteBuf.Count меняется во время цикла
            while (noteBuffer.Count > 0)
            {
                if (maskBuffer.Count == 0)
                {
                    // если для разбираемой очереди нот-триолей, в очереди нот маски приоритетов не осталось нот,
                    // то следущей ноте-триоли присваивается приоритеты предыдущей ноты-триоли
                    noteBuffer[0].Priority = temp[temp.Count - 1].Priority;
                    temp.Add((ValueNote)noteBuffer[0].Clone());
                    noteBuffer.RemoveAt(0);
                }
                else
                {
                    // отнимаем из маски приоритетов нот на сумму равную номинальному (не реальному) значению длительности триольной ноты
                    double durationBuffer = noteBuffer[0].Duration.OriginalValue;

                    noteBuffer[0].Priority = maskBuffer[0].Priority;

                    // добавляем ноту триоль в выходной буфер
                    temp.Add((ValueNote)noteBuffer[0].Clone());

                    // удаляем ноту-триоль из разбираемой очереди
                    noteBuffer.RemoveAt(0);
                    while (durationBuffer > 0.0000001)
                    {
                        // по одной удаляем из маски приоритетов ноты, сумма длительностей которых равна номинальной длительности текущей разбираемой ноты
                        if (maskBuffer.Count < 1)
                        {
                            // если ноты в маске закончились то выходим из цикла
                            break;
                        }

                        // отнимаем из значения длительности ноты-триоли длительность очередной ноты маски
                        durationBuffer -= maskBuffer[0].Duration.Value;

                        // удаляем ноту маски из очереди (маски приоритетов)
                        maskBuffer.RemoveAt(0);
                    }
                }
            }

            return temp; // возвращаем результат
        }

        /// <summary>
        /// The min duration.
        /// </summary>
        /// <param name="measure">
        /// The measure.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if measure contains no notes.
        /// </exception>
        public double MinDuration(Measure measure)
        {
            // Метод находит минимальную длительность ноты/паузы в такте
            double value = 0;
            if (measure.NoteList.Count > 0)
            {
                value = measure.NoteList[0].Duration.Value;
            }
            else
            {
                // заносим в буфер первый элемент массива длительностей нот, если такт пустой - ошибка!
                throw new Exception("LibiadaMusic.OIP: обнаружен пустой такт при выявлении приоритета!");
            }

            foreach (ValueNote note in measure.NoteList)
            {
                if (value > note.Duration.Value)
                {
                    value = note.Duration.Value;
                }
            }

            return value;
        }

        /// <summary>
        /// Calculate priority mask method.
        /// маска - разметка приоритетов на пустой такт,
        /// совмещение которого с оригинальным позволит определить приоритеты реальных нот
        /// </summary>
        /// <param name="measure">
        /// The measure.
        /// </param>
        /// <returns>
        /// The priority mask as <see cref="Measure"/>.
        /// </returns>
        public Measure CalculatePriorityMask(Measure measure)
        {
            int priority = 0;

            // создание объекта маски с атрибутами оригинала и пустым списком нот
            var priorityMask = new Measure(new List<ValueNote>(), (MeasureAttributes)measure.Attributes.Clone());

            //---------------------------Занесение начальных долей размера такта---------------------------
            //---------------------------------------------------------------------------------------------
            var newDuration = new Duration(1, measure.Attributes.Size.BeatBase, false, measure.Attributes.Size.TicksPerBeat);

            priorityMask.NoteList.Add(new ValueNote((Pitch)null, newDuration, false, Tie.None, priority));

            // первая доля в такте всегда самая сильная и выделяется НАИВЫСШИМ приоритетом 0
            if (measure.Attributes.Size.Beats % 2 == 0)
            {
                // ПМТ-2 - двудольный метр/размер такта
                for (int i = 1; i < measure.Attributes.Size.Beats; i++)
                {
                    // начиная со второй доли заполняем чередуя приоритет через одну долю
                    if (i % 2 == 0)
                    {
                        // относительно сильная доля с приоритетом 1
                        priority = 1;
                        
                    }
                    else
                    {
                        // слабая доля с приоритетом 2
                        priority = 2;

                        // если всего две доли то более слабая будет иметь приоритет 1, так как больше нет долей
                        if (measure.Attributes.Size.Beats == 2)
                        {
                            priority = 1;
                        }
                    }

                    var duration = new Duration(1, measure.Attributes.Size.BeatBase, false, measure.Attributes.Size.TicksPerBeat);
                    priorityMask.NoteList.Add(new ValueNote((Pitch)null, duration, false, Tie.None, priority));
                }
            }
            else if (measure.Attributes.Size.Beats % 3 == 0)
            {
                // ПМТ-3 - трёхдольный метр/размер такта
                for (int i = 1; i < measure.Attributes.Size.Beats; i++)
                {
                    // начиная со второй доли заполняем чередуя приоритет через две доли
                    if (i % 3 == 0)
                    {
                        // относительно сильная доля с приоритетом 1
                        priority = 1;
                    }
                    else
                    {
                        // слабая доля с приоритетом 2
                        priority = 2;

                        // если всего три доли то более слабые будут иметь приоритет 1, так как больше нет других долей
                        if (measure.Attributes.Size.Beats == 3)
                        {
                            priority = 1;
                        }
                    }

                    var duration = new Duration(1, measure.Attributes.Size.BeatBase, false, measure.Attributes.Size.TicksPerBeat);
                    priorityMask.NoteList.Add(new ValueNote((Pitch)null, duration, false, Tie.None, priority));
                }
            }
            else
            {
                // ПМТ-К сложный метр/размер такта
                for (int i = 1; i < measure.Attributes.Size.Beats; i++)
                {
                    // начиная со второй доли заполняем чередуя приоритет через
                    // одну долю и последнюю долю записываем как слабую
                    if (i % 2 == 0)
                    {
                        // относительно сильная доля с приоритетом 1
                        priority = 1;

                        // если сильная доля последняя - записываем ее как слабую в ПМТ-3
                        if (i == measure.Attributes.Size.Beats - 1)
                        {
                            priority = 2;
                        }
                    }
                    else
                    {
                        // слабая доля с приоритетом 2
                        priority = 2;
                    }

                    var duration = new Duration(1, measure.Attributes.Size.BeatBase, false, measure.Attributes.Size.TicksPerBeat);
                    priorityMask.NoteList.Add(new ValueNote((Pitch)null, duration, false, Tie.None, priority));
                }
            }

            double minDuration = MinDuration(measure);

            priorityMask = SplitPriorityMask(priorityMask, minDuration);

            return priorityMask;
        }

        /// <summary>
        /// The split priority mask.
        /// </summary>
        /// <param name="priorityMask">
        /// The priority mask as <see cref="Measure"/>.
        /// </param>
        /// <param name="minDuration">
        /// The minimal note duration in measure.
        /// </param>
        /// <returns>
        /// The new priority mask as <see cref="Measure"/>.
        /// </returns>
        private Measure SplitPriorityMask(Measure priorityMask, double minDuration)
        {
            //---------------------------Разложение долей такта на более низкий уровень, ---------------------------
            //---------------------------пока не будут известны приоритеты для нот с минимальной длительностью------
            //------------------------------------------------------------------------------------------------------
            

            // флаг останова, когда просчитаются приоритеты для всех нот,
            // длительность которых окажется меньше либо равна минимальной, деленной на 2 (так как может быть точка у ноты, которую возможно описать только 3 нотами короче в два раза чем сама нота),
            // если они уже просчитаны для всех нот, то процесс заканчивается
            // проверка: останов будет тогда, когда длительности ВСЕХ нот в маске будут меньше либо равны длительности минимальной ноты
            while (!NeedToStopSplitting(priorityMask, minDuration))
            {
                var temp = new Measure(new List<ValueNote>(), (MeasureAttributes)priorityMask.Attributes.Clone());

                // создание объекта буфера для перехода к следущей маске нижнего уровня

                // определение максимального (наименьшего приоритета) для спуска на уровень ниже,
                // где появятся ноты с приоритетом еще ниже на 1 ( +1)
                int maxPriority = 0;
                foreach (ValueNote note in priorityMask.NoteList)
                {
                    if (maxPriority < note.Priority)
                    {
                        maxPriority = note.Priority;
                    }
                }

                for (int i = 0; i < priorityMask.NoteList.Count; i++)
                {
                    var duration = new Duration(1, priorityMask.NoteList[i].Duration.Denominator * 2, false, priorityMask.NoteList[i].Duration.Ticks / 2);

                    temp.NoteList.Add(new ValueNote((Pitch)null, duration, false, Tie.None, priorityMask.NoteList[i].Priority));

                    duration = new Duration(1, priorityMask.NoteList[i].Duration.Denominator * 2, false, priorityMask.NoteList[i].Duration.Ticks / 2);

                    temp.NoteList.Add(new ValueNote((Pitch)null, duration, false, Tie.None, maxPriority + 1));
                }

                // присваем объекту маске новый получившейся объект уровня ниже
                priorityMask = (Measure)temp.Clone();

                // проверка: останов будет тогда, когда длительности ВСЕХ нот в маске будут меньше либо равны длительности минимальной ноты
                // деленной на два (смотри выше из-за точки)
            }

            return priorityMask;
        }

        /// <summary>
        /// Determines if priority mask needs further splitting.
        /// </summary>
        /// <param name="minDuration">
        /// The min duration.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool NeedToStopSplitting(Measure priorityMask, double minDuration)
        {
            foreach (ValueNote note in priorityMask.NoteList)
            {
                if (note.Duration.Value > minDuration / 2)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
