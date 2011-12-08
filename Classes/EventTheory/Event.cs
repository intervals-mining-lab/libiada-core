using System;
using System.Collections;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.EventTheory
{
    ///<summary>
    /// Класс реализующий Событие
    ///</summary>
    [Serializable]
    public class Event : Space, IBaseObject
    {
        protected ArrayList Keys = new ArrayList();
        protected ArrayList Values = new ArrayList();

        public bool Access = true;


        ///<summary>
        ///</summary>
        ///<param name="Dimension"></param>
        public new void AddDimension(Dimension Dimension)
        {
            base.AddDimension(Dimension);
        }

        ///<summary>
        /// Удаляет все измерения пространтсва
        /// И очищает весь алфавит.
        ///</summary>
        public new void DeleteDimesnions()
        {
            base.DeleteDimesnions();
        }

        ///<summary>
        /// Позволяет получить одно из измерение пространтсва 
        ///</summary>
        ///<param name="i">Номер измерния в пространстве</param>
        ///<returns>Объект измерения</returns>
        public new Dimension GetDimension(int i)
        {
            return base.GetDimension(i);
        }

        ///<summary>
        /// Количество измерений пространства.
        /// Размерность пространства.
        ///</summary>
        ///<returns>Возвращает INT64. Результат всегда >=0</returns>
        public new Int64 DimensionCount()
        {
            return base.DimensionCount();
        }


        ///<summary>
        /// Свойство возвращает кол-во мест для которых определено 
        ///</summary>
        public int ReadRuleCount
        {
            get
            {
                if (Keys.Count != Values.Count)
                {
                    throw new Exception();
                }
                return Keys.Count;
            }
        }

        ///<summary>
        /// Добавляет value место в правило чтения для места Key.
        /// Key и Value - соседнии места принадлежашие данному событию, если это ограницение нарушается 
        /// выкидывается исключение
        ///</summary>
        ///<param name="Key">Место в правило для которого добавляется Value</param>
        ///<param name="Value">Место которое добавляется в правило для места Key</param>
        public void AddToReadRule(Place Key, Place Value)
        {
            if (!Keys.Contains(Key))
            {
                ReadRule temp = new ReadRule(Key);
                temp.Add(Value);
                Keys.Add(Key.Clone());
                Values.Add(temp);
            }
            else
            {
                if (!((ReadRule) Values[Keys.IndexOf(Key)]).Contains(Value))
                {
                    ((ReadRule) Values[Keys.IndexOf(Key)]).Add(Value);
                }
            }
        }

        ///<summary>
        /// Добавляет правило чтения Value для места Key.
        /// Правило чтения Value должно быть определено для эквивалентного Key места, принадлежащего данному событию, 
        /// в противном случае выкидывается исключение.
        /// В случае если для места Key уже определно правило то это правило объединяется с 
        /// Value
        ///</summary>
        ///<param name="Key">Место в правило для которого добавляется Value</param>
        ///<param name="Value">Место которое добавляется в правило для места Key</param>
        public void AddToReadRule(Place Key, ReadRule Value)
        {
            if (Value == null)
            {
                throw new NullReferenceException();
            }
            if (!Keys.Contains(Key))
            {
                Keys.Add(Key.Clone());
                Values.Add(Value.Clone());
            }
            else
            {
                ((ReadRule) Values[Keys.IndexOf(Key)]).Add(Value);
            }
        }

        ///<summary>
        /// Удаляет правило из места Key.
        /// Key должно принадлежать данному событию, иначе вызывается исключение.
        ///</summary>
        ///<param name="Key"></param>
        public void RemoveFromReadRule(Place Key)
        {
            if (Key == null)
            {
                throw new NullReferenceException();
            }
            if (Keys.Contains(Key))
            {
                Values.RemoveAt(Keys.IndexOf(Key));
                Keys.Remove(Key);
            }
        }

        ///<summary>
        /// Удаляет i-ое правило.
        ///</summary>
        ///<param name="index">Номер правила</param>
        public void RemoveFromReadRuleAt(int index)
        {
            Values.RemoveAt(index);
            Keys.RemoveAt(index);
        }

        ///<summary>
        /// Получить правило для места Key.
        /// Key должно принадлежать данному событию, иначе вызывается исключение.
        ///</summary>
        ///<param name="Key"></param>
        ///<returns></returns>
        public ReadRule GetFromReadRule(Place Key)
        {
            if (Key == null)
            {
                throw new NullReferenceException();
            }
            int pos = Keys.IndexOf(Key);
            return pos == -1 ? null : ((ReadRule) Values[pos]).Clone();
        }

        ///<summary>
        ///</summary>
        ///<param name="From"></param>
        ///<param name="To"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public ReadPath GetReadPath(Place From, Place To)
        {
            if (!From.CompatibleTo(To))
            {
                throw new Exception("Место From не совместимо с местом To");
            }
            throw new Exception("Метод нахождения пути чтения не реализован");
        }


        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<param name="apoint"></param>
        ///<param name="bpoint"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Rapprochement(Event a, Event b, Place apoint, Place bpoint)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<param name="absolute_priority"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Adding(Event b, bool absolute_priority)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        public Event Add(Event b)
        {
            return (Adding(b, true));
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        public Event AddRelative(Event b)
        {
            return (Adding(b, false));
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Joining(Event b)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Removing(Event b)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Removal(Event b)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Removal(object b)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Induction(Event b)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Deduction(Event b)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Syntheses(Event b)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Analysis(Event b)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Join(Event b)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public virtual Event Separation(Event b)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return EqualsAsEvent(obj as Event);
        }

        protected bool EqualsAsEvent(Event Event)
        {
            if (!EqualsAsSpace(Event))
            {
                return false;
            }
            if (ReadRuleCount != Event.ReadRuleCount)
            {
                return false;
            }

            for (int i = 0; i < ReadRuleCount; i++)
            {
                if (!Event.Keys.Contains(Keys[i]) ||
                    !Values[i].Equals(Event.GetFromReadRule((Place) Keys[i])))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            throw new Exception("Method GetHashCode not defined. Class EventTheory.Classes.Math.Event");
        }

        /*
        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static Event operator |(Event a, Event b)
        {
            return (a.Separation(b));
        }

        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static bool operator >(Event a, Event b)
        {
            return (a.CompareTo(b) > 0);
        }

        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static bool operator <(Event a, Event b)
        {
            return (b.CompareTo(a) < 0);
        }

        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static bool operator >=(Event a, Event b)
        {
            return (a.CompareTo(b) >= 0);
        }

        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static bool operator <=(Event a, Event b)
        {
            return (a.CompareTo(b) <= 0);
        }

        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static bool operator ==(Event a, Event b)
        {
            return (a.CompareTo(b) == 0);
        }

        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static bool operator !=(Event a, Event b)
        {
            return (a.CompareTo(b) != 0);
        }
        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static Event operator &(Event a, Event b)
        {
            return (a.Join(b));
        }
        
        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static Event operator %(Event a, Event b)
        {
            return (a.Analysis(b));
        }
         
        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static Event operator ^(Event a, Event b)
        {
            return (a.Syntheses(b));
        }        
        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static Event operator -(Event a, Event b)
        {
            return (a.Removal(b));
        }

        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static Event operator -(Event a, object b)
        {
            return (a.Removal(b));
        }
        
        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static Event operator /(Event a, Event b)
        {
            return (a.Removing(b));
        }
        
        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static Event operator *(Event a, Event b)
        {
            return (a.Joining(b));
        }        
        
        ///<summary>
        ///</summary>
        ///<param name="a"></param>
        ///<param name="b"></param>
        ///<returns></returns>
        public static Event operator +(Event a, Event b)
        {
            return (a.Add(b));
        }
        */

        public override IBaseObject Clone()
        {
            Event temp = new Event();
            FillClone(temp);
            return temp;
        }

        protected override void FillClone(IBaseObject temp)
        {
            base.FillClone(temp);
            Event TempEvent = temp as Event;
            if (TempEvent != null)
            {
                TempEvent.Values = (ArrayList) Values.Clone();
                TempEvent.Keys = (ArrayList) Keys.Clone();
            }
        }
    }
}