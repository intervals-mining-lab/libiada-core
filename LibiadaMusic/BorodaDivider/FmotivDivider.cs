using System;
using System.Collections.Generic;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.BorodaDivider
{
    public class FmotivDivider
    {
        private int paramPause; // параметр сохраняется для всего экземпляра класса и потом используется
        //----------------------
        public FmotivChain GetDivision(UniformScoreTrack unitrack, int paramPauseTreat)
        {
            var temp = new FmotivChain {Name = unitrack.Name}; // выходная, результирующая цепочка разбитых ф-мотивов
            paramPause = paramPauseTreat;

            var fmotivBuffer = new Fmotiv(String.Empty);
            // буффер для накопления нот, для последующего анализа его содержимого

            #region заполнение цепи нот, со всех тактов монотрека

            var noteChain = new List<Note>();
            // цепочка нот, куда поочередно складываются ноты из последовательности тактов
            // для дальнейшего их анализа и распределения по ф-мотивам.

            // заполняем NoteChain всеми нотам из данной монофонической цепи unitrack
            foreach (Measure measure in unitrack.MeasureList)
            {
                foreach (Note note in measure.NoteList)
                {
                    noteChain.Add(((Note) note.Clone()));
                }
            }

            #endregion

            int n = 0; // счетчик реальных нот/пауз для первой группировки в реальную нот

            bool wasNote = false;
            // флаг который говорит, что была нота перемещена в буфер после последнего флага Next, для pause notetrace
            bool next = false; // флаг, говорит что собралась очередная нота для рассмотрения
            bool sameDurationChain = false;
            // флаг, говорящий что собирается последовательность равнодлительных звуков (1,2 тип фмотива - ПМТ,ЧМТ)
            bool growingDurationChain = false;
            // флаг, говорящий что собирается возрастающая последовательность (3 тип фмотива)
            bool combination = false;
            // флаг, говорящий что собирается комбинация - ПМТ/ЧМТ и возрастающая последовательность (4 тип фмотива)
            // пока анализируемая цепь содержит элементы, идет выполнение анализа ее содержимого
            while (0 < noteChain.Count)
            {
                fmotivBuffer.NoteList.Add(((Note) noteChain[0].Clone()));
                noteChain.RemoveAt(0);

                #region Сборка последующих нот, в случае Лиги

                // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                if ((int) fmotivBuffer.NoteList[fmotivBuffer.NoteList.Count - 1].Tie != -1)
                {
                    // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                    if (fmotivBuffer.NoteList[fmotivBuffer.NoteList.Count - 1].Tie == 0)
                    {
                        // TODO: желательно сделать проверку когда собирается очередная лига,
                        // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                        while ((int) noteChain[0].Tie == 2)
                        {
                            // пока продолжается лига, заносим ноты в буфер
                            fmotivBuffer.NoteList.Add(((Note) noteChain[0].Clone()));
                            noteChain.RemoveAt(0);
                        }
                        if ((int) noteChain[0].Tie == 1)
                        {
                            // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                            fmotivBuffer.NoteList.Add(((Note) noteChain[0].Clone()));
                            noteChain.RemoveAt(0);

                            wasNote = true; // была нота пермещена в буфер

                            switch (paramPause)
                            {
                                case 0:
                                {
// удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)

                                    // если у очередной ноты нет лиги, то проверяем: если нота - не пауза, то выставляем флаг о следущей рассматриваемой ноте
                                    if (fmotivBuffer.NoteList[fmotivBuffer.NoteList.Count - 1].Pitch.Count > 0)
                                    {
                                        next = true;
                                    }
                                }
                                    break;
                                case 1:
                                {
// длительность паузы прибавляется к предыдущей ноте, а она сама удаляется из текста (1) (пауза - звуковой след ноты)

                                    if (noteChain.Count > 0)
                                    {
                                        //если следующая не паузы то переходим к анализу буфера
                                        if ((noteChain[0].Pitch.Count > 0) && (wasNote))
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
                                }
                                    break;
                                case 2:
                                {
// Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                                    // ничего не треуется
                                    next = true;
                                }
                                    break;

                                default:
                                    throw new Exception("Error Fmotiv.PauseTreatment parameter contains wrong value!");
                            }
                        }
                        else
                        {
                            // когда лига не заканчивается флагом конца, то ошибка
                            throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!End!");
                        }

                    }
                    else
                    {
                        // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                        throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!Begining!");
                    }
                }
                    #endregion

                else
                {
                    // если у очередной ноты нет лиги
                    switch (paramPause)
                    {
                        case 0:
                        {
// удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)

                            // если у очередной ноты нет лиги, то проверяем: если нота - не пауза, то выставляем флаг о следущей рассматриваемой ноте
                            if (fmotivBuffer.NoteList[fmotivBuffer.NoteList.Count - 1].Pitch.Count > 0)
                            {
                                next = true;
                            }
                        }
                            break;
                        case 1:
                        {
// длительность паузы прибавляется к предыдущей ноте, а она сама удаляется из текста (1) (пауза - звуковой след ноты)

                            //проверяем: если нота - не пауза, то выставляем флаг о следущей рассматриваемой ноте
                            if (fmotivBuffer.NoteList[fmotivBuffer.NoteList.Count - 1].Pitch.Count > 0)
                            {
                                wasNote = true;
                            }

                            if (noteChain.Count > 0)
                            {
                                //если следующая в н. тексте не пауза то переходим к анализу буфера
                                if ((noteChain[0].Pitch.Count > 0) && (wasNote))
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
                        }
                            break;
                        case 2:
                        {
// Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                            // ничего не треуется
                            next = true;
                        }
                            break;

                        default:
                            throw new Exception("Error Fmotiv.PauseTreatment parameter contains wrong value!");
                    }
                }

                // если готова (собрана) следущая нота для анализа
                if (next)
                {
                    // убираем флаг следущей готовой (собранной ноты), так как после анализа не известно что там будет
                    next = false;
                    wasNote = false;

                    #region если в буфере 1 собранная нота

                    if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count == 1)
                    {
                        n = fmotivBuffer.NoteList.Count;
                        // сохранили сколько нот/пауз входит в первую рассматриваемую ноту
                    }

                    #endregion

                    #region если в буфере 2 собранные ноты

                    if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count == 2)
                    {
                        // если длительность первой собранной ноты больше длительности второй собранной ноты
                        if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[0].Duration.Value >
                            fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[1].Duration.Value)
                        {
                            // заносим ноты/паузы первой собранной ноты в очередной фмотив с типом ЧМТ, и удаляем из буфера
                            var fm = new Fmotiv("ЧМТ", (temp.FmotivList.Count));
                            for (int i = 0; i < n; i++)
                            {
                                //заносим
                                fm.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                //удаляем
                                fmotivBuffer.NoteList.RemoveAt(0);
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            temp.FmotivList.Add(((Fmotiv) fm.Clone()));

                            //сохранили n на случай если за этим фмотивом следует еще один ЧМТ
                            n = fmotivBuffer.NoteList.Count;
                            // сохранили сколько нот/пауз входит в первую рассматриваемую ноту
                        }
                        else
                        {
                            if (
                                fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[0].Duration.Equals(
                                    fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[1].Duration))
                            {
                                // выставляем флаг для сбора последовательности равнодлительных звуков
                                sameDurationChain = true;
                                n = fmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер

                            }
                            else
                            {
                                if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[0].Duration.Value <
                                    fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[1].Duration.Value)
                                {
                                    // выставляем флаг для сбора возрастающей последовательности
                                    growingDurationChain = true;
                                    n = fmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер
                                }
                            }
                        }
                    }

                    #endregion

                    #region если в буфере больше 2-х собранных нот

                    if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count > 2)
                    {
                        #region сбор равнодлительных нот?

                        if (sameDurationChain)
                        {
                            // если длительность предпоследнего меньше длительности последнего
                            if (
                                fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[
                                    fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count - 2].Duration
                                    .Value <
                                fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[
                                    fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count - 1].Duration
                                    .Value)
                            {
                                var fmotivbuffer2 = new Fmotiv(String.Empty);
                                // помещаем в буффер2 последнюю собранную ноту - большей длительности чем все равнодлительные
                                int count = fmotivBuffer.NoteList.Count; // так как меняется в процессе
                                for (int i = n; i < count; i++)
                                {
                                    fmotivbuffer2.NoteList.Add(((Note) fmotivBuffer.NoteList[n].Clone()));
                                    fmotivBuffer.NoteList.RemoveAt(n);
                                }

                                // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                                // заисключением последнего фмотива - он останется в буфере вместе с нотой длительность которой больше последней ноты этого фмотива
                                List<Fmotiv> dividedSameDuration = DivideSameDurationNotes(fmotivBuffer);
                                for (int i = 0; i < (dividedSameDuration.Count - 1); i++)
                                {
                                    // заносим очередной фмотив
                                    temp.FmotivList.Add(((Fmotiv) dividedSameDuration[i].Clone()));
                                    // присваиваем очередной id
                                    temp.FmotivList[temp.FmotivList.Count - 1].Id = (temp.FmotivList.Count - 1);
                                }

                                // в буфер заносим последний фмотив цепочки фмотивов нот с равнодлительностью
                                fmotivBuffer = (Fmotiv) dividedSameDuration[dividedSameDuration.Count - 1].Clone();
                                // добавляем сохраненную ноту с большой длительностью
                                for (int i = 0; i < fmotivbuffer2.NoteList.Count; i++)
                                {
                                    fmotivBuffer.NoteList.Add(((Note) fmotivbuffer2.NoteList[i].Clone()));
                                }

                                combination = true; // флаг комбинации
                                growingDurationChain = true;
                                // флаг возрастающей последовательности, чтобы завершить фмотив - комбинация
                                sameDurationChain = false; // убираем флаг для сбора равнодлительных нот

                                n = fmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в текущий буфер

                            }
                            // если длительность предпоследнего равна длительности последнего
                            if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[
                                fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count - 2].Duration
                                .Equals
                                (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[
                                    fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count - 1].Duration))
                            {
                                //записываем очередную ноты в фмотив с типом последовательность равнодлительных звуков (она уже записана, поэтому просто сохраняем число входящих в фмотив на данный момент нот/пауз)
                                n = fmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер
                            }
                            // если длительность предпоследнего больше длительности последнего
                            if (
                                fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[
                                    fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count - 2].Duration
                                    .Value >
                                fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[
                                    fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count - 1].Duration
                                    .Value)
                            {
                                var fmotivbuffer2 = new Fmotiv(String.Empty);
                                // помещаем в буффер2 последнюю собранную ноту - меньшей длительности чем все равнодлительные
                                int count = fmotivBuffer.NoteList.Count; // так как меняется в процессе
                                for (int i = n; i < count; i++)
                                {
                                    fmotivbuffer2.NoteList.Add(((Note) fmotivBuffer.NoteList[n].Clone()));
                                    fmotivBuffer.NoteList.RemoveAt(n);
                                }
                                // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                                foreach (Fmotiv fmotiv in DivideSameDurationNotes(fmotivBuffer))
                                {
                                    // заносим очередной фмотив
                                    temp.FmotivList.Add(((Fmotiv) fmotiv.Clone()));
                                    // присваиваем очередной id
                                    temp.FmotivList[temp.FmotivList.Count - 1].Id = (temp.FmotivList.Count - 1);
                                }

                                // очищаем буффер
                                fmotivBuffer.NoteList.Clear();

                                // добавляем состав сохраненной ноты (паузы/лиги) с меньшей длительностью в буфер
                                for (int i = 0; i < fmotivbuffer2.NoteList.Count; i++)
                                {
                                    fmotivBuffer.NoteList.Add(((Note) fmotivbuffer2.NoteList[i].Clone()));
                                }

                                sameDurationChain = false; // убираем флаг для сбора равнодлительных нот
                                n = fmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в текущий буфер
                            }

                        }
                            #endregion

                            #region сбор возрастающей последовательности?

                        else
                        {
                            if (growingDurationChain)
                            {
                                // если длительность предпоследнего меньше длительности последнего
                                if (
                                    fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[
                                        fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count - 2]
                                        .Duration.Value <
                                    fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[
                                        fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count - 1]
                                        .Duration.Value)
                                {
                                    //записываем очередную ноты в фмотив с типом возрастающая последовательность (она уже записана, поэтому просто сохраняем число входящих в фмотив на данный момент нот)
                                    n = fmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер
                                }
                                else
                                {
                                    // иначе если длительности равны, или последняя по длительности меньше предпоследней, то составляем новый фмотив
                                    //также сохраняем не вошедшую последнюю ноту (не удаляем ее)
                                    if (combination)
                                    {
                                        var fm = new Fmotiv(fmotivBuffer.Type + "ВП", (temp.FmotivList.Count));
                                        // ЧМТВП или ПМТВП
                                        for (int i = 0; i < n; i++)
                                        {
                                            //заносим
                                            fm.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                            //удаляем
                                            fmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        // добавляем в выходную цепочку получившийся фмотив
                                        temp.FmotivList.Add(((Fmotiv) fm.Clone()));

                                        n = fmotivBuffer.NoteList.Count;
                                        // сохранили сколько нот/пауз осталось в буфере от последней не вошедшей в фмотив ноты
                                        growingDurationChain = false;
                                        // убрали флаг сбора возрастающей последовательности
                                        combination = false; // убрали флаг сбора возрастающей последовательности

                                    }
                                    else
                                    {
                                        var fm = new Fmotiv("ВП", (temp.FmotivList.Count));
                                        for (int i = 0; i < n; i++)
                                        {
                                            //заносим
                                            fm.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                            //удаляем
                                            fmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        // добавляем в выходную цепочку получившийся фмотив
                                        temp.FmotivList.Add(((Fmotiv) fm.Clone()));

                                        n = fmotivBuffer.NoteList.Count;
                                        // сохранили сколько нот/пауз осталось в буфере от последней не вошедшей в фмотив ноты
                                        growingDurationChain = false;
                                        // убрали флаг сбора возрастающей последовательности
                                    }
                                }

                            }
                        }

                        #endregion
                    }

                    #endregion
                }

            }

            #region анализ оставшихся нот в буфере после цикла

            // если в буфере осталась 1 непроанализированная нота
            if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count == 1)
            {
                // заносим ноты/паузы 1 собранной ноты в очередной фмотив с типом ЧМТ, и удаляем из буфера
                var fm = new Fmotiv("ЧМТ", (temp.FmotivList.Count));
                //for (int i = 0; i < FmotivBuffer.NoteList.Count; i++)
                foreach (Note note in fmotivBuffer.NoteList)
                {
                    //заносим
                    fm.NoteList.Add(((Note) note.Clone()));
                }
                // добавляем в выходную цепочку получившийся фмотив
                temp.FmotivList.Add(((Fmotiv) fm.Clone()));

                //очищаем буффер
                fmotivBuffer.NoteList.Clear();
            }

            // если в буфере остались непроанализированные ноты (больше 1)
            if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count > 1)
            {
                if (sameDurationChain)
                {
                    // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                    foreach (Fmotiv fmotiv in DivideSameDurationNotes(fmotivBuffer))
                    {
                        // заносим очередной фмотив
                        temp.FmotivList.Add(((Fmotiv) fmotiv.Clone()));
                        // присваиваем очередной id
                        temp.FmotivList[temp.FmotivList.Count - 1].Id = (temp.FmotivList.Count - 1);
                    }
                    // очищаем буффер
                    fmotivBuffer.NoteList.Clear();
                    sameDurationChain = false; // убираем флаг для сбора равнодлительных нот
                }
                else
                {
                    if (growingDurationChain)
                    {
                        if (combination)
                        {
                            //заносим оставшиеся ноты в комбинированный фмотив ЧМТ/ПМТ + ВП и в выходную цепочку
                            var fm = new Fmotiv(fmotivBuffer.Type + "ВП", (temp.FmotivList.Count)); // ЧМТВП или ПМТВП
                            foreach (Note note in fmotivBuffer.NoteList)
                            {
                                //заносим
                                fm.NoteList.Add(((Note) note.Clone()));
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            temp.FmotivList.Add(((Fmotiv) fm.Clone()));

                            // очищаем буффер
                            fmotivBuffer.NoteList.Clear();
                        }
                        else
                        {
                            // заносим оставшиеся ноты в фмотив ВП и в выходную цепочку
                            Fmotiv fm = new Fmotiv("ВП", (temp.FmotivList.Count));
                            foreach (Note note in fmotivBuffer.NoteList)
                            {
                                //заносим
                                fm.NoteList.Add(((Note) note.Clone()));
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            temp.FmotivList.Add(((Fmotiv) fm.Clone()));
                            // очищаем буффер
                            fmotivBuffer.NoteList.Clear();
                        }
                    }
                }
            }

            #endregion

            return temp;
        }

        private List<Fmotiv> DivideSameDurationNotes(Fmotiv FmotivBuf)
        {
            var fmotivBuffer = (Fmotiv) FmotivBuf.Clone(); // создаем копию входного объекта
            var flTemp = new List<Fmotiv>(); // выходной список фмотивов

            // проверка на случай когда в аругменте метода количество собранных нот (из пауз/лиг) меньше двух
            if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count < 2)
            {
                throw new Exception("LibiadaMusic DivideSameDurationNotes: notes < 2");
            }

            #region если количество собранных нот делится на 2

            if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count%2 == 0)
            {
                // то начинаем анализ из расчета : по две ноты в фмотиве
                // сохраняем количество раз, так как потом меняется
                int count = fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count/2;
                for (int i = 0; i < count; i++)
                {
                    if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[0].Priority <
                        fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[1].Priority)
                    {
                        // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                        // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                        var fmotiv = new Fmotiv("ПМТ");

                        // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимостиот того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        while (fmotivBuffer.NoteList.Count > 0)
                        {
                            if (fmotiv.PauseTreatment(paramPause).TieGathered().NoteList.Count == 2)
                            {
                                // Silence Note OR Ignore Pause
                                if (paramPause != (int) ParamPauseTreatment.NoteTrace)
                                {
                                    break;
                                }
                                // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                if ((paramPause == (int) ParamPauseTreatment.NoteTrace) &&
                                    (fmotivBuffer.NoteList[0].Pitch.Count > 0))
                                {
                                    break;
                                }
                            }

                            fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                            fmotivBuffer.NoteList.RemoveAt(0);

                            #region Сборка последующих нот, в случае Лиги

                            // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                            if ((int) fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                            {
                                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                {
                                    // TODO: желательно сделать проверку когда собирается очередная лига,
                                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                    while ((int) fmotivBuffer.NoteList[0].Tie == 2)
                                    {
                                        // пока продолжается лига, заносим ноты в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    if ((int) fmotivBuffer.NoteList[0].Tie == 1)
                                    {
                                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    else
                                    {
                                        // когда лига не заканчивается флагом конца, то ошибка
                                        throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!End!");
                                    }
                                }
                                else
                                {
                                    // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                    throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!Begining!");
                                }
                            }

                            #endregion
                        }

                        // и складываем в выходную цепочку
                        flTemp.Add(((Fmotiv) fmotiv.Clone()));
                    }
                    else
                    {
                        // приоритет первой ноты ниже приоритета второй ноты (метрически слабее)
                        // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                        // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                        // потому что количество равндлительных звуков поменялось, и алгоритм анализа может поменяться
                        var fmotiv = new Fmotiv("ЧМТ");

                        // собираем в цикле, пока не кончатся ноты в буфере 1 полноценную ноту в зависимостиот того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        while (fmotivBuffer.NoteList.Count > 0)
                        {
                            if (fmotiv.PauseTreatment(paramPause).TieGathered().NoteList.Count == 1)
                            {
                                // Silence Note OR Ignore Pause
                                if (paramPause != (int) ParamPauseTreatment.NoteTrace)
                                {
                                    break;
                                }
                                // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                if ((paramPause == (int) ParamPauseTreatment.NoteTrace) &&
                                    (fmotivBuffer.NoteList[0].Pitch.Count > 0))
                                {
                                    break;
                                }
                            }

                            fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                            fmotivBuffer.NoteList.RemoveAt(0);

                            #region Сборка последующих нот, в случае Лиги

                            // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                            if ((int) fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                            {
                                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                {
                                    // TODO: желательно сделать проверку когда собирается очередная лига,
                                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                    while ((int) fmotivBuffer.NoteList[0].Tie == 2)
                                    {
                                        // пока продолжается лига, заносим ноты в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    if ((int) fmotivBuffer.NoteList[0].Tie == 1)
                                    {
                                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    else
                                    {
                                        // когда лига не заканчивается флагом конца, то ошибка
                                        throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!End!");
                                    }
                                }
                                else
                                {
                                    // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                    throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!Begining!");
                                }
                            }

                            #endregion
                        }

                        // и складываем в выходную цепочку
                        flTemp.Add(((Fmotiv) fmotiv.Clone()));

                        // если осталась одна нота то заносим ее в фмотив ЧМТ
                        if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count == 1)
                        {
                            var fm = new Fmotiv("ЧМТ");
                            for (int j = 0; j < fmotivBuffer.NoteList.Count; j++)
                            {
                                //заносим
                                fm.NoteList.Add(((Note) fmotivBuffer.NoteList[j].Clone()));
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            flTemp.Add(((Fmotiv) fm.Clone()));
                            fmotivBuffer.NoteList.Clear();
                        }
                        else
                        {
                            // если больше 1 ноты, то вызываем рекурсию на оставшиеся ноты
                            // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                            List<Fmotiv> dividedSameDuration = DivideSameDurationNotes(fmotivBuffer);
                            for (int j = 0; j < dividedSameDuration.Count; j++)
                            {
                                // заносим очередной фмотив
                                flTemp.Add(((Fmotiv) dividedSameDuration[j].Clone()));
                            }
                        }

                        return flTemp;
                    }
                }
                // прошли все ПМТ без ЧМТ, то вернуть результат
                return flTemp;

            }

            #endregion

            #region если количество собранных нот делится на 3

            if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count%3 == 0)
            {
                // то начинаем анализ из расчета : по три ноты в фмотиве
                // сохраняем количество раз, так как потом меняется
                int count = fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count/3;
                for (int i = 0; i < count; i++)
                {
                    if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[0].Priority <
                        fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[1].Priority)
                    {
                        // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                        if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[0].Priority <
                            fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[2].Priority)
                        {
                            // приоритет первой ноты выше приоритета третьей ноты (собранные ноты)
                            // ПМТ и записываем все что входит в цепочку нот - в эти три собранные ноты, в очередной фмотив
                            var fmotiv = new Fmotiv("ПМТ");

                            // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                            //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                            while (fmotivBuffer.NoteList.Count > 0)
                            {
                                if (fmotiv.PauseTreatment(paramPause).TieGathered().NoteList.Count == 3)
                                {
                                    // Silence Note OR Ignore Pause
                                    if (paramPause != (int) ParamPauseTreatment.NoteTrace)
                                    {
                                        break;
                                    }
                                    // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                    if ((paramPause == (int) ParamPauseTreatment.NoteTrace) &&
                                        (fmotivBuffer.NoteList[0].Pitch.Count > 0))
                                    {
                                        break;
                                    }
                                }
                                fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                fmotivBuffer.NoteList.RemoveAt(0);

                                #region Сборка последующих нот, в случае Лиги

                                // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                                if ((int) fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                                {
                                    // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                    if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                    {
                                        // TODO: желательно сделать проверку когда собирается очередная лига,
                                        // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                        while ((int) fmotivBuffer.NoteList[0].Tie == 2)
                                        {
                                            // пока продолжается лига, заносим ноты в буфер
                                            fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                            fmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        if ((int) fmotivBuffer.NoteList[0].Tie == 1)
                                        {
                                            // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                            fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                            fmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        else
                                        {
                                            // когда лига не заканчивается флагом конца, то ошибка
                                            throw new Exception(
                                                "LibiadaMusic: FmotivDivider, wrong Tie organization!End!");
                                        }
                                    }
                                    else
                                    {
                                        // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                        throw new Exception(
                                            "LibiadaMusic: FmotivDivider, wrong Tie organization!Begining!");
                                    }
                                }

                                #endregion
                            }
                            // и складываем в выходную цепочку
                            flTemp.Add(((Fmotiv) fmotiv.Clone()));
                        }
                        else
                        {
                            // приоритет первой ноты ниже или равен приоритету третьей ноты (собранные ноты)
                            // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                            // (ЧМТ - если есть знак триоли хотя бы у одной ноты)

                            string typeF = "ПМТ"; // тип ПМТ если не триоль
                            if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[0].Triplet ||
                                fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[1].Triplet)
                            {
                                typeF = "ЧМТ"; // если есть хотя б один знак триоли 
                            }

                            var fmotiv = new Fmotiv(typeF);

                            // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимости от того, чем мы считаем паузу 
                            //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                            while (fmotivBuffer.NoteList.Count > 0)
                            {
                                if (fmotiv.PauseTreatment(paramPause).TieGathered().NoteList.Count == 2)
                                {
                                    // Silence Note OR Ignore Pause
                                    if (paramPause != (int) ParamPauseTreatment.NoteTrace)
                                    {
                                        break;
                                    }
                                    // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                    if ((paramPause == (int) ParamPauseTreatment.NoteTrace) &&
                                        (fmotivBuffer.NoteList[0].Pitch.Count > 0))
                                    {
                                        break;
                                    }
                                }
                                fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                fmotivBuffer.NoteList.RemoveAt(0);

                                #region Сборка последующих нот, в случае Лиги

                                // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                                if ((int) fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                                {
                                    // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                    if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                    {
                                        // TODO: желательно сделать проверку когда собирается очередная лига,
                                        // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                        while ((int) fmotivBuffer.NoteList[0].Tie == 2)
                                        {
                                            // пока продолжается лига, заносим ноты в буфер
                                            fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                            fmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        if ((int) fmotivBuffer.NoteList[0].Tie == 1)
                                        {
                                            // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                            fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                            fmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        else
                                        {
                                            // когда лига не заканчивается флагом конца, то ошибка
                                            throw new Exception(
                                                "LibiadaMusic: FmotivDivider, wrong Tie organization!End!");
                                        }
                                    }
                                    else
                                    {
                                        // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                        throw new Exception(
                                            "LibiadaMusic: FmotivDivider, wrong Tie organization!Begining!");
                                    }
                                }

                                #endregion
                            }
                            // и складываем в выходную цепочку
                            flTemp.Add(((Fmotiv) fmotiv.Clone()));

                            // если осталась одна нота то заносим ее в фмотив ЧМТ
                            if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count == 1)
                            {
                                var fm = new Fmotiv("ЧМТ");
                                for (int j = 0; j < fmotivBuffer.NoteList.Count; j++)
                                {
                                    //заносим
                                    fm.NoteList.Add(((Note) fmotivBuffer.NoteList[j].Clone()));
                                }
                                // добавляем в выходную цепочку получившийся фмотив
                                flTemp.Add(((Fmotiv) fm.Clone()));
                                fmotivBuffer.NoteList.Clear();
                            }
                            else
                            {
                                // если больше 1 ноты, то вызываем рекурсию на оставшиеся ноты
                                // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                                List<Fmotiv> dividedSameDuration = DivideSameDurationNotes(fmotivBuffer);
                                for (int j = 0;
                                    j < dividedSameDuration.Count;
                                    j++)
                                {
                                    // заносим очередной фмотив
                                    flTemp.Add(((Fmotiv) dividedSameDuration[j].Clone()));
                                }
                            }
                            return flTemp;
                        }

                    }
                    else
                    {
                        // приоритет первой ноты ниже или равен приоритету второй ноты (метрически слабее или равен)
                        // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                        // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                        // потому что количество равнодлительных звуков поменялось, и алгоритм анализа может поменяться
                        var fmotiv = new Fmotiv("ЧМТ");

                        // собираем в цикле, пока не кончатся ноты в буфере 1 полноценная нота в зависимости от того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        while (fmotivBuffer.NoteList.Count > 0)
                        {
                            if (fmotiv.PauseTreatment(paramPause).TieGathered().NoteList.Count == 1)
                            {
                                // Silence Note OR Ignore Pause
                                if (paramPause != (int) ParamPauseTreatment.NoteTrace)
                                {
                                    break;
                                }
                                // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                if ((paramPause == (int) ParamPauseTreatment.NoteTrace) &&
                                    (fmotivBuffer.NoteList[0].Pitch.Count > 0))
                                {
                                    break;
                                }
                            }
                            fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                            fmotivBuffer.NoteList.RemoveAt(0);

                            #region Сборка последующих нот, в случае Лиги

                            // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                            if ((int) fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                            {
                                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                {
                                    // TODO: желательно сделать проверку когда собирается очередная лига,
                                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                    while ((int) fmotivBuffer.NoteList[0].Tie == 2)
                                    {
                                        // пока продолжается лига, заносим ноты в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    if ((int) fmotivBuffer.NoteList[0].Tie == 1)
                                    {
                                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    else
                                    {
                                        // когда лига не заканчивается флагом конца, то ошибка
                                        throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!End!");
                                    }
                                }
                                else
                                {
                                    // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                    throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!Begining!");
                                }
                            }

                            #endregion
                        }

                        // и складываем в выходную цепочку
                        flTemp.Add(((Fmotiv) fmotiv.Clone()));

                        // если осталась одна нота то заносим ее в фмотив ЧМТ
                        if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count == 1)
                        {
                            var fm = new Fmotiv("ЧМТ");
                            for (int j = 0; j < fmotivBuffer.NoteList.Count; j++)
                            {
                                //заносим
                                fm.NoteList.Add(((Note) fmotivBuffer.NoteList[j].Clone()));
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            flTemp.Add(((Fmotiv) fm.Clone()));
                            fmotivBuffer.NoteList.Clear();
                        }
                        else
                        {
                            // если больше 1 ноты, то вызываем рекурсию на оставшиеся ноты
                            // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                            List<Fmotiv> dividedSameDuration = DivideSameDurationNotes(fmotivBuffer);
                            for (int j = 0;
                                j < dividedSameDuration.Count;
                                j++)
                            {
                                // заносим очередной фмотив
                                flTemp.Add(((Fmotiv) dividedSameDuration[j].Clone()));
                            }
                        }
                        return flTemp;
                    }
                }

                // прошли все ПМТ без ЧМТ, то вернуть результат
                return flTemp;
            }
                #endregion
                #region если количество нот не делится на два и на три, оно- простое число (как по бороде)

            else
            {
                // то начинаем анализ из расчета : по две ноты в фмотиве (к-3)/2 раза, а в последнем 3 ноты
                // сохраняем количество раз, так как потом меняется
                int count = (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count - 3)/2;
                for (int i = 0; i < count; i++)
                {
                    if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[0].Priority <
                        fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[1].Priority)
                    {
                        // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                        // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                        var fmotiv = new Fmotiv("ПМТ");

                        // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимости от того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        while (fmotivBuffer.NoteList.Count > 0)
                        {
                            if (fmotiv.PauseTreatment(paramPause).TieGathered().NoteList.Count == 2)
                            {
                                // Silence Note OR Ignore Pause
                                if (paramPause != (int) ParamPauseTreatment.NoteTrace)
                                {
                                    break;
                                }
                                // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                if ((paramPause == (int) ParamPauseTreatment.NoteTrace) &&
                                    (fmotivBuffer.NoteList[0].Pitch.Count > 0))
                                {
                                    break;
                                }
                            }
                            fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                            fmotivBuffer.NoteList.RemoveAt(0);

                            #region Сборка последующих нот, в случае Лиги

                            // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                            if ((int) fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                            {
                                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                {
                                    // TODO: желательно сделать проверку когда собирается очередная лига,
                                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                    while ((int) fmotivBuffer.NoteList[0].Tie == 2)
                                    {
                                        // пока продолжается лига, заносим ноты в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    if ((int) fmotivBuffer.NoteList[0].Tie == 1)
                                    {
                                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    else
                                    {
                                        // когда лига не заканчивается флагом конца, то ошибка
                                        throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!End!");
                                    }
                                }
                                else
                                {
                                    // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                    throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!Begining!");
                                }
                            }

                            #endregion
                        }
                        // и складываем в выходную цепочку
                        flTemp.Add(((Fmotiv) fmotiv.Clone()));
                    }
                    else
                    {
                        // приоритет первой ноты ниже приоритета второй ноты (метрически слабее)
                        // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                        // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                        // потому что количество равндлительных звуков поменялось, и алгоритм анализа может поменяться
                        var fmotiv = new Fmotiv("ЧМТ");

                        // собираем в цикле, пока не кончатся ноты в буфере 1 полноценную ноту в зависимости от того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        while (fmotivBuffer.NoteList.Count > 0)
                        {
                            if (fmotiv.PauseTreatment(paramPause).TieGathered().NoteList.Count == 1)
                            {
                                // Silence Note OR Ignore Pause
                                if (paramPause != (int) ParamPauseTreatment.NoteTrace)
                                {
                                    break;
                                }
                                // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                if ((paramPause == (int) ParamPauseTreatment.NoteTrace) &&
                                    (fmotivBuffer.NoteList[0].Pitch.Count > 0))
                                {
                                    break;
                                }
                            }
                            fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                            fmotivBuffer.NoteList.RemoveAt(0);

                            #region Сборка последующих нот, в случае Лиги

                            // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                            if ((int) fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                            {
                                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                {
                                    // TODO: желательно сделать проверку когда собирается очередная лига,
                                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                    while ((int) fmotivBuffer.NoteList[0].Tie == 2)
                                    {
                                        // пока продолжается лига, заносим ноты в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    if ((int) fmotivBuffer.NoteList[0].Tie == 1)
                                    {
                                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    else
                                    {
                                        // когда лига не заканчивается флагом конца, то ошибка
                                        throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!End!");
                                    }
                                }
                                else
                                {
                                    // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                    throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!Begining!");
                                }
                            }

                            #endregion
                        }

                        // и складываем в выходную цепочку
                        flTemp.Add(((Fmotiv) fmotiv.Clone()));

                        // вызываем рекурсию на оставшиеся ноты
                        // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                        List<Fmotiv> dividedSameDuration = DivideSameDurationNotes(fmotivBuffer);
                        for (int j = 0; j < dividedSameDuration.Count; j++)
                        {
                            // заносим очередной фмотив
                            flTemp.Add(((Fmotiv) dividedSameDuration[j].Clone()));
                        }

                        return flTemp;
                    }

                }

                // анализируем оставшиеся 3 ноты
                if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[0].Priority <
                    fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[1].Priority)
                {
                    // приоритет первой ноты выше приоритета второй ноты (собранные ноты) !!!!!!!!!!!!!!!!!!! сравнение на саомо деле происход первой и третьей, разве нет? 08.04.2012
                    if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[0].Priority <
                        fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[2].Priority)
                    {
                        // приоритет первой ноты выше приоритета третьей ноты (собранные ноты)
                        // ПМТ и записываем все что входит в цепочку нот - в эти три собранные ноты, в очередной фмотив
                        var fmotiv = new Fmotiv("ПМТ");

                        // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        while (fmotivBuffer.NoteList.Count > 0)
                        {
                            if (fmotiv.PauseTreatment(paramPause).TieGathered().NoteList.Count == 3)
                            {
                                // Silence Note OR Ignore Pause
                                if (paramPause != (int) ParamPauseTreatment.NoteTrace)
                                {
                                    break;
                                }
                                // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                if ((paramPause == (int) ParamPauseTreatment.NoteTrace) &&
                                    (fmotivBuffer.NoteList[0].Pitch.Count > 0))
                                {
                                    break;
                                }
                            }
                            fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                            fmotivBuffer.NoteList.RemoveAt(0);

                            #region Сборка последующих нот, в случае Лиги

                            // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                            if ((int) fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                            {
                                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                {
                                    // TODO: желательно сделать проверку когда собирается очередная лига,
                                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                    while ((int) fmotivBuffer.NoteList[0].Tie == 2)
                                    {
                                        // пока продолжается лига, заносим ноты в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    if ((int) fmotivBuffer.NoteList[0].Tie == 1)
                                    {
                                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    else
                                    {
                                        // когда лига не заканчивается флагом конца, то ошибка
                                        throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!End!");
                                    }
                                }
                                else
                                {
                                    // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                    throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!Begining!");
                                }
                            }

                            #endregion
                        }
                        // и складываем в выходную цепочку
                        flTemp.Add(((Fmotiv) fmotiv.Clone()));
                    }
                    else
                    {
                        // приоритет первой ноты ниже или равен приоритету третьей ноты (собранные ноты)
                        // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                        // (ЧМТ - если есть знак триоли хотя бы у одной ноты)

                        string typeF = "ПМТ"; // тип ПМТ если не триоль
                        if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[0].Triplet ||
                            fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList[1].Triplet)
                        {
                            typeF = "ЧМТ"; // если есть хотя б один знак триоли 
                        }

                        var fmotiv = new Fmotiv(typeF);

                        // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        while (fmotivBuffer.NoteList.Count > 0)
                        {
                            if (fmotiv.PauseTreatment(paramPause).TieGathered().NoteList.Count == 2)
                            {
                                // Silence Note OR Ignore Pause
                                if (paramPause != (int) ParamPauseTreatment.NoteTrace)
                                {
                                    break;
                                }
                                // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                if ((paramPause == (int) ParamPauseTreatment.NoteTrace) &&
                                    (fmotivBuffer.NoteList[0].Pitch.Count > 0))
                                {
                                    break;
                                }
                            }
                            fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                            fmotivBuffer.NoteList.RemoveAt(0);

                            #region Сборка последующих нот, в случае Лиги

                            // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                            if ((int) fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                            {
                                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                {
                                    // TODO: желательно сделать проверку когда собирается очередная лига,
                                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                    while ((int) fmotivBuffer.NoteList[0].Tie == 2)
                                    {
                                        // пока продолжается лига, заносим ноты в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    if ((int) fmotivBuffer.NoteList[0].Tie == 1)
                                    {
                                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                        fmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    else
                                    {
                                        // когда лига не заканчивается флагом конца, то ошибка
                                        throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!End!");
                                    }
                                }
                                else
                                {
                                    // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                    throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!Begining!");
                                }
                            }

                            #endregion
                        }
                        // и складываем в выходную цепочку
                        flTemp.Add(((Fmotiv) fmotiv.Clone()));

                        // если осталась одна нота то заносим ее в фмотив ЧМТ
                        if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count == 1)
                        {
                            var fm = new Fmotiv("ЧМТ");
                            for (int j = 0; j < fmotivBuffer.NoteList.Count; j++)
                            {
                                //заносим
                                fm.NoteList.Add(((Note) fmotivBuffer.NoteList[j].Clone()));
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            flTemp.Add(((Fmotiv) fm.Clone()));
                            fmotivBuffer.NoteList.Clear();
                        }
                        else
                        {
                            // если больше 1 ноты, то вызываем рекурсию на оставшиеся ноты
                            // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                            List<Fmotiv> dividedSameDuration = DivideSameDurationNotes(fmotivBuffer);
                            for (int j = 0;
                                j < dividedSameDuration.Count;
                                j++)
                            {
                                // заносим очередной фмотив
                                flTemp.Add(((Fmotiv) dividedSameDuration[j].Clone()));
                            }
                        }
                        return flTemp;
                    }

                }
                else
                {
                    // приоритет первой ноты ниже или равен приоритету второй ноты (метрически слабее или равен)
                    // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                    // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                    // потому что количество равнодлительных звуков поменялось, и алгоритм анализа может поменяться
                    var fmotiv = new Fmotiv("ЧМТ");

                    // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                    //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                    while (fmotivBuffer.NoteList.Count > 0)
                    {
                        if (fmotiv.PauseTreatment(paramPause).TieGathered().NoteList.Count == 1)
                        {
                            // Silence Note OR Ignore Pause
                            if (paramPause != (int) ParamPauseTreatment.NoteTrace)
                            {
                                break;
                            }
                            // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                            if ((paramPause == (int) ParamPauseTreatment.NoteTrace) &&
                                (fmotivBuffer.NoteList[0].Pitch.Count > 0))
                            {
                                break;
                            }
                        }
                        fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                        fmotivBuffer.NoteList.RemoveAt(0);

                        #region Сборка последующих нот, в случае Лиги

                        // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                        if ((int) fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                        {
                            // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                            if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                            {
                                // TODO: желательно сделать проверку когда собирается очередная лига,
                                // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                while ((int) fmotivBuffer.NoteList[0].Tie == 2)
                                {
                                    // пока продолжается лига, заносим ноты в буфер
                                    fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                    fmotivBuffer.NoteList.RemoveAt(0);
                                }
                                if ((int) fmotivBuffer.NoteList[0].Tie == 1)
                                {
                                    // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                    fmotiv.NoteList.Add(((Note) fmotivBuffer.NoteList[0].Clone()));
                                    fmotivBuffer.NoteList.RemoveAt(0);
                                }
                                else
                                {
                                    // когда лига не заканчивается флагом конца, то ошибка
                                    throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!End!");
                                }
                            }
                            else
                            {
                                // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                throw new Exception("LibiadaMusic: FmotivDivider, wrong Tie organization!Begining!");
                            }
                        }

                        #endregion
                    }

                    // и складываем в выходную цепочку
                    flTemp.Add(((Fmotiv) fmotiv.Clone()));

                    // если осталась одна нота то заносим ее в фмотив ЧМТ
                    if (fmotivBuffer.PauseTreatment(paramPause).TieGathered().NoteList.Count == 1)
                    {
                        var fm = new Fmotiv("ЧМТ");
                        for (int j = 0; j < fmotivBuffer.NoteList.Count; j++)
                        {
                            //заносим
                            fm.NoteList.Add(((Note) fmotivBuffer.NoteList[j].Clone()));
                        }
                        // добавляем в выходную цепочку получившийся фмотив
                        flTemp.Add(((Fmotiv) fm.Clone()));
                        fmotivBuffer.NoteList.Clear();
                    }
                    else
                    {
                        // если больше 1 ноты, то вызываем рекурсию на оставшиеся ноты
                        // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                        List<Fmotiv> dividedSameDuration = DivideSameDurationNotes(fmotivBuffer);
                        for (int j = 0;
                            j < dividedSameDuration.Count;
                            j++)
                        {
                            // заносим очередной фмотив
                            flTemp.Add(((Fmotiv) dividedSameDuration[j].Clone()));
                        }
                    }
                    return flTemp;
                }

                // если все собрали, то возвращаем выходную цепочку
                return flTemp;
            }

            #endregion
        }

    }
}