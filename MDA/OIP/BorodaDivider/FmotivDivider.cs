using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using MDA.OIP.ScoreModel;

namespace MDA.OIP.BorodaDivider
{
    public class FmotivDivider
    {
        /// <summary>
        /// параметр сохраняется для всего экземпляра класса и потом используется
        /// </summary>
        private PauseTreatment paramPause;

        public FmotivChain GetDivision(UniformScoreTrack unitrack, PauseTreatment paramPauseTreat)
        {
            List<IBaseObject> temp = new List<IBaseObject>(); // выходная, результирующая цепочка разбитых ф-мотивов
            paramPause = paramPauseTreat;

            Fmotiv FmotivBuffer = new Fmotiv(""); // буффер для накопления нот, для последующего анализа его содержимого

            #region заполнение цепи нот, со всех тактов монотрека

            List<ValueNote> NoteChain = new List<ValueNote>();
                // цепочка нот, куда поочередно складываются ноты из последовательности тактов
            // для дальнейшего их анализа и распределения по ф-мотивам.

            // заполняем NoteChain всеми нотам из данной монофонической цепи unitrack
            foreach (Measure measure in unitrack.Measurelist)
            {
                foreach (ValueNote note in measure.NoteList)
                {
                    NoteChain.Add(((ValueNote) note.Clone()));
                }
            }

            #endregion

            int n = 0; // счетчик реальных нот/пауз для первой группировки в реальную нот

            bool WasNote = false;
                // флаг который говорит, что была нота перемещена в буфер после последнего флага Next, для pause notetrace
            bool Next = false; // флаг, говорит что собралась очередная нота для рассмотрения
            bool SameDurationChain = false;
                // флаг, говорящий что собирается последовательность равнодлительных звуков (1,2 тип фмотива - ПМТ,ЧМТ)
            bool GrowingDurationChain = false;
                // флаг, говорящий что собирается возрастающая последовательность (3 тип фмотива)
            bool Combination = false;
            // флаг, говорящий что собирается комбинация - ПМТ/ЧМТ и возрастающая последовательность (4 тип фмотива)
            // пока анализируемая цепь содержит элементы, идет выполнение анализа ее содержимого
            while (0 < NoteChain.Count)
            {
                FmotivBuffer.NoteList.Add(((ValueNote) NoteChain[0].Clone()));
                NoteChain.RemoveAt(0);

                #region Сборка последующих нот, в случае Лиги

                // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                if (FmotivBuffer.NoteList[FmotivBuffer.NoteList.Count - 1].Tie != -1)
                {
                    // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                    if (FmotivBuffer.NoteList[FmotivBuffer.NoteList.Count - 1].Tie == 0)
                    {
                        // TODO: желательно сделать проверку когда собирается очередная лига,
                        // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                        while (NoteChain[0].Tie == 2)
                        {
                            // пока продолжается лига, заносим ноты в буфер
                            FmotivBuffer.NoteList.Add(((ValueNote) NoteChain[0].Clone()));
                            NoteChain.RemoveAt(0);
                        }
                        if (NoteChain[0].Tie == 1)
                        {
                            // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                            FmotivBuffer.NoteList.Add(((ValueNote) NoteChain[0].Clone()));
                            NoteChain.RemoveAt(0);


                            WasNote = true; // была нота пермещена в буфер

                            switch (paramPause)
                            {
                                case PauseTreatment.Ignore:
                                    {
                                        // удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)

                                        // если у очередной ноты нет лиги, то проверяем: если нота - не пауза, то выставляем флаг о следущей рассматриваемой ноте
                                        if (FmotivBuffer.NoteList[FmotivBuffer.NoteList.Count - 1].Pitch != null)
                                        {
                                            Next = true;
                                        }
                                    }
                                    break;
                                case PauseTreatment.NoteTrace:
                                    {
                                        // длительность паузы прибавляется к предыдущей ноте, а она сама удаляется из текста (1) (пауза - звуковой след ноты)

                                        if (NoteChain.Count > 0)
                                        {
                                            //если следующая не паузы то переходим к анализу буфера
                                            if ((NoteChain[0].Pitch != null) && (WasNote))
                                            {
                                                Next = true;
                                            }
                                        }
                                        else
                                        {
                                            if (WasNote)
                                            {
                                                Next = true;
                                            }
                                        }
                                    }
                                    break;
                                case PauseTreatment.SilenceNote:
                                    {
                                        // Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                                        // ничего не треуется
                                        Next = true;
                                    }
                                    break;

                                default:
                                    throw new Exception("Error Fmotiv.PauseTreatment parameter contains wrong value!");
                            }
                        }
                        else
                        {
                            // когда лига не заканчивается флагом конца, то ошибка
                            throw new Exception("MDA: FmotivDivider, wrong Tie organization!End!");
                        }

                    }
                    else
                    {
                        // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                        throw new Exception("MDA: FmotivDivider, wrong Tie organization!Begining!");
                    }
                }
                    #endregion

                else
                {
                    // если у очередной ноты нет лиги
                    switch (paramPause)
                    {
                        case PauseTreatment.Ignore:
                            {
                                // удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)
                                // если у очередной ноты нет лиги, то проверяем: если нота - не пауза, то выставляем флаг о следущей рассматриваемой ноте
                                if (FmotivBuffer.NoteList[FmotivBuffer.NoteList.Count - 1].Pitch != null)
                                {
                                    Next = true;
                                }
                            }
                            break;
                        case PauseTreatment.NoteTrace:
                            {
                                // длительность паузы прибавляется к предыдущей ноте, а она сама удаляется из текста (1) (пауза - звуковой след ноты)
                                //проверяем: если нота - не пауза, то выставляем флаг о следущей рассматриваемой ноте
                                if (FmotivBuffer.NoteList[FmotivBuffer.NoteList.Count - 1].Pitch != null)
                                {
                                    WasNote = true;
                                }

                                if (NoteChain.Count > 0)
                                {
                                    //если следующая в н. тексте не пауза то переходим к анализу буфера
                                    if ((NoteChain[0].Pitch != null) && (WasNote))
                                    {
                                        Next = true;
                                    }
                                }
                                else
                                {
                                    if (WasNote)
                                    {
                                        Next = true;
                                    }
                                }
                            }
                            break;
                        case PauseTreatment.SilenceNote:
                            {
                                // Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                                // ничего не треуется
                                Next = true;
                            }
                            break;

                        default:
                            throw new Exception("Error Fmotiv.PauseTreatment parameter contains wrong value!");
                    }
                }

                // если готова (собрана) следущая нота для анализа
                if (Next)
                {
                    // убираем флаг следущей готовой (собранной ноты), так как после анализа не известно что там будет
                    Next = false;
                    WasNote = false;

                    #region если в буфере 1 собранная нота

                    if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count == 1)
                    {
                        n = FmotivBuffer.NoteList.Count;
                            // сохранили сколько нот/пауз входит в первую рассматриваемую ноту
                    }

                    #endregion

                    #region если в буфере 2 собранные ноты

                    if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count == 2)
                    {
                        // если длительность первой собранной ноты больше длительности второй собранной ноты
                        if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[0].Duration.Value >
                            FmotivBuffer.Clone(paramPause).TieGathered().NoteList[1].Duration.Value)
                        {
                            // заносим ноты/паузы первой собранной ноты в очередной фмотив с типом ЧМТ, и удаляем из буфера
                            Fmotiv fm = new Fmotiv("ЧМТ");
                            for (int i = 0; i < n; i++)
                            {
                                //заносим
                                fm.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                //удаляем
                                FmotivBuffer.NoteList.RemoveAt(0);
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            temp.Add(fm);

                            //сохранили n на случай если за этим фмотивом следует еще один ЧМТ
                            n = FmotivBuffer.NoteList.Count;
                                // сохранили сколько нот/пауз входит в первую рассматриваемую ноту
                        }
                        else
                        {
                            if (
                                FmotivBuffer.Clone(paramPause).TieGathered().NoteList[0].Duration.Equals(
                                    FmotivBuffer.Clone(paramPause).TieGathered().NoteList[1].Duration))
                            {
                                // выставляем флаг для сбора последовательности равнодлительных звуков
                                SameDurationChain = true;
                                n = FmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер

                            }
                            else
                            {
                                if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[0].Duration.Value <
                                    FmotivBuffer.Clone(paramPause).TieGathered().NoteList[1].Duration.Value)
                                {
                                    // выставляем флаг для сбора возрастающей последовательности
                                    GrowingDurationChain = true;
                                    n = FmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер
                                }
                            }
                        }
                    }

                    #endregion

                    #region если в буфере больше 2-х собранных нот

                    if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count > 2)
                    {
                        #region сбор равнодлительных нот?

                        if (SameDurationChain)
                        {
                            // если длительность предпоследнего меньше длительности последнего
                            if (
                                FmotivBuffer.Clone(paramPause).TieGathered().NoteList[
                                    FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count - 2].Duration.
                                    Value <
                                FmotivBuffer.Clone(paramPause).TieGathered().NoteList[
                                    FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count - 1].Duration.
                                    Value)
                            {
                                Fmotiv Fmotivbuffer2 = new Fmotiv("");
                                // помещаем в буффер2 последнюю собранную ноту - большей длительности чем все равнодлительные
                                int count = FmotivBuffer.NoteList.Count; // так как меняется в процессе
                                for (int i = n; i < count; i++)
                                {
                                    Fmotivbuffer2.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[n].Clone()));
                                    FmotivBuffer.NoteList.RemoveAt(n);
                                }

                                // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                                // заисключением последнего фмотива - он останется в буфере вместе с нотой длительность которой больше последней ноты этого фмотива
                                List<Fmotiv> dividedSameDuration = DivideSameDurationNotes(FmotivBuffer);
                                for (int i = 0; i < (dividedSameDuration.Count - 1); i++)
                                {
                                    // заносим очередной фмотив
                                    temp.Add(dividedSameDuration[i]);
                                    //Not needed anymore
                                    // присваиваем очередной id
                                    //Temp.Building[Temp.Length - 1] = (Temp.Length);
                                }

                                // в буфер заносим последний фмотив цепочки фмотивов нот с равнодлительностью
                                FmotivBuffer = (Fmotiv) dividedSameDuration[dividedSameDuration.Count - 1].Clone();
                                // добавляем сохраненную ноту с большой длительностью
                                for (int i = 0; i < Fmotivbuffer2.NoteList.Count; i++)
                                {
                                    FmotivBuffer.NoteList.Add(((ValueNote) Fmotivbuffer2.NoteList[i].Clone()));
                                }

                                Combination = true; // флаг комбинации
                                GrowingDurationChain = true;
                                    // флаг возрастающей последовательности, чтобы завершить фмотив - комбинация
                                SameDurationChain = false; // убираем флаг для сбора равнодлительных нот

                                n = FmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в текущий буфер

                            }
                            // если длительность предпоследнего равна длительности последнего
                            if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[
                                FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count - 2].Duration.
                                Equals
                                (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[
                                    FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count - 1].Duration))
                            {
                                //записываем очередную ноты в фмотив с типом последовательность равнодлительных звуков (она уже записана, поэтому просто сохраняем число входящих в фмотив на данный момент нот/пауз)
                                n = FmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер
                            }
                            // если длительность предпоследнего больше длительности последнего
                            if (
                                FmotivBuffer.Clone(paramPause).TieGathered().NoteList[
                                    FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count - 2].Duration.
                                    Value >
                                FmotivBuffer.Clone(paramPause).TieGathered().NoteList[
                                    FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count - 1].Duration.
                                    Value)
                            {
                                Fmotiv Fmotivbuffer2 = new Fmotiv("");
                                // помещаем в буффер2 последнюю собранную ноту - меньшей длительности чем все равнодлительные
                                int count = FmotivBuffer.NoteList.Count; // так как меняется в процессе
                                for (int i = n; i < count; i++)
                                {
                                    Fmotivbuffer2.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[n].Clone()));
                                    FmotivBuffer.NoteList.RemoveAt(n);
                                }
                                // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                                foreach (Fmotiv fmotiv in DivideSameDurationNotes(FmotivBuffer))
                                {
                                    // заносим очередной фмотив
                                    temp.Add(fmotiv);
                                    //Not nedded anymore
                                    // присваиваем очередной id
                                    //Temp.FmotivList[Temp.FmotivList.Count - 1].Id = (Temp.FmotivList.Count - 1);
                                }

                                // очищаем буффер
                                FmotivBuffer.NoteList.Clear();

                                // добавляем состав сохраненной ноты (паузы/лиги) с меньшей длительностью в буфер
                                for (int i = 0; i < Fmotivbuffer2.NoteList.Count; i++)
                                {
                                    FmotivBuffer.NoteList.Add(((ValueNote) Fmotivbuffer2.NoteList[i].Clone()));
                                }

                                SameDurationChain = false; // убираем флаг для сбора равнодлительных нот
                                n = FmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в текущий буфер
                            }

                        }
                            #endregion

                            #region сбор возрастающей последовательности?

                        else
                        {
                            if (GrowingDurationChain)
                            {
                                // если длительность предпоследнего меньше длительности последнего
                                if (
                                    FmotivBuffer.Clone(paramPause).TieGathered().NoteList[
                                        FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count - 2].
                                        Duration.Value <
                                    FmotivBuffer.Clone(paramPause).TieGathered().NoteList[
                                        FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count - 1].
                                        Duration.Value)
                                {
                                    //записываем очередную ноты в фмотив с типом возрастающая последовательность (она уже записана, поэтому просто сохраняем число входящих в фмотив на данный момент нот)
                                    n = FmotivBuffer.NoteList.Count; // сохранили сколько нот/пауз входит в буфер
                                }
                                else
                                {
                                    // иначе если длительности равны, или последняя по длительности меньше предпоследней, то составляем новый фмотив
                                    //также сохраняем не вошедшую последнюю ноту (не удаляем ее)
                                    if (Combination)
                                    {
                                        Fmotiv fm = new Fmotiv(FmotivBuffer.Type + "ВП");
                                            // ЧМТВП или ПМТВП
                                        for (int i = 0; i < n; i++)
                                        {
                                            //заносим
                                            fm.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            //удаляем
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        // добавляем в выходную цепочку получившийся фмотив
                                        temp.Add(fm);

                                        n = FmotivBuffer.NoteList.Count;
                                            // сохранили сколько нот/пауз осталось в буфере от последней не вошедшей в фмотив ноты
                                        GrowingDurationChain = false;
                                            // убрали флаг сбора возрастающей последовательности
                                        Combination = false; // убрали флаг сбора возрастающей последовательности

                                    }
                                    else
                                    {
                                        Fmotiv fm = new Fmotiv("ВП");
                                        for (int i = 0; i < n; i++)
                                        {
                                            //заносим
                                            fm.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            //удаляем
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        // добавляем в выходную цепочку получившийся фмотив
                                        temp.Add(fm);

                                        n = FmotivBuffer.NoteList.Count;
                                            // сохранили сколько нот/пауз осталось в буфере от последней не вошедшей в фмотив ноты
                                        GrowingDurationChain = false;
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
            if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count == 1)
            {
                // заносим ноты/паузы 1 собранной ноты в очередной фмотив с типом ЧМТ, и удаляем из буфера
                Fmotiv fm = new Fmotiv("ЧМТ");
                //for (int i = 0; i < FmotivBuffer.NoteList.Count; i++)
                foreach (ValueNote note in FmotivBuffer.NoteList)
                {
                    //заносим
                    fm.NoteList.Add(((ValueNote) note.Clone()));
                }
                // добавляем в выходную цепочку получившийся фмотив
                temp.Add(fm);

                //очищаем буффер
                FmotivBuffer.NoteList.Clear();
            }

            // если в буфере остались непроанализированные ноты (больше 1)
            if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count > 1)
            {
                if (SameDurationChain)
                {
                    // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                    foreach (Fmotiv fmotiv in DivideSameDurationNotes(FmotivBuffer))
                    {
                        // заносим очередной фмотив
                        temp.Add(fmotiv);
                        //Not needed anymore
                        // присваиваем очередной id
                        //Temp.FmotivList[Temp.FmotivList.Count - 1].Id = (Temp.FmotivList.Count - 1);
                    }
                    // очищаем буффер
                    FmotivBuffer.NoteList.Clear();
                    SameDurationChain = false; // убираем флаг для сбора равнодлительных нот
                }
                else
                {
                    if (GrowingDurationChain)
                    {
                        if (Combination)
                        {
                            //заносим оставшиеся ноты в комбинированный фмотив ЧМТ/ПМТ + ВП и в выходную цепочку
                            Fmotiv fm = new Fmotiv(FmotivBuffer.Type + "ВП");
                                // ЧМТВП или ПМТВП
                            foreach (ValueNote note in FmotivBuffer.NoteList)
                            {
                                //заносим
                                fm.NoteList.Add(((ValueNote) note.Clone()));
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            temp.Add(fm);

                            // очищаем буффер
                            FmotivBuffer.NoteList.Clear();
                            GrowingDurationChain = false; // убрали флаг сбора возрастающей последовательности
                            Combination = false; // убрали флаг сбора возрастающей последовательности
                        }
                        else
                        {
                            // заносим оставшиеся ноты в фмотив ВП и в выходную цепочку
                            Fmotiv fm = new Fmotiv("ВП");
                            foreach (ValueNote note in FmotivBuffer.NoteList)
                            {
                                //заносим
                                fm.NoteList.Add(((ValueNote) note.Clone()));
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            temp.Add(fm);
                            // очищаем буффер
                            FmotivBuffer.NoteList.Clear();
                            GrowingDurationChain = false; // убрали флаг сбора возрастающей последовательности
                        }
                    }
                }
            }

            #endregion
            FmotivChain result = new FmotivChain(temp);
            result.Name = unitrack.Name;
            return result;
        }

        public List<Fmotiv> DivideSameDurationNotes(Fmotiv FmotivBuf)
        {
            Fmotiv FmotivBuffer = (Fmotiv) FmotivBuf.Clone(); // создаем копию входного объекта
            List<Fmotiv> FLTemp = new List<Fmotiv>(); // выходной список фмотивов

            // проверка на случай когда в аругменте метода количество собранных нот (из пауз/лиг) меньше двух
            if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count < 2)
            {
                throw new Exception("MDA DivideSameDurationNotes: notes < 2");
            }

            #region если количество собранных нот делится на 2

            if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count%2 == 0)
            {
                // то начинаем анализ из расчета : по две ноты в фмотиве
                // сохраняем количество раз, так как потом меняется
                int count = FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count/2;
                for (int i = 0; i < count; i++)
                {
                    if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[0].Priority <
                        FmotivBuffer.Clone(paramPause).TieGathered().NoteList[1].Priority)
                    {
                        // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                        // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                        Fmotiv fmotiv = new Fmotiv("ПМТ");

                        // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимостиот того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        while (FmotivBuffer.NoteList.Count > 0)
                        {
                            if (fmotiv.Clone(paramPause).TieGathered().NoteList.Count == 2)
                            {
                                // Silence Note OR Ignore Pause
                                if (paramPause != PauseTreatment.NoteTrace)
                                {
                                    break;
                                }
                                // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                if ((paramPause == PauseTreatment.NoteTrace) &&
                                    (FmotivBuffer.NoteList[0].Pitch != null))
                                {
                                    break;
                                }
                            }

                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                            FmotivBuffer.NoteList.RemoveAt(0);

                            #region Сборка последующих нот, в случае Лиги

                            // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                            if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                            {
                                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                {
                                    // TODO: желательно сделать проверку когда собирается очередная лига,
                                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                    while (FmotivBuffer.NoteList[0].Tie == 2)
                                    {
                                        // пока продолжается лига, заносим ноты в буфер
                                        fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                        FmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    if (FmotivBuffer.NoteList[0].Tie == 1)
                                    {
                                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                        fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                        FmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    else
                                    {
                                        // когда лига не заканчивается флагом конца, то ошибка
                                        throw new Exception("MDA: FmotivDivider, wrong Tie organization!End!");
                                    }
                                }
                                else
                                {
                                    // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                    throw new Exception("MDA: FmotivDivider, wrong Tie organization!Begining!");
                                }
                            }

                            #endregion
                        }

                        // и складываем в выходную цепочку
                        FLTemp.Add(((Fmotiv) fmotiv.Clone()));
                    }
                    else
                    {
                        // приоритет первой ноты ниже приоритета второй ноты (метрически слабее)
                        // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                        // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                        // потому что количество равндлительных звуков поменялось, и алгоритм анализа может поменяться
                        Fmotiv fmotiv = new Fmotiv("ЧМТ");

                        // собираем в цикле, пока не кончатся ноты в буфере 1 полноценную ноту в зависимостиот того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        while (FmotivBuffer.NoteList.Count > 0)
                        {
                            if (fmotiv.Clone(paramPause).TieGathered().NoteList.Count == 1)
                            {
                                // Silence Note OR Ignore Pause
                                if (paramPause != PauseTreatment.NoteTrace)
                                {
                                    break;
                                }
                                // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                if ((paramPause == PauseTreatment.NoteTrace) &&
                                    (FmotivBuffer.NoteList[0].Pitch != null))
                                {
                                    break;
                                }
                            }

                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                            FmotivBuffer.NoteList.RemoveAt(0);

                            #region Сборка последующих нот, в случае Лиги

                            // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                            if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                            {
                                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                {
                                    // TODO: желательно сделать проверку когда собирается очередная лига,
                                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                    while (FmotivBuffer.NoteList[0].Tie == 2)
                                    {
                                        // пока продолжается лига, заносим ноты в буфер
                                        fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                        FmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    if (FmotivBuffer.NoteList[0].Tie == 1)
                                    {
                                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                        fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                        FmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    else
                                    {
                                        // когда лига не заканчивается флагом конца, то ошибка
                                        throw new Exception("MDA: FmotivDivider, wrong Tie organization!End!");
                                    }
                                }
                                else
                                {
                                    // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                    throw new Exception("MDA: FmotivDivider, wrong Tie organization!Begining!");
                                }
                            }

                            #endregion
                        }

                        // и складываем в выходную цепочку
                        FLTemp.Add(((Fmotiv) fmotiv.Clone()));

                        // если осталась одна нота то заносим ее в фмотив ЧМТ
                        if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count == 1)
                        {
                            Fmotiv fm = new Fmotiv("ЧМТ");
                            for (int j = 0; j < FmotivBuffer.NoteList.Count; j++)
                            {
                                //заносим
                                fm.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[j].Clone()));
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            FLTemp.Add(((Fmotiv) fm.Clone()));
                            FmotivBuffer.NoteList.Clear();
                        }
                        else
                        {
                            // если больше 1 ноты, то вызываем рекурсию на оставшиеся ноты
                            // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                            List<Fmotiv> DividedSameDuration = DivideSameDurationNotes(FmotivBuffer);
                            for (int j = 0;
                                 j < DividedSameDuration.Count;
                                 j++)
                            {
                                // заносим очередной фмотив
                                FLTemp.Add(((Fmotiv) DividedSameDuration[j].Clone()));
                            }
                        }

                        return FLTemp;
                    }
                }
                // прошли все ПМТ без ЧМТ, то вернуть результат
                return FLTemp;

            }
                #endregion
                #region если количество собранных нот делится на 3

            else
            {
                if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count%3 == 0)
                {
                    // то начинаем анализ из расчета : по три ноты в фмотиве
                    // сохраняем количество раз, так как потом меняется
                    int count = FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count/3;
                    for (int i = 0; i < count; i++)
                    {
                        if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[0].Priority <
                            FmotivBuffer.Clone(paramPause).TieGathered().NoteList[1].Priority)
                        {
                            // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                            if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[0].Priority <
                                FmotivBuffer.Clone(paramPause).TieGathered().NoteList[2].Priority)
                            {
                                // приоритет первой ноты выше приоритета третьей ноты (собранные ноты)
                                // ПМТ и записываем все что входит в цепочку нот - в эти три собранные ноты, в очередной фмотив
                                Fmotiv fmotiv = new Fmotiv("ПМТ");

                                // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                                //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                                while (FmotivBuffer.NoteList.Count > 0)
                                {
                                    if (fmotiv.Clone(paramPause).TieGathered().NoteList.Count == 3)
                                    {
                                        // Silence Note OR Ignore Pause
                                        if (paramPause != PauseTreatment.NoteTrace)
                                        {
                                            break;
                                        }
                                        // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                        if ((paramPause == PauseTreatment.NoteTrace) &&
                                            (FmotivBuffer.NoteList[0].Pitch != null))
                                        {
                                            break;
                                        }
                                    }
                                    fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                    FmotivBuffer.NoteList.RemoveAt(0);

                                    #region Сборка последующих нот, в случае Лиги

                                    // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                                    if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                                    {
                                        // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                        if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                        {
                                            // TODO: желательно сделать проверку когда собирается очередная лига,
                                            // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                            while (FmotivBuffer.NoteList[0].Tie == 2)
                                            {
                                                // пока продолжается лига, заносим ноты в буфер
                                                fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                                FmotivBuffer.NoteList.RemoveAt(0);
                                            }
                                            if (FmotivBuffer.NoteList[0].Tie == 1)
                                            {
                                                // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                                fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                                FmotivBuffer.NoteList.RemoveAt(0);
                                            }
                                            else
                                            {
                                                // когда лига не заканчивается флагом конца, то ошибка
                                                throw new Exception("MDA: FmotivDivider, wrong Tie organization!End!");
                                            }
                                        }
                                        else
                                        {
                                            // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                            throw new Exception("MDA: FmotivDivider, wrong Tie organization!Begining!");
                                        }
                                    }

                                    #endregion
                                }
                                // и складываем в выходную цепочку
                                FLTemp.Add(((Fmotiv) fmotiv.Clone()));
                            }
                            else
                            {
                                // приоритет первой ноты ниже или равен приоритету третьей ноты (собранные ноты)
                                // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                                // (ЧМТ - если есть знак триоли хотя бы у одной ноты)

                                string typeF = "ПМТ"; // тип ПМТ если не триоль
                                if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[0].Triplet ||
                                    FmotivBuffer.Clone(paramPause).TieGathered().NoteList[1].Triplet)
                                {
                                    typeF = "ЧМТ"; // если есть хотя б один знак триоли 
                                }

                                Fmotiv fmotiv = new Fmotiv(typeF);

                                // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимости от того, чем мы считаем паузу 
                                //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                                while (FmotivBuffer.NoteList.Count > 0)
                                {
                                    if (fmotiv.Clone(paramPause).TieGathered().NoteList.Count == 2)
                                    {
                                        // Silence Note OR Ignore Pause
                                        if (paramPause != PauseTreatment.NoteTrace)
                                        {
                                            break;
                                        }
                                        // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                        if ((paramPause == PauseTreatment.NoteTrace) &&
                                            (FmotivBuffer.NoteList[0].Pitch != null))
                                        {
                                            break;
                                        }
                                    }
                                    fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                    FmotivBuffer.NoteList.RemoveAt(0);

                                    #region Сборка последующих нот, в случае Лиги

                                    // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                                    if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                                    {
                                        // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                        if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                        {
                                            // TODO: желательно сделать проверку когда собирается очередная лига,
                                            // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                            while (FmotivBuffer.NoteList[0].Tie == 2)
                                            {
                                                // пока продолжается лига, заносим ноты в буфер
                                                fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                                FmotivBuffer.NoteList.RemoveAt(0);
                                            }
                                            if (FmotivBuffer.NoteList[0].Tie == 1)
                                            {
                                                // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                                fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                                FmotivBuffer.NoteList.RemoveAt(0);
                                            }
                                            else
                                            {
                                                // когда лига не заканчивается флагом конца, то ошибка
                                                throw new Exception("MDA: FmotivDivider, wrong Tie organization!End!");
                                            }
                                        }
                                        else
                                        {
                                            // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                            throw new Exception("MDA: FmotivDivider, wrong Tie organization!Begining!");
                                        }
                                    }

                                    #endregion
                                }
                                // и складываем в выходную цепочку
                                FLTemp.Add(((Fmotiv) fmotiv.Clone()));

                                // если осталась одна нота то заносим ее в фмотив ЧМТ
                                if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count == 1)
                                {
                                    Fmotiv fm = new Fmotiv("ЧМТ");
                                    for (int j = 0; j < FmotivBuffer.NoteList.Count; j++)
                                    {
                                        //заносим
                                        fm.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[j].Clone()));
                                    }
                                    // добавляем в выходную цепочку получившийся фмотив
                                    FLTemp.Add(((Fmotiv) fm.Clone()));
                                    FmotivBuffer.NoteList.Clear();
                                }
                                else
                                {
                                    // если больше 1 ноты, то вызываем рекурсию на оставшиеся ноты
                                    // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                                    List<Fmotiv> DividedSameDuration = DivideSameDurationNotes(FmotivBuffer);
                                    for (int j = 0;
                                         j < DividedSameDuration.Count;
                                         j++)
                                    {
                                        // заносим очередной фмотив
                                        FLTemp.Add(((Fmotiv) DividedSameDuration[j].Clone()));
                                    }
                                }
                                return FLTemp;
                            }

                        }
                        else
                        {
                            // приоритет первой ноты ниже или равен приоритету второй ноты (метрически слабее или равен)
                            // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                            // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                            // потому что количество равнодлительных звуков поменялось, и алгоритм анализа может поменяться
                            Fmotiv fmotiv = new Fmotiv("ЧМТ");

                            // собираем в цикле, пока не кончатся ноты в буфере 1 полноценная нота в зависимости от того, чем мы считаем паузу 
                            //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                            while (FmotivBuffer.NoteList.Count > 0)
                            {
                                if (fmotiv.Clone(paramPause).TieGathered().NoteList.Count == 1)
                                {
                                    // Silence Note OR Ignore Pause
                                    if (paramPause != PauseTreatment.NoteTrace)
                                    {
                                        break;
                                    }
                                    // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                    if ((paramPause == PauseTreatment.NoteTrace) &&
                                        (FmotivBuffer.NoteList[0].Pitch != null))
                                    {
                                        break;
                                    }
                                }
                                fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                FmotivBuffer.NoteList.RemoveAt(0);

                                #region Сборка последующих нот, в случае Лиги

                                // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                                {
                                    // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                    if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                    {
                                        // TODO: желательно сделать проверку когда собирается очередная лига,
                                        // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                        while (FmotivBuffer.NoteList[0].Tie == 2)
                                        {
                                            // пока продолжается лига, заносим ноты в буфер
                                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        if (FmotivBuffer.NoteList[0].Tie == 1)
                                        {
                                            // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        else
                                        {
                                            // когда лига не заканчивается флагом конца, то ошибка
                                            throw new Exception("MDA: FmotivDivider, wrong Tie organization!End!");
                                        }
                                    }
                                    else
                                    {
                                        // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                        throw new Exception("MDA: FmotivDivider, wrong Tie organization!Begining!");
                                    }
                                }

                                #endregion
                            }

                            // и складываем в выходную цепочку
                            FLTemp.Add(((Fmotiv) fmotiv.Clone()));

                            // если осталась одна нота то заносим ее в фмотив ЧМТ
                            if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count == 1)
                            {
                                Fmotiv fm = new Fmotiv("ЧМТ");
                                for (int j = 0; j < FmotivBuffer.NoteList.Count; j++)
                                {
                                    //заносим
                                    fm.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[j].Clone()));
                                }
                                // добавляем в выходную цепочку получившийся фмотив
                                FLTemp.Add(((Fmotiv) fm.Clone()));
                                FmotivBuffer.NoteList.Clear();
                            }
                            else
                            {
                                // если больше 1 ноты, то вызываем рекурсию на оставшиеся ноты
                                // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                                List<Fmotiv> DividedSameDuration = DivideSameDurationNotes(FmotivBuffer);
                                for (int j = 0;
                                     j < DividedSameDuration.Count;
                                     j++)
                                {
                                    // заносим очередной фмотив
                                    FLTemp.Add(((Fmotiv) DividedSameDuration[j].Clone()));
                                }
                            }
                            return FLTemp;
                        }
                    }

                    // прошли все ПМТ без ЧМТ, то вернуть результат
                    return FLTemp;
                }
                    #endregion
                    #region если количество нот не делится на два и на три, оно- простое число (как по бороде)

                else
                {
                    // то начинаем анализ из расчета : по две ноты в фмотиве (к-3)/2 раза, а в последнем 3 ноты
                    // сохраняем количество раз, так как потом меняется
                    int count = (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count - 3)/2;
                    for (int i = 0; i < count; i++)
                    {
                        if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[0].Priority <
                            FmotivBuffer.Clone(paramPause).TieGathered().NoteList[1].Priority)
                        {
                            // приоритет первой ноты выше приоритета второй ноты (собранные ноты)
                            // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                            Fmotiv fmotiv = new Fmotiv("ПМТ");

                            // собираем в цикле, пока не кончатся ноты в буфере 2 полноценные ноты в зависимости от того, чем мы считаем паузу 
                            //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                            while (FmotivBuffer.NoteList.Count > 0)
                            {
                                if (fmotiv.Clone(paramPause).TieGathered().NoteList.Count == 2)
                                {
                                    // Silence Note OR Ignore Pause
                                    if (paramPause != PauseTreatment.NoteTrace)
                                    {
                                        break;
                                    }
                                    // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                    if ((paramPause == PauseTreatment.NoteTrace) &&
                                        (FmotivBuffer.NoteList[0].Pitch != null))
                                    {
                                        break;
                                    }
                                }
                                fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                FmotivBuffer.NoteList.RemoveAt(0);

                                #region Сборка последующих нот, в случае Лиги

                                // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                                {
                                    // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                    if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                    {
                                        // TODO: желательно сделать проверку когда собирается очередная лига,
                                        // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                        while (FmotivBuffer.NoteList[0].Tie == 2)
                                        {
                                            // пока продолжается лига, заносим ноты в буфер
                                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        if (FmotivBuffer.NoteList[0].Tie == 1)
                                        {
                                            // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        else
                                        {
                                            // когда лига не заканчивается флагом конца, то ошибка
                                            throw new Exception("MDA: FmotivDivider, wrong Tie organization!End!");
                                        }
                                    }
                                    else
                                    {
                                        // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                        throw new Exception("MDA: FmotivDivider, wrong Tie organization!Begining!");
                                    }
                                }

                                #endregion
                            }
                            // и складываем в выходную цепочку
                            FLTemp.Add(((Fmotiv) fmotiv.Clone()));
                        }
                        else
                        {
                            // приоритет первой ноты ниже приоритета второй ноты (метрически слабее)
                            // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                            // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                            // потому что количество равндлительных звуков поменялось, и алгоритм анализа может поменяться
                            Fmotiv fmotiv = new Fmotiv("ЧМТ");

                            // собираем в цикле, пока не кончатся ноты в буфере 1 полноценную ноту в зависимости от того, чем мы считаем паузу 
                            //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                            while (FmotivBuffer.NoteList.Count > 0)
                            {
                                if (fmotiv.Clone(paramPause).TieGathered().NoteList.Count == 1)
                                {
                                    // Silence Note OR Ignore Pause
                                    if (paramPause != PauseTreatment.NoteTrace)
                                    {
                                        break;
                                    }
                                    // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                    if ((paramPause == PauseTreatment.NoteTrace) &&
                                        (FmotivBuffer.NoteList[0].Pitch != null))
                                    {
                                        break;
                                    }
                                }
                                fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                FmotivBuffer.NoteList.RemoveAt(0);

                                #region Сборка последующих нот, в случае Лиги

                                // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                                {
                                    // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                    if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                    {
                                        // TODO: желательно сделать проверку когда собирается очередная лига,
                                        // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                        while (FmotivBuffer.NoteList[0].Tie == 2)
                                        {
                                            // пока продолжается лига, заносим ноты в буфер
                                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        if (FmotivBuffer.NoteList[0].Tie == 1)
                                        {
                                            // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        else
                                        {
                                            // когда лига не заканчивается флагом конца, то ошибка
                                            throw new Exception("MDA: FmotivDivider, wrong Tie organization!End!");
                                        }
                                    }
                                    else
                                    {
                                        // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                        throw new Exception("MDA: FmotivDivider, wrong Tie organization!Begining!");
                                    }
                                }

                                #endregion
                            }

                            // и складываем в выходную цепочку
                            FLTemp.Add(((Fmotiv) fmotiv.Clone()));

                            // вызываем рекурсию на оставшиеся ноты
                            // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                            List<Fmotiv> DividedSameDuration = DivideSameDurationNotes(FmotivBuffer);
                            for (int j = 0;
                                 j < DividedSameDuration.Count;
                                 j++)
                            {
                                // заносим очередной фмотив
                                FLTemp.Add(((Fmotiv) DividedSameDuration[j].Clone()));
                            }

                            return FLTemp;
                        }

                    }

                    // анализируем оставшиеся 3 ноты
                    if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[0].Priority <
                        FmotivBuffer.Clone(paramPause).TieGathered().NoteList[1].Priority)
                    {
                        // приоритет первой ноты выше приоритета второй ноты (собранные ноты) !!!!!!!!!!!!!!!!!!! сравнение на саомо деле происход первой и третьей, разве нет? 08.04.2012
                        if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[0].Priority <
                            FmotivBuffer.Clone(paramPause).TieGathered().NoteList[2].Priority)
                        {
                            // приоритет первой ноты выше приоритета третьей ноты (собранные ноты)
                            // ПМТ и записываем все что входит в цепочку нот - в эти три собранные ноты, в очередной фмотив
                            Fmotiv fmotiv = new Fmotiv("ПМТ");

                            // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                            //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                            while (FmotivBuffer.NoteList.Count > 0)
                            {
                                if (fmotiv.Clone(paramPause).TieGathered().NoteList.Count == 3)
                                {
                                    // Silence Note OR Ignore Pause
                                    if (paramPause != PauseTreatment.NoteTrace)
                                    {
                                        break;
                                    }
                                    // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                    if ((paramPause == PauseTreatment.NoteTrace) &&
                                        (FmotivBuffer.NoteList[0].Pitch != null))
                                    {
                                        break;
                                    }
                                }
                                fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                FmotivBuffer.NoteList.RemoveAt(0);

                                #region Сборка последующих нот, в случае Лиги

                                // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                                {
                                    // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                    if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                    {
                                        // TODO: желательно сделать проверку когда собирается очередная лига,
                                        // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                        while (FmotivBuffer.NoteList[0].Tie == 2)
                                        {
                                            // пока продолжается лига, заносим ноты в буфер
                                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        if (FmotivBuffer.NoteList[0].Tie == 1)
                                        {
                                            // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        else
                                        {
                                            // когда лига не заканчивается флагом конца, то ошибка
                                            throw new Exception("MDA: FmotivDivider, wrong Tie organization!End!");
                                        }
                                    }
                                    else
                                    {
                                        // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                        throw new Exception("MDA: FmotivDivider, wrong Tie organization!Begining!");
                                    }
                                }

                                #endregion
                            }
                            // и складываем в выходную цепочку
                            FLTemp.Add(((Fmotiv) fmotiv.Clone()));
                        }
                        else
                        {
                            // приоритет первой ноты ниже или равен приоритету третьей ноты (собранные ноты)
                            // ПМТ и записываем все что входит в цепочку нот - в эти две собранные ноты, в очередной фмотив
                            // (ЧМТ - если есть знак триоли хотя бы у одной ноты)

                            string typeF = "ПМТ"; // тип ПМТ если не триоль
                            if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList[0].Triplet ||
                                FmotivBuffer.Clone(paramPause).TieGathered().NoteList[1].Triplet)
                            {
                                typeF = "ЧМТ"; // если есть хотя б один знак триоли 
                            }

                            Fmotiv fmotiv = new Fmotiv(typeF);

                            // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                            //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                            while (FmotivBuffer.NoteList.Count > 0)
                            {
                                if (fmotiv.Clone(paramPause).TieGathered().NoteList.Count == 2)
                                {
                                    // Silence Note OR Ignore Pause
                                    if (paramPause != PauseTreatment.NoteTrace)
                                    {
                                        break;
                                    }
                                    // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                    if ((paramPause == PauseTreatment.NoteTrace) &&
                                        (FmotivBuffer.NoteList[0].Pitch != null))
                                    {
                                        break;
                                    }
                                }
                                fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                FmotivBuffer.NoteList.RemoveAt(0);

                                #region Сборка последующих нот, в случае Лиги

                                // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                                {
                                    // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                    if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                    {
                                        // TODO: желательно сделать проверку когда собирается очередная лига,
                                        // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                        while (FmotivBuffer.NoteList[0].Tie == 2)
                                        {
                                            // пока продолжается лига, заносим ноты в буфер
                                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        if (FmotivBuffer.NoteList[0].Tie == 1)
                                        {
                                            // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                            FmotivBuffer.NoteList.RemoveAt(0);
                                        }
                                        else
                                        {
                                            // когда лига не заканчивается флагом конца, то ошибка
                                            throw new Exception("MDA: FmotivDivider, wrong Tie organization!End!");
                                        }
                                    }
                                    else
                                    {
                                        // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                        throw new Exception("MDA: FmotivDivider, wrong Tie organization!Begining!");
                                    }
                                }

                                #endregion
                            }
                            // и складываем в выходную цепочку
                            FLTemp.Add(((Fmotiv) fmotiv.Clone()));

                            // если осталась одна нота то заносим ее в фмотив ЧМТ
                            if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count == 1)
                            {
                                Fmotiv fm = new Fmotiv("ЧМТ");
                                for (int j = 0; j < FmotivBuffer.NoteList.Count; j++)
                                {
                                    //заносим
                                    fm.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[j].Clone()));
                                }
                                // добавляем в выходную цепочку получившийся фмотив
                                FLTemp.Add(((Fmotiv) fm.Clone()));
                                FmotivBuffer.NoteList.Clear();
                            }
                            else
                            {
                                // если больше 1 ноты, то вызываем рекурсию на оставшиеся ноты
                                // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                                List<Fmotiv> DividedSameDuration = DivideSameDurationNotes(FmotivBuffer);
                                for (int j = 0;
                                     j < DividedSameDuration.Count;
                                     j++)
                                {
                                    // заносим очередной фмотив
                                    FLTemp.Add(((Fmotiv) DividedSameDuration[j].Clone()));
                                }
                            }
                            return FLTemp;
                        }

                    }
                    else
                    {
                        // приоритет первой ноты ниже или равен приоритету второй ноты (метрически слабее или равен)
                        // ЧМТ и записываем все что входит в первую собранную ноту в очередной фмотив,
                        // и вызываем для оставшихся нот повторный анализ цепочки равнодлительных звуков
                        // потому что количество равнодлительных звуков поменялось, и алгоритм анализа может поменяться
                        Fmotiv fmotiv = new Fmotiv("ЧМТ");

                        // собираем в цикле, пока не кончатся ноты в буфере 3 полноценные ноты в зависимости от того, чем мы считаем паузу 
                        //(когда звуковой след, надо добавить в след идущие паузы за последним звуком)
                        while (FmotivBuffer.NoteList.Count > 0)
                        {
                            if (fmotiv.Clone(paramPause).TieGathered().NoteList.Count == 1)
                            {
                                // Silence Note OR Ignore Pause
                                if (paramPause != PauseTreatment.NoteTrace)
                                {
                                    break;
                                }
                                // для Note Trace приходится отслеживать чтобы все ноты и паузы за ними идущие собрались
                                if ((paramPause == PauseTreatment.NoteTrace) &&
                                    (FmotivBuffer.NoteList[0].Pitch != null))
                                {
                                    break;
                                }
                            }
                            fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                            FmotivBuffer.NoteList.RemoveAt(0);

                            #region Сборка последующих нот, в случае Лиги

                            // проверка на наличие лиги у очередной ноты, если есть то заносим в буффер все ноты, объединенные данной лигой
                            if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie != -1)
                            {
                                // если есть флаг начала лиги, то записываем в буфер все остальные лигованные ноты, пока не будет флага конца лиги
                                if (fmotiv.NoteList[fmotiv.NoteList.Count - 1].Tie == 0)
                                {
                                    // TODO: желательно сделать проверку когда собирается очередная лига,
                                    // не будет ли пуста цепь нот, до того как лига закончится (будет флаг конца лиги)

                                    while (FmotivBuffer.NoteList[0].Tie == 2)
                                    {
                                        // пока продолжается лига, заносим ноты в буфер
                                        fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                        FmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    if (FmotivBuffer.NoteList[0].Tie == 1)
                                    {
                                        // если есть флаг конца лиги у очередной ноты, то заносим конечную ноту лиги в буфер
                                        fmotiv.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[0].Clone()));
                                        FmotivBuffer.NoteList.RemoveAt(0);
                                    }
                                    else
                                    {
                                        // когда лига не заканчивается флагом конца, то ошибка
                                        throw new Exception("MDA: FmotivDivider, wrong Tie organization!End!");
                                    }
                                }
                                else
                                {
                                    // когда начинается лига не с флага начала, а с какого то другого, то ошибка
                                    throw new Exception("MDA: FmotivDivider, wrong Tie organization!Begining!");
                                }
                            }

                            #endregion
                        }

                        // и складываем в выходную цепочку
                        FLTemp.Add(((Fmotiv) fmotiv.Clone()));

                        // если осталась одна нота то заносим ее в фмотив ЧМТ
                        if (FmotivBuffer.Clone(paramPause).TieGathered().NoteList.Count == 1)
                        {
                            Fmotiv fm = new Fmotiv("ЧМТ");
                            for (int j = 0; j < FmotivBuffer.NoteList.Count; j++)
                            {
                                //заносим
                                fm.NoteList.Add(((ValueNote) FmotivBuffer.NoteList[j].Clone()));
                            }
                            // добавляем в выходную цепочку получившийся фмотив
                            FLTemp.Add(((Fmotiv) fm.Clone()));
                            FmotivBuffer.NoteList.Clear();
                        }
                        else
                        {
                            // если больше 1 ноты, то вызываем рекурсию на оставшиеся ноты
                            // отправляем последовательность равнодлительных звуков на анализ, получаем цепочку фмотивов и заносим их в выходную последовательность
                            List<Fmotiv> DividedSameDuration = DivideSameDurationNotes(FmotivBuffer);
                            for (int j = 0;
                                 j < DividedSameDuration.Count;
                                 j++)
                            {
                                // заносим очередной фмотив
                                FLTemp.Add(((Fmotiv) DividedSameDuration[j].Clone()));
                            }
                        }
                        return FLTemp;
                    }

                    // если все собрали, то возвращаем выходную цепочку
                    return FLTemp;
                }

                #endregion
            }
        }
    }
}