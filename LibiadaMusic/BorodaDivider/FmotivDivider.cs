﻿using System;
using System.Collections.Generic;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.BorodaDivider
{
    public class FmotivDivider
    {
        /// <summary>
        ///  параметр сохраняется для всего экземпляра класса и потом используется
        /// </summary>
        private ParamPauseTreatment paramPauseTreatment;
        //----------------------
        public FmotivChain GetDivision(CongenericScoreTrack congenericTrack, ParamPauseTreatment paramPauseTreatment)
        {
            var chain = new FmotivChain {Name = congenericTrack.Name}; // выходная, результирующая цепочка разбитых ф-мотивов
            this.paramPauseTreatment = paramPauseTreatment;

            var fmotivBuffer = new Fmotiv(String.Empty);
            // буффер для накопления нот, для последующего анализа его содержимого

            var noteChain = new List<ValueNote>();
            // цепочка нот, куда поочередно складываются ноты из последовательности тактов
            // для дальнейшего их анализа и распределения по ф-мотивам.

            // заполняем NoteChain всеми нотам из данной монофонической цепи unitrack
            foreach (Measure measure in congenericTrack.MeasureList)
            {
                foreach (ValueNote note in measure.NoteList)
                {
                    noteChain.Add(((ValueNote) note.Clone()));
                }
            }

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
            while (noteChain.Count > 0)
            {
                fmotivBuffer.NoteList.Add(((ValueNote) noteChain[0].Clone()));
                noteChain.RemoveAt(0);

                // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                if (fmotivBuffer.NoteList[fmotivBuffer.NoteList.Count - 1].Tie != Tie.None)
                {
                    // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                    if (fmotivBuffer.NoteList[fmotivBuffer.NoteList.Count - 1].Tie == Tie.Start)
                    {
                        // TODO: желательно сделать проверку когда собирается очередная лига,
                        // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                        while (noteChain[0].Tie == Tie.StartStop)
                        {
                            // пока продолжается лига, заносим ноты в буфер
                            fmotivBuffer.NoteList.Add(((ValueNote) noteChain[0].Clone()));
                            noteChain.RemoveAt(0);
                        }
                        if (noteChain[0].Tie == Tie.Stop)
                        {
                            // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                            fmotivBuffer.NoteList.Add(((ValueNote) noteChain[0].Clone()));
                            noteChain.RemoveAt(0);

                            wasNote = true; // была нота пермещена в буфер

                            switch (paramPauseTreatment)
                            {
                                case ParamPauseTreatment.Ignore:
                                    // удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)
                                    // если у очередной ноты нет лиги, то проверяем: если нота - не пауза, то выставляем флаг о следущей рассматриваемой ноте
                                    if (fmotivBuffer.NoteList[fmotivBuffer.NoteList.Count - 1].Pitch.Count > 0)
                                    {
                                        next = true;
                                    }
                                    break;
                                case ParamPauseTreatment.NoteTrace:
                                    // длительность паузы прибавляется к предыдущей ноте, а она сама удаляется из текста (1) (пауза - звуковой след ноты)
                                    if (noteChain.Count > 0)
                                    {
                                        //если следующая не паузы то переходим к анализу буфера
                                        if ((noteChain[0].Pitch.Count > 0))
                                        {
                                            next = true;
                                        }
                                    }
                                    else
                                    {
                                        next = true;
                                    }
                                    break;
                                case ParamPauseTreatment.SilenceNote:
                                    // Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                                    // ничего не треуется
                                    next = true;
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
                else
                {
                    // если у очередной ноты нет лиги
                    switch (paramPauseTreatment)
                    {
                        case ParamPauseTreatment.Ignore:
                            // удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)
                            // если у очередной ноты нет лиги, то проверяем: если нота - не пауза, то выставляем флаг о следущей рассматриваемой ноте
                            if (fmotivBuffer.NoteList[fmotivBuffer.NoteList.Count - 1].Pitch.Count > 0)
                            {
                                next = true;
                            }
                            break;
                        case ParamPauseTreatment.NoteTrace:
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
                            break;
                        case ParamPauseTreatment.SilenceNote:
                            // Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                            // ничего не треуется
                            next = true;
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

                    if (ExtractNoteList(fmotivBuffer).Count == 1)
                    {
                        n = fmotivBuffer.NoteList.Count;
                        // сохранили сколько нот/пауз входит в первую рассматриваемую ноту
                    }

                    if (ExtractNoteList(fmotivBuffer).Count == 2)
                    {
                        // если длительность первой собранной ноты больше длительности второй собранной ноты
                        if (TempExtractor(fmotivBuffer, 0).Duration.Value > TempExtractor(fmotivBuffer, 1).Duration.Value)
                        {
                            // заносим ноты/паузы первой собранной ноты в очередной фмотив с типом ЧМТ, и удаляем из буфера
                            var fm = new Fmotiv("ЧМТ", (chain.FmotivList.Count));
                            for (int i = 0; i < n; i++)
                            {
                                //заносим
                                fm.NoteList.Add(((ValueNote) fmotivBuffer.NoteList[0].Clone()));
                                //удаляем
                                fmotivBuffer.NoteList.RemoveAt(0);
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            chain.FmotivList.Add(((Fmotiv) fm.Clone()));

                            //сохранили n на случай если за этим фмотивом следует еще один ЧМТ
                            n = fmotivBuffer.NoteList.Count;
                            // сохранили сколько нот/пауз входит в первую рассматриваемую ноту
                        }
                        else
                        {
                            if (AnotherTempComparator(fmotivBuffer))
                            {
                                // выставляем флаг для сбора последовательности равнодлительных звуков
                                sameDurationChain = true;
                                n = fmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер
                            }
                            else
                            {
                                if (SecondAnotherTempComparator(fmotivBuffer))
                                {
                                    // выставляем флаг для сбора возрастающей последовательности
                                    growingDurationChain = true;
                                    n = fmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер
                                }
                            }
                        }
                    }

                    if (ExtractNoteList(fmotivBuffer).Count > 2)
                    {
                        if (sameDurationChain)
                        {
                            // если длительность предпоследнего меньше длительности последнего
                            if (TempExtractor(fmotivBuffer, ExtractNoteList(fmotivBuffer).Count - 2).Duration.Value <
                                TempExtractor(fmotivBuffer, ExtractNoteList(fmotivBuffer).Count - 1).Duration.Value)
                            {
                                var fmotivBuffer2 = new Fmotiv(String.Empty);
                                // помещаем в буффер2 последнюю собранную ноту - большей длительности чем все равнодлительные
                                int count = fmotivBuffer.NoteList.Count; // так как меняется в процессе
                                for (int i = n; i < count; i++)
                                {
                                    fmotivBuffer2.NoteList.Add(((ValueNote) fmotivBuffer.NoteList[n].Clone()));
                                    fmotivBuffer.NoteList.RemoveAt(n);
                                }

                                // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                                // заисключением последнего фмотива - он останется в буфере вместе с нотой длительность которой больше последней ноты этого фмотива
                                List<Fmotiv> dividedSameDuration = DivideSameDurationNotes(fmotivBuffer);
                                for (int i = 0; i < (dividedSameDuration.Count - 1); i++)
                                {
                                    // заносим очередной фмотив
                                    chain.FmotivList.Add(((Fmotiv) dividedSameDuration[i].Clone()));
                                    // присваиваем очередной id
                                    chain.FmotivList[chain.FmotivList.Count - 1].Id = (chain.FmotivList.Count - 1);
                                }

                                // в буфер заносим последний фмотив цепочки фмотивов нот с равнодлительностью
                                fmotivBuffer = (Fmotiv) dividedSameDuration[dividedSameDuration.Count - 1].Clone();
                                // добавляем сохраненную ноту с большой длительностью
                                for (int i = 0; i < fmotivBuffer2.NoteList.Count; i++)
                                {
                                    fmotivBuffer.NoteList.Add(((ValueNote) fmotivBuffer2.NoteList[i].Clone()));
                                }

                                combination = true; // флаг комбинации
                                growingDurationChain = true;
                                // флаг возрастающей последовательности, чтобы завершить фмотив - комбинация
                                sameDurationChain = false; // убираем флаг для сбора равнодлительных нот

                                n = fmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в текущий буфер

                            }
                            // если длительность предпоследнего равна длительности последнего
                            if (TempExtractor(fmotivBuffer, ExtractNoteList(fmotivBuffer).Count - 2).Duration.Equals(TempExtractor(fmotivBuffer, ExtractNoteList(fmotivBuffer).Count - 1).Duration))
                            {
                                //записываем очередную ноты в фмотив с типом последовательность равнодлительных звуков (она уже записана, поэтому просто сохраняем число входящих в фмотив на данный момент нот/пауз)
                                n = fmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер
                            }
                            // если длительность предпоследнего больше длительности последнего
                            if (FifthTempComparator(fmotivBuffer))
                            {
                                var fmotivBuffer2 = new Fmotiv(String.Empty);
                                // помещаем в буффер2 последнюю собранную ноту - меньшей длительности чем все равнодлительные
                                int count = fmotivBuffer.NoteList.Count; // так как меняется в процессе
                                for (int i = n; i < count; i++)
                                {
                                    fmotivBuffer2.NoteList.Add(((ValueNote) fmotivBuffer.NoteList[n].Clone()));
                                    fmotivBuffer.NoteList.RemoveAt(n);
                                }
                                // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                                foreach (Fmotiv fmotiv in DivideSameDurationNotes(fmotivBuffer))
                                {
                                    // заносим очередной фмотив
                                    chain.FmotivList.Add(((Fmotiv) fmotiv.Clone()));
                                    // присваиваем очередной id
                                    chain.FmotivList[chain.FmotivList.Count - 1].Id = (chain.FmotivList.Count - 1);
                                }

                                // очищаем буффер
                                fmotivBuffer.NoteList.Clear();

                                // добавляем состав сохраненной ноты (паузы/лиги) с меньшей длительностью в буфер
                                for (int i = 0; i < fmotivBuffer2.NoteList.Count; i++)
                                {
                                    fmotivBuffer.NoteList.Add(((ValueNote) fmotivBuffer2.NoteList[i].Clone()));
                                }

                                sameDurationChain = false; // убираем флаг для сбора равнодлительных нот
                                n = fmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в текущий буфер
                            }

                        }
                        else
                        {
                            if (growingDurationChain)
                            {
                                // если длительность предпоследнего меньше длительности последнего
                                if (ForthTempComparator(fmotivBuffer))
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
                                        var fm = new Fmotiv(fmotivBuffer.Type + "ВП", (chain.FmotivList.Count));
                                        // ЧМТВП или ПМТВП
                                        for (int i = 0; i < n; i++)
                                        {
                                            //заносим
                                            fm.NoteList.Add(((ValueNote) fmotivBuffer.NoteList[0].Clone()));
                                            //удаляем
                                            fmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        // добавляем в выходную цепочку получившийся фмотив
                                        chain.FmotivList.Add(((Fmotiv) fm.Clone()));

                                        n = fmotivBuffer.NoteList.Count;
                                        // сохранили сколько нот/пауз осталось в буфере от последней не вошедшей в фмотив ноты
                                        growingDurationChain = false;
                                        // убрали флаг сбора возрастающей последовательности
                                        combination = false; // убрали флаг сбора возрастающей последовательности

                                    }
                                    else
                                    {
                                        var fm = new Fmotiv("ВП", (chain.FmotivList.Count));
                                        for (int i = 0; i < n; i++)
                                        {
                                            //заносим
                                            fm.NoteList.Add(((ValueNote) fmotivBuffer.NoteList[0].Clone()));
                                            //удаляем
                                            fmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        // добавляем в выходную цепочку получившийся фмотив
                                        chain.FmotivList.Add(((Fmotiv) fm.Clone()));

                                        n = fmotivBuffer.NoteList.Count;
                                        // сохранили сколько нот/пауз осталось в буфере от последней не вошедшей в фмотив ноты
                                        growingDurationChain = false;
                                        // убрали флаг сбора возрастающей последовательности
                                    }
                                }

                            }
                        }
                    }
                }
            }

            // если в буфере осталась 1 непроанализированная нота
            if (ExtractNoteList(fmotivBuffer).Count == 1)
            {
                // заносим ноты/паузы 1 собранной ноты в очередной фмотив с типом ЧМТ, и удаляем из буфера
                var fm = new Fmotiv("ЧМТ", (chain.FmotivList.Count));
                //for (int i = 0; i < FmotivBuffer.NoteList.Count; i++)
                foreach (ValueNote note in fmotivBuffer.NoteList)
                {
                    //заносим
                    fm.NoteList.Add(((ValueNote) note.Clone()));
                }
                // добавляем в выходную цепочку получившийся фмотив
                chain.FmotivList.Add(((Fmotiv) fm.Clone()));

                //очищаем буффер
                fmotivBuffer.NoteList.Clear();
            }

            // если в буфере остались непроанализированные ноты (больше 1)
            if (ExtractNoteList(fmotivBuffer).Count > 1)
            {
                if (sameDurationChain)
                {
                    // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                    foreach (Fmotiv fmotiv in DivideSameDurationNotes(fmotivBuffer))
                    {
                        // заносим очередной фмотив
                        chain.FmotivList.Add(((Fmotiv) fmotiv.Clone()));
                        // присваиваем очередной id
                        chain.FmotivList[chain.FmotivList.Count - 1].Id = (chain.FmotivList.Count - 1);
                    }
                    // очищаем буффер
                    fmotivBuffer.NoteList.Clear();
                }
                else
                {
                    if (growingDurationChain)
                    {
                        if (combination)
                        {
                            //заносим оставшиеся ноты в комбинированный фмотив ЧМТ/ПМТ + ВП и в выходную цепочку
                            var fm = new Fmotiv(fmotivBuffer.Type + "ВП", (chain.FmotivList.Count)); // ЧМТВП или ПМТВП
                            foreach (ValueNote note in fmotivBuffer.NoteList)
                            {
                                //заносим
                                fm.NoteList.Add(((ValueNote) note.Clone()));
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            chain.FmotivList.Add(((Fmotiv) fm.Clone()));

                            // очищаем буффер
                            fmotivBuffer.NoteList.Clear();
                        }
                        else
                        {
                            // заносим оставшиеся ноты в фмотив ВП и в выходную цепочку
                            var fm = new Fmotiv("ВП", (chain.FmotivList.Count));
                            foreach (ValueNote note in fmotivBuffer.NoteList)
                            {
                                //заносим
                                fm.NoteList.Add(((ValueNote) note.Clone()));
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            chain.FmotivList.Add(((Fmotiv) fm.Clone()));
                            // очищаем буффер
                            fmotivBuffer.NoteList.Clear();
                        }
                    }
                }
            }

            return chain;
        }

        private List<Fmotiv> DivideSameDurationNotes(Fmotiv fmotivBuff)
        {
            var fmotivBuffer = (Fmotiv) fmotivBuff.Clone(); // создаем копию входного объекта
            var flTemp = new List<Fmotiv>(); // выходной список фмотивов

            // проверка на случай когда в аругменте метода количество собранных нот (из пауз/лиг) меньше двух
            if (ExtractNoteList(fmotivBuffer).Count < 2)
            {
                throw new Exception("LibiadaMusic DivideSameDurationNotes: notes < 2");
            }

            if (ExtractNoteList(fmotivBuffer).Count % 2 == 0)
            {
                // то начинаем анализ из расчета : по две ноты в фмотиве
                // сохраняем количество раз, так как потом меняется
                int count = ExtractNoteList(fmotivBuffer).Count / 2;
                for (int i = 0; i < count; i++)
                {
                    if (ThirdTempComparator(fmotivBuffer))
                    {
                        // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                        // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив

                        // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимостиот того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        flTemp.Add(ThirdTempMethod(fmotivBuffer, "ПМТ", 2));
                    }
                    else
                    {
                        // приоритет первой ноты ниже приоритета второй ноты (метрически слабее)
                        // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                        // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                        // потому что количество равндлительных звуков поменялось, и алгоритм анализа может поменяться

                        // собираем в цикле, пока не кончатся ноты в буфере 1 полноценную ноту в зависимостиот того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        flTemp.Add(ThirdTempMethod(fmotivBuffer, "ЧМТ", 1));
                        // если осталась одна нота то заносим ее в фмотив ЧМТ
                        SecondTempMethod(fmotivBuffer, flTemp);

                        return flTemp;
                    }
                }
                // прошли все ПМТ без ЧМТ, то вернуть результат
                return flTemp;

            }

            if (ExtractNoteList(fmotivBuffer).Count % 3 == 0)
            {
                // то начинаем анализ из расчета : по три ноты в фмотиве
                // сохраняем количество раз, так как потом меняется
                int count = ExtractNoteList(fmotivBuffer).Count / 3;
                for (int i = 0; i < count; i++)
                {
                    if (ThirdTempComparator(fmotivBuffer))
                    {
                        // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                        if (SecondTempComparator(fmotivBuffer))
                        {
                            // приоритет первой ноты выше приоритета третьей ноты (собранные ноты)
                            // ПМТ и записываем все что входит в цепочку нот - в эти три собранные ноты, в очередной фмотив

                            // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                            //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                            flTemp.Add(ThirdTempMethod(fmotivBuffer, "ПМТ", 3));
                        }
                        else
                        {
                            // приоритет первой ноты ниже или равен приоритету третьей ноты (собранные ноты)
                            // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                            // (ЧМТ - если есть знак триоли хотя бы у одной ноты)

                            string typeF = "ПМТ"; // тип ПМТ если не триоль
                            if (TempComparator(fmotivBuffer))
                            {
                                typeF = "ЧМТ"; // если есть хотя б один знак триоли 
                            }

                            // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимости от того, чем мы считаем паузу 
                            //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                            flTemp.Add(ThirdTempMethod(fmotivBuffer, typeF, 2));
                            // если осталась одна нота то заносим ее в фмотив ЧМТ
                            SecondTempMethod(fmotivBuffer, flTemp);
                            return flTemp;
                        }

                    }
                    else
                    {

                        // приоритет первой ноты ниже или равен приоритету второй ноты (метрически слабее или равен)
                        // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                        // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                        // потому что количество равнодлительных звуков поменялось, и алгоритм анализа может поменяться

                        // собираем в цикле, пока не кончатся ноты в буфере 1 полноценная нота в зависимости от того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        flTemp.Add(ThirdTempMethod(fmotivBuffer, "ЧМТ", 1));
                        // если осталась одна нота то заносим ее в фмотив ЧМТ
                        SecondTempMethod(fmotivBuffer, flTemp);
                        return flTemp;
                    }
                }

                // прошли все ПМТ без ЧМТ, то вернуть результат
                return flTemp;
            }
            
            else
            {
                // то начинаем анализ из расчета : по две ноты в фмотиве (к-3)/2 раза, а в последнем 3 ноты
                // сохраняем количество раз, так как потом меняется
                int count = (ExtractNoteList(fmotivBuffer).Count - 3) / 2;
                for (int i = 0; i < count; i++)
                {
                    if (ThirdTempComparator(fmotivBuffer))
                    {
                        // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                        // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив

                        // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимости от того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        flTemp.Add(ThirdTempMethod(fmotivBuffer, "ПМТ", 2));
                    }
                    else
                    {
                        // приоритет первой ноты ниже приоритета второй ноты (метрически слабее)
                        // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                        // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                        // потому что количество равндлительных звуков поменялось, и алгоритм анализа может поменяться

                        // собираем в цикле, пока не кончатся ноты в буфере 1 полноценную ноту в зависимости от того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        flTemp.Add(ThirdTempMethod(fmotivBuffer, "ЧМТ", 1));
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
                if (ThirdTempComparator(fmotivBuffer))
                {
                    // приоритет первой ноты выше приоритета второй ноты (собранные ноты) !!!!!!!!!!!!!!!!!!! сравнение на саомо деле происход первой и третьей, разве нет? 08.04.2012
                    if (SecondTempComparator(fmotivBuffer))
                    {
                        // приоритет первой ноты выше приоритета третьей ноты (собранные ноты)
                        // ПМТ и записываем все что входит в цепочку нот - в эти три собранные ноты, в очередной фмотив

                        // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        flTemp.Add(ThirdTempMethod(fmotivBuffer, "ПМТ", 3));
                    }
                    else
                    {
                        // приоритет первой ноты ниже или равен приоритету третьей ноты (собранные ноты)
                        // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                        // (ЧМТ - если есть знак триоли хотя бы у одной ноты)

                        string typeF = "ПМТ"; // тип ПМТ если не триоль
                        if (TempComparator(fmotivBuffer))
                        {
                            typeF = "ЧМТ"; // если есть хотя б один знак триоли 
                        }

                        // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        flTemp.Add(ThirdTempMethod(fmotivBuffer, typeF, 2));
                        // если осталась одна нота то заносим ее в фмотив ЧМТ
                        SecondTempMethod(fmotivBuffer, flTemp);
                        return flTemp;
                    }

                }
                else
                {
                    // приоритет первой ноты ниже или равен приоритету второй ноты (метрически слабее или равен)
                    // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                    // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                    // потому что количество равнодлительных звуков поменялось, и алгоритм анализа может поменяться

                    // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                    //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                    flTemp.Add(ThirdTempMethod(fmotivBuffer, "ЧМТ", 1));

                    // если осталась одна нота то заносим ее в фмотив ЧМТ
                    SecondTempMethod(fmotivBuffer, flTemp);
                    return flTemp;
                }

                // если все собрали, то возвращаем выходную цепочку
                return flTemp;
            }
        }

        private bool SecondAnotherTempComparator(Fmotiv fmotivBuffer)
        {
            return TempExtractor(fmotivBuffer, 0).Duration.Value < TempExtractor(fmotivBuffer, 1).Duration.Value;
        }

        private ValueNote TempExtractor(Fmotiv fmotivBuffer, int index)
        {
            return ExtractNoteList(fmotivBuffer)[index];
        }

        private List<ValueNote> ExtractNoteList(Fmotiv fmotivBuffer)
        {
            return fmotivBuffer.PauseTreatment(paramPauseTreatment).TieGathered().NoteList;
        }

        private bool AnotherTempComparator(Fmotiv fmotivBuffer)
        {
            return TempExtractor(fmotivBuffer, 0).Duration.Equals(TempExtractor(fmotivBuffer, 1).Duration);
        }

        private bool FifthTempComparator(Fmotiv fmotivBuffer)
        {
            return TempExtractor(fmotivBuffer, ExtractNoteList(fmotivBuffer).Count - 2).Duration.Value >
                TempExtractor(fmotivBuffer, ExtractNoteList(fmotivBuffer).Count - 1).Duration.Value;
        }

        private bool ForthTempComparator(Fmotiv fmotivBuffer)
        {
            return TempExtractor(fmotivBuffer, ExtractNoteList(fmotivBuffer).Count - 2).Duration.Value <
                TempExtractor(fmotivBuffer, ExtractNoteList(fmotivBuffer).Count - 1).Duration.Value;
        }

        private bool ThirdTempComparator(Fmotiv fmotivBuffer)
        {
            return TempExtractor(fmotivBuffer, 0).Priority < TempExtractor(fmotivBuffer, 1).Priority;
        }

        private bool SecondTempComparator(Fmotiv fmotivBuffer)
        {
            return TempExtractor(fmotivBuffer, 0).Priority < TempExtractor(fmotivBuffer, 2).Priority;
        }

        private bool TempComparator(Fmotiv fmotivBuffer)
        {
            return TempExtractor(fmotivBuffer, 0).Triplet || TempExtractor(fmotivBuffer, 1).Triplet;
        }

        private Fmotiv ThirdTempMethod(Fmotiv fmotivBuffer, String fmotivType, int noteCount)
        {
            var fmotiv = new Fmotiv(fmotivType);
            while (fmotivBuffer.NoteList.Count > 0)
            {
                if (ExtractNoteList(fmotiv).Count == noteCount)
                {
                    if (paramPauseTreatment != ParamPauseTreatment.NoteTrace)
                    {
                        break;
                    }

                    if ((paramPauseTreatment == ParamPauseTreatment.NoteTrace) &&
                        (fmotivBuffer.NoteList[0].Pitch.Count > 0))
                    {
                        break;
                    }
                }
                fmotiv.NoteList.Add(((ValueNote) fmotivBuffer.NoteList[0].Clone()));
                fmotivBuffer.NoteList.RemoveAt(0);

                TempMethod(fmotiv, fmotivBuffer);
            }

            return (Fmotiv) fmotiv.Clone();
        }

        private void SecondTempMethod(Fmotiv fmotivBuffer, List<Fmotiv> flTemp)
        {
            if (ExtractNoteList(fmotivBuffer).Count == 1)
            {
                var fm = new Fmotiv("ЧМТ");
                for (int j = 0; j < fmotivBuffer.NoteList.Count; j++)
                {
                    //заносим
                    fm.NoteList.Add(((ValueNote) fmotivBuffer.NoteList[j].Clone()));
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
        }

        private static void TempMethod(Fmotiv fmotiv, Fmotiv fmotivBuffer)
        {
            if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != Tie.None)
            {
                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == Tie.Start)
                {
                    // TODO: желательно сделать проверку когда собирается очередная лига,
                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                    while (fmotivBuffer.NoteList[0].Tie == Tie.StartStop)
                    {
                        // пока продолжается лига, заносим ноты в буфер
                        fmotiv.NoteList.Add(((ValueNote) fmotivBuffer.NoteList[0].Clone()));
                        fmotivBuffer.NoteList.RemoveAt(0);
                    }
                    if (fmotivBuffer.NoteList[0].Tie == Tie.Stop)
                    {
                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                        fmotiv.NoteList.Add(((ValueNote) fmotivBuffer.NoteList[0].Clone()));
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
        }
    }
}