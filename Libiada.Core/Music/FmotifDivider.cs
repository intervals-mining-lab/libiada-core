namespace Libiada.Core.Music;

using System.ComponentModel;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The fmotif divider.
/// </summary>
public class FmotifDivider
{
    /// <summary>
    ///  Параметр сохраняется для всего экземпляра класса и потом используется.
    /// </summary>
    private PauseTreatment pauseTreatment;

    /// <summary>
    /// The get division.
    /// </summary>
    /// <param name="congenericTrack">
    /// The congeneric track.
    /// </param>
    /// <param name="paramPauseTreatment">
    /// The param pause treatment.
    /// </param>
    /// <returns>
    /// The <see cref="FmotifChain"/>.
    /// </returns>
    /// <exception cref="Exception">
    /// Thrown in many cases.
    /// </exception>
    public FmotifChain GetDivision(CongenericScoreTrack congenericTrack, PauseTreatment pauseTreatment)
    {
        var chain = new FmotifChain(); // выходная, результирующая цепочка разбитых ф-мотивов
        this.pauseTreatment = pauseTreatment;

        var fmotifBuffer = new Fmotif(FmotifType.None, pauseTreatment);

        // буффер для накопления нот, для последующего анализа его содержимого
        var noteChain = new List<ValueNote>();

        // цепочка нот, куда поочередно складываются ноты из последовательности тактов
        // для дальнейшего их анализа и распределения по ф-мотивам.

        // заполняем NoteChain всеми нотам из данной монофонической цепи unitrack
        foreach (Measure measure in congenericTrack.MeasureList)
        {
            foreach (ValueNote note in measure.NoteList)
            {
                noteChain.Add((ValueNote)note.Clone());
            }
        }

        // счетчик реальных нот/пауз для первой группировки в реальную нот
        int n = 0;

        // флаг который говорит, что была нота перемещена в буфер после последнего флага Next, для pause notetrace
        bool wasNote = false;

        // флаг, говорит что собралась очередная нота для рассмотрения
        bool next = false;

        // флаг, говорящий что собирается последовательность равнодлительных звуков (1,2 тип фмотива - ПМТ,ЧМТ)
        bool sameDurationChain = false;

        // флаг, говорящий что собирается возрастающая последовательность (3 тип фмотива)
        bool growingDurationChain = false;

        // флаг, говорящий что собирается комбинация - ПМТ/ЧМТ и возрастающая последовательность (4 тип фмотива)
        bool combination = false;

        // пока анализируемая цепь содержит элементы, идет выполнение анализа ее содержимого
        while (noteChain.Count > 0)
        {
            fmotifBuffer.NoteList.Add((ValueNote)noteChain[0].Clone());
            noteChain.RemoveAt(0);

            // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
            if (fmotifBuffer.NoteList[fmotifBuffer.NoteList.Count - 1].Tie != Tie.None)
            {
                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                if (fmotifBuffer.NoteList[fmotifBuffer.NoteList.Count - 1].Tie == Tie.Start)
                {
                    // TODO: желательно сделать проверку когда собирается очередная лига,
                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)
                    while (noteChain[0].Tie == Tie.Continue)
                    {
                        // пока продолжается лига, заносим ноты в буфер
                        fmotifBuffer.NoteList.Add((ValueNote)noteChain[0].Clone());
                        noteChain.RemoveAt(0);
                    }

                    if (noteChain[0].Tie == Tie.End)
                    {
                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                        fmotifBuffer.NoteList.Add((ValueNote)noteChain[0].Clone());
                        noteChain.RemoveAt(0);

                        wasNote = true; // была нота пермещена в буфер

                        switch (pauseTreatment)
                        {
                            case PauseTreatment.Ignore:
                                // удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)
                                // если у очередной ноты нет лиги, то проверяем: если нота - не пауза, то выставляем флаг о следущей рассматриваемой ноте
                                if (fmotifBuffer.NoteList[fmotifBuffer.NoteList.Count - 1].Pitches.Count > 0)
                                {
                                    next = true;
                                }

                                break;
                            case PauseTreatment.NoteTrace:
                                // длительность паузы прибавляется к предыдущей ноте, а она сама удаляется из текста (1) (пауза - звуковой след ноты)
                                if (noteChain.Count > 0)
                                {
                                    // если следующая не паузы то переходим к анализу буфера
                                    if (noteChain[0].Pitches.Count > 0)
                                    {
                                        next = true;
                                    }
                                }
                                else
                                {
                                    next = true;
                                }

                                break;
                            case PauseTreatment.SilenceNote:
                                // Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                                // ничего не треуется
                                next = true;
                                break;
                            default:
                                throw new InvalidEnumArgumentException(nameof(pauseTreatment), (int)pauseTreatment, typeof(PauseTreatment));
                        }
                    }
                    else
                    {
                        // когда лига не заканчивается флагом конца, то ошибка
                        throw new Exception("LibiadaMusic: FmotifDivider, wrong Tie organization!End!");
                    }
                }
                else
                {
                    // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                    throw new Exception("LibiadaMusic: FmotifDivider, wrong Tie organization!Begining!");
                }
            }
            else
            {
                // если у очередной ноты нет лиги
                switch (pauseTreatment)
                {
                    case PauseTreatment.Ignore:
                        // удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)
                        // если у очередной ноты нет лиги, то проверяем: если нота - не пауза, то выставляем флаг о следущей рассматриваемой ноте
                        if (fmotifBuffer.NoteList[fmotifBuffer.NoteList.Count - 1].Pitches.Count > 0)
                        {
                            next = true;
                        }

                        break;
                    case PauseTreatment.NoteTrace:
                        // длительность паузы прибавляется к предыдущей ноте, а она сама удаляется из текста (1) (пауза - звуковой след ноты)
                        // проверяем: если нота - не пауза, то выставляем флаг о следущей рассматриваемой ноте
                        if (fmotifBuffer.NoteList[fmotifBuffer.NoteList.Count - 1].Pitches.Count > 0)
                        {
                            wasNote = true;
                        }

                        if (noteChain.Count > 0)
                        {
                            // если следующая в н. тексте не пауза то переходим к анализу буфера
                            if ((noteChain[0].Pitches.Count > 0) && wasNote)
                            {
                                next = true;
                            }
                        }
                        else
                        {
                            if (wasNote)
                            {
                                next = true;
                            }
                        }

                        break;
                    case PauseTreatment.SilenceNote:
                        // Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                        // ничего не треуется
                        next = true;
                        break;
                    default:
                        throw new InvalidEnumArgumentException(nameof(pauseTreatment), (int)pauseTreatment, typeof(PauseTreatment));
                }
            }

            // если готова (собрана) следущая нота для анализа
            if (next)
            {
                // убираем флаг следущей готовой (собранной ноты), так как после анализа не известно что там будет
                next = false;
                wasNote = false;

                if (ExtractNoteList(fmotifBuffer).Count == 1)
                {
                    // сохранили сколько нот/пауз входит в первую рассматриваемую ноту
                    n = fmotifBuffer.NoteList.Count;
                }

                if (ExtractNoteList(fmotifBuffer).Count == 2)
                {
                    // если длительность первой собранной ноты больше длительности второй собранной ноты
                    var first = TempExtractor(fmotifBuffer, 0);
                    var second = TempExtractor(fmotifBuffer, 1);
                    if (first.Duration.Value > second.Duration.Value)
                    {
                        // заносим ноты/паузы первой собранной ноты в очередной фмотив с типом ЧМТ, и удаляем из буфера
                        var fm = new Fmotif(FmotifType.PartialMinimalMeasure, pauseTreatment, chain.FmotifsList.Count);
                        for (int i = 0; i < n; i++)
                        {
                            // заносим
                            fm.NoteList.Add((ValueNote)fmotifBuffer.NoteList[0].Clone());

                            // удаляем
                            fmotifBuffer.NoteList.RemoveAt(0);
                        }

                        // добавляем в выходную цепочку получившийся фмотив
                        chain.FmotifsList.Add((Fmotif)fm.Clone());

                        // сохранили n на случай если за этим фмотивом следует еще один ЧМТ
                        n = fmotifBuffer.NoteList.Count;

                        // сохранили сколько нот/пауз входит в первую рассматриваемую ноту
                    }
                    else
                    {
                        first = TempExtractor(fmotifBuffer, 0);
                        second = TempExtractor(fmotifBuffer, 1);
                        if (first.Duration.Equals(second.Duration))
                        {
                            // выставляем флаг для сбора последовательности равнодлительных звуков
                            sameDurationChain = true;
                            n = fmotifBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер
                        }
                        else
                        {
                            first = TempExtractor(fmotifBuffer, 0);
                            second = TempExtractor(fmotifBuffer, 1);
                            if (first.Duration.Value < second.Duration.Value)
                            {
                                // выставляем флаг для сбора возрастающей последовательности
                                growingDurationChain = true;

                                // сохранили сколько нот/пауз входит в буфер
                                n = fmotifBuffer.NoteList.Count;
                            }
                        }
                    }
                }

                if (ExtractNoteList(fmotifBuffer).Count > 2)
                {
                    if (sameDurationChain)
                    {
                        // если длительность предпоследнего меньше длительности последнего
                        var lastButOne = TempExtractor(fmotifBuffer, ExtractNoteList(fmotifBuffer).Count - 2);
                        var last = TempExtractor(fmotifBuffer, ExtractNoteList(fmotifBuffer).Count - 1);
                        if (lastButOne.Duration.Value < last.Duration.Value)
                        {
                            var fmotifBuffer2 = new Fmotif(FmotifType.None, pauseTreatment);

                            // помещаем в буффер2 последнюю собранную ноту - большей длительности чем все равнодлительные
                            // так как меняется в процессе
                            int count = fmotifBuffer.NoteList.Count;
                            for (int i = n; i < count; i++)
                            {
                                fmotifBuffer2.NoteList.Add((ValueNote)fmotifBuffer.NoteList[n].Clone());
                                fmotifBuffer.NoteList.RemoveAt(n);
                            }

                            // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                            // заисключением последнего фмотива - он останется в буфере вместе с нотой длительность которой больше последней ноты этого фмотива
                            List<Fmotif> dividedSameDuration = DivideSameDurationNotes(fmotifBuffer);
                            for (int i = 0; i < (dividedSameDuration.Count - 1); i++)
                            {
                                // заносим очередной фмотив
                                chain.FmotifsList.Add((Fmotif)dividedSameDuration[i].Clone());

                                // присваиваем очередной id
                                chain.FmotifsList[chain.FmotifsList.Count - 1].Id = chain.FmotifsList.Count - 1;
                            }

                            // в буфер заносим последний фмотив цепочки фмотивов нот с равнодлительностью
                            fmotifBuffer = (Fmotif)dividedSameDuration[dividedSameDuration.Count - 1].Clone();

                            // добавляем сохраненную ноту с большой длительностью
                            for (int i = 0; i < fmotifBuffer2.NoteList.Count; i++)
                            {
                                fmotifBuffer.NoteList.Add((ValueNote)fmotifBuffer2.NoteList[i].Clone());
                            }

                            // флаг комбинации
                            combination = true;

                            // флаг возрастающей последовательности, чтобы завершить фмотив - комбинация
                            growingDurationChain = true;

                            // убираем флаг для сбора равнодлительных нот
                            sameDurationChain = false;

                            // сохранили сколько нот/пауз входит в текущий буфер
                            n = fmotifBuffer.NoteList.Count;
                        }

                        // если длительность предпоследнего равна длительности последнего
                        last = TempExtractor(fmotifBuffer, ExtractNoteList(fmotifBuffer).Count - 1);
                        lastButOne = TempExtractor(fmotifBuffer, ExtractNoteList(fmotifBuffer).Count - 2);
                        if (lastButOne.Duration.Equals(last.Duration))
                        {
                            // записываем очередную ноты в фмотив с типом последовательность равнодлительных звуков
                            // (она уже записана, поэтому просто сохраняем число входящих в фмотив на данный момент нот/пауз)
                            // сохранили сколько нот/пауз входит в буфер
                            n = fmotifBuffer.NoteList.Count;
                        }

                        // если длительность предпоследнего больше длительности последнего
                        last = TempExtractor(fmotifBuffer, ExtractNoteList(fmotifBuffer).Count - 1);
                        lastButOne = TempExtractor(fmotifBuffer, ExtractNoteList(fmotifBuffer).Count - 2);
                        if (lastButOne.Duration.Value > last.Duration.Value)
                        {
                            var fmotifBuffer2 = new Fmotif(FmotifType.None, pauseTreatment);

                            // помещаем в буффер2 последнюю собранную ноту - меньшей длительности чем все равнодлительные
                            int count = fmotifBuffer.NoteList.Count; // так как меняется в процессе
                            for (int i = n; i < count; i++)
                            {
                                fmotifBuffer2.NoteList.Add((ValueNote)fmotifBuffer.NoteList[n].Clone());
                                fmotifBuffer.NoteList.RemoveAt(n);
                            }

                            // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                            foreach (Fmotif fmotif in DivideSameDurationNotes(fmotifBuffer))
                            {
                                // заносим очередной фмотив
                                chain.FmotifsList.Add((Fmotif)fmotif.Clone());

                                // присваиваем очередной id
                                chain.FmotifsList[chain.FmotifsList.Count - 1].Id = chain.FmotifsList.Count - 1;
                            }

                            // очищаем буффер
                            fmotifBuffer.NoteList.Clear();

                            // добавляем состав сохраненной ноты (паузы/лиги) с меньшей длительностью в буфер
                            for (int i = 0; i < fmotifBuffer2.NoteList.Count; i++)
                            {
                                fmotifBuffer.NoteList.Add((ValueNote)fmotifBuffer2.NoteList[i].Clone());
                            }

                            // убираем флаг для сбора равнодлительных нот
                            sameDurationChain = false;

                            // сохранили сколько нот/пауз входит в текущий буфер
                            n = fmotifBuffer.NoteList.Count;
                        }
                    }
                    else
                    {
                        if (growingDurationChain)
                        {
                            // если длительность предпоследнего меньше длительности последнего
                            var last = TempExtractor(fmotifBuffer, ExtractNoteList(fmotifBuffer).Count - 1);
                            var lastButOne = TempExtractor(fmotifBuffer, ExtractNoteList(fmotifBuffer).Count - 2);
                            if (lastButOne.Duration.Value < last.Duration.Value)
                            {
                                // записываем очередную ноты в фмотив с типом возрастающая последовательность
                                // (она уже записана, поэтому просто сохраняем число входящих в фмотив на данный момент нот)
                                n = fmotifBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер
                            }
                            else
                            {
                                // иначе если длительности равны, или последняя по длительности меньше предпоследней, то составляем новый фмотив
                                // также сохраняем не вошедшую последнюю ноту (не удаляем ее)
                                if (combination)
                                {
                                    var fm = new Fmotif((byte)fmotifBuffer.Type + FmotifType.IncreasingSequence, pauseTreatment, chain.FmotifsList.Count);

                                    // ЧМТВП или ПМТВП
                                    for (int i = 0; i < n; i++)
                                    {
                                        // заносим
                                        fm.NoteList.Add((ValueNote)fmotifBuffer.NoteList[0].Clone());

                                        // удаляем
                                        fmotifBuffer.NoteList.RemoveAt(0);
                                    }

                                    // добавляем в выходную цепочку получившийся фмотив
                                    chain.FmotifsList.Add((Fmotif)fm.Clone());

                                    // сохранили сколько нот/пауз осталось в буфере от последней не вошедшей в фмотив ноты
                                    n = fmotifBuffer.NoteList.Count;

                                    // убрали флаг сбора возрастающей последовательности
                                    growingDurationChain = false;

                                    // убрали флаг сбора возрастающей последовательности
                                    combination = false;
                                }
                                else
                                {
                                    var fm = new Fmotif(FmotifType.IncreasingSequence, pauseTreatment, chain.FmotifsList.Count);
                                    for (int i = 0; i < n; i++)
                                    {
                                        // заносим
                                        fm.NoteList.Add((ValueNote)fmotifBuffer.NoteList[0].Clone());

                                        // удаляем
                                        fmotifBuffer.NoteList.RemoveAt(0);
                                    }

                                    // добавляем в выходную цепочку получившийся фмотив
                                    chain.FmotifsList.Add((Fmotif)fm.Clone());

                                    // сохранили сколько нот/пауз осталось в буфере от последней не вошедшей в фмотив ноты
                                    n = fmotifBuffer.NoteList.Count;

                                    // убрали флаг сбора возрастающей последовательности
                                    growingDurationChain = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        // если в буфере осталась 1 непроанализированная нота
        if (ExtractNoteList(fmotifBuffer).Count == 1)
        {
            // заносим ноты/паузы 1 собранной ноты в очередной фмотив с типом ЧМТ, и удаляем из буфера
            var fm = new Fmotif(FmotifType.PartialMinimalMeasure, pauseTreatment, chain.FmotifsList.Count);

            // for (int i = 0; i < FmotifBuffer.NoteList.Count; i++)
            foreach (ValueNote note in fmotifBuffer.NoteList)
            {
                // заносим
                fm.NoteList.Add((ValueNote)note.Clone());
            }

            // добавляем в выходную цепочку получившийся фмотив
            chain.FmotifsList.Add((Fmotif)fm.Clone());

            // очищаем буффер
            fmotifBuffer.NoteList.Clear();
        }

        // если в буфере остались непроанализированные ноты (больше 1)
        if (ExtractNoteList(fmotifBuffer).Count > 1)
        {
            if (sameDurationChain)
            {
                // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                foreach (Fmotif fmotif in DivideSameDurationNotes(fmotifBuffer))
                {
                    // заносим очередной фмотив
                    chain.FmotifsList.Add((Fmotif)fmotif.Clone());

                    // присваиваем очередной id
                    chain.FmotifsList[chain.FmotifsList.Count - 1].Id = chain.FmotifsList.Count - 1;
                }

                // очищаем буффер
                fmotifBuffer.NoteList.Clear();
            }
            else
            {
                if (growingDurationChain)
                {
                    if (combination)
                    {
                        // заносим оставшиеся ноты в комбинированный фмотив ЧМТ/ПМТ + ВП и в выходную цепочку
                        var fm = new Fmotif((byte)fmotifBuffer.Type + FmotifType.IncreasingSequence, pauseTreatment, chain.FmotifsList.Count); // ЧМТВП или ПМТВП
                        foreach (ValueNote note in fmotifBuffer.NoteList)
                        {
                            // заносим
                            fm.NoteList.Add((ValueNote)note.Clone());
                        }

                        // добавляем в выходную цепочку получившийся фмотив
                        chain.FmotifsList.Add((Fmotif)fm.Clone());

                        // очищаем буффер
                        fmotifBuffer.NoteList.Clear();
                    }
                    else
                    {
                        // заносим оставшиеся ноты в фмотив ВП и в выходную цепочку
                        var fm = new Fmotif(FmotifType.IncreasingSequence, pauseTreatment, chain.FmotifsList.Count);
                        foreach (ValueNote note in fmotifBuffer.NoteList)
                        {
                            // заносим
                            fm.NoteList.Add((ValueNote)note.Clone());
                        }

                        // добавляем в выходную цепочку получившийся фмотив
                        chain.FmotifsList.Add((Fmotif)fm.Clone());

                        // очищаем буффер
                        fmotifBuffer.NoteList.Clear();
                    }
                }
            }
        }

        return chain;
    }

    /// <summary>
    /// The temp method.
    /// </summary>
    /// <param name="fmotif">
    /// The fmotif.
    /// </param>
    /// <param name="fmotifBuffer">
    /// The fmotif buffer.
    /// </param>
    /// <exception cref="Exception">
    /// Thrown in different cases.
    /// </exception>
    private static void MoveTiedNotesFromFmotifBufferToFmotif(Fmotif fmotif, Fmotif fmotifBuffer)
    {
        if (fmotif.NoteList[fmotif.NoteList.Count - 1].Tie != Tie.None)
        {
            // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
            if (fmotif.NoteList[fmotif.NoteList.Count - 1].Tie == Tie.Start)
            {
                // TODO: желательно сделать проверку когда собирается очередная лига,
                // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)
                while (fmotifBuffer.NoteList[0].Tie == Tie.Continue)
                {
                    // пока продолжается лига, заносим ноты в буфер
                    fmotif.NoteList.Add((ValueNote)fmotifBuffer.NoteList[0].Clone());
                    fmotifBuffer.NoteList.RemoveAt(0);
                }

                if (fmotifBuffer.NoteList[0].Tie == Tie.End)
                {
                    // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                    fmotif.NoteList.Add((ValueNote)fmotifBuffer.NoteList[0].Clone());
                    fmotifBuffer.NoteList.RemoveAt(0);
                }
                else
                {
                    // когда лига не заканчивается флагом конца, то ошибка
                    throw new Exception("LibiadaMusic: FmotifDivider, wrong Tie organization!End!");
                }
            }
            else
            {
                // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                throw new Exception("LibiadaMusic: FmotifDivider, wrong Tie organization!Begining!");
            }
        }
    }

    /// <summary>
    /// The divide same duration notes.
    /// </summary>
    /// <param name="fmotifBuff">
    /// The fmotif buff.
    /// </param>
    /// <returns>
    /// The <see cref="List{Fmotif}"/>.
    /// </returns>
    /// <exception cref="Exception">
    /// Thrown if amount of collected notes in buffer is less than 2.
    /// </exception>
    private List<Fmotif> DivideSameDurationNotes(Fmotif fmotifBuff)
    {
        // создаем копию входного объекта
        var fmotifBuffer = (Fmotif)fmotifBuff.Clone();

        // выходной список фмотивов
        var result = new List<Fmotif>();

        // проверка на случай когда в аругменте метода количество собранных нот (из пауз/лиг) меньше двух
        if (ExtractNoteList(fmotifBuffer).Count < 2)
        {
            throw new Exception("LibiadaMusic DivideSameDurationNotes: notes < 2");
        }

        if (ExtractNoteList(fmotifBuffer).Count % 2 == 0)
        {
            // то начинаем анализ из расчета : по две ноты в фмотиве
            // сохраняем количество раз, так как потом меняется
            int count = ExtractNoteList(fmotifBuffer).Count / 2;
            for (int i = 0; i < count; i++)
            {
                if (FirstPriorityIsLessThanSecond(fmotifBuffer))
                {
                    // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                    // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив

                    // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимостиот того, чем мы считаем паузу
                    // (когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                    result.Add(ExtractGivenNotesCountFromFmotifBuffer(fmotifBuffer, FmotifType.CompleteMinimalMeasure, 2));
                }
                else
                {
                    // приоритет первой ноты ниже приоритета второй ноты (метрически слабее)
                    // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                    // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                    // потому что количество равндлительных звуков поменялось, и алгоритм анализа может поменяться

                    // собираем в цикле, пока не кончатся ноты в буфере 1 полноценную ноту в зависимостиот того, чем мы считаем паузу
                    // (когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                    result.Add(ExtractGivenNotesCountFromFmotifBuffer(fmotifBuffer, FmotifType.PartialMinimalMeasure, 1));

                    // если осталась одна нота то заносим ее в фмотив ЧМТ
                    SecondTempMethod(fmotifBuffer, result);

                    return result;
                }
            }

            // прошли все ПМТ без ЧМТ, то вернуть результат
            return result;
        }

        if (ExtractNoteList(fmotifBuffer).Count % 3 == 0)
        {
            // то начинаем анализ из расчета : по три ноты в фмотиве
            // сохраняем количество раз, так как потом меняется
            int count = ExtractNoteList(fmotifBuffer).Count / 3;
            for (int i = 0; i < count; i++)
            {
                if (FirstPriorityIsLessThanSecond(fmotifBuffer))
                {
                    // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                    var first = TempExtractor(fmotifBuffer, 0);
                    var third = TempExtractor(fmotifBuffer, 2);
                    if (first.Priority < third.Priority)
                    {
                        // приоритет первой ноты выше приоритета третьей ноты (собранные ноты)
                        // ПМТ и записываем все что входит в цепочку нот - в эти три собранные ноты, в очередной фмотив

                        // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу
                        // (когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        result.Add(ExtractGivenNotesCountFromFmotifBuffer(fmotifBuffer, FmotifType.CompleteMinimalMeasure, 3));
                    }
                    else
                    {
                        // приоритет первой ноты ниже или равен приоритету третьей ноты (собранные ноты)
                        // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                        // (ЧМТ - если есть знак триоли хотя бы у одной ноты)
                        FmotifType typeF = FmotifType.CompleteMinimalMeasure; // тип ПМТ если не триоль
                        first = TempExtractor(fmotifBuffer, 0);
                        var second = TempExtractor(fmotifBuffer, 1);
                        if (first.Triplet || second.Triplet)
                        {
                            typeF = FmotifType.PartialMinimalMeasure; // если есть хотя б один знак триоли
                        }

                        // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимости от того, чем мы считаем паузу
                        // (когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        result.Add(ExtractGivenNotesCountFromFmotifBuffer(fmotifBuffer, typeF, 2));

                        // если осталась одна нота то заносим ее в фмотив ЧМТ
                        SecondTempMethod(fmotifBuffer, result);
                        return result;
                    }
                }
                else
                {
                    // приоритет первой ноты ниже или равен приоритету второй ноты (метрически слабее или равен)
                    // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                    // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                    // потому что количество равнодлительных звуков поменялось, и алгоритм анализа может поменяться

                    // собираем в цикле, пока не кончатся ноты в буфере 1 полноценная нота в зависимости от того, чем мы считаем паузу
                    // (когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                    result.Add(ExtractGivenNotesCountFromFmotifBuffer(fmotifBuffer, FmotifType.PartialMinimalMeasure, 1));

                    // если осталась одна нота то заносим ее в фмотив ЧМТ
                    SecondTempMethod(fmotifBuffer, result);
                    return result;
                }
            }

            // прошли все ПМТ без ЧМТ, то вернуть результат
            return result;
        }
        else
        {
            // то начинаем анализ из расчета : по две ноты в фмотиве (к-3)/2 раза, а в последнем 3 ноты
            // сохраняем количество раз, так как потом меняется
            int count = (ExtractNoteList(fmotifBuffer).Count - 3) / 2;
            for (int i = 0; i < count; i++)
            {
                if (FirstPriorityIsLessThanSecond(fmotifBuffer))
                {
                    // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                    // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив

                    // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимости от того, чем мы считаем паузу
                    // (когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                    result.Add(ExtractGivenNotesCountFromFmotifBuffer(fmotifBuffer, FmotifType.CompleteMinimalMeasure, 2));
                }
                else
                {
                    // приоритет первой ноты ниже приоритета второй ноты (метрически слабее)
                    // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                    // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                    // потому что количество равндлительных звуков поменялось, и алгоритм анализа может поменяться

                    // собираем в цикле, пока не кончатся ноты в буфере 1 полноценную ноту в зависимости от того, чем мы считаем паузу
                    // (когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                    result.Add(ExtractGivenNotesCountFromFmotifBuffer(fmotifBuffer, FmotifType.PartialMinimalMeasure, 1));

                    // вызываем рекурсию на оставшиеся ноты
                    // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                    List<Fmotif> dividedSameDuration = DivideSameDurationNotes(fmotifBuffer);
                    foreach (Fmotif fmotif in dividedSameDuration)
                    {
                        // заносим очередной фмотив
                        result.Add((Fmotif)fmotif.Clone());
                    }

                    return result;
                }
            }

            // анализируем оставшиеся 3 ноты
            if (FirstPriorityIsLessThanSecond(fmotifBuffer))
            {
                // приоритет первой ноты выше приоритета второй ноты (собранные ноты) !!!!!!!!!!!!!!!!!!! сравнение на саомо деле происход первой и третьей, разве нет? 08.04.2012
                var first = TempExtractor(fmotifBuffer, 0);
                var third = TempExtractor(fmotifBuffer, 2);
                if (first.Priority < third.Priority)
                {
                    // приоритет первой ноты выше приоритета третьей ноты (собранные ноты)
                    // ПМТ и записываем все что входит в цепочку нот - в эти три собранные ноты, в очередной фмотив

                    // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу
                    // (когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                    result.Add(ExtractGivenNotesCountFromFmotifBuffer(fmotifBuffer, FmotifType.CompleteMinimalMeasure, 3));
                }
                else
                {
                    // приоритет первой ноты ниже или равен приоритету третьей ноты (собранные ноты)
                    // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                    // (ЧМТ - если есть знак триоли хотя бы у одной ноты)
                    FmotifType typeF = FmotifType.CompleteMinimalMeasure; // тип ПМТ если не триоль
                    first = TempExtractor(fmotifBuffer, 0);
                    var second = TempExtractor(fmotifBuffer, 1);
                    if (first.Triplet || second.Triplet)
                    {
                        typeF = FmotifType.PartialMinimalMeasure; // если есть хотя б один знак триоли
                    }

                    // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу
                    // (когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                    result.Add(ExtractGivenNotesCountFromFmotifBuffer(fmotifBuffer, typeF, 2));

                    // если осталась одна нота то заносим ее в фмотив ЧМТ
                    SecondTempMethod(fmotifBuffer, result);
                    return result;
                }
            }
            else
            {
                // приоритет первой ноты ниже или равен приоритету второй ноты (метрически слабее или равен)
                // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                // потому что количество равнодлительных звуков поменялось, и алгоритм анализа может поменяться

                // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу
                // (когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                result.Add(ExtractGivenNotesCountFromFmotifBuffer(fmotifBuffer, FmotifType.PartialMinimalMeasure, 1));

                // если осталась одна нота то заносим ее в фмотив ЧМТ
                SecondTempMethod(fmotifBuffer, result);
                return result;
            }

            // если все собрали, то возвращаем выходную цепочку
            return result;
        }
    }

    /// <summary>
    /// The temp extractor.
    /// </summary>
    /// <param name="fmotifBuffer">
    /// The fmotif buffer.
    /// </param>
    /// <param name="index">
    /// The index.
    /// </param>
    /// <returns>
    /// The <see cref="ValueNote"/>.
    /// </returns>
    private ValueNote TempExtractor(Fmotif fmotifBuffer, int index)
    {
        return ExtractNoteList(fmotifBuffer)[index];
    }

    /// <summary>
    /// The extract note list.
    /// </summary>
    /// <param name="fmotifBuffer">
    /// The fmotif buffer.
    /// </param>
    /// <returns>
    /// The <see cref="List{ValueNote}"/>.
    /// </returns>
    private List<ValueNote> ExtractNoteList(Fmotif fmotifBuffer)
    {
        return fmotifBuffer.PauseTreatmentProcedure(pauseTreatment).TieGathered().NoteList;
    }

    /// <summary>
    /// The third temp comparator.
    /// </summary>
    /// <param name="fmotifBuffer">
    /// The fmotif buffer.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    private bool FirstPriorityIsLessThanSecond(Fmotif fmotifBuffer)
    {
        var first = TempExtractor(fmotifBuffer, 0);
        var second = TempExtractor(fmotifBuffer, 1);
        return first.Priority < second.Priority;
    }

    /// <summary>
    /// The third temp method.
    /// </summary>
    /// <param name="fmotifBuffer">
    /// The fmotif Buffer.
    /// </param>
    /// <param name="fmotifType">
    /// The fmotif Type.
    /// </param>
    /// <param name="noteCount">
    /// The note count.
    /// </param>
    /// <returns>
    /// The <see cref="Fmotif"/>.
    /// </returns>
    private Fmotif ExtractGivenNotesCountFromFmotifBuffer(Fmotif fmotifBuffer, FmotifType fmotifType, int noteCount)
    {
        var fmotif = new Fmotif(fmotifType, pauseTreatment);
        while (fmotifBuffer.NoteList.Count > 0)
        {
            if (ExtractNoteList(fmotif).Count == noteCount)
            {
                if (pauseTreatment != PauseTreatment.NoteTrace)
                {
                    break;
                }

                if ((pauseTreatment == PauseTreatment.NoteTrace) &&
                    (fmotifBuffer.NoteList[0].Pitches.Count > 0))
                {
                    break;
                }
            }

            fmotif.NoteList.Add((ValueNote)fmotifBuffer.NoteList[0].Clone());
            fmotifBuffer.NoteList.RemoveAt(0);

            MoveTiedNotesFromFmotifBufferToFmotif(fmotif, fmotifBuffer);
        }

        return (Fmotif)fmotif.Clone();
    }

    /// <summary>
    /// The second temp method.
    /// </summary>
    /// <param name="fmotifBuffer">
    /// The fmotif buffer.
    /// </param>
    /// <param name="fmotifList">
    /// The fmotif list.
    /// </param>
    private void SecondTempMethod(Fmotif fmotifBuffer, List<Fmotif> fmotifList)
    {
        if (ExtractNoteList(fmotifBuffer).Count == 1)
        {
            var fm = new Fmotif(FmotifType.PartialMinimalMeasure, pauseTreatment);
            for (int j = 0; j < fmotifBuffer.NoteList.Count; j++)
            {
                // заносим
                fm.NoteList.Add((ValueNote)fmotifBuffer.NoteList[j].Clone());
            }

            // добавляем в выходную цепочку получившийся фмотив
            fmotifList.Add((Fmotif)fm.Clone());
            fmotifBuffer.NoteList.Clear();
        }
        else
        {
            // если больше 1 ноты, то вызываем рекурсию на оставшиеся ноты
            // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
            List<Fmotif> dividedSameDuration = DivideSameDurationNotes(fmotifBuffer);
            foreach (Fmotif fmotif in dividedSameDuration)
            {
                // заносим очередной фмотив
                fmotifList.Add((Fmotif)fmotif.Clone());
            }
        }
    }
}
