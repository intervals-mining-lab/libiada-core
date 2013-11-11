using System;
using System.Collections.Generic;
using System.Text;
using MDA.OIP.ScoreModel;
using ChainAnalises.Classes.Root;

namespace MDA.OIP.BorodaDivider
{
    public class Fmotiv : IBaseObject // класс для хранения ф-мотива
    {
        private int id; // (-1 значит не определен) порядковый номер - идентификатор (возможно введения доп id - глобального для словаря ф-мотивов)
        private string type = ""; // тип ф-мотива (ПМТ, МТ, ВП, ПМТВП, МТВП)
        private List<Note> notelist; // список нот, входящих в  ф-мотив

        public Fmotiv(int id, string type) 
        {
            // конструктор для ф-мотива с уже определенным id
            this.id = id;
            this.type = type;
            this.notelist = new List<Note>();
        }
        public Fmotiv(string type)
        {
            // конструктор для ф-мотива с неопределенным id
            this.id = -1;
            this.type = type;
            this.notelist = new List<Note>();
        }
        
        public List<Note> NoteList
        {
            get
            {
                return notelist;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set 
            {
                this.type = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }

        // TODO: убрать все частные и заменить на общие!!!!!!!!! заменил все withoutpauses() на PauseTreatment с параметорм ignore
        public Fmotiv PauseTreatment(int paramPause)
        {           //возвращает копию этого объекта

            switch (paramPause)
            {
                case 0:
                    {// удаляем все паузы в возвращаемом объекте (0) (паузы игнорируются)
                        Fmotiv Temp = new Fmotiv(this.id, this.type);
                        Temp = (Fmotiv)this.Clone();
                        for (int i = 0; i < Temp.notelist.Count; i++)
                        {
                            if (Temp.notelist[i].Pitch == null)
                            {
                                Temp.notelist.RemoveAt(i);
                                i = i - 1;
                            }
                        }
                        return Temp;
                    }
                    break;
                case 1:
                    {// длительность паузы прибавляется к предыдущей ноте, а она сама удаляется из текста (1) (пауза - звуковой след ноты)
                        Fmotiv Temp = new Fmotiv(this.id, this.type);
                        Temp = (Fmotiv)this.Clone();

                        // если пауза стоит вначале текста (и текст не пустой) то она удаляется
                        while (Temp.notelist.Count > 0)
                        {   if (Temp.NoteList[0].Pitch!=null)
                            {
                                break;
                            }
                            else
                            {
                                Temp.notelist.RemoveAt(0);
                            }
                        }

                        for (int i = 0; i < Temp.notelist.Count; i++)
                        {
                            
                            if (Temp.notelist[i].Pitch == null)
                            {
                                // к длительности предыдущего звука добавляем длительность текущей паузы 
                                Temp.notelist[i - 1].Duration.AddDuration((Duration)Temp.notelist[i].Duration.Clone());
                                // удаляем паузу
                                Temp.notelist.RemoveAt(i);
                                i = i - 1;
                            }
                        }
                        return Temp;
                    }
                    break;
                case 2:
                    {// Пауза - звук тишины, рассматривается как нота без высоты звучания (2)
                     // ничего не треуется
                        Fmotiv Temp = new Fmotiv(this.id, this.type);
                        Temp = (Fmotiv)this.Clone();
                        return Temp;
                    }
                    break;
                
                default:
                    throw new Exception("Error Fmotiv.PauseTreatment parameter contains wrong value!");
            }


           

        }
        public Fmotiv TieGathered()
        {
            //возвращает копию этого объекта, соединив все залигованные ноты, если такие имеются
            // (тоесть вместо трех залигованных нот в фмотиве будет отображаться одна, с суммарной длительностью но такой же высотой
            Note BuffNote = null;
            Fmotiv Temp = (Fmotiv)this.Clone();
            Fmotiv TempGathered = new Fmotiv(this.id,this.type);

            int count = Temp.notelist.Count;

            for (int i = 0; i < count; i++)
            {
                // неправильный код лиги, лига кодируется {-1,0,1,2}
                if ((Temp.NoteList[0].Tie > 2) || (Temp.NoteList[0].Tie < -1)) { throw new Exception("MDA: Tie is not valid!"); }

                // если лига отсутствует
                if (Temp.NoteList[0].Tie == -1)
                {
                    if (BuffNote != null) { throw new Exception("MDA: Tie started but (stop)/(startstop) note NOT following!"); }
                    TempGathered.NoteList.Add(((Note)Temp.NoteList[0].Clone()));
                    // очистка текущей позиции ноты, для перехода к следущей в очереди
                    Temp.NoteList.RemoveAt(0);
                }
                else
                {
                    // пауза не может быть залигованна, ошибка если лига на паузе! 
                    if (Temp.NoteList[0].Pitch == null) { throw new Exception("MDA: Pause can't be with Tie! Sorry!"); }

                    // начало лиги стартовая нота
                    if (Temp.NoteList[0].Tie == 0) 
                    {   // если уже был старт лиги, и еще раз начинается старт
                        if (BuffNote != null) { throw new Exception("MDA: Tie note start after existing start note!"); }
                        BuffNote = ((Note)Temp.NoteList[0].Clone());
                        // очистка текущей позиции ноты, для перехода к следущей в очереди
                        Temp.NoteList.RemoveAt(0);
                    }
                    else
                    {
                        // должно быть уже собрано что то в буффере так как лига продолжающаяся или завершающаяся
                        if (BuffNote == null) { throw new Exception("MDA: Tie note (stopes and starts)/(stops), without previous note start!"); }
                        // высота залигованных нот должна быть одинакова
                        if (!BuffNote.Pitch.Equals(Temp.NoteList[0].Pitch)) { throw new Exception("MDA: Pitches of tie notes not equal!"); }

                        // уже начавшаяся лига продолжается, с условием что будет еще следущая лигованная нота
                        if (Temp.NoteList[0].Tie == 2)
                        {
                            // добавляется длительность, и копируется старая высота звучания и приоритет
                            BuffNote = new Note((Pitch)BuffNote.Pitch.Clone(), BuffNote.Duration.AddDuration(Temp.NoteList[0].Duration), BuffNote.Triplet, Tie.None, BuffNote.Priority);
                            // очистка текущей позиции ноты, для перехода к следущей в очереди
                            Temp.NoteList.RemoveAt(0);
                        }
                        else
                        {
                            // конечная нота в последовательности лигованных нот
                            if (Temp.NoteList[0].Tie == 1)
                            {
                                // добавляется длительность, и копируется старая высота звучания и приоритет
                                BuffNote = new Note((Pitch)BuffNote.Pitch.Clone(), BuffNote.Duration.AddDuration(Temp.NoteList[0].Duration), BuffNote.Triplet, Tie.None, BuffNote.Priority);
                                // завершен сбор лигованных нот, результат кладется в возвращаемый буфер.
                                TempGathered.NoteList.Add(((Note)BuffNote.Clone()));
                                // очистка буффера залигованных нот
                                BuffNote = null;
                                // очистка текущей позиции ноты, для перехода к следущей в очереди
                                Temp.NoteList.RemoveAt(0);
                            }
                            else 
                            {
                                { throw new Exception("MDA: Tie is not valid!"); }
                            }

                        }
                    }
                }
            }
            return TempGathered;
        }

        #region IBaseMethods

        private Fmotiv()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }

        public IBaseObject Clone()
        {
            Fmotiv Temp = new Fmotiv(this.id,this.type);
            foreach (Note note in notelist) 
            {
                Temp.notelist.Add((Note)note.Clone());
            }
            return Temp;
        }


        //TODO: убрал метод override , соотвественно euals сейчас просто выполняет сравнение ссылок объектов переделать все частные
        public override bool Equals(object obj)
        {
            // для сравнения паузы не нужны, поэтому сравнивае ф-мотивы без пауз (они игнорируются, но входят в состав ф-мотива)
            Fmotiv Temp1 = this.PauseTreatment(ParamPauseTreatment.Ignore).TieGathered();
            Fmotiv Temp2 = ((Fmotiv)obj).PauseTreatment(ParamPauseTreatment.Ignore).TieGathered();
            int Modulation = 0;
            bool FirstTime = true;

            if (Temp1.NoteList.Count != Temp2.NoteList.Count)
            {
                //фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for (int i = 0; i < Temp1.notelist.Count; i++)
            {

                // одинаковы ли длительности у нот?
                if (!Temp1.notelist[i].Duration.Equals(Temp2.notelist[i].Duration))
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }
                
                if (FirstTime) 
                { // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                  //последущие должны отличаться на столько же, чтобы фмотивы были равны
                    Modulation = Temp1.NoteList[i].Pitch.Midinumber - Temp2.NoteList[i].Pitch.Midinumber;
                    FirstTime = false;
                }

                // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                if (Modulation != (Temp1.NoteList[i].Pitch.Midinumber - Temp2.NoteList[i].Pitch.Midinumber))
                {
                    return false;
                }
            }

            return true;
        }
        
        public bool FmEquals(object obj, int paramPause, int paramEqual)
        {
            // для сравнения паузы не нужны, поэтому сравнивае ф-мотивы без пауз (они игнорируются, но входят в состав ф-мотива)
            Fmotiv Temp1 = this.PauseTreatment(paramPause).TieGathered();
            Fmotiv Temp2 = ((Fmotiv)obj).PauseTreatment(paramPause).TieGathered();
            int Modulation = 0;
            bool FirstTime = true;

            if (Temp1.NoteList.Count != Temp2.NoteList.Count) 
            {
                //фмотивы - неодинаковы, так как входит разное количество нот
                return false;
            }

            for(int i = 0; i < Temp1.notelist.Count; i++)
            {

                // одинаковы ли длительности у нот?
                if (!Temp1.notelist[i].Duration.Equals(Temp2.notelist[i].Duration))
                {
                    //если нет - фмотивы - неодинаковы
                    return false;
                }

                if ((Temp1.notelist[i].Pitch == null) || (Temp2.notelist[i].Pitch == null))
                {
                    if (!((Temp1.notelist[i].Pitch == null) && (Temp2.notelist[i].Pitch == null)))
                    {// если одна из нот пауза, а вторая - нет, то ф-мотивы не одинаковы
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

                            if (FirstTime)
                            { // при первом сравнении вычисляем на сколько полутонов отличаются первые ноты,
                                //последущие должны отличаться на столько же, чтобы фмотивы были равны
                                Modulation = Temp1.NoteList[i].Pitch.Midinumber - Temp2.NoteList[i].Pitch.Midinumber;
                                FirstTime = false;
                            }

                            // одинаковы ли при этом высоты / правильно ли присутствует секвентный перенос (модуляция)
                            if (Modulation != (Temp1.NoteList[i].Pitch.Midinumber - Temp2.NoteList[i].Pitch.Midinumber))
                            {
                                return false;
                            }
                        }
                        break;

                        case 1:
                        {  //без секвентного переноса (NonSequent)
                        
                            if (!(Temp1.NoteList[i].Pitch.Midinumber == Temp2.NoteList[i].Pitch.Midinumber))
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
        
        public IBin GetBin()
        {
            FmotivBin Temp = new FmotivBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class FmotivBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new Fmotiv();
            }
        }

        #endregion
    }
}
