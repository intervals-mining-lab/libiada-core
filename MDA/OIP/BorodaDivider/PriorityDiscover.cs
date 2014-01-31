using System;
using System.Collections.Generic;
using LibiadaMusic.OIP.ScoreModel;

namespace LibiadaMusic.OIP.BorodaDivider
{
    public class PriorityDiscover
    {
        private Measure priorityMask;
        
        //маска - разметка приоритетов на пустой такт, 
        //совмещение которого с оригинальным позволит определить приоритеты реальных нот

        public Measure PriorityMask
        {
            get
            {
                return priorityMask;
            }
        }

        public void Calculate(ScoreTrack scoretrack) 
        {   // метод для подсчета приоритетов нот во всем Scoretrack
            foreach (UniformScoreTrack utrack in scoretrack.UniformScoreTracks) 
            {
                Calculate(utrack);
            }
        }
        public void Calculate(UniformScoreTrack utrack)
        {   // метод для подсчета приоритетов нот для каждого такта (Measure) в монофоническом треке (UniformScoretrack)
            foreach (Measure measure in utrack.Measurelist)
            {
                this.Calculate(measure);
            }
        }
        public void Calculate(Measure measure)
        {
            // создаем новый такт, куда будут складываться ноты, после определения их приоритета.
            Measure Temp = new Measure(new List<Note>(), (Attributes)measure.Attributes.Clone());
            // считаем маску приоритетов для такта
            CalcPriorityMask(measure);
            // соотнесение маски приоритетов и реального такта
            double bufduration = 0; // буфер длительности
            List<Note> noteBuf = new List<Note>(); // буфер нот для сбора триоли и передачи в CollectTriplet
            List<Note> maskBuf = new List<Note>(); // буфер маски приоритетов для сбора приоритетов маски под триолью и передачи в CollectTriplet 
            double tripletDuration = 0;
            // для каждой ноты подсчет приоритета, либо собирание в триоль и отдельный подсчет приоритетов
            foreach (Note note in measure.NoteList) 
            {
                if (note.Triplet)
                {
                    // если идет две триоли подряд, то как только первая сменяет вторую - меняется размер длительности у след. ноты
                    // и как только это произошло, нужно сначала проанализировать первую триоль и потом начать заполнять вторую
                    if ((note.Duration.Value!=tripletDuration) && (noteBuf.Count > 0))
                    {
                        while (bufduration > 0.0000001)
                        {   // собираем буфер маски приоритетов для триоли, 
                            // собираем пока суммарная длительность нот маски не превышает длительность реальных нот триоли
                            maskBuf.Add((Note)priorityMask.NoteList[0].Clone());
                            bufduration = bufduration - priorityMask.NoteList[0].Duration.Value;
                            priorityMask.NoteList.RemoveAt(0);
                        }
                        //передача методу CountTriplet notebuf + maskbuf и расстановка приоритетов + передача обратно
                        //занесение в выходной буфер результата определения приоритета нот триоли
                        foreach (Note tnote in CountTripletPriority(noteBuf, maskBuf))
                        {
                            Temp.NoteList.Add((Note)tnote.Clone());
                        }
                        //Temp.Notelist.AddRange(CountTripletPriority(noteBuf,maskBuf));

                        // зануление буферов
                        noteBuf.Clear();
                        maskBuf.Clear();
                        bufduration = 0;
                    }
                    // последовательность реальных нот триоли (триплета) заносится в буфер для дальнейшей обработки
                    // считается суммарная длительность триоли
                    noteBuf.Add((Note)note.Clone());
                    tripletDuration = note.Duration.Value; // сохраняем размерность триоли/ новой триоли (если две подряд)
                    bufduration = bufduration + note.Duration.Value;
                }
                else 
                { // если следущая нота не триоль, то проверка, собиралась ли она шагом ранее, если да то вызов метода CollectTriplet,
                    if (noteBuf.Count > 0)
                    {
                        while (bufduration > 0.0000001)
                        {   // собираем буфер маски приоритетов для триоли, 
                            // собираем пока суммарная длительность нот маски не превышает длительность реальных нот триоли
                            maskBuf.Add((Note)priorityMask.NoteList[0].Clone());
                            bufduration = bufduration - priorityMask.NoteList[0].Duration.Value;
                            priorityMask.NoteList.RemoveAt(0);
                        }
                        //передача методу CountTriplet notebuf + maskbuf и расстановка приоритетов + передача обратно
                        //занесение в выходной буфер результата определения приоритета нот триоли
                        foreach (Note tnote in CountTripletPriority(noteBuf, maskBuf))
                        {
                            Temp.NoteList.Add((Note)tnote.Clone());
                        }
                        //Temp.Notelist.AddRange(CountTripletPriority(noteBuf,maskBuf));
                        
                        // зануление буферов
                        noteBuf.Clear();
                        maskBuf.Clear();
                        bufduration = 0;
                   }
                       // так как следущая нота не триплет, то определяем ее приоритет по следущему алгоритму
                       // присвоение приоритета при нахожении начала позиции следущей ноты в маске приоритетов
                        note.Priority = priorityMask.NoteList[0].Priority;
                        //занесение в буфер длительности следующей ноты маски приоритетов
                        bufduration = priorityMask.NoteList[0].Duration.Value;
                        //удаление этой ноты из общей маски приоритетов
                        priorityMask.NoteList.RemoveAt(0);

                        // цикл, если набралось в буфер нот общей длительностью равной реальной ноте, то переходим к следующей реальной ноте
                        while ((note.Duration.Value - bufduration)> 0.0000001) 
                        //while (bufduration < note.Duration.Value) 
                        {
                            if (priorityMask.NoteList.Count < 1) 
                            {
                                throw new Exception("LibiadaMusic Priority Discover: такт построен не по правилам, не хватает ноты");
                            }
                            //набор длительностей нот маски, и их удаление из очереди
                            bufduration = bufduration + priorityMask.NoteList[0].Duration.Value;
                            priorityMask.NoteList.RemoveAt(0);
                        }
                        
                        //переход к следующей реальной ноте
                        Temp.NoteList.Add((Note)note.Clone());
                        bufduration = bufduration - note.Duration.Value; 
                        //bufduration = 0;
                    
                }
            }
            // проверка буфера триоли, на случай когда триоль стоит вконце, чтобы не было потери нот
            if (noteBuf.Count > 0)
            {
                while (bufduration > 0.0000001)
                {   // собираем буфер маски приоритетов для триоли, 
                    // собираем пока суммарная длительность нот маски не превышает длительность реальных нот триоли
                    maskBuf.Add((Note)priorityMask.NoteList[0].Clone());
                    bufduration = bufduration - priorityMask.NoteList[0].Duration.Value;
                    priorityMask.NoteList.RemoveAt(0);
                }
                //передача методу CountTriplet notebuf + maskbuf и расстановка приоритетов + передача обратно
                //занесение в выходной буфер результата определения приоритета нот триоли
                foreach (Note tnote in CountTripletPriority(noteBuf, maskBuf)) 
                {
                    Temp.NoteList.Add((Note)tnote.Clone());
                }
                //Temp.Notelist.AddRange(CountTripletPriority(noteBuf, maskBuf));
                

                // зануление буферов
                noteBuf.Clear();
                maskBuf.Clear();
                bufduration = 0;
            }
            // присваиваем полю приоритет входного объекта, вычисленный приоритет в Temp соответственно
            for (int i = 0; i < measure.NoteList.Count; i++) 
            {
                measure.NoteList[i].Priority = Temp.NoteList[i].Priority;
                if (measure.NoteList[i].Priority < 0) 
                {
                    throw new Exception("LibiadaMusic.PriorityDiscover: не выявлен приоритет для одной из нот (равен -1)");
                }
            }
        }

        public List<Note> CountTripletPriority(List<Note> noteBuf, List<Note> maskBuf)
        { // TODO: расчет приоритетов для триоли с числом нот больше 3 выполняется по четко не определенному правилу, сделать как должно быть
            List<Note> TTemp = new List<Note>();
            double bufduration = 0;
            int count = noteBuf.Count; // записываем в отдельный счетчик т.к. значение noteBuf.Count меняется во время цикла
            for (int i = 0; i < count; i++ )
            {
                if (maskBuf.Count < 1)
                { // если для разбираемой очереди нот-триолей, в очереди нот маски приоритетов не осталось нот,
                  //то следущей ноте-триоли присваивается приоритеты предыдущей ноты-триоли
                    noteBuf[0].Priority = TTemp[TTemp.Count - 1].Priority;
                    TTemp.Add((Note)noteBuf[0].Clone());
                    noteBuf.RemoveAt(0);
                }
                else
                {
                    noteBuf[0].Priority = maskBuf[0].Priority;
                    // отнимаем из маски приоритетов нот на сумму равную номинальному (не реальному) значению длительности триольной ноты
                    bufduration = noteBuf[0].Duration.oValue; // оиргинальная длительность
                    TTemp.Add((Note)noteBuf[0].Clone()); // добавляем ноту триоль в выходной буфер
                    noteBuf.RemoveAt(0); // удаляем ноту-триоль из разбираемой очереди
                    while (bufduration > 0.0000001)
                    {
                        // по одной удаляем из маски приоритетов ноты, сумма длительностей которых равна номинальной длительности текущей разбираемой ноты
                        if (maskBuf.Count < 1) break; // если ноты в маске закончились то выходим из цикла
                        bufduration = bufduration - maskBuf[0].Duration.Value; // отнимаем из значения длительности ноты-триоли длительность очередной ноты маски
                        maskBuf.RemoveAt(0); // удаляем ноту маски из очереди (маски приоритетов)
                    }
                }
                
            }

            return (List<Note>)TTemp; // возвращаем результат
        }

        public double minDuration(Measure measure) 
        {
            //Метод находит минимальную длительность ноты/паузы в такте

            double value = 0;
            if (measure.NoteList.Count > 0) {value = measure.NoteList[0].Duration.Value;} 
                // заносим в буфер первый элемент массива длительностей нот, если такт пустой - ошибка!
            else throw new Exception("LibiadaMusic.OIP: обнаружен пустой такт при выявлении приоритета!");
            
            foreach (Note note in measure.NoteList) 
            {
                if (value > note.Duration.Value) 
                {
                    value = note.Duration.Value;
                }
            }
            return value;
        }

        public void CalcPriorityMask(Measure measure) 
        {
            // создание объекта маски с атрибутами оригинала и пустым списком нот
            priorityMask = new Measure(new List<Note>(), (Attributes)measure.Attributes.Clone());

//---------------------------Занесение начальных долей размера такта---------------------------
//---------------------------------------------------------------------------------------------
            priorityMask.NoteList.Add(new Note((Pitch)null, new Duration(1, measure.Attributes.Size.Beatbase,
                false, measure.Attributes.Size.Ticksperbeat), false, Tie.None, 0));
                // первая доля в такте всегда самая сильная и выделяется НАИВЫСШИМ приоритетом 0

                if (measure.Attributes.Size.Beats % 2 == 0)
                {
                    //ПМТ-2 - двудольный метр/размер такта
                    for (int i = 1; i < measure.Attributes.Size.Beats; i++) // начиная со второй доли заполняем чередуя приоритет через одну долю
                    {
                        if (i % 2 == 0)
                        { //относительно сильная доля с приоритетом 1
                            int priority = 1;
                            priorityMask.NoteList.Add(new Note((Pitch)null, new Duration(1, measure.Attributes.Size.Beatbase,
                                            false, measure.Attributes.Size.Ticksperbeat), false, Tie.None, priority));
                        }
                        else
                        { //слабая доля с приоритетом 2
                            int priority = 2;
                            //если всего две доли то более слабая будет иметь приоритет 1, так как больше нет долей
                            if (measure.Attributes.Size.Beats == 2) { priority = 1; }

                            priorityMask.NoteList.Add(new Note((Pitch)null, new Duration(1, measure.Attributes.Size.Beatbase,
                                            false, measure.Attributes.Size.Ticksperbeat), false, Tie.None, priority));
                        }
                    }

                }
                else
                {
                    if (measure.Attributes.Size.Beats % 3 == 0)
                    {
                        //ПМТ-3 - трёхдольный метр/размер такта
                        for (int i = 1; i < measure.Attributes.Size.Beats; i++) // начиная со второй доли заполняем чередуя приоритет через две доли
                        {
                            if (i % 3 == 0)
                            { //относительно сильная доля с приоритетом 1
                                int priority = 1;
                                priorityMask.NoteList.Add(new Note((Pitch)null, new Duration(1, measure.Attributes.Size.Beatbase,
                                                false, measure.Attributes.Size.Ticksperbeat), false, Tie.None, priority));
                            }
                            else
                            { //слабая доля с приоритетом 2
                                int priority = 2;
                                //если всего три доли то более слабые будут иметь приоритет 1, так как больше нет других долей
                                if (measure.Attributes.Size.Beats == 3) { priority = 1; }

                                priorityMask.NoteList.Add(new Note((Pitch)null, new Duration(1, measure.Attributes.Size.Beatbase,
                                                false, measure.Attributes.Size.Ticksperbeat), false, Tie.None, priority));
                            }
                        }                        
                    }
                    else
                    {
                        //ПМТ-К сложный метр/размер такта      
                        for (int i = 1; i < measure.Attributes.Size.Beats; i++) // начиная со второй доли заполняем чередуя приоритет через 
                                                                                  //одну долю и последнюю долю записываем как слабую
                        {
                            if (i % 2 == 0)
                            { //относительно сильная доля с приоритетом 1
                                int priority = 1;
                                // если сильная доля последняя - записываем ее как слабую в ПМТ-3
                                if (i == measure.Attributes.Size.Beats - 1) { priority = 2; }

                                priorityMask.NoteList.Add(new Note((Pitch)null, new Duration(1, measure.Attributes.Size.Beatbase,
                                                false, measure.Attributes.Size.Ticksperbeat), false, Tie.None, priority));
                            }
                            else
                            { //слабая доля с приоритетом 2
                                int priority = 2;
                                priorityMask.NoteList.Add(new Note((Pitch)null, new Duration(1, measure.Attributes.Size.Beatbase,
                                                false, measure.Attributes.Size.Ticksperbeat), false, Tie.None, priority));
                            }
                        }                        

                    }
                }
//---------------------------Разложение долей такта на более низкий уровень, ---------------------------
//---------------------------пока не будут известны приоритеты для нот с минимальной длительностью------
//------------------------------------------------------------------------------------------------------                
                bool stop = true; // флаг останова, когда просчитаются приоритеты для всех нот,
                //длительность которых окажется меньше либо равна минимальной, деленной на 2 (так как может быть точка у ноты, котору. возможно описать только 3 нотами короче в два раза чем сама нота),
                //если они уже просчитаны для всех нот, то процесс заканчивается
                // проверка: останов будет тогда, когда длительности ВСЕХ нот в маске будут меньше либо равны длительности минимально ноты
                foreach (Note note in priorityMask.NoteList)
                {
                    if (note.Duration.Value > minDuration(measure)/2)
                    {
                        stop = false;
                    }
                }                    
            
            while (!stop) 
            {
                Measure Temp = new Measure(new List<Note>(),(Attributes)priorityMask.Attributes.Clone());
                // создание объекта буфера для перехода к следущей маске нижнего уровня

                // определение максимального (наименьшего приоритета) для спуска на уровень ниже,
                //где появятся ноты с приоритетом еще ниже на 1 ( +1)
                int maxpriority = 0;
                foreach(Note note in priorityMask.NoteList)
                {
                    if (maxpriority < note.Priority)
                    {
                        maxpriority = note.Priority;
                    }
                }

                for (int i = 0; i < priorityMask.NoteList.Count; i++)
                {

                    Temp.NoteList.Add(new Note((Pitch)null, new Duration(1, (priorityMask.NoteList[i].Duration.Denominator * 2),
                        false, (priorityMask.NoteList[i].Duration.Ticks / 2)), false, Tie.None, priorityMask.NoteList[i].Priority));
                    Temp.NoteList.Add(new Note((Pitch)null, new Duration(1, (priorityMask.NoteList[i].Duration.Denominator * 2),
                        false, (priorityMask.NoteList[i].Duration.Ticks / 2)), false, Tie.None, (maxpriority + 1)));
                }
                
                // присваем объекту маске новый получившейся объект уровня ниже 
                priorityMask = (Measure)Temp.Clone();

                // высталение флага останова
                stop = true;

                // проверка: останов будет тогда, когда длительности ВСЕХ нот в маске будут меньше либо равны длительности минимальной ноты 
                //деленной на два (смотри выше из-за точки)
                foreach (Note note in priorityMask.NoteList)
                {
                    if (note.Duration.Value > minDuration(measure)/2) 
                    {
                        stop = false;
                    }
                }
            }

        }

    }
}
